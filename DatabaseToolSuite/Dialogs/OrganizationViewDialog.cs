namespace DatabaseToolSuite.Dialogs
{
	class OrganizationViewDialog : DialogBase
	{
		private System.Windows.Forms.PropertyGrid propertyGrid1;

		private OrganizationViewDialog() : base()
		{
			InitializeComponent();
		}

		public OrganizationViewDialog(Repositories.MainDataSet.ViewFgisEsnsiOrganization organization) : base()
		{
			InitializeComponent();
			propertyGrid1.SelectedObject = organization;

			DialogCaption = organization.Name;
			ApplyButtonVisible = false;
			CancelButtonVisible = false;
		}


		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizationViewDialog));
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.propertyGrid1.Location = new System.Drawing.Point(15, 99);
			this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(875, 416);
			this.propertyGrid1.TabIndex = 3;
			// 
			// OrganizationViewDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.ClientSize = new System.Drawing.Size(902, 580);
			this.Controls.Add(this.propertyGrid1);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.About24;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.Name = "OrganizationViewDialog";
			this.Controls.SetChildIndex(this.propertyGrid1, 0);
			this.ResumeLayout(false);

		}
	}
}
