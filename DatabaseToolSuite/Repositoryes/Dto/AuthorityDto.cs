using DatabaseToolSuite.Controls;

namespace DatabaseToolSuite.Repositoryes.Dto
{
    public class AuthorityDto : ComboControl<AuthorityDto>.IComboBoxItem
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public string Text { get { return Name; } }

        public AuthorityDto(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public AuthorityDto(Repositoryes.RepositoryDataSet.authorityRow row) : this(code: row.code, name: row.name) { }
    }
}
