// Ignore Spelling: okato fgis ervk Esnsi Multy

using DatabaseToolSuite.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositories.MainDataSet;

namespace DatabaseToolSuite.Controls
{
	internal partial class UrpListView : UserControl
	{
		private MainDataSet _dataSet;
		private IList<ViewUrpOrganization> itemsCollection;
		private ListViewItem[] itemsCache;
		private int firstItemIndex;

		private bool _lockShow;
		private bool _reserveShow;
		private bool _unlockShow;
		private long? _lawAgencyType;
		private readonly long? _authority;
		private readonly string _okato;
		private readonly string _code;
		private ImageList checkStateImageList;
		private ColumnHeader ownerName;
		private readonly string _name;
		private readonly Func<ViewUrpOrganization, object>[] orders = new Func<ViewUrpOrganization, object>[] {
			new Func<ViewUrpOrganization, string>(x => x.Code),
			new Func<ViewUrpOrganization, string>(x => x.Name),
			new Func<ViewUrpOrganization, string>(x => x.Authority),
			new Func<ViewUrpOrganization, string>(x => x.Okato),
			new Func<ViewUrpOrganization, object>(x => x.Begin),
			new Func<ViewUrpOrganization, object>(x => x.End),
			new Func<ViewUrpOrganization, string>(x => x.OwnerName),
			new Func<ViewUrpOrganization, object>(x => x.LawAgencyType)
		};

		public UrpListView()
		{
			itemsCollection = new List<ViewUrpOrganization>();

			_lockShow = false;
			_reserveShow = true;
			_unlockShow = true;
			_lawAgencyType = null;

			_authority = null;
			_okato = string.Empty;
			_code = string.Empty;
			_name = string.Empty;

			InitializeComponent();

			InitializeDelegates();

			Filter(authority: _authority,
				okato: _okato,
				code: _code,
				name: _name,
				unlockShow: _unlockShow,
				reserveShow: _reserveShow,
				lockShow: _lockShow,
				lawAgencyType: _lawAgencyType);

			DetailsUpdate();
		}

		public MainDataSet DataSet
		{
			get => _dataSet;
			set
			{
				if (value != null)
				{
					_dataSet = value;

					if (_dataSet.EXP_LAW_AGENCY_URP != null)
					{
						_dataSet.EXP_LAW_AGENCY_URP.EXP_LAW_AGENCY_URPRowChanged += new EXP_LAW_AGENCY_URPRowChangeEventHandler(LAW_AGENCY_URPRowChanged);
					}

					Filter(authority: _authority,
						okato: _okato,
						code: _code,
						name: _name,
						unlockShow: _unlockShow,
						reserveShow: _reserveShow,
						lockShow: _lockShow,
						lawAgencyType: _lawAgencyType);

					DetailsUpdate();
				}
			}
		}

		private void LAW_AGENCY_URPRowChanged(object sender, EXP_LAW_AGENCY_URPRowChangeEvent e)
		{
			for (int i = 0; i < itemsCollection.Count; i++)
			{
				if (itemsCollection[i].Version == e.Row.VERSION)
					UpdateListViewItem(i);
			}
			OnContentChanged(new EventArgs());
		}

		public gaspsRow DataRow { get; private set; }

		public IEnumerable<gaspsRow> MultySelectDataRows { get; private set; }

		public ViewUrpOrganization SelectedOrganization
		{
			get
			{
				if (baseListView.SelectedIndices.Count == 1)
				{
					return itemsCollection[baseListView.SelectedIndices[0]];
				}
				else
				{
					return default;
				}
			}
		}

		public IEnumerable<ViewUrpOrganization> MultySelectedOrganization
		{
			get
			{
				if (baseListView.SelectedIndices.Count > 1)
				{
					int[] indices = new int[baseListView.SelectedIndices.Count];
					baseListView.SelectedIndices.CopyTo(indices, 0);
					return indices.Select(index => itemsCollection[index]);
				}
				else
				{
					return default;
				}
			}
		}

		public bool LockShow
		{
			get => _lockShow;
			set
			{
				if (_lockShow != value)
				{
					_lockShow = value;
					OnLockVisibleChanged(new EventArgs());
				}
			}
		}

		public bool ReserveShow
		{
			get => _reserveShow;
			set
			{
				if (_reserveShow != value)
				{
					_reserveShow = value;
					OnReserveVisibleChanged(new EventArgs());
				}
			}
		}

		public bool UnlockShow
		{
			get => _unlockShow;
			set
			{
				if (_unlockShow != value)
				{
					_unlockShow = value;
					OnUnlockVisibleChanged(new EventArgs());
				}
			}
		}

		public long? LawAgencyType
		{
			get => _lawAgencyType;
			set
			{
				if (_lawAgencyType != value)
				{
					_lawAgencyType = value;
					OnLawAgencyTypeVisibleChanged(new EventArgs());
				}
			}
		}

		public int RowCount => itemsCollection.Count;

		public int SelectedRowCount => baseListView.SelectedIndices.Count;

		public void Filter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, long? lawAgencyType)
		{
			if (DataSet == null) return;
			IList<ViewUrpOrganization> list = DataSet.GetViewUrpOrganizationFilter(
				authority: authority,
				okato: okato,
				code: code,
				name: name,
				unlockShow: unlockShow,
				reserveShow: reserveShow,
				lockShow: lockShow,
				fgisEsnsiOnlyShow: false,
				ervkOnlyShow: false,
				lawAgencyType: lawAgencyType);

			ApplyFilter(list);
		}

		private void ApplyFilter(IList<ViewUrpOrganization> list)
		{
			baseListView.BeginUpdate();

			int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
			ViewUrpOrganization selectedOrganization = itemsCollection.Count > 0 ? itemsCollection[selectedIndex] : default;

			baseListView.VirtualMode = true;
			itemsCache = null;

			if (list != null)
				itemsCollection = list;
			else
				itemsCollection.Clear();

			baseListView.VirtualListSize = itemsCollection.Count();

			baseListView.SelectedIndices.Clear();
			int selectIndex = itemsCollection.IndexOf(selectedOrganization);
			if (selectIndex >= 0)
			{
				baseListView.SelectedIndices.Add(selectIndex);
				baseListView.EnsureVisible(selectIndex);
			}
			DetailsUpdate();

			baseListView.EndUpdate();
		}

		private void DetailsUpdate()
		{
			if (baseListView.SelectedIndices.Count == 0)
			{
				if (DataRow != null)
				{
					DataRow = null;
					MultySelectDataRows = null;
					OnItemSelectionChanged(new EventArgs());
				}
			}
			else if (baseListView.SelectedIndices.Count == 1)
			{
				ViewUrpOrganization selectedOrganization = itemsCollection[baseListView.SelectedIndices[0]];
				if (DataRow == null ||
					DataRow.version != selectedOrganization.Version)
				{
					MultySelectDataRows = null;
					DataRow = DataSet.gasps.GetOrganizationFromVersion(selectedOrganization.Version);
					OnItemSelectionChanged(new EventArgs());
				}
			}
			else
			{
				DataRow = null;
				OnItemSelectionChanged(new EventArgs());
				MultySelectDataRows = MultySelectedOrganization
					.Select(organization => DataSet.gasps.GetOrganizationFromVersion(organization.Version));
				OnItemsMultySelectionChanged(new EventArgs());
			}
		}

		private void ListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			if (itemsCache != null && e.ItemIndex >= firstItemIndex && e.ItemIndex < firstItemIndex + itemsCache.Length)
			{
				e.Item = itemsCache[e.ItemIndex - firstItemIndex];
			}
			else
			{
				e.Item = CreateListViewItem(itemsCollection[e.ItemIndex]);
			}
		}

		private void ListView_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
		{
			if (itemsCache != null &&
				e.StartIndex >= firstItemIndex &&
				e.EndIndex <= firstItemIndex + itemsCache.Length)
			{
				return;
			}

			firstItemIndex = e.StartIndex;
			int length = e.EndIndex - e.StartIndex + 1;
			itemsCache = new ListViewItem[length];

			for (int i = 0; i < length; i++)
			{
				itemsCache[i] = CreateListViewItem(itemsCollection[firstItemIndex + i]);
			}
		}

		private ListViewItem CreateListViewItem(ViewUrpOrganization organization)
		{
			ListViewItem item = new ListViewItem(organization.Code)
			{
				ImageIndex = GetImageIndex(organization),
				Text = string.IsNullOrEmpty(organization.Code) ? string.Empty : organization.Code
			};
			item.SubItems.Add(organization.Name);
			item.SubItems.Add(organization.Authority);
			item.SubItems.Add(organization.Okato);
			item.SubItems.Add(organization.Begin.ToShortDateString());
			item.SubItems.Add(organization.End.ToShortDateString());
			item.SubItems.Add(organization.OwnerName);

			return item;
		}

		private int GetImageIndex(ViewUrpOrganization organization) => organization.IsGS ? 1 : 0;
		
		public void UpdateListViewItems()
		{
			if (itemsCollection.Count == 0 && baseListView.SelectedIndices.Count == 0) return;

			foreach (int index in baseListView.SelectedIndices)
			{
				UpdateListViewItem(index: index);
			}
		}

		private void UpdateListViewItem(int index)
		{			
			int offset = index >= firstItemIndex ? index - firstItemIndex : 0;
			if (offset >= itemsCache.Length) return;
			
			long version = itemsCollection[index].Version;
			itemsCollection[index] = _dataSet.GetViewUrpOrganization(version);
			ViewUrpOrganization organization = itemsCollection[index];

			ListViewItem item = itemsCache[offset];
			
			item.ImageIndex = GetImageIndex(organization);
			item.Text = string.IsNullOrEmpty(organization.Code) ? string.Empty : organization.Code;
			item.SubItems[1].Text = organization.Name;
			item.SubItems[2].Text = organization.Authority;
			item.SubItems[3].Text = organization.Okato;
			item.SubItems[4].Text = organization.Begin.ToShortDateString();
			item.SubItems[5].Text = organization.End.ToShortDateString();
			item.SubItems[6].Text = organization.OwnerName;
			
			baseListView.Invalidate(item.Bounds);
		}

		private void ListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			DetailsUpdate();
		}

		private void ListView_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
		{
			DetailsUpdate();
		}

		private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (itemsCollection.Count == 0) return;

			baseListView.BeginUpdate();

			int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
			ViewUrpOrganization selectedOrganization = itemsCollection[selectedIndex];

			if (e.Column == 0)
			{
				if (baseListView.Columns[0].Tag == null ||
					baseListView.Columns[0].Tag.ToString() == "UP")
				{
					itemsCollection = itemsCollection.OrderBy(orders.First()).ToArray();
					baseListView.Columns[0].Tag = "OTHER_UP";
				}
				else if (baseListView.Columns[0].Tag.ToString() == "OTHER_UP")
				{
					itemsCollection = itemsCollection.OrderBy(orders.Last()).ToArray();
					baseListView.Columns[e.Column].Tag = "DOWN";
				}
				else if (baseListView.Columns[0].Tag.ToString() == "DOWN")
				{
					itemsCollection = itemsCollection.OrderBy(orders.First()).ToArray();
					baseListView.Columns[e.Column].Tag = "OTHER_DOWN";
				}
				else
				{
					itemsCollection = itemsCollection.OrderByDescending(orders.Last()).ToArray();
					baseListView.Columns[e.Column].Tag = "UP";
				}
			}
			else
			{
				if (baseListView.Columns[e.Column].Tag == null ||
					baseListView.Columns[e.Column].Tag.ToString() == "UP")
				{
					itemsCollection = itemsCollection.OrderBy(orders[e.Column]).ToArray();
					baseListView.Columns[e.Column].Tag = "DOWN";
				}
				else
				{
					itemsCollection = itemsCollection.OrderByDescending(orders[e.Column]).ToArray();
					baseListView.Columns[e.Column].Tag = "UP";
				}
			}

			int selectIndex = itemsCollection.IndexOf(selectedOrganization);
			itemsCache = null;
			baseListView.SelectedIndices.Clear();
			baseListView.SelectedIndices.Add(selectIndex);
			baseListView.EnsureVisible(selectIndex);
			baseListView.EndUpdate();
		}

		public event EventHandler ContentChanged;

		public event EventHandler ItemSelectionChanged;

		public event EventHandler ItemsMultySelectionChanged;

		public event EventHandler LockVisibleChanged;

		public event EventHandler ReserveVisibleChanged;

		public event EventHandler UnlockVisibleChanged;

		public event EventHandler LawAgencyTypeVisibleChanged;

		public event EventHandler<ListViewEventArgs> ItemMouseClick;

		public event EventHandler<ListViewEventArgs> ItemMouseDoubleClick;

		protected virtual void OnContentChanged(EventArgs e) => ContentChanged?.Invoke(this, e);

		protected virtual void OnItemSelectionChanged(EventArgs e) => ItemSelectionChanged?.Invoke(this, e);

		protected virtual void OnItemsMultySelectionChanged(EventArgs e) => ItemsMultySelectionChanged?.Invoke(this, e);

		protected virtual void OnLockVisibleChanged(EventArgs e)
		{
			ControlsValueChanged();
			LockVisibleChanged?.Invoke(this, e);
		}

		protected virtual void OnReserveVisibleChanged(EventArgs e)
		{
			ControlsValueChanged();
			ReserveVisibleChanged?.Invoke(this, e);
		}

		protected virtual void OnUnlockVisibleChanged(EventArgs e)
		{
			ControlsValueChanged();
			UnlockVisibleChanged?.Invoke(this, e);
		}

		protected virtual void OnLawAgencyTypeVisibleChanged(EventArgs e)
		{
			ControlsValueChanged();
			LawAgencyTypeVisibleChanged?.Invoke(this, e);
		}

		protected virtual void OnItemMouseClick(ListViewEventArgs e) => ItemMouseClick?.Invoke(this, e);

		protected virtual void OnItemMouseDoubleClick(ListViewEventArgs e) => ItemMouseDoubleClick?.Invoke(this, e);

		private void ControlsValueChanged()
		{
			baseListView.SelectedIndices.Clear();

			Filter(
				authority: _authority,
				okato: _okato,
				code: _code,
				name: _name,
				unlockShow: _unlockShow,
				reserveShow: _reserveShow,
				lockShow: _lockShow,
				lawAgencyType: _lawAgencyType);
			DetailsUpdate();
		}

		private void ListView_MouseClick(object sender, MouseEventArgs e)
		{
			ListView listView = sender as ListView;
			var focusedItem = listView.FocusedItem;
			if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
			{
				OnItemMouseClick(new ListViewEventArgs(focusedItem, e));
			}
		}

		private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListView listView = sender as ListView;
			var focusedItem = listView.FocusedItem;
			if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
			{
				OnItemMouseDoubleClick(new ListViewEventArgs(focusedItem, e));
			}
		}

		private void ListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Space && baseListView.SelectedIndices.Count == 1)
			{
				ViewUrpOrganization organization = itemsCollection[baseListView.SelectedIndices[0]];
				EXP_LAW_AGENCY_URPRow row = DataSet.EXP_LAW_AGENCY_URP.Get(organization.Version);
				row.IS_GS = !row.IS_GS;				
				e.SuppressKeyPress = false;
			}
		}

		private delegate void WorkerEventHandler(FilterParameters filter, AsyncOperation asyncOp);

		private SendOrPostCallback onProgressReportDelegate;
		private SendOrPostCallback onCompletedDelegate;

		private readonly HybridDictionary userStateToLifetime = new HybridDictionary();

		#region Public events

		public event ProgressChangedEventHandler ProgressChanged;

		public event ListViewCompletedEventHandler ListViewContentCompleted;

		#endregion Public events

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

		protected virtual void InitializeDelegates()
		{
			onProgressReportDelegate = new SendOrPostCallback(ReportProgress);
			onCompletedDelegate = new SendOrPostCallback(ItemCollectionCompleted);
		}

		#region Implementation

		public virtual void FilterAsync(
			long? authority,
			string okato,
			string code,
			string name,
			bool unlockShow,
			bool reserveShow,
			bool lockShow,
			long? lawAgencyType)
		{
			FilterParameters filter = new FilterParameters(
				dataSet: DataSet,
				authority: authority,
				okato: okato,
				code: code,
				name: name,
				unlockShow: unlockShow,
				reserveShow: reserveShow,
				lockShow: lockShow,
				lawAgencyType: lawAgencyType);

			AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(filter.GetHashCode());

			if (userStateToLifetime.Count > 0)
			{
				lock (userStateToLifetime.SyncRoot)
				{
					userStateToLifetime.Clear();
					Thread.Sleep(10);
				}
			}

			lock (userStateToLifetime.SyncRoot)
			{
				userStateToLifetime[filter.GetHashCode()] = asyncOp;
			}

			WorkerEventHandler workerDelegate = new WorkerEventHandler(ListViewWorker);
			workerDelegate.BeginInvoke(
				filter,
				asyncOp,
				null,
				null);
		}

		private bool TaskCanceled(object taskId)
		{
			return userStateToLifetime[taskId] == null;
		}

		public void CancelAsync(object taskId)
		{
			if (userStateToLifetime[taskId] is AsyncOperation)
			{
				lock (userStateToLifetime.SyncRoot)
				{
					userStateToLifetime.Remove(taskId);
				}
			}
		}

		private void ListViewWorker(
			FilterParameters filter,
			AsyncOperation asyncOp)
		{
			IList<ViewUrpOrganization> collection = null;
			Exception e = null;

			if (!TaskCanceled(asyncOp.UserSuppliedState))
			{
				try
				{
					collection = BuildListViewList(
						filter,
						asyncOp);
				}
				catch (Exception ex)
				{
					e = ex;
				}
			}

			CompletionMethod(
				filter,
				collection,
				e,
				TaskCanceled(asyncOp.UserSuppliedState),
				asyncOp);
		}

		private IList<ViewUrpOrganization> BuildListViewList(
			FilterParameters filter,
			AsyncOperation asyncOp)
		{
			IList<ViewUrpOrganization> list =
				filter.DataSet.GetViewUrpOrganizationFilter(
				authority: filter.Authority,
				okato: filter.Okato,
				code: filter.Code,
				name: filter.Name,
				unlockShow: filter.UnlockShow,
				reserveShow: filter.ReserveShow,
				lockShow: filter.LockShow,
				fgisEsnsiOnlyShow: false,
				ervkOnlyShow: false,
				lawAgencyType: filter.LawAgencyType);

			return list;
		}

		private void ItemCollectionCompleted(object operationState)
		{
			ListViewCompletedEventArgs e = operationState as ListViewCompletedEventArgs;
			ApplyFilter(e.Collection);
			OnListViewCompleted(e);
		}

		private void ReportProgress(object state)
		{
			ProgressChangedEventArgs e = state as ProgressChangedEventArgs;
			OnProgressChanged(e);
		}

		protected void OnListViewCompleted(ListViewCompletedEventArgs e) => ListViewContentCompleted?.Invoke(this, e);

		protected void OnProgressChanged(ProgressChangedEventArgs e) => ProgressChanged?.Invoke(e);

		private void CompletionMethod(
			FilterParameters filter,
			IList<ViewUrpOrganization> collection,
			Exception exception,
			bool canceled,
			AsyncOperation asyncOp)
		{
			if (!canceled)
			{
				lock (userStateToLifetime.SyncRoot)
				{
					userStateToLifetime.Remove(asyncOp.UserSuppliedState);
				}
			}

			ListViewCompletedEventArgs e =
				new ListViewCompletedEventArgs(
				collection,
				exception,
				canceled,
				asyncOp.UserSuppliedState);

			asyncOp.PostOperationCompleted(onCompletedDelegate, e);
		}

		#endregion Implementation

		#region Код, автоматически созданный конструктором компонентов

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrpListView));
			this.baseListView = new System.Windows.Forms.ListView();
			this.codeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.authorityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.okatoColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.beginColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.endColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ownerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.checkStateImageList = new System.Windows.Forms.ImageList(this.components);
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
			this.endColumn,
			this.ownerName});
			this.baseListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.baseListView.FullRowSelect = true;
			this.baseListView.GridLines = true;
			this.baseListView.HideSelection = false;
			this.baseListView.LargeImageList = this.checkStateImageList;
			this.baseListView.Location = new System.Drawing.Point(0, 0);
			this.baseListView.Margin = new System.Windows.Forms.Padding(4);
			this.baseListView.Name = "baseListView";
			this.baseListView.Size = new System.Drawing.Size(863, 185);
			this.baseListView.SmallImageList = this.checkStateImageList;
			this.baseListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.baseListView.TabIndex = 0;
			this.baseListView.UseCompatibleStateImageBehavior = false;
			this.baseListView.View = System.Windows.Forms.View.Details;
			this.baseListView.VirtualMode = true;
			this.baseListView.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.ListView_CacheVirtualItems);
			this.baseListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_ColumnClick);
			this.baseListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListView_RetrieveVirtualItem);
			this.baseListView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
			this.baseListView.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.ListView_VirtualItemsSelectionRangeChanged);
			this.baseListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView_KeyDown);
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
			this.beginColumn.Width = 100;
			// 
			// endColumn
			// 
			this.endColumn.Text = "Окончание действия";
			this.endColumn.Width = 100;
			// 
			// ownerName
			// 
			this.ownerName.Text = "Владелец";
			this.ownerName.Width = 200;
			// 
			// checkStateImageList
			// 
			this.checkStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("checkStateImageList.ImageStream")));
			this.checkStateImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.checkStateImageList.Images.SetKeyName(0, "uncheck");
			this.checkStateImageList.Images.SetKeyName(1, "check");
			// 
			// UrpListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.baseListView);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "UrpListView";
			this.Size = new System.Drawing.Size(863, 185);
			this.ResumeLayout(false);

		}

		#endregion Код, автоматически созданный конструктором компонентов

		private ListView baseListView;
		private ColumnHeader codeColumn;
		private ColumnHeader nameColumn;
		private ColumnHeader authorityColumn;
		private ColumnHeader okatoColumn;
		private ColumnHeader beginColumn;
		private ColumnHeader endColumn;

		private class FilterParameters
		{
			public MainDataSet DataSet { get; private set; }
			public long? Authority { get; private set; }
			public string Okato { get; private set; }
			public string Code { get; private set; }
			public string Name { get; private set; }
			public bool UnlockShow { get; private set; }
			public bool ReserveShow { get; private set; }
			public bool LockShow { get; private set; }
			public long? LawAgencyType { get; private set; }

			private int hashCode;

			public FilterParameters(MainDataSet dataSet, long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, long? lawAgencyType)
			{
				DataSet = dataSet;
				Authority = authority;
				Okato = okato;
				Code = code;
				Name = name;
				UnlockShow = unlockShow;
				ReserveShow = reserveShow;
				LockShow = lockShow;
				LawAgencyType = lawAgencyType;

				hashCode = ("GaspsListViewFilterParameters" +
					(Authority.HasValue ? Authority.Value.ToString() : "Null") + "F1" +
					Okato + "F2" +
					Code + "F3" +
					Name + "F4" +
					UnlockShow.ToString() + "F5" +
					ReserveShow.ToString() + "F6" +
					LockShow.ToString() + "F7" +
					(LawAgencyType.HasValue ? LawAgencyType.Value.ToString() : "Null"))
					.GetHashCode();
			}

			public static bool Equals(FilterParameters parameterA, FilterParameters parameterB) => Equals(objA: parameterA, objB: parameterB);

			public new static bool Equals(object objA, object objB)
			{
				if (objA == null & objB == null)
				{
					return true;
				}
				else if (objA != null & objB == null)
				{
					return false;
				}
				else if (objA == null & objB != null)
				{
					return false;
				}
				else
				{
					if (!(objA is FilterParameters) | !(objB is FilterParameters))
					{
						return false;
					}
					else
					{
						FilterParameters parameterA = (FilterParameters)objA;
						FilterParameters parameterB = (FilterParameters)objB;
						return parameterA.GetHashCode().Equals(parameterB.GetHashCode());
					}
				}
			}

			public override bool Equals(object obj) => Equals(objA: this, objB: obj);

			public bool Equals(FilterParameters obj) => Equals(objA: this, objB: obj);

			public override int GetHashCode() => hashCode;
		}

		public delegate void ProgressChangedEventHandler(ProgressChangedEventArgs e);

		public delegate void ListViewCompletedEventHandler(object sender, ListViewCompletedEventArgs e);

	}

	internal interface IUrpListViewItem
	{
		[Description("Наименование подразделения (SV-0001)")]
		[Category("ГАС ПС")]
		[DisplayName("Наименование")]
		string Name { get; }

		[Description("Ведомство")]
		[Category("ГАС ПС")]
		[DisplayName("Ведомство")]
		string Authority { get; }

		[Description("Код ОКАТО")]
		[Category("ГАС ПС")]
		[DisplayName("ОКАТО")]
		string Okato { get; }

		[Description("Код подразделения")]
		[Category("ГАС ПС")]
		[DisplayName("Код подразделения")]
		string Code { get; }

		[Description("Дата начала действия подразделения")]
		[Category("ГАС ПС")]
		[DisplayName("Дата начала")]
		DateTime Begin { get; }

		[Description("Дата окончания действия подразделения")]
		[Category("ГАС ПС")]
		[DisplayName("Дата окончания")]
		DateTime End { get; }

		[Description("Уникальное значение версии записи")]
		[DisplayName("Версия записи")]
		long Version { get; }

		[Description("Наименование вышестоящей организации (владельца)")]
		[Category("ГАС ПС")]
		[DisplayName("Владелец")]
		string OwnerName { get; }

		[Description("Телефон канцелярии (SV-0004)")]
		[Category("ФГИС ЕСНСИ")]
		[DisplayName("Телефон")]
		string Phone { get; }

		[Description("Электронный адрес канцелярии (SV-0005)")]
		[Category("ФГИС ЕСНСИ")]
		[DisplayName("Электронный адрес")]
		string Email { get; }

		[Description("Почтовый адрес где ведется прием граждан (SV-0006)")]
		[Category("ФГИС ЕСНСИ")]
		[DisplayName("Почтовый адрес")]
		string Address { get; }

		[Description("Признак, определяющий, что орган прокуратуры является головным")]
		[Category("ЕРВК")]
		[DisplayName("Головная прокуратура")]
		bool IsHead { get; }

		[Description("Признак, определяющий, что орган прокуратуры является специализированным")]
		[Category("ЕРВК")]
		[DisplayName("Спец.прокуратура")]
		bool Special { get; }

		[Description("Признак, определяющий, что орган прокуратуры является военным")]
		[Category("ЕРВК")]
		[DisplayName("Военная прокуратура")]
		bool Military { get; }

		[Description("Признак, определяющий, что запись является активной")]
		[Category("ЕРВК")]
		[DisplayName("Признак активности")]
		bool IsActive { get; }

		[Description("ОГРН")]
		[Category("ЕРВК")]
		[DisplayName("ОГРН")]
		string Ogrn { get; }

		[Description("ИНН")]
		[Category("ЕРВК")]
		[DisplayName("ИНН")]
		string Inn { get; }

		[Browsable(false)]
		bool IsErvk { get; }
	}
}