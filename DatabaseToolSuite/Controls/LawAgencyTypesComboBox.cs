using DatabaseToolSuite.Repositories.Dto;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]

	internal class LawAgencyTypesComboBox : ComboControl<LawAgencyTypesDto>
	{
		#region Initialize

		public LawAgencyTypesComboBox() : base()
		{
		}

		public void InitializeSource(Repositories.MainDataSet.EXP_LAW_AGENCY_TYPESDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (Repositories.MainDataSet.EXP_LAW_AGENCY_TYPESRow row in table.Rows)
			{
				Add(new LawAgencyTypesDto(row));
			}
			EndUpdate();
		}

		public void InitializeSource(Repositories.EXP_LAW_AGENCY.EXP_LAW_AGENCY_TYPESDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (Repositories.EXP_LAW_AGENCY.EXP_LAW_AGENCY_TYPESRow row in table.Rows)
			{
				Add(new LawAgencyTypesDto(row));
			}
			EndUpdate();
		}

		#endregion Initialize
	}
}