using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DatabaseToolSuite.Repositoryes;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;
using System.Drawing;

namespace DatabaseToolSuite.Controls
{
    public partial class GaspsListView : UserControl
    {
        private RepositoryDataSet _dataSet;
        private IList<gaspsRow> rowsCollection;
        private ListViewItem[] itemsCache;
        private int firstItemIndex;

        private Dictionary<long, string> authorityCollection;
        private Dictionary<string, string> okatoCollection;

        private bool _lockShow;
        private bool _reserveShow;
        private bool _unlockShow;
        private long? _authority;
        private string _okato;
        private string _code;
        private string _name;

        public GaspsListView()
        {
            rowsCollection = new List<gaspsRow>();
            authorityCollection = new Dictionary<long, string>();
            okatoCollection = new Dictionary<string, string>();

            _lockShow = false;
            _reserveShow = true;
            _unlockShow = true;

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
                lockShow: _lockShow);

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
                        lockShow: _lockShow);

                    DetailsUpdate();
                }
            }
        }

        public gaspsRow DataRow { get; private set; }
             
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
        
        public int RowCount
        {
            get { return rowsCollection.Count; }
        }

        public void SetFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
        {
            InitializeFilter(dataSet: DataSet, 
                authority: authority, 
                okato: okato, 
                code: code, 
                name: name, 
                unlockShow: 
                unlockShow, 
                reserveShow: reserveShow, 
                lockShow: lockShow);
        }

        private void InitializeFilter(RepositoryDataSet dataSet, long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
        {
            if (dataSet == null) return;

            baseListView.BeginUpdate();

            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            gaspsRow selectedRow = rowsCollection.Count > 0 ? rowsCollection[selectedIndex]: null;

            authorityCollection.Clear();
            foreach (authorityRow row in DataSet.authority)
            {
                authorityCollection.Add(row.id, row.name);
            }

            okatoCollection.Clear();
            foreach (okatoRow row in DataSet.okato)
            {
                okatoCollection.Add(row.code, row.name);
            }

            baseListView.VirtualMode = true;
            itemsCache = null;
            
            rowsCollection = dataSet.gasps.GetOrganizationFilter(
                authority: authority,
                okato: okato,
                code: code,
                name: name,
                unlockShow: unlockShow,
                reserveShow: reserveShow,
                lockShow: lockShow);

            baseListView.VirtualListSize = rowsCollection.Count();

            baseListView.SelectedIndices.Clear();
            int selectIndex = rowsCollection.IndexOf(selectedRow);
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
                gaspsRow newRow = rowsCollection[baseListView.SelectedIndices[0]];
                if (DataRow != newRow)
                {
                    DataRow = newRow;
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
                e.Item = CreateListViewItem(rowsCollection[e.ItemIndex]);
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
                itemsCache[i] = CreateListViewItem(rowsCollection[firstItemIndex + i]);
            }
        }

        //private void ListView_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        //{
        //    //We've gotten a search request.
        //    //In this example, finding the item is easy since it's
        //    //just the square of its index.  We'll take the square root
        //    //and round.
        //    double x = 0;
        //    if (Double.TryParse(e.Text, out x)) //check if this is a valid search
        //    {
        //        x = Math.Sqrt(x);
        //        x = Math.Round(x);
        //        e.Index = (int)x;
        //    }
        //    //If e.Index is not set, the search returns null.
        //    //Note that this only handles simple searches over the entire
        //    //list, ignoring any other settings.  Handling Direction, StartIndex,
        //    //and the other properties of SearchForVirtualItemEventArgs is up
        //    //to this handler.
        //}

        private ListViewItem CreateListViewItem(gaspsRow row)
        {
            ListViewItem item = new ListViewItem(row.code);

            if (row.date_beg > DateTime.Today)
                item.ImageIndex = 2;
            else if (row.date_beg <= DateTime.Today && row.date_end > DateTime.Today)
                item.ImageIndex = 0;
            else
                item.ImageIndex = 1;
                        
            item.Text = row.code;
            item.SubItems.Add(row.name);
            item.SubItems.Add(authorityCollection[row.authority_id]);
            item.SubItems.Add(row.okato_code + " - " + okatoCollection[row.okato_code]);
            item.SubItems.Add(row.date_beg.ToShortDateString());
            item.SubItems.Add(row.date_end.ToShortDateString());

            //item.SubItems.Add(row.key.ToString());
            //item.SubItems.Add(row.version.ToString());
            return item;
        }


        public void UpdateListViewItem()
        {
            if (rowsCollection.Count == 0) return;
            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            gaspsRow selectedRow = rowsCollection[selectedIndex];


            ListViewItem item = itemsCache[selectedIndex - firstItemIndex];

            if (selectedRow.date_beg > DateTime.Today)
                item.ImageIndex = 2;
            else if (selectedRow.date_beg <= DateTime.Today && selectedRow.date_end > DateTime.Today)
                item.ImageIndex = 0;
            else
                item.ImageIndex = 1;

            item.Text = selectedRow.code;
            item.SubItems[1].Text = selectedRow.name;
            item.SubItems[2].Text = authorityCollection[selectedRow.authority_id];
            item.SubItems[3].Text = selectedRow.okato_code + " - " + okatoCollection[selectedRow.okato_code];
            item.SubItems[4].Text = selectedRow.date_beg.ToShortDateString();
            item.SubItems[5].Text = selectedRow.date_end.ToShortDateString();

            //item.SubItems[6].Text = selectedRow.key.ToString();
            //item.SubItems[7].Text = selectedRow.version.ToString();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsUpdate();
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (rowsCollection.Count == 0) return;

            baseListView.BeginUpdate();

            int selectedIndex = baseListView.SelectedIndices.Count > 0 ? baseListView.SelectedIndices[0] : 0;
            gaspsRow selectedRow = rowsCollection[selectedIndex];

            if (baseListView.Columns[e.Column].Tag == null ||
                baseListView.Columns[e.Column].Tag.ToString() == "UP")
            {
                if (e.Column == 0)
                    rowsCollection = rowsCollection.OrderBy(x => x.code).ToArray();
                else if (e.Column == 1)
                    rowsCollection = rowsCollection.OrderBy(x => x.name).ToArray();
                else if (e.Column == 2)
                    rowsCollection = rowsCollection.OrderBy(x => x.authority_id).ToArray();
                else if (e.Column == 3)
                    rowsCollection = rowsCollection.OrderBy(x => x.okato_code).ToArray();
                else if (e.Column == 4)
                    rowsCollection = rowsCollection.OrderBy(x => x.date_beg).ToArray();
                else if (e.Column == 5)
                    rowsCollection = rowsCollection.OrderBy(x => x.date_end).ToArray();
                else
                    rowsCollection = rowsCollection.OrderBy(x => x.code).ToArray();

                baseListView.Columns[e.Column].Tag = "DOWN";
            }
            else
            {
                if (e.Column == 0)
                    rowsCollection = rowsCollection.OrderByDescending(x => x.code).ToArray();
                else if (e.Column == 1)
                    rowsCollection = rowsCollection.OrderByDescending(x => x.name).ToArray();
                else if (e.Column == 2)
                    rowsCollection = rowsCollection.OrderByDescending(x => x.authority_id).ToArray();
                else if (e.Column == 3)
                    rowsCollection = rowsCollection.OrderByDescending(x => x.okato_code).ToArray();
               else if (e.Column == 4)
                    rowsCollection = rowsCollection.OrderByDescending(x => x.date_beg).ToArray();
                else if (e.Column == 5)
                    rowsCollection = rowsCollection.OrderByDescending(x => x.date_end).ToArray();
                else
                    rowsCollection = rowsCollection.OrderByDescending(x => x.code).ToArray();

                baseListView.Columns[e.Column].Tag = "UP";
            }

            int selectIndex = rowsCollection.IndexOf(selectedRow);
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
            InitializeFilter(dataSet: DataSet,
                authority: _authority,
                okato: _okato,
                code: _code,
                name: _name,
                unlockShow: _unlockShow,
                reserveShow: _reserveShow,
                lockShow: _lockShow);
            DetailsUpdate();
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            var focusedItem = listView.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
            {
                OnItemMouseClick(new GaspsListViewEventArgs(focusedItem, e ));
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
