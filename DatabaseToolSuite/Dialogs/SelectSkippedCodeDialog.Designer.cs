namespace DatabaseToolSuite.Dialogs
{
	partial class SelectSkippedCodeDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSkippedCodeDialog));
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.skippedCodeListBox = new System.Windows.Forms.ListBox();
			this.filterCodeTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(193, 413);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(112, 34);
			this.cancelButton.TabIndex = 30;
			this.cancelButton.Text = "Отмена";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(71, 413);
			this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(112, 34);
			this.okButton.TabIndex = 29;
			this.okButton.Text = "&ОК";
			// 
			// skippedCodeListBox
			// 
			this.skippedCodeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.skippedCodeListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.skippedCodeListBox.FormattingEnabled = true;
			this.skippedCodeListBox.ItemHeight = 25;
			this.skippedCodeListBox.Location = new System.Drawing.Point(13, 65);
			this.skippedCodeListBox.Name = "skippedCodeListBox";
			this.skippedCodeListBox.Size = new System.Drawing.Size(293, 329);
			this.skippedCodeListBox.TabIndex = 31;
			this.skippedCodeListBox.SelectedIndexChanged += new System.EventHandler(this.SkippedCodeListBox_SelectedIndexChanged);
			// 
			// filterCodeTextBox
			// 
			this.filterCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.filterCodeTextBox.Location = new System.Drawing.Point(13, 12);
			this.filterCodeTextBox.Name = "filterCodeTextBox";
			this.filterCodeTextBox.Size = new System.Drawing.Size(292, 30);
			this.filterCodeTextBox.TabIndex = 32;
			this.filterCodeTextBox.TextChanged += new System.EventHandler(this.FilterCodeTextBox_TextChanged);
			// 
			// SelectSkippedCodeDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(318, 461);
			this.Controls.Add(this.filterCodeTextBox);
			this.Controls.Add(this.skippedCodeListBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectSkippedCodeDialog";
			this.Text = "Выбор пропущенного кода";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.ListBox skippedCodeListBox;
		private System.Windows.Forms.TextBox filterCodeTextBox;
	}
}