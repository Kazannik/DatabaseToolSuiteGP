using System;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
    public partial class ExportDialog : Form
    {
        public ExportDialog()
        {
            InitializeComponent();
        }

        private void ExportDialog_Load(object sender, EventArgs e)
        {
            Repositoryes.DatabaseRepository repository = new Repositoryes.DatabaseRepository();

        }
    }
}
