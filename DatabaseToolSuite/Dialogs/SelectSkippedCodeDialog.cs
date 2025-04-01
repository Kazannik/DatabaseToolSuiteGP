// Ignore Spelling: Okato

using DatabaseToolSuite.Repositories;
using DatabaseToolSuite.Services;
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
	internal partial class SelectSkippedCodeDialog: Form
    {
		private readonly MainDataSet dialogDataSet;

		public string Code => skippedCodeListBox.SelectedItem.ToString();

		public string Okato {  get; }

		public long Authority { get;}

		public SelectSkippedCodeDialog() : this(dataSet: FileSystem.Repository.MainDataSet)
		{
		}
		
		public SelectSkippedCodeDialog(long authority, string okato) : this(dataSet: FileSystem.Repository.MainDataSet)
		{
			Authority = authority;
			Okato = okato;
			InitializeCode(dataSet: dialogDataSet, filter: filterCodeTextBox.Text);
		}

		public SelectSkippedCodeDialog(MainDataSet dataSet)
		{
			dialogDataSet = dataSet;
			InitializeComponent();	
			okButton.Enabled = false;
		}

		private void InitializeCode(MainDataSet dataSet, string filter)
		{
			string format = Okato.Length == 2 ? "0000" : "00";
			
			skippedCodeListBox.BeginUpdate();

			skippedCodeListBox.Items.Clear();

			IEnumerable<string> codes = dataSet.gasps.GetSkippedCodes(authority: Authority, okato: Okato)
				.Select(c => Authority.ToString("00") + Okato +  c.ToString(format))
				.Where(c => c.Contains(filter));

			foreach (string code in codes)
			{
				skippedCodeListBox.Items.Add(code);
			}

			if (codes.Any())
			{
				skippedCodeListBox.SelectedIndex = 0;
			}

			skippedCodeListBox.EndUpdate();
		}

		private void SkippedCodeListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			okButton.Enabled = skippedCodeListBox.SelectedIndex >= 0;
		}

		private void FilterCodeTextBox_TextChanged(object sender, EventArgs e)
		{
			InitializeCode(dataSet: dialogDataSet, filter: filterCodeTextBox.Text);
		}
	}
}
