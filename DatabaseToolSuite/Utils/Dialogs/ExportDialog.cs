using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
