namespace DatabaseToolSuite.Controls
{
    partial class GaspsListView
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GaspsListView));
            this.baseListView = new System.Windows.Forms.ListView();
            this.codeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.authorityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okatoColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.beginColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.organizationImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // baseListView
            // 
            this.baseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeColumn,
            this.nameColumn,
            this.authorityColumn,
            this.okatoColumn,
            this.beginColumn,
            this.endColumn});
            this.baseListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseListView.FullRowSelect = true;
            this.baseListView.GridLines = true;
            this.baseListView.LargeImageList = this.organizationImageList;
            this.baseListView.Location = new System.Drawing.Point(0, 0);
            this.baseListView.Margin = new System.Windows.Forms.Padding(4);
            this.baseListView.MultiSelect = false;
            this.baseListView.Name = "baseListView";
            this.baseListView.Size = new System.Drawing.Size(863, 185);
            this.baseListView.SmallImageList = this.organizationImageList;
            this.baseListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.baseListView.TabIndex = 0;
            this.baseListView.UseCompatibleStateImageBehavior = false;
            this.baseListView.View = System.Windows.Forms.View.Details;
            this.baseListView.VirtualMode = true;
            this.baseListView.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.ListView_CacheVirtualItems);
            this.baseListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_ColumnClick);
            this.baseListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListView_RetrieveVirtualItem);
            this.baseListView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            this.baseListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
            this.baseListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseDoubleClick);
            // 
            // codeColumn
            // 
            this.codeColumn.Text = "Код";
            this.codeColumn.Width = 80;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Наименование";
            this.nameColumn.Width = 400;
            // 
            // authorityColumn
            // 
            this.authorityColumn.Text = "Ведомство";
            this.authorityColumn.Width = 120;
            // 
            // okatoColumn
            // 
            this.okatoColumn.Text = "ОКАТО";
            this.okatoColumn.Width = 200;
            // 
            // beginColumn
            // 
            this.beginColumn.Text = "Начало действия";
            this.beginColumn.Width = 80;
            // 
            // endColumn
            // 
            this.endColumn.Text = "Окончание действия";
            this.endColumn.Width = 80;
            // 
            // organizationImageList
            // 
            this.organizationImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("organizationImageList.ImageStream")));
            this.organizationImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.organizationImageList.Images.SetKeyName(0, "unlock");
            this.organizationImageList.Images.SetKeyName(1, "lock");
            this.organizationImageList.Images.SetKeyName(2, "reserve");
            // 
            // GaspsListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseListView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GaspsListView";
            this.Size = new System.Drawing.Size(863, 185);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView baseListView;
        private System.Windows.Forms.ImageList organizationImageList;
        private System.Windows.Forms.ColumnHeader codeColumn;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader authorityColumn;
        private System.Windows.Forms.ColumnHeader okatoColumn;
        private System.Windows.Forms.ColumnHeader beginColumn;
        private System.Windows.Forms.ColumnHeader endColumn;
    }
}
