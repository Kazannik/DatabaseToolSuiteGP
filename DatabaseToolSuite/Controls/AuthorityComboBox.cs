using DatabaseToolSuite.Repositoryes.Dto;
using System.Windows.Forms.Design;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class AuthorityComboBox: ComboControl<AuthorityDto>
    {
        #region Initialize
        public  AuthorityComboBox() : base() { }

        public void InitializeSource(authorityDataTable table)
        {
            BeginUpdate();
            Items.Clear();
            foreach (authorityRow row in table.Rows)
            {
                Add(new AuthorityDto(row));
            }
            EndUpdate();
        }

        #endregion
    }
}
