namespace DatabaseToolSuite.Dialogs
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditSelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditFindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabaseAddOkato = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolBar = new System.Windows.Forms.ToolStrip();
            this.btnDatabaseAddOkato = new System.Windows.Forms.ToolStripButton();
            this.btnCheckLinkFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.mainStatusBar = new System.Windows.Forms.StatusStrip();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.databaseTreeView = new System.Windows.Forms.TreeView();
            this.mainImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolsToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.okatoToolStripComboBox1 = new DatabaseToolSuite.Controls.OkatoToolStripComboBox(this.components);
            this.authorityToolStripComboBox1 = new DatabaseToolSuite.Controls.AuthorityToolStripComboBox(this.components);
            this.unlockCodeStripCheckBox = new DatabaseToolSuite.Controls.ToolStripCheckBox();
            this.okatoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryDataSet = new DatabaseToolSuite.Repositoryes.RepositoryDataSet();
            this.mainMenuBar.SuspendLayout();
            this.mainToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.toolsToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.okatoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuDatabase,
            this.mnuTools,
            this.mnuHelp});
            this.mainMenuBar.Location = new System.Drawing.Point(0, 0);
            this.mainMenuBar.Name = "mainMenuBar";
            this.mainMenuBar.Size = new System.Drawing.Size(1242, 28);
            this.mainMenuBar.TabIndex = 0;
            this.mainMenuBar.Text = "Основная";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.toolStripMenuItem3,
            this.mnuFileImport,
            this.mnuFileExport,
            this.toolStripMenuItem4,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(57, 24);
            this.mnuFile.Text = "&Файл";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(205, 26);
            this.mnuFileNew.Text = "Создать";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Image = global::DatabaseToolSuite.Properties.Resources.openHS;
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(205, 26);
            this.mnuFileOpen.Text = "Открыть...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Image = global::DatabaseToolSuite.Properties.Resources.saveHS;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.Size = new System.Drawing.Size(205, 26);
            this.mnuFileSave.Text = "Сохранить";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(205, 26);
            this.mnuFileSaveAs.Text = "Сохранить как...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(202, 6);
            // 
            // mnuFileImport
            // 
            this.mnuFileImport.Name = "mnuFileImport";
            this.mnuFileImport.Size = new System.Drawing.Size(205, 26);
            this.mnuFileImport.Text = "Импорт данных...";
            this.mnuFileImport.Click += new System.EventHandler(this.mnuFileImport_Click);
            // 
            // mnuFileExport
            // 
            this.mnuFileExport.Name = "mnuFileExport";
            this.mnuFileExport.Size = new System.Drawing.Size(205, 26);
            this.mnuFileExport.Text = "Экспорт данных...";
            this.mnuFileExport.Click += new System.EventHandler(this.mnuFileExport_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(202, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(205, 26);
            this.mnuFileExit.Text = "Выход";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCutToolStripMenuItem,
            this.mnuEditCopyToolStripMenuItem,
            this.mnuEditPastToolStripMenuItem,
            this.mnuEditDeleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mnuEditSelectAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.mnuEditFindToolStripMenuItem});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(72, 24);
            this.mnuEdit.Text = "&Правка";
            // 
            // mnuEditCutToolStripMenuItem
            // 
            this.mnuEditCutToolStripMenuItem.Image = global::DatabaseToolSuite.Properties.Resources.CutHS;
            this.mnuEditCutToolStripMenuItem.Name = "mnuEditCutToolStripMenuItem";
            this.mnuEditCutToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.mnuEditCutToolStripMenuItem.Text = "Вырезать";
            // 
            // mnuEditCopyToolStripMenuItem
            // 
            this.mnuEditCopyToolStripMenuItem.Image = global::DatabaseToolSuite.Properties.Resources.CopyHS;
            this.mnuEditCopyToolStripMenuItem.Name = "mnuEditCopyToolStripMenuItem";
            this.mnuEditCopyToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.mnuEditCopyToolStripMenuItem.Text = "Копировать";
            // 
            // mnuEditPastToolStripMenuItem
            // 
            this.mnuEditPastToolStripMenuItem.Image = global::DatabaseToolSuite.Properties.Resources.PasteHS;
            this.mnuEditPastToolStripMenuItem.Name = "mnuEditPastToolStripMenuItem";
            this.mnuEditPastToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.mnuEditPastToolStripMenuItem.Text = "Вставить";
            // 
            // mnuEditDeleteToolStripMenuItem
            // 
            this.mnuEditDeleteToolStripMenuItem.Image = global::DatabaseToolSuite.Properties.Resources.DeleteRedHS;
            this.mnuEditDeleteToolStripMenuItem.Name = "mnuEditDeleteToolStripMenuItem";
            this.mnuEditDeleteToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.mnuEditDeleteToolStripMenuItem.Text = "Удалить";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuEditSelectAllToolStripMenuItem
            // 
            this.mnuEditSelectAllToolStripMenuItem.Name = "mnuEditSelectAllToolStripMenuItem";
            this.mnuEditSelectAllToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.mnuEditSelectAllToolStripMenuItem.Text = "Выделить все";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuEditFindToolStripMenuItem
            // 
            this.mnuEditFindToolStripMenuItem.Name = "mnuEditFindToolStripMenuItem";
            this.mnuEditFindToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.mnuEditFindToolStripMenuItem.Text = "Найти...";
            // 
            // mnuView
            // 
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(47, 24);
            this.mnuView.Text = "&Вид";
            // 
            // mnuDatabase
            // 
            this.mnuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatabaseAddOkato});
            this.mnuDatabase.Name = "mnuDatabase";
            this.mnuDatabase.Size = new System.Drawing.Size(109, 24);
            this.mnuDatabase.Text = "База &данных";
            // 
            // mnuDatabaseAddOkato
            // 
            this.mnuDatabaseAddOkato.Image = global::DatabaseToolSuite.Properties.Resources.AddHomeHS;
            this.mnuDatabaseAddOkato.Name = "mnuDatabaseAddOkato";
            this.mnuDatabaseAddOkato.Size = new System.Drawing.Size(241, 26);
            this.mnuDatabaseAddOkato.Text = "Добавить код ОКАТО...";
            this.mnuDatabaseAddOkato.Click += new System.EventHandler(this.mnuDatabaseAddOkato_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(71, 24);
            this.mnuTools.Text = "С&ервис";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(79, 24);
            this.mnuHelp.Text = "Справ&ка";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Image = global::DatabaseToolSuite.Properties.Resources.Home16;
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(188, 26);
            this.mnuHelpAbout.Text = "&О программе...";
            // 
            // mainToolBar
            // 
            this.mainToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDatabaseAddOkato,
            this.btnCheckLinkFile,
            this.toolStripButton1});
            this.mainToolBar.Location = new System.Drawing.Point(0, 28);
            this.mainToolBar.Name = "mainToolBar";
            this.mainToolBar.Size = new System.Drawing.Size(1242, 27);
            this.mainToolBar.TabIndex = 1;
            this.mainToolBar.Text = "Стандартная";
            this.mainToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainToolBar_ItemClicked);
            // 
            // btnDatabaseAddOkato
            // 
            this.btnDatabaseAddOkato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDatabaseAddOkato.Image = global::DatabaseToolSuite.Properties.Resources.AddHomeHS;
            this.btnDatabaseAddOkato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatabaseAddOkato.Name = "btnDatabaseAddOkato";
            this.btnDatabaseAddOkato.Size = new System.Drawing.Size(24, 24);
            this.btnDatabaseAddOkato.Text = "Добавить код ОКАО";
            this.btnDatabaseAddOkato.Click += new System.EventHandler(this.mnuDatabaseAddOkato_Click);
            // 
            // btnCheckLinkFile
            // 
            this.btnCheckLinkFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCheckLinkFile.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckLinkFile.Image")));
            this.btnCheckLinkFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheckLinkFile.Name = "btnCheckLinkFile";
            this.btnCheckLinkFile.Size = new System.Drawing.Size(24, 24);
            this.btnCheckLinkFile.Text = "Сравнение";
            this.btnCheckLinkFile.Click += new System.EventHandler(this.btnCheckLinkFile_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // mainStatusBar
            // 
            this.mainStatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainStatusBar.Location = new System.Drawing.Point(0, 433);
            this.mainStatusBar.Name = "mainStatusBar";
            this.mainStatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.mainStatusBar.Size = new System.Drawing.Size(1242, 22);
            this.mainStatusBar.TabIndex = 2;
            this.mainStatusBar.Text = "statusStrip1";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 55);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.databaseTreeView);
            this.mainSplitContainer.Panel1.Controls.Add(this.toolsToolBar);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.mainDataGridView);
            this.mainSplitContainer.Panel2.Controls.Add(this.toolStrip1);
            this.mainSplitContainer.Size = new System.Drawing.Size(1242, 378);
            this.mainSplitContainer.SplitterDistance = 211;
            this.mainSplitContainer.SplitterWidth = 5;
            this.mainSplitContainer.TabIndex = 3;
            // 
            // databaseTreeView
            // 
            this.databaseTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseTreeView.ImageIndex = 0;
            this.databaseTreeView.ImageList = this.mainImageList;
            this.databaseTreeView.Location = new System.Drawing.Point(0, 27);
            this.databaseTreeView.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.databaseTreeView.Name = "databaseTreeView";
            this.databaseTreeView.SelectedImageIndex = 0;
            this.databaseTreeView.Size = new System.Drawing.Size(211, 351);
            this.databaseTreeView.TabIndex = 1;
            this.databaseTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.databaseTreeView_AfterSelect);
            // 
            // mainImageList
            // 
            this.mainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList.ImageStream")));
            this.mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList.Images.SetKeyName(0, "DataBaseHS.png");
            this.mainImageList.Images.SetKeyName(1, "TableHS.png");
            this.mainImageList.Images.SetKeyName(2, "TableBlueHS.png");
            // 
            // toolsToolBar
            // 
            this.toolsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolsToolBar.Location = new System.Drawing.Point(0, 0);
            this.toolsToolBar.Name = "toolsToolBar";
            this.toolsToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolsToolBar.Size = new System.Drawing.Size(211, 27);
            this.toolsToolBar.TabIndex = 0;
            this.toolsToolBar.Text = "Дополнительная";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::DatabaseToolSuite.Properties.Resources.openHS;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDataGridView.Location = new System.Drawing.Point(0, 31);
            this.mainDataGridView.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowTemplate.Height = 28;
            this.mainDataGridView.Size = new System.Drawing.Size(1026, 347);
            this.mainDataGridView.TabIndex = 0;
            this.mainDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGridView_CellContentClick);
            this.mainDataGridView.DoubleClick += new System.EventHandler(this.mainDataGridView_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.okatoToolStripComboBox1,
            this.authorityToolStripComboBox1,
            this.unlockCodeStripCheckBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1026, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // okatoToolStripComboBox1
            // 
            this.okatoToolStripComboBox1.AutoSize = false;
            this.okatoToolStripComboBox1.Code = "";
            this.okatoToolStripComboBox1.DropDownHeight = 204;
            this.okatoToolStripComboBox1.DropDownWidth = 80;
            this.okatoToolStripComboBox1.IntegralHeight = false;
            this.okatoToolStripComboBox1.MaxDropDownItems = 20;
            this.okatoToolStripComboBox1.Name = "okatoToolStripComboBox1";
            this.okatoToolStripComboBox1.Size = new System.Drawing.Size(400, 31);
            // 
            // authorityToolStripComboBox1
            // 
            this.authorityToolStripComboBox1.AutoSize = false;
            this.authorityToolStripComboBox1.Code = "";
            this.authorityToolStripComboBox1.DropDownHeight = 204;
            this.authorityToolStripComboBox1.DropDownWidth = 80;
            this.authorityToolStripComboBox1.IntegralHeight = false;
            this.authorityToolStripComboBox1.MaxDropDownItems = 20;
            this.authorityToolStripComboBox1.Name = "authorityToolStripComboBox1";
            this.authorityToolStripComboBox1.Size = new System.Drawing.Size(200, 31);
            // 
            // unlockCodeStripCheckBox
            // 
            this.unlockCodeStripCheckBox.Checked = false;
            this.unlockCodeStripCheckBox.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.unlockCodeStripCheckBox.Name = "unlockCodeStripCheckBox";
            this.unlockCodeStripCheckBox.Size = new System.Drawing.Size(178, 28);
            this.unlockCodeStripCheckBox.Text = "Только действующие";
            // 
            // okatoBindingSource
            // 
            this.okatoBindingSource.DataMember = "okato";
            this.okatoBindingSource.DataSource = this.repositoryDataSet;
            // 
            // repositoryDataSet
            // 
            this.repositoryDataSet.DataSetName = "RepositoryDataSet";
            this.repositoryDataSet.Locale = new System.Globalization.CultureInfo("ru");
            this.repositoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 455);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainStatusBar);
            this.Controls.Add(this.mainToolBar);
            this.Controls.Add(this.mainMenuBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuBar;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenuBar.ResumeLayout(false);
            this.mainMenuBar.PerformLayout();
            this.mainToolBar.ResumeLayout(false);
            this.mainToolBar.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.toolsToolBar.ResumeLayout(false);
            this.toolsToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.okatoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStrip mainToolBar;
        private System.Windows.Forms.ToolStripButton btnDatabaseAddOkato;
        private System.Windows.Forms.StatusStrip mainStatusBar;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ToolStrip toolsToolBar;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditSelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuEditFindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripButton btnCheckLinkFile;
        private System.Windows.Forms.TreeView databaseTreeView;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuFileImport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ImageList mainImageList;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabaseAddOkato;
        private System.Windows.Forms.BindingSource okatoBindingSource;
        private Repositoryes.RepositoryDataSet repositoryDataSet;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.OkatoToolStripComboBox okatoToolStripComboBox1;
        private Controls.AuthorityToolStripComboBox authorityToolStripComboBox1;
        private Controls.ToolStripCheckBox unlockCodeStripCheckBox;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}