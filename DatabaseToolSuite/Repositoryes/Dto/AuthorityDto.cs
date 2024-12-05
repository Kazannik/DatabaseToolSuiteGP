using DatabaseToolSuite.Controls;

namespace DatabaseToolSuite.Repositoryes.Dto
{
	internal class AuthorityDto : ComboControl<AuthorityDto>.IComboBoxItem
	{
		public AuthorityDto()
		{
			Id = -1;
			Code = string.Empty;
			Name = string.Empty;
		}

		public long Id { get; private set; }

		public string Code { get; private set; }

		public string Name { get; private set; }

		public string Text
		{ get { return Name; } }

		public AuthorityDto(string code, string name)
		{
			Id = 0;
			Code = code;
			Name = name;
		}

		public AuthorityDto(MainDataSet.authorityRow row) : this(code: row.code, name: row.name)
		{
			Id = row.id;
		}
	}
}