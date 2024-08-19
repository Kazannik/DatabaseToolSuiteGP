using DatabaseToolSuite.Repositoryes.Dto;
using System.ComponentModel;
using System.Diagnostics;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Controls
{
    public class OkatoToolStripComboBox: ToolStripComboControl<OkatoDto>
    {
        #region Initialize

        public OkatoToolStripComboBox() : base() { }

        [DebuggerNonUserCode()]
        public OkatoToolStripComboBox(IContainer container):base(container: container) { }

        public void InitializeSource(okatoDataTable table)
        {
            BeginUpdate();
            ComboBox.Items.Clear();
            foreach (okatoRow row in table.Rows)
            {
                Add(new OkatoDto(row));
            }
            EndUpdate();
        }

        #endregion
    }
}
