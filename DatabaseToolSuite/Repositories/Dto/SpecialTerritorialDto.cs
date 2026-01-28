// Ignore Spelling: Dto

using DatabaseToolSuite.Controls;

namespace DatabaseToolSuite.Repositories.Dto
{
	internal class SpecialTerritorialDto : ComboControl<SpecialTerritorialDto>.IComboBoxItem
	{
		public long Id { get; private set; }

		public string Code { get; private set; }

		public string Name { get; private set; }

		public string Text => Name;

		public SpecialTerritorialDto()
		{
			Id = -1;
			Code = string.Empty;
			Name = string.Empty;
		}

		public SpecialTerritorialDto(long id, string code, string name)
		{
			Id = id;
			Code = code;
			Name = name;
		}

		public SpecialTerritorialDto(MainDataSet.SPECIAL_TERRITORIAL_CODERow row) : this(
			id: row.ID,
			code: row.CODE,
			name: row.NAME
			)
		{ }

		public SpecialTerritorialDto(EXP_LAW_AGENCY.SPECIAL_TERRITORIAL_CODERow row) : this(
			id: row.ID,
			code: row.CODE,
			name: row.NAME
			)
		{ }
	}
}