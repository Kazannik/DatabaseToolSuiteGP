using System;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    class EsnsiDialog : DialogBase
    {
        public fgis_esnsiRow DataRow { get; }

        private long oldRegionCode;
        private string oldPhone;
        private string oldEmail;
        private string oldAddress;
        private int oldOkatoCode;
        private long oldCode;
        private string oldAutokey;
        private long oldId;


        public long RegionCode {
            get
            {
                return esnsiOkatoComboBox.SelectedItem !=null ?  esnsiOkatoComboBox.SelectedItem.Ter: 0;
            }
        }

        public string Phone { get { return esnsiPhoneTextBox.Text; } }

        public string Email { get { return esnsiEmailTextBox.Text; } }

        public string Address { get { return esnsiAddressTextBox.Text; } }

        public int OkatoCode
        {
            get
            {
                return esnsiOkatoComboBox.SelectedItem != null ? int.Parse(esnsiOkatoComboBox.SelectedItem.Okato) : 0;
            }
        }

        public int Code { get { return (int)esnsiCodeNumericTextBox.Value ; } }

        public string Autokey { get { return esnsiAutokeyTextBox.Text; } }

        public long Id { get { return esnsiIdNumericTextBox.Value; } }

        public EsnsiDialog(): base()
        {
            ApplyButtonVisible = false;

            InitializeComponent();
        }

        public EsnsiDialog(gaspsRow gaspsRow,  fgis_esnsiRow row) : base()
        {
            ApplyButtonVisible = false; 

            InitializeComponent();

            DataRow = row;

            esnsiOkatoComboBox.InitializeSource(Services.FileSystem.Repository.DataSet.okato);

            FormBorderStyle = FormBorderStyle.Sizable;
            
            Text = "ФГИС 'Единая система нормативно-справочной информации'";
            DialogCaption = "Сведения о прокуратуре для ФГИС ЕСНСИ";

            oldAutokey = DataRow.IsautokeyNull()? string.Empty: DataRow.autokey;
            oldRegionCode = DataRow.Isregion_idNull()? -1: DataRow.region_id;
            oldOkatoCode = DataRow.IsokatoNull()? -1: DataRow.okato;
            oldPhone = DataRow.Issv_0004Null()?string.Empty: DataRow.sv_0004;
            oldEmail = DataRow.Issv_0005Null()? string.Empty: DataRow.sv_0005;
            oldAddress = DataRow.Issv_0006Null()? string.Empty: DataRow.sv_0006;
            oldCode = DataRow.IscodeNull()?-1: DataRow.code;
            oldId = DataRow.IsidNull()? -1: DataRow.id;

            if (oldOkatoCode >= 0)
            {
                esnsiOkatoComboBox.Code = oldOkatoCode.ToString("00");
            }

            esnsiNameTextBox.Text = gaspsRow.name;
            esnsiRegionTextBox.Text = esnsiOkatoComboBox.SelectedItem !=null ? esnsiOkatoComboBox.SelectedItem.Name2: string.Empty;
            esnsiPhoneTextBox.Text = DataRow.Issv_0004Null() ? string.Empty : DataRow.sv_0004;
            esnsiEmailTextBox.Text = DataRow.Issv_0005Null() ? string.Empty : DataRow.sv_0005;
            esnsiAddressTextBox.Text = DataRow.Issv_0006Null() ? string.Empty : DataRow.sv_0006;
            esnsiCodeNumericTextBox.Text = DataRow.IscodeNull() ? string.Empty : DataRow.code.ToString();
            esnsiIdNumericTextBox.Text = DataRow.IsidNull() ? string.Empty : DataRow.id.ToString();

            OkButtonEnabled = false;
        }


        private void Controls_ValueChanged(object sender, EventArgs e)
        {
            esnsiAutokeyTextBox.Text = "FED_GENPROK_ORGANIZATION_" + esnsiIdNumericTextBox.Text;
            esnsiRegionTextBox.Text = esnsiOkatoComboBox.SelectedItem !=null ? esnsiOkatoComboBox.SelectedItem.Name2: string.Empty;

            if (
                oldAddress != Address ||
                oldAutokey != Autokey ||
                oldCode != Code ||
                oldEmail != Email ||
                oldId != Id ||
                oldOkatoCode != OkatoCode ||
                oldPhone != Phone ||
                oldRegionCode !=RegionCode
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
        private System.Windows.Forms.Label esnsiRegionLabel;
        private System.Windows.Forms.TextBox esnsiRegionTextBox;
        private System.Windows.Forms.Label esnsiPhoneLabel;
        private System.Windows.Forms.Label esnsiEmailLabel;
        private System.Windows.Forms.Label esnsiAddressLabel;
        private System.Windows.Forms.Label esnsiOkatoLabel;
        private System.Windows.Forms.Label esnsiCodeLabel;
        private System.Windows.Forms.Label eansiAutokeyLabel;
        private System.Windows.Forms.TextBox esnsiPhoneTextBox;
        private System.Windows.Forms.TextBox esnsiEmailTextBox;
        private System.Windows.Forms.TextBox esnsiAddressTextBox;
        private Controls.OkatoComboBox esnsiOkatoComboBox;
        private Controls.NumericTextBox esnsiCodeNumericTextBox;
        private System.Windows.Forms.TextBox esnsiAutokeyTextBox;
        private Label esnsiIdLabel;
        private Controls.NumericTextBox esnsiIdNumericTextBox;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label esnsiNameLabel;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EsnsiDialog));
            this.esnsiNameLabel = new System.Windows.Forms.Label();
            this.esnsiNameTextBox = new System.Windows.Forms.TextBox();
            this.esnsiRegionLabel = new System.Windows.Forms.Label();
            this.esnsiRegionTextBox = new System.Windows.Forms.TextBox();
            this.esnsiPhoneLabel = new System.Windows.Forms.Label();
            this.esnsiEmailLabel = new System.Windows.Forms.Label();
            this.esnsiAddressLabel = new System.Windows.Forms.Label();
            this.esnsiOkatoLabel = new System.Windows.Forms.Label();
            this.esnsiCodeLabel = new System.Windows.Forms.Label();
            this.eansiAutokeyLabel = new System.Windows.Forms.Label();
            this.esnsiPhoneTextBox = new System.Windows.Forms.TextBox();
            this.esnsiEmailTextBox = new System.Windows.Forms.TextBox();
            this.esnsiAddressTextBox = new System.Windows.Forms.TextBox();
            this.esnsiOkatoComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
            this.esnsiCodeNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
            this.esnsiAutokeyTextBox = new System.Windows.Forms.TextBox();
            this.esnsiIdLabel = new System.Windows.Forms.Label();
            this.esnsiIdNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(637, 506);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(5);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(475, 506);
            this.button_OK.Margin = new System.Windows.Forms.Padding(5);
            // 
            // esnsiNameLabel
            // 
            this.esnsiNameLabel.AutoSize = true;
            this.esnsiNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiNameLabel.Location = new System.Drawing.Point(12, 59);
            this.esnsiNameLabel.Name = "esnsiNameLabel";
            this.esnsiNameLabel.Size = new System.Drawing.Size(246, 20);
            this.esnsiNameLabel.TabIndex = 3;
            this.esnsiNameLabel.Text = "Наименование прокуратуры";
            // 
            // esnsiNameTextBox
            // 
            this.esnsiNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiNameTextBox.Location = new System.Drawing.Point(16, 82);
            this.esnsiNameTextBox.Name = "esnsiNameTextBox";
            this.esnsiNameTextBox.ReadOnly = true;
            this.esnsiNameTextBox.Size = new System.Drawing.Size(694, 27);
            this.esnsiNameTextBox.TabIndex = 4;
            // 
            // esnsiRegionLabel
            // 
            this.esnsiRegionLabel.AutoSize = true;
            this.esnsiRegionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiRegionLabel.Location = new System.Drawing.Point(12, 118);
            this.esnsiRegionLabel.Name = "esnsiRegionLabel";
            this.esnsiRegionLabel.Size = new System.Drawing.Size(68, 20);
            this.esnsiRegionLabel.TabIndex = 5;
            this.esnsiRegionLabel.Text = "Регион";
            // 
            // esnsiRegionTextBox
            // 
            this.esnsiRegionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiRegionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiRegionTextBox.Location = new System.Drawing.Point(86, 115);
            this.esnsiRegionTextBox.Name = "esnsiRegionTextBox";
            this.esnsiRegionTextBox.ReadOnly = true;
            this.esnsiRegionTextBox.Size = new System.Drawing.Size(624, 27);
            this.esnsiRegionTextBox.TabIndex = 6;
            // 
            // esnsiPhoneLabel
            // 
            this.esnsiPhoneLabel.AutoSize = true;
            this.esnsiPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiPhoneLabel.Location = new System.Drawing.Point(103, 151);
            this.esnsiPhoneLabel.Name = "esnsiPhoneLabel";
            this.esnsiPhoneLabel.Size = new System.Drawing.Size(270, 20);
            this.esnsiPhoneLabel.TabIndex = 7;
            this.esnsiPhoneLabel.Text = "Телефон канцелярии (SV-0004)";
            // 
            // esnsiEmailLabel
            // 
            this.esnsiEmailLabel.AutoSize = true;
            this.esnsiEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiEmailLabel.Location = new System.Drawing.Point(9, 184);
            this.esnsiEmailLabel.Name = "esnsiEmailLabel";
            this.esnsiEmailLabel.Size = new System.Drawing.Size(364, 20);
            this.esnsiEmailLabel.TabIndex = 8;
            this.esnsiEmailLabel.Text = "Электронный адрес канцелярии (SV-0005)";
            // 
            // esnsiAddressLabel
            // 
            this.esnsiAddressLabel.AutoSize = true;
            this.esnsiAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiAddressLabel.Location = new System.Drawing.Point(12, 228);
            this.esnsiAddressLabel.Name = "esnsiAddressLabel";
            this.esnsiAddressLabel.Size = new System.Drawing.Size(230, 20);
            this.esnsiAddressLabel.TabIndex = 9;
            this.esnsiAddressLabel.Text = "Адрес приемной (SV-0006)";
            // 
            // esnsiOkatoLabel
            // 
            this.esnsiOkatoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.esnsiOkatoLabel.AutoSize = true;
            this.esnsiOkatoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiOkatoLabel.Location = new System.Drawing.Point(12, 329);
            this.esnsiOkatoLabel.Name = "esnsiOkatoLabel";
            this.esnsiOkatoLabel.Size = new System.Drawing.Size(68, 20);
            this.esnsiOkatoLabel.TabIndex = 10;
            this.esnsiOkatoLabel.Text = "ОКАТО";
            // 
            // esnsiCodeLabel
            // 
            this.esnsiCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.esnsiCodeLabel.AutoSize = true;
            this.esnsiCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiCodeLabel.Location = new System.Drawing.Point(22, 366);
            this.esnsiCodeLabel.Name = "esnsiCodeLabel";
            this.esnsiCodeLabel.Size = new System.Drawing.Size(58, 20);
            this.esnsiCodeLabel.TabIndex = 11;
            this.esnsiCodeLabel.Text = "CODE";
            // 
            // eansiAutokeyLabel
            // 
            this.eansiAutokeyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eansiAutokeyLabel.AutoSize = true;
            this.eansiAutokeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eansiAutokeyLabel.Location = new System.Drawing.Point(307, 399);
            this.eansiAutokeyLabel.Name = "eansiAutokeyLabel";
            this.eansiAutokeyLabel.Size = new System.Drawing.Size(66, 20);
            this.eansiAutokeyLabel.TabIndex = 12;
            this.eansiAutokeyLabel.Text = "autokey";
            // 
            // esnsiPhoneTextBox
            // 
            this.esnsiPhoneTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiPhoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiPhoneTextBox.Location = new System.Drawing.Point(379, 148);
            this.esnsiPhoneTextBox.Name = "esnsiPhoneTextBox";
            this.esnsiPhoneTextBox.Size = new System.Drawing.Size(331, 27);
            this.esnsiPhoneTextBox.TabIndex = 13;
            this.esnsiPhoneTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // esnsiEmailTextBox
            // 
            this.esnsiEmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiEmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiEmailTextBox.Location = new System.Drawing.Point(379, 181);
            this.esnsiEmailTextBox.Name = "esnsiEmailTextBox";
            this.esnsiEmailTextBox.Size = new System.Drawing.Size(331, 27);
            this.esnsiEmailTextBox.TabIndex = 14;
            this.esnsiEmailTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // esnsiAddressTextBox
            // 
            this.esnsiAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiAddressTextBox.Location = new System.Drawing.Point(16, 251);
            this.esnsiAddressTextBox.Multiline = true;
            this.esnsiAddressTextBox.Name = "esnsiAddressTextBox";
            this.esnsiAddressTextBox.Size = new System.Drawing.Size(694, 69);
            this.esnsiAddressTextBox.TabIndex = 15;
            this.esnsiAddressTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // esnsiOkatoComboBox
            // 
            this.esnsiOkatoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiOkatoComboBox.Code = "";
            this.esnsiOkatoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.esnsiOkatoComboBox.DropDownHeight = 504;
            this.esnsiOkatoComboBox.DropDownWidth = 80;
            this.esnsiOkatoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiOkatoComboBox.FormattingEnabled = true;
            this.esnsiOkatoComboBox.IntegralHeight = false;
            this.esnsiOkatoComboBox.ItemHeight = 25;
            this.esnsiOkatoComboBox.Location = new System.Drawing.Point(86, 326);
            this.esnsiOkatoComboBox.MaxDropDownItems = 20;
            this.esnsiOkatoComboBox.Name = "esnsiOkatoComboBox";
            this.esnsiOkatoComboBox.SelectedItem = null;
            this.esnsiOkatoComboBox.Size = new System.Drawing.Size(624, 31);
            this.esnsiOkatoComboBox.TabIndex = 16;
            this.esnsiOkatoComboBox.SelectedIndexChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // esnsiCodeNumericTextBox
            // 
            this.esnsiCodeNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.esnsiCodeNumericTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiCodeNumericTextBox.Location = new System.Drawing.Point(86, 363);
            this.esnsiCodeNumericTextBox.Name = "esnsiCodeNumericTextBox";
            this.esnsiCodeNumericTextBox.Size = new System.Drawing.Size(304, 27);
            this.esnsiCodeNumericTextBox.TabIndex = 17;
            this.esnsiCodeNumericTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // esnsiAutokeyTextBox
            // 
            this.esnsiAutokeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.esnsiAutokeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiAutokeyTextBox.Location = new System.Drawing.Point(379, 396);
            this.esnsiAutokeyTextBox.Name = "esnsiAutokeyTextBox";
            this.esnsiAutokeyTextBox.ReadOnly = true;
            this.esnsiAutokeyTextBox.Size = new System.Drawing.Size(331, 27);
            this.esnsiAutokeyTextBox.TabIndex = 18;
            // 
            // esnsiIdLabel
            // 
            this.esnsiIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.esnsiIdLabel.AutoSize = true;
            this.esnsiIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiIdLabel.Location = new System.Drawing.Point(54, 399);
            this.esnsiIdLabel.Name = "esnsiIdLabel";
            this.esnsiIdLabel.Size = new System.Drawing.Size(26, 20);
            this.esnsiIdLabel.TabIndex = 19;
            this.esnsiIdLabel.Text = "ID";
            // 
            // esnsiIdNumericTextBox
            // 
            this.esnsiIdNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.esnsiIdNumericTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esnsiIdNumericTextBox.Location = new System.Drawing.Point(86, 396);
            this.esnsiIdNumericTextBox.Name = "esnsiIdNumericTextBox";
            this.esnsiIdNumericTextBox.Size = new System.Drawing.Size(192, 27);
            this.esnsiIdNumericTextBox.TabIndex = 20;
            this.esnsiIdNumericTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
            // 
            // EsnsiDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(722, 533);
            this.Controls.Add(this.esnsiIdNumericTextBox);
            this.Controls.Add(this.esnsiIdLabel);
            this.Controls.Add(this.esnsiAutokeyTextBox);
            this.Controls.Add(this.esnsiCodeNumericTextBox);
            this.Controls.Add(this.esnsiOkatoComboBox);
            this.Controls.Add(this.esnsiAddressTextBox);
            this.Controls.Add(this.esnsiEmailTextBox);
            this.Controls.Add(this.esnsiPhoneTextBox);
            this.Controls.Add(this.eansiAutokeyLabel);
            this.Controls.Add(this.esnsiCodeLabel);
            this.Controls.Add(this.esnsiOkatoLabel);
            this.Controls.Add(this.esnsiAddressLabel);
            this.Controls.Add(this.esnsiEmailLabel);
            this.Controls.Add(this.esnsiPhoneLabel);
            this.Controls.Add(this.esnsiRegionTextBox);
            this.Controls.Add(this.esnsiRegionLabel);
            this.Controls.Add(this.esnsiNameTextBox);
            this.Controls.Add(this.esnsiNameLabel);
            this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.epgu;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(740, 580);
            this.Name = "EsnsiDialog";
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.esnsiNameLabel, 0);
            this.Controls.SetChildIndex(this.esnsiNameTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiRegionLabel, 0);
            this.Controls.SetChildIndex(this.esnsiRegionTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiPhoneLabel, 0);
            this.Controls.SetChildIndex(this.esnsiEmailLabel, 0);
            this.Controls.SetChildIndex(this.esnsiAddressLabel, 0);
            this.Controls.SetChildIndex(this.esnsiOkatoLabel, 0);
            this.Controls.SetChildIndex(this.esnsiCodeLabel, 0);
            this.Controls.SetChildIndex(this.eansiAutokeyLabel, 0);
            this.Controls.SetChildIndex(this.esnsiPhoneTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiEmailTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiAddressTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiOkatoComboBox, 0);
            this.Controls.SetChildIndex(this.esnsiCodeNumericTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiAutokeyTextBox, 0);
            this.Controls.SetChildIndex(this.esnsiIdLabel, 0);
            this.Controls.SetChildIndex(this.esnsiIdNumericTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
                
    }
}
