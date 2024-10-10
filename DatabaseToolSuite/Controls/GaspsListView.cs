using DatabaseToolSuite.Repositoryes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DatabaseToolSuite.Controls
{
    public partial class GaspsListView : UserControl
    {
        private RepositoryDataSet _dataSet;
        private IList<RepositoryDataSet.ViewErvkOrganization> itemsCollection;
        private ListViewItem[] itemsCache;
        private int firstItemIndex;

        private bool _lockShow;
        private bool _reserveShow;
        private bool _unlockShow;
        private bool _fgisEsnsiOnlyShow;
        private bool _ervkOnlyShow;
        private long? _authority;
        private string _okato;
        private string _code;
        private ImageList organizationImageList;
        private ColumnHeader phoneColumn;
        private ColumnHeader emailColumn;
        private ColumnHeader addressColumn;
        private ColumnHeader ownerName;
        private ColumnHeader isActive;
        private ColumnHeader isHead;
        private ColumnHeader special;
        private ColumnHeader military;
        private ColumnHeader ogrn;
        private ColumnHeader inn;
        private string _name;

        public GaspsListView()
        {
            itemsCollection = new List<RepositoryDataSet.ViewErvkOrganization>();

            _lockShow = false;
            _reserveShow = true;
            _unlockShow = true;
            _fgisEsnsiOnlyShow = false;
            _ervkOnlyShow = false;

            _authority = (long?)null;
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
                fgisEsnsiOnlyShow: _fgisEsnsiOnlyShow,
                ervkOnlyShow: _ervkOnlyShow);

            DetailsUpdate();
        }

        public RepositoryDataSet DataSet
        {
            get
            {
                return _dataSet;
            }
            set
            {
                if (value != null)
                {
                    _dataSet = value;

                    Filter(authority: _authority,
                        okato: _okato,
                        code: _code,
                        name: _name,
                        unlockShow: _unlockShow,
                        reserveShow: _reserveShow,
                        lockShow: _lockShow,
                        fgisEsnsiOnlyShow: _fgisEsnsiOnlyShow,
                        ervkOnlyShow: _ervkOnlyShow);

                    DetailsUpdate();
                }
            }
        }

        public RepositoryDataSet.gaspsRow DataRow { get; private set; }

        public RepositoryDataSet.ViewErvkOrganization SelectedOrganization
        {
            get
            {
                if (baseListView.SelectedIndices.Count > 0)
                {
                    return itemsCollection[baseListView.SelectedIndices[0]];
                }
                else
                {
                    return null;
                }
            }
        }

        public bool LockShow
        {
            get
            {
                return _lockShow;
            }
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
            get
            {
                return _reserveShow;
            }
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
            get
            {
                return _unlockShow;
            }
            set
            {
                if (_unlockShow != value)
                {
                    _unlockShow = value;
                    OnUnlockVisibleChanged(new EventArgs());
                }
            }
        }

        public bool FgisEsnsiOnlyShow
        {
            get
            {
                return _fgisEsnsiOnlyShow;
            }
            set
            {
                if (_fgisEsnsiOnlyShow != value)
                {
                    _fgisEsnsiOnlyShow = value;
                    OnFgisEsnsiOnlyVisibleChanged(new EventArgs());
                }
            }
        }

        public bool ErvkOnlyShow
        {
            get
            {
                return _ervkOnlyShow;
            }
            set
            {
                if (_ervkOnlyShow != value)
                {
                    _ervkOnlyShow = value;
                    OnErvkOnlyVisibleChanged(new EventArgs());
                }
            }
        }

        public int RowCount
        {
            get { return itemsCollection.Count; }
        }

        public void Filter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
        {
            if (DataSet == null) return;
            IList<RepositoryDataSet.ViewErvkOrganization> list = DataSet.GetViewErvkOrganizationFilter(
                authority: authority,
                okato: okato,
                code: code,
                name: name,
                unlockShow: unlockShow,
                reserveShow: reserveShow,
                lockShow: lockShow,
                fgisEsnsiOnlyShow: fgisEsnsiOnlyShow,
                ervkOnlyShow: ervkOnlyShow);

            ApplyFilter(list);
        }

        private void ApplyFilter(IList<RepositoryDataSet.ViewErvkOrganization> list)
        {

            baseListView.BeginUpdate();

            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            RepositoryDataSet.ViewErvkOrganization selectedOrganization = itemsCollection.Count > 0 ? itemsCollection[selectedIndex] : null;

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
                    OnItemSelectionChanged(new EventArgs());
                }
            }
            else
            {
                RepositoryDataSet.ViewErvkOrganization newOrganization = itemsCollection[baseListView.SelectedIndices[0]];
                if (DataRow == null ||
                    DataRow.version != newOrganization.Version)
                {
                    DataRow = DataSet.gasps.GetOrganizationFromVersion(newOrganization.Version);
                    OnItemSelectionChanged(new EventArgs());
                }
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
            if (itemsCache != null && e.StartIndex >= firstItemIndex && e.EndIndex <= firstItemIndex + itemsCache.Length)
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

        private ListViewItem CreateListViewItem(RepositoryDataSet.ViewErvkOrganization organization)
        {
            ListViewItem item = new ListViewItem(organization.Code);

            if (organization.Begin > DateTime.Today)
                item.ImageIndex = 2;
            else if (organization.Begin <= DateTime.Today && organization.End > DateTime.Today)
                item.ImageIndex = 0;
            else
                item.ImageIndex = 1;

            item.Text = organization.Code;
            item.SubItems.Add(organization.Name);
            item.SubItems.Add(organization.Authority);
            item.SubItems.Add(organization.Okato);
            item.SubItems.Add(organization.Begin.ToShortDateString());
            item.SubItems.Add(organization.End.ToShortDateString());

            item.SubItems.Add(organization.Phone);
            item.SubItems.Add(organization.Email);
            item.SubItems.Add(organization.Address);

            item.SubItems.Add(organization.OwnerName);

            if (organization.IsErvk)
            {
                item.SubItems.Add(organization.IsHead.ToString());
                item.SubItems.Add(organization.Special.ToString());
                item.SubItems.Add(organization.Military.ToString());
                item.SubItems.Add(organization.Ogrn);
                item.SubItems.Add(organization.Inn);
                item.SubItems.Add(organization.IsActive.ToString());
            }
            else
            {
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
            }


            return item;
        }

        public void UpdateListViewItem()
        {
            if (itemsCollection.Count == 0) return;
            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            long version = itemsCollection[selectedIndex].Version;
            itemsCollection[selectedIndex] = _dataSet.GetViewErvkOrganization(version);
            RepositoryDataSet.ViewErvkOrganization organization = itemsCollection[selectedIndex];
            ListViewItem item = itemsCache[selectedIndex - firstItemIndex];

            if (organization.Begin > DateTime.Today)
                item.ImageIndex = 2;
            else if (organization.Begin <= DateTime.Today && organization.End > DateTime.Today)
                item.ImageIndex = 0;
            else
                item.ImageIndex = 1;

            item.Text = organization.Code;
            item.SubItems[1].Text = organization.Name;
            item.SubItems[2].Text = organization.Authority;
            item.SubItems[3].Text = organization.Okato;
            item.SubItems[4].Text = organization.Begin.ToShortDateString();
            item.SubItems[5].Text = organization.End.ToShortDateString();

            item.SubItems[6].Text = organization.Phone;
            item.SubItems[7].Text = organization.Email;
            item.SubItems[8].Text = organization.Address;

            item.SubItems[9].Text = organization.OwnerName;

            if (organization.IsErvk)
            {
                item.SubItems[10].Text = organization.IsHead.ToString();
                item.SubItems[11].Text = organization.Special.ToString();
                item.SubItems[12].Text = organization.Military.ToString();
                item.SubItems[13].Text = organization.Ogrn;
                item.SubItems[14].Text = organization.Inn;
                item.SubItems[15].Text = organization.IsActive.ToString();
            }
            else
            {
                item.SubItems[10].Text = string.Empty;
                item.SubItems[11].Text = string.Empty;
                item.SubItems[12].Text = string.Empty;
                item.SubItems[13].Text = string.Empty;
                item.SubItems[14].Text = string.Empty;
                item.SubItems[15].Text = string.Empty;
            }

            Refresh();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsUpdate();
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (itemsCollection.Count == 0) return;

            baseListView.BeginUpdate();

            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            RepositoryDataSet.ViewErvkOrganization selectedOrganization = itemsCollection[selectedIndex];

            if (baseListView.Columns[e.Column].Tag == null ||
                baseListView.Columns[e.Column].Tag.ToString() == "UP")
            {
                if (e.Column == 0)
                    itemsCollection = itemsCollection.OrderBy(x => x.Code).ToArray();
                else if (e.Column == 1)
                    itemsCollection = itemsCollection.OrderBy(x => x.Name).ToArray();
                else if (e.Column == 2)
                    itemsCollection = itemsCollection.OrderBy(x => x.Authority).ToArray();
                else if (e.Column == 3)
                    itemsCollection = itemsCollection.OrderBy(x => x.Okato).ToArray();
                else if (e.Column == 4)
                    itemsCollection = itemsCollection.OrderBy(x => x.Begin).ToArray();
                else if (e.Column == 5)
                    itemsCollection = itemsCollection.OrderBy(x => x.End).ToArray();
                else if (e.Column == 6)
                    itemsCollection = itemsCollection.OrderBy(x => x.Phone).ToArray();
                else if (e.Column == 7)
                    itemsCollection = itemsCollection.OrderBy(x => x.Email).ToArray();
                else if (e.Column == 8)
                    itemsCollection = itemsCollection.OrderBy(x => x.Address).ToArray();
                else if (e.Column == 9)
                    itemsCollection = itemsCollection.OrderBy(x => x.OwnerName).ToArray();
                else if (e.Column == 10)
                    itemsCollection = itemsCollection.OrderBy(x => x.IsHead).ToArray();
                else if (e.Column == 11)
                    itemsCollection = itemsCollection.OrderBy(x => x.Special).ToArray();
                else if (e.Column == 12)
                    itemsCollection = itemsCollection.OrderBy(x => x.Military).ToArray();
                else if (e.Column == 13)
                    itemsCollection = itemsCollection.OrderBy(x => x.Ogrn).ToArray();
                else if (e.Column == 14)
                    itemsCollection = itemsCollection.OrderBy(x => x.Inn).ToArray();
                else if (e.Column == 15)
                    itemsCollection = itemsCollection.OrderBy(x => x.IsActive).ToArray();
                else
                    itemsCollection = itemsCollection.OrderBy(x => x.Code).ToArray();

                baseListView.Columns[e.Column].Tag = "DOWN";
            }
            else
            {
                if (e.Column == 0)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Code).ToArray();
                else if (e.Column == 1)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Name).ToArray();
                else if (e.Column == 2)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Authority).ToArray();
                else if (e.Column == 3)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Okato).ToArray();
                else if (e.Column == 4)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Begin).ToArray();
                else if (e.Column == 5)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.End).ToArray();
                else if (e.Column == 6)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Phone).ToArray();
                else if (e.Column == 7)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Email).ToArray();
                else if (e.Column == 8)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Address).ToArray();
                else if (e.Column == 9)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.OwnerName).ToArray();
                else if (e.Column == 10)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.IsHead).ToArray();
                else if (e.Column == 11)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Special).ToArray();
                else if (e.Column == 12)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Military).ToArray();
                else if (e.Column == 13)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Ogrn).ToArray();
                else if (e.Column == 14)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Inn).ToArray();
                else if (e.Column == 15)
                    itemsCollection = itemsCollection.OrderByDescending(x => x.IsActive).ToArray();
                else
                    itemsCollection = itemsCollection.OrderByDescending(x => x.Code).ToArray();

                baseListView.Columns[e.Column].Tag = "UP";
            }

            int selectIndex = itemsCollection.IndexOf(selectedOrganization);
            itemsCache = null;
            baseListView.SelectedIndices.Clear();
            baseListView.SelectedIndices.Add(selectIndex);
            baseListView.EnsureVisible(selectIndex);
            baseListView.EndUpdate();
        }

        public event EventHandler ItemSelectionChanged;
        public event EventHandler LockVisibleChanged;
        public event EventHandler ReserveVisibleChanged;
        public event EventHandler UnlockVisibleChanged;
        public event EventHandler FgisEsnsiOnlyVisibleChanged;
        public event EventHandler ErvkOnlyVisibleChanged;

        public event EventHandler<GaspsListViewEventArgs> ItemMouseClick;
        public event EventHandler<GaspsListViewEventArgs> ItemMouseDoubleClick;


        protected virtual void OnItemSelectionChanged(EventArgs e)
        {
            EventHandler ItemSelectionChangedEvent = ItemSelectionChanged;
            if (ItemSelectionChangedEvent != null)
            {
                ItemSelectionChangedEvent(this, e);
            }
        }

        protected virtual void OnLockVisibleChanged(EventArgs e)
        {
            ControlsValueChanged();
            EventHandler LockVisibleChangedEvent = LockVisibleChanged;
            if (LockVisibleChangedEvent != null)
            {
                LockVisibleChangedEvent(this, e);
            }
        }

        protected virtual void OnReserveVisibleChanged(EventArgs e)
        {
            ControlsValueChanged();
            EventHandler ReserveVisibleChangedEvent = ReserveVisibleChanged;
            if (ReserveVisibleChangedEvent != null)
            {
                ReserveVisibleChangedEvent(this, e);
            }
        }

        protected virtual void OnUnlockVisibleChanged(EventArgs e)
        {
            ControlsValueChanged();
            EventHandler UnlockVisibleChangedEvent = UnlockVisibleChanged;
            if (UnlockVisibleChangedEvent != null)
            {
                UnlockVisibleChangedEvent(this, e);
            }
        }

        protected virtual void OnFgisEsnsiOnlyVisibleChanged(EventArgs e)
        {
            ControlsValueChanged();
            EventHandler FgisEsnsiOnlyVisibleChangedEvent = FgisEsnsiOnlyVisibleChanged;
            if (FgisEsnsiOnlyVisibleChangedEvent != null)
            {
                FgisEsnsiOnlyVisibleChangedEvent(this, e);
            }
        }

        protected virtual void OnErvkOnlyVisibleChanged(EventArgs e)
        {
            ControlsValueChanged();
            EventHandler ErvkOnlyVisibleChangedEvent = ErvkOnlyVisibleChanged;
            if (ErvkOnlyVisibleChangedEvent != null)
            {
                ErvkOnlyVisibleChangedEvent(this, e);
            }
        }

        protected virtual void OnItemMouseClick(GaspsListViewEventArgs e)
        {
            EventHandler<GaspsListViewEventArgs> ItemMouseClickEvent = ItemMouseClick;
            if (ItemMouseClickEvent != null)
            {
                ItemMouseClickEvent(this, e);
            }
        }

        protected virtual void OnItemMouseDoubleClick(GaspsListViewEventArgs e)
        {
            EventHandler<GaspsListViewEventArgs> ItemMouseDoubleClickEvent = ItemMouseDoubleClick;
            if (ItemMouseDoubleClickEvent != null)
            {
                ItemMouseDoubleClickEvent(this, e);
            }
        }

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
                fgisEsnsiOnlyShow: _fgisEsnsiOnlyShow,
                ervkOnlyShow: _ervkOnlyShow);
            DetailsUpdate();
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            var focusedItem = listView.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
            {
                OnItemMouseClick(new GaspsListViewEventArgs(focusedItem, e));
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            var focusedItem = listView.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
            {
                OnItemMouseDoubleClick(new GaspsListViewEventArgs(focusedItem, e));
            }
        }
                
        private delegate void WorkerEventHandler(FilterParameters filter, AsyncOperation asyncOp);

        private SendOrPostCallback onProgressReportDelegate;
        private SendOrPostCallback onCompletedDelegate;

        private HybridDictionary userStateToLifetime = new HybridDictionary();

        #region Public events

        public event ProgressChangedEventHandler ProgressChanged;
        public event GaspsListViewCompletedEventHandler GaspsListViewCompleted;

        #endregion

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
            bool fgisEsnsiOnlyShow,
            bool ervkOnlyShow)
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
                fgisEsnsiOnlyShow: fgisEsnsiOnlyShow,
                ervkOnlyShow: ervkOnlyShow
                );

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

            WorkerEventHandler workerDelegate = new WorkerEventHandler(GaspsListViewWorker);
            workerDelegate.BeginInvoke(
                filter,
                asyncOp,
                null,
                null);
        }

        private bool TaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }

        public void CancelAsync(object taskId)
        {
            AsyncOperation asyncOp = userStateToLifetime[taskId] as AsyncOperation;
            if (asyncOp != null)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(taskId);
                }
            }
        }

        private void GaspsListViewWorker(
            FilterParameters filter,
            AsyncOperation asyncOp)
        {
            IList<Repositoryes.RepositoryDataSet.ViewErvkOrganization> collection = null;
            Exception e = null;

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    collection = BuildGaspsListViewList(
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

        private IList<RepositoryDataSet.ViewErvkOrganization> BuildGaspsListViewList(
            FilterParameters filter,
            AsyncOperation asyncOp)
        {
            IList<Repositoryes.RepositoryDataSet.ViewErvkOrganization> list =
                filter.DataSet.GetViewErvkOrganizationFilter(
                authority: filter.Authority,
                okato: filter.Okato,
                code: filter.Code,
                name: filter.Name,
                unlockShow: filter.UnlockShow,
                reserveShow: filter.ReserveShow,
                lockShow: filter.LockShow,
                fgisEsnsiOnlyShow: filter.FgisEsnsiOnlyShow,
                ervkOnlyShow: filter.ErvkOnlyShow);

            return list;
        }


        private void ItemCollectionCompleted(object operationState)
        {
            GaspsListViewCompletedEventArgs e = operationState as GaspsListViewCompletedEventArgs;
            ApplyFilter(e.Collection);
            OnGaspsListViewCompleted(e);
        }

        private void ReportProgress(object state)
        {
            ProgressChangedEventArgs e = state as ProgressChangedEventArgs;
            OnProgressChanged(e);
        }

        protected void OnGaspsListViewCompleted(GaspsListViewCompletedEventArgs e)
        {
            GaspsListViewCompletedEventHandler GaspsListViewCompletedEvent = GaspsListViewCompleted;
            if (GaspsListViewCompletedEvent != null)
            {
                GaspsListViewCompletedEvent(this, e);
            }
        }

        protected void OnProgressChanged(ProgressChangedEventArgs e)
        {
            ProgressChangedEventHandler ProgressChangedEvent = ProgressChanged;
            if (ProgressChangedEvent != null)
            {
                ProgressChangedEvent(e);
            }
        }

        private void CompletionMethod(
            FilterParameters filter,
            IList<RepositoryDataSet.ViewErvkOrganization> collection,
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

            GaspsListViewCompletedEventArgs e =
                new GaspsListViewCompletedEventArgs(
                collection,
                exception,
                canceled,
                asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onCompletedDelegate, e);
        }

        #endregion


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
            this.phoneColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addressColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ownerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.special = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.military = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ogrn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.endColumn,
            this.phoneColumn,
            this.emailColumn,
            this.addressColumn,
            this.ownerName,
            this.isHead,
            this.special,
            this.military,
            this.ogrn,
            this.inn,
            this.isActive});
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
            this.beginColumn.Width = 100;
            // 
            // endColumn
            // 
            this.endColumn.Text = "Окончание действия";
            this.endColumn.Width = 100;
            // 
            // phoneColumn
            // 
            this.phoneColumn.Text = "Телефон";
            this.phoneColumn.Width = 120;
            // 
            // emailColumn
            // 
            this.emailColumn.Text = "Эл.почта";
            this.emailColumn.Width = 120;
            // 
            // addressColumn
            // 
            this.addressColumn.Text = "Адрес";
            this.addressColumn.Width = 200;
            // 
            // ownerName
            // 
            this.ownerName.Text = "Владелец";
            this.ownerName.Width = 200;
            // 
            // isActive
            // 
            this.isActive.Text = "Активная";
            // 
            // isHead
            // 
            this.isHead.Text = "Головная";
            // 
            // special
            // 
            this.special.Text = "Специализированная";
            // 
            // military
            // 
            this.military.Text = "Военная";
            // 
            // ogrn
            // 
            this.ogrn.Text = "ОГРН";
            // 
            // inn
            // 
            this.inn.Text = "ИНН";
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
        private System.Windows.Forms.ColumnHeader codeColumn;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader authorityColumn;
        private System.Windows.Forms.ColumnHeader okatoColumn;
        private System.Windows.Forms.ColumnHeader beginColumn;
        private System.Windows.Forms.ColumnHeader endColumn;

        private class FilterParameters
        {
            public RepositoryDataSet DataSet { get; private set; }
            public long? Authority { get; private set; }
            public string Okato { get; private set; }
            public string Code { get; private set; }
            public string Name { get; private set; }
            public bool UnlockShow { get; private set; }
            public bool ReserveShow { get; private set; }
            public bool LockShow { get; private set; }
            public bool FgisEsnsiOnlyShow { get; private set; }
            public bool ErvkOnlyShow { get; private set; }

            private int hashCode;

            public FilterParameters(RepositoryDataSet dataSet, long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
            {
                DataSet = dataSet;
                Authority = authority;
                Okato = okato;
                Code = code;
                Name = name;
                UnlockShow = unlockShow;
                ReserveShow = reserveShow;
                LockShow = lockShow;
                FgisEsnsiOnlyShow = fgisEsnsiOnlyShow;
                ErvkOnlyShow = ervkOnlyShow;

                hashCode = ("GaspsListViewFilterParameters" +
                    (Authority.HasValue ? Authority.Value.ToString() : "Null") + "F1" +
                    Okato + "F2" +
                    Code + "F3" +
                    Name + "F4" +
                    UnlockShow.ToString() + "F5" +
                    ReserveShow.ToString() + "F6" +
                    LockShow.ToString() + "F7" +
                    FgisEsnsiOnlyShow.ToString() + "F8" +
                    ErvkOnlyShow.ToString())
                    .GetHashCode();
            }


            public static bool Equals(FilterParameters parameterA, FilterParameters parameterB)
            {
                return Equals(objA: parameterA, objB: parameterB);
            }

            public static new bool Equals(object objA, object objB)
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

            public override bool Equals(Object obj)
            {
                return Equals(objA: this, objB: obj);
            }
            public bool Equals(FilterParameters obj)
            {
                return Equals(objA: this, objB: obj);
            }

            public override int GetHashCode()
            {
                return hashCode;
            }
        }
    }


    public class GaspsListViewEventArgs : EventArgs
    {
        public GaspsListViewEventArgs(ListViewItem item, MouseEventArgs arg)
        {
            FocusedItem = item;
            Button = arg.Button;
            Clicks = arg.Clicks;
            Delta = arg.Delta;
            Location = arg.Location;
            X = arg.X;
            Y = arg.Y;
        }

        public ListViewItem FocusedItem { get; private set; }

        public MouseButtons Button { get; private set; }

        public int Clicks { get; private set; }

        public int Delta { get; private set; }

        public Point Location { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

    }

    public delegate void ProgressChangedEventHandler(ProgressChangedEventArgs e);

    public delegate void GaspsListViewCompletedEventHandler(object sender, GaspsListViewCompletedEventArgs e);

    public class GaspsListViewProgressChangedEventArgs : ProgressChangedEventArgs
    {
        private long latestItemIndex = 0;

        public GaspsListViewProgressChangedEventArgs(
            long latestItemIndex,
            int progressPercentage,
            object userToken) : base(progressPercentage, userToken)
        {
            this.latestItemIndex = latestItemIndex;
        }

        public long LatestItemIndex
        {
            get
            {
                return latestItemIndex;
            }
        }
    }

    public class GaspsListViewCompletedEventArgs : AsyncCompletedEventArgs
    {
        private IList<RepositoryDataSet.ViewErvkOrganization> collection;

        public GaspsListViewCompletedEventArgs(
            IList<RepositoryDataSet.ViewErvkOrganization> collection,
            Exception e,
            bool canceled,
            object state) : base(e, canceled, state)
        {
            this.collection = collection;
        }

        public IList<RepositoryDataSet.ViewErvkOrganization> Collection
        {
            get
            {
                return collection;
            }
        }
    }
}

