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
    public partial class SelectPeriodDialog: Form
    {
        public SelectPeriodDialog()
        {
            InitializeComponent();
            beginDateTimePicker.Value = new DateTime( DateTime.Today.Year, DateTime.Today.Month, 1);
            endDateTimePicker.Value = DateTime.Now;
        }
        
        public DateTime Begin => beginDateTimePicker.Value;

        public DateTime End => endDateTimePicker.Value;
    }
}
