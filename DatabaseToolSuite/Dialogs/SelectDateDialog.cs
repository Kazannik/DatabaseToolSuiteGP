using DatabaseToolSuite.Services;
using System;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	public partial class SelectDateDialog : Form
	{
		public SelectDateDialog()
		{
			InitializeComponent();
			selectDateTimePicker.Value = DateTime.Now;
			fullDateCheckBox.Checked = false;
		}

		public DateTime SelectDate
		{
			get
			{
				if (fullDateCheckBox.Checked)
					return MasterDataSystem.MIN_DATE;
				else 
					return selectDateTimePicker.Value;
			}
		}

		private void FullDateCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = sender as CheckBox;
			selectDateTimePicker.Enabled = !checkBox.Checked;
		}
	}
}
