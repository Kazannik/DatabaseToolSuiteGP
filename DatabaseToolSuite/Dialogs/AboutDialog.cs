using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
    class AboutDialog : DialogBase
    {
        public AboutDialog() : base()
        {
            InitializeComponent();

            Text = string.Format("О программе {0}", AssemblyTitle);
            label_ProductName.Text = AssemblyProduct;
            label_Version.Text = string.Format("Версия {0}", AssemblyVersion);
            label_Copyright.Text = AssemblyCopyright;
            textBox_CompanyName.Text = AssemblyCompany;
            textBox_Description.Text = AssemblyDescription;
            DialogCaption = "Редактор НСИ ГАС ПС";
            DialogCaptionImage = Properties.Resources.Windows32;
            ApplyButtonVisible = false;
            CancelButtonVisible = false;
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_CompanyName = new System.Windows.Forms.TextBox();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.label_ProductName = new System.Windows.Forms.Label();
            this.label_Version = new System.Windows.Forms.Label();
            this.label_Copyright = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(495, 359);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(333, 359);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.textBox_CompanyName, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.pictureBox_Logo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label_ProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label_Version, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label_Copyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.textBox_Description, 0, 4);
            this.tableLayoutPanel.Location = new System.Drawing.Point(11, 54);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(556, 272);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // textBox_CompanyName
            // 
            this.textBox_CompanyName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_CompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_CompanyName.Location = new System.Drawing.Point(191, 94);
            this.textBox_CompanyName.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.textBox_CompanyName.Multiline = true;
            this.textBox_CompanyName.Name = "textBox_CompanyName";
            this.textBox_CompanyName.ReadOnly = true;
            this.textBox_CompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_CompanyName.Size = new System.Drawing.Size(361, 82);
            this.textBox_CompanyName.TabIndex = 25;
            this.textBox_CompanyName.TabStop = false;
            this.textBox_CompanyName.Text = "Наименование компании";
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Logo.Image = global::DatabaseToolSuite.Properties.Resources.emblem_big;
            this.pictureBox_Logo.Location = new System.Drawing.Point(4, 4);
            this.pictureBox_Logo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.tableLayoutPanel.SetRowSpan(this.pictureBox_Logo, 4);
            this.pictureBox_Logo.Size = new System.Drawing.Size(175, 172);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Logo.TabIndex = 12;
            this.pictureBox_Logo.TabStop = false;
            // 
            // label_ProductName
            // 
            this.label_ProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProductName.Location = new System.Drawing.Point(191, 0);
            this.label_ProductName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.label_ProductName.MaximumSize = new System.Drawing.Size(0, 21);
            this.label_ProductName.Name = "label_ProductName";
            this.label_ProductName.Size = new System.Drawing.Size(361, 21);
            this.label_ProductName.TabIndex = 19;
            this.label_ProductName.Text = "Название продукта";
            this.label_ProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Version
            // 
            this.label_Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Version.Location = new System.Drawing.Point(191, 30);
            this.label_Version.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.label_Version.MaximumSize = new System.Drawing.Size(0, 21);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(361, 21);
            this.label_Version.TabIndex = 0;
            this.label_Version.Text = "Версия";
            this.label_Version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Copyright
            // 
            this.label_Copyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Copyright.Location = new System.Drawing.Point(191, 60);
            this.label_Copyright.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.label_Copyright.MaximumSize = new System.Drawing.Size(0, 21);
            this.label_Copyright.Name = "label_Copyright";
            this.label_Copyright.Size = new System.Drawing.Size(361, 21);
            this.label_Copyright.TabIndex = 21;
            this.label_Copyright.Text = "Авторские права";
            this.label_Copyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Description
            // 
            this.tableLayoutPanel.SetColumnSpan(this.textBox_Description, 2);
            this.textBox_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Description.Location = new System.Drawing.Point(8, 184);
            this.textBox_Description.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.ReadOnly = true;
            this.textBox_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Description.Size = new System.Drawing.Size(544, 84);
            this.textBox_Description.TabIndex = 23;
            this.textBox_Description.TabStop = false;
            this.textBox_Description.Text = "Описание";
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.AcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(580, 386);
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(598, 433);
            this.MinimumSize = new System.Drawing.Size(598, 433);
            this.Name = "AboutDialog";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ShowIcon = false;
            this.Text = "DialogAbout";
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PictureBox pictureBox_Logo;
        private Label label_ProductName;
        private Label label_Version;
        private Label label_Copyright;
        private TextBox textBox_Description;
        private TextBox textBox_CompanyName;
    }
}
