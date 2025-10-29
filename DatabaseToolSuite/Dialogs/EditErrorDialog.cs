using DatabaseToolSuite.Controls;
using System;

namespace DatabaseToolSuite.Dialogs
{
	internal class EditErrorDialog : CreateNewVersionDialog
	{
		private readonly DateTime oldBeginDate;

		public EditErrorDialog() : base()
		{
			BeginDateLabelText = "Дата введения в действие";
			Text = "Исправление ошибки в записи о подразделении";
			DialogCaption = "Исправление ошибки в записи о подразделении";
			authorityComboBox.Enabled = true;

		}

		public EditErrorDialog(Repositories.MainDataSet.gaspsRow row) : base(row)
		{
			BeginDateLabelText = "Дата введения в действие";
			BeginDateTimeValue = row.date_beg;
			Text = "Исправление ошибки в записи о подразделении";
			DialogCaption = "Исправление ошибки в записи о подразделении";
			oldBeginDate = row.date_beg;
			Controls_ValueChanged(this, EventArgs.Empty);
			authorityComboBox.Enabled = true;
		}

		protected override bool AdditionalCondition()
		{
			return DateTime.Equals(BeginDateTimeValue, oldBeginDate);
		}

		protected override void ComboBox_SelectedIndexChanged(object sender, EventArgs e) 
		{
			Controls_ValueChanged(this, EventArgs.Empty);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			//
			// EditErrorDialog
			//
			this.AcceptButton = null;
			this.CancelButton = null;
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.Edit32;
			this.Name = "EditErrorDialog";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}