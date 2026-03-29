// Ignore Spelling: Oktmo Loc Urp Doesnt

using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	internal class UrpMultiEditDialog : UrpDialog
	{

		public UrpMultiEditDialog() : base()
		{
			SHORT_NAME_TextBox.Enabled = false;
			VED_CODE_TextBox.Enabled = false;

			DOESNT_CONSOLIDATE_CHILD_CheckBox.CheckState = CheckState.Indeterminate;
			DOESNT_CREATE_CARD_CheckBox.CheckState = CheckState.Indeterminate;
			DOESNT_SIGN_REPORT_CheckBox.CheckState = CheckState.Indeterminate;
			IS_GS_CheckBox.CheckState = CheckState.Indeterminate;
		}

		public bool IsEditIsGS => IS_GS_CheckBox.CheckState != CheckState.Indeterminate;

		public bool IsEditDoesntConsolidateChild => DOESNT_CONSOLIDATE_CHILD_CheckBox.CheckState != CheckState.Indeterminate;

		public bool IsEditDoesntCreateCard => DOESNT_CREATE_CARD_CheckBox.CheckState != CheckState.Indeterminate;

		public bool IsEditDoesntSingReport => DOESNT_SIGN_REPORT_CheckBox.CheckState != CheckState.Indeterminate;

		public bool IsEditAgencyReceivingReport => AGENCY_RECEIVING_REPORT_TextBox.Text != string.Empty;

		public bool IsEditLawAgencyType => AGENCY_TYPE_ComboBox.Value.HasValue;

		public bool IsEditOktmoLocId => OKTMO_LOC_ID_ComboBox.Value.HasValue;

		public bool IsEditSpecialTerritorialCode => SPECIAL_TERRITORIAL_CODE_ComboBox.Value.HasValue;
	}
}
