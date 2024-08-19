using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet.gaspsDataTable;

namespace DatabaseToolSuite.Dialogs
{
    class OrganizationViewDialog : DialogBase
    {
        private System.Windows.Forms.PropertyGrid propertyGrid1;



        private OrganizationViewDialog() : base()
        {
            InitializeComponent();
        }

        public OrganizationViewDialog(FullOrganization organization ) : base()
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
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(637, 506);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(475, 506);
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
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(722, 533);
            this.Controls.Add(this.propertyGrid1);
            this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.About24;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrganizationViewDialog";
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.ResumeLayout(false);

        }
    }
}
