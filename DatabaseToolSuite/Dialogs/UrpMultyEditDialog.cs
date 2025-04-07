using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	internal class UrpMultyEditDialog : UrpDialog
	{

		public UrpMultyEditDialog() : base()
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
	}
}
