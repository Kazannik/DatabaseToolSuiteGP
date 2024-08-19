using System;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    public class RemoveOrganizationDialog : DialogBase
    {

        public RemoveOrganizationDialog(gaspsRow row): base()
        {
            ApplyButtonVisible = false;

            DataRow = row;

            InitializeComponent();

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            lockDateTimePicker.MinDate = Services.MasterDataSystem.MIN_DATE;
            lockDateTimePicker.MaxDate = Services.MasterDataSystem.MAX_DATE;

            Text = "Блокировка записи о подразделении правоохранительного органа";
            DialogCaption = "Блокировка записи о подразделении";

            DetailsUpdate();
        }

        private void DetailsUpdate()
        {

            listView1.Items.Clear();
            listView1.Items.Add("Наименование").SubItems.Add(DataRow.name);
            listView1.Items.Add("Код подразделения").SubItems.Add(DataRow.code);
            listView1.Items.Add("Вид органа").SubItems.Add(DataRow.authority_id.ToString("00") + " - " + Services.FileSystem.Repository.DataSet.authority.GetName(DataRow.authority_id));
            listView1.Items.Add("ОКАТО").SubItems.Add(DataRow.okato_code + " - " + Services.FileSystem.Repository.DataSet.okato.GetName(DataRow.okato_code));
            listView1.Items.Add("Дата начала действия").SubItems.Add(DataRow.date_beg.ToShortDateString());
            listView1.Items.Add("Дата окончания действия").SubItems.Add(DataRow.date_end.ToShortDateString());
            if (DataRow.owner_id > 0)
            {
                gaspsRow owner = Services.FileSystem.Repository.DataSet.gasps.GetLastVersionOrganizationFromKey(DataRow.owner_id);
                listView1.Items.Add("Владелец").SubItems.Add("(" + owner.code + ") " + owner.name);
            }
        }

        public gaspsRow DataRow { get; }

        public DateTime LockDate
        {
            get
            {
                return lockDateTimePicker.Value;
            }
        }


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveOrganizationDialog));
            this.lockDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(640, 419);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(478, 419);
            // 
            // lockDateTimePicker
            // 
            this.lockDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lockDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lockDateTimePicker.Location = new System.Drawing.Point(128, 87);
            this.lockDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.lockDateTimePicker.Name = "lockDateTimePicker";
            this.lockDateTimePicker.Size = new System.Drawing.Size(191, 26);
            this.lockDateTimePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(124, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Дата блокировки:";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(16, 141);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(692, 227);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 600;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(375, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Запись о подразделении правоохранительного органа:";
            // 
            // RemoveOrganizationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(725, 446);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lockDateTimePicker);
            this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.Delete32;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(741, 481);
            this.Name = "RemoveOrganizationDialog";
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.lockDateTimePicker, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker lockDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;



    }
}
