// Ignore Spelling: Oktmo Loc Urp Doesnt

using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	internal class UrpMultiEditDialog : UrpDialog
	{

		public UrpMultiEditDialog() : base()
		{
			SHORT_NAME_textBox.Enabled = false;
			VED_CODE_textBox.Enabled = false;

			DOESNT_CONSOLIDATE_CHILD_checkBox.CheckState = CheckState.Indeterminate;
			DOESNT_CREATE_CARD_checkBox.CheckState = CheckState.Indeterminate;
			DOESNT_SIGN_REPORT_checkBox.CheckState = CheckState.Indeterminate;
		}

		public bool IsEditDoesntConsolidateChild
		{
			get
			{
				return DOESNT_CONSOLIDATE_CHILD_checkBox.CheckState != CheckState.Indeterminate;
			}
		}

		public bool IsEditDoesntCreateCard
		{
			get
			{
				return DOESNT_CREATE_CARD_checkBox.CheckState != CheckState.Indeterminate;
			}
		}

		public bool IsEditDoesntSingReport
		{
			get
			{
				return DOESNT_SIGN_REPORT_checkBox.CheckState != CheckState.Indeterminate;
			}
		}

		public bool IsEditAgencyReceivingReport
		{
			get
			{
				return AGENCY_RECEIVING_REPORT_textBox.Text != string.Empty;
			}
		}

		public bool IsEditLawAgencyType
		{
			get
			{
				return AGENCY_TYPE_ComboBox.Value.HasValue;
			}
		}
		public bool IsEditOktmoLocId
		{
			get
			{
				return OKTMO_LOC_ID_ComboBox.Value.HasValue;
			}
		}
		public bool IsEditSpecialTerritorialCode
		{
			get
			{
				return SPECIAL_TERRITORIAL_CODE_ComboBox.Value.HasValue;
			}
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// AGENCY_RECEIVING_REPORT_textBox
			// 
			this.AGENCY_RECEIVING_REPORT_textBox.Size = new System.Drawing.Size(288, 82);
			// 
			// AGENCY_TYPE_ComboBox
			// 
			this.AGENCY_TYPE_ComboBox.Location = new System.Drawing.Point(195, 341);
			// 
			// VED_CODE_textBox
			// 
			this.VED_CODE_textBox.Location = new System.Drawing.Point(195, 378);
			// 
			// OKTMO_LOC_ID_ComboBox
			// 
			this.OKTMO_LOC_ID_ComboBox.Location = new System.Drawing.Point(327, 410);
			// 
			// UrpMultiEditDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.ClientSize = new System.Drawing.Size(732, 520);
			this.Name = "UrpMultiEditDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
