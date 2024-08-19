using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    public class EditErrorDialog : CreateNewVersionDialog
    {
        public EditErrorDialog() : base()
        {
            beginDateLabel.Text = "Дата введения в действие";
            Text = "Исправление ошибки в записи о подразделении";
            DialogCaption = "Исправление ошибки в записи о подразделении";
        }

        public EditErrorDialog(gaspsRow row) : base(row)
        {
            beginDateLabel.Text = "Дата введения в действие";
            beginDateTimePicker.Value = row.date_beg;
            Text = "Исправление ошибки в записи о подразделении";
            DialogCaption = "Исправление ошибки в записи о подразделении";
        }

        private void InitializeComponent()
        {
            this.organizationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditErrorDialog
            // 
            this.AcceptButton = null;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = null;
            this.ClientSize = new System.Drawing.Size(722, 533);
            this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.Edit32;
            this.Name = "EditErrorDialog";
            this.organizationGroupBox.ResumeLayout(false);
            this.organizationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}