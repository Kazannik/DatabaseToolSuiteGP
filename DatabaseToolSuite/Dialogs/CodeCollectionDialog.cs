using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
    public partial class CodeCollectionDialog : Form
    {
        public CodeCollectionDialog(BindingList<Repositoryes.RepositoryDataSet.gaspsRow> collection)
        {
            InitializeComponent();

            foreach(Repositoryes.RepositoryDataSet.gaspsRow row in collection)
            {
                listBox1.Items.Add(row.code + " " + row.date_beg.ToShortDateString() + "/" + row.date_end.ToShortDateString() + " - "  + row.name);
            }
        }

        private void CodeCollectionDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
