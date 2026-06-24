using DatabaseToolSuite.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using static DatabaseToolSuite.Repositories.MainDataSet;

namespace DatabaseToolSuite.Dialogs
{
	public partial class ExportToWordDialog : DialogBase
	{
		public ExportToWordDialog(): base()
		{
			InitializeComponent();

			Text = "Экспорт данных в документ Microsoft Office Word";
			DialogCaption = "Экспорт данных в документ Microsoft Office Word";

			ApplyButtonVisible = false;
			OkButtonEnabled = false;
			MaximizeBox = true;
			StartPosition = FormStartPosition.CenterScreen;

			InitializeCollection();
		}


		private void InitializeCollection()
		{
			checkedListBox1.Items.Clear();
			List<ViewGaspsOrganization> views = 
				new List<ViewGaspsOrganization>(MasterDataSystem.DataSet.gasps.ExportData(dateTimePicker1.Value.Date));
			foreach (ViewGaspsOrganization item in views)
			{
				checkedListBox1.Items.Add(item);
			}
		}

		private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			InitializeCollection();
		}

		private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			OkButtonEnabled = checkedListBox1.CheckedItems.Count > 0;
		}

		private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			OkButtonEnabled = checkedListBox1.CheckedItems.Count > 0;
		}

		private void CheckedListBox1_MouseClick(object sender, MouseEventArgs e)
		{
			OkButtonEnabled = checkedListBox1.CheckedItems.Count > 0;
		}

		private void ExportToWordDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				try
				{
					IEnumerable<ViewGaspsOrganization> collection =
						from object item
						in checkedListBox1.CheckedItems
						select item as ViewGaspsOrganization;
					Export.ExportToWord(collection, dateTimePicker1.Value.Date);
				}
				catch (Exception ex) { MessageBox.Show(ex.Message); }				
			}			
		}

		private void CheckAllButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				checkedListBox1.SetItemChecked(i, true);
			}
		}

		private void CheckedListBox1_Click(object sender, EventArgs e)
		{
			OkButtonEnabled = checkedListBox1.CheckedItems.Count > 0;
		}

		private void CheckedListBox1_MouseUp(object sender, MouseEventArgs e)
		{
			OkButtonEnabled = checkedListBox1.CheckedItems.Count > 0;
		}

		private void CheckedListBox1_KeyUp(object sender, KeyEventArgs e)
		{
			OkButtonEnabled = checkedListBox1.CheckedItems.Count > 0;
		}
	}
}
