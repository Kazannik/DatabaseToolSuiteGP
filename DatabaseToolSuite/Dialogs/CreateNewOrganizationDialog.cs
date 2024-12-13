using System;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	internal class CreateNewOrganizationDialog : CreateNewVersionDialog
	{
		private readonly bool generationCodeService;

		public CreateNewOrganizationDialog() : base()
		{
			generationCodeService = true;

			InitializeComponent();

			nextCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
				!string.IsNullOrWhiteSpace(okatoComboBox.Code);

			selectCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
				!string.IsNullOrWhiteSpace(okatoComboBox.Code);

			Text = "Новая запись о подразделении";
			DialogCaption = "Создание новой записи о подразделении";
			codeTextBox.Text = string.Empty;
		}

		public CreateNewOrganizationDialog(string name, string code, DateTime beginDate) : this()
		{
			generationCodeService = false;
			nextCodeButton.Enabled = false;
			selectCodeButton.Enabled = false;

			nameTextBox.Text = name;
			nameTextBox.Enabled = false;
			codeTextBox.Text = code;
			codeTextBox.Enabled = false;
			beginDateTimePicker.Value = new DateTime(year: beginDate.Year, month: beginDate.Month, day: beginDate.Day);
			beginDateTimePicker.Enabled = false;
		}

		public CreateNewOrganizationDialog(Repositoryes.MainDataSet.gaspsRow row) : base(row)
		{
			generationCodeService = true;

			InitializeComponent();

			nextCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
				!string.IsNullOrWhiteSpace(okatoComboBox.Code);

			selectCodeButton.Enabled = !string.IsNullOrWhiteSpace(authorityComboBox.Code) ||
				!string.IsNullOrWhiteSpace(okatoComboBox.Code);

			cleanCodeButton.Enabled = authorityComboBox.Value.HasValue && authorityComboBox.Value == Services.MasterDataSystem.PROSECUTOR_CODE;

			Text = "Новая запись о подразделении";
			DialogCaption = "Создание новой записи о подразделении";
			codeTextBox.Text = string.Empty;
		}

		public string Code
		{
			get { return codeTextBox.Text; }
		}

		private void NextCodeButton_Click(object sender, EventArgs e)
		{
			try
			{
				codeTextBox.Text = Services.FileSystem.Repository.MainDataSet.gasps.GetNextCode(authority: Authority ?? 0, okato: OkatoCode);
			}
			catch (Exception)
			{
				codeTextBox.Text = Services.FileSystem.Repository.MainDataSet.gasps.GetNextSkippedCode(authority: Authority ?? 0, okato: OkatoCode);
				MessageBox.Show(this, "Диапазон кодов исчерпан. Выбран код из числа пропущенных номеров.", "Создание новой записи о подразделении", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void SelectCodeButton_Click(object sender, EventArgs e)
		{
			SelectOrganizationDialog dialog = new SelectOrganizationDialog(authority: Authority ?? 0, okato: OkatoCode);
			dialog.LastLockOnlyShow = true;
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				codeTextBox.Text = dialog.DataRow.code;
			}
		}

		private void CleanCodeButton_Click(object sender, EventArgs e)
		{
			codeTextBox.Text = string.Empty;
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
					codeTextBox.Text = Services.FileSystem.Repository.MainDataSet.gasps.GetNextCode(authority: Authority ?? 0, okato: OkatoCode);
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
			this.cleanCodeButton = new System.Windows.Forms.Button();
			this.organizationGroupBox.SuspendLayout();
			this.SuspendLayout();
			//
			// organizationGroupBox
			//
			this.organizationGroupBox.Controls.Add(this.cleanCodeButton);
			this.organizationGroupBox.Controls.Add(this.selectCodeButton);
			this.organizationGroupBox.Controls.Add(this.nextCodeButton);
			this.organizationGroupBox.Controls.SetChildIndex(this.ownerTextBox, 0);
			this.organizationGroupBox.Controls.SetChildIndex(this.nameTextBox, 0);
			this.organizationGroupBox.Controls.SetChildIndex(this.authorityComboBox, 0);
			this.organizationGroupBox.Controls.SetChildIndex(this.okatoComboBox, 0);
			this.organizationGroupBox.Controls.SetChildIndex(this.codeTextBox, 0);
			this.organizationGroupBox.Controls.SetChildIndex(this.nextCodeButton, 0);
			this.organizationGroupBox.Controls.SetChildIndex(this.selectCodeButton, 0);
			this.organizationGroupBox.Controls.SetChildIndex(this.cleanCodeButton, 0);
			//
			// codeTextBox
			//
			this.codeTextBox.Size = new System.Drawing.Size(126, 22);
			//
			// authorityComboBox
			//
			this.authorityComboBox.DropDownHeight = 424;
			this.authorityComboBox.ItemHeight = 21;
			this.authorityComboBox.Size = new System.Drawing.Size(624, 27);
			this.authorityComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
			//
			// okatoComboBox
			//
			this.okatoComboBox.DropDownHeight = 424;
			this.okatoComboBox.ItemHeight = 21;
			this.okatoComboBox.Size = new System.Drawing.Size(624, 27);
			this.okatoComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
			//
			// button_Cancel
			//
			this.button_Cancel.Location = new System.Drawing.Point(708, 573);
			//
			// button_OK
			//
			this.button_OK.Location = new System.Drawing.Point(508, 573);
			//
			// nextCodeButton
			//
			this.nextCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nextCodeButton.Location = new System.Drawing.Point(362, 172);
			this.nextCodeButton.Margin = new System.Windows.Forms.Padding(4);
			this.nextCodeButton.Name = "nextCodeButton";
			this.nextCodeButton.Size = new System.Drawing.Size(127, 28);
			this.nextCodeButton.TabIndex = 3;
			this.nextCodeButton.Text = "Создать";
			this.nextCodeButton.UseVisualStyleBackColor = true;
			this.nextCodeButton.Click += new System.EventHandler(this.NextCodeButton_Click);
			//
			// selectCodeButton
			//
			this.selectCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.selectCodeButton.Location = new System.Drawing.Point(497, 172);
			this.selectCodeButton.Margin = new System.Windows.Forms.Padding(4);
			this.selectCodeButton.Name = "selectCodeButton";
			this.selectCodeButton.Size = new System.Drawing.Size(127, 28);
			this.selectCodeButton.TabIndex = 4;
			this.selectCodeButton.Text = "Выбрать...";
			this.selectCodeButton.UseVisualStyleBackColor = true;
			this.selectCodeButton.Click += new System.EventHandler(this.SelectCodeButton_Click);
			//
			// cleanCodeButton
			//
			this.cleanCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cleanCodeButton.Location = new System.Drawing.Point(632, 172);
			this.cleanCodeButton.Margin = new System.Windows.Forms.Padding(4);
			this.cleanCodeButton.Name = "cleanCodeButton";
			this.cleanCodeButton.Size = new System.Drawing.Size(127, 28);
			this.cleanCodeButton.TabIndex = 46;
			this.cleanCodeButton.Text = "Очистить";
			this.cleanCodeButton.UseVisualStyleBackColor = true;
			this.cleanCodeButton.Click += new System.EventHandler(this.CleanCodeButton_Click);
			//
			// CreateNewOrganizationDialog
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.ClientSize = new System.Drawing.Size(814, 608);
			this.Name = "CreateNewOrganizationDialog";
			this.organizationGroupBox.ResumeLayout(false);
			this.organizationGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion Код, автоматически созданный конструктором форм Windows

		private System.Windows.Forms.Button selectCodeButton;
		private Button cleanCodeButton;
		private System.Windows.Forms.Button nextCodeButton;
	}
}