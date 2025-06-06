﻿// Ignore Spelling: Okato

using System;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	internal class CreateNewVersionDialog : DialogBase
	{
		private readonly string oldCode;
		private readonly string oldName;
		private readonly string oldOkato;
		private readonly long oldAuthorityId;
		private Button nameWizardButton;
		private readonly long oldOwnerKey;

		public CreateNewVersionDialog() : base()
		{
			ApplyButtonVisible = false;

			InitializeComponent();

			FormBorderStyle = FormBorderStyle.Sizable;

			okatoComboBox.InitializeSource(Services.FileSystem.Repository.MainDataSet.okato);
			authorityComboBox.InitializeSource(Services.FileSystem.Repository.MainDataSet.authority);

			beginDateTimePicker.MinDate = Services.MasterDataSystem.MIN_DATE;
			beginDateTimePicker.MaxDate = Services.MasterDataSystem.MAX_DATE;

			Text = "Новая версия записи о подразделении правоохранительного органа";
			DialogCaption = "Создание новой версии записи о подразделении";

			OkButtonEnabled = false;
		}

		public CreateNewVersionDialog(Repositories.MainDataSet.gaspsRow row) : this()
		{
			ApplyButtonVisible = false;

			DataRow = row;

			oldCode = DataRow.code;
			oldName = DataRow.name;
			oldOkato = DataRow.okato_code;
			oldAuthorityId = DataRow.authority_id;
			oldOwnerKey = DataRow.owner_id;

			CourtType = DataRow.court_type_id;

			beginDateTimePicker.Value = DateTime.Today;
			authorityComboBox.Code = DataRow.authority_id.ToString("00");
			codeTextBox.Text = DataRow.code;
			nameTextBox.Text = DataRow.name;
			okatoComboBox.Code = DataRow.okato_code;
			OrganizationOwner = DataRow.owner_id;

			if (DataRow.owner_id > 0)
			{
				Repositories.MainDataSet.gaspsRow owner = Services.FileSystem.Repository.MainDataSet.gasps.GetLastVersionOrganizationFromKey(DataRow.owner_id);

				ownerTextBox.Text = owner.name + " (код: " + owner.code + ")";
			}
			else
				ownerTextBox.Text = string.Empty;
		}

		public Repositories.MainDataSet.gaspsRow DataRow { get; private set; }

		public DateTime BeginDate
		{
			get { return beginDateTimePicker.Value.Date; }
		}

		public string OrganizationName
		{
			get { return nameTextBox.Text.Replace("\r\n", string.Empty).Replace("\r", string.Empty).Trim(); }
		}

		public string OkatoCode
		{
			get { return okatoComboBox.Code; }
		}

		public long? Authority
		{
			get { return authorityComboBox.Value; }
		}

		public long OrganizationOwner { get; private set; }

		public long CourtType { get; }

		private void SelectOwnerButton_Click(object sender, EventArgs e)
		{
			SelectOrganizationDialog dialog;
			if (!string.IsNullOrWhiteSpace(okatoComboBox.Code) &&
				authorityComboBox.Value.HasValue)
			{
				dialog = new SelectOrganizationDialog(authorityComboBox.Value.Value, okatoComboBox.Code);
			}
			else
			{
				dialog = new SelectOrganizationDialog();
			}

			dialog.LastLockOnlyShow = false;
			dialog.LockShow = false;
			dialog.ReserveShow = false;
			dialog.UnlockShow = true;

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				OrganizationOwner = dialog.DataRow.key;
				ownerTextBox.Text = dialog.DataRow.name + " (код: " + dialog.DataRow.code + ")";
			}
		}

		private void DeleteOwnerButton_Click(object sender, EventArgs e)
		{
			OrganizationOwner = 0;
			ownerTextBox.Text = string.Empty;
		}

		private void Controls_ValueChanged(object sender, EventArgs e)
		{
			if (
				oldAuthorityId != Authority ||
				CourtType != CourtType ||
				oldName != OrganizationName ||
				oldOkato != OkatoCode ||
				oldOwnerKey != OrganizationOwner ||
				oldCode != CodeText
				)
			{
				OkButtonEnabled = true;
			}
			else
			{
				OkButtonEnabled = false;
			}
			if ((string.IsNullOrWhiteSpace(codeTextBox.Text) && AuthorityCode != "20") ||
				string.IsNullOrWhiteSpace(OrganizationName) ||
				!Authority.HasValue ||
				string.IsNullOrWhiteSpace(OkatoCode))
				OkButtonEnabled = false;

			deleteOwnerButton.Enabled = OrganizationOwner != 0;
		}

		protected virtual void ComboBox_SelectedIndexChanged(object sender, EventArgs e) { }

		protected string CodeText
		{
			get => codeTextBox.Text;
			set => codeTextBox.Text = value;
		}

		protected bool CodeTextEnabled
		{
			get => codeTextBox.Enabled;
			set => codeTextBox.Enabled = value;
		}

		protected string NameText
		{
			get => nameTextBox.Text;
			set => nameTextBox.Text = value;
		}

		protected bool NameTextEnabled
		{
			get => nameTextBox.Enabled;
			set => nameTextBox.Enabled = value;
		}

		protected string BeginDateLabelText
		{
			get => beginDateLabel.Text;
			set => beginDateLabel.Text = value;
		}

		protected DateTime BeginDateTimeValue
		{
			get => beginDateTimePicker.Value;
			set => beginDateTimePicker.Value = value;
		}

		protected bool BeginDateTimeEnabled
		{
			get => beginDateTimePicker.Enabled;
			set => beginDateTimePicker.Enabled = value;
		}

		protected string AuthorityCode => authorityComboBox.Code;

		protected long? AuthorityValue => authorityComboBox.Value;

		protected Control.ControlCollection OtherControls => organizationGroupBox.Controls;

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewVersionDialog));
			this.beginDateLabel = new System.Windows.Forms.Label();
			this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.nameLabel = new System.Windows.Forms.Label();
			this.organizationGroupBox = new System.Windows.Forms.GroupBox();
			this.deleteOwnerButton = new System.Windows.Forms.Button();
			this.selectOwnerButton = new System.Windows.Forms.Button();
			this.ownerTextBox = new System.Windows.Forms.TextBox();
			this.ownerLabel = new System.Windows.Forms.Label();
			this.okatoLabel = new System.Windows.Forms.Label();
			this.authorityLabel = new System.Windows.Forms.Label();
			this.okatoComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
			this.authorityComboBox = new DatabaseToolSuite.Controls.AuthorityComboBox();
			this.codeTextBox = new System.Windows.Forms.TextBox();
			this.codeLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameWizardButton = new System.Windows.Forms.Button();
			this.organizationGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// beginDateLabel
			// 
			this.beginDateLabel.AutoSize = true;
			this.beginDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateLabel.Location = new System.Drawing.Point(23, 64);
			this.beginDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.beginDateLabel.Name = "beginDateLabel";
			this.beginDateLabel.Size = new System.Drawing.Size(287, 25);
			this.beginDateLabel.TabIndex = 36;
			this.beginDateLabel.Text = "Дата введения новой версии:";
			// 
			// beginDateTimePicker
			// 
			this.beginDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateTimePicker.Location = new System.Drawing.Point(27, 88);
			this.beginDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
			this.beginDateTimePicker.Name = "beginDateTimePicker";
			this.beginDateTimePicker.Size = new System.Drawing.Size(214, 30);
			this.beginDateTimePicker.TabIndex = 0;
			this.beginDateTimePicker.ValueChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nameLabel.Location = new System.Drawing.Point(9, 24);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(167, 25);
			this.nameLabel.TabIndex = 37;
			this.nameLabel.Text = "Наименование:";
			// 
			// organizationGroupBox
			// 
			this.organizationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.organizationGroupBox.Controls.Add(this.deleteOwnerButton);
			this.organizationGroupBox.Controls.Add(this.selectOwnerButton);
			this.organizationGroupBox.Controls.Add(this.ownerTextBox);
			this.organizationGroupBox.Controls.Add(this.ownerLabel);
			this.organizationGroupBox.Controls.Add(this.okatoLabel);
			this.organizationGroupBox.Controls.Add(this.authorityLabel);
			this.organizationGroupBox.Controls.Add(this.okatoComboBox);
			this.organizationGroupBox.Controls.Add(this.authorityComboBox);
			this.organizationGroupBox.Controls.Add(this.codeTextBox);
			this.organizationGroupBox.Controls.Add(this.codeLabel);
			this.organizationGroupBox.Controls.Add(this.nameTextBox);
			this.organizationGroupBox.Controls.Add(this.nameLabel);
			this.organizationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.organizationGroupBox.Location = new System.Drawing.Point(23, 122);
			this.organizationGroupBox.Margin = new System.Windows.Forms.Padding(4);
			this.organizationGroupBox.Name = "organizationGroupBox";
			this.organizationGroupBox.Padding = new System.Windows.Forms.Padding(4);
			this.organizationGroupBox.Size = new System.Drawing.Size(770, 421);
			this.organizationGroupBox.TabIndex = 38;
			this.organizationGroupBox.TabStop = false;
			this.organizationGroupBox.Text = "Сведения о подразделении правоохранительного органа";
			// 
			// deleteOwnerButton
			// 
			this.deleteOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteOwnerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.deleteOwnerButton.Location = new System.Drawing.Point(553, 377);
			this.deleteOwnerButton.Margin = new System.Windows.Forms.Padding(4);
			this.deleteOwnerButton.Name = "deleteOwnerButton";
			this.deleteOwnerButton.Size = new System.Drawing.Size(200, 36);
			this.deleteOwnerButton.TabIndex = 8;
			this.deleteOwnerButton.Text = "Удалить владельца...";
			this.deleteOwnerButton.Click += new System.EventHandler(this.DeleteOwnerButton_Click);
			// 
			// selectOwnerButton
			// 
			this.selectOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.selectOwnerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.selectOwnerButton.Location = new System.Drawing.Point(345, 377);
			this.selectOwnerButton.Margin = new System.Windows.Forms.Padding(4);
			this.selectOwnerButton.Name = "selectOwnerButton";
			this.selectOwnerButton.Size = new System.Drawing.Size(200, 36);
			this.selectOwnerButton.TabIndex = 7;
			this.selectOwnerButton.Text = "Выбрать владельца...";
			this.selectOwnerButton.Click += new System.EventHandler(this.SelectOwnerButton_Click);
			// 
			// ownerTextBox
			// 
			this.ownerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.ownerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ownerTextBox.Location = new System.Drawing.Point(11, 305);
			this.ownerTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.ownerTextBox.Multiline = true;
			this.ownerTextBox.Name = "ownerTextBox";
			this.ownerTextBox.ReadOnly = true;
			this.ownerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ownerTextBox.Size = new System.Drawing.Size(742, 64);
			this.ownerTextBox.TabIndex = 45;
			this.ownerTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// ownerLabel
			// 
			this.ownerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ownerLabel.AutoSize = true;
			this.ownerLabel.Location = new System.Drawing.Point(9, 281);
			this.ownerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ownerLabel.Name = "ownerLabel";
			this.ownerLabel.Size = new System.Drawing.Size(116, 25);
			this.ownerLabel.TabIndex = 44;
			this.ownerLabel.Text = "Владелец:";
			// 
			// okatoLabel
			// 
			this.okatoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.okatoLabel.AutoSize = true;
			this.okatoLabel.Location = new System.Drawing.Point(34, 209);
			this.okatoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.okatoLabel.Name = "okatoLabel";
			this.okatoLabel.Size = new System.Drawing.Size(91, 25);
			this.okatoLabel.TabIndex = 39;
			this.okatoLabel.Text = "ОКАТО:";
			// 
			// authorityLabel
			// 
			this.authorityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.authorityLabel.AutoSize = true;
			this.authorityLabel.Location = new System.Drawing.Point(9, 245);
			this.authorityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.authorityLabel.Name = "authorityLabel";
			this.authorityLabel.Size = new System.Drawing.Size(130, 25);
			this.authorityLabel.TabIndex = 43;
			this.authorityLabel.Text = "Вид органа:";
			// 
			// okatoComboBox
			// 
			this.okatoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.okatoComboBox.Code = "";
			this.okatoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.okatoComboBox.DropDownHeight = 584;
			this.okatoComboBox.DropDownWidth = 80;
			this.okatoComboBox.FormattingEnabled = true;
			this.okatoComboBox.Id = ((long)(-1));
			this.okatoComboBox.IntegralHeight = false;
			this.okatoComboBox.ItemHeight = 29;
			this.okatoComboBox.Location = new System.Drawing.Point(144, 206);
			this.okatoComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.okatoComboBox.MaxDropDownItems = 20;
			this.okatoComboBox.Name = "okatoComboBox";
			this.okatoComboBox.SelectedItem = null;
			this.okatoComboBox.Size = new System.Drawing.Size(618, 35);
			this.okatoComboBox.TabIndex = 6;
			this.okatoComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
			// 
			// authorityComboBox
			// 
			this.authorityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.authorityComboBox.Code = "";
			this.authorityComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.authorityComboBox.DropDownHeight = 584;
			this.authorityComboBox.DropDownWidth = 80;
			this.authorityComboBox.FormattingEnabled = true;
			this.authorityComboBox.Id = ((long)(-1));
			this.authorityComboBox.IntegralHeight = false;
			this.authorityComboBox.ItemHeight = 29;
			this.authorityComboBox.Location = new System.Drawing.Point(144, 242);
			this.authorityComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.authorityComboBox.MaxDropDownItems = 20;
			this.authorityComboBox.Name = "authorityComboBox";
			this.authorityComboBox.SelectedItem = null;
			this.authorityComboBox.Size = new System.Drawing.Size(618, 35);
			this.authorityComboBox.TabIndex = 5;
			this.authorityComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
			// 
			// codeTextBox
			// 
			this.codeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.codeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.codeTextBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.codeTextBox.Location = new System.Drawing.Point(231, 172);
			this.codeTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.codeTextBox.Name = "codeTextBox";
			this.codeTextBox.ReadOnly = true;
			this.codeTextBox.Size = new System.Drawing.Size(149, 30);
			this.codeTextBox.TabIndex = 2;
			this.codeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.codeTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// codeLabel
			// 
			this.codeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.codeLabel.AutoSize = true;
			this.codeLabel.Location = new System.Drawing.Point(7, 175);
			this.codeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.codeLabel.Name = "codeLabel";
			this.codeLabel.Size = new System.Drawing.Size(216, 25);
			this.codeLabel.TabIndex = 39;
			this.codeLabel.Text = "Код подразделения:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nameTextBox.Location = new System.Drawing.Point(11, 48);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.nameTextBox.Multiline = true;
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.nameTextBox.Size = new System.Drawing.Size(742, 116);
			this.nameTextBox.TabIndex = 1;
			this.nameTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// nameWizardButton
			// 
			this.nameWizardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nameWizardButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.nameWizardButton.Location = new System.Drawing.Point(608, 87);
			this.nameWizardButton.Name = "nameWizardButton";
			this.nameWizardButton.Size = new System.Drawing.Size(188, 39);
			this.nameWizardButton.TabIndex = 39;
			this.nameWizardButton.Text = "Мастер имени";
			this.nameWizardButton.UseVisualStyleBackColor = true;
			this.nameWizardButton.Click += new System.EventHandler(this.NameWizardButton_Click);
			// 
			// CreateNewVersionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 591);
			this.Controls.Add(this.nameWizardButton);
			this.Controls.Add(this.organizationGroupBox);
			this.Controls.Add(this.beginDateLabel);
			this.Controls.Add(this.beginDateTimePicker);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.Duplicate32;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MinimumSize = new System.Drawing.Size(830, 647);
			this.Name = "CreateNewVersionDialog";
			this.Controls.SetChildIndex(this.beginDateTimePicker, 0);
			this.Controls.SetChildIndex(this.beginDateLabel, 0);
			this.Controls.SetChildIndex(this.organizationGroupBox, 0);
			this.Controls.SetChildIndex(this.nameWizardButton, 0);
			this.organizationGroupBox.ResumeLayout(false);
			this.organizationGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion Код, автоматически созданный конструктором форм Windows

		private Label beginDateLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label codeLabel;
		private System.Windows.Forms.Label okatoLabel;
		private System.Windows.Forms.Label authorityLabel;
		private TextBox ownerTextBox;
		private System.Windows.Forms.Label ownerLabel;
		private System.Windows.Forms.Button selectOwnerButton;
		private System.Windows.Forms.Button deleteOwnerButton;
		private GroupBox organizationGroupBox;
		private TextBox codeTextBox;
		private Controls.AuthorityComboBox authorityComboBox;
		private Controls.OkatoComboBox okatoComboBox;
		private TextBox nameTextBox;
		private DateTimePicker beginDateTimePicker;

		private void NameWizardButton_Click(object sender, EventArgs e)
		{
			nameTextBox.Text = Utils.NameWizard.GetName(DataRow);
		}
	}
}