using DatabaseToolSuite.Services;
using System;
using System.Reflection;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    public partial class AppForm : Form
    {

        public AppForm()
        {
            InitializeComponent();

            this.Text = Const.App.APP_CAPTION + 
                string.Format(" - Версия {0}",  Assembly.GetExecutingAssembly().GetName().Version.ToString());

            DisableControl();

            if (Services.FileSystem.DefaultDatabaseFileExists())
                Services.FileSystem.ReadDatabase();

            gaspsListView.DataSet = Services.FileSystem.Repository.DataSet;

            filterOkatoComboBox.InitializeSource(Services.FileSystem.Repository.DataSet.okato);
            filterAuthorityComboBox.InitializeSource(Services.FileSystem.Repository.DataSet.authority);
            rowCountStatusLabel.Text = string.Format("Отражено записей {0}", gaspsListView.RowCount);
        }

        private void DisableControl()
        {
            selectedRowStatusLabel.Text = string.Empty;

            mnuTableCreateOrganization.Enabled = false;
            mnuContextCreateOrganization.Enabled = false;
            tableCreateOrganizationButton.Enabled = false;

            mnuTableCreateNewVersion.Enabled = false;
            mnuContextCreateNewVersion.Enabled = false;
            tableCreateNewVersionButton.Enabled = false;
            mnuToolsCreateNewVersion.Enabled = false;

            mnuTableRemoveOrganization.Enabled = false;
            mnuContextRemoveOrganization.Enabled = false;
            tableRemoveOrganizationButton.Enabled = false;

            mnuTableEditError.Enabled = false;
            mnuContextEditError.Enabled = false;
            mnuToolsEditError.Enabled = false;

            mnuTableFgisEsnsiEdit.Enabled = false;
            mnuContextFgisEsnsiEdit.Enabled = false;
            mnuTableFgisEsnsiEditButton.Enabled = false;

            mnuTableFgisEsnsiCloneToLast.Enabled = false;
            mnuContextFgisEsnsiCloneToLast.Enabled = false;
            mnuTableFgisEsnsiCloneToLastButton.Enabled = false;

            mnuTableFgisEsnsiRemove.Enabled = false;
            mnuTableFgisEsnsiRemoveButton.Enabled = false;
        }


        bool isFilter = true;

        private void Filter_ParametersChanged(object sender, EventArgs e)
        {
            if (isFilter)
            {
                gaspsListView.SetFilter(authority: filterAuthorityComboBox.Value,
                okato: filterOkatoComboBox.Code,
                code: filterCodeNumericTextBox.Text,
                name: filterNameTextBox.Text,
                unlockShow: true,
                reserveShow: true,
                lockShow: filterLockCodeViewCheckBox.Checked);
                rowCountStatusLabel.Text = string.Format("Отражено записей {0}", gaspsListView.RowCount);
           }
        }

        private void cleanFilterButton_Click(object sender, EventArgs e)
        {
            isFilter = false;
            filterAuthorityComboBox.Code = string.Empty;
            filterOkatoComboBox.Code = string.Empty;
            filterCodeNumericTextBox.Text = string.Empty;
            filterNameTextBox.Text = string.Empty;
            isFilter = true;

            gaspsListView.SetFilter(authority: filterAuthorityComboBox.Value,
               okato: filterOkatoComboBox.Code,
               code: filterCodeNumericTextBox.Text,
               name: filterNameTextBox.Text,
               unlockShow: true,
               reserveShow: true,
               lockShow: filterLockCodeViewCheckBox.Checked);
            rowCountStatusLabel.Text = string.Format("Отражено записей {0}", gaspsListView.RowCount);
        }

        private void gaspsListView_ItemSelectionChanged(object sender, EventArgs e)
        {
            if (gaspsListView.DataRow != null)
            {
                selectedRowStatusLabel.Text = gaspsListView.DataRow.code.ToString();
                mnuTableCreateOrganization.Enabled = true;
                mnuContextCreateOrganization.Enabled = true;
                tableCreateOrganizationButton.Enabled = true;

                mnuToolsEditError.Enabled = true;

                bool isLastVersion = FileSystem.Repository.DataSet.gasps.IsLastVersion(gaspsListView.DataRow.version);

                mnuTableCreateNewVersion.Enabled = isLastVersion;
                mnuContextCreateNewVersion.Enabled = isLastVersion;
                tableCreateNewVersionButton.Enabled = isLastVersion;

                mnuToolsCreateNewVersion.Enabled = true;

                mnuTableRemoveOrganization.Enabled = gaspsListView.DataRow.date_end > DateTime.Today;
                mnuContextRemoveOrganization.Enabled = gaspsListView.DataRow.date_end > DateTime.Today;
                tableRemoveOrganizationButton.Enabled = gaspsListView.DataRow.date_end > DateTime.Today;

                mnuTableEditError.Enabled = isLastVersion;
                mnuContextEditError.Enabled = isLastVersion;

                mnuTableFgisEsnsiEdit.Enabled = gaspsListView.DataRow.authority_id == 20;
                mnuContextFgisEsnsiEdit.Enabled = gaspsListView.DataRow.authority_id == 20;
                mnuTableFgisEsnsiEditButton.Enabled = gaspsListView.DataRow.authority_id == 20;

                bool existsFgisEsnsi = Services.FileSystem.Repository.DataSet.fgis_esnsi.ExistsRow(gaspsListView.DataRow.version);

                mnuTableFgisEsnsiCloneToLast.Enabled = !isLastVersion && existsFgisEsnsi;
                mnuContextFgisEsnsiCloneToLast.Enabled = !isLastVersion && existsFgisEsnsi;
                mnuTableFgisEsnsiCloneToLastButton.Enabled = !isLastVersion && existsFgisEsnsi;

                mnuTableFgisEsnsiRemove.Enabled = existsFgisEsnsi;
                mnuTableFgisEsnsiRemoveButton.Enabled = existsFgisEsnsi;
            }
            else
            {
                DisableControl();
            }
        }


        private void gaspsListView_ItemMouseClick(object sender, Controls.GaspsListViewEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuTable.Show(Cursor.Position);
            }
        }

        private void gaspsListView_ItemMouseDoubleClick(object sender, Controls.GaspsListViewEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (gaspsListView.SelectedOrganization != null)
                {
                    OrganizationViewDialog dialog = new OrganizationViewDialog(gaspsListView.SelectedOrganization);
                    dialog.ShowDialog(this);
                }
            }
        }

        private void TableNewOrganization_Click(object sender, EventArgs e)
        {
            CreateNewOrganizationDialog dialog = new CreateNewOrganizationDialog();
            dialog.DialogCaptionImage = Properties.Resources.New32;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                MasterDataSystem.CreateNewOrganization(
                    name: dialog.OrganizationName,
                    okato: dialog.OkatoCode,
                    authorityId: dialog.Authority.HasValue ? dialog.Authority.Value : 0,
                    code: dialog.Code,
                    ownerKey: dialog.OrganizationOwner,
                    dateBegin: dialog.BeginDate,
                    dateEnd: Services.MasterDataSystem.MAX_DATE,
                    courtTypeId: dialog.CourtType);
                gaspsListView.UpdateListViewItem();
            }
        }

        private void TableCreateOrganization_Click(object sender, EventArgs e)
        {
            CreateNewOrganizationDialog dialog = new CreateNewOrganizationDialog(gaspsListView.DataRow);
            dialog.DialogCaptionImage = Properties.Resources.NewSeries32;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                MasterDataSystem.CreateNewOrganization(
                    name: dialog.OrganizationName,
                    okato: dialog.OkatoCode,
                    authorityId: dialog.Authority.HasValue ? dialog.Authority.Value : 0,
                    code: dialog.Code,
                    ownerKey: dialog.OrganizationOwner,
                    dateBegin: dialog.BeginDate,
                    dateEnd: Services.MasterDataSystem.MAX_DATE,
                    courtTypeId: dialog.CourtType);
                gaspsListView.UpdateListViewItem();
            }
        }

        private void TableCreateVersion_Click(object sender, EventArgs e)
        {
            CreateNewVersionDialog dialog = new CreateNewVersionDialog(gaspsListView.DataRow);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                long version = gaspsListView.DataRow.version;
                MasterDataSystem.CreateNewVersionOrganization(
                    version: version, 
                    date: dialog.BeginDate,
                    name: dialog.OrganizationName,
                    okato: dialog.OkatoCode,
                    authorityId: dialog.Authority.HasValue ? dialog.Authority.Value: 0,
                    ownerKey: dialog.OrganizationOwner,
                    courtTypeId: dialog.CourtType);
                gaspsListView.UpdateListViewItem();
            }
        }

        private void TableRemoveOrganization_Click(object sender, EventArgs e)
        {
            RemoveOrganizationDialog dialog = new RemoveOrganizationDialog(gaspsListView.DataRow);
            if (dialog.ShowDialog(this)== DialogResult.OK)
            {
                long version = gaspsListView.DataRow.version;
                MasterDataSystem.RemoveOrganization(version: version, date: dialog.LockDate);
                gaspsListView.UpdateListViewItem();
            }
        }


        private void TableEditError_Click(object sender, EventArgs e)
        {
            EditErrorDialog dialog = new EditErrorDialog(gaspsListView.DataRow);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                long version = gaspsListView.DataRow.version;
                MasterDataSystem.EditVersionOrganization(
                    version: version,
                    date: dialog.BeginDate,
                    name: dialog.OrganizationName,
                    okato: dialog.OkatoCode,
                    authorityId: dialog.Authority.HasValue ? dialog.Authority.Value : 0,
                    ownerKey: dialog.OrganizationOwner,
                    courtTypeId: dialog.CourtType);
                gaspsListView.UpdateListViewItem();
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (FileSystem.Repository.DataSet.HasChanges())
                {
                    DialogResult result = MessageBox.Show("Вы хотите сохранить изменения?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        FileSystem.WriteDatabase();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }                
            }
            else
            {
                if (FileSystem.Repository.DataSet.HasChanges())
                {
                    FileSystem.RescueDatabase();
                }
            }
        }

        private void HelpStatistic_Click(object sender, EventArgs e)
        {
            StatisticsDialog dialog = new StatisticsDialog();
            dialog.ShowDialog(this);

            //MessageBox.Show("Всего добавлено/изменено/заблокировано в 2023 году записей: " + 
            //    Services.FileSystem.Repository.DataSet.gasps.GetEditedRowCount().ToString(), "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FileOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Открыть данные";
            dialog.Multiselect = false;
            dialog.Filter = "Документ XML(.xml)|*.xml|XML Schema File(.xsd)|*.xsd";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                {
                    FileSystem.ReadDatabase(dialog.FileName);
                }
                else
                {
                    FileSystem.ReadSchema(dialog.FileName);
                }

                gaspsListView.DataSet = FileSystem.Repository.DataSet;

                filterOkatoComboBox.InitializeSource(FileSystem.Repository.DataSet.okato);
                filterAuthorityComboBox.InitializeSource(FileSystem.Repository.DataSet.authority);
                rowCountStatusLabel.Text = string.Format("Отражено записей {0}", gaspsListView.RowCount);
            }
        }

        private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FileSystem.DatabaseFileName))
            {
                FileSaveAs();
            }
            else
            {
                FileSystem.WriteDatabase();
            }
        }

        private void FileSaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveAs();
        }

        private void FileSaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Сохранить данные";
            dialog.Filter = "Документ XML(.xml)|*.xml|XML Schema File(.xsd)|*.xsd";
            dialog.FileName = string.IsNullOrWhiteSpace(FileSystem.DatabaseFileName) ? "gasps.xml": FileSystem.DatabaseFileName;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                {
                    FileSystem.WriteDatabase(dialog.FileName);
                }
                else
                {
                    FileSystem.WriteSchema(dialog.FileName);
                }
            }
        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog(this);
        }

        private void FileImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Импортировать данные";
            dialog.Multiselect = false;
            dialog.Filter = "Текстовый документ (.txt)|*.txt";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                {
                    Impors.ImportTextFile(dialog.FileName);
                }
                else
                {

                }
            }
        }

        private void FileExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Экспортировать данные";
            dialog.Filter = "Документ XML(.xml)|*.xml|Файл Microsoft Excel, содержащий значения, разделенные запятыми (.csv)|*.csv";
            dialog.FileName = "export";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                {
                    Export.ExportToXml(dialog.FileName);
                } else if (dialog.FilterIndex == 2)
                {
                    Export.ExportFgisEsnsiToCsv(dialog.FileName);
                }
            }
        }

        private void FileExportGaspsToExcel_Click(object sender, EventArgs e)
        {
            Export.ExportGaspsToExcel();
        }

        private void FileFgisEsnsiExportToExcel_Click(object sender, EventArgs e)
        {
            Export.ExportFgisEsnsiToExcel();
        }

        private void mnuFileErknmExportToExcel_Click(object sender, EventArgs e)
        {
            Export.ExportGaspsToExcel2();
        }


        private void AppForm_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            Width = Properties.Settings.Default.AppWindowWidth;
            Height = Properties.Settings.Default.AppWindowHight;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.AppWindowWidth = Width;
                Properties.Settings.Default.AppWindowHight = Height;
                Properties.Settings.Default.Save();
            }
            base.OnFormClosed(e);
        }

        private void AppForm_Resize(object sender, EventArgs e)
        {
            filterPanel.Location = new System.Drawing.Point(2, mainToolStripBar.Top + mainToolStripBar.Height);
            filterPanel.Width = ClientSize.Width - 4;
            gaspsListView.Location = new System.Drawing.Point(filterPanel.Left + filterGroupBox.Left, filterPanel.Top + filterPanel.Height);
            gaspsListView.Width = ClientSize.Width - (filterPanel.Left + filterGroupBox.Left) * 2;
            gaspsListView.Height = statusStrip1.Top - gaspsListView.Top - filterPanel.Left;
        }

        private void FgisEsnsiEdit_Click(object sender, EventArgs e)
        {
            FgisEsnsiEdit();
        }

        private void FgisEsnsiRemove_Click(object sender, EventArgs e)
        {
            if (gaspsListView.DataRow != null && gaspsListView.DataRow.authority_id == 20)
            {
                if (MasterDataSystem.DataSet.fgis_esnsi.ExistsRow(gaspsListView.DataRow.version))
                {
                    MasterDataSystem.DataSet.fgis_esnsi.Romove(gaspsListView.DataRow.version);
                }

                bool existsFgisEsnsi = FileSystem.Repository.DataSet.fgis_esnsi.ExistsRow(gaspsListView.DataRow.version);

                mnuTableFgisEsnsiRemove.Enabled = existsFgisEsnsi;
                mnuTableFgisEsnsiRemoveButton.Enabled = existsFgisEsnsi;
                gaspsListView.UpdateListViewItem();
            }
        }
    

        private void FgisEsnsiEdit()
        {
            if (gaspsListView.DataRow !=null && gaspsListView.DataRow.authority_id == 20)
            {
                fgis_esnsiRow editRow;

                if (MasterDataSystem.DataSet.fgis_esnsi.ExistsRow(gaspsListView.DataRow.version))
                {
                    editRow = MasterDataSystem.DataSet.fgis_esnsi.Get(gaspsListView.DataRow.version);
                }
                else
                {
                    editRow = MasterDataSystem.DataSet.fgis_esnsi.Create(gaspsListView.DataRow.version);
                }

                EsnsiDialog dialog = new EsnsiDialog(gaspsListView.DataRow, editRow);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    editRow.autokey = dialog.Autokey;
                    editRow.code = dialog.Code;
                    editRow.id = dialog.Id;
                    editRow.okato = (short)dialog.OkatoCode;
                    editRow.region_id = dialog.RegionCode;
                    editRow.sv_0004 = dialog.Phone;
                    editRow.sv_0005 = dialog.Email;
                    editRow.sv_0006 = dialog.Address;
                    gaspsListView.UpdateListViewItem();
                }
            }
        }

        private void FgisEsnsiCloneToLast_Click(object sender, EventArgs e)
        {
            if (MasterDataSystem.DataSet.fgis_esnsi.ExistsRow(gaspsListView.DataRow.version))
            {
                fgis_esnsiRow currentRow = MasterDataSystem.DataSet.fgis_esnsi.Get(gaspsListView.DataRow.version);
               if ( MasterDataSystem.CloneFgisEsnsiNoteToLastVersion(currentRow.version) != null)
                {
                    MessageBox.Show(this, "Данные ФГСИ ЕСНСИ успешно скопированы в действующую запись!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
               else
                {
                    MessageBox.Show(this, "Не удалось скопировать данные ФГСИ ЕСНСИ!" + Environment.NewLine + "Вероятно в действующей записи уже имеются сведения.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ToolsImportFgisEsnsi_Click(object sender, EventArgs e)
        {
            Utils.Dialogs.ImportDialog dialog = new Utils.Dialogs.ImportDialog();
            dialog.ShowDialog(this);
        }                
    }
}
