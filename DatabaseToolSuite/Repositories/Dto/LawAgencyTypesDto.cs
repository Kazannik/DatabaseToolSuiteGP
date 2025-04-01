// Ignore Spelling: Dto

using DatabaseToolSuite.Controls;

namespace DatabaseToolSuite.Repositories.Dto
{
	internal class LawAgencyTypesDto : ComboControl<LawAgencyTypesDto>.IComboBoxItem
	{
		public long Id { get; private set; }

		public string Code { get { return Id.ToString(); } }

		public string Name { get; private set; }

		public string Text { get { return Name; } }

		public bool MandatoryCode { get; private set; }

		public LawAgencyTypesDto(long id, bool mandatoryCode, string name)
		{
			Id = id;
			MandatoryCode = mandatoryCode;
			Name = name;
		}

		public LawAgencyTypesDto(MainDataSet.EXP_LAW_AGENCY_TYPESRow row) : this(
			id: row.ID,
			mandatoryCode: row.MANDATORY_CODE,
			name: row.NAME
			)
		{ }

		public LawAgencyTypesDto(EXP_LAW_AGENCY.EXP_LAW_AGENCY_TYPESRow row) : this(
			id: row.ID,
			mandatoryCode: row.MANDATORY_CODE,
			name: row.NAME
			)
		{ }
	}
}