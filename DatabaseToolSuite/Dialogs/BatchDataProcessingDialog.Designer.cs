namespace DatabaseToolSuite.Dialogs
{
	partial class BatchDataProcessingDialog
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchDataProcessingDialog));
			this.filtrGroupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.filterCodeNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.filterLawAgencyTypesComboBox = new DatabaseToolSuite.Controls.LawAgencyTypesComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.filterNameTextBox = new System.Windows.Forms.TextBox();
			this.filterLockCodeViewCheckBox = new System.Windows.Forms.CheckBox();
			this.okatoLabel = new System.Windows.Forms.Label();
			this.filterAuthorityComboBox = new DatabaseToolSuite.Controls.AuthorityComboBox();
			this.filterOkatoComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
			this.authorityLabel = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.countLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.selectedRowCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.is_GS_CheckBox = new System.Windows.Forms.CheckBox();
			this.contextMenuTable = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuIsGS = new System.Windows.Forms.ToolStripMenuItem();
			this.detailsListView = new DatabaseToolSuite.Controls.UrpListView();
			this.filtrGroupBox.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.contextMenuTable.SuspendLayout();
			this.SuspendLayout();
			// 
			// filtrGroupBox
			// 
			this.filtrGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filtrGroupBox.Controls.Add(this.label3);
			this.filtrGroupBox.Controls.Add(this.filterCodeNumericTextBox);
			this.filtrGroupBox.Controls.Add(this.label1);
			this.filtrGroupBox.Controls.Add(this.filterLawAgencyTypesComboBox);
			this.filtrGroupBox.Controls.Add(this.label2);
			this.filtrGroupBox.Controls.Add(this.filterNameTextBox);
			this.filtrGroupBox.Controls.Add(this.filterLockCodeViewCheckBox);
			this.filtrGroupBox.Controls.Add(this.okatoLabel);
			this.filtrGroupBox.Controls.Add(this.filterAuthorityComboBox);
			this.filtrGroupBox.Controls.Add(this.filterOkatoComboBox);
			this.filtrGroupBox.Controls.Add(this.authorityLabel);
			this.filtrGroupBox.Location = new System.Drawing.Point(12, 204);
			this.filtrGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filtrGroupBox.Name = "filtrGroupBox";
			this.filtrGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filtrGroupBox.Size = new System.Drawing.Size(840, 203);
			this.filtrGroupBox.TabIndex = 35;
			this.filtrGroupBox.TabStop = false;
			this.filtrGroupBox.Text = "Фильтр";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(141, 16);
			this.label3.TabIndex = 42;
			this.label3.Text = "Тип подразделения:";
			// 
			// filterCodeNumericTextBox
			// 
			this.filterCodeNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.filterCodeNumericTextBox.Location = new System.Drawing.Point(8, 160);
			this.filterCodeNumericTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterCodeNumericTextBox.Name = "filterCodeNumericTextBox";
			this.filterCodeNumericTextBox.Size = new System.Drawing.Size(181, 22);
			this.filterCodeNumericTextBox.TabIndex = 41;
			this.filterCodeNumericTextBox.TextChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(192, 134);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(215, 16);
			this.label1.TabIndex = 40;
			this.label1.Text = "Наименование подразделения:";
			// 
			// filterLawAgencyTypesComboBox
			// 
			this.filterLawAgencyTypesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterLawAgencyTypesComboBox.Code = "";
			this.filterLawAgencyTypesComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.filterLawAgencyTypesComboBox.DropDownHeight = 404;
			this.filterLawAgencyTypesComboBox.DropDownWidth = 80;
			this.filterLawAgencyTypesComboBox.FormattingEnabled = true;
			this.filterLawAgencyTypesComboBox.Id = ((long)(-1));
			this.filterLawAgencyTypesComboBox.IntegralHeight = false;
			this.filterLawAgencyTypesComboBox.ItemHeight = 20;
			this.filterLawAgencyTypesComboBox.Location = new System.Drawing.Point(165, 96);
			this.filterLawAgencyTypesComboBox.MaxDropDownItems = 20;
			this.filterLawAgencyTypesComboBox.Name = "filterLawAgencyTypesComboBox";
			this.filterLawAgencyTypesComboBox.SelectedItem = null;
			this.filterLawAgencyTypesComboBox.Size = new System.Drawing.Size(418, 26);
			this.filterLawAgencyTypesComboBox.TabIndex = 0;
			this.filterLawAgencyTypesComboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 134);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(140, 16);
			this.label2.TabIndex = 39;
			this.label2.Text = "Код подразделения:";
			// 
			// filterNameTextBox
			// 
			this.filterNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterNameTextBox.Location = new System.Drawing.Point(195, 160);
			this.filterNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterNameTextBox.Name = "filterNameTextBox";
			this.filterNameTextBox.Size = new System.Drawing.Size(634, 22);
			this.filterNameTextBox.TabIndex = 37;
			this.filterNameTextBox.TextChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// filterLockCodeViewCheckBox
			// 
			this.filterLockCodeViewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.filterLockCodeViewCheckBox.AutoSize = true;
			this.filterLockCodeViewCheckBox.Location = new System.Drawing.Point(616, 64);
			this.filterLockCodeViewCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterLockCodeViewCheckBox.Name = "filterLockCodeViewCheckBox";
			this.filterLockCodeViewCheckBox.Size = new System.Drawing.Size(216, 20);
			this.filterLockCodeViewCheckBox.TabIndex = 36;
			this.filterLockCodeViewCheckBox.Text = "Включить заблокированные";
			this.filterLockCodeViewCheckBox.UseVisualStyleBackColor = true;
			this.filterLockCodeViewCheckBox.CheckedChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// okatoLabel
			// 
			this.okatoLabel.AutoSize = true;
			this.okatoLabel.Location = new System.Drawing.Point(12, 30);
			this.okatoLabel.Name = "okatoLabel";
			this.okatoLabel.Size = new System.Drawing.Size(83, 16);
			this.okatoLabel.TabIndex = 35;
			this.okatoLabel.Text = "Код ОКАТО:";
			// 
			// filterAuthorityComboBox
			// 
			this.filterAuthorityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterAuthorityComboBox.Code = "";
			this.filterAuthorityComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.filterAuthorityComboBox.DropDownHeight = 404;
			this.filterAuthorityComboBox.DropDownWidth = 80;
			this.filterAuthorityComboBox.FormattingEnabled = true;
			this.filterAuthorityComboBox.Id = ((long)(-1));
			this.filterAuthorityComboBox.IntegralHeight = false;
			this.filterAuthorityComboBox.ItemHeight = 20;
			this.filterAuthorityComboBox.Location = new System.Drawing.Point(165, 60);
			this.filterAuthorityComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterAuthorityComboBox.MaxDropDownItems = 20;
			this.filterAuthorityComboBox.Name = "filterAuthorityComboBox";
			this.filterAuthorityComboBox.SelectedItem = null;
			this.filterAuthorityComboBox.Size = new System.Drawing.Size(418, 26);
			this.filterAuthorityComboBox.TabIndex = 1;
			this.filterAuthorityComboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// filterOkatoComboBox
			// 
			this.filterOkatoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterOkatoComboBox.Code = "";
			this.filterOkatoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.filterOkatoComboBox.DropDownHeight = 404;
			this.filterOkatoComboBox.DropDownWidth = 80;
			this.filterOkatoComboBox.FormattingEnabled = true;
			this.filterOkatoComboBox.Id = ((long)(-1));
			this.filterOkatoComboBox.IntegralHeight = false;
			this.filterOkatoComboBox.ItemHeight = 20;
			this.filterOkatoComboBox.Location = new System.Drawing.Point(165, 24);
			this.filterOkatoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterOkatoComboBox.MaxDropDownItems = 20;
			this.filterOkatoComboBox.Name = "filterOkatoComboBox";
			this.filterOkatoComboBox.SelectedItem = null;
			this.filterOkatoComboBox.Size = new System.Drawing.Size(664, 26);
			this.filterOkatoComboBox.TabIndex = 2;
			this.filterOkatoComboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// authorityLabel
			// 
			this.authorityLabel.AutoSize = true;
			this.authorityLabel.Location = new System.Drawing.Point(12, 66);
			this.authorityLabel.Name = "authorityLabel";
			this.authorityLabel.Size = new System.Drawing.Size(92, 16);
			this.authorityLabel.TabIndex = 0;
			this.authorityLabel.Text = "Вид органов:";
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countLabel,
            this.selectedRowCountLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 424);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(865, 26);
			this.statusStrip1.TabIndex = 36;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// countLabel
			// 
			this.countLabel.AutoSize = false;
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(180, 20);
			this.countLabel.Text = "#";
			// 
			// selectedRowCountLabel
			// 
			this.selectedRowCountLabel.AutoSize = false;
			this.selectedRowCountLabel.Name = "selectedRowCountLabel";
			this.selectedRowCountLabel.Size = new System.Drawing.Size(180, 20);
			this.selectedRowCountLabel.Text = "#";
			// 
			// is_GS_CheckBox
			// 
			this.is_GS_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.is_GS_CheckBox.AutoSize = true;
			this.is_GS_CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.is_GS_CheckBox.Location = new System.Drawing.Point(12, 168);
			this.is_GS_CheckBox.Name = "is_GS_CheckBox";
			this.is_GS_CheckBox.Size = new System.Drawing.Size(421, 24);
			this.is_GS_CheckBox.TabIndex = 37;
			this.is_GS_CheckBox.Text = "Участие в формировании гос.отчетности";
			this.is_GS_CheckBox.UseVisualStyleBackColor = true;
			this.is_GS_CheckBox.Click += new System.EventHandler(this.IsGS_Click);
			// 
			// contextMenuTable
			// 
			this.contextMenuTable.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.toolStripMenuItem1,
            this.mnuEdit,
            this.toolStripMenuItem2,
            this.mnuIsGS});
			this.contextMenuTable.Name = "contextMenuStrip1";
			this.contextMenuTable.Size = new System.Drawing.Size(248, 88);
			// 
			// mnuOpen
			// 
			this.mnuOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.mnuOpen.Name = "mnuOpen";
			this.mnuOpen.Size = new System.Drawing.Size(247, 24);
			this.mnuOpen.Text = "Открыть...";
			this.mnuOpen.Click += new System.EventHandler(this.Open_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(244, 6);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Name = "mnuEdit";
			this.mnuEdit.Size = new System.Drawing.Size(247, 24);
			this.mnuEdit.Text = "Правка...";
			this.mnuEdit.Click += new System.EventHandler(this.Edit_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(244, 6);
			// 
			// mnuIsGS
			// 
			this.mnuIsGS.Name = "mnuIsGS";
			this.mnuIsGS.Size = new System.Drawing.Size(247, 24);
			this.mnuIsGS.Text = "Участие в гос.статистике";
			this.mnuIsGS.Click += new System.EventHandler(this.IsGS_Click);
			// 
			// detailsListView
			// 
			this.detailsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.detailsListView.DataSet = null;
			this.detailsListView.LawAgencyType = null;
			this.detailsListView.Location = new System.Drawing.Point(13, 13);
			this.detailsListView.LockShow = false;
			this.detailsListView.Margin = new System.Windows.Forms.Padding(4);
			this.detailsListView.Name = "detailsListView";
			this.detailsListView.ReserveShow = true;
			this.detailsListView.Size = new System.Drawing.Size(839, 143);
			this.detailsListView.TabIndex = 1;
			this.detailsListView.UnlockShow = true;
			this.detailsListView.ItemMouseClick += new System.EventHandler<DatabaseToolSuite.Controls.ListViewEventArgs>(this.ListView_ItemMouseClick);
			this.detailsListView.ItemMouseDoubleClick += new System.EventHandler<DatabaseToolSuite.Controls.ListViewEventArgs>(this.ListView_ItemMouseDoubleClick);
			// 
			// BatchDataProcessingDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(865, 450);
			this.Controls.Add(this.is_GS_CheckBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.filtrGroupBox);
			this.Controls.Add(this.detailsListView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BatchDataProcessingDialog";
			this.Text = "Пакетная обработка данных";
			this.filtrGroupBox.ResumeLayout(false);
			this.filtrGroupBox.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuTable.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.LawAgencyTypesComboBox filterLawAgencyTypesComboBox;
		private Controls.UrpListView detailsListView;
		private System.Windows.Forms.GroupBox filtrGroupBox;
		private Controls.NumericTextBox filterCodeNumericTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox filterNameTextBox;
		private System.Windows.Forms.CheckBox filterLockCodeViewCheckBox;
		private System.Windows.Forms.Label okatoLabel;
		private Controls.AuthorityComboBox filterAuthorityComboBox;
		private Controls.OkatoComboBox filterOkatoComboBox;
		private System.Windows.Forms.Label authorityLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel countLabel;
		private System.Windows.Forms.ToolStripStatusLabel selectedRowCountLabel;
		private System.Windows.Forms.CheckBox is_GS_CheckBox;
		private System.Windows.Forms.ContextMenuStrip contextMenuTable;
		private System.Windows.Forms.ToolStripMenuItem mnuOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mnuIsGS;
	}
}