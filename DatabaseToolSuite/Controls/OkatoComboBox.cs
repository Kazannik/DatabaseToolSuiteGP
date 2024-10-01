using DatabaseToolSuite.Repositoryes.Dto;
using System.ComponentModel;
using System.Diagnostics;

namespace DatabaseToolSuite.Controls
{
    public class OkatoComboBox: ComboControl<OkatoDto>
    {
        #region Initialize

        public OkatoComboBox() : base() { }

        public void InitializeSource(Repositoryes.RepositoryDataSet.okatoDataTable table)
        {
            BeginUpdate();
            Items.Clear();
            foreach (Repositoryes.RepositoryDataSet.okatoRow row in table.Rows)
            {
                Add(new OkatoDto(row));
            }
            EndUpdate();
        }

        #endregion


        public OkatoDto GetItemFromTer(int ter)
        {
            foreach (OkatoDto i in Items)
            {
                if (i.Ter == ter && i.Kod1 == 0)
                {
                    return i;
                }
            }
            return default(OkatoDto);
        }
    }
}

