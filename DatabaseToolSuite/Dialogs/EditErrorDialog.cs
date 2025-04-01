namespace DatabaseToolSuite.Dialogs
{
	internal class EditErrorDialog : CreateNewVersionDialog
	{
		public EditErrorDialog() : base()
		{
			BeginDateLabelText = "Дата введения в действие";
			Text = "Исправление ошибки в записи о подразделении";
			DialogCaption = "Исправление ошибки в записи о подразделении";
		}

		public EditErrorDialog(Repositories.MainDataSet.gaspsRow row) : base(row)
		{
			BeginDateLabelText = "Дата введения в действие";
			BeginDateTimeValue = row.date_beg;
			Text = "Исправление ошибки в записи о подразделении";
			DialogCaption = "Исправление ошибки в записи о подразделении";
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