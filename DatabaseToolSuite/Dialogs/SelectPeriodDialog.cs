using System;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	public partial class SelectPeriodDialog : Form
	{
		public SelectPeriodDialog()
		{
			InitializeComponent();
			beginDateTimePicker.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			endDateTimePicker.Value = DateTime.Now;
		}

		public DateTime Begin => beginDateTimePicker.Value;

		public DateTime End => endDateTimePicker.Value;
	}
}
