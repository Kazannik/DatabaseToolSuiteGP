using DatabaseToolSuite.Repositories.Dto;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
	internal class SpecialTerritorialComboBox : ComboControl<SpecialTerritorialDto>
	{
		#region Initialize

		public SpecialTerritorialComboBox() : base()
		{
		}

		public void InitializeSource(Repositories.MainDataSet.SPECIAL_TERRITORIAL_CODEDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (Repositories.MainDataSet.SPECIAL_TERRITORIAL_CODERow row in table.Rows)
			{
				Add(new SpecialTerritorialDto(row));
			}
			EndUpdate();
		}

		public void InitializeSource(Repositories.EXP_LAW_AGENCY.SPECIAL_TERRITORIAL_CODEDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (Repositories.EXP_LAW_AGENCY.SPECIAL_TERRITORIAL_CODERow row in table.Rows)
			{
				Add(new SpecialTerritorialDto(row));
			}
			EndUpdate();
		}

		#endregion Initialize
	}
}