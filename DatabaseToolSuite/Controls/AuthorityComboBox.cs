using DatabaseToolSuite.Repositoryes.Dto;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class AuthorityComboBox : ComboControl<AuthorityDto>
    {
        #region Initialize
        public AuthorityComboBox() : base() { }

        public void InitializeSource(Repositoryes.RepositoryDataSet.authorityDataTable table)
        {
            BeginUpdate();
            Items.Clear();
            foreach (Repositoryes.RepositoryDataSet.authorityRow row in table.Rows)
            {
                Add(new AuthorityDto(row));
            }
            EndUpdate();
        }

        #endregion
    }
}
