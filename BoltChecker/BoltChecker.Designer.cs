namespace BoltChecker
{
	partial class BoltChecker
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoltChecker));
			this.btnUpdate = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listBoxSize = new System.Windows.Forms.ListBox();
			this.listBoxStandard = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.listBoxType = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxProperties = new System.Windows.Forms.TextBox();
			this.dataGridViewResults = new System.Windows.Forms.DataGridView();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxBuilder = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.buttonSelectBoltsInModel = new System.Windows.Forms.Button();
			this.buttonExportToPdf = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
			this.SuspendLayout();
			// 
			// btnUpdate
			// 
			this.btnUpdate.AutoSize = true;
			this.btnUpdate.Location = new System.Drawing.Point(408, 579);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(172, 42);
			this.btnUpdate.TabIndex = 11;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnCheckBolts_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::BoltChecker.Properties.Resources.Logo;
			this.pictureBox1.Location = new System.Drawing.Point(28, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(172, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 17);
			this.label1.TabIndex = 13;
			this.label1.Text = "Size";
			// 
			// listBoxSize
			// 
			this.listBoxSize.FormattingEnabled = true;
			this.listBoxSize.ItemHeight = 16;
			this.listBoxSize.Location = new System.Drawing.Point(28, 124);
			this.listBoxSize.Name = "listBoxSize";
			this.listBoxSize.Size = new System.Drawing.Size(120, 132);
			this.listBoxSize.TabIndex = 14;
			this.listBoxSize.Click += new System.EventHandler(this.listBoxSize_Click);
			// 
			// listBoxStandard
			// 
			this.listBoxStandard.FormattingEnabled = true;
			this.listBoxStandard.ItemHeight = 16;
			this.listBoxStandard.Location = new System.Drawing.Point(154, 124);
			this.listBoxStandard.Name = "listBoxStandard";
			this.listBoxStandard.Size = new System.Drawing.Size(166, 132);
			this.listBoxStandard.TabIndex = 16;
			this.listBoxStandard.Click += new System.EventHandler(this.listBoxStandard_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(151, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 17);
			this.label2.TabIndex = 15;
			this.label2.Text = "Standard";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 17);
			this.label3.TabIndex = 17;
			this.label3.Text = "Bolt Properties";
			// 
			// listBoxType
			// 
			this.listBoxType.FormattingEnabled = true;
			this.listBoxType.ItemHeight = 16;
			this.listBoxType.Location = new System.Drawing.Point(326, 124);
			this.listBoxType.Name = "listBoxType";
			this.listBoxType.Size = new System.Drawing.Size(254, 132);
			this.listBoxType.TabIndex = 19;
			this.listBoxType.Click += new System.EventHandler(this.listBoxType_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(323, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 17);
			this.label4.TabIndex = 18;
			this.label4.Text = "Type";
			// 
			// textBoxProperties
			// 
			this.textBoxProperties.Location = new System.Drawing.Point(28, 263);
			this.textBoxProperties.Name = "textBoxProperties";
			this.textBoxProperties.Size = new System.Drawing.Size(552, 22);
			this.textBoxProperties.TabIndex = 20;
			// 
			// dataGridViewResults
			// 
			this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewResults.Location = new System.Drawing.Point(28, 292);
			this.dataGridViewResults.Name = "dataGridViewResults";
			this.dataGridViewResults.RowTemplate.Height = 24;
			this.dataGridViewResults.Size = new System.Drawing.Size(552, 281);
			this.dataGridViewResults.TabIndex = 21;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(326, 12);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(254, 22);
			this.textBoxName.TabIndex = 22;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(262, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 17);
			this.label5.TabIndex = 23;
			this.label5.Text = "Name";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(262, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 17);
			this.label6.TabIndex = 25;
			this.label6.Text = "Builder";
			// 
			// textBoxBuilder
			// 
			this.textBoxBuilder.Location = new System.Drawing.Point(326, 68);
			this.textBoxBuilder.Name = "textBoxBuilder";
			this.textBoxBuilder.ReadOnly = true;
			this.textBoxBuilder.Size = new System.Drawing.Size(254, 22);
			this.textBoxBuilder.TabIndex = 24;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(262, 43);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 17);
			this.label7.TabIndex = 27;
			this.label7.Text = "Number";
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Location = new System.Drawing.Point(326, 40);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.ReadOnly = true;
			this.textBoxNumber.Size = new System.Drawing.Size(254, 22);
			this.textBoxNumber.TabIndex = 26;
			// 
			// buttonSelectBoltsInModel
			// 
			this.buttonSelectBoltsInModel.AutoSize = true;
			this.buttonSelectBoltsInModel.Location = new System.Drawing.Point(28, 579);
			this.buttonSelectBoltsInModel.Name = "buttonSelectBoltsInModel";
			this.buttonSelectBoltsInModel.Size = new System.Drawing.Size(181, 42);
			this.buttonSelectBoltsInModel.TabIndex = 28;
			this.buttonSelectBoltsInModel.Text = "Select In Model";
			this.buttonSelectBoltsInModel.UseVisualStyleBackColor = true;
			this.buttonSelectBoltsInModel.Click += new System.EventHandler(this.displayBoltsInModel_Click);
			// 
			// buttonExportToPdf
			// 
			this.buttonExportToPdf.AutoSize = true;
			this.buttonExportToPdf.Location = new System.Drawing.Point(215, 579);
			this.buttonExportToPdf.Name = "buttonExportToPdf";
			this.buttonExportToPdf.Size = new System.Drawing.Size(187, 42);
			this.buttonExportToPdf.TabIndex = 29;
			this.buttonExportToPdf.Text = "Export To PDF";
			this.buttonExportToPdf.UseVisualStyleBackColor = true;
			this.buttonExportToPdf.Click += new System.EventHandler(this.buttonExportToPdf_Click);
			// 
			// BoltChecker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 633);
			this.Controls.Add(this.buttonExportToPdf);
			this.Controls.Add(this.buttonSelectBoltsInModel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxBuilder);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.dataGridViewResults);
			this.Controls.Add(this.textBoxProperties);
			this.Controls.Add(this.listBoxType);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listBoxStandard);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.listBoxSize);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BoltChecker";
			this.Text = "Bolt Checker";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBoxSize;
		private System.Windows.Forms.ListBox listBoxStandard;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBoxType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxProperties;
		private System.Windows.Forms.DataGridView dataGridViewResults;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxBuilder;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.Button buttonSelectBoltsInModel;
		private System.Windows.Forms.Button buttonExportToPdf;
	}
}

