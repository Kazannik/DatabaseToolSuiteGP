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

			OtherControls.Add(this.nextCodeButton);
			OtherControls.Add(this.selectCodeButton);
			OtherControls.Add(this.cleanCodeButton);

			nextCodeButton.Enabled = !string.IsNullOrWhiteSpace(AuthorityCode) ||
				!string.IsNullOrWhiteSpace(OkatoCode);

			selectCodeButton.Enabled = !string.IsNullOrWhiteSpace(AuthorityCode) ||
				!string.IsNullOrWhiteSpace(OkatoCode);

			Text = "Новая запись о подразделении";
			DialogCaption = "Создание новой записи о подразделении";
			CodeText = string.Empty;
		}

		public CreateNewOrganizationDialog(string name, string code, DateTime beginDate) : this()
		{
			generationCodeService = false;
			nextCodeButton.Enabled = false;
			selectCodeButton.Enabled = false;

			NameText = name;
			NameTextEnabled = false;
			CodeText = code;
			CodeTextEnabled = false;
			BeginDateTimeValue = new DateTime(year: beginDate.Year, month: beginDate.Month, day: beginDate.Day);
			BeginDateTimeEnabled = false;
		}

		public CreateNewOrganizationDialog(Repositories.MainDataSet.gaspsRow row) : base(row)
		{
			generationCodeService = true;

			InitializeComponent();

			OtherControls.Add(this.nextCodeButton);
			OtherControls.Add(this.selectCodeButton);
			OtherControls.Add(this.selectSkippedCodeButton);
			OtherControls.Add(this.cleanCodeButton);

			nextCodeButton.Enabled = !string.IsNullOrWhiteSpace(AuthorityCode) ||
				!string.IsNullOrWhiteSpace(OkatoCode);

			selectCodeButton.Enabled = !string.IsNullOrWhiteSpace(AuthorityCode) ||
				!string.IsNullOrWhiteSpace(OkatoCode);

			selectSkippedCodeButton.Enabled = !string.IsNullOrWhiteSpace(AuthorityCode) ||
				!string.IsNullOrWhiteSpace(OkatoCode);

			cleanCodeButton.Enabled = AuthorityValue.HasValue && AuthorityValue == Services.MasterDataSystem.PROSECUTOR_CODE;

			Text = "Новая запись о подразделении";
			DialogCaption = "Создание новой записи о подразделении";
			CodeText = string.Empty;
		}

		public string Code
		{
			get { return CodeText; }
		}

		private void NextCodeButton_Click(object sender, EventArgs e)
		{
			try
			{
				CodeText = Services.FileSystem.Repository.MainDataSet.gasps.GetNextCode(authority: Authority ?? 0, okato: OkatoCode);
			}
			catch (Exception)
			{
				CodeText = Services.FileSystem.Repository.MainDataSet.gasps.GetNextSkippedCode(authority: Authority ?? 0, okato: OkatoCode);
				MessageBox.Show(this, "Диапазон кодов исчерпан. Выбран код из числа пропущенных номеров.", "Создание новой записи о подразделении", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void SelectCodeButton_Click(object sender, EventArgs e)
		{
			SelectOrganizationDialog dialog = new SelectOrganizationDialog(authority: Authority ?? 0, okato: OkatoCode)
			{
				LastLockOnlyShow = true
			};
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				CodeText = dialog.DataRow.code;
			}
		}

		private void SelectSkippedCodeButton_Click(object sender, EventArgs e)
		{
			SelectSkippedCodeDialog dialog = new SelectSkippedCodeDialog(authority: Authority ?? 0, okato: OkatoCode);
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				CodeText = dialog.Code;
			}
		}

		private void CleanCodeButton_Click(object sender, EventArgs e)
		{
			CodeText = string.Empty;
		}

		protected override void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(AuthorityCode) ||
				string.IsNullOrWhiteSpace(OkatoCode))
			{
				if (nextCodeButton != null) nextCodeButton.Enabled = false;
				if (selectCodeButton != null) selectCodeButton.Enabled = false;
			}
			else
			{
				if (generationCodeService)
				{
					try
					{
						CodeText = Services.FileSystem.Repository.MainDataSet.gasps.GetNextCode(authority: Authority ?? 0, okato: OkatoCode);
						nextCodeButton.Enabled = true;
						selectCodeButton.Enabled = true;
					}
					catch (Exception)
					{
						CodeText = Services.FileSystem.Repository.MainDataSet.gasps.GetNextSkippedCode(authority: Authority ?? 0, okato: OkatoCode);
						MessageBox.Show(this, "Диапазон кодов исчерпан. Выбран код из числа пропущенных номеров.", "Создание новой записи о подразделении", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
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
			this.selectSkippedCodeButton = new System.Windows.Forms.Button();
			this.cleanCodeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// nextCodeButton
			// 
			this.nextCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nextCodeButton.Location = new System.Drawing.Point(390, 172);
			this.nextCodeButton.Margin = new System.Windows.Forms.Padding(9);
			this.nextCodeButton.Name = "nextCodeButton";
			this.nextCodeButton.Size = new System.Drawing.Size(90, 28);
			this.nextCodeButton.TabIndex = 3;
			this.nextCodeButton.Text = "Создать";
			this.nextCodeButton.UseVisualStyleBackColor = true;
			this.nextCodeButton.Click += new System.EventHandler(this.NextCodeButton_Click);
			// 
			// selectCodeButton
			// 
			this.selectCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.selectCodeButton.Location = new System.Drawing.Point(490, 172);
			this.selectCodeButton.Margin = new System.Windows.Forms.Padding(9);
			this.selectCodeButton.Name = "selectCodeButton";
			this.selectCodeButton.Size = new System.Drawing.Size(90, 28);
			this.selectCodeButton.TabIndex = 4;
			this.selectCodeButton.Text = "Выбрать...";
			this.selectCodeButton.UseVisualStyleBackColor = true;
			this.selectCodeButton.Click += new System.EventHandler(this.SelectCodeButton_Click);
			// 
			// selectSkippedCodeButton
			// 
			this.selectSkippedCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.selectSkippedCodeButton.Location = new System.Drawing.Point(590, 172);
			this.selectSkippedCodeButton.Margin = new System.Windows.Forms.Padding(9);
			this.selectSkippedCodeButton.Name = "selectSkippedCodeButton";
			this.selectSkippedCodeButton.Size = new System.Drawing.Size(90, 28);
			this.selectSkippedCodeButton.TabIndex = 5;
			this.selectSkippedCodeButton.Text = "Иные...";
			this.selectSkippedCodeButton.UseVisualStyleBackColor = true;
			this.selectSkippedCodeButton.Click += new System.EventHandler(this.SelectSkippedCodeButton_Click);

			// 
			// cleanCodeButton
			// 
			this.cleanCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cleanCodeButton.Location = new System.Drawing.Point(690, 172);
			this.cleanCodeButton.Margin = new System.Windows.Forms.Padding(9);
			this.cleanCodeButton.Name = "cleanCodeButton";
			this.cleanCodeButton.Size = new System.Drawing.Size(90, 28);
			this.cleanCodeButton.TabIndex = 6;
			this.cleanCodeButton.Text = "Очистить";
			this.cleanCodeButton.UseVisualStyleBackColor = true;
			this.cleanCodeButton.Click += new System.EventHandler(this.CleanCodeButton_Click);
			// 
			// CreateNewOrganizationDialog
			// 
			this.Name = "CreateNewOrganizationDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion Код, автоматически созданный конструктором форм Windows

		private Button nextCodeButton;
		private Button selectCodeButton;
		private Button selectSkippedCodeButton;
		private Button cleanCodeButton;
	}
}