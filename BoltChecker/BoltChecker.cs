using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

		private BoltResult GetBoltResult(BoltArray bolt)
		{
			return new BoltResult
			{
				Size = Math.Round(bolt.BoltSize, 2).ToString(),
				Standard = bolt.BoltStandard,
				Type = bolt.BoltType,
			};
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
	}

	public static class TeklaExtensionMethods
	{
		public static List<ModelObject> ToList(this ModelObjectEnumerator enumerator)
		{
			enumerator.SelectInstances = false;

			var modelObjects = new List<ModelObject>();
			while (enumerator.MoveNext())
			{
				var modelObject = enumerator.Current;
				if (modelObject == null) continue;
				modelObjects.Add(modelObject);
			}

			return modelObjects;
		}
	}
}
