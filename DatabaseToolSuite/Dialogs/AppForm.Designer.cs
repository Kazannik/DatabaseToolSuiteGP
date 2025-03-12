namespace DatabaseToolSuite.Dialogs
{
    partial class AppForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileImport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileExport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileExportForGasps = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileGaspsExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileFgisEsnsiExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileErvkExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileFullExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileStatisticsExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTable = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableNewOrganization = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableCreateOrganization = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableCreateNewVersion = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableRemoveOrganization = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableEditError = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableFgisEsnsiEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableFgisEsnsiCloneToLast = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableFgisEsnsiRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableErvkEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableErvkCloneToLast = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableErvkRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableUrpEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableUrpCloneToLast = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTableUrpRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsImportFgisEsnsi = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsImportSubdivision = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuToolsClearCode = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuToolsServise = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsCreateNewVersion = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsEditError = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsFillLogEditDateGasps = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsFillLogEditDateFgisEsnsi = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsFillLogEditDateErvk = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuToolsInitializeRtkTables = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsFillRtkUrpTable = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsExpLawAgenceEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsTableEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelpStatistic = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.rowCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.selectedRowStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.filterPanel = new System.Windows.Forms.Panel();
			this.filterGroupBox = new System.Windows.Forms.GroupBox();
			this.filterErvkOnlyRadioButton = new System.Windows.Forms.RadioButton();
			this.filterFgisEsnsiOnlyRadioButton = new System.Windows.Forms.RadioButton();
			this.filterAllRadioButton = new System.Windows.Forms.RadioButton();
			this.cleanFilterButton = new System.Windows.Forms.Button();
			this.filterCodeNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.filterNameTextBox = new System.Windows.Forms.TextBox();
			this.filterLockCodeViewCheckBox = new System.Windows.Forms.CheckBox();
			this.okatoLabel = new System.Windows.Forms.Label();
			this.filterAuthorityComboBox = new DatabaseToolSuite.Controls.AuthorityComboBox();
			this.filterOkatoComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
			this.authorityLabel = new System.Windows.Forms.Label();
			this.contextMenuTable = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuContextNewOrganization = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuContextCreateOrganization = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContextCreateNewVersion = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContextRemoveOrganization = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContextEditError = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContextFgisEsnsiEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuContextFgisEsnsiCloneToLast = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContextErvkEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuContextErvkCloneToLast = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContextUrpEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuContextUrpCloneToLast = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContextUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this.mainToolStripBar = new System.Windows.Forms.ToolStrip();
			this.fileSaveButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tableNewOrganizationButton = new System.Windows.Forms.ToolStripButton();
			this.tableCreateOrganizationButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tableCreateNewVersionButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tableRemoveOrganizationButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableFgisEsnsiEditButton = new System.Windows.Forms.ToolStripButton();
			this.mnuTableFgisEsnsiCloneToLastButton = new System.Windows.Forms.ToolStripButton();
			this.mnuTableFgisEsnsiRemoveButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableErvkEditButton = new System.Windows.Forms.ToolStripButton();
			this.mnuTableErvkCloneToLastButton = new System.Windows.Forms.ToolStripButton();
			this.mnuTableErvkRemoveButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableUrpEditButton = new System.Windows.Forms.ToolStripButton();
			this.mnuTableUrpCloneToLastButton = new System.Windows.Forms.ToolStripButton();
			this.mnuTableUrpRemoveButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTableRefreshButton = new System.Windows.Forms.ToolStripButton();
			this.additionalToolStripBar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton21 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton22 = new System.Windows.Forms.ToolStripButton();
			this.gaspsListView = new DatabaseToolSuite.Controls.GaspsListView();
			this.mnuFileExportDelta = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuStrip.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.filterPanel.SuspendLayout();
			this.filterGroupBox.SuspendLayout();
			this.contextMenuTable.SuspendLayout();
			this.mainToolStripBar.SuspendLayout();
			this.additionalToolStripBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTable,
            this.mnuTools,
            this.mnuHelp});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
			this.mainMenuStrip.Size = new System.Drawing.Size(1228, 38);
			this.mainMenuStrip.TabIndex = 0;
			this.mainMenuStrip.Text = "Основное";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileImport,
            this.mnuFileExport,
            this.mnuFileExportForGasps,
            this.toolStripMenuItem2,
            this.mnuFileExportToExcel,
            this.toolStripMenuItem6,
            this.mnuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(78, 34);
			this.mnuFile.Text = "Файл";
			// 
			// mnuFileNew
			// 
			this.mnuFileNew.Name = "mnuFileNew";
			this.mnuFileNew.Size = new System.Drawing.Size(402, 38);
			this.mnuFileNew.Text = "mnuFileNew";
			this.mnuFileNew.Visible = false;
			// 
			// mnuFileOpen
			// 
			this.mnuFileOpen.Image = global::DatabaseToolSuite.Properties.Resources.Open24;
			this.mnuFileOpen.Name = "mnuFileOpen";
			this.mnuFileOpen.Size = new System.Drawing.Size(402, 38);
			this.mnuFileOpen.Text = "Открыть...";
			this.mnuFileOpen.Click += new System.EventHandler(this.FileOpenToolStripMenuItem_Click);
			// 
			// mnuFileSave
			// 
			this.mnuFileSave.Image = global::DatabaseToolSuite.Properties.Resources.Save24;
			this.mnuFileSave.Name = "mnuFileSave";
			this.mnuFileSave.Size = new System.Drawing.Size(402, 38);
			this.mnuFileSave.Text = "Сохранить";
			this.mnuFileSave.Click += new System.EventHandler(this.FileSaveToolStripMenuItem_Click);
			// 
			// mnuFileSaveAs
			// 
			this.mnuFileSaveAs.Image = global::DatabaseToolSuite.Properties.Resources.SaveAs24;
			this.mnuFileSaveAs.Name = "mnuFileSaveAs";
			this.mnuFileSaveAs.Size = new System.Drawing.Size(402, 38);
			this.mnuFileSaveAs.Text = "Сохранить как...";
			this.mnuFileSaveAs.Click += new System.EventHandler(this.FileSaveAsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(399, 6);
			// 
			// mnuFileImport
			// 
			this.mnuFileImport.Image = global::DatabaseToolSuite.Properties.Resources.ImportTextFile24;
			this.mnuFileImport.Name = "mnuFileImport";
			this.mnuFileImport.Size = new System.Drawing.Size(402, 38);
			this.mnuFileImport.Text = "Импорт из файла...";
			this.mnuFileImport.Click += new System.EventHandler(this.FileImport_Click);
			// 
			// mnuFileExport
			// 
			this.mnuFileExport.Image = global::DatabaseToolSuite.Properties.Resources.ExportXmlFile24;
			this.mnuFileExport.Name = "mnuFileExport";
			this.mnuFileExport.Size = new System.Drawing.Size(402, 38);
			this.mnuFileExport.Text = "Экспорт данных в файл...";
			this.mnuFileExport.Click += new System.EventHandler(this.FileExport_Click);
			// 
			// mnuFileExportForGasps
			// 
			this.mnuFileExportForGasps.Image = global::DatabaseToolSuite.Properties.Resources.ExportXmlGaspsFile24;
			this.mnuFileExportForGasps.Name = "mnuFileExportForGasps";
			this.mnuFileExportForGasps.Size = new System.Drawing.Size(402, 38);
			this.mnuFileExportForGasps.Text = "Экспорт данных для ГАС ПС...";
			this.mnuFileExportForGasps.Click += new System.EventHandler(this.FileExportForGasps_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(399, 6);
			// 
			// mnuFileExportToExcel
			// 
			this.mnuFileExportToExcel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileGaspsExportToExcel,
            this.mnuFileFgisEsnsiExportToExcel,
            this.mnuFileErvkExportToExcel,
            this.toolStripMenuItem17,
            this.mnuFileFullExportToExcel,
            this.toolStripMenuItem18,
            this.mnuFileStatisticsExportToExcel,
            this.mnuFileExportDelta});
			this.mnuFileExportToExcel.Image = global::DatabaseToolSuite.Properties.Resources.ExportExcel24;
			this.mnuFileExportToExcel.Name = "mnuFileExportToExcel";
			this.mnuFileExportToExcel.Size = new System.Drawing.Size(402, 38);
			this.mnuFileExportToExcel.Text = "Экспорт в MS Office Excel";
			// 
			// mnuFileGaspsExportToExcel
			// 
			this.mnuFileGaspsExportToExcel.Name = "mnuFileGaspsExportToExcel";
			this.mnuFileGaspsExportToExcel.Size = new System.Drawing.Size(340, 38);
			this.mnuFileGaspsExportToExcel.Text = "Данных ГАС ПС...";
			this.mnuFileGaspsExportToExcel.Click += new System.EventHandler(this.FileExportGaspsToExcel_Click);
			// 
			// mnuFileFgisEsnsiExportToExcel
			// 
			this.mnuFileFgisEsnsiExportToExcel.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi24;
			this.mnuFileFgisEsnsiExportToExcel.Name = "mnuFileFgisEsnsiExportToExcel";
			this.mnuFileFgisEsnsiExportToExcel.Size = new System.Drawing.Size(340, 38);
			this.mnuFileFgisEsnsiExportToExcel.Text = "Данных ФГИС ЕСНСИ...";
			this.mnuFileFgisEsnsiExportToExcel.Click += new System.EventHandler(this.FileFgisEsnsiExportToExcel_Click);
			// 
			// mnuFileErvkExportToExcel
			// 
			this.mnuFileErvkExportToExcel.Image = global::DatabaseToolSuite.Properties.Resources.economy24;
			this.mnuFileErvkExportToExcel.Name = "mnuFileErvkExportToExcel";
			this.mnuFileErvkExportToExcel.Size = new System.Drawing.Size(340, 38);
			this.mnuFileErvkExportToExcel.Text = "Данных ЕРВК...";
			this.mnuFileErvkExportToExcel.Click += new System.EventHandler(this.FileErvkExportToExcel_Click);
			// 
			// toolStripMenuItem17
			// 
			this.toolStripMenuItem17.Name = "toolStripMenuItem17";
			this.toolStripMenuItem17.Size = new System.Drawing.Size(337, 6);
			// 
			// mnuFileFullExportToExcel
			// 
			this.mnuFileFullExportToExcel.Image = global::DatabaseToolSuite.Properties.Resources.Windows32;
			this.mnuFileFullExportToExcel.Name = "mnuFileFullExportToExcel";
			this.mnuFileFullExportToExcel.Size = new System.Drawing.Size(340, 38);
			this.mnuFileFullExportToExcel.Text = "Всего справочника...";
			this.mnuFileFullExportToExcel.Click += new System.EventHandler(this.FileFullExportToExcel_Click);
			// 
			// toolStripMenuItem18
			// 
			this.toolStripMenuItem18.Name = "toolStripMenuItem18";
			this.toolStripMenuItem18.Size = new System.Drawing.Size(337, 6);
			// 
			// mnuFileStatisticsExportToExcel
			// 
			this.mnuFileStatisticsExportToExcel.Image = global::DatabaseToolSuite.Properties.Resources.Statistics24;
			this.mnuFileStatisticsExportToExcel.Name = "mnuFileStatisticsExportToExcel";
			this.mnuFileStatisticsExportToExcel.Size = new System.Drawing.Size(340, 38);
			this.mnuFileStatisticsExportToExcel.Text = "Статистики...";
			this.mnuFileStatisticsExportToExcel.Click += new System.EventHandler(this.FileStatisticsExportToExcel_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(399, 6);
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Image = global::DatabaseToolSuite.Properties.Resources.FileExit24;
			this.mnuFileExit.Name = "mnuFileExit";
			this.mnuFileExit.Size = new System.Drawing.Size(402, 38);
			this.mnuFileExit.Text = "Выход";
			this.mnuFileExit.Click += new System.EventHandler(this.FileExit_Click);
			// 
			// mnuTable
			// 
			this.mnuTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTableNewOrganization,
            this.mnuTableCreateOrganization,
            this.toolStripMenuItem3,
            this.mnuTableCreateNewVersion,
            this.toolStripMenuItem4,
            this.mnuTableRemoveOrganization,
            this.toolStripMenuItem7,
            this.mnuTableEditError,
            this.toolStripMenuItem11,
            this.mnuTableFgisEsnsiEdit,
            this.mnuTableFgisEsnsiCloneToLast,
            this.mnuTableFgisEsnsiRemove,
            this.toolStripMenuItem15,
            this.mnuTableErvkEdit,
            this.mnuTableErvkCloneToLast,
            this.mnuTableErvkRemove,
            this.toolStripMenuItem21,
            this.mnuTableUrpEdit,
            this.mnuTableUrpCloneToLast,
            this.mnuTableUrpRemove});
			this.mnuTable.Name = "mnuTable";
			this.mnuTable.Size = new System.Drawing.Size(299, 34);
			this.mnuTable.Text = "Справочник подразделений";
			// 
			// mnuTableNewOrganization
			// 
			this.mnuTableNewOrganization.Image = global::DatabaseToolSuite.Properties.Resources.New24;
			this.mnuTableNewOrganization.Name = "mnuTableNewOrganization";
			this.mnuTableNewOrganization.Size = new System.Drawing.Size(744, 38);
			this.mnuTableNewOrganization.Text = "Создать запись...";
			this.mnuTableNewOrganization.Click += new System.EventHandler(this.NewOrganization_Click);
			// 
			// mnuTableCreateOrganization
			// 
			this.mnuTableCreateOrganization.Image = global::DatabaseToolSuite.Properties.Resources.NewSeries24;
			this.mnuTableCreateOrganization.Name = "mnuTableCreateOrganization";
			this.mnuTableCreateOrganization.Size = new System.Drawing.Size(744, 38);
			this.mnuTableCreateOrganization.Text = "Создать запись на основе текущей...";
			this.mnuTableCreateOrganization.Click += new System.EventHandler(this.CreateOrganization_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(741, 6);
			// 
			// mnuTableCreateNewVersion
			// 
			this.mnuTableCreateNewVersion.Image = global::DatabaseToolSuite.Properties.Resources.Duplicate24;
			this.mnuTableCreateNewVersion.Name = "mnuTableCreateNewVersion";
			this.mnuTableCreateNewVersion.Size = new System.Drawing.Size(744, 38);
			this.mnuTableCreateNewVersion.Text = "Создать новую версию записи...";
			this.mnuTableCreateNewVersion.Click += new System.EventHandler(this.CreateVersion_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(741, 6);
			// 
			// mnuTableRemoveOrganization
			// 
			this.mnuTableRemoveOrganization.Image = global::DatabaseToolSuite.Properties.Resources.Delete24;
			this.mnuTableRemoveOrganization.Name = "mnuTableRemoveOrganization";
			this.mnuTableRemoveOrganization.Size = new System.Drawing.Size(744, 38);
			this.mnuTableRemoveOrganization.Text = "Заблокировать запись...";
			this.mnuTableRemoveOrganization.Click += new System.EventHandler(this.RemoveOrganization_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(741, 6);
			// 
			// mnuTableEditError
			// 
			this.mnuTableEditError.Image = global::DatabaseToolSuite.Properties.Resources.Edit24;
			this.mnuTableEditError.Name = "mnuTableEditError";
			this.mnuTableEditError.Size = new System.Drawing.Size(744, 38);
			this.mnuTableEditError.Text = "Исправить ошибку...";
			this.mnuTableEditError.Click += new System.EventHandler(this.EditError_Click);
			// 
			// toolStripMenuItem11
			// 
			this.toolStripMenuItem11.Name = "toolStripMenuItem11";
			this.toolStripMenuItem11.Size = new System.Drawing.Size(741, 6);
			// 
			// mnuTableFgisEsnsiEdit
			// 
			this.mnuTableFgisEsnsiEdit.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi24;
			this.mnuTableFgisEsnsiEdit.Name = "mnuTableFgisEsnsiEdit";
			this.mnuTableFgisEsnsiEdit.Size = new System.Drawing.Size(744, 38);
			this.mnuTableFgisEsnsiEdit.Text = "Запись ФГИС ЕСНСИ...";
			this.mnuTableFgisEsnsiEdit.Click += new System.EventHandler(this.FgisEsnsiEdit_Click);
			// 
			// mnuTableFgisEsnsiCloneToLast
			// 
			this.mnuTableFgisEsnsiCloneToLast.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi_dublicate24;
			this.mnuTableFgisEsnsiCloneToLast.Name = "mnuTableFgisEsnsiCloneToLast";
			this.mnuTableFgisEsnsiCloneToLast.Size = new System.Drawing.Size(744, 38);
			this.mnuTableFgisEsnsiCloneToLast.Text = "Копировать запись ФГИС ЕСНСИ в действующую версию записи";
			this.mnuTableFgisEsnsiCloneToLast.Click += new System.EventHandler(this.FgisEsnsiCloneToLast_Click);
			// 
			// mnuTableFgisEsnsiRemove
			// 
			this.mnuTableFgisEsnsiRemove.Image = ((System.Drawing.Image)(resources.GetObject("mnuTableFgisEsnsiRemove.Image")));
			this.mnuTableFgisEsnsiRemove.Name = "mnuTableFgisEsnsiRemove";
			this.mnuTableFgisEsnsiRemove.Size = new System.Drawing.Size(744, 38);
			this.mnuTableFgisEsnsiRemove.Text = "Удалить запись ФГИС ЕСНСИ";
			this.mnuTableFgisEsnsiRemove.Click += new System.EventHandler(this.FgisEsnsiRemove_Click);
			// 
			// toolStripMenuItem15
			// 
			this.toolStripMenuItem15.Name = "toolStripMenuItem15";
			this.toolStripMenuItem15.Size = new System.Drawing.Size(741, 6);
			// 
			// mnuTableErvkEdit
			// 
			this.mnuTableErvkEdit.Image = global::DatabaseToolSuite.Properties.Resources.economy24;
			this.mnuTableErvkEdit.Name = "mnuTableErvkEdit";
			this.mnuTableErvkEdit.Size = new System.Drawing.Size(744, 38);
			this.mnuTableErvkEdit.Text = "Запись ЕРВК...";
			this.mnuTableErvkEdit.Click += new System.EventHandler(this.ErvkEdit_Click);
			// 
			// mnuTableErvkCloneToLast
			// 
			this.mnuTableErvkCloneToLast.Image = global::DatabaseToolSuite.Properties.Resources.economy_dublicate24;
			this.mnuTableErvkCloneToLast.Name = "mnuTableErvkCloneToLast";
			this.mnuTableErvkCloneToLast.Size = new System.Drawing.Size(744, 38);
			this.mnuTableErvkCloneToLast.Text = "Копировать запись ЕРВК в действующую версию записи";
			this.mnuTableErvkCloneToLast.Click += new System.EventHandler(this.ErvkCloneToLast_Click);
			// 
			// mnuTableErvkRemove
			// 
			this.mnuTableErvkRemove.Image = ((System.Drawing.Image)(resources.GetObject("mnuTableErvkRemove.Image")));
			this.mnuTableErvkRemove.Name = "mnuTableErvkRemove";
			this.mnuTableErvkRemove.Size = new System.Drawing.Size(744, 38);
			this.mnuTableErvkRemove.Text = "Удалить запись ЕРВК";
			this.mnuTableErvkRemove.Click += new System.EventHandler(this.ErvkRemove_Click);
			// 
			// toolStripMenuItem21
			// 
			this.toolStripMenuItem21.Name = "toolStripMenuItem21";
			this.toolStripMenuItem21.Size = new System.Drawing.Size(741, 6);
			// 
			// mnuTableUrpEdit
			// 
			this.mnuTableUrpEdit.Image = global::DatabaseToolSuite.Properties.Resources.emblem24;
			this.mnuTableUrpEdit.Name = "mnuTableUrpEdit";
			this.mnuTableUrpEdit.Size = new System.Drawing.Size(744, 38);
			this.mnuTableUrpEdit.Text = "Запись УРП ГАС ПС...";
			this.mnuTableUrpEdit.Click += new System.EventHandler(this.UrpEdit_Click);
			// 
			// mnuTableUrpCloneToLast
			// 
			this.mnuTableUrpCloneToLast.Image = global::DatabaseToolSuite.Properties.Resources.emblem_dublicate24;
			this.mnuTableUrpCloneToLast.Name = "mnuTableUrpCloneToLast";
			this.mnuTableUrpCloneToLast.Size = new System.Drawing.Size(744, 38);
			this.mnuTableUrpCloneToLast.Text = "Копировать запись УРП ГАС ПС в действующую версию записи";
			this.mnuTableUrpCloneToLast.Click += new System.EventHandler(this.UrpCloneToLast_Click);
			// 
			// mnuTableUrpRemove
			// 
			this.mnuTableUrpRemove.Image = global::DatabaseToolSuite.Properties.Resources.emblem_remove24;
			this.mnuTableUrpRemove.Name = "mnuTableUrpRemove";
			this.mnuTableUrpRemove.Size = new System.Drawing.Size(744, 38);
			this.mnuTableUrpRemove.Text = "Удалить запись УРП ГАС ПС";
			this.mnuTableUrpRemove.Click += new System.EventHandler(this.UrpRemove_Click);
			// 
			// mnuTools
			// 
			this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsImportFgisEsnsi,
            this.mnuToolsImportSubdivision,
            this.toolStripMenuItem13,
            this.mnuToolsClearCode,
            this.toolStripMenuItem19,
            this.mnuToolsServise,
            this.mnuToolsExpLawAgenceEdit,
            this.mnuToolsTableEdit});
			this.mnuTools.Name = "mnuTools";
			this.mnuTools.Size = new System.Drawing.Size(98, 34);
			this.mnuTools.Text = "Сервис";
			// 
			// mnuToolsImportFgisEsnsi
			// 
			this.mnuToolsImportFgisEsnsi.Name = "mnuToolsImportFgisEsnsi";
			this.mnuToolsImportFgisEsnsi.Size = new System.Drawing.Size(594, 38);
			this.mnuToolsImportFgisEsnsi.Text = "Импорт данных ФГИС ЕСНСИ...";
			this.mnuToolsImportFgisEsnsi.Click += new System.EventHandler(this.ToolsImportFgisEsnsi_Click);
			// 
			// mnuToolsImportSubdivision
			// 
			this.mnuToolsImportSubdivision.Image = global::DatabaseToolSuite.Properties.Resources._1C_Yellow24;
			this.mnuToolsImportSubdivision.Name = "mnuToolsImportSubdivision";
			this.mnuToolsImportSubdivision.Size = new System.Drawing.Size(594, 38);
			this.mnuToolsImportSubdivision.Text = "Импорт данных из файла 1С...";
			this.mnuToolsImportSubdivision.Click += new System.EventHandler(this.ToolsImportSubdivision_Click);
			// 
			// toolStripMenuItem13
			// 
			this.toolStripMenuItem13.Name = "toolStripMenuItem13";
			this.toolStripMenuItem13.Size = new System.Drawing.Size(591, 6);
			// 
			// mnuToolsClearCode
			// 
			this.mnuToolsClearCode.Name = "mnuToolsClearCode";
			this.mnuToolsClearCode.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
			this.mnuToolsClearCode.Size = new System.Drawing.Size(594, 38);
			this.mnuToolsClearCode.Text = "Удалить код подразделения";
			this.mnuToolsClearCode.Click += new System.EventHandler(this.ToolsClearCode_Click);
			// 
			// toolStripMenuItem19
			// 
			this.toolStripMenuItem19.Name = "toolStripMenuItem19";
			this.toolStripMenuItem19.Size = new System.Drawing.Size(591, 6);
			// 
			// mnuToolsServise
			// 
			this.mnuToolsServise.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsCreateNewVersion,
            this.mnuToolsEditError,
            this.mnuToolsFillLogEditDateGasps,
            this.mnuToolsFillLogEditDateFgisEsnsi,
            this.mnuToolsFillLogEditDateErvk,
            this.toolStripMenuItem20,
            this.mnuToolsInitializeRtkTables,
            this.mnuToolsFillRtkUrpTable});
			this.mnuToolsServise.Name = "mnuToolsServise";
			this.mnuToolsServise.Size = new System.Drawing.Size(594, 38);
			this.mnuToolsServise.Text = "Сервисные команды";
			// 
			// mnuToolsCreateNewVersion
			// 
			this.mnuToolsCreateNewVersion.Image = global::DatabaseToolSuite.Properties.Resources.Duplicate24;
			this.mnuToolsCreateNewVersion.Name = "mnuToolsCreateNewVersion";
			this.mnuToolsCreateNewVersion.Size = new System.Drawing.Size(744, 38);
			this.mnuToolsCreateNewVersion.Text = "Аварийное создание новой версии записи...";
			this.mnuToolsCreateNewVersion.Click += new System.EventHandler(this.CreateVersion_Click);
			// 
			// mnuToolsEditError
			// 
			this.mnuToolsEditError.Image = global::DatabaseToolSuite.Properties.Resources.Edit24;
			this.mnuToolsEditError.Name = "mnuToolsEditError";
			this.mnuToolsEditError.Size = new System.Drawing.Size(744, 38);
			this.mnuToolsEditError.Text = "Аварийное исправление ошибки...";
			this.mnuToolsEditError.Click += new System.EventHandler(this.EditError_Click);
			// 
			// mnuToolsFillLogEditDateGasps
			// 
			this.mnuToolsFillLogEditDateGasps.Name = "mnuToolsFillLogEditDateGasps";
			this.mnuToolsFillLogEditDateGasps.Size = new System.Drawing.Size(744, 38);
			this.mnuToolsFillLogEditDateGasps.Text = "Автозаполнение журнала редактирования записей ГАС ПС";
			this.mnuToolsFillLogEditDateGasps.Visible = false;
			this.mnuToolsFillLogEditDateGasps.Click += new System.EventHandler(this.ToolsFillLogEditDateGasps_Click);
			// 
			// mnuToolsFillLogEditDateFgisEsnsi
			// 
			this.mnuToolsFillLogEditDateFgisEsnsi.Name = "mnuToolsFillLogEditDateFgisEsnsi";
			this.mnuToolsFillLogEditDateFgisEsnsi.Size = new System.Drawing.Size(744, 38);
			this.mnuToolsFillLogEditDateFgisEsnsi.Text = "Автозаполнение журнала редактирования записей ФГИС ЕСНСИ";
			this.mnuToolsFillLogEditDateFgisEsnsi.Visible = false;
			this.mnuToolsFillLogEditDateFgisEsnsi.Click += new System.EventHandler(this.ToolsFillLogEditDateFgisEsnsi_Click);
			// 
			// mnuToolsFillLogEditDateErvk
			// 
			this.mnuToolsFillLogEditDateErvk.Name = "mnuToolsFillLogEditDateErvk";
			this.mnuToolsFillLogEditDateErvk.Size = new System.Drawing.Size(744, 38);
			this.mnuToolsFillLogEditDateErvk.Text = "Автозаполнение журнала редактирования записей ЕРВК";
			this.mnuToolsFillLogEditDateErvk.Visible = false;
			this.mnuToolsFillLogEditDateErvk.Click += new System.EventHandler(this.ToolsFillLogEditDateErvk_Click);
			// 
			// toolStripMenuItem20
			// 
			this.toolStripMenuItem20.Name = "toolStripMenuItem20";
			this.toolStripMenuItem20.Size = new System.Drawing.Size(741, 6);
			this.toolStripMenuItem20.Visible = false;
			// 
			// mnuToolsInitializeRtkTables
			// 
			this.mnuToolsInitializeRtkTables.Name = "mnuToolsInitializeRtkTables";
			this.mnuToolsInitializeRtkTables.Size = new System.Drawing.Size(744, 38);
			this.mnuToolsInitializeRtkTables.Text = "Инициализация таблиц в основной базе данных";
			this.mnuToolsInitializeRtkTables.Visible = false;
			this.mnuToolsInitializeRtkTables.Click += new System.EventHandler(this.ToolsInitializeRtkTables_Click);
			// 
			// mnuToolsFillRtkUrpTable
			// 
			this.mnuToolsFillRtkUrpTable.Name = "mnuToolsFillRtkUrpTable";
			this.mnuToolsFillRtkUrpTable.Size = new System.Drawing.Size(744, 38);
			this.mnuToolsFillRtkUrpTable.Text = "Автодополнение основной базы сведениями УРП ГАС ПС";
			this.mnuToolsFillRtkUrpTable.Visible = false;
			this.mnuToolsFillRtkUrpTable.Click += new System.EventHandler(this.ToolsFillRtkUrpTable_Click);
			// 
			// mnuToolsExpLawAgenceEdit
			// 
			this.mnuToolsExpLawAgenceEdit.Name = "mnuToolsExpLawAgenceEdit";
			this.mnuToolsExpLawAgenceEdit.Size = new System.Drawing.Size(594, 38);
			this.mnuToolsExpLawAgenceEdit.Text = "mnuToolsExpLawAgenceEdit";
			this.mnuToolsExpLawAgenceEdit.Visible = false;
			this.mnuToolsExpLawAgenceEdit.Click += new System.EventHandler(this.ToolsExpLawAgenceEdit_Click);
			// 
			// mnuToolsTableEdit
			// 
			this.mnuToolsTableEdit.Name = "mnuToolsTableEdit";
			this.mnuToolsTableEdit.Size = new System.Drawing.Size(594, 38);
			this.mnuToolsTableEdit.Text = "mnuToolsTableEdit";
			this.mnuToolsTableEdit.Visible = false;
			this.mnuToolsTableEdit.Click += new System.EventHandler(this.ToolsTableEdit_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpStatistic,
            this.toolStripMenuItem5,
            this.mnuHelpAbout});
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.Size = new System.Drawing.Size(109, 34);
			this.mnuHelp.Text = "Справка";
			// 
			// mnuHelpStatistic
			// 
			this.mnuHelpStatistic.Image = global::DatabaseToolSuite.Properties.Resources.Statistics24;
			this.mnuHelpStatistic.Name = "mnuHelpStatistic";
			this.mnuHelpStatistic.Size = new System.Drawing.Size(261, 38);
			this.mnuHelpStatistic.Text = "Статистика";
			this.mnuHelpStatistic.Click += new System.EventHandler(this.HelpStatistic_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(258, 6);
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Image = global::DatabaseToolSuite.Properties.Resources.About24;
			this.mnuHelpAbout.Name = "mnuHelpAbout";
			this.mnuHelpAbout.Size = new System.Drawing.Size(261, 38);
			this.mnuHelpAbout.Text = "О программе...";
			this.mnuHelpAbout.Click += new System.EventHandler(this.HelpAbout_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowCountStatusLabel,
            this.selectedRowStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 707);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 24, 0);
			this.statusStrip1.Size = new System.Drawing.Size(1228, 32);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// rowCountStatusLabel
			// 
			this.rowCountStatusLabel.AutoSize = false;
			this.rowCountStatusLabel.Name = "rowCountStatusLabel";
			this.rowCountStatusLabel.Size = new System.Drawing.Size(200, 25);
			this.rowCountStatusLabel.Text = "##";
			this.rowCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// selectedRowStatusLabel
			// 
			this.selectedRowStatusLabel.Name = "selectedRowStatusLabel";
			this.selectedRowStatusLabel.Size = new System.Drawing.Size(199, 25);
			this.selectedRowStatusLabel.Text = "selectedRowStatusLabel";
			// 
			// filterPanel
			// 
			this.filterPanel.AutoScroll = true;
			this.filterPanel.BackColor = System.Drawing.SystemColors.Window;
			this.filterPanel.Controls.Add(this.filterGroupBox);
			this.filterPanel.Location = new System.Drawing.Point(0, 122);
			this.filterPanel.Margin = new System.Windows.Forms.Padding(5);
			this.filterPanel.Name = "filterPanel";
			this.filterPanel.Size = new System.Drawing.Size(1228, 200);
			this.filterPanel.TabIndex = 3;
			// 
			// filterGroupBox
			// 
			this.filterGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterGroupBox.Controls.Add(this.filterErvkOnlyRadioButton);
			this.filterGroupBox.Controls.Add(this.filterFgisEsnsiOnlyRadioButton);
			this.filterGroupBox.Controls.Add(this.filterAllRadioButton);
			this.filterGroupBox.Controls.Add(this.cleanFilterButton);
			this.filterGroupBox.Controls.Add(this.filterCodeNumericTextBox);
			this.filterGroupBox.Controls.Add(this.label1);
			this.filterGroupBox.Controls.Add(this.label2);
			this.filterGroupBox.Controls.Add(this.filterNameTextBox);
			this.filterGroupBox.Controls.Add(this.filterLockCodeViewCheckBox);
			this.filterGroupBox.Controls.Add(this.okatoLabel);
			this.filterGroupBox.Controls.Add(this.filterAuthorityComboBox);
			this.filterGroupBox.Controls.Add(this.filterOkatoComboBox);
			this.filterGroupBox.Controls.Add(this.authorityLabel);
			this.filterGroupBox.Location = new System.Drawing.Point(9, 6);
			this.filterGroupBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.filterGroupBox.Name = "filterGroupBox";
			this.filterGroupBox.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.filterGroupBox.Size = new System.Drawing.Size(874, 191);
			this.filterGroupBox.TabIndex = 2;
			this.filterGroupBox.TabStop = false;
			this.filterGroupBox.Text = "Фильтр";
			// 
			// filterErvkOnlyRadioButton
			// 
			this.filterErvkOnlyRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.filterErvkOnlyRadioButton.AutoSize = true;
			this.filterErvkOnlyRadioButton.Location = new System.Drawing.Point(772, 99);
			this.filterErvkOnlyRadioButton.Name = "filterErvkOnlyRadioButton";
			this.filterErvkOnlyRadioButton.Size = new System.Drawing.Size(93, 29);
			this.filterErvkOnlyRadioButton.TabIndex = 43;
			this.filterErvkOnlyRadioButton.TabStop = true;
			this.filterErvkOnlyRadioButton.Text = "ЕРВК";
			this.filterErvkOnlyRadioButton.UseVisualStyleBackColor = true;
			this.filterErvkOnlyRadioButton.CheckedChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// filterFgisEsnsiOnlyRadioButton
			// 
			this.filterFgisEsnsiOnlyRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.filterFgisEsnsiOnlyRadioButton.AutoSize = true;
			this.filterFgisEsnsiOnlyRadioButton.Location = new System.Drawing.Point(606, 99);
			this.filterFgisEsnsiOnlyRadioButton.Name = "filterFgisEsnsiOnlyRadioButton";
			this.filterFgisEsnsiOnlyRadioButton.Size = new System.Drawing.Size(177, 29);
			this.filterFgisEsnsiOnlyRadioButton.TabIndex = 42;
			this.filterFgisEsnsiOnlyRadioButton.TabStop = true;
			this.filterFgisEsnsiOnlyRadioButton.Text = "ФГИС ЕСНСИ";
			this.filterFgisEsnsiOnlyRadioButton.UseVisualStyleBackColor = true;
			this.filterFgisEsnsiOnlyRadioButton.CheckedChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// filterAllRadioButton
			// 
			this.filterAllRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.filterAllRadioButton.AutoSize = true;
			this.filterAllRadioButton.Checked = true;
			this.filterAllRadioButton.Location = new System.Drawing.Point(483, 99);
			this.filterAllRadioButton.Name = "filterAllRadioButton";
			this.filterAllRadioButton.Size = new System.Drawing.Size(150, 29);
			this.filterAllRadioButton.TabIndex = 41;
			this.filterAllRadioButton.TabStop = true;
			this.filterAllRadioButton.Text = "Все записи";
			this.filterAllRadioButton.UseVisualStyleBackColor = true;
			this.filterAllRadioButton.CheckedChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// cleanFilterButton
			// 
			this.cleanFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cleanFilterButton.Location = new System.Drawing.Point(740, 140);
			this.cleanFilterButton.Margin = new System.Windows.Forms.Padding(5);
			this.cleanFilterButton.Name = "cleanFilterButton";
			this.cleanFilterButton.Size = new System.Drawing.Size(125, 34);
			this.cleanFilterButton.TabIndex = 8;
			this.cleanFilterButton.Text = "Очистить";
			this.cleanFilterButton.Click += new System.EventHandler(this.CleanFilterButton_Click);
			// 
			// filterCodeNumericTextBox
			// 
			this.filterCodeNumericTextBox.Location = new System.Drawing.Point(9, 142);
			this.filterCodeNumericTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.filterCodeNumericTextBox.Name = "filterCodeNumericTextBox";
			this.filterCodeNumericTextBox.Size = new System.Drawing.Size(196, 31);
			this.filterCodeNumericTextBox.TabIndex = 6;
			this.filterCodeNumericTextBox.TextChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(214, 114);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(327, 25);
			this.label1.TabIndex = 40;
			this.label1.Text = "Наименование подразделения:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 114);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(216, 25);
			this.label2.TabIndex = 39;
			this.label2.Text = "Код подразделения:";
			// 
			// filterNameTextBox
			// 
			this.filterNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterNameTextBox.Location = new System.Drawing.Point(216, 142);
			this.filterNameTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.filterNameTextBox.Name = "filterNameTextBox";
			this.filterNameTextBox.Size = new System.Drawing.Size(514, 31);
			this.filterNameTextBox.TabIndex = 7;
			this.filterNameTextBox.TextChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// filterLockCodeViewCheckBox
			// 
			this.filterLockCodeViewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.filterLockCodeViewCheckBox.AutoSize = true;
			this.filterLockCodeViewCheckBox.Location = new System.Drawing.Point(543, 70);
			this.filterLockCodeViewCheckBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.filterLockCodeViewCheckBox.Name = "filterLockCodeViewCheckBox";
			this.filterLockCodeViewCheckBox.Size = new System.Drawing.Size(321, 29);
			this.filterLockCodeViewCheckBox.TabIndex = 5;
			this.filterLockCodeViewCheckBox.Text = "Включить заблокированные";
			this.filterLockCodeViewCheckBox.UseVisualStyleBackColor = true;
			this.filterLockCodeViewCheckBox.CheckedChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// okatoLabel
			// 
			this.okatoLabel.AutoSize = true;
			this.okatoLabel.Location = new System.Drawing.Point(5, 31);
			this.okatoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.okatoLabel.Name = "okatoLabel";
			this.okatoLabel.Size = new System.Drawing.Size(135, 25);
			this.okatoLabel.TabIndex = 35;
			this.okatoLabel.Text = "Код ОКАТО:";
			// 
			// filterAuthorityComboBox
			// 
			this.filterAuthorityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterAuthorityComboBox.Code = "";
			this.filterAuthorityComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.filterAuthorityComboBox.DropDownHeight = 584;
			this.filterAuthorityComboBox.DropDownWidth = 80;
			this.filterAuthorityComboBox.FormattingEnabled = true;
			this.filterAuthorityComboBox.Id = ((long)(-1));
			this.filterAuthorityComboBox.IntegralHeight = false;
			this.filterAuthorityComboBox.ItemHeight = 29;
			this.filterAuthorityComboBox.Location = new System.Drawing.Point(134, 66);
			this.filterAuthorityComboBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.filterAuthorityComboBox.MaxDropDownItems = 20;
			this.filterAuthorityComboBox.Name = "filterAuthorityComboBox";
			this.filterAuthorityComboBox.SelectedItem = null;
			this.filterAuthorityComboBox.Size = new System.Drawing.Size(409, 35);
			this.filterAuthorityComboBox.TabIndex = 4;
			this.filterAuthorityComboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// filterOkatoComboBox
			// 
			this.filterOkatoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterOkatoComboBox.Code = "";
			this.filterOkatoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.filterOkatoComboBox.DropDownHeight = 584;
			this.filterOkatoComboBox.DropDownWidth = 80;
			this.filterOkatoComboBox.FormattingEnabled = true;
			this.filterOkatoComboBox.Id = ((long)(-1));
			this.filterOkatoComboBox.IntegralHeight = false;
			this.filterOkatoComboBox.ItemHeight = 29;
			this.filterOkatoComboBox.Location = new System.Drawing.Point(134, 26);
			this.filterOkatoComboBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.filterOkatoComboBox.MaxDropDownItems = 20;
			this.filterOkatoComboBox.Name = "filterOkatoComboBox";
			this.filterOkatoComboBox.SelectedItem = null;
			this.filterOkatoComboBox.Size = new System.Drawing.Size(730, 35);
			this.filterOkatoComboBox.TabIndex = 3;
			this.filterOkatoComboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// authorityLabel
			// 
			this.authorityLabel.AutoSize = true;
			this.authorityLabel.Location = new System.Drawing.Point(5, 71);
			this.authorityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.authorityLabel.Name = "authorityLabel";
			this.authorityLabel.Size = new System.Drawing.Size(141, 25);
			this.authorityLabel.TabIndex = 0;
			this.authorityLabel.Text = "Вид органов:";
			// 
			// contextMenuTable
			// 
			this.contextMenuTable.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.contextMenuTable.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.contextMenuTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextNewOrganization,
            this.mnuContextCreateOrganization,
            this.toolStripMenuItem8,
            this.mnuContextCreateNewVersion,
            this.toolStripMenuItem9,
            this.mnuContextRemoveOrganization,
            this.toolStripMenuItem10,
            this.mnuContextEditError,
            this.toolStripMenuItem12,
            this.mnuContextFgisEsnsiEdit,
            this.mnuContextFgisEsnsiCloneToLast,
            this.toolStripMenuItem14,
            this.mnuContextErvkEdit,
            this.mnuContextErvkCloneToLast,
            this.toolStripMenuItem16,
            this.mnuContextUrpEdit,
            this.mnuContextUrpCloneToLast,
            this.toolStripMenuItem22,
            this.mnuContextUpdate});
			this.contextMenuTable.Name = "contextMenuTable";
			this.contextMenuTable.Size = new System.Drawing.Size(723, 478);
			// 
			// mnuContextNewOrganization
			// 
			this.mnuContextNewOrganization.Image = global::DatabaseToolSuite.Properties.Resources.New24;
			this.mnuContextNewOrganization.Name = "mnuContextNewOrganization";
			this.mnuContextNewOrganization.Size = new System.Drawing.Size(722, 36);
			this.mnuContextNewOrganization.Text = "Создать запись...";
			this.mnuContextNewOrganization.Click += new System.EventHandler(this.NewOrganization_Click);
			// 
			// mnuContextCreateOrganization
			// 
			this.mnuContextCreateOrganization.Image = global::DatabaseToolSuite.Properties.Resources.NewSeries24;
			this.mnuContextCreateOrganization.Name = "mnuContextCreateOrganization";
			this.mnuContextCreateOrganization.Size = new System.Drawing.Size(722, 36);
			this.mnuContextCreateOrganization.Text = "Создать запись на основе текущей...";
			this.mnuContextCreateOrganization.Click += new System.EventHandler(this.CreateOrganization_Click);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(719, 6);
			// 
			// mnuContextCreateNewVersion
			// 
			this.mnuContextCreateNewVersion.Image = global::DatabaseToolSuite.Properties.Resources.Duplicate24;
			this.mnuContextCreateNewVersion.Name = "mnuContextCreateNewVersion";
			this.mnuContextCreateNewVersion.Size = new System.Drawing.Size(722, 36);
			this.mnuContextCreateNewVersion.Text = "Создать новую версию записи...";
			this.mnuContextCreateNewVersion.Click += new System.EventHandler(this.CreateVersion_Click);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(719, 6);
			// 
			// mnuContextRemoveOrganization
			// 
			this.mnuContextRemoveOrganization.Image = global::DatabaseToolSuite.Properties.Resources.Delete24;
			this.mnuContextRemoveOrganization.Name = "mnuContextRemoveOrganization";
			this.mnuContextRemoveOrganization.Size = new System.Drawing.Size(722, 36);
			this.mnuContextRemoveOrganization.Text = "Заблокировать запись...";
			this.mnuContextRemoveOrganization.Click += new System.EventHandler(this.RemoveOrganization_Click);
			// 
			// toolStripMenuItem10
			// 
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new System.Drawing.Size(719, 6);
			// 
			// mnuContextEditError
			// 
			this.mnuContextEditError.Image = global::DatabaseToolSuite.Properties.Resources.Edit24;
			this.mnuContextEditError.Name = "mnuContextEditError";
			this.mnuContextEditError.Size = new System.Drawing.Size(722, 36);
			this.mnuContextEditError.Text = "Исправить ошибку...";
			this.mnuContextEditError.Click += new System.EventHandler(this.EditError_Click);
			// 
			// toolStripMenuItem12
			// 
			this.toolStripMenuItem12.Name = "toolStripMenuItem12";
			this.toolStripMenuItem12.Size = new System.Drawing.Size(719, 6);
			// 
			// mnuContextFgisEsnsiEdit
			// 
			this.mnuContextFgisEsnsiEdit.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi24;
			this.mnuContextFgisEsnsiEdit.Name = "mnuContextFgisEsnsiEdit";
			this.mnuContextFgisEsnsiEdit.Size = new System.Drawing.Size(722, 36);
			this.mnuContextFgisEsnsiEdit.Text = "Запись ФГИС ЕСНСИ...";
			this.mnuContextFgisEsnsiEdit.Click += new System.EventHandler(this.FgisEsnsiEdit_Click);
			// 
			// mnuContextFgisEsnsiCloneToLast
			// 
			this.mnuContextFgisEsnsiCloneToLast.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi_dublicate24;
			this.mnuContextFgisEsnsiCloneToLast.Name = "mnuContextFgisEsnsiCloneToLast";
			this.mnuContextFgisEsnsiCloneToLast.Size = new System.Drawing.Size(722, 36);
			this.mnuContextFgisEsnsiCloneToLast.Text = "Копировать запись ФГИС ЕСНСИ в действующую версию записи";
			this.mnuContextFgisEsnsiCloneToLast.Click += new System.EventHandler(this.FgisEsnsiCloneToLast_Click);
			// 
			// toolStripMenuItem14
			// 
			this.toolStripMenuItem14.Name = "toolStripMenuItem14";
			this.toolStripMenuItem14.Size = new System.Drawing.Size(719, 6);
			// 
			// mnuContextErvkEdit
			// 
			this.mnuContextErvkEdit.Image = global::DatabaseToolSuite.Properties.Resources.economy24;
			this.mnuContextErvkEdit.Name = "mnuContextErvkEdit";
			this.mnuContextErvkEdit.Size = new System.Drawing.Size(722, 36);
			this.mnuContextErvkEdit.Text = "Запись ЕРВК...";
			this.mnuContextErvkEdit.Click += new System.EventHandler(this.ErvkEdit_Click);
			// 
			// mnuContextErvkCloneToLast
			// 
			this.mnuContextErvkCloneToLast.Image = global::DatabaseToolSuite.Properties.Resources.economy_dublicate24;
			this.mnuContextErvkCloneToLast.Name = "mnuContextErvkCloneToLast";
			this.mnuContextErvkCloneToLast.Size = new System.Drawing.Size(722, 36);
			this.mnuContextErvkCloneToLast.Text = "Копировать запись ЕРВК в действующую версию записи";
			this.mnuContextErvkCloneToLast.Click += new System.EventHandler(this.ErvkCloneToLast_Click);
			// 
			// toolStripMenuItem16
			// 
			this.toolStripMenuItem16.Name = "toolStripMenuItem16";
			this.toolStripMenuItem16.Size = new System.Drawing.Size(719, 6);
			// 
			// mnuContextUrpEdit
			// 
			this.mnuContextUrpEdit.Image = global::DatabaseToolSuite.Properties.Resources.emblem24;
			this.mnuContextUrpEdit.Name = "mnuContextUrpEdit";
			this.mnuContextUrpEdit.Size = new System.Drawing.Size(722, 36);
			this.mnuContextUrpEdit.Text = "Запись УРП ГАС ПС...";
			this.mnuContextUrpEdit.Click += new System.EventHandler(this.UrpEdit_Click);
			// 
			// mnuContextUrpCloneToLast
			// 
			this.mnuContextUrpCloneToLast.Image = global::DatabaseToolSuite.Properties.Resources.emblem_dublicate24;
			this.mnuContextUrpCloneToLast.Name = "mnuContextUrpCloneToLast";
			this.mnuContextUrpCloneToLast.Size = new System.Drawing.Size(722, 36);
			this.mnuContextUrpCloneToLast.Text = "Копировать запись УРП ГАС ПС в действующую версию записи";
			this.mnuContextUrpCloneToLast.Click += new System.EventHandler(this.UrpCloneToLast_Click);
			// 
			// toolStripMenuItem22
			// 
			this.toolStripMenuItem22.Name = "toolStripMenuItem22";
			this.toolStripMenuItem22.Size = new System.Drawing.Size(719, 6);
			// 
			// mnuContextUpdate
			// 
			this.mnuContextUpdate.Image = global::DatabaseToolSuite.Properties.Resources.Update24;
			this.mnuContextUpdate.Name = "mnuContextUpdate";
			this.mnuContextUpdate.Size = new System.Drawing.Size(722, 36);
			this.mnuContextUpdate.Text = "Обновить таблицу";
			this.mnuContextUpdate.Click += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// mainToolStripBar
			// 
			this.mainToolStripBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mainToolStripBar.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.mainToolStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSaveButton,
            this.toolStripSeparator1,
            this.tableNewOrganizationButton,
            this.tableCreateOrganizationButton,
            this.toolStripSeparator2,
            this.tableCreateNewVersionButton,
            this.toolStripSeparator3,
            this.tableRemoveOrganizationButton,
            this.toolStripSeparator4,
            this.mnuTableFgisEsnsiEditButton,
            this.mnuTableFgisEsnsiCloneToLastButton,
            this.mnuTableFgisEsnsiRemoveButton,
            this.toolStripSeparator5,
            this.mnuTableErvkEditButton,
            this.mnuTableErvkCloneToLastButton,
            this.mnuTableErvkRemoveButton,
            this.toolStripSeparator6,
            this.mnuTableUrpEditButton,
            this.mnuTableUrpCloneToLastButton,
            this.mnuTableUrpRemoveButton,
            this.toolStripSeparator7,
            this.mnuTableRefreshButton});
			this.mainToolStripBar.Location = new System.Drawing.Point(0, 38);
			this.mainToolStripBar.Name = "mainToolStripBar";
			this.mainToolStripBar.Size = new System.Drawing.Size(1228, 41);
			this.mainToolStripBar.TabIndex = 9;
			this.mainToolStripBar.Text = "Стандартная";
			// 
			// fileSaveButton
			// 
			this.fileSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fileSaveButton.Image = global::DatabaseToolSuite.Properties.Resources.Save32;
			this.fileSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileSaveButton.Name = "fileSaveButton";
			this.fileSaveButton.Size = new System.Drawing.Size(36, 36);
			this.fileSaveButton.Text = "Сохранить файл";
			this.fileSaveButton.Click += new System.EventHandler(this.FileSaveToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
			// 
			// tableNewOrganizationButton
			// 
			this.tableNewOrganizationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tableNewOrganizationButton.Image = global::DatabaseToolSuite.Properties.Resources.New32;
			this.tableNewOrganizationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tableNewOrganizationButton.Name = "tableNewOrganizationButton";
			this.tableNewOrganizationButton.Size = new System.Drawing.Size(36, 36);
			this.tableNewOrganizationButton.Text = "Создать запись...";
			this.tableNewOrganizationButton.Click += new System.EventHandler(this.NewOrganization_Click);
			// 
			// tableCreateOrganizationButton
			// 
			this.tableCreateOrganizationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tableCreateOrganizationButton.Image = global::DatabaseToolSuite.Properties.Resources.NewSeries32;
			this.tableCreateOrganizationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tableCreateOrganizationButton.Name = "tableCreateOrganizationButton";
			this.tableCreateOrganizationButton.Size = new System.Drawing.Size(36, 36);
			this.tableCreateOrganizationButton.Text = "Создать запись на основе текущей...";
			this.tableCreateOrganizationButton.Click += new System.EventHandler(this.CreateOrganization_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
			// 
			// tableCreateNewVersionButton
			// 
			this.tableCreateNewVersionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tableCreateNewVersionButton.Image = global::DatabaseToolSuite.Properties.Resources.Duplicate32;
			this.tableCreateNewVersionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tableCreateNewVersionButton.Name = "tableCreateNewVersionButton";
			this.tableCreateNewVersionButton.Size = new System.Drawing.Size(36, 36);
			this.tableCreateNewVersionButton.Text = "Создать новую версию записи...";
			this.tableCreateNewVersionButton.Click += new System.EventHandler(this.CreateVersion_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
			// 
			// tableRemoveOrganizationButton
			// 
			this.tableRemoveOrganizationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tableRemoveOrganizationButton.Image = global::DatabaseToolSuite.Properties.Resources.Delete32;
			this.tableRemoveOrganizationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tableRemoveOrganizationButton.Name = "tableRemoveOrganizationButton";
			this.tableRemoveOrganizationButton.Size = new System.Drawing.Size(36, 36);
			this.tableRemoveOrganizationButton.Text = "Заблокировать запись...";
			this.tableRemoveOrganizationButton.Click += new System.EventHandler(this.RemoveOrganization_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
			// 
			// mnuTableFgisEsnsiEditButton
			// 
			this.mnuTableFgisEsnsiEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableFgisEsnsiEditButton.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi32;
			this.mnuTableFgisEsnsiEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableFgisEsnsiEditButton.Name = "mnuTableFgisEsnsiEditButton";
			this.mnuTableFgisEsnsiEditButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableFgisEsnsiEditButton.Text = "Запись ФГИС ЕСНСИ";
			this.mnuTableFgisEsnsiEditButton.Click += new System.EventHandler(this.FgisEsnsiEdit_Click);
			// 
			// mnuTableFgisEsnsiCloneToLastButton
			// 
			this.mnuTableFgisEsnsiCloneToLastButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableFgisEsnsiCloneToLastButton.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi_dublicate32;
			this.mnuTableFgisEsnsiCloneToLastButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableFgisEsnsiCloneToLastButton.Name = "mnuTableFgisEsnsiCloneToLastButton";
			this.mnuTableFgisEsnsiCloneToLastButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableFgisEsnsiCloneToLastButton.Text = "Копировать запись ФГИС ЕСНСИ в действующую версию записи";
			this.mnuTableFgisEsnsiCloneToLastButton.Click += new System.EventHandler(this.FgisEsnsiCloneToLast_Click);
			// 
			// mnuTableFgisEsnsiRemoveButton
			// 
			this.mnuTableFgisEsnsiRemoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableFgisEsnsiRemoveButton.Image = global::DatabaseToolSuite.Properties.Resources.gosuslugi_remove32;
			this.mnuTableFgisEsnsiRemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableFgisEsnsiRemoveButton.Name = "mnuTableFgisEsnsiRemoveButton";
			this.mnuTableFgisEsnsiRemoveButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableFgisEsnsiRemoveButton.Text = "Удалить запись ФГИС ЕСНСИ";
			this.mnuTableFgisEsnsiRemoveButton.Click += new System.EventHandler(this.FgisEsnsiRemove_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 41);
			// 
			// mnuTableErvkEditButton
			// 
			this.mnuTableErvkEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableErvkEditButton.Image = global::DatabaseToolSuite.Properties.Resources.economy32;
			this.mnuTableErvkEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableErvkEditButton.Name = "mnuTableErvkEditButton";
			this.mnuTableErvkEditButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableErvkEditButton.Text = "Запись ЕРВК";
			this.mnuTableErvkEditButton.Click += new System.EventHandler(this.ErvkEdit_Click);
			// 
			// mnuTableErvkCloneToLastButton
			// 
			this.mnuTableErvkCloneToLastButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableErvkCloneToLastButton.Image = global::DatabaseToolSuite.Properties.Resources.economy_dublicate32;
			this.mnuTableErvkCloneToLastButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableErvkCloneToLastButton.Name = "mnuTableErvkCloneToLastButton";
			this.mnuTableErvkCloneToLastButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableErvkCloneToLastButton.Text = "Копировать запись ЕРВК в действующую версию записи";
			this.mnuTableErvkCloneToLastButton.Click += new System.EventHandler(this.ErvkCloneToLast_Click);
			// 
			// mnuTableErvkRemoveButton
			// 
			this.mnuTableErvkRemoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableErvkRemoveButton.Image = global::DatabaseToolSuite.Properties.Resources.economy_remove32;
			this.mnuTableErvkRemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableErvkRemoveButton.Name = "mnuTableErvkRemoveButton";
			this.mnuTableErvkRemoveButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableErvkRemoveButton.Text = "Удалить запись ЕРВК";
			this.mnuTableErvkRemoveButton.Click += new System.EventHandler(this.ErvkRemove_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 41);
			// 
			// mnuTableUrpEditButton
			// 
			this.mnuTableUrpEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableUrpEditButton.Image = global::DatabaseToolSuite.Properties.Resources.emblem32;
			this.mnuTableUrpEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableUrpEditButton.Name = "mnuTableUrpEditButton";
			this.mnuTableUrpEditButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableUrpEditButton.Text = "Запись УРП ГАС ПС";
			this.mnuTableUrpEditButton.Click += new System.EventHandler(this.UrpEdit_Click);
			// 
			// mnuTableUrpCloneToLastButton
			// 
			this.mnuTableUrpCloneToLastButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableUrpCloneToLastButton.Image = global::DatabaseToolSuite.Properties.Resources.emblem_dublicate32;
			this.mnuTableUrpCloneToLastButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableUrpCloneToLastButton.Name = "mnuTableUrpCloneToLastButton";
			this.mnuTableUrpCloneToLastButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableUrpCloneToLastButton.Text = "Копировать запись УРП ГАС ПС в действующую версию записи";
			this.mnuTableUrpCloneToLastButton.Click += new System.EventHandler(this.UrpCloneToLast_Click);
			// 
			// mnuTableUrpRemoveButton
			// 
			this.mnuTableUrpRemoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableUrpRemoveButton.Image = global::DatabaseToolSuite.Properties.Resources.emblem_remove32;
			this.mnuTableUrpRemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableUrpRemoveButton.Name = "mnuTableUrpRemoveButton";
			this.mnuTableUrpRemoveButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableUrpRemoveButton.Text = "Удалить запись УРП ГАС ПС";
			this.mnuTableUrpRemoveButton.Click += new System.EventHandler(this.UrpRemove_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
			// 
			// mnuTableRefreshButton
			// 
			this.mnuTableRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mnuTableRefreshButton.Image = global::DatabaseToolSuite.Properties.Resources.Update24;
			this.mnuTableRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.mnuTableRefreshButton.Name = "mnuTableRefreshButton";
			this.mnuTableRefreshButton.Size = new System.Drawing.Size(36, 36);
			this.mnuTableRefreshButton.Text = "Обновить таблицу";
			this.mnuTableRefreshButton.Click += new System.EventHandler(this.Filter_ParametersChanged);
			// 
			// additionalToolStripBar
			// 
			this.additionalToolStripBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.additionalToolStripBar.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.additionalToolStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator8,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripSeparator9,
            this.toolStripButton10,
            this.toolStripButton11,
            this.toolStripSeparator10,
            this.toolStripButton12,
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripSeparator11,
            this.toolStripButton15,
            this.toolStripButton16,
            this.toolStripButton17,
            this.toolStripButton18,
            this.toolStripButton19,
            this.toolStripButton20,
            this.toolStripButton21,
            this.toolStripButton22});
			this.additionalToolStripBar.Location = new System.Drawing.Point(0, 79);
			this.additionalToolStripBar.Name = "additionalToolStripBar";
			this.additionalToolStripBar.Size = new System.Drawing.Size(1228, 33);
			this.additionalToolStripBar.TabIndex = 10;
			this.additionalToolStripBar.Text = "Дополнительная";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::DatabaseToolSuite.Properties.Resources.bt01;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton1.Tag = "1";
			this.toolStripButton1.Text = "Генеральная прокуратура";
			this.toolStripButton1.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 33);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::DatabaseToolSuite.Properties.Resources.bt02;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton2.Tag = "2";
			this.toolStripButton2.Text = "Прокуратура субъекта";
			this.toolStripButton2.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = global::DatabaseToolSuite.Properties.Resources.bt03;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton3.Tag = "3";
			this.toolStripButton3.Text = "Районная прокуратура";
			this.toolStripButton3.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = global::DatabaseToolSuite.Properties.Resources.bt04;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton4.Tag = "4";
			this.toolStripButton4.Text = "Межрайонная прокуратура";
			this.toolStripButton4.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = global::DatabaseToolSuite.Properties.Resources.bt05;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton5.Tag = "5";
			this.toolStripButton5.Text = "Специализированная прокуратура субъекта";
			this.toolStripButton5.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = global::DatabaseToolSuite.Properties.Resources.bt06;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton6.Tag = "6";
			this.toolStripButton6.Text = "Межрайонная специализированная прокуратура";
			this.toolStripButton6.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton7.Image = global::DatabaseToolSuite.Properties.Resources.bt07;
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton7.Tag = "7";
			this.toolStripButton7.Text = "Городская прокуратура";
			this.toolStripButton7.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton8.Image = global::DatabaseToolSuite.Properties.Resources.bt08;
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton8.Tag = "8";
			this.toolStripButton8.Text = "Окружная прокуратура";
			this.toolStripButton8.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton9.Image = global::DatabaseToolSuite.Properties.Resources.bt09;
			this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton9.Tag = "9";
			this.toolStripButton9.Text = "Городская районная прокуратура";
			this.toolStripButton9.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 33);
			// 
			// toolStripButton10
			// 
			this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton10.Image = global::DatabaseToolSuite.Properties.Resources.bt10;
			this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton10.Name = "toolStripButton10";
			this.toolStripButton10.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton10.Tag = "10";
			this.toolStripButton10.Text = "Специализированная прокуратура";
			this.toolStripButton10.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton11
			// 
			this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton11.Image = global::DatabaseToolSuite.Properties.Resources.bt11;
			this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton11.Tag = "11";
			this.toolStripButton11.Text = "Специализированная прокуратура на правах районной";
			this.toolStripButton11.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 33);
			// 
			// toolStripButton12
			// 
			this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton12.Image = global::DatabaseToolSuite.Properties.Resources.bt12;
			this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton12.Name = "toolStripButton12";
			this.toolStripButton12.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton12.Tag = "12";
			this.toolStripButton12.Text = "Главная военная прокуратура";
			this.toolStripButton12.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton13
			// 
			this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton13.Image = global::DatabaseToolSuite.Properties.Resources.bt13;
			this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton13.Name = "toolStripButton13";
			this.toolStripButton13.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton13.Tag = "13";
			this.toolStripButton13.Text = "Военная прокуратура окружного звена";
			this.toolStripButton13.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton14
			// 
			this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton14.Image = global::DatabaseToolSuite.Properties.Resources.bt14;
			this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton14.Name = "toolStripButton14";
			this.toolStripButton14.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton14.Tag = "14";
			this.toolStripButton14.Text = "Военная прокуратура";
			this.toolStripButton14.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 33);
			// 
			// toolStripButton15
			// 
			this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton15.Image = global::DatabaseToolSuite.Properties.Resources.bt15;
			this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton15.Name = "toolStripButton15";
			this.toolStripButton15.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton15.Tag = "15";
			this.toolStripButton15.Text = "Центральный аппарат";
			this.toolStripButton15.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton16
			// 
			this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton16.Image = global::DatabaseToolSuite.Properties.Resources.bt16;
			this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton16.Name = "toolStripButton16";
			this.toolStripButton16.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton16.Tag = "16";
			this.toolStripButton16.Text = "Аппарат";
			this.toolStripButton16.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton17
			// 
			this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton17.Image = global::DatabaseToolSuite.Properties.Resources.bt17;
			this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton17.Name = "toolStripButton17";
			this.toolStripButton17.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton17.Tag = "17";
			this.toolStripButton17.Text = "Главное управление";
			this.toolStripButton17.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton18
			// 
			this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton18.Image = global::DatabaseToolSuite.Properties.Resources.bt18;
			this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton18.Name = "toolStripButton18";
			this.toolStripButton18.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton18.Tag = "18";
			this.toolStripButton18.Text = "Управление";
			this.toolStripButton18.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton19
			// 
			this.toolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton19.Image = global::DatabaseToolSuite.Properties.Resources.bt19;
			this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton19.Name = "toolStripButton19";
			this.toolStripButton19.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton19.Tag = "19";
			this.toolStripButton19.Text = "Отдел";
			this.toolStripButton19.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton20
			// 
			this.toolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton20.Image = global::DatabaseToolSuite.Properties.Resources.bt20;
			this.toolStripButton20.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton20.Name = "toolStripButton20";
			this.toolStripButton20.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton20.Tag = "20";
			this.toolStripButton20.Text = "Руководитель";
			this.toolStripButton20.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton21
			// 
			this.toolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton21.Image = global::DatabaseToolSuite.Properties.Resources.bt21;
			this.toolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton21.Name = "toolStripButton21";
			this.toolStripButton21.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton21.Tag = "21";
			this.toolStripButton21.Text = "Старший помощник";
			this.toolStripButton21.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// toolStripButton22
			// 
			this.toolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton22.Image = global::DatabaseToolSuite.Properties.Resources.bt22;
			this.toolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton22.Name = "toolStripButton22";
			this.toolStripButton22.Size = new System.Drawing.Size(34, 28);
			this.toolStripButton22.Tag = "22";
			this.toolStripButton22.Text = "Помощник";
			this.toolStripButton22.Click += new System.EventHandler(this.UrpLawAgencyTypeEditButton_Click);
			// 
			// gaspsListView
			// 
			this.gaspsListView.DataSet = null;
			this.gaspsListView.ErvkOnlyShow = false;
			this.gaspsListView.FgisEsnsiOnlyShow = false;
			this.gaspsListView.Location = new System.Drawing.Point(0, 326);
			this.gaspsListView.LockShow = false;
			this.gaspsListView.Margin = new System.Windows.Forms.Padding(6);
			this.gaspsListView.Name = "gaspsListView";
			this.gaspsListView.ReserveShow = true;
			this.gaspsListView.Size = new System.Drawing.Size(1228, 379);
			this.gaspsListView.TabIndex = 1;
			this.gaspsListView.UnlockShow = true;
			this.gaspsListView.ItemSelectionChanged += new System.EventHandler(this.GaspsListView_ItemSelectionChanged);
			this.gaspsListView.ItemsMultySelectionChanged += new System.EventHandler(this.GaspsListView_ItemsMultySelectionChanged);
			this.gaspsListView.ItemMouseClick += new System.EventHandler<DatabaseToolSuite.Controls.ListViewEventArgs>(this.GaspsListView_ItemMouseClick);
			this.gaspsListView.ItemMouseDoubleClick += new System.EventHandler<DatabaseToolSuite.Controls.ListViewEventArgs>(this.GaspsListView_ItemMouseDoubleClick);
			this.gaspsListView.GaspsListViewCompleted += new DatabaseToolSuite.Controls.GaspsListView.ListViewCompletedEventHandler(this.GaspsListView_GaspsListViewCompleted);
			// 
			// mnuFileExportDelta
			// 
			this.mnuFileExportDelta.Image = global::DatabaseToolSuite.Properties.Resources.ExportXmlGaspsFile24;
			this.mnuFileExportDelta.Name = "mnuFileExportDelta";
			this.mnuFileExportDelta.Size = new System.Drawing.Size(476, 38);
			this.mnuFileExportDelta.Text = "Сведения об изменениях за период...";
			this.mnuFileExportDelta.Click += new System.EventHandler(this.FileExportDelta_Click);
			// 
			// AppForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1228, 739);
			this.Controls.Add(this.filterPanel);
			this.Controls.Add(this.additionalToolStripBar);
			this.Controls.Add(this.mainToolStripBar);
			this.Controls.Add(this.gaspsListView);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.mainMenuStrip);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenuStrip;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MinimumSize = new System.Drawing.Size(1188, 398);
			this.Name = "AppForm";
			this.Text = "Справочник подразделений правоохранительных органов в НСИ ГАС ПС";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppForm_FormClosing);
			this.Load += new System.EventHandler(this.AppForm_Load);
			this.Resize += new System.EventHandler(this.AppForm_Resize);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.filterPanel.ResumeLayout(false);
			this.filterGroupBox.ResumeLayout(false);
			this.filterGroupBox.PerformLayout();
			this.contextMenuTable.ResumeLayout(false);
			this.mainToolStripBar.ResumeLayout(false);
			this.mainToolStripBar.PerformLayout();
			this.additionalToolStripBar.ResumeLayout(false);
			this.additionalToolStripBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileImport;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private Controls.NumericTextBox filterCodeNumericTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filterNameTextBox;
        private System.Windows.Forms.CheckBox filterLockCodeViewCheckBox;
        private System.Windows.Forms.Label okatoLabel;
        private Controls.AuthorityComboBox filterAuthorityComboBox;
        private Controls.OkatoComboBox filterOkatoComboBox;
        private System.Windows.Forms.Label authorityLabel;
        private Controls.GaspsListView gaspsListView;
        private System.Windows.Forms.ToolStripStatusLabel rowCountStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem mnuTable;
        private System.Windows.Forms.ToolStripMenuItem mnuTableNewOrganization;
        private System.Windows.Forms.ToolStripMenuItem mnuTableCreateOrganization;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuTableCreateNewVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuTableRemoveOrganization;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpStatistic;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripStatusLabel selectedRowStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mnuTableEditError;
        private System.Windows.Forms.ContextMenuStrip contextMenuTable;
        private System.Windows.Forms.ToolStripMenuItem mnuContextNewOrganization;
        private System.Windows.Forms.ToolStripMenuItem mnuContextCreateOrganization;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem mnuContextCreateNewVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem mnuContextRemoveOrganization;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem mnuContextEditError;
        protected System.Windows.Forms.Button cleanFilterButton;
        private System.Windows.Forms.ToolStrip mainToolStripBar;
        private System.Windows.Forms.ToolStripButton fileSaveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tableNewOrganizationButton;
        private System.Windows.Forms.ToolStripButton tableCreateOrganizationButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tableCreateNewVersionButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tableRemoveOrganizationButton;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuFileGaspsExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuFileFgisEsnsiExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem mnuTableFgisEsnsiEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuTableFgisEsnsiRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem mnuContextFgisEsnsiEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton mnuTableFgisEsnsiEditButton;
        private System.Windows.Forms.ToolStripButton mnuTableFgisEsnsiRemoveButton;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsImportFgisEsnsi;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsServise;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsCreateNewVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuTableFgisEsnsiCloneToLast;
        private System.Windows.Forms.ToolStripMenuItem mnuContextFgisEsnsiCloneToLast;
        private System.Windows.Forms.ToolStripButton mnuTableFgisEsnsiCloneToLastButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem mnuContextUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton mnuTableRefreshButton;
        private System.Windows.Forms.ToolStripMenuItem mnuFileErvkExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsEditError;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsFillLogEditDateGasps;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsFillLogEditDateFgisEsnsi;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsFillLogEditDateErvk;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem mnuTableErvkEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuTableErvkCloneToLast;
        private System.Windows.Forms.ToolStripMenuItem mnuTableErvkRemove;
        private System.Windows.Forms.ToolStripButton mnuTableErvkEditButton;
        private System.Windows.Forms.ToolStripButton mnuTableErvkCloneToLastButton;
        private System.Windows.Forms.ToolStripButton mnuTableErvkRemoveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuContextErvkEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuContextErvkCloneToLast;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem16;
        private System.Windows.Forms.RadioButton filterErvkOnlyRadioButton;
        private System.Windows.Forms.RadioButton filterFgisEsnsiOnlyRadioButton;
        private System.Windows.Forms.RadioButton filterAllRadioButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem mnuFileFullExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem mnuFileStatisticsExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExportForGasps;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsClearCode;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsImportSubdivision;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem19;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsExpLawAgenceEdit;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsTableEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem20;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsInitializeRtkTables;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem21;
		private System.Windows.Forms.ToolStripMenuItem mnuTableUrpEdit;
		private System.Windows.Forms.ToolStripMenuItem mnuTableUrpCloneToLast;
		private System.Windows.Forms.ToolStripMenuItem mnuTableUrpRemove;
		private System.Windows.Forms.ToolStripMenuItem mnuContextUrpEdit;
		private System.Windows.Forms.ToolStripMenuItem mnuContextUrpCloneToLast;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem22;
		private System.Windows.Forms.ToolStripButton mnuTableUrpEditButton;
		private System.Windows.Forms.ToolStripButton mnuTableUrpCloneToLastButton;
		private System.Windows.Forms.ToolStripButton mnuTableUrpRemoveButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsFillRtkUrpTable;
		private System.Windows.Forms.ToolStrip additionalToolStripBar;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.ToolStripButton toolStripButton10;
		private System.Windows.Forms.ToolStripButton toolStripButton11;
		private System.Windows.Forms.ToolStripButton toolStripButton12;
		private System.Windows.Forms.ToolStripButton toolStripButton13;
		private System.Windows.Forms.ToolStripButton toolStripButton14;
		private System.Windows.Forms.ToolStripButton toolStripButton15;
		private System.Windows.Forms.ToolStripButton toolStripButton16;
		private System.Windows.Forms.ToolStripButton toolStripButton17;
		private System.Windows.Forms.ToolStripButton toolStripButton18;
		private System.Windows.Forms.ToolStripButton toolStripButton19;
		private System.Windows.Forms.ToolStripButton toolStripButton20;
		private System.Windows.Forms.ToolStripButton toolStripButton21;
		private System.Windows.Forms.ToolStripButton toolStripButton22;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem mnuFileExportDelta;
	}
}