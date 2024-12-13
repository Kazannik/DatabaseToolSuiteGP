using DatabaseToolSuite.Repositoryes.Dto;
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

		public void InitializeSource(Repositoryes.MainDataSet.EXP_LAW_AGENCY_TYPESDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (Repositoryes.MainDataSet.EXP_LAW_AGENCY_TYPESRow row in table.Rows)
			{
				Add(new LawAgencyTypesDto(row));
			}
			EndUpdate();
		}

		public void InitializeSource(Repositoryes.EXP_LAW_AGENCY.EXP_LAW_AGENCY_TYPESDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (Repositoryes.EXP_LAW_AGENCY.EXP_LAW_AGENCY_TYPESRow row in table.Rows)
			{
				Add(new LawAgencyTypesDto(row));
			}
			EndUpdate();
		}

		#endregion Initialize
	}
}