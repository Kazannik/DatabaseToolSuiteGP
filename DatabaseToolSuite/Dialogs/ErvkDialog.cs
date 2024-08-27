using DatabaseToolSuite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    class ErvkDialog : DialogBase
    {
        public ervkRow DataRow { get; }
        
        private bool oldIsHead;
        private bool oldSpecial;
        private bool oldMilitary;
        private bool oldIsActive;
        private long oldIdVersionHead;
        private long oldIdSuccession;
        private DateTime oldDateStartVersion;
        private DateTime oldDateCloseProc;
        private string oldOgrn;
        private string oldInn;
        
        private Button deleteOwnerButton;
        private Button selectOwnerButton;
        private TextBox ownerTextBox;
        private Label ownerLabel;
        private Button autoSelectOwnerButton;
        protected Label beginDateLabel;
        protected DateTimePicker beginDateTimePicker;
        protected Label endDateLabel;
        protected DateTimePicker endDateTimePicker;
        private Button getOwnerArgButton;

        /// <summary>
        /// Признак активности записи.
        /// </summary>
        public bool IsActive { get { return isActiveCheckBox.Checked; } }

        /// <summary>
        /// Признак наличия подчиненных прокуратур.
        /// </summary>
        public bool IsHead { get { return isHeadCheckBox.Checked; } }

        /// <summary>
        /// Код (esnsiCode) вышестоящей прокуратуры.
        /// </summary>
        public long IdVersionHead { get; private set; }

        /// <summary>
        /// Код (esnsiCode) бывшей прокуратуры.
        /// </summary>
        public long IdSuccession { get; private set; }

        /// <summary>
        /// Специализированная прокуратура
        /// </summary>
        public bool IsSpecial { get { return isSpecialCheckBox.Checked; } }

        /// <summary>
        /// Военная прокуратура
        /// </summary>
        public bool IsMilitary { get { return isMilitaryCheckBox.Checked; } }

        /// <summary>
        /// Дата начала действия записи.
        /// </summary>
        public DateTime DateStartVersion { get { return beginDateTimePicker.Value; } }

        /// <summary>
        /// Дата прекращения действия записи.
        /// </summary>
        public DateTime DateCloseProc { get { return endDateTimePicker.Value; } }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get { return innNumericTextBox.Text; } }
        
        /// <summary>
        /// ОГРН
        /// </summary>
        public string Ogrn { get { return ogrnNumericTextBox.Text; } }

        
        public ErvkDialog(): base()
        {
            ApplyButtonVisible = false;

            InitializeComponent();
        }

        public ErvkDialog(ervkRow row) : base()
        {
            ApplyButtonVisible = false;

            InitializeComponent();

            DataRow = row;

            FormBorderStyle = FormBorderStyle.Sizable;

            Text = "ФГИС 'Единая система нормативно-справочной информации'";
            DialogCaption = "Сведения о прокуратуре для ЕРВК";

            beginDateTimePicker.MinDate = MasterDataSystem.MIN_DATE;
            beginDateTimePicker.MaxDate = MasterDataSystem.MAX_DATE;

            endDateTimePicker.MinDate = MasterDataSystem.MIN_DATE;
            endDateTimePicker.MaxDate = MasterDataSystem.MAX_DATE;

            oldIsHead = DataRow.isHead;
            oldSpecial = DataRow.special;
            oldMilitary = DataRow.military;
            oldIsActive = DataRow.isActive;
            oldIdVersionHead = DataRow.IsidVersionHeadNull() ? 0 : DataRow.idVersionHead;
            oldIdSuccession = DataRow.IsidSuccessionNull() ? 0 : DataRow.idSuccession;
            oldDateStartVersion = DataRow.dateStartVersion;
            oldDateCloseProc = DataRow.IsdateCloseProcNull() ? MasterDataSystem.MAX_DATE : DataRow.dateCloseProc;
            oldOgrn = DataRow.IsogrnNull() ? string.Empty : DataRow.ogrn;
            oldInn = DataRow.IsinnNull() ? string.Empty : DataRow.inn;

            esnsiNameTextBox.Text = DataRow.gaspsRow.name;

            isHeadCheckBox.Checked = DataRow.isHead;
            isSpecialCheckBox.Checked = DataRow.special;
            isMilitaryCheckBox.Checked = DataRow.military;
            isActiveCheckBox.Checked = DataRow.isActive;

            beginDateTimePicker.Value = DataRow.dateStartVersion;
            endDateTimePicker.Value = DataRow.IsdateCloseProcNull() ? MasterDataSystem.MAX_DATE : DataRow.dateCloseProc;

            ogrnNumericTextBox.Text = DataRow.IsogrnNull() ? string.Empty : DataRow.ogrn;
            innNumericTextBox.Text = DataRow.IsinnNull() ? string.Empty : DataRow.inn;

            if (MasterDataSystem.DataSet.ervk.ExistsEsnsiCode(DataRow.IsidVersionHeadNull() ? 0 : DataRow.idVersionHead))
            {
                long ownerVersion = MasterDataSystem.DataSet.ervk.GetFromEsnsiCode(DataRow.IsidVersionHeadNull() ? 0 : DataRow.idVersionHead).version;
                gaspsRow owner = MasterDataSystem.DataSet.gasps.Get(ownerVersion);
                ownerTextBox.Text = owner.name + " (код: " + owner.code + ")";
            }
            else
            {
                ownerTextBox.Text = string.Empty;
            }           

            OkButtonEnabled = false;
        }


        private void Controls_ValueChanged(object sender, EventArgs e)
        {
            //esnsiAutokeyTextBox.Text = "FED_GENPROK_ORGANIZATION_" + esnsiIdNumericTextBox.Text;
            //esnsiRegionTextBox.Text = esnsiOkatoComboBox.SelectedItem != null ? esnsiOkatoComboBox.SelectedItem.Name2 : string.Empty;

            if (
                oldIsHead != IsHead ||
                oldSpecial != IsSpecial ||
                oldMilitary != IsMilitary ||
                oldIsActive != IsActive ||
                oldIdVersionHead != IdVersionHead ||
                oldIdSuccession != IdSuccession ||
                oldDateStartVersion != DateStartVersion ||
                oldDateCloseProc != DateCloseProc ||
                oldOgrn != Ogrn ||
                oldInn != Inn
                )
            {
                OkButtonEnabled = true;
            }
            else
            {
                OkButtonEnabled = false;
            }
        }


        private System.Windows.Forms.TextBox esnsiNameTextBox;
        private Controls.NumericTextBox innNumericTextBox;
        private System.ComponentModel.IContainer components;
        private Label label1;
        private Label label2;
        private Controls.NumericTextBox ogrnNumericTextBox;
        private CheckBox isSpecialCheckBox;
        private CheckBox isMilitaryCheckBox;
        private CheckBox isActiveCheckBox;
        private CheckBox isHeadCheckBox;
        private System.Windows.Forms.Label esnsiNameLabel;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErvkDialog));
            this.esnsiNameTextBox = new System.Windows.Forms.TextBox();
            this.esnsiNameLabel = new System.Windows.Forms.Label();
            this.innNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ogrnNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
            this.isSpecialCheckBox = new System.Windows.Forms.CheckBox();
            this.isMilitaryCheckBox = new System.Windows.Forms.CheckBox();
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.isHeadCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteOwnerButton = new System.Windows.Forms.Button();
            this.selectOwnerButton = new System.Windows.Forms.Button();
            this.ownerTextBox = new System.Windows.Forms.TextBox();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.autoSelectOwnerButton = new System.Windows.Forms.Button();
            this.getOwnerArgButton = new System.Windows.Forms.Button();
            this.beginDateLabel = new System.Windows.Forms.Label();
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(637, 632);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(475, 632);
            // 
            // esnsiNameTextBox
            // 
            this.esnsiNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiNameTextBox.Location = new System.Drawing.Point(16, 90);
            this.esnsiNameTextBox.Name = "esnsiNameTextBox";
            this.esnsiNameTextBox.ReadOnly = true;
            this.esnsiNameTextBox.Size = new System.Drawing.Size(694, 27);
            this.esnsiNameTextBox.TabIndex = 8;
            // 
            // esnsiNameLabel
            // 
            this.esnsiNameLabel.AutoSize = true;
            this.esnsiNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiNameLabel.Location = new System.Drawing.Point(12, 67);
            this.esnsiNameLabel.Name = "esnsiNameLabel";
            this.esnsiNameLabel.Size = new System.Drawing.Size(246, 20);
            this.esnsiNameLabel.TabIndex = 7;
            this.esnsiNameLabel.Text = "Наименование прокуратуры";
            // 
            // innNumericTextBox
            // 
            this.innNumericTextBox.Location = new System.Drawing.Point(92, 134);
            this.innNumericTextBox.Name = "innNumericTextBox";
            this.innNumericTextBox.Size = new System.Drawing.Size(235, 22);
            this.innNumericTextBox.TabIndex = 11;
            this.innNumericTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "ИНН:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "ОГРН:";
            // 
            // ogrnNumericTextBox
            // 
            this.ogrnNumericTextBox.Location = new System.Drawing.Point(92, 170);
            this.ogrnNumericTextBox.Name = "ogrnNumericTextBox";
            this.ogrnNumericTextBox.Size = new System.Drawing.Size(235, 22);
            this.ogrnNumericTextBox.TabIndex = 13;
            this.ogrnNumericTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // isSpecialCheckBox
            // 
            this.isSpecialCheckBox.AutoSize = true;
            this.isSpecialCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isSpecialCheckBox.Location = new System.Drawing.Point(346, 135);
            this.isSpecialCheckBox.Name = "isSpecialCheckBox";
            this.isSpecialCheckBox.Size = new System.Drawing.Size(322, 24);
            this.isSpecialCheckBox.TabIndex = 15;
            this.isSpecialCheckBox.Text = "Специализированная прокуратура";
            this.isSpecialCheckBox.UseVisualStyleBackColor = true;
            this.isSpecialCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // isMilitaryCheckBox
            // 
            this.isMilitaryCheckBox.AutoSize = true;
            this.isMilitaryCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isMilitaryCheckBox.Location = new System.Drawing.Point(346, 169);
            this.isMilitaryCheckBox.Name = "isMilitaryCheckBox";
            this.isMilitaryCheckBox.Size = new System.Drawing.Size(213, 24);
            this.isMilitaryCheckBox.TabIndex = 16;
            this.isMilitaryCheckBox.Text = "Военная прокуратура";
            this.isMilitaryCheckBox.UseVisualStyleBackColor = true;
            this.isMilitaryCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.AutoSize = true;
            this.isActiveCheckBox.Location = new System.Drawing.Point(346, 256);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(141, 21);
            this.isActiveCheckBox.TabIndex = 17;
            this.isActiveCheckBox.Text = "Активная запись";
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            this.isActiveCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // isHeadCheckBox
            // 
            this.isHeadCheckBox.AutoSize = true;
            this.isHeadCheckBox.Location = new System.Drawing.Point(346, 283);
            this.isHeadCheckBox.Name = "isHeadCheckBox";
            this.isHeadCheckBox.Size = new System.Drawing.Size(239, 21);
            this.isHeadCheckBox.TabIndex = 18;
            this.isHeadCheckBox.Text = "Запись, имеющая подчиненных";
            this.isHeadCheckBox.UseVisualStyleBackColor = true;
            this.isHeadCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // deleteOwnerButton
            // 
            this.deleteOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteOwnerButton.Location = new System.Drawing.Point(499, 562);
            this.deleteOwnerButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteOwnerButton.Name = "deleteOwnerButton";
            this.deleteOwnerButton.Size = new System.Drawing.Size(213, 34);
            this.deleteOwnerButton.TabIndex = 47;
            this.deleteOwnerButton.Text = "Удалить владельца...";
            this.deleteOwnerButton.Click += new System.EventHandler(this.deleteOwnerButton_Click);
            // 
            // selectOwnerButton
            // 
            this.selectOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectOwnerButton.Location = new System.Drawing.Point(278, 562);
            this.selectOwnerButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectOwnerButton.Name = "selectOwnerButton";
            this.selectOwnerButton.Size = new System.Drawing.Size(213, 34);
            this.selectOwnerButton.TabIndex = 46;
            this.selectOwnerButton.Text = "Выбрать владельца...";
            this.selectOwnerButton.Click += new System.EventHandler(this.selectOwnerButton_Click);
            // 
            // ownerTextBox
            // 
            this.ownerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ownerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ownerTextBox.Location = new System.Drawing.Point(16, 499);
            this.ownerTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ownerTextBox.Multiline = true;
            this.ownerTextBox.Name = "ownerTextBox";
            this.ownerTextBox.ReadOnly = true;
            this.ownerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ownerTextBox.Size = new System.Drawing.Size(696, 56);
            this.ownerTextBox.TabIndex = 49;
            this.ownerTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // ownerLabel
            // 
            this.ownerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.Location = new System.Drawing.Point(13, 478);
            this.ownerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(77, 17);
            this.ownerLabel.TabIndex = 48;
            this.ownerLabel.Text = "Владелец:";
            // 
            // autoSelectOwnerButton
            // 
            this.autoSelectOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoSelectOwnerButton.Location = new System.Drawing.Point(16, 562);
            this.autoSelectOwnerButton.Margin = new System.Windows.Forms.Padding(4);
            this.autoSelectOwnerButton.Name = "autoSelectOwnerButton";
            this.autoSelectOwnerButton.Size = new System.Drawing.Size(213, 34);
            this.autoSelectOwnerButton.TabIndex = 50;
            this.autoSelectOwnerButton.Text = "Авто из ГАС ПС";
            this.autoSelectOwnerButton.Click += new System.EventHandler(this.autoSelectOwnerButton_Click);
            // 
            // getOwnerArgButton
            // 
            this.getOwnerArgButton.Location = new System.Drawing.Point(16, 200);
            this.getOwnerArgButton.Margin = new System.Windows.Forms.Padding(4);
            this.getOwnerArgButton.Name = "getOwnerArgButton";
            this.getOwnerArgButton.Size = new System.Drawing.Size(311, 34);
            this.getOwnerArgButton.TabIndex = 51;
            this.getOwnerArgButton.Text = "Получить из вышестоящей прокуратуры";
            this.getOwnerArgButton.Click += new System.EventHandler(this.getOwnerArgButton_Click);
            // 
            // beginDateLabel
            // 
            this.beginDateLabel.AutoSize = true;
            this.beginDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beginDateLabel.Location = new System.Drawing.Point(13, 284);
            this.beginDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.beginDateLabel.Name = "beginDateLabel";
            this.beginDateLabel.Size = new System.Drawing.Size(263, 20);
            this.beginDateLabel.TabIndex = 53;
            this.beginDateLabel.Text = "Дата введения новой версии:";
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beginDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beginDateTimePicker.Location = new System.Drawing.Point(17, 312);
            this.beginDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.Size = new System.Drawing.Size(191, 26);
            this.beginDateTimePicker.TabIndex = 52;
            this.beginDateTimePicker.ValueChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endDateLabel.Location = new System.Drawing.Point(13, 365);
            this.endDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(224, 20);
            this.endDateLabel.TabIndex = 55;
            this.endDateLabel.Text = "Дата блокировки версии:";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endDateTimePicker.Location = new System.Drawing.Point(17, 393);
            this.endDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(191, 26);
            this.endDateTimePicker.TabIndex = 54;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // ErvkDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(722, 659);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.beginDateLabel);
            this.Controls.Add(this.beginDateTimePicker);
            this.Controls.Add(this.getOwnerArgButton);
            this.Controls.Add(this.autoSelectOwnerButton);
            this.Controls.Add(this.deleteOwnerButton);
            this.Controls.Add(this.selectOwnerButton);
            this.Controls.Add(this.ownerTextBox);
            this.Controls.Add(this.ownerLabel);
            this.Controls.Add(this.isHeadCheckBox);
            this.Controls.Add(this.isActiveCheckBox);
            this.Controls.Add(this.isMilitaryCheckBox);
            this.Controls.Add(this.isSpecialCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ogrnNumericTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.innNumericTextBox);
            this.Controls.Add(this.esnsiNameTextBox);
            this.Controls.Add(this.esnsiNameLabel);
            this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.epgu;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErvkDialog";
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.esnsiNameLabel, 0);
            this.Controls.SetChildIndex(this.esnsiNameTextBox, 0);
            this.Controls.SetChildIndex(this.innNumericTextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ogrnNumericTextBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.isSpecialCheckBox, 0);
            this.Controls.SetChildIndex(this.isMilitaryCheckBox, 0);
            this.Controls.SetChildIndex(this.isActiveCheckBox, 0);
            this.Controls.SetChildIndex(this.isHeadCheckBox, 0);
            this.Controls.SetChildIndex(this.ownerLabel, 0);
            this.Controls.SetChildIndex(this.ownerTextBox, 0);
            this.Controls.SetChildIndex(this.selectOwnerButton, 0);
            this.Controls.SetChildIndex(this.deleteOwnerButton, 0);
            this.Controls.SetChildIndex(this.autoSelectOwnerButton, 0);
            this.Controls.SetChildIndex(this.getOwnerArgButton, 0);
            this.Controls.SetChildIndex(this.beginDateTimePicker, 0);
            this.Controls.SetChildIndex(this.beginDateLabel, 0);
            this.Controls.SetChildIndex(this.endDateTimePicker, 0);
            this.Controls.SetChildIndex(this.endDateLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void autoSelectOwnerButton_Click(object sender, EventArgs e)
        {
            long ownerKey = DataRow.gaspsRow.owner_id;
            try
            {
                gaspsRow owner = MasterDataSystem.DataSet.gasps.GetLastVersionOrganizationFromKey(ownerKey);
                if (MasterDataSystem.DataSet.ervk.ExistsRow(owner.version))
                {
                    ervkRow ownerErvk = MasterDataSystem.DataSet.ervk.Get(owner.version);
                    IdVersionHead = ownerErvk.esnsiCode;
                    ownerTextBox.Text = owner.name + " (код: " + owner.code + ")";
                }
                else
                {
                    IdVersionHead = 0;
                    ownerTextBox.Text = string.Empty;
                    MessageBox.Show(this, "Не удалось в автоматическом режиме получить код родительского подразделения!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Не удалось в автоматическом режиме получить код родительского подразделения!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void selectOwnerButton_Click(object sender, EventArgs e)
        {
            SelectOrganizationDialog dialog;
            
            dialog = new SelectOrganizationDialog(ervkOnlyShow: true);

            dialog.UnlockShow = true;
            dialog.LockShow = false;
            dialog.ReserveShow = false;
            dialog.LastLockOnlyShow = false;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                long ownerKey = dialog.DataRow.key;
                gaspsRow owner = MasterDataSystem.DataSet.gasps.GetLastVersionOrganizationFromKey(ownerKey);
                ervkRow ownerErvk = MasterDataSystem.DataSet.ervk.Get(owner.version);

                IdVersionHead = ownerErvk.esnsiCode;
                ownerTextBox.Text = dialog.DataRow.name + " (код: " + dialog.DataRow.code + ")";                
            }
        }

        private void deleteOwnerButton_Click(object sender, EventArgs e)
        {
            IdVersionHead = 0;
            ownerTextBox.Text = string.Empty;
        }

        private void getOwnerArgButton_Click(object sender, EventArgs e)
        {
            long ownerKey = DataRow.IsidVersionHeadNull() ? 0 : DataRow.idVersionHead;
            if (MasterDataSystem.DataSet.ervk.ExistsRow(ownerKey))
            {
                ervkRow ownerErvk = MasterDataSystem.DataSet.ervk.Get(ownerKey);
                innNumericTextBox.Text = ownerErvk.IsinnNull() ? string.Empty : ownerErvk.inn;
                ogrnNumericTextBox.Text = ownerErvk.IsogrnNull() ? string.Empty : ownerErvk.ogrn;
            }
            else
            {
                innNumericTextBox.Text = string.Empty;
                ogrnNumericTextBox.Text = string.Empty;
                MessageBox.Show(this, "Не удалось в автоматическом режиме получить ИНН и ОГРН вышестоящего органа!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
