using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	class StatisticsDialog : DialogBase
	{
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.Windows.Forms.ColumnHeader expensesСolumnHeader;
		private Controls.AuthorityComboBox authorityComboBox1;
		private Label label1;
		private System.Windows.Forms.ListView listView1;

		public StatisticsDialog() : base()
		{
			DialogCaption = "Остаток неиспользованных кодов";
			DialogCaptionImage = Properties.Resources.Statistics32;
			ApplyButtonVisible = false;
			CancelButtonVisible = false;


			InitializeComponent();

			authorityComboBox1.InitializeSource(Services.FileSystem.Repository.MainDataSet.authority);

			TableReload();
		}


		private void authorityComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			TableReload();
		}


		private void TableReload()
		{
			listView1.Items.Clear();
			if (!authorityComboBox1.Value.HasValue) return;

			if (Services.MasterDataSystem.DataSet.okato.Count > 0)
			{
				foreach (Repositories.MainDataSet.okatoRow row in Services.MasterDataSystem.DataSet.okato)
				{
					ListViewItem item = new ListViewItem(row.name + " (" + row.code + ")");
					IEnumerable<long> codes = Services.MasterDataSystem.DataSet.gasps.GetUsedCodes(authorityComboBox1.Value.Value, row.okato);
					decimal expenses;
					if (row.code.Length == 2)
					{
						expenses = 9999 - codes.Count();
					}
					else
					{
						expenses = 99 - codes.Count();
					}
					item.SubItems.Add(expenses.ToString());
					listView1.Items.Add(item);
				}
			}
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsDialog));
			this.listView1 = new System.Windows.Forms.ListView();
			this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.expensesСolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.authorityComboBox1 = new DatabaseToolSuite.Controls.AuthorityComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.nameColumnHeader,
			this.expensesСolumnHeader});
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(18, 136);
			this.listView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(1046, 569);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "ОКАТО";
			this.nameColumnHeader.Width = 518;
			// 
			// expensesСolumnHeader
			// 
			this.expensesСolumnHeader.Text = "Остаток незадействованных кодов";
			this.expensesСolumnHeader.Width = 162;
			// 
			// authorityComboBox1
			// 
			this.authorityComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.authorityComboBox1.Code = "";
			this.authorityComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.authorityComboBox1.DropDownHeight = 584;
			this.authorityComboBox1.DropDownWidth = 80;
			this.authorityComboBox1.FormattingEnabled = true;
			this.authorityComboBox1.IntegralHeight = false;
			this.authorityComboBox1.ItemHeight = 29;
			this.authorityComboBox1.Location = new System.Drawing.Point(181, 86);
			this.authorityComboBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.authorityComboBox1.MaxDropDownItems = 20;
			this.authorityComboBox1.Name = "authorityComboBox1";
			this.authorityComboBox1.SelectedItem = null;
			this.authorityComboBox1.Size = new System.Drawing.Size(881, 35);
			this.authorityComboBox1.TabIndex = 4;
			this.authorityComboBox1.SelectedIndexChanged += new System.EventHandler(this.authorityComboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 90);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 25);
			this.label1.TabIndex = 5;
			this.label1.Text = "Вид органа:";
			// 
			// StatisticsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.ClientSize = new System.Drawing.Size(1082, 832);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.authorityComboBox1);
			this.Controls.Add(this.listView1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "StatisticsDialog";
			this.Controls.SetChildIndex(this.listView1, 0);
			this.Controls.SetChildIndex(this.authorityComboBox1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


	}
}
