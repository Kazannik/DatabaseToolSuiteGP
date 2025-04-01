namespace DatabaseToolSuite.Dialogs
{
	partial class SelectPeriodDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.beginLabel = new System.Windows.Forms.Label();
			this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(134, 200);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(112, 34);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Отмена";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(14, 200);
			this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(112, 34);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "&ОК";
			// 
			// beginLabel
			// 
			this.beginLabel.AutoSize = true;
			this.beginLabel.Location = new System.Drawing.Point(27, 28);
			this.beginLabel.Name = "beginLabel";
			this.beginLabel.Size = new System.Drawing.Size(140, 20);
			this.beginLabel.TabIndex = 0;
			this.beginLabel.Text = "Начало периода:";
			// 
			// beginDateTimePicker
			// 
			this.beginDateTimePicker.Location = new System.Drawing.Point(31, 51);
			this.beginDateTimePicker.Name = "beginDateTimePicker";
			this.beginDateTimePicker.Size = new System.Drawing.Size(200, 26);
			this.beginDateTimePicker.TabIndex = 1;
			// 
			// endDateTimePicker
			// 
			this.endDateTimePicker.Location = new System.Drawing.Point(31, 112);
			this.endDateTimePicker.Name = "endDateTimePicker";
			this.endDateTimePicker.Size = new System.Drawing.Size(200, 26);
			this.endDateTimePicker.TabIndex = 3;
			// 
			// endLabel
			// 
			this.endLabel.AutoSize = true;
			this.endLabel.Location = new System.Drawing.Point(27, 89);
			this.endLabel.Name = "endLabel";
			this.endLabel.Size = new System.Drawing.Size(128, 20);
			this.endLabel.TabIndex = 2;
			this.endLabel.Text = "Конец периода:";
			// 
			// SelectPeriodDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(259, 248);
			this.Controls.Add(this.endDateTimePicker);
			this.Controls.Add(this.endLabel);
			this.Controls.Add(this.beginDateTimePicker);
			this.Controls.Add(this.beginLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectPeriodDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Выбор периода";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label beginLabel;
		private System.Windows.Forms.DateTimePicker beginDateTimePicker;
		private System.Windows.Forms.DateTimePicker endDateTimePicker;
		private System.Windows.Forms.Label endLabel;
	}
}