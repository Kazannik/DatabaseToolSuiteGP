using DatabaseToolSuite.Repositoryes;
using DatabaseToolSuite.Repositoryes.Dto;

namespace DatabaseToolSuite.Controls
{
	internal class OkatoComboBox : ComboControl<OkatoDto>
	{
		#region Initialize

		public OkatoComboBox() : base()
		{
		}

		public void InitializeSource(MainDataSet.okatoDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (MainDataSet.okatoRow row in table.Rows)
			{
				Add(new OkatoDto(row));
			}
			EndUpdate();
		}

		#endregion Initialize

		public OkatoDto GetItemFromTer(int ter)
		{
			foreach (OkatoDto i in Items)
			{
				if (i.Ter == ter && i.Kod1 == 0)
				{
					return i;
				}
			}
			return default;
		}
	}
}