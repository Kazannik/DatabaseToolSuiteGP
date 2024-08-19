using DatabaseToolSuite.Controls;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Repositoryes.Dto
{
    public class AuthorityDto: ComboControl<AuthorityDto>.IComboBoxItem
    {
        public string Code { get; }

        public string Name { get; }

        public string Text { get { return Name; } }

        public AuthorityDto(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public AuthorityDto(authorityRow row) : this(code: row.code, name: row.name) { }
    }
}
