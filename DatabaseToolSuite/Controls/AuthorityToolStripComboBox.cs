using DatabaseToolSuite.Repositoryes.Dto;
using System.ComponentModel;
using System.Diagnostics;

namespace DatabaseToolSuite.Controls
{
    public class AuthorityToolStripComboBox : ToolStripComboControl<AuthorityDto>
    {
        #region Initialize

        public AuthorityToolStripComboBox() : base() { }

        [DebuggerNonUserCode()]
        public AuthorityToolStripComboBox(IContainer container):base(container: container) { }

        public void InitializeSource(Repositoryes.RepositoryDataSet.authorityDataTable table)
        {
            BeginUpdate();
            ComboBox.Items.Clear();
            foreach (Repositoryes.RepositoryDataSet.authorityRow row in table.Rows)
            {
                Add(new AuthorityDto(row));
            }
            EndUpdate();
        }

        #endregion
    }
}
