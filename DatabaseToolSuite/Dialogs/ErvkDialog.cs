// Ignore Spelling: Ervk Ogrn

using DatabaseToolSuite.Services;
using System;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	class ErvkDialog : DialogBase
	{
		public Repositories.MainDataSet.ervkRow DataRow { get; private set; }

		private readonly bool oldIsHead;
		private readonly bool oldSpecial;
		private readonly bool oldMilitary;
		private readonly bool oldIsActive;
		private readonly long oldIdVersionHead;
		private readonly long oldIdSuccession;
		private readonly DateTime oldDateStartVersion;
		private readonly DateTime oldDateCloseProc;
		private readonly string oldOgrn;
		private readonly string oldInn;
		private readonly string oldOktmo;

		private Button deleteOwnerButton;
		private Button selectOwnerButton;
		private TextBox ownerTextBox;
		private Button autoSelectOwnerButton;
		protected Label beginDateLabel;
		protected DateTimePicker beginDateTimePicker;
		protected Label endDateLabel;
		protected DateTimePicker endDateTimePicker;
		private GroupBox ownerGroupBox;
		private Label label3;
		private Controls.NumericTextBox oktmoNumericTextBox;
		private Button getOwnerArgButton;

		public Repositories.MainDataSet.ervkRow ErvkOrganization { get; private set; }
		public Repositories.MainDataSet.ervkRow ErvkOwnerOrganization { get; private set; }
		public Repositories.MainDataSet.gaspsRow GaspsOrganization { get; private set; }
		public Repositories.MainDataSet.gaspsRow GaspsOwnerOrganization { get; private set; }

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
		public long IdVersionHead { get { return ErvkOwnerOrganization == null ? 0 : ErvkOwnerOrganization.esnsiCode; } }

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

		/// <summary>
		/// ОКТМО (из справочника ЕРВК, может отличаться от ГАС ПС)
		/// </summary>
		public string Oktmo { get { return oktmoNumericTextBox.Text; } }

		public ErvkDialog() : base()
		{
			ApplyButtonVisible = false;

			InitializeComponent();
			///InitializeLocation();
		}

		public ErvkDialog(Repositories.MainDataSet.ervkRow row) : base()
		{
			ApplyButtonVisible = false;

			InitializeComponent();
			///InitializeLocation();

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
			oldOktmo = DataRow.IsoktmoListNull() ? string.Empty : DataRow.oktmoList;

			esnsiNameTextBox.Text = DataRow.gaspsRow.name;

			isHeadCheckBox.Checked = DataRow.isHead;
			isSpecialCheckBox.Checked = DataRow.special;
			isMilitaryCheckBox.Checked = DataRow.military;
			isActiveCheckBox.Checked = DataRow.isActive;

			beginDateTimePicker.Value = DataRow.dateStartVersion;
			endDateTimePicker.Value = DataRow.IsdateCloseProcNull() ? MasterDataSystem.MAX_DATE : DataRow.dateCloseProc;

			ogrnNumericTextBox.Text = DataRow.IsogrnNull() ? string.Empty : DataRow.ogrn;
			innNumericTextBox.Text = DataRow.IsinnNull() ? string.Empty : DataRow.inn;
			oktmoNumericTextBox.Text = DataRow.IsoktmoListNull() ? string.Empty : DataRow.oktmoList;

			ErvkOrganization = row;
			GaspsOrganization = MasterDataSystem.DataSet.gasps.Get(ErvkOrganization.version);

			if (MasterDataSystem.DataSet.ervk.ExistsEsnsiCode(DataRow.IsidVersionHeadNull() ? 0 : DataRow.idVersionHead))
			{
				ErvkOwnerOrganization = MasterDataSystem.DataSet.ervk.GetFromEsnsiCode(DataRow.IsidVersionHeadNull() ? 0 : DataRow.idVersionHead);
				GaspsOwnerOrganization = MasterDataSystem.DataSet.gasps.Get(ErvkOwnerOrganization.version);

			}
			SetOwnerOrganizationName();
			OkButtonEnabled = false;
		}


		private void GetOwnerOrganization()
		{
			long ownerKey = DataRow.gaspsRow.owner_id;
			if (MasterDataSystem.DataSet.gasps.ExistsKey(ownerKey))
			{
				GaspsOwnerOrganization = MasterDataSystem.DataSet.gasps.GetVersionOrganizationFromKeyDate(ownerKey, DateTime.Now);
				if (MasterDataSystem.DataSet.ervk.Exists(GaspsOwnerOrganization.version))
				{
					ErvkOwnerOrganization = MasterDataSystem.DataSet.ervk.Get(GaspsOwnerOrganization.version);
				}
				else
				{
					GaspsOwnerOrganization = null;
					ErvkOwnerOrganization = null;
					MessageBox.Show(this, "Не удалось в автоматическом режиме получить код родительского подразделения!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				GaspsOwnerOrganization = null;
				ErvkOwnerOrganization = null;
				MessageBox.Show(this, "Не удалось в автоматическом режиме получить код родительского подразделения!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			SetOwnerOrganizationName();
		}

		private void SetOwnerOrganizationName()
		{
			if (GaspsOwnerOrganization != null)
			{
				ownerTextBox.Text = GaspsOwnerOrganization.name + " (код: " + GaspsOwnerOrganization.code + ")";
			}
			else
			{
				ownerTextBox.Text = string.Empty;
			}
		}

		private void Controls_ValueChanged(object sender, EventArgs e)
		{
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
				oldInn != Inn ||
				oldOktmo != Oktmo
				)
			{
				OkButtonEnabled = true;
			}
			else
			{
				OkButtonEnabled = false;
			}
		}

		private void InitializeLocation()
		{
			this.esnsiNameTextBox.Location = new System.Drawing.Point(20, 112);
			this.esnsiNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.esnsiNameTextBox.Size = new System.Drawing.Size(866, 98);
			this.esnsiNameLabel.Location = new System.Drawing.Point(15, 84);
			this.esnsiNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.esnsiNameLabel.Size = new System.Drawing.Size(246, 20);
			this.innNumericTextBox.Location = new System.Drawing.Point(125, 391);
			this.innNumericTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.innNumericTextBox.Size = new System.Drawing.Size(293, 27);
			this.label1.Location = new System.Drawing.Point(25, 394);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Size = new System.Drawing.Size(51, 20);
			this.label2.Location = new System.Drawing.Point(25, 436);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Size = new System.Drawing.Size(61, 20);
			this.ogrnNumericTextBox.Location = new System.Drawing.Point(125, 436);
			this.ogrnNumericTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ogrnNumericTextBox.Size = new System.Drawing.Size(293, 27);
			this.isSpecialCheckBox.Location = new System.Drawing.Point(442, 392);
			this.isSpecialCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.isSpecialCheckBox.Size = new System.Drawing.Size(322, 24);
			this.isMilitaryCheckBox.Location = new System.Drawing.Point(442, 435);
			this.isMilitaryCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.isMilitaryCheckBox.Size = new System.Drawing.Size(213, 24);
			this.isActiveCheckBox.Location = new System.Drawing.Point(442, 544);
			this.isActiveCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.isActiveCheckBox.Size = new System.Drawing.Size(175, 24);
			this.isHeadCheckBox.Location = new System.Drawing.Point(442, 578);
			this.isHeadCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.isHeadCheckBox.Size = new System.Drawing.Size(297, 24);
			this.deleteOwnerButton.Location = new System.Drawing.Point(591, 106);
			this.deleteOwnerButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.deleteOwnerButton.Size = new System.Drawing.Size(266, 42);
			this.selectOwnerButton.Location = new System.Drawing.Point(321, 106);
			this.selectOwnerButton.Name = "selectOwnerButton";
			this.selectOwnerButton.Size = new System.Drawing.Size(266, 42);
			this.ownerTextBox.Location = new System.Drawing.Point(9, 22);
			this.ownerTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.ownerTextBox.Size = new System.Drawing.Size(848, 73);
			this.autoSelectOwnerButton.Location = new System.Drawing.Point(9, 106);
			this.autoSelectOwnerButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.autoSelectOwnerButton.Size = new System.Drawing.Size(266, 42);
			this.getOwnerArgButton.Location = new System.Drawing.Point(30, 474);
			this.getOwnerArgButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.getOwnerArgButton.Size = new System.Drawing.Size(856, 42);
			this.beginDateLabel.Location = new System.Drawing.Point(26, 541);
			this.beginDateLabel.Name = "beginDateLabel";
			this.beginDateLabel.Size = new System.Drawing.Size(263, 20);
			this.beginDateTimePicker.Location = new System.Drawing.Point(31, 578);
			this.beginDateTimePicker.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.beginDateTimePicker.Size = new System.Drawing.Size(238, 26);
			this.endDateLabel.Location = new System.Drawing.Point(26, 628);
			this.endDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.endDateLabel.Size = new System.Drawing.Size(224, 20);
			this.endDateTimePicker.Location = new System.Drawing.Point(30, 658);
			this.endDateTimePicker.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.endDateTimePicker.Size = new System.Drawing.Size(238, 26);
			this.ownerGroupBox.Location = new System.Drawing.Point(21, 219);
			this.ownerGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ownerGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ownerGroupBox.Size = new System.Drawing.Size(866, 158);
			this.ClientSize = new System.Drawing.Size(902, 786);
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
		}

		private System.Windows.Forms.TextBox esnsiNameTextBox;
		private Controls.NumericTextBox innNumericTextBox;
		private new System.ComponentModel.IContainer components;
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
			this.autoSelectOwnerButton = new System.Windows.Forms.Button();
			this.getOwnerArgButton = new System.Windows.Forms.Button();
			this.beginDateLabel = new System.Windows.Forms.Label();
			this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endDateLabel = new System.Windows.Forms.Label();
			this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.ownerGroupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.oktmoNumericTextBox = new DatabaseToolSuite.Controls.NumericTextBox(this.components);
			this.ownerGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// esnsiNameTextBox
			// 
			this.esnsiNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.esnsiNameTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.esnsiNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.esnsiNameTextBox.Location = new System.Drawing.Point(17, 83);
			this.esnsiNameTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.esnsiNameTextBox.Multiline = true;
			this.esnsiNameTextBox.Name = "esnsiNameTextBox";
			this.esnsiNameTextBox.ReadOnly = true;
			this.esnsiNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.esnsiNameTextBox.Size = new System.Drawing.Size(686, 33);
			this.esnsiNameTextBox.TabIndex = 8;
			// 
			// esnsiNameLabel
			// 
			this.esnsiNameLabel.AutoSize = true;
			this.esnsiNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.esnsiNameLabel.Location = new System.Drawing.Point(13, 62);
			this.esnsiNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.esnsiNameLabel.Name = "esnsiNameLabel";
			this.esnsiNameLabel.Size = new System.Drawing.Size(246, 20);
			this.esnsiNameLabel.TabIndex = 7;
			this.esnsiNameLabel.Text = "Наименование прокуратуры";
			// 
			// innNumericTextBox
			// 
			this.innNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.innNumericTextBox.Location = new System.Drawing.Point(109, 269);
			this.innNumericTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.innNumericTextBox.Name = "innNumericTextBox";
			this.innNumericTextBox.Size = new System.Drawing.Size(213, 27);
			this.innNumericTextBox.TabIndex = 11;
			this.innNumericTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(27, 269);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 20);
			this.label1.TabIndex = 12;
			this.label1.Text = "ИНН:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(27, 307);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 20);
			this.label2.TabIndex = 14;
			this.label2.Text = "ОГРН:";
			// 
			// ogrnNumericTextBox
			// 
			this.ogrnNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ogrnNumericTextBox.Location = new System.Drawing.Point(109, 304);
			this.ogrnNumericTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.ogrnNumericTextBox.Name = "ogrnNumericTextBox";
			this.ogrnNumericTextBox.Size = new System.Drawing.Size(213, 27);
			this.ogrnNumericTextBox.TabIndex = 13;
			this.ogrnNumericTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// isSpecialCheckBox
			// 
			this.isSpecialCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.isSpecialCheckBox.AutoSize = true;
			this.isSpecialCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.isSpecialCheckBox.Location = new System.Drawing.Point(381, 268);
			this.isSpecialCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.isSpecialCheckBox.Name = "isSpecialCheckBox";
			this.isSpecialCheckBox.Size = new System.Drawing.Size(322, 24);
			this.isSpecialCheckBox.TabIndex = 15;
			this.isSpecialCheckBox.Text = "Специализированная прокуратура";
			this.isSpecialCheckBox.UseVisualStyleBackColor = true;
			this.isSpecialCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// isMilitaryCheckBox
			// 
			this.isMilitaryCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.isMilitaryCheckBox.AutoSize = true;
			this.isMilitaryCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.isMilitaryCheckBox.Location = new System.Drawing.Point(381, 300);
			this.isMilitaryCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.isMilitaryCheckBox.Name = "isMilitaryCheckBox";
			this.isMilitaryCheckBox.Size = new System.Drawing.Size(213, 24);
			this.isMilitaryCheckBox.TabIndex = 16;
			this.isMilitaryCheckBox.Text = "Военная прокуратура";
			this.isMilitaryCheckBox.UseVisualStyleBackColor = true;
			this.isMilitaryCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// isActiveCheckBox
			// 
			this.isActiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.isActiveCheckBox.AutoSize = true;
			this.isActiveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.isActiveCheckBox.Location = new System.Drawing.Point(396, 383);
			this.isActiveCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.isActiveCheckBox.Name = "isActiveCheckBox";
			this.isActiveCheckBox.Size = new System.Drawing.Size(175, 24);
			this.isActiveCheckBox.TabIndex = 17;
			this.isActiveCheckBox.Text = "Активная запись";
			this.isActiveCheckBox.UseVisualStyleBackColor = true;
			this.isActiveCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// isHeadCheckBox
			// 
			this.isHeadCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.isHeadCheckBox.AutoSize = true;
			this.isHeadCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.isHeadCheckBox.Location = new System.Drawing.Point(396, 412);
			this.isHeadCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.isHeadCheckBox.Name = "isHeadCheckBox";
			this.isHeadCheckBox.Size = new System.Drawing.Size(297, 24);
			this.isHeadCheckBox.TabIndex = 18;
			this.isHeadCheckBox.Text = "Запись, имеющая подчиненных";
			this.isHeadCheckBox.UseVisualStyleBackColor = true;
			this.isHeadCheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// deleteOwnerButton
			// 
			this.deleteOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteOwnerButton.Location = new System.Drawing.Point(451, 69);
			this.deleteOwnerButton.Margin = new System.Windows.Forms.Padding(5);
			this.deleteOwnerButton.Name = "deleteOwnerButton";
			this.deleteOwnerButton.Size = new System.Drawing.Size(226, 42);
			this.deleteOwnerButton.TabIndex = 47;
			this.deleteOwnerButton.Text = "Удалить владельца...";
			this.deleteOwnerButton.Click += new System.EventHandler(this.DeleteOwnerButton_Click);
			// 
			// selectOwnerButton
			// 
			this.selectOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.selectOwnerButton.Location = new System.Drawing.Point(191, 70);
			this.selectOwnerButton.Margin = new System.Windows.Forms.Padding(5);
			this.selectOwnerButton.Name = "selectOwnerButton";
			this.selectOwnerButton.Size = new System.Drawing.Size(250, 42);
			this.selectOwnerButton.TabIndex = 46;
			this.selectOwnerButton.Text = "Выбрать владельца...";
			this.selectOwnerButton.Click += new System.EventHandler(this.SelectOwnerButton_Click);
			// 
			// ownerTextBox
			// 
			this.ownerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ownerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ownerTextBox.Location = new System.Drawing.Point(9, 22);
			this.ownerTextBox.Margin = new System.Windows.Forms.Padding(5);
			this.ownerTextBox.Multiline = true;
			this.ownerTextBox.Name = "ownerTextBox";
			this.ownerTextBox.ReadOnly = true;
			this.ownerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ownerTextBox.Size = new System.Drawing.Size(668, 37);
			this.ownerTextBox.TabIndex = 49;
			this.ownerTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// autoSelectOwnerButton
			// 
			this.autoSelectOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.autoSelectOwnerButton.Location = new System.Drawing.Point(9, 70);
			this.autoSelectOwnerButton.Margin = new System.Windows.Forms.Padding(5);
			this.autoSelectOwnerButton.Name = "autoSelectOwnerButton";
			this.autoSelectOwnerButton.Size = new System.Drawing.Size(167, 42);
			this.autoSelectOwnerButton.TabIndex = 50;
			this.autoSelectOwnerButton.Text = "Авто из ГАС ПС";
			this.autoSelectOwnerButton.Click += new System.EventHandler(this.AutoSelectOwnerButton_Click);
			// 
			// getOwnerArgButton
			// 
			this.getOwnerArgButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.getOwnerArgButton.Location = new System.Drawing.Point(334, 329);
			this.getOwnerArgButton.Margin = new System.Windows.Forms.Padding(5);
			this.getOwnerArgButton.Name = "getOwnerArgButton";
			this.getOwnerArgButton.Size = new System.Drawing.Size(378, 42);
			this.getOwnerArgButton.TabIndex = 51;
			this.getOwnerArgButton.Text = "Получить из вышестоящей прокуратуры";
			this.getOwnerArgButton.Click += new System.EventHandler(this.GetOwnerArgButton_Click);
			// 
			// beginDateLabel
			// 
			this.beginDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.beginDateLabel.AutoSize = true;
			this.beginDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateLabel.Location = new System.Drawing.Point(27, 368);
			this.beginDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.beginDateLabel.Name = "beginDateLabel";
			this.beginDateLabel.Size = new System.Drawing.Size(263, 20);
			this.beginDateLabel.TabIndex = 53;
			this.beginDateLabel.Text = "Дата введения новой версии:";
			// 
			// beginDateTimePicker
			// 
			this.beginDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.beginDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.beginDateTimePicker.Location = new System.Drawing.Point(26, 393);
			this.beginDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
			this.beginDateTimePicker.Name = "beginDateTimePicker";
			this.beginDateTimePicker.Size = new System.Drawing.Size(238, 26);
			this.beginDateTimePicker.TabIndex = 52;
			this.beginDateTimePicker.ValueChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// endDateLabel
			// 
			this.endDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.endDateLabel.AutoSize = true;
			this.endDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.endDateLabel.Location = new System.Drawing.Point(22, 424);
			this.endDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.endDateLabel.Name = "endDateLabel";
			this.endDateLabel.Size = new System.Drawing.Size(224, 20);
			this.endDateLabel.TabIndex = 55;
			this.endDateLabel.Text = "Дата блокировки версии:";
			// 
			// endDateTimePicker
			// 
			this.endDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.endDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.endDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.endDateTimePicker.Location = new System.Drawing.Point(26, 449);
			this.endDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
			this.endDateTimePicker.Name = "endDateTimePicker";
			this.endDateTimePicker.Size = new System.Drawing.Size(238, 26);
			this.endDateTimePicker.TabIndex = 54;
			this.endDateTimePicker.ValueChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// ownerGroupBox
			// 
			this.ownerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ownerGroupBox.Controls.Add(this.ownerTextBox);
			this.ownerGroupBox.Controls.Add(this.autoSelectOwnerButton);
			this.ownerGroupBox.Controls.Add(this.selectOwnerButton);
			this.ownerGroupBox.Controls.Add(this.deleteOwnerButton);
			this.ownerGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ownerGroupBox.Location = new System.Drawing.Point(17, 124);
			this.ownerGroupBox.Margin = new System.Windows.Forms.Padding(4);
			this.ownerGroupBox.Name = "ownerGroupBox";
			this.ownerGroupBox.Padding = new System.Windows.Forms.Padding(4);
			this.ownerGroupBox.Size = new System.Drawing.Size(686, 121);
			this.ownerGroupBox.TabIndex = 56;
			this.ownerGroupBox.TabStop = false;
			this.ownerGroupBox.Text = "Владелец";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(27, 340);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 20);
			this.label3.TabIndex = 57;
			this.label3.Text = "ОКТМО:";
			// 
			// oktmoNumericTextBox
			// 
			this.oktmoNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.oktmoNumericTextBox.Location = new System.Drawing.Point(109, 339);
			this.oktmoNumericTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.oktmoNumericTextBox.MaxLength = 11;
			this.oktmoNumericTextBox.Name = "oktmoNumericTextBox";
			this.oktmoNumericTextBox.Size = new System.Drawing.Size(213, 27);
			this.oktmoNumericTextBox.TabIndex = 58;
			this.oktmoNumericTextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// ErvkDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.ClientSize = new System.Drawing.Size(722, 533);
			this.Controls.Add(this.oktmoNumericTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ownerGroupBox);
			this.Controls.Add(this.endDateLabel);
			this.Controls.Add(this.endDateTimePicker);
			this.Controls.Add(this.beginDateLabel);
			this.Controls.Add(this.beginDateTimePicker);
			this.Controls.Add(this.getOwnerArgButton);
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
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.economy32;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MinimumSize = new System.Drawing.Size(740, 580);
			this.Name = "ErvkDialog";
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
			this.Controls.SetChildIndex(this.getOwnerArgButton, 0);
			this.Controls.SetChildIndex(this.beginDateTimePicker, 0);
			this.Controls.SetChildIndex(this.beginDateLabel, 0);
			this.Controls.SetChildIndex(this.endDateTimePicker, 0);
			this.Controls.SetChildIndex(this.endDateLabel, 0);
			this.Controls.SetChildIndex(this.ownerGroupBox, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.oktmoNumericTextBox, 0);
			this.ownerGroupBox.ResumeLayout(false);
			this.ownerGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void AutoSelectOwnerButton_Click(object sender, EventArgs e)
		{
			GetOwnerOrganization();
		}

		private void SelectOwnerButton_Click(object sender, EventArgs e)
		{
			SelectOrganizationDialog dialog;

			dialog = new SelectOrganizationDialog(ervkOnlyShow: true)
			{
				UnlockShow = true,
				LockShow = false,
				ReserveShow = false,
				LastLockOnlyShow = false
			};

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				long ownerKey = dialog.DataRow.key;
				GaspsOwnerOrganization = MasterDataSystem.DataSet.gasps.GetVersionOrganizationFromKeyDate(ownerKey, DateTime.Now);
				ErvkOwnerOrganization = MasterDataSystem.DataSet.ervk.Get(GaspsOwnerOrganization.version);
				SetOwnerOrganizationName();
			}
		}

		private void DeleteOwnerButton_Click(object sender, EventArgs e)
		{
			GaspsOwnerOrganization = null;
			ErvkOwnerOrganization = null;
			SetOwnerOrganizationName();
		}

		private void GetOwnerArgButton_Click(object sender, EventArgs e)
		{
			if (ErvkOwnerOrganization != null)
			{
				innNumericTextBox.Text = ErvkOwnerOrganization.IsinnNull() ? string.Empty : ErvkOwnerOrganization.inn;
				ogrnNumericTextBox.Text = ErvkOwnerOrganization.IsogrnNull() ? string.Empty : ErvkOwnerOrganization.ogrn;
				oktmoNumericTextBox.Text = Utils.Converters.OktmoToEightSymbols(GetOwnerOktmo());
				if (ErvkOwnerOrganization.special)
					isSpecialCheckBox.Checked = true;
				if (ErvkOwnerOrganization.military)
					isMilitaryCheckBox.Checked = true;
			}
			else
			{
				innNumericTextBox.Text = string.Empty;
				ogrnNumericTextBox.Text = string.Empty;
				oktmoNumericTextBox.Text = string.Empty;
				MessageBox.Show(this, "Не удалось в автоматическом режиме получить ИНН, ОГРН и ОКТМО вышестоящего органа!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		private string GetOwnerOktmo()
		{
			if (ErvkOwnerOrganization.IsoktmoListNull())
			{
				return GaspsOrganization.okato_code;
			}
			else
			{
				return ErvkOwnerOrganization.oktmoList;
			}
		}
	}
}
