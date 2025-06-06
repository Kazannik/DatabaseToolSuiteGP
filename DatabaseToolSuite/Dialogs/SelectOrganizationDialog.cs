﻿// Ignore Spelling: okato ervk

using DatabaseToolSuite.Repositories;
using DatabaseToolSuite.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	internal partial class SelectOrganizationDialog : Form
	{
		private readonly MainDataSet dialogDataSet;
		private IList<MainDataSet.gaspsRow> rowsCollection;
		private ListViewItem[] itemsCache;
		private int firstItemIndex;

		public MainDataSet.gaspsRow DataRow { get; private set; }

		[DefaultValue(true)]
		public bool UnlockShow { get; set; }

		[DefaultValue(false)]
		public bool ErvkOnlyShow { get; set; }

		public bool LockShow
		{
			get
			{
				return filterLockCodeViewCheckBox.Checked;
			}
			set
			{
				filterLockCodeViewCheckBox.Checked = value;
			}
		}

		public bool LastLockOnlyShow
		{
			get
			{
				return !filterLockCodeViewCheckBox.Visible;
			}
			set
			{
				filterLockCodeViewCheckBox.Visible = !value;
			}
		}

		public long FilterAuthority
		{
			get => filterAuthorityComboBox.Value ?? 0;
			set
			{
				filterAuthorityComboBox.Code = value.ToString("00");
			}
		}

		public string FilterName
		{
			get { return filterNameTextBox.Text; }
			set { filterNameTextBox.Text = value; }
		}

		public bool ReserveShow { get; set; }

		public SelectOrganizationDialog() : this(dataSet: FileSystem.Repository.MainDataSet)
		{
		}

		public SelectOrganizationDialog(long authority) : this(dataSet: FileSystem.Repository.MainDataSet)
		{
			filterAuthorityComboBox.Enabled = false;
			filterOkatoComboBox.Enabled = true;
			filterAuthorityComboBox.Code = authority.ToString("00");
		}

		public SelectOrganizationDialog(bool ervkOnlyShow) : this(dataSet: Services.FileSystem.Repository.MainDataSet)
		{
			ErvkOnlyShow = ervkOnlyShow;
			filterAuthorityComboBox.Enabled = false;
			filterOkatoComboBox.Enabled = true;
			filterAuthorityComboBox.Code = MasterDataSystem.PROSECUTOR_CODE.ToString("00");
		}

		public SelectOrganizationDialog(long authority, string okato) : this(dataSet: Services.FileSystem.Repository.MainDataSet)
		{
			filterAuthorityComboBox.Enabled = false;
			filterOkatoComboBox.Enabled = true;
			filterAuthorityComboBox.Code = authority.ToString("00");
			filterOkatoComboBox.Code = okato;
		}

		public SelectOrganizationDialog(MainDataSet dataSet)
		{
			dialogDataSet = dataSet;

			InitializeComponent();

			UnlockShow = true;
			ReserveShow = true;
			LockShow = false;
			filterLockCodeViewCheckBox.Visible = true;

			filterOkatoComboBox.InitializeSource(dialogDataSet.okato);
			filterAuthorityComboBox.InitializeSource(dialogDataSet.authority);

			InitializeFilter(dialogDataSet);
			DetailsUpdate();
		}

		private void InitializeFilter(MainDataSet dataSet)
		{
			detailsListView.BeginUpdate();

			detailsListView.VirtualMode = true;
			itemsCache = null;

			long? authority = string.IsNullOrWhiteSpace(filterAuthorityComboBox.Code) ? (long?)null : long.Parse(filterAuthorityComboBox.Code);

			if (LastLockOnlyShow)
			{
				rowsCollection = dataSet.gasps.GetLockLastCodes(
					authority: authority,
					okato: filterOkatoComboBox.Code);
			}
			else
			{
				rowsCollection = dataSet.gasps.GetGaspsOrganizationFilter(
					authority: authority,
					okato: filterOkatoComboBox.Code,
					code: filterCodeNumericTextBox.Text,
					name: filterNameTextBox.Text,
					unlockShow: UnlockShow,
					reserveShow: ReserveShow,
					lockShow: filterLockCodeViewCheckBox.Checked);
			}

			if (ErvkOnlyShow)
			{
				EnumerableRowCollection<Repositories.MainDataSet.ervkRow> ervkCollection = dataSet.ervk.Where(e => e.RowState != DataRowState.Deleted);
				rowsCollection = (from gasps in rowsCollection
								  join ervk in ervkCollection on gasps.version equals ervk.version
								  select gasps).ToList();
			}

			detailsListView.VirtualListSize = rowsCollection.Count();

			detailsListView.EndUpdate();
		}

		private void DetailsUpdate()
		{
			if (detailsListView.SelectedIndices.Count == 0)
			{
				detailsTextBox.Text = string.Empty;
				selectOkatoTextBox.Text = string.Empty;
				selectNameTextBox.Text = string.Empty;
				DataRow = null;
				okButton.Enabled = false;
			}
			else
			{
				DataRow = rowsCollection[detailsListView.SelectedIndices[0]];

				selectOkatoTextBox.Text = DataRow.code;
				selectNameTextBox.Text = DataRow.name;

				StringBuilder text = new StringBuilder(DataRow.name);
				text.AppendLine();
				text.AppendLine();
				text.AppendLine("Код: " + DataRow.code);
				text.AppendLine();
				text.AppendLine("ОКАТО: " + DataRow.okato_code + " - " + dialogDataSet.okato.GetName(DataRow.okato_code));
				text.AppendLine();
				text.AppendLine("Дата начала действия: " + DataRow.date_beg.ToShortDateString());
				text.AppendLine("Дата окончания действия: " + DataRow.date_end.ToShortDateString());
				text.AppendLine();
				text.AppendLine("Вид органа: " + DataRow.authority_id.ToString("00") + " - " + dialogDataSet.authority.GetName(DataRow.authority_id));

				if (DataRow.owner_id > 0)
				{
					text.AppendLine();
					MainDataSet.gaspsRow owner = dialogDataSet.gasps.GetLastVersionOrganizationFromKey(DataRow.owner_id);
					text.AppendLine("Владелец: (" + owner.code + ") " + owner.name);
				}

				detailsTextBox.Text = text.ToString();
				okButton.Enabled = true;
			}
		}

		private void DetailsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			if (itemsCache != null && e.ItemIndex >= firstItemIndex && e.ItemIndex < firstItemIndex + itemsCache.Length)
			{
				e.Item = itemsCache[e.ItemIndex - firstItemIndex];
			}
			else
			{
				e.Item = CreateListViewItem(rowsCollection[e.ItemIndex]);
			}
		}

		private void DetailsListView_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
		{
			if (itemsCache != null && e.StartIndex >= firstItemIndex && e.EndIndex <= firstItemIndex + itemsCache.Length)
			{
				return;
			}

			firstItemIndex = e.StartIndex;
			int length = e.EndIndex - e.StartIndex + 1;
			itemsCache = new ListViewItem[length];

			for (int i = 0; i < length; i++)
			{
				itemsCache[i] = CreateListViewItem(rowsCollection[firstItemIndex + i]);
			}
		}

		private void DetailsListView_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
		{
			if (double.TryParse(e.Text, out double x)) //check if this is a valid search
			{
				x = Math.Sqrt(x);
				x = Math.Round(x);
				e.Index = (int)x;
			}
		}

		private ListViewItem CreateListViewItem(MainDataSet.gaspsRow row)
		{
			ListViewItem item = new ListViewItem(row.code);

			if (row.date_beg.Date > DateTime.Today)
				item.ImageIndex = 2;
			else if (row.date_beg.Date <= DateTime.Today && row.date_end.Date > DateTime.Today)
				item.ImageIndex = 0;
			else
				item.ImageIndex = 1;

			item.Text = row.code;
			item.SubItems.Add(row.name);
			return item;
		}

		private void FilterControls_ValueChanged(object sender, EventArgs e)
		{
			detailsListView.SelectedIndices.Clear();
			InitializeFilter(dialogDataSet);
			DetailsUpdate();
		}

		private void DetailsListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			DetailsUpdate();
		}

		private void DetailsListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			detailsListView.BeginUpdate();

			int selectedIndex = detailsListView.SelectedIndices.Count > 0 ? detailsListView.SelectedIndices[0] : 0;
			Repositories.MainDataSet.gaspsRow selectedRow = rowsCollection[selectedIndex];

			if (detailsListView.Columns[e.Column].Tag == null ||
				detailsListView.Columns[e.Column].Tag.ToString() == "UP")
			{
				if (e.Column == 0)
					rowsCollection = rowsCollection.OrderBy(x => x.code).ToList();
				else
					rowsCollection = rowsCollection.OrderBy(x => x.name).ToList();
				detailsListView.Columns[e.Column].Tag = "DOWN";
			}
			else
			{
				if (e.Column == 0)
					rowsCollection = rowsCollection.OrderByDescending(x => x.code).ToList();
				else
					rowsCollection = rowsCollection.OrderByDescending(x => x.name).ToList();
				detailsListView.Columns[e.Column].Tag = "UP";
			}

			itemsCache = null;
			detailsListView.SelectedIndices.Clear();
			int selectIndex = rowsCollection.IndexOf(selectedRow);
			detailsListView.SelectedIndices.Add(selectIndex);
			detailsListView.EnsureVisible(selectIndex);
			detailsListView.EndUpdate();
		}
	}
}