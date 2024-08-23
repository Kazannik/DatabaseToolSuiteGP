using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    class ErvkDialog : DialogBase
    {
        public ervkRow DataRow { get; }


        public ErvkDialog(): base()
        {
            ApplyButtonVisible = false;

            InitializeComponent();
        }

        public ErvkDialog(gaspsRow gaspsRow, ervkRow row) : base()
        {
            ApplyButtonVisible = false;

            InitializeComponent();

            DataRow = row;

            FormBorderStyle = FormBorderStyle.Sizable;

            Text = "ФГИС 'Единая система нормативно-справочной информации'";
            DialogCaption = "Сведения о прокуратуре для ЕРВК";


            esnsiNameTextBox.Text = gaspsRow.name;
           // esnsiRegionTextBox.Text = esnsiOkatoComboBox.SelectedItem != null ? esnsiOkatoComboBox.SelectedItem.Name2 : string.Empty;

            OkButtonEnabled = false;
        }

        private System.Windows.Forms.TextBox esnsiRegionTextBox;
        private System.Windows.Forms.Label esnsiRegionLabel;
        private System.Windows.Forms.TextBox esnsiNameTextBox;
        private System.Windows.Forms.Label esnsiNameLabel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErvkDialog));
            this.esnsiRegionTextBox = new System.Windows.Forms.TextBox();
            this.esnsiRegionLabel = new System.Windows.Forms.Label();
            this.esnsiNameTextBox = new System.Windows.Forms.TextBox();
            this.esnsiNameLabel = new System.Windows.Forms.Label();
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
            // esnsiRegionTextBox
            // 
            this.esnsiRegionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiRegionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiRegionTextBox.Location = new System.Drawing.Point(86, 123);
            this.esnsiRegionTextBox.Name = "esnsiRegionTextBox";
            this.esnsiRegionTextBox.ReadOnly = true;
            this.esnsiRegionTextBox.Size = new System.Drawing.Size(624, 27);
            this.esnsiRegionTextBox.TabIndex = 10;
            // 
            // esnsiRegionLabel
            // 
            this.esnsiRegionLabel.AutoSize = true;
            this.esnsiRegionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiRegionLabel.Location = new System.Drawing.Point(12, 126);
            this.esnsiRegionLabel.Name = "esnsiRegionLabel";
            this.esnsiRegionLabel.Size = new System.Drawing.Size(68, 20);
            this.esnsiRegionLabel.TabIndex = 9;
            this.esnsiRegionLabel.Text = "Регион";
            // 
            // esnsiNameTextBox
            // 
            this.esnsiNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiNameTextBox.Location = new System.Drawing.Point(16, 90);
            this.esnsiNameTextBox.Name = "esnsiNameTextBox";
            this.esnsiNameTextBox.ReadOnly = true;
            this.esnsiNameTextBox.Size = new System.Drawing.Size(694, 27);
            this.esnsiNameTextBox.TabIndex = 8;
            // 
            // esnsiNameLabel
            // 
            this.esnsiNameLabel.AutoSize = true;
            this.esnsiNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiNameLabel.Location = new System.Drawing.Point(12, 67);
            this.esnsiNameLabel.Name = "esnsiNameLabel";
            this.esnsiNameLabel.Size = new System.Drawing.Size(246, 20);
            this.esnsiNameLabel.TabIndex = 7;
            this.esnsiNameLabel.Text = "Наименование прокуратуры";
            // 
            // ErvkDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(722, 533);
            this.Controls.Add(this.esnsiRegionTextBox);
            this.Controls.Add(this.esnsiRegionLabel);
            this.Controls.Add(this.esnsiNameTextBox);
            this.Controls.Add(this.esnsiNameLabel);
            this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.epgu;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErvkDialog";
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.esnsiNameLabel, 0);
            this.Controls.SetChildIndex(this.esnsiNameTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiRegionLabel, 0);
            this.Controls.SetChildIndex(this.esnsiRegionTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
