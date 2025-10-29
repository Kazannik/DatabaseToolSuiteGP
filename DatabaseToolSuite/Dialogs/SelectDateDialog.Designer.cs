namespace DatabaseToolSuite.Dialogs
{
	partial class SelectDateDialog
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
			this.selectDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.fullDateCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// selectDateTimePicker
			// 
			this.selectDateTimePicker.Location = new System.Drawing.Point(17, 67);
			this.selectDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.selectDateTimePicker.Name = "selectDateTimePicker";
			this.selectDateTimePicker.Size = new System.Drawing.Size(178, 22);
			this.selectDateTimePicker.TabIndex = 7;
			// 
			// endLabel
			// 
			this.endLabel.AutoSize = true;
			this.endLabel.Location = new System.Drawing.Point(14, 49);
			this.endLabel.Name = "endLabel";
			this.endLabel.Size = new System.Drawing.Size(123, 16);
			this.endLabel.TabIndex = 6;
			this.endLabel.Text = "За период с даты:";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(124, 125);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(100, 27);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "Отмена";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(17, 125);
			this.okButton.Margin = new System.Windows.Forms.Padding(4);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(100, 27);
			this.okButton.TabIndex = 8;
			this.okButton.Text = "&ОК";
			// 
			// fullDateCheckBox
			// 
			this.fullDateCheckBox.AutoSize = true;
			this.fullDateCheckBox.Location = new System.Drawing.Point(17, 12);
			this.fullDateCheckBox.Name = "fullDateCheckBox";
			this.fullDateCheckBox.Size = new System.Drawing.Size(130, 20);
			this.fullDateCheckBox.TabIndex = 10;
			this.fullDateCheckBox.Text = "За весь период";
			this.fullDateCheckBox.UseVisualStyleBackColor = true;
			this.fullDateCheckBox.CheckedChanged += new System.EventHandler(this.FullDateCheckBox_CheckedChanged);
			// 
			// SelectDateDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(236, 167);
			this.Controls.Add(this.fullDateCheckBox);
			this.Controls.Add(this.selectDateTimePicker);
			this.Controls.Add(this.endLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectDateDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Выбор периода";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker selectDateTimePicker;
		private System.Windows.Forms.Label endLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.CheckBox fullDateCheckBox;
	}
}