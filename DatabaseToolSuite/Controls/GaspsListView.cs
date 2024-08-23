﻿using DatabaseToolSuite.Repositoryes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Controls
{
    public partial class GaspsListView : UserControl
    {
        private RepositoryDataSet _dataSet;
        private IList<ViewErvkOrganization> itemsCollection;
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
            itemsCollection = new List<ViewErvkOrganization>();

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

            InitializeFilter(dataSet: DataSet,
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

                    InitializeFilter(dataSet: DataSet,
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
            }
        }

        public gaspsRow DataRow { get; private set; }
        
        public ViewErvkOrganization SelectedOrganization
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

        public void SetFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
        {
            InitializeFilter(dataSet: DataSet,
                authority: authority,
                okato: okato,
                code: code,
                name: name,
                unlockShow: unlockShow,
                reserveShow: reserveShow,
                lockShow: lockShow,
                fgisEsnsiOnlyShow: fgisEsnsiOnlyShow,
                ervkOnlyShow: ervkOnlyShow);
            
        }

        private void InitializeFilter(RepositoryDataSet dataSet, long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
        {
            if (dataSet == null) return;

            baseListView.BeginUpdate();

            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            ViewErvkOrganization selectedOrganization = itemsCollection.Count > 0 ? itemsCollection[selectedIndex] : null;

            baseListView.VirtualMode = true;
            itemsCache = null;

            itemsCollection = dataSet.GetViewErvkOrganizationFilter(
                authority: authority,
                okato: okato,
                code: code,
                name: name,
                unlockShow: unlockShow,
                reserveShow: reserveShow,
                lockShow: lockShow,
                fgisEsnsiOnlyShow: fgisEsnsiOnlyShow,
                ervkOnlyShow: ervkOnlyShow);

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
                ViewErvkOrganization newOrganization = itemsCollection[baseListView.SelectedIndices[0]];
                if (DataRow ==null ||
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

        private ListViewItem CreateListViewItem(ViewErvkOrganization organization)
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

            item.SubItems.Add(organization.IsHead.ToString());
            item.SubItems.Add(organization.Special.ToString());
            item.SubItems.Add(organization.Military.ToString());
            item.SubItems.Add(organization.Ogrn);
            item.SubItems.Add(organization.Inn);
            item.SubItems.Add(organization.IsActive.ToString());

            return item;
        }


        public void UpdateListViewItem(           
            string code,           
            string phone,
            string email,
            string address,            
            string okatoCode)
        {
            if (itemsCollection.Count == 0) return;
            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            ViewErvkOrganization organization = itemsCollection[selectedIndex];

            UpdateListViewItem(
                name: organization.Name,
                authority: organization.Authority,
                okato: organization.Okato,
                code: code,
                begin: organization.Begin,
                end: organization.End,
                phone: phone,
                email: email,
                address: address,
                version: organization.Version,
                authorityId: organization.AuthorityId,
                okatoCode: okatoCode,
                key: organization.Key,
                ownerId: organization.OwnerId,
                ownerName: organization.OwnerName,
                esnsiCode: organization.EsnsiCode,
                isHead: organization.IsHead,
                special: organization.Special,
                military: organization.Military,
                isActive: organization.IsActive,
                idVersionProc: organization.IdVersionProc,
                idVersionHead: organization.IdVersionHead,
                dateStartVersion: organization.DateStartVersion,
                dateCloseProc: organization.DateCloseProc,
                ogrn: organization.Ogrn,
                inn: organization.Inn,
                isFgisEsnsi: organization.IsFgisEsnsi,
                isErvk: organization.IsErvk);           
        }

        public void UpdateListViewItem(
            string name,
            string authority,
            string okato,
            string code,
            DateTime begin,
            DateTime end,
            string phone,
            string email,
            string address,
            long version,
            long authorityId,
            string okatoCode,
            long key,
            long ownerId,
            string ownerName,
            long esnsiCode,
            bool isHead,
            bool special,
            bool military,
            bool isActive,
            string idVersionProc,
            long idVersionHead,
            DateTime dateStartVersion,
            DateTime dateCloseProc,
            string ogrn,
            string inn,
            bool isFgisEsnsi,
            bool isErvk
            )
        {
            if (itemsCollection.Count == 0) return;
            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            ViewErvkOrganization organization = itemsCollection[selectedIndex];
            itemsCollection[selectedIndex] = new ViewErvkOrganization(
                name: name,
                authority: authority,
                okato: okato,
                code: code,
                begin: begin,
                end: end,
                phone: phone,
                email: email,
                address: address,
                version: version,
                authorityId: authorityId,
                okatoCode: okatoCode,
                key: key,
                ownerId: ownerId,
                ownerName: ownerName,
                esnsiCode: esnsiCode,
                isHead: isHead,
                special: special,
                military: military,
                isActive: isActive,
                idVersionProc: idVersionProc,
                idVersionHead: idVersionHead,
                dateStartVersion: dateStartVersion,
                dateCloseProc: dateCloseProc,
                ogrn: ogrn,
                inn: inn,
                isFgisEsnsi: isFgisEsnsi,
                isErvk: isErvk);
            UpdateListViewItem();
        }

        public void UpdateListViewItem()
        {
            if (itemsCollection.Count == 0) return;
            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            long version = itemsCollection[selectedIndex].Version;
            itemsCollection[selectedIndex] = _dataSet.GetViewErvkOrganization(version);
            ViewErvkOrganization organization = itemsCollection[selectedIndex];
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

            item.SubItems[10].Text = organization.IsHead.ToString();
            item.SubItems[11].Text = organization.Special.ToString();
            item.SubItems[12].Text = organization.Military.ToString();
            item.SubItems[13].Text = organization.Ogrn;
            item.SubItems[14].Text = organization.Inn;
            item.SubItems[15].Text = organization.IsActive.ToString();

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
            ViewErvkOrganization selectedOrganization = itemsCollection[selectedIndex];

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
            ItemSelectionChanged?.Invoke(this, e);
        }

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

        protected virtual void OnFgisEsnsiOnlyVisibleChanged(EventArgs e)
        {
            ControlsValueChanged();
            FgisEsnsiOnlyVisibleChanged?.Invoke(this, e);
        }

        protected virtual void OnErvkOnlyVisibleChanged(EventArgs e)
        {
            ControlsValueChanged();
            ErvkOnlyVisibleChanged?.Invoke(this, e);
        }

        protected virtual void OnItemMouseClick(GaspsListViewEventArgs e)
        {
            ItemMouseClick?.Invoke(this, e);
        }

        protected virtual void OnItemMouseDoubleClick(GaspsListViewEventArgs e)
        {
            ItemMouseDoubleClick?.Invoke(this, e);
        }

        private void ControlsValueChanged()
        {
            baseListView.SelectedIndices.Clear();
            InitializeFilter(
                dataSet: DataSet,
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

        public ListViewItem FocusedItem { get; }

        public MouseButtons Button { get; }

        public int Clicks { get; }

        public int Delta { get; }

        public Point Location { get; }

        public int X { get; }

        public int Y { get; }

    }

}

