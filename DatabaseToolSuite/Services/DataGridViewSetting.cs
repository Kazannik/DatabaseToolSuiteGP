using System.Windows.Forms;

namespace DatabaseToolSuite.Services
{
    static class DataGridViewSetting
    {
        public const string codeCaption = "Код";
        public const string okatoCaption = "ОКАТО";
        public const string nameCaption = "Наименование";
        public const string name2Caption = "Отражаемое наименование";
        public const string centrumCaption = "Центр";
        public const string genitiveCaption = "Наименование в родительном падеже";
        public const string terCaption = "TER";
        public const string kod1Caption = "KOD1";
        public const string labCaption = "LABEL";

        public const string authorityCaption = "Орган власти";
        public const string dateBegCaption = "Дата начала";
        public const string dateEndCaption = "Дата окончания";

        public const string courtCaption = "Вид суда";


        public static void SetSetting(DataGridView control)
        {
            if (control.DataSource is Repositoryes.RepositoryDataSet.gaspsDataTable)
            {
                control.ReadOnly = true;
                control.ShowEditingIcon = false;
                control.RowHeadersVisible = false;
                control.MultiSelect = false;
                control.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                control.Columns["id"].Visible = false;
                control.Columns["key"].Visible = true;
                control.Columns["version"].Visible = true;
                control.Columns["index"].Visible = true;
                control.Columns["owner_id"].Visible = true;
                control.Columns["location_okato_id"].Visible = false;
                control.Columns["another_okato_id"].Visible = false;
                control.Columns["court_type_id"].Visible = false;

                control.Columns["name"].HeaderText = nameCaption; ;
                control.Columns["name"].Visible = true;
                control.Columns["name"].DisplayIndex = 0;
                control.Columns["name"].Width = 400;
                control.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["okato_code"].HeaderText = okatoCaption;
                control.Columns["okato_code"].Visible = true;
                control.Columns["okato_code"].DisplayIndex = 1;
                control.Columns["okato_code"].Width = 60;
                control.Columns["okato_code"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["authority_id"].HeaderText = authorityCaption;
                control.Columns["authority_id"].Visible = true;
                control.Columns["authority_id"].DisplayIndex = 2;
                control.Columns["authority_id"].Width = 60;
                control.Columns["authority_id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                control.Columns["code"].HeaderText = codeCaption;
                control.Columns["code"].Visible = true;
                control.Columns["code"].DisplayIndex = 3;
                control.Columns["code"].Width = 80;
                control.Columns["code"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["date_beg"].HeaderText = dateBegCaption;
                control.Columns["date_beg"].Visible = true;
                control.Columns["date_beg"].DisplayIndex = 4;
                control.Columns["date_beg"].Width = 80;
                control.Columns["date_beg"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["date_end"].HeaderText = dateEndCaption;
                control.Columns["date_end"].Visible = true;
                control.Columns["date_end"].DisplayIndex = 5;
                control.Columns["date_end"].Width = 80;
                control.Columns["date_end"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            }
            else if (control.DataSource is Repositoryes.RepositoryDataSet.okatoDataTable)
            {
                control.ReadOnly = true;
                control.ShowEditingIcon = false;
                control.RowHeadersVisible = false;
                control.MultiSelect = false;
                control.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                control.Columns["code"].HeaderText = codeCaption;
                control.Columns["code"].Visible = true;
                control.Columns["code"].DisplayIndex = 0;
                control.Columns["code"].Width = 60;
                control.Columns["code"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["okato"].HeaderText = okatoCaption;
                control.Columns["okato"].Visible = true;
                control.Columns["okato"].DisplayIndex = 1;
                control.Columns["okato"].Width = 60;
                control.Columns["okato"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["name"].HeaderText = nameCaption;;
                control.Columns["name"].Visible = true;
                control.Columns["name"].DisplayIndex = 2;
                control.Columns["name"].Width = 200;
                control.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["name2"].HeaderText = name2Caption;
                control.Columns["name2"].Visible = true;
                control.Columns["name2"].DisplayIndex = 3;
                control.Columns["name2"].Width = 200;
                control.Columns["name2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["centrum"].Visible = false;
                control.Columns["genitive"].Visible = false;
                control.Columns["ter"].Visible = false;
                control.Columns["kod1"].Visible = false;
                control.Columns["lab"].Visible = false;
            }
            else if (control.DataSource is Repositoryes.RepositoryDataSet.authorityDataTable)
            {
                control.ReadOnly = true;
                control.ShowEditingIcon = false;
                control.RowHeadersVisible = false;
                control.MultiSelect = false;
                control.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                control.Columns["id"].Visible = false;

                control.Columns["code"].HeaderText = codeCaption;
                control.Columns["code"].Visible = true;
                control.Columns["code"].DisplayIndex = 0;
                control.Columns["code"].Width = 60;
                control.Columns["code"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                control.Columns["name"].HeaderText = authorityCaption;
                control.Columns["name"].Visible = true;
                control.Columns["name"].DisplayIndex = 1;
                control.Columns["name"].Width = 200;
                control.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (control.DataSource is Repositoryes.RepositoryDataSet.court_typeDataTable)
            {

                control.ReadOnly = true;
                control.ShowEditingIcon = false;
                control.RowHeadersVisible = false;
                control.MultiSelect = false;
                control.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                control.Columns["id"].Visible = false;

                control.Columns["name"].HeaderText = courtCaption;
                control.Columns["name"].Visible = true;
                control.Columns["name"].DisplayIndex = 0;
                control.Columns["name"].Width = 200;
                control.Columns["name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
