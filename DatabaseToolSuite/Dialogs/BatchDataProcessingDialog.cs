using DatabaseToolSuite.Repositories;
using DatabaseToolSuite.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DatabaseToolSuite.Dialogs
{
	internal partial class BatchDataProcessingDialog : Form
	{
		private readonly MainDataSet dialogDataSet;

		public MainDataSet.gaspsRow DataRow { get; private set; }

		[DefaultValue(true)]
		public bool UnlockShow { get; set; }
				
		public bool LockShow
		{
			get => filterLockCodeViewCheckBox.Checked;
			set => filterLockCodeViewCheckBox.Checked = value;
		}

		public bool LastLockOnlyShow
		{
			get => !filterLockCodeViewCheckBox.Visible;
			set => filterLockCodeViewCheckBox.Visible = !value;
		}

		public long FilterAuthority
		{
			get => filterAuthorityComboBox.Value ?? 0;
			set => filterAuthorityComboBox.Id = value;
		}

		public string FilterName
		{
			get => filterNameTextBox.Text;
			set => filterNameTextBox.Text = value;
		}

		[DefaultValue(true)]
		public bool ReserveShow { get; set; }

		public BatchDataProcessingDialog() : this(dataSet: FileSystem.Repository.MainDataSet)
		{
		}

		public BatchDataProcessingDialog(long authority) : this(dataSet: FileSystem.Repository.MainDataSet)
		{
			filterAuthorityComboBox.Enabled = false;
			filterOkatoComboBox.Enabled = true;
			filterAuthorityComboBox.Id = authority;
		}
				
		public BatchDataProcessingDialog(long authority, string okato) : this(dataSet: FileSystem.Repository.MainDataSet)
		{
			filterAuthorityComboBox.Enabled = false;
			filterOkatoComboBox.Enabled = true;
			filterAuthorityComboBox.Id = authority;
			filterOkatoComboBox.Code = okato;
		}

		public BatchDataProcessingDialog(MainDataSet dataSet)
		{
			dialogDataSet = dataSet;

			InitializeComponent();

			countLabel.Text = string.Empty;
			selectedRowCountLabel.Text = string.Empty;
			detailsListView.ListViewContentCompleted += new Controls.UrpListView.ListViewCompletedEventHandler(DetailsListView_ListViewContentCompleted);
			detailsListView.ContentChanged += new EventHandler(DetailsListView_ItemSelectionChanged);
			detailsListView.ItemSelectionChanged += new EventHandler(DetailsListView_ItemSelectionChanged);
			detailsListView.ItemsMultySelectionChanged += new EventHandler(DetailsListView_ItemSelectionChanged);

			detailsListView.DataSet = dialogDataSet;

			UnlockShow = true;
			ReserveShow = true;
			LockShow = false;

			filterLockCodeViewCheckBox.Visible = true;

			filterAuthorityComboBox.InitializeSource(dialogDataSet.authority);
			filterAuthorityComboBox.Id = MasterDataSystem.PROSECUTOR_CODE;
			filterAuthorityComboBox.Enabled = false;
			
			filterOkatoComboBox.InitializeSource(dialogDataSet.okato);
			filterLawAgencyTypesComboBox.InitializeSource(dialogDataSet.EXP_LAW_AGENCY_TYPES);
		}
				
		private void DetailsListView_ItemSelectionChanged(object sender, EventArgs e)
		{
			is_GS_CheckBox.CheckState = GetStateMenu();
			is_GS_CheckBox.Enabled = detailsListView.SelectedRowCount > 0;
			
			selectedRowCountLabel.Text = string.Format("Выделено записей: {0}", detailsListView.SelectedRowCount);
		}

		private void DetailsListView_ListViewContentCompleted(object sender, Controls.ListViewCompletedEventArgs e)
		{
			is_GS_CheckBox.CheckState = GetStateMenu();
			is_GS_CheckBox.Enabled = detailsListView.SelectedRowCount > 0;

			countLabel.Text = string.Format("Всего записей: {0}", detailsListView.RowCount);
			selectedRowCountLabel.Text = string.Format("Выделено записей: {0}", detailsListView.SelectedRowCount);
		}

		private void Filter_ParametersChanged(object sender, EventArgs e)
		{
			detailsListView.FilterAsync(
				authority: filterAuthorityComboBox.Value,
				okato: filterOkatoComboBox.Code,
				code: filterCodeNumericTextBox.Text,
				name: filterNameTextBox.Text,
				unlockShow: UnlockShow,
				reserveShow: ReserveShow,
				lockShow: filterLockCodeViewCheckBox.Checked,
				lawAgencyType: filterLawAgencyTypesComboBox.Value);
		}

		private void ListView_ItemMouseClick(object sender, Controls.ListViewEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				mnuIsGS.CheckState = GetStateMenu();
				mnuIsGS.Enabled = detailsListView.SelectedRowCount > 0;
				contextMenuTable.Show(Cursor.Position);
			}
		}

		private void ListView_ItemMouseDoubleClick(object sender, Controls.ListViewEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				UrpView();
			}
		}

		private void Open_Click(object sender, EventArgs e)
		{
			UrpView();
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			UrpEdit();
		}

		private void IsGS_Click(object sender, EventArgs e)
		{
			is_GS_CheckBox.Enabled = false;
			if (sender is CheckBox)
			{
				CheckIsGS(is_GS_CheckBox.Checked);
			}
			else
			{
				CheckIsGS(!mnuIsGS.Checked);
			}
			is_GS_CheckBox.Enabled = true;
		}

		private void UrpView()
		{
			if (detailsListView.SelectedOrganization != null)
			{
				OrganizationViewDialog dialog = new OrganizationViewDialog(detailsListView.SelectedOrganization);
				dialog.ShowDialog(this);
			}
		}

		private void UrpEdit()
		{
			if (detailsListView.DataRow != null && 
				detailsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				MainDataSet.EXP_LAW_AGENCY_URPRow editRow;
				bool createdRow = false;

				if (MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Exists(detailsListView.DataRow.version))
				{
					editRow = MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Get(detailsListView.DataRow.version);
				}
				else
				{
					editRow = MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Create(detailsListView.DataRow.version, detailsListView.DataRow.name, detailsListView.DataRow.okatoRow.export_id);
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
					editRow.IS_GS = dialog.IsGS;

					if (dialog.SpecialTerritorialCode > 0)
					{
						editRow.SPECIAL_TERRITORIAL_CODE = dialog.SpecialTerritorialCode;
					}
					else
					{
						editRow.SetSPECIAL_TERRITORIAL_CODENull();
					}

					Utils.Database.SetIsHeadAttribute();

					detailsListView.UpdateListViewItems();
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
			else if (detailsListView.MultySelectDataRows != null && filterAuthorityComboBox.Value == MasterDataSystem.PROSECUTOR_CODE)
			{
				UrpMultiEditDialog dialog = new UrpMultiEditDialog();
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					foreach (MainDataSet.gaspsRow row in detailsListView.MultySelectDataRows)
					{
						if (MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Exists(row.version))
						{
							MainDataSet.EXP_LAW_AGENCY_URPRow editRow = MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Get(row.version);

							if (dialog.IsEditDoesntConsolidateChild)
							{
								editRow.DOESNT_CONSOLIDATE_CHILD = dialog.DoesntConsolidateChild;
							}
							if (dialog.IsEditDoesntCreateCard)
							{
								editRow.DOESNT_CREATE_CARD = dialog.DoesntCreateCard;
							}
							if (dialog.IsEditDoesntSingReport)
							{
								editRow.DOESNT_SIGN_REPORT = dialog.DoesntSingReport;
							}
							if (dialog.IsEditAgencyReceivingReport)
							{
								editRow.AGENCY_RECEIVING_REPORT = dialog.AgencyReceivingReport;
							}
							if (dialog.IsEditLawAgencyType)
							{
								editRow.LAW_AGENCY_TYPE = dialog.LawAgencyType;
							}
							if (dialog.IsEditOktmoLocId)
							{
								editRow.OKTMO_LOC_ID = dialog.OktmoLocId;
							}
							if (dialog.IsEditSpecialTerritorialCode)
							{
								editRow.SPECIAL_TERRITORIAL_CODE = dialog.SpecialTerritorialCode;
							}
							if (dialog.IsEditIsGS)
							{
								editRow.IS_GS = dialog.IsGS;
							}
						}
					}
					Utils.Database.SetIsHeadAttribute();
					detailsListView.UpdateListViewItems();
					MessageBox.Show(this, "Данные успешно внесены", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}		

		private void CheckIsGS(bool isGS)
		{
			Cursor = Cursors.WaitCursor;
			detailsListView.Enabled = false;

			if (detailsListView.DataRow != null &&
				detailsListView.DataRow.authority_id == MasterDataSystem.PROSECUTOR_CODE)
			{
				foreach (MainDataSet.EXP_LAW_AGENCY_URPRow row in detailsListView.DataRow.GetEXP_LAW_AGENCY_URPRows())
				{
					row.IS_GS = isGS;
				}
			}
			else if (detailsListView.MultySelectDataRows != null &&
				filterAuthorityComboBox.Value == MasterDataSystem.PROSECUTOR_CODE)
			{
				foreach (MainDataSet.gaspsRow gaspsRow in detailsListView.MultySelectDataRows)
				{
					foreach (MainDataSet.EXP_LAW_AGENCY_URPRow row in gaspsRow.GetEXP_LAW_AGENCY_URPRows())
					{
						row.IS_GS = isGS;
					}
				}
			}

			detailsListView.Enabled = true;
			Cursor = Cursors.Default;
		}

		private CheckState GetStateMenu()
		{
			if (detailsListView.SelectedRowCount == 1)
			{
				return detailsListView.SelectedOrganization.IsGS ? CheckState.Checked : CheckState.Unchecked;
			}
			else if (detailsListView.SelectedRowCount > 1)
			{
				CheckState result = detailsListView.MultySelectedOrganization.First().IsGS ? CheckState.Checked : CheckState.Unchecked;
				
				foreach (MainDataSet.ViewUrpOrganization organization in detailsListView.MultySelectedOrganization)
				{
					CheckState state = organization.IsGS ? CheckState.Checked : CheckState.Unchecked;
					if (result != state) return CheckState.Indeterminate;
				}
				return result;
			}
			else
			{
				return CheckState.Indeterminate;
			}
		}	
	}
}