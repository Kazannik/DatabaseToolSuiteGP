using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    public partial class CodeCollectionDialog : Form
    {
        public CodeCollectionDialog(BindingList<gaspsRow> collection)
        {
            InitializeComponent();

            foreach(gaspsRow row in collection)
            {
                listBox1.Items.Add(row.code + " " + row.date_beg.ToShortDateString() + "/" + row.date_end.ToShortDateString() + " - "  + row.name);
            }
        }

        private void CodeCollectionDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
