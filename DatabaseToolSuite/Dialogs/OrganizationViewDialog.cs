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
			this.propertyGrid1.Location = new System.Drawing.Point(12, 79);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(700, 373);
			this.propertyGrid1.TabIndex = 3;
			// 
			// OrganizationViewDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(722, 533);
			this.Controls.Add(this.propertyGrid1);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.About24;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "OrganizationViewDialog";
			this.Controls.SetChildIndex(this.propertyGrid1, 0);
			this.ResumeLayout(false);

		}
	}
}
