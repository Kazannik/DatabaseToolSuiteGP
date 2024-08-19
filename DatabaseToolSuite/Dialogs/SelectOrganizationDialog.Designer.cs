namespace DatabaseToolSuite.Dialogs
{
    partial class SelectOrganizationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectOrganizationDialog));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.detailsListView = new System.Windows.Forms.ListView();
            this.codeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.organizationImageList = new System.Windows.Forms.ImageList(this.components);
            this.selectNameTextBox = new System.Windows.Forms.TextBox();
            this.selectOkatoTextBox = new System.Windows.Forms.TextBox();
            this.selectOkatoLabel = new System.Windows.Forms.Label();
            this.selectNameLabel = new System.Windows.Forms.Label();
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
            this.cancelButton.Location = new System.Drawing.Point(572, 516);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 27);
            this.cancelButton.TabIndex = 28;
            this.cancelButton.Text = "Отмена";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(464, 516);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 27);
            this.okButton.TabIndex = 27;
            this.okButton.Text = "&ОК";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSplitContainer.Location = new System.Drawing.Point(8, 7);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.detailsTextBox);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.detailsListView);
            this.mainSplitContainer.Size = new System.Drawing.Size(672, 283);
            this.mainSplitContainer.SplitterDistance = 157;
            this.mainSplitContainer.TabIndex = 29;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.BackColor = System.Drawing.Color.White;
            this.detailsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.detailsTextBox.Location = new System.Drawing.Point(0, 0);
            this.detailsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.ReadOnly = true;
            this.detailsTextBox.Size = new System.Drawing.Size(157, 283);
            this.detailsTextBox.TabIndex = 1;
            // 
            // detailsListView
            // 
            this.detailsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeColumnHeader,
            this.nameColumnHeader});
            this.detailsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsListView.FullRowSelect = true;
            this.detailsListView.LargeImageList = this.organizationImageList;
            this.detailsListView.Location = new System.Drawing.Point(0, 0);
            this.detailsListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.detailsListView.MultiSelect = false;
            this.detailsListView.Name = "detailsListView";
            this.detailsListView.ShowGroups = false;
            this.detailsListView.Size = new System.Drawing.Size(511, 283);
            this.detailsListView.SmallImageList = this.organizationImageList;
            this.detailsListView.TabIndex = 0;
            this.detailsListView.UseCompatibleStateImageBehavior = false;
            this.detailsListView.View = System.Windows.Forms.View.Details;
            this.detailsListView.VirtualMode = true;
            this.detailsListView.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.detailsListView_CacheVirtualItems);
            this.detailsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.detailsListView_ColumnClick);
            this.detailsListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.detailsListView_RetrieveVirtualItem);
            this.detailsListView.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this.detailsListView_SearchForVirtualItem);
            this.detailsListView.SelectedIndexChanged += new System.EventHandler(this.detailsListView_SelectedIndexChanged);
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
            // selectNameTextBox
            // 
            this.selectNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.selectNameTextBox.Location = new System.Drawing.Point(181, 476);
            this.selectNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectNameTextBox.Name = "selectNameTextBox";
            this.selectNameTextBox.ReadOnly = true;
            this.selectNameTextBox.Size = new System.Drawing.Size(489, 22);
            this.selectNameTextBox.TabIndex = 30;
            // 
            // selectOkatoTextBox
            // 
            this.selectOkatoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectOkatoTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.selectOkatoTextBox.Location = new System.Drawing.Point(15, 476);
            this.selectOkatoTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectOkatoTextBox.Name = "selectOkatoTextBox";
            this.selectOkatoTextBox.ReadOnly = true;
            this.selectOkatoTextBox.Size = new System.Drawing.Size(161, 22);
            this.selectOkatoTextBox.TabIndex = 31;
            // 
            // selectOkatoLabel
            // 
            this.selectOkatoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectOkatoLabel.AutoSize = true;
            this.selectOkatoLabel.Location = new System.Drawing.Point(12, 453);
            this.selectOkatoLabel.Name = "selectOkatoLabel";
            this.selectOkatoLabel.Size = new System.Drawing.Size(144, 17);
            this.selectOkatoLabel.TabIndex = 32;
            this.selectOkatoLabel.Text = "Код подразделения:";
            // 
            // selectNameLabel
            // 
            this.selectNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectNameLabel.AutoSize = true;
            this.selectNameLabel.Location = new System.Drawing.Point(179, 453);
            this.selectNameLabel.Name = "selectNameLabel";
            this.selectNameLabel.Size = new System.Drawing.Size(217, 17);
            this.selectNameLabel.TabIndex = 33;
            this.selectNameLabel.Text = "Наименование подразделения:";
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
            this.filtrGroupBox.Location = new System.Drawing.Point(8, 297);
            this.filtrGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filtrGroupBox.Name = "filtrGroupBox";
            this.filtrGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filtrGroupBox.Size = new System.Drawing.Size(672, 153);
            this.filtrGroupBox.TabIndex = 34;
            this.filtrGroupBox.TabStop = false;
            this.filtrGroupBox.Text = "Фильтр";
            // 
            // filterCodeNumericTextBox
            // 
            this.filterCodeNumericTextBox.Location = new System.Drawing.Point(7, 114);
            this.filterCodeNumericTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterCodeNumericTextBox.Name = "filterCodeNumericTextBox";
            this.filterCodeNumericTextBox.Size = new System.Drawing.Size(161, 22);
            this.filterCodeNumericTextBox.TabIndex = 41;
            this.filterCodeNumericTextBox.TextChanged += new System.EventHandler(this.filterControls_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "Наименование подразделения:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Код подразделения:";
            // 
            // filterNameTextBox
            // 
            this.filterNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterNameTextBox.Location = new System.Drawing.Point(173, 114);
            this.filterNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterNameTextBox.Name = "filterNameTextBox";
            this.filterNameTextBox.Size = new System.Drawing.Size(489, 22);
            this.filterNameTextBox.TabIndex = 37;
            this.filterNameTextBox.TextChanged += new System.EventHandler(this.filterControls_ValueChanged);
            // 
            // filterLockCodeViewCheckBox
            // 
            this.filterLockCodeViewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterLockCodeViewCheckBox.AutoSize = true;
            this.filterLockCodeViewCheckBox.Location = new System.Drawing.Point(447, 57);
            this.filterLockCodeViewCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterLockCodeViewCheckBox.Name = "filterLockCodeViewCheckBox";
            this.filterLockCodeViewCheckBox.Size = new System.Drawing.Size(217, 21);
            this.filterLockCodeViewCheckBox.TabIndex = 36;
            this.filterLockCodeViewCheckBox.Text = "Включить заблокированные";
            this.filterLockCodeViewCheckBox.UseVisualStyleBackColor = true;
            this.filterLockCodeViewCheckBox.CheckedChanged += new System.EventHandler(this.filterControls_ValueChanged);
            this.filterLockCodeViewCheckBox.VisibleChanged += new System.EventHandler(this.filterControls_ValueChanged);
            // 
            // okatoLabel
            // 
            this.okatoLabel.AutoSize = true;
            this.okatoLabel.Location = new System.Drawing.Point(4, 25);
            this.okatoLabel.Name = "okatoLabel";
            this.okatoLabel.Size = new System.Drawing.Size(90, 17);
            this.okatoLabel.TabIndex = 35;
            this.okatoLabel.Text = "Код ОКАТО:";
            // 
            // filterAuthorityComboBox
            // 
            this.filterAuthorityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterAuthorityComboBox.Code = "";
            this.filterAuthorityComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterAuthorityComboBox.DropDownHeight = 164;
            this.filterAuthorityComboBox.DropDownWidth = 80;
            this.filterAuthorityComboBox.FormattingEnabled = true;
            this.filterAuthorityComboBox.IntegralHeight = false;
            this.filterAuthorityComboBox.ItemHeight = 20;
            this.filterAuthorityComboBox.Location = new System.Drawing.Point(105, 53);
            this.filterAuthorityComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterAuthorityComboBox.MaxDropDownItems = 20;
            this.filterAuthorityComboBox.Name = "filterAuthorityComboBox";
            this.filterAuthorityComboBox.Size = new System.Drawing.Size(297, 26);
            this.filterAuthorityComboBox.TabIndex = 1;
            this.filterAuthorityComboBox.SelectedIndexChanged += new System.EventHandler(this.filterControls_ValueChanged);
            // 
            // filterOkatoComboBox
            // 
            this.filterOkatoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterOkatoComboBox.Code = "";
            this.filterOkatoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterOkatoComboBox.DropDownHeight = 164;
            this.filterOkatoComboBox.DropDownWidth = 80;
            this.filterOkatoComboBox.FormattingEnabled = true;
            this.filterOkatoComboBox.IntegralHeight = false;
            this.filterOkatoComboBox.ItemHeight = 20;
            this.filterOkatoComboBox.Location = new System.Drawing.Point(107, 21);
            this.filterOkatoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterOkatoComboBox.MaxDropDownItems = 20;
            this.filterOkatoComboBox.Name = "filterOkatoComboBox";
            this.filterOkatoComboBox.Size = new System.Drawing.Size(560, 26);
            this.filterOkatoComboBox.TabIndex = 2;
            this.filterOkatoComboBox.SelectedIndexChanged += new System.EventHandler(this.filterControls_ValueChanged);
            // 
            // authorityLabel
            // 
            this.authorityLabel.AutoSize = true;
            this.authorityLabel.Location = new System.Drawing.Point(4, 57);
            this.authorityLabel.Name = "authorityLabel";
            this.authorityLabel.Size = new System.Drawing.Size(93, 17);
            this.authorityLabel.TabIndex = 0;
            this.authorityLabel.Text = "Вид органов:";
            // 
            // SelectOrganizationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(685, 556);
            this.Controls.Add(this.filtrGroupBox);
            this.Controls.Add(this.selectNameLabel);
            this.Controls.Add(this.selectOkatoLabel);
            this.Controls.Add(this.selectOkatoTextBox);
            this.Controls.Add(this.selectNameTextBox);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(701, 592);
            this.Name = "SelectOrganizationDialog";
            this.ShowInTaskbar = false;
            this.Text = "Выбор подразделения";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.ImageList organizationImageList;
        private Controls.NumericTextBox filterCodeNumericTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filterNameTextBox;
        private System.Windows.Forms.CheckBox filterLockCodeViewCheckBox;
    }
}