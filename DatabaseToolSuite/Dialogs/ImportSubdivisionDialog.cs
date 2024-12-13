using DatabaseToolSuite.Repositoryes._1C;
using DatabaseToolSuite.Services;
using System;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes._1C.SubdivisionCollection;

namespace DatabaseToolSuite.Dialogs
{
	internal class ImportSubdivisionDialog : DialogBase
	{
		public long ParentVersion { get; private set; }

		public SubdivisionCollection SelectSubdivisions { get; }

		public DateTime BeginDate
		{
			get { return beginDateTimePicker.Value.Date; }
		}

		private System.Windows.Forms.Label parent_label;
		private System.Windows.Forms.TextBox parent_textBox;
		private System.Windows.Forms.Button button_SelectParent;
		private System.Windows.Forms.Button button_CheckAll;
		private System.Windows.Forms.Button button_UncheckAll;
		private Button button_Inverse;
		protected Label beginDateLabel;
		protected DateTimePicker beginDateTimePicker;
		private System.Windows.Forms.TreeView subdivisions_treeView;

		public ImportSubdivisionDialog() : base()
		{
			SelectSubdivisions = new SubdivisionCollection();
			ParentVersion = -1;

			InitializeComponent();

			Text = "Импорт данных";
			DialogCaption = "Импорт данных из файла Кадры 1С";
			DialogCaptionImage = Properties.Resources._1C_Yellow32;
			ApplyButtonVisible = false;
			CancelButtonVisible = true;

			button_OK.Enabled = false;

			beginDateTimePicker.MinDate = MasterDataSystem.MIN_DATE;
			beginDateTimePicker.MaxDate = MasterDataSystem.MAX_DATE;
			beginDateTimePicker.Value = DateTime.Today;

			subdivisions_treeView.Nodes.Clear();
			foreach (Subdivision root in FileSystem.Repository.Subdivisions.Roots)
			{
				TreeNode node = subdivisions_treeView.Nodes.Add(root.Name);
				node.Tag = root;
				AddChildTreeNode(node);
			}
			Refresh();
		}


		private void DialogParametersChanged()
		{
			button_OK.Enabled = ParentVersion >= 0 && SelectSubdivisions.Count > 0;
		}

		private void AddChildTreeNode(TreeNode node)
		{
			Subdivision subdivision = node.Tag as Subdivision;
			foreach (Subdivision child in subdivision.Child)
			{
				TreeNode treeNode = node.Nodes.Add(child.Name);
				treeNode.Tag = child;
				AddChildTreeNode(treeNode);
			}
		}

		private void InitializeComponent()
		{
			this.subdivisions_treeView = new System.Windows.Forms.TreeView();
			this.parent_label = new System.Windows.Forms.Label();
			this.parent_textBox = new System.Windows.Forms.TextBox();
			this.button_SelectParent = new System.Windows.Forms.Button();
			this.button_CheckAll = new System.Windows.Forms.Button();
			this.button_UncheckAll = new System.Windows.Forms.Button();
			this.button_Inverse = new System.Windows.Forms.Button();
			this.beginDateLabel = new System.Windows.Forms.Label();
			this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(784, 573);
			this.button_Cancel.Margin = new System.Windows.Forms.Padding(6);
			// 
			// button_OK
			// 
			this.button_OK.Location = new System.Drawing.Point(622, 573);
			this.button_OK.Margin = new System.Windows.Forms.Padding(6);
			// 
			// subdivisions_treeView
			// 
			this.subdivisions_treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.subdivisions_treeView.CheckBoxes = true;
			this.subdivisions_treeView.Location = new System.Drawing.Point(10, 226);
			this.subdivisions_treeView.Name = "subdivisions_treeView";
			this.subdivisions_treeView.Size = new System.Drawing.Size(568, 280);
			this.subdivisions_treeView.TabIndex = 3;
			this.subdivisions_treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterCheck);
			// 
			// parent_label
			// 
			this.parent_label.AutoSize = true;
			this.parent_label.Location = new System.Drawing.Point(21, 132);
			this.parent_label.Name = "parent_label";
			this.parent_label.Size = new System.Drawing.Size(116, 25);
			this.parent_label.TabIndex = 4;
			this.parent_label.Text = "Владелец:";
			// 
			// parent_textBox
			// 
			this.parent_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.parent_textBox.Location = new System.Drawing.Point(143, 132);
			this.parent_textBox.Multiline = true;
			this.parent_textBox.Name = "parent_textBox";
			this.parent_textBox.ReadOnly = true;
			this.parent_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.parent_textBox.Size = new System.Drawing.Size(435, 77);
			this.parent_textBox.TabIndex = 5;
			// 
			// button_SelectParent
			// 
			this.button_SelectParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_SelectParent.Location = new System.Drawing.Point(598, 132);
			this.button_SelectParent.Name = "button_SelectParent";
			this.button_SelectParent.Size = new System.Drawing.Size(261, 38);
			this.button_SelectParent.TabIndex = 6;
			this.button_SelectParent.Text = "Выбрать...";
			this.button_SelectParent.UseVisualStyleBackColor = true;
			this.button_SelectParent.Click += new System.EventHandler(this.SelectParent_Click);
			// 
			// button_CheckAll
			// 
			this.button_CheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_CheckAll.Location = new System.Drawing.Point(598, 226);
			this.button_CheckAll.Name = "button_CheckAll";
			this.button_CheckAll.Size = new System.Drawing.Size(261, 38);
			this.button_CheckAll.TabIndex = 7;
			this.button_CheckAll.Text = "Отметить всё";
			this.button_CheckAll.UseVisualStyleBackColor = true;
			this.button_CheckAll.Click += new System.EventHandler(this.CheckAll_Click);
			// 
			// button_UncheckAll
			// 
			this.button_UncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_UncheckAll.Location = new System.Drawing.Point(598, 270);
			this.button_UncheckAll.Name = "button_UncheckAll";
			this.button_UncheckAll.Size = new System.Drawing.Size(261, 38);
			this.button_UncheckAll.TabIndex = 8;
			this.button_UncheckAll.Text = "Снять отметки";
			this.button_UncheckAll.UseVisualStyleBackColor = true;
			this.button_UncheckAll.Click += new System.EventHandler(this.UncheckAll_Click);
			// 
			// button_Inverse
			// 
			this.button_Inverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Inverse.Location = new System.Drawing.Point(598, 468);
			this.button_Inverse.Name = "button_Inverse";
			this.button_Inverse.Size = new System.Drawing.Size(261, 38);
			this.button_Inverse.TabIndex = 9;
			this.button_Inverse.Text = "Инвертировать отметки";
			this.button_Inverse.UseVisualStyleBackColor = true;
			this.button_Inverse.Click += new System.EventHandler(this.Inverse_Click);
			// 
			// beginDateLabel
			// 
			this.beginDateLabel.AutoSize = true;
			this.beginDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateLabel.Location = new System.Drawing.Point(21, 95);
			this.beginDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.beginDateLabel.Name = "beginDateLabel";
			this.beginDateLabel.Size = new System.Drawing.Size(287, 25);
			this.beginDateLabel.TabIndex = 38;
			this.beginDateLabel.Text = "Дата введения новой версии:";
			// 
			// beginDateTimePicker
			// 
			this.beginDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateTimePicker.Location = new System.Drawing.Point(316, 95);
			this.beginDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
			this.beginDateTimePicker.Name = "beginDateTimePicker";
			this.beginDateTimePicker.Size = new System.Drawing.Size(214, 30);
			this.beginDateTimePicker.TabIndex = 37;
			// 
			// ImportSubdivisionDialog
			// 
			this.AcceptButton = this.AcceptButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelButton;
			this.ClientSize = new System.Drawing.Size(865, 591);
			this.Controls.Add(this.beginDateLabel);
			this.Controls.Add(this.beginDateTimePicker);
			this.Controls.Add(this.button_Inverse);
			this.Controls.Add(this.button_UncheckAll);
			this.Controls.Add(this.button_CheckAll);
			this.Controls.Add(this.button_SelectParent);
			this.Controls.Add(this.parent_textBox);
			this.Controls.Add(this.parent_label);
			this.Controls.Add(this.subdivisions_treeView);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources._1C_Yellow32;
			this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "ImportSubdivisionDialog";
			this.Padding = new System.Windows.Forms.Padding(18);
			this.ShowIcon = false;
			this.Text = "ImportSubdivisionDialog";
			this.Controls.SetChildIndex(this.button_Cancel, 0);
			this.Controls.SetChildIndex(this.button_OK, 0);
			this.Controls.SetChildIndex(this.subdivisions_treeView, 0);
			this.Controls.SetChildIndex(this.parent_label, 0);
			this.Controls.SetChildIndex(this.parent_textBox, 0);
			this.Controls.SetChildIndex(this.button_SelectParent, 0);
			this.Controls.SetChildIndex(this.button_CheckAll, 0);
			this.Controls.SetChildIndex(this.button_UncheckAll, 0);
			this.Controls.SetChildIndex(this.button_Inverse, 0);
			this.Controls.SetChildIndex(this.beginDateTimePicker, 0);
			this.Controls.SetChildIndex(this.beginDateLabel, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void SelectParent_Click(object sender, EventArgs e)
		{
			SelectOrganizationDialog dialog = new SelectOrganizationDialog(authority: MasterDataSystem.PROSECUTOR_CODE);
			dialog.UnlockShow = true;
			dialog.LockShow = false;
			dialog.ReserveShow = false;
			dialog.LastLockOnlyShow = false;

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				parent_textBox.Text = dialog.DataRow.name + " (код: " + dialog.DataRow.code + ")";
				ParentVersion = dialog.DataRow.version;
			}
			DialogParametersChanged();
		}

		private void CheckAll_Click(object sender, EventArgs e)
		{
			CheckedNodes(SelectSubdivisions, subdivisions_treeView.Nodes, CheckTreeNode);
			DialogParametersChanged();
		}

		private void UncheckAll_Click(object sender, EventArgs e)
		{
			CheckedNodes(SelectSubdivisions, subdivisions_treeView.Nodes, UncheckTreeNode);
			DialogParametersChanged();
		}

		private void Inverse_Click(object sender, EventArgs e)
		{
			CheckedNodes(SelectSubdivisions, subdivisions_treeView.Nodes, InverseCheckTreeNode);
			DialogParametersChanged();
		}

		private void TreeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Checked)
			{
				SelectSubdivisions.Add(e.Node.Tag as Subdivision);
				CheckedNodes(SelectSubdivisions, e.Node.Nodes, CheckTreeNode);
			}
			else
			{
				SelectSubdivisions.Remove(e.Node.Tag as Subdivision);
				CheckedNodes(SelectSubdivisions, e.Node.Nodes, UncheckTreeNode);
			}
			DialogParametersChanged();
		}

		delegate void CheckedCallback(SubdivisionCollection subdivisions, TreeNode node);

		public static void CheckTreeNode(SubdivisionCollection subdivisions, TreeNode node)
		{
			node.Checked = true;
			subdivisions.Add(node.Tag as Subdivision);
		}

		public static void UncheckTreeNode(SubdivisionCollection subdivisions, TreeNode node)
		{
			node.Checked = false;
			subdivisions.Remove(node.Tag as Subdivision);
		}

		public static void InverseCheckTreeNode(SubdivisionCollection subdivisions, TreeNode node)
		{
			node.Checked = !node.Checked;
			if (node.Checked)
			{
				subdivisions.Add(node.Tag as Subdivision);
			}
			else
			{
				subdivisions.Remove(node.Tag as Subdivision);
			}
		}

		private void CheckedNodes(SubdivisionCollection subdivisions, TreeNodeCollection nodes, CheckedCallback callback)
		{
			foreach (TreeNode node in nodes)
			{
				callback(subdivisions, node);
				CheckChild(subdivisions, node, callback);
			}
		}

		private void CheckChild(SubdivisionCollection subdivisions, TreeNode rootNode, CheckedCallback callback)
		{
			foreach (TreeNode node in rootNode.Nodes)
			{
				callback(subdivisions, node);
				CheckChild(subdivisions, node, callback);
			}
		}
	}
}
