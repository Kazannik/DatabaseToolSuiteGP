using System;
using System.Data;

namespace DatabaseToolSuite.Dialogs
{
	internal class TableEditor : DialogBase
	{

		public TableEditor()
		{

			InitializeComponent();

			tables_comboBox.BeginUpdate();
			tables_comboBox.Items.Clear();
			foreach (DataTable table in Services.FileSystem.Repository.MainDataSet.Tables)
			{
				tables_comboBox.Items.Add(table.TableName);
			}
			tables_comboBox.EndUpdate();

		}

		private System.Windows.Forms.ComboBox tables_comboBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGridView1;

		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tables_comboBox = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 134);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 62;
			this.dataGridView1.RowTemplate.Height = 28;
			this.dataGridView1.Size = new System.Drawing.Size(696, 315);
			this.dataGridView1.TabIndex = 3;
			// 
			// tables_comboBox
			// 
			this.tables_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tables_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tables_comboBox.FormattingEnabled = true;
			this.tables_comboBox.Location = new System.Drawing.Point(12, 84);
			this.tables_comboBox.Name = "tables_comboBox";
			this.tables_comboBox.Size = new System.Drawing.Size(576, 33);
			this.tables_comboBox.TabIndex = 4;
			this.tables_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(600, 84);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(106, 31);
			this.button1.TabIndex = 5;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// TableEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.ClientSize = new System.Drawing.Size(718, 524);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tables_comboBox);
			this.Controls.Add(this.dataGridView1);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.Table32;
			this.Name = "TableEditor";
			this.Controls.SetChildIndex(this.dataGridView1, 0);
			this.Controls.SetChildIndex(this.tables_comboBox, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
