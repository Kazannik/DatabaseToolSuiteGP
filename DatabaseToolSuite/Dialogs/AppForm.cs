using DatabaseToolSuite.Services;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	public partial class AppForm : Form
	{
		public AppForm()
		{
			InitializeComponent();

			this.Text = Const.App.APP_CAPTION +
				string.Format(" - Версия {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

			DisableControl();

			if (FileSystem.DefaultDatabaseFileExists())
				FileSystem.ReadDatabase();

			gaspsListView.DataSet = FileSystem.Repository.MainDataSet;

			filterOkatoComboBox.InitializeSource(FileSystem.Repository.MainDataSet.okato);
			filterAuthorityComboBox.InitializeSource(FileSystem.Repository.MainDataSet.authority);
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

			mnuTableErvkEdit.Enabled = false;
			mnuContextErvkEdit.Enabled = false;
			mnuTableErvkEditButton.Enabled = false;

			mnuTableErvkCloneToLast.Enabled = false;
			mnuContextErvkCloneToLast.Enabled = false;
			mnuTableErvkCloneToLastButton.Enabled = false;

			mnuTableErvkRemove.Enabled = false;
			mnuTableErvkRemoveButton.Enabled = false;

			mnuTableUrpEdit.Enabled = false;
			mnuContextUrpEdit.Enabled = false;
			mnuTableUrpEditButton.Enabled = false;

			mnuTableUrpCloneToLast.Enabled = false;
			mnuContextUrpCloneToLast.Enabled = false;
			mnuTableUrpCloneToLastButton.Enabled = false;

			mnuTableUrpRemove.Enabled = false;
			mnuTableUrpRemoveButton.Enabled = false;

			mnuToolsClearCode.Enabled = false;
		}

		private bool isFilter = true;

		private void Filter_ParametersChanged(object sender, EventArgs e)
		{
			if (isFilter)
			{
				gaspsListView.FilterAsync(authority: filterAuthorityComboBox.Value,
				okato: filterOkatoComboBox.Code,
				code: filterCodeNumericTextBox.Text,
				name: filterNameTextBox.Text,
				unlockShow: true,
				reserveShow: true,
				lockShow: filterLockCodeViewCheckBox.Checked,
				fgisEsnsiOnlyShow: filterFgisEsnsiOnlyRadioButton.Checked,
				ervkOnlyShow: filterErvkOnlyRadioButton.Checked);
			}
		}

		private void CleanFilterButton_Click(object sender, EventArgs e)
		{
			isFilter = false;
			filterAuthorityComboBox.Code = string.Empty;
			filterOkatoComboBox.Code = string.Empty;
			filterCodeNumericTextBox.Text = string.Empty;
			filterNameTextBox.Text = string.Empty;
			isFilter = true;

			gaspsListView.FilterAsync(authority: filterAuthorityComboBox.Value,
			   okato: filterOkatoComboBox.Code,
			   code: filterCodeNumericTextBox.Text,
			   name: filterNameTextBox.Text,
			   unlockShow: true,
			   reserveShow: true,
			   lockShow: filterLockCodeViewCheckBox.Checked,
			   fgisEsnsiOnlyShow: filterFgisEsnsiOnlyRadioButton.Checked,
			   ervkOnlyShow: filterErvkOnlyRadioButton.Checked);
		}

		private void GaspsListView_ItemSelectionChanged(object sender, EventArgs e)
		{
			if (gaspsListView.DataRow != null)
			{
				selectedRowStatusLabel.Text = string.IsNullOrEmpty(gaspsListView.DataRow.code) ? string.Empty : gaspsListView.DataRow.code;
				mnuTableCreateOrganization.Enabled = true;
				mnuContextCreateOrganization.Enabled = true;
				tableCreateOrganizationButton.Enabled = true;

				mnuToolsEditError.Enabled = true;

				bool isLastVersion = FileSystem.Repository.MainDataSet.gasps.IsLastVersion(gaspsListView.DataRow.version);

				mnuTableCreateNewVersion.Enabled = isLastVersion;
				mnuContextCreateNewVersion.Enabled = isLastVersion;
				tableCreateNewVersionButton.Enabled = isLastVersion;

				mnuToolsCreateNewVersion.Enabled = true;

				mnuTableRemoveOrganization.Enabled = gaspsListView.DataRow.date_end.Date > DateTime.Today;
				mnuContextRemoveOrganization.Enabled = gaspsListView.DataRow.date_end.Date > DateTime.Today;
				tableRemoveOrganizationButton.Enabled = gaspsListView.DataRow.date_end.Date > DateTime.Today;

				mnuTableEditError.Enabled = isLastVersion;
				mnuContextEditError.Enabled = isLastVersion;

				mnuTableFgisEsnsiEdit.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;
				mnuContextFgisEsnsiEdit.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;
				mnuTableFgisEsnsiEditButton.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;

				mnuTableErvkEdit.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;
				mnuContextErvkEdit.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;
				mnuTableErvkEditButton.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;

				mnuTableUrpEdit.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;
				mnuContextUrpEdit.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;
				mnuTableUrpEditButton.Enabled = gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE;

				bool existsFgisEsnsi = FileSystem.Repository.MainDataSet.fgis_esnsi.Exists(gaspsListView.DataRow.version);

				mnuTableFgisEsnsiCloneToLast.Enabled = !isLastVersion && existsFgisEsnsi;
				mnuContextFgisEsnsiCloneToLast.Enabled = !isLastVersion && existsFgisEsnsi;
				mnuTableFgisEsnsiCloneToLastButton.Enabled = !isLastVersion && existsFgisEsnsi;

				mnuTableFgisEsnsiRemove.Enabled = existsFgisEsnsi;
				mnuTableFgisEsnsiRemoveButton.Enabled = existsFgisEsnsi;

				bool existsErvk = FileSystem.Repository.MainDataSet.ervk.Exists(gaspsListView.DataRow.version);

				mnuTableErvkCloneToLast.Enabled = !isLastVersion && existsErvk;
				mnuContextErvkCloneToLast.Enabled = !isLastVersion && existsErvk;
				mnuTableErvkCloneToLastButton.Enabled = !isLastVersion && existsErvk;

				mnuTableErvkRemove.Enabled = existsErvk;
				mnuTableErvkRemoveButton.Enabled = existsErvk;

				bool existsUrp = FileSystem.Repository.MainDataSet.EXP_LAW_AGENCY_URP.Exists(gaspsListView.DataRow.version);

				mnuTableUrpCloneToLast.Enabled = !isLastVersion && existsUrp;
				mnuContextUrpCloneToLast.Enabled = !isLastVersion && existsUrp;
				mnuTableUrpCloneToLastButton.Enabled = !isLastVersion && existsUrp;

				mnuTableUrpRemove.Enabled = existsUrp;
				mnuTableUrpRemoveButton.Enabled = existsUrp;

				mnuToolsClearCode.Enabled = !gaspsListView.DataRow.IscodeNull();
			}
			else
			{
				DisableControl();
			}
		}

		private void GaspsListView_ItemMouseClick(object sender, Controls.GaspsListViewEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				contextMenuTable.Show(Cursor.Position);
			}
		}

		private void GaspsListView_ItemMouseDoubleClick(object sender, Controls.GaspsListViewEventArgs e)
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

		private void NewOrganization_Click(object sender, EventArgs e)
		{
			CreateNewOrganizationDialog dialog = new CreateNewOrganizationDialog
			{
				DialogCaptionImage = Properties.Resources.New32
			};
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				MasterDataSystem.CreateNewOrganization(
					name: dialog.OrganizationName,
					okato: dialog.OkatoCode,
					authorityId: dialog.Authority ?? 0,
					code: dialog.Code,
					ownerKey: dialog.OrganizationOwner,
					dateBegin: dialog.BeginDate,
					dateEnd: Services.MasterDataSystem.MAX_DATE,
					courtTypeId: dialog.CourtType);
				gaspsListView.UpdateListViewItem();
			}
		}

		private void CreateOrganization_Click(object sender, EventArgs e)
		{
			CreateNewOrganizationDialog dialog = new CreateNewOrganizationDialog(gaspsListView.DataRow)
			{
				DialogCaptionImage = Properties.Resources.NewSeries32
			};
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				MasterDataSystem.CreateNewOrganization(
					name: dialog.OrganizationName,
					okato: dialog.OkatoCode,
					authorityId: dialog.Authority ?? 0,
					code: dialog.Code,
					ownerKey: dialog.OrganizationOwner,
					dateBegin: dialog.BeginDate,
					dateEnd: Services.MasterDataSystem.MAX_DATE,
					courtTypeId: dialog.CourtType);
				gaspsListView.UpdateListViewItem();
			}
		}

		private void CreateVersion_Click(object sender, EventArgs e)
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
					authorityId: dialog.Authority ?? 0,
					ownerKey: dialog.OrganizationOwner,
					courtTypeId: dialog.CourtType);
				gaspsListView.UpdateListViewItem();
			}
		}

		private void RemoveOrganization_Click(object sender, EventArgs e)
		{
			RemoveOrganizationDialog dialog = new RemoveOrganizationDialog(gaspsListView.DataRow);
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				long version = gaspsListView.DataRow.version;
				MasterDataSystem.RemoveOrganization(version: version, date: dialog.LockDate);
				gaspsListView.UpdateListViewItem();
			}
		}

		private void EditError_Click(object sender, EventArgs e)
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
					authorityId: dialog.Authority ?? 0,
					ownerKey: dialog.OrganizationOwner,
					courtTypeId: dialog.CourtType);
				gaspsListView.UpdateListViewItem();
			}
		}

		private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				if (FileSystem.Repository.MainDataSet.HasChanges())
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
				if (FileSystem.Repository.MainDataSet.HasChanges())
				{
					FileSystem.RescueDatabase();
				}
			}
		}

		private void HelpStatistic_Click(object sender, EventArgs e)
		{
			StatisticsDialog dialog = new StatisticsDialog();
			dialog.ShowDialog(this);
		}

		private void FileOpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog
			{
				Title = "Открыть данные",
				Multiselect = false,
				Filter = "Документ XML(.xml)|*.xml|XML Schema File(.xsd)|*.xsd"
			};
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

				gaspsListView.DataSet = FileSystem.Repository.MainDataSet;

				filterOkatoComboBox.InitializeSource(FileSystem.Repository.MainDataSet.okato);
				filterAuthorityComboBox.InitializeSource(FileSystem.Repository.MainDataSet.authority);
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
			SaveFileDialog dialog = new SaveFileDialog
			{
				Title = "Сохранить данные",
				Filter = "Документ XML(.xml)|*.xml|XML Schema File(.xsd)|*.xsd",
				FileName = string.IsNullOrWhiteSpace(FileSystem.DatabaseFileName) ? "gasps.xml" : FileSystem.DatabaseFileName
			};
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
			OpenFileDialog dialog = new OpenFileDialog
			{
				Title = "Импортировать данные",
				Multiselect = false,
				Filter = "Текстовый документ (.txt)|*.txt"
			};
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				if (dialog.FilterIndex == 1)
				{
					Import.ImportTextFile(dialog.FileName);
				}
				else
				{
				}
			}
		}

		private void FileExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog
			{
				Title = "Экспортировать данные",
				Filter = "Документ XML(.xml)|*.xml|" +
				"Файл Microsoft Excel, содержащий значения ЕСНСИ, разделенные запятыми (.csv)|*.csv|" +
				"Файл Microsoft Excel, содержащий значения ЕРВК, разделенные запятыми (.csv)|*.csv|" +
				"База данных ГАС ПС в формате XML(.xml)|*.xml",
				FileName = "FED_GENPROK_ORGANIZATION_Cp1251"
			};
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				if (dialog.FilterIndex == 1)
				{
					Export.ExportToXml(dialog.FileName);
				}
				else if (dialog.FilterIndex == 2)
				{
					Export.ExportFgisEsnsiToCsv(dialog.FileName);
				}
				else if (dialog.FilterIndex == 3)
				{
					Export.ExportErvkToCsv(dialog.FileName);
				}
			}
		}

		private void FileExportForGasps_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog
			{
				Title = "Экспорт данных для ГАС ПС",
				Filter = "Документ XML(.xml)|*.xml",
				FileName = "EXP_LAW_AGENCY"
			};
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				Rtk.ConvertDataBase();
				Rtk.ExportToXml(dialog.FileName);
				MessageBox.Show(dialog.Title + " успешно выполнен!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void ToolsImportSubdivision_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog
			{
				Title = "Импорт данных из кадров 1С",
				Filter = "Документ XML(*.xml)|*.xml",
				FileName = "get_subdivision"
			};
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				FileSystem.Repository.SubdivisionsReadXml(dialog.FileName);
				ImportSubdivisionDialog subdivisionDialog = new ImportSubdivisionDialog();

				if (subdivisionDialog.ShowDialog(this) == DialogResult.OK)
				{
					Import.ImportSubdivision(subdivisionDialog.ParentVersion, subdivisionDialog.BeginDate, subdivisionDialog.SelectSubdivisions);
					gaspsListView.UpdateListViewItem();
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

		private void FileErvkExportToExcel_Click(object sender, EventArgs e)
		{
			Export.ExportErvkToExcel();
		}

		private void FileFullExportToExcel_Click(object sender, EventArgs e)
		{
			Export.ExportFullDataBaseToExcel();
		}

		private void FileStatisticsExportToExcel_Click(object sender, EventArgs e)
		{
			Export.ExportStatisticToExcel();
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

		#region FGIS ESNSI

		private void FgisEsnsiEdit_Click(object sender, EventArgs e)
		{
			FgisEsnsiEdit();
		}

		private void FgisEsnsiRemove_Click(object sender, EventArgs e)
		{
			if (gaspsListView.DataRow != null && gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				if (MasterDataSystem.DataSet.fgis_esnsi.Exists(gaspsListView.DataRow.version))
				{
					MasterDataSystem.DataSet.fgis_esnsi.Romove(gaspsListView.DataRow.version);
				}

				bool existsFgisEsnsi = FileSystem.Repository.MainDataSet.fgis_esnsi.Exists(gaspsListView.DataRow.version);

				mnuTableFgisEsnsiRemove.Enabled = existsFgisEsnsi;
				mnuTableFgisEsnsiRemoveButton.Enabled = existsFgisEsnsi;
				gaspsListView.UpdateListViewItem();
			}
		}

		private void FgisEsnsiCloneToLast_Click(object sender, EventArgs e)
		{
			if (MasterDataSystem.DataSet.fgis_esnsi.Exists(gaspsListView.DataRow.version))
			{
				Repositoryes.MainDataSet.fgis_esnsiRow currentRow = MasterDataSystem.DataSet.fgis_esnsi.Get(gaspsListView.DataRow.version);
				if (MasterDataSystem.CloneFgisEsnsiNoteToLastVersion(currentRow.version) != null)
				{
					MessageBox.Show(this, "Данные ФГСИ ЕСНСИ успешно скопированы в действующую запись!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(this, "Не удалось скопировать данные ФГСИ ЕСНСИ!" + Environment.NewLine + "Вероятно в действующей записи уже имеются сведения.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void FgisEsnsiEdit()
		{
			if (gaspsListView.DataRow != null && gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				Repositoryes.MainDataSet.fgis_esnsiRow editRow;
				bool createdRow = false;

				if (MasterDataSystem.DataSet.fgis_esnsi.Exists(gaspsListView.DataRow.version))
				{
					editRow = MasterDataSystem.DataSet.fgis_esnsi.Get(gaspsListView.DataRow.version);
				}
				else
				{
					editRow = MasterDataSystem.DataSet.fgis_esnsi.Create(gaspsListView.DataRow.version);
					createdRow = true;
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
				else
				{
					if (createdRow)
					{
						editRow.Delete();
					}
					else
					{
						editRow.CancelEdit();
					}
				}
			}
		}

		#endregion FGIS ESNSI

		#region ERVK

		private void ErvkEdit_Click(object sender, EventArgs e)
		{
			ErvkEdit();
		}

		private void ErvkCloneToLast_Click(object sender, EventArgs e)
		{
			if (MasterDataSystem.DataSet.ervk.Exists(gaspsListView.DataRow.version))
			{
				Repositoryes.MainDataSet.ervkRow currentRow = MasterDataSystem.DataSet.ervk.Get(gaspsListView.DataRow.version);
				if (MasterDataSystem.CloneErvkNoteToLastVersion(currentRow.version) != null)
				{
					MessageBox.Show(this, "Данные ЕРВК успешно скопированы в действующую запись!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(this, "Не удалось скопировать данные ЕРВК!" + Environment.NewLine + "Вероятно в действующей записи уже имеются сведения.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void ErvkRemove_Click(object sender, EventArgs e)
		{
			if (gaspsListView.DataRow != null && gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				if (MasterDataSystem.DataSet.ervk.Exists(gaspsListView.DataRow.version))
				{
					MasterDataSystem.DataSet.ervk.Romove(gaspsListView.DataRow.version);
				}

				bool existsErvk = FileSystem.Repository.MainDataSet.ervk.Exists(gaspsListView.DataRow.version);

				mnuTableErvkRemove.Enabled = existsErvk;
				mnuTableErvkRemoveButton.Enabled = existsErvk;
				gaspsListView.UpdateListViewItem();
			}
		}

		private void ErvkEdit()
		{
			if (gaspsListView.DataRow != null && gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				Repositoryes.MainDataSet.ervkRow editRow;
				bool createdRow = false;

				if (MasterDataSystem.DataSet.ervk.Exists(gaspsListView.DataRow.version))
				{
					editRow = MasterDataSystem.DataSet.ervk.Get(gaspsListView.DataRow.version);
				}
				else
				{
					editRow = MasterDataSystem.DataSet.ervk.Create(gaspsListView.DataRow.version);
					editRow.dateStartVersion = gaspsListView.DataRow.date_beg;
					createdRow = true;
				}

				ErvkDialog dialog = new ErvkDialog(editRow);
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					if (dialog.DateCloseProc != MasterDataSystem.MAX_DATE)
					{
						editRow.dateCloseProc = dialog.DateCloseProc > MasterDataSystem.MAX_DATE ? MasterDataSystem.MAX_DATE : dialog.DateCloseProc;
					}
					else
					{
						editRow.SetdateCloseProcNull();
					}

					if (editRow.dateStartVersion < MasterDataSystem.MIN_DATE)
					{
						editRow.dateStartVersion = MasterDataSystem.MIN_DATE;
					}
					else
					{
						editRow.dateStartVersion = dialog.DateStartVersion;
					}

					if (dialog.IdVersionHead <= 0)
					{
						editRow.SetidVersionHeadNull();
					}
					else
					{
						editRow.idVersionHead = dialog.IdVersionHead;
					}

					editRow.inn = dialog.Inn;
					editRow.isActive = dialog.IsActive;
					editRow.isHead = dialog.IsHead;
					editRow.military = dialog.IsMilitary;
					editRow.ogrn = dialog.Ogrn;
					editRow.special = dialog.IsSpecial;

					Utils.Database.SetIsHeadAttribute();

					gaspsListView.UpdateListViewItem();
				}
				else
				{
					if (createdRow)
					{
						editRow.Delete();
					}
					else
					{
						editRow.CancelEdit();
					}
				}
			}
		}

		#endregion ERVK

		#region URP

		private void UrpEdit_Click(object sender, EventArgs e)
		{
			UrpEdit();
		}

		private void UrpCloneToLast_Click(object sender, EventArgs e)
		{
			if (MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Exists(gaspsListView.DataRow.version))
			{
				Repositoryes.MainDataSet.EXP_LAW_AGENCY_URPRow currentRow = MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Get(gaspsListView.DataRow.version);
				if (MasterDataSystem.CloneUrpNoteToLastVersion(currentRow.VERSION) != null)
				{
					MessageBox.Show(this, "Данные УРП ГАС ПС успешно скопированы в действующую запись!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(this, "Не удалось скопировать данные УРП ГАС ПС!" + Environment.NewLine + "Вероятно в действующей записи уже имеются сведения.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void UrpRemove_Click(object sender, EventArgs e)
		{
			if (gaspsListView.DataRow != null && gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				if (MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Exists(gaspsListView.DataRow.version))
				{
					MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Romove(gaspsListView.DataRow.version);
				}

				bool existsUrp = FileSystem.Repository.MainDataSet.ervk.Exists(gaspsListView.DataRow.version);

				mnuTableUrpRemove.Enabled = existsUrp;
				mnuTableUrpRemoveButton.Enabled = existsUrp;
				gaspsListView.UpdateListViewItem();
			}
		}

		private void UrpEdit()
		{
			if (gaspsListView.DataRow != null && gaspsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				Repositoryes.MainDataSet.EXP_LAW_AGENCY_URPRow editRow;
				bool createdRow = false;

				if (MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Exists(gaspsListView.DataRow.version))
				{
					editRow = MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Get(gaspsListView.DataRow.version);
				}
				else
				{
					editRow = MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Create(gaspsListView.DataRow.version, gaspsListView.DataRow.name, gaspsListView.DataRow.okatoRow.export_id);
					createdRow = true;
				}

				UrpDialog dialog = new UrpDialog(editRow, createdRow);
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					editRow.DOESNT_CONSOLIDATE_CHILD = dialog.DoesntConsolidateChild;
					editRow.DOESNT_CREATE_CARD = dialog.DoesntCreateCard;
					editRow.DOESNT_SIGN_REPORT = dialog.DoesntSingReport;
					editRow.AGENCY_RECEIVING_REPORT = dialog.AgencyReceivingReport;
					editRow.LAW_AGENCY_TYPE = dialog.LawAgencyType;
					editRow.OKTMO_LOC_ID = dialog.OktmoLocId;
					editRow.SHORT_NAME = dialog.ShortName;
					editRow.VED_CODE = dialog.VedCode;
					if (dialog.SpecialTerritorialCode > 0)
					{
						editRow.SPECIAL_TERRITORIAL_CODE = dialog.SpecialTerritorialCode;
					}
					else
					{
						editRow.SetSPECIAL_TERRITORIAL_CODENull();
					}

					Utils.Database.SetIsHeadAttribute();

					gaspsListView.UpdateListViewItem();
				}
				else
				{
					if (createdRow)
					{
						editRow.Delete();
					}
					else
					{
						editRow.CancelEdit();
					}
				}
			}
		}

		#endregion URP

		private void ToolsImportFgisEsnsi_Click(object sender, EventArgs e)
		{
			Utils.Dialogs.ImportDialog dialog = new Utils.Dialogs.ImportDialog();
			dialog.ShowDialog(this);
		}

		private void ToolsFillLogEditDateGasps_Click(object sender, EventArgs e)
		{
			Utils.Database.FillLogEditDateInGasps();
			MessageBox.Show(this, "Данные ГАС ПС успешно дополнены журналом редактирования", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ToolsFillLogEditDateFgisEsnsi_Click(object sender, EventArgs e)
		{
			Utils.Database.FillLogEditDateInFgisEsnsi();
			MessageBox.Show(this, "Данные ФГИС ЕСНСИ успешно дополнены журналом редактирования", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ToolsFillLogEditDateErvk_Click(object sender, EventArgs e)
		{
			Utils.Database.FillLogEditDateInErvk();
			MessageBox.Show(this, "Данные ЕРВК успешно дополнены журналом редактирования", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void GaspsListView_GaspsListViewCompleted(object sender, Controls.GaspsListViewCompletedEventArgs e)
		{
			rowCountStatusLabel.Text = string.Format("Отражено записей {0}", gaspsListView.RowCount);
		}

		private void gaspsListView_ItemSelectionChanged(object sender, EventArgs e)
		{
		}

		private void gaspsListView_ItemMouseClick(object sender, Controls.GaspsListViewEventArgs e)
		{
		}

		private void gaspsListView_ItemMouseDoubleClick(object sender, Controls.GaspsListViewEventArgs e)
		{
		}

		private void gaspsListView_GaspsListViewCompleted(object sender, Controls.GaspsListViewCompletedEventArgs e)
		{
		}

		private void ToolsClearCode_Click(object sender, EventArgs e)
		{
			if (gaspsListView.SelectedOrganization != null)
			{
				MasterDataSystem.ClearCodeVersionOrganization(gaspsListView.SelectedOrganization.Version);
				gaspsListView.UpdateListViewItem();
			}
		}

		private void ToolsExpLawAgenceEdit_Click(object sender, EventArgs e)
		{
			ExpLawAgencyForm frm = new ExpLawAgencyForm();
			frm.ShowDialog(this);
		}

		private void ToolsTableEdit_Click(object sender, EventArgs e)
		{
			TableEditor tableEditor = new TableEditor();
			tableEditor.ShowDialog(this);
		}

		private void ToolsInitializeRtkTables_Click(object sender, EventArgs e)
		{
			Utils.Database.InitializeTables();
			gaspsListView.UpdateListViewItem();
		}

		private void ToolsFillRtkUrpTable_Click(object sender, EventArgs e)
		{
			Utils.Database.FillUrpInGasps();
			gaspsListView.UpdateListViewItem();
		}
	}
}