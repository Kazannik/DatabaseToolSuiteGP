namespace DatabaseToolSuite.Dialogs
{
    partial class SupervisionDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupervisionDialog));
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.gaspsLiteListView1 = new DatabaseToolSuite.Controls.GaspsLiteListView();
			this.addButton = new System.Windows.Forms.Button();
			this.detailsListView = new System.Windows.Forms.ListView();
			this.codeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.organizationImageList = new System.Windows.Forms.ImageList(this.components);
			this.selectOkatoLabel = new System.Windows.Forms.Label();
			this.selectNameLabel = new System.Windows.Forms.Label();
			this.selectNameTextBox = new System.Windows.Forms.TextBox();
			this.selectOkatoTextBox = new System.Windows.Forms.TextBox();
			this.filtrGroupBox = new System.Windows.Forms.GroupBox();
			this.filterCodeNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.filterNameTextBox = new System.Windows.Forms.TextBox();
			this.filterLockCodeViewCheckBox = new System.Windows.Forms.CheckBox();
			this.okatoLabel = new System.Windows.Forms.Label();
			this.filterAuthorityComboBox = new DatabaseToolSuite.Controls.AuthorityComboBox();
			this.filterOkatoComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
			this.authorityLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.authorityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.filtrGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(1138, 580);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(112, 30);
			this.cancelButton.TabIndex = 28;
			this.cancelButton.Text = "Отмена";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(1017, 580);
			this.okButton.Margin = new System.Windows.Forms.Padding(4);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(112, 30);
			this.okButton.TabIndex = 27;
			this.okButton.Text = "&ОК";
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainSplitContainer.Location = new System.Drawing.Point(9, 69);
			this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.mainSplitContainer.Name = "mainSplitContainer";
			this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.gaspsLiteListView1);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.addButton);
			this.mainSplitContainer.Panel2.Controls.Add(this.detailsListView);
			this.mainSplitContainer.Panel2.Controls.Add(this.selectOkatoLabel);
			this.mainSplitContainer.Panel2.Controls.Add(this.selectNameLabel);
			this.mainSplitContainer.Panel2.Controls.Add(this.selectNameTextBox);
			this.mainSplitContainer.Panel2.Controls.Add(this.selectOkatoTextBox);
			this.mainSplitContainer.Size = new System.Drawing.Size(1251, 335);
			this.mainSplitContainer.SplitterDistance = 137;
			this.mainSplitContainer.TabIndex = 29;
			// 
			// gaspsLiteListView1
			// 
			this.gaspsLiteListView1.DataSet = null;
			this.gaspsLiteListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gaspsLiteListView1.Location = new System.Drawing.Point(0, 0);
			this.gaspsLiteListView1.LockShow = false;
			this.gaspsLiteListView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.gaspsLiteListView1.Name = "gaspsLiteListView1";
			this.gaspsLiteListView1.ReserveShow = true;
			this.gaspsLiteListView1.Size = new System.Drawing.Size(1251, 137);
			this.gaspsLiteListView1.TabIndex = 0;
			this.gaspsLiteListView1.UnlockShow = true;
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.Location = new System.Drawing.Point(1129, 24);
			this.addButton.Margin = new System.Windows.Forms.Padding(4);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(112, 30);
			this.addButton.TabIndex = 34;
			this.addButton.Text = "Добавить";
			// 
			// detailsListView
			// 
			this.detailsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.detailsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeColumnHeader,
            this.nameColumnHeader,
            this.authorityColumnHeader});
			this.detailsListView.FullRowSelect = true;
			this.detailsListView.HideSelection = false;
			this.detailsListView.LargeImageList = this.organizationImageList;
			this.detailsListView.Location = new System.Drawing.Point(0, 71);
			this.detailsListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.detailsListView.MultiSelect = false;
			this.detailsListView.Name = "detailsListView";
			this.detailsListView.ShowGroups = false;
			this.detailsListView.Size = new System.Drawing.Size(1250, 120);
			this.detailsListView.SmallImageList = this.organizationImageList;
			this.detailsListView.TabIndex = 0;
			this.detailsListView.UseCompatibleStateImageBehavior = false;
			this.detailsListView.View = System.Windows.Forms.View.Details;
			this.detailsListView.VirtualMode = true;
			this.detailsListView.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.DetailsListView_CacheVirtualItems);
			this.detailsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DetailsListView_ColumnClick);
			this.detailsListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.DetailsListView_RetrieveVirtualItem);
			this.detailsListView.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this.DetailsListView_SearchForVirtualItem);
			this.detailsListView.SelectedIndexChanged += new System.EventHandler(this.DetailsListView_SelectedIndexChanged);
			// 
			// codeColumnHeader
			// 
			this.codeColumnHeader.Text = "Код";
			this.codeColumnHeader.Width = 100;
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Наименование";
			this.nameColumnHeader.Width = 600;
			// 
			// organizationImageList
			// 
			this.organizationImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("organizationImageList.ImageStream")));
			this.organizationImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.organizationImageList.Images.SetKeyName(0, "unlock");
			this.organizationImageList.Images.SetKeyName(1, "lock");
			this.organizationImageList.Images.SetKeyName(2, "reserve");
			// 
			// selectOkatoLabel
			// 
			this.selectOkatoLabel.AutoSize = true;
			this.selectOkatoLabel.ForeColor = System.Drawing.SystemColors.Highlight;
			this.selectOkatoLabel.Location = new System.Drawing.Point(3, 4);
			this.selectOkatoLabel.Name = "selectOkatoLabel";
			this.selectOkatoLabel.Size = new System.Drawing.Size(152, 18);
			this.selectOkatoLabel.TabIndex = 32;
			this.selectOkatoLabel.Text = "Код подразделения:";
			// 
			// selectNameLabel
			// 
			this.selectNameLabel.AutoSize = true;
			this.selectNameLabel.ForeColor = System.Drawing.SystemColors.Highlight;
			this.selectNameLabel.Location = new System.Drawing.Point(198, 4);
			this.selectNameLabel.Name = "selectNameLabel";
			this.selectNameLabel.Size = new System.Drawing.Size(315, 18);
			this.selectNameLabel.TabIndex = 33;
			this.selectNameLabel.Text = "Наименование выбранного подразделения:";
			// 
			// selectNameTextBox
			// 
			this.selectNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.selectNameTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.selectNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.selectNameTextBox.Location = new System.Drawing.Point(195, 26);
			this.selectNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectNameTextBox.Name = "selectNameTextBox";
			this.selectNameTextBox.ReadOnly = true;
			this.selectNameTextBox.Size = new System.Drawing.Size(925, 27);
			this.selectNameTextBox.TabIndex = 30;
			// 
			// selectOkatoTextBox
			// 
			this.selectOkatoTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.selectOkatoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.selectOkatoTextBox.Location = new System.Drawing.Point(0, 26);
			this.selectOkatoTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectOkatoTextBox.Name = "selectOkatoTextBox";
			this.selectOkatoTextBox.ReadOnly = true;
			this.selectOkatoTextBox.Size = new System.Drawing.Size(188, 27);
			this.selectOkatoTextBox.TabIndex = 31;
			// 
			// filtrGroupBox
			// 
			this.filtrGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filtrGroupBox.Controls.Add(this.filterCodeNumericTextBox);
			this.filtrGroupBox.Controls.Add(this.label1);
			this.filtrGroupBox.Controls.Add(this.label2);
			this.filtrGroupBox.Controls.Add(this.filterNameTextBox);
			this.filtrGroupBox.Controls.Add(this.filterLockCodeViewCheckBox);
			this.filtrGroupBox.Controls.Add(this.okatoLabel);
			this.filtrGroupBox.Controls.Add(this.filterAuthorityComboBox);
			this.filtrGroupBox.Controls.Add(this.filterOkatoComboBox);
			this.filtrGroupBox.Controls.Add(this.authorityLabel);
			this.filtrGroupBox.Location = new System.Drawing.Point(9, 408);
			this.filtrGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filtrGroupBox.Name = "filtrGroupBox";
			this.filtrGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filtrGroupBox.Size = new System.Drawing.Size(1251, 165);
			this.filtrGroupBox.TabIndex = 34;
			this.filtrGroupBox.TabStop = false;
			this.filtrGroupBox.Text = "Фильтр";
			// 
			// filterCodeNumericTextBox
			// 
			this.filterCodeNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.filterCodeNumericTextBox.Location = new System.Drawing.Point(8, 122);
			this.filterCodeNumericTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterCodeNumericTextBox.Name = "filterCodeNumericTextBox";
			this.filterCodeNumericTextBox.Size = new System.Drawing.Size(181, 24);
			this.filterCodeNumericTextBox.TabIndex = 41;
			this.filterCodeNumericTextBox.TextChanged += new System.EventHandler(this.FilterControls_ValueChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(192, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(227, 18);
			this.label1.TabIndex = 40;
			this.label1.Text = "Наименование подразделения:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 18);
			this.label2.TabIndex = 39;
			this.label2.Text = "Код подразделения:";
			// 
			// filterNameTextBox
			// 
			this.filterNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterNameTextBox.Location = new System.Drawing.Point(195, 122);
			this.filterNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterNameTextBox.Name = "filterNameTextBox";
			this.filterNameTextBox.Size = new System.Drawing.Size(1045, 24);
			this.filterNameTextBox.TabIndex = 37;
			this.filterNameTextBox.TextChanged += new System.EventHandler(this.FilterControls_ValueChanged);
			// 
			// filterLockCodeViewCheckBox
			// 
			this.filterLockCodeViewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.filterLockCodeViewCheckBox.AutoSize = true;
			this.filterLockCodeViewCheckBox.Location = new System.Drawing.Point(1013, 64);
			this.filterLockCodeViewCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterLockCodeViewCheckBox.Name = "filterLockCodeViewCheckBox";
			this.filterLockCodeViewCheckBox.Size = new System.Drawing.Size(230, 22);
			this.filterLockCodeViewCheckBox.TabIndex = 36;
			this.filterLockCodeViewCheckBox.Text = "Включить заблокированные";
			this.filterLockCodeViewCheckBox.UseVisualStyleBackColor = true;
			this.filterLockCodeViewCheckBox.CheckedChanged += new System.EventHandler(this.FilterControls_ValueChanged);
			this.filterLockCodeViewCheckBox.VisibleChanged += new System.EventHandler(this.FilterControls_ValueChanged);
			// 
			// okatoLabel
			// 
			this.okatoLabel.AutoSize = true;
			this.okatoLabel.Location = new System.Drawing.Point(4, 28);
			this.okatoLabel.Name = "okatoLabel";
			this.okatoLabel.Size = new System.Drawing.Size(96, 18);
			this.okatoLabel.TabIndex = 35;
			this.okatoLabel.Text = "Код ОКАТО:";
			// 
			// filterAuthorityComboBox
			// 
			this.filterAuthorityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterAuthorityComboBox.Code = "";
			this.filterAuthorityComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.filterAuthorityComboBox.DropDownHeight = 444;
			this.filterAuthorityComboBox.DropDownWidth = 80;
			this.filterAuthorityComboBox.FormattingEnabled = true;
			this.filterAuthorityComboBox.Id = ((long)(-1));
			this.filterAuthorityComboBox.IntegralHeight = false;
			this.filterAuthorityComboBox.ItemHeight = 22;
			this.filterAuthorityComboBox.Location = new System.Drawing.Point(118, 60);
			this.filterAuthorityComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterAuthorityComboBox.MaxDropDownItems = 20;
			this.filterAuthorityComboBox.Name = "filterAuthorityComboBox";
			this.filterAuthorityComboBox.SelectedItem = null;
			this.filterAuthorityComboBox.Size = new System.Drawing.Size(829, 28);
			this.filterAuthorityComboBox.TabIndex = 1;
			this.filterAuthorityComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterControls_ValueChanged);
			// 
			// filterOkatoComboBox
			// 
			this.filterOkatoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterOkatoComboBox.Code = "";
			this.filterOkatoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.filterOkatoComboBox.DropDownHeight = 444;
			this.filterOkatoComboBox.DropDownWidth = 80;
			this.filterOkatoComboBox.FormattingEnabled = true;
			this.filterOkatoComboBox.Id = ((long)(-1));
			this.filterOkatoComboBox.IntegralHeight = false;
			this.filterOkatoComboBox.ItemHeight = 22;
			this.filterOkatoComboBox.Location = new System.Drawing.Point(120, 24);
			this.filterOkatoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filterOkatoComboBox.MaxDropDownItems = 20;
			this.filterOkatoComboBox.Name = "filterOkatoComboBox";
			this.filterOkatoComboBox.SelectedItem = null;
			this.filterOkatoComboBox.Size = new System.Drawing.Size(1124, 28);
			this.filterOkatoComboBox.TabIndex = 2;
			this.filterOkatoComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterControls_ValueChanged);
			// 
			// authorityLabel
			// 
			this.authorityLabel.AutoSize = true;
			this.authorityLabel.Location = new System.Drawing.Point(4, 64);
			this.authorityLabel.Name = "authorityLabel";
			this.authorityLabel.Size = new System.Drawing.Size(99, 18);
			this.authorityLabel.TabIndex = 0;
			this.authorityLabel.Text = "Вид органов:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 18);
			this.label3.TabIndex = 35;
			this.label3.Text = "label3";
			// 
			// autColumnHeader
			// 
			this.authorityColumnHeader.Text = "Ведомство";
			this.authorityColumnHeader.Width = 220;
			// 
			// SupervisionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(1266, 626);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.filtrGroupBox);
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(786, 658);
			this.Name = "SupervisionDialog";
			this.Text = "Настройка поднадзорности";
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			this.mainSplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.filtrGroupBox.ResumeLayout(false);
			this.filtrGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TextBox selectNameTextBox;
        private System.Windows.Forms.TextBox selectOkatoTextBox;
        private System.Windows.Forms.Label selectOkatoLabel;
        private System.Windows.Forms.Label selectNameLabel;
        private System.Windows.Forms.GroupBox filtrGroupBox;
        private Controls.AuthorityComboBox filterAuthorityComboBox;
        private System.Windows.Forms.Label authorityLabel;
        private System.Windows.Forms.ListView detailsListView;
        private System.Windows.Forms.ColumnHeader codeColumnHeader;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.Label okatoLabel;
        private Controls.OkatoComboBox filterOkatoComboBox;
        private System.Windows.Forms.ImageList organizationImageList;
        private Controls.NumericTextBox filterCodeNumericTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filterNameTextBox;
        private System.Windows.Forms.CheckBox filterLockCodeViewCheckBox;
		private Controls.GaspsLiteListView gaspsLiteListView1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.ColumnHeader authorityColumnHeader;
	}
}