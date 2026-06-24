namespace DatabaseToolSuite.Dialogs
{
	partial class ExportToWordDialog
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.checkAllButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(12, 66);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(186, 27);
			this.dateTimePicker1.TabIndex = 0;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(12, 108);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(690, 329);
			this.checkedListBox1.TabIndex = 1;
			this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox1_ItemCheck);
			this.checkedListBox1.Click += new System.EventHandler(this.CheckedListBox1_Click);
			this.checkedListBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckedListBox1_MouseClick);
			this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
			this.checkedListBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CheckedListBox1_KeyUp);
			this.checkedListBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CheckedListBox1_MouseUp);
			// 
			// checkAllButton
			// 
			this.checkAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkAllButton.Location = new System.Drawing.Point(12, 444);
			this.checkAllButton.Name = "checkAllButton";
			this.checkAllButton.Size = new System.Drawing.Size(174, 30);
			this.checkAllButton.TabIndex = 3;
			this.checkAllButton.Text = "Выделить все";
			this.checkAllButton.UseVisualStyleBackColor = true;
			this.checkAllButton.Click += new System.EventHandler(this.CheckAllButton_Click);
			// 
			// ExportToWordDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.ClientSize = new System.Drawing.Size(722, 533);
			this.Controls.Add(this.checkAllButton);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "ExportToWordDialog";
			this.Text = "Экспорт результатов в Документ Microsoft Word";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportToWordDialog_FormClosing);
			this.Controls.SetChildIndex(this.dateTimePicker1, 0);
			this.Controls.SetChildIndex(this.checkedListBox1, 0);
			this.Controls.SetChildIndex(this.checkAllButton, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Button checkAllButton;
	}
}