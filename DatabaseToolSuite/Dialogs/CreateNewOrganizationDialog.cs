using System;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    public class CreateNewOrganizationDialog : CreateNewVersionDialog
    {
        private bool generationCodeService = true;

        public CreateNewOrganizationDialog() : base()
        {
            InitializeComponent();

            nextCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
                !string.IsNullOrWhiteSpace(okatoComboBox.Code);

            selectCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
                !string.IsNullOrWhiteSpace(okatoComboBox.Code);

            Text = "Новая запись о подразделении";
            DialogCaption = "Создание новой записи о подразделении";
            codeTextBox.Text = string.Empty;

        }


        public CreateNewOrganizationDialog(string name, string code, DateTime beginDate) : base()
        {
            generationCodeService = false;

            InitializeComponent();


            nextCodeButton.Enabled = false;
            selectCodeButton.Enabled = false;

            nameTextBox.Text = name;
            nameTextBox.Enabled = false;
            codeTextBox.Text = code;
            codeTextBox.Enabled = false;
            beginDateTimePicker.Value = beginDate;
            beginDateTimePicker.Enabled = false;

            Text = "Новая запись о подразделении";
            DialogCaption = "Создание новой записи о подразделении";

        }

        public CreateNewOrganizationDialog(gaspsRow row) : base(row)
        {
            InitializeComponent();


            nextCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
                !string.IsNullOrWhiteSpace(okatoComboBox.Code);

            selectCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
                !string.IsNullOrWhiteSpace(okatoComboBox.Code);

            Text = "Новая запись о подразделении";
            DialogCaption = "Создание новой записи о подразделении";
            codeTextBox.Text = string.Empty;

        }

        public string Code
        {
            get { return codeTextBox.Text; }
        }

        private void nextCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                codeTextBox.Text = Services.FileSystem.Repository.DataSet.gasps.GetNextCode(authority: Authority.HasValue ? Authority.Value : 0, okato: OkatoCode);
            }
            catch (Exception)
            {
                codeTextBox.Text = Services.FileSystem.Repository.DataSet.gasps.GetNextSkippedCode(authority: Authority.HasValue ? Authority.Value : 0, okato: OkatoCode);
                MessageBox.Show(this, "Диапазон кодов исчерпан. Выбран код из числа пропущенных номеров.", "Создание новой записи о подразделении",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void selectCodeButton_Click(object sender, EventArgs e)
        {
            SelectOrganizationDialog dialog = new SelectOrganizationDialog(authority: Authority.HasValue ? Authority.Value : 0, okato: OkatoCode);
            dialog.LastLockOnlyShow = true;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                codeTextBox.Text = dialog.DataRow.code;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
                string.IsNullOrWhiteSpace(okatoComboBox.Code))
            {
                nextCodeButton.Enabled = false;
                selectCodeButton.Enabled = false;
            }
            else
            {
                if (generationCodeService)
                {
                    codeTextBox.Text = Services.FileSystem.Repository.DataSet.gasps.GetNextCode(authority: Authority.HasValue ? Authority.Value : 0, okato: OkatoCode);
                    nextCodeButton.Enabled = true;
                    selectCodeButton.Enabled = true;
                }
            }
        }


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nextCodeButton = new System.Windows.Forms.Button();
            this.selectCodeButton = new System.Windows.Forms.Button();
            this.organizationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // organizationGroupBox
            // 
            this.organizationGroupBox.Controls.Add(this.selectCodeButton);
            this.organizationGroupBox.Controls.Add(this.nextCodeButton);
            this.organizationGroupBox.Size = new System.Drawing.Size(690, 357);
            this.organizationGroupBox.Controls.SetChildIndex(this.nameTextBox, 0);
            this.organizationGroupBox.Controls.SetChildIndex(this.authorityComboBox, 0);
            this.organizationGroupBox.Controls.SetChildIndex(this.okatoComboBox, 0);
            this.organizationGroupBox.Controls.SetChildIndex(this.codeTextBox, 0);
            this.organizationGroupBox.Controls.SetChildIndex(this.nextCodeButton, 0);
            this.organizationGroupBox.Controls.SetChildIndex(this.selectCodeButton, 0);
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(204, 102);
            // 
            // authorityComboBox
            // 
            this.authorityComboBox.Location = new System.Drawing.Point(129, 180);
            this.authorityComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // okatoComboBox
            // 
            this.okatoComboBox.Location = new System.Drawing.Point(129, 140);
            this.okatoComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Size = new System.Drawing.Size(669, 37);
            // 
            // nextCodeButton
            // 
            this.nextCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextCodeButton.Location = new System.Drawing.Point(345, 99);
            this.nextCodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.nextCodeButton.Name = "nextCodeButton";
            this.nextCodeButton.Size = new System.Drawing.Size(113, 34);
            this.nextCodeButton.TabIndex = 3;
            this.nextCodeButton.Text = "Создать";
            this.nextCodeButton.UseVisualStyleBackColor = true;
            this.nextCodeButton.Click += new System.EventHandler(this.nextCodeButton_Click);
            // 
            // selectCodeButton
            // 
            this.selectCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectCodeButton.Location = new System.Drawing.Point(466, 99);
            this.selectCodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectCodeButton.Name = "selectCodeButton";
            this.selectCodeButton.Size = new System.Drawing.Size(113, 34);
            this.selectCodeButton.TabIndex = 4;
            this.selectCodeButton.Text = "Выбрать...";
            this.selectCodeButton.UseVisualStyleBackColor = true;
            this.selectCodeButton.Click += new System.EventHandler(this.selectCodeButton_Click);
            // 
            // CreateNewOrganizationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.MinimumSize = new System.Drawing.Size(740, 580);
            this.Name = "CreateNewOrganizationDialog";
            this.organizationGroupBox.ResumeLayout(false);
            this.organizationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectCodeButton;
        private System.Windows.Forms.Button nextCodeButton;


    }
}
