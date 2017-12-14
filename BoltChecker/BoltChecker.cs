using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace BoltChecker
{
	public partial class BoltChecker : Form
	{
		private readonly Model _model;
		private List<BoltArray> _boltArrays;
		private List<BoltArray> _boltResults = new List<BoltArray>();

		public BoltChecker()
		{
			_model = new Model();
			if (!_model.GetConnectionStatus()) return;

			InitializeComponent();

			InitializeUi();

			UpdateProperties();
		}

		private void InitializeUi()
		{
			textBoxName.Text = _model.GetProjectInfo().Name;
			textBoxNumber.Text = _model.GetProjectInfo().ProjectNumber;
			textBoxBuilder.Text = _model.GetProjectInfo().Builder;

			ModelObjectEnumerator.AutoFetch = true;
			_boltArrays = _model
				.GetModelObjectSelector()
				.GetAllObjectsWithType(ModelObject.ModelObjectEnum.BOLT_ARRAY)
				.ToList()
				.OfType<BoltArray>()
				.ToList();

			var boltSizes = _boltArrays
				.Select(b => Math.Round(b.BoltSize, 2).ToString())
				.Distinct()
				.OrderBy(b => b)
				.ToList();
			boltSizes.Insert(0, string.Empty);
			listBoxSize.DataSource = boltSizes;

			var boltStandards = _boltArrays
				.Select(b => b.BoltStandard)
				.Distinct()
				.OrderBy(b => b)
				.ToList();
			boltStandards.Insert(0, string.Empty);
			listBoxStandard.DataSource = boltStandards;

			var boltTypes = _boltArrays.Select(b => b.BoltType.ToString())
				.Distinct()
				.OrderBy(b => b)
				.ToList();
			boltTypes.Insert(0, string.Empty);
			listBoxType.DataSource = boltTypes;
		}

		private void listBoxSize_Click(object sender, EventArgs e)
		{
			UpdateProperties();
		}

		private void listBoxStandard_Click(object sender, EventArgs e)
		{
			UpdateProperties();
		}

		private void listBoxType_Click(object sender, EventArgs e)
		{
			UpdateProperties();
		}

		private void UpdateProperties()
		{
			this.textBoxProperties.Text = $"{listBoxSize.Text} " +
			                              $"{listBoxStandard.Text} " +
			                              $"{listBoxType.Text}";
		}

		private void btnCheckBolts_Click(object sender, EventArgs e)
		{
			var boltSizeResult = listBoxSize.Text != string.Empty
				? _boltArrays
					.Where(b => Math.Round(b.BoltSize, 2).ToString() == listBoxSize.Text)
					.ToList()
				: _boltArrays;

			var boltStandardResult = listBoxStandard.Text != string.Empty
				? boltSizeResult
					.Where(b => b.BoltStandard == listBoxStandard.Text)
					.ToList()
				: boltSizeResult;

			var boltTypeResult = listBoxType.Text != string.Empty
				? boltStandardResult
					.Where(b => b.BoltType.ToString() == listBoxType.Text)
				: boltStandardResult;

			_boltResults = boltTypeResult.ToList();

			var boltViews = _boltResults
				.GroupBy(GetBoltResult)
				.Distinct()
				.Select(g => new BoltView
				{
					Size = g.Key.Size,
					Standard = g.Key.Standard,
					Type = g.Key.Type,
					Quantity = g.Count()
				})
				.OrderBy(k => k.Size)
				.ThenBy(k => k.Standard)
				.ThenBy(k => k.Type)
				.ToList();

			dataGridViewResults.DataSource = boltViews;
		}

		private void displayBoltsInModel_Click(object sender, EventArgs e)
		{
			if (!_boltResults.Any()) return;

			var row = dataGridViewResults.CurrentRow?.DataBoundItem as BoltView;

			var result = _boltResults.Where(b => Math.Round(b.BoltSize, 2).ToString() == row.Size &&
			                                     b.BoltStandard == row.Standard &&
			                                     b.BoltType == row.Type).ToList();

			var drawer = new GraphicsDrawer();

			result.ForEach(b =>
				{
					var location = b.FirstPosition;
					var color = new Color(1, 1, 1);
					var text = $"{Math.Round(b.BoltSize, 2)} {b.BoltStandard} {b.BoltType}";
					drawer.DrawText(location, text, color);
				});
		}

		private void buttonExportToPdf_Click(object sender, EventArgs e)
		{
			ExportToPdf();
		}

		private BoltResult GetBoltResult(BoltArray bolt)
		{
			return new BoltResult
			{
				Size = Math.Round(bolt.BoltSize, 2).ToString(),
				Standard = bolt.BoltStandard,
				Type = bolt.BoltType,
			};
		}

		private void ExportToPdf()
		{
			try
			{
				var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
				string path = $"d:\\{_model.GetProjectInfo().Name}.pdf";
				PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
				pdfDoc.Open();

				var imagepath = @"D:\RazorCX\Logos\Logo.png";
				using (FileStream fs = new FileStream(imagepath, FileMode.Open))
				{
					var png = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
					png.ScalePercent(5f);
					png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
					pdfDoc.Add(png);
				}

				var spacer = new Paragraph("")
				{
					SpacingBefore = 10f,
					SpacingAfter = 10f,
				};
				pdfDoc.Add(spacer);

				var headerTable = new PdfPTable(new[] { .75f, 2f })
				{
					HorizontalAlignment = Left,
					WidthPercentage = 75,
					DefaultCell = { MinimumHeight = 22f }
				};

				headerTable.AddCell("Date");
				headerTable.AddCell(DateTime.Now.ToString());
				headerTable.AddCell("Name");
				headerTable.AddCell(textBoxName.Text);
				headerTable.AddCell("Project Number");
				headerTable.AddCell(textBoxNumber.Text);
				headerTable.AddCell("Builder");
				headerTable.AddCell(textBoxBuilder.Text);

				pdfDoc.Add(headerTable);
				pdfDoc.Add(spacer);

				var columnCount = dataGridViewResults.ColumnCount;
				var columnWidths = new[] { 0.75f, 2f, 2f, 0.75f };

				var table = new PdfPTable(columnWidths)
				{
					HorizontalAlignment = Left,
					WidthPercentage = 100,
					DefaultCell = { MinimumHeight = 22f }
				};

				var cell = new PdfPCell(new Phrase("Bolt Summary"))
				{
					Colspan = columnCount,
					HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
					MinimumHeight = 30f
				}; 

				table.AddCell(cell);

				dataGridViewResults.Columns
					.OfType<DataGridViewColumn>()
					.ToList()
					.ForEach(c => table.AddCell(c.Name));

				dataGridViewResults.Rows
					.OfType<DataGridViewRow>()
					.ToList()
					.ForEach(r =>
					{
						var cells = r.Cells.OfType<DataGridViewCell>().ToList();
						cells.ForEach(c => table.AddCell(c.Value.ToString()));
					});

				pdfDoc.Add(table);

				pdfDoc.Close();
			}
			catch (Exception ex)
			{
				
			}
		}
	}
}
