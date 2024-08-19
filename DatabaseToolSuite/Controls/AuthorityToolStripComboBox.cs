using DatabaseToolSuite.Repositoryes.Dto;
using System.ComponentModel;
using System.Diagnostics;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Controls
{
    public class AuthorityToolStripComboBox : ToolStripComboControl<AuthorityDto>
    {
        #region Initialize

        public AuthorityToolStripComboBox() : base() { }

        [DebuggerNonUserCode()]
        public AuthorityToolStripComboBox(IContainer container):base(container: container) { }

        public void InitializeSource(authorityDataTable table)
        {
            BeginUpdate();
            ComboBox.Items.Clear();
            foreach (authorityRow row in table.Rows)
            {
                Add(new AuthorityDto(row));
            }
            EndUpdate();
        }

        #endregion
    }
}
