using System;

namespace DatabaseToolSuite.Dialogs
{
	internal class EditErrorDialog : CreateNewVersionDialog
	{
		private System.Windows.Forms.DateTimePicker endDateTimePicker;
		private System.Windows.Forms.Label endDateLabel;
		private readonly DateTime oldBeginDate;
		private readonly DateTime oldEndDate;

		public DateTime EndDate => endDateTimePicker.Value.Date;

		protected string EndDateLabelText
		{
			get => endDateLabel.Text;
			set => endDateLabel.Text = value;
		}

		protected DateTime EndDateTimeValue
		{
			get => endDateTimePicker.Value;
			set => endDateTimePicker.Value = value;
		}

		protected bool EndDateTimeEnabled
		{
			get => endDateTimePicker.Enabled;
			set => endDateTimePicker.Enabled = value;
		}

		public EditErrorDialog() : base()
		{
			InitializeComponent();

			BeginDateLabelText = "Дата введения в действие";
			Text = "Исправление ошибки в записи о подразделении";
			DialogCaption = "Исправление ошибки в записи о подразделении";
			authorityComboBox.Enabled = true;
		}

		public EditErrorDialog(Repositories.MainDataSet.gaspsRow row) : base(row)
		{
			InitializeComponent();

			BeginDateLabelText = "Дата введения в действие";
			BeginDateTimeValue = row.date_beg;
			Text = "Исправление ошибки в записи о подразделении";
			DialogCaption = "Исправление ошибки в записи о подразделении";
			oldBeginDate = row.date_beg;

			EndDateTimeValue = row.date_end;
			oldEndDate = row.date_end;

			Controls_ValueChanged(this, EventArgs.Empty);
			authorityComboBox.Enabled = true;
		}

		protected override bool AdditionalCondition()
		{
			return DateTime.Equals(BeginDateTimeValue, oldBeginDate) && DateTime.Equals(EndDateTimeValue, oldEndDate);
		}

		protected override void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Controls_ValueChanged(this, EventArgs.Empty);
		}

		private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			Controls_ValueChanged(this, EventArgs.Empty);
		}

		private void InitializeComponent()
		{
			this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endDateLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// authorityComboBox
			// 
			this.authorityComboBox.Location = new System.Drawing.Point(144, 228);
			this.authorityComboBox.Size = new System.Drawing.Size(629, 31);
			// 
			// endDateTimePicker
			// 
			this.endDateTimePicker.Location = new System.Drawing.Point(366, 96);
			this.endDateTimePicker.Name = "endDateTimePicker";
			this.endDateTimePicker.Size = new System.Drawing.Size(192, 27);
			this.endDateTimePicker.TabIndex = 40;
			this.endDateTimePicker.ValueChanged += new System.EventHandler(this.EndDateTimePicker_ValueChanged);
			// 
			// endDateLabel
			// 
			this.endDateLabel.AutoSize = true;
			this.endDateLabel.Location = new System.Drawing.Point(366, 72);
			this.endDateLabel.Name = "endDateLabel";
			this.endDateLabel.Size = new System.Drawing.Size(175, 20);
			this.endDateLabel.TabIndex = 41;
			this.endDateLabel.Text = "Дата прекращения:";
			// 
			// EditErrorDialog
			// 
			this.AcceptButton = null;
			this.CancelButton = null;
			this.Controls.Add(this.endDateLabel);
			this.Controls.Add(this.endDateTimePicker);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.Edit32;
			this.Name = "EditErrorDialog";
			this.Controls.SetChildIndex(this.endDateTimePicker, 0);
			this.Controls.SetChildIndex(this.endDateLabel, 0);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		
	}
}