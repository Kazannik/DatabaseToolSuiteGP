// Ignore Spelling: Oktmo Loc Urp DOESNT Ved

using DatabaseToolSuite.Controls;
using DatabaseToolSuite.Services;
using System;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
	internal class UrpDialog : DialogBase
	{
		private readonly bool createNew;

		private readonly bool oldDOESNT_CONSOLIDATE_CHILD;
		private readonly bool oldDOESNT_CREATE_CARD;
		private readonly bool oldDOESNT_SIGN_REPORT;
		private readonly long oldAGENCY_RECEIVING_REPORT;
		private readonly long oldLAW_AGENCY_TYPE;
		private readonly long oldOKTMO_LOC_ID;
		private readonly string oldSHORT_NAME;
		private readonly string oldVED_CODE;
		private readonly bool oldIS_GS;
		private readonly long oldSPECIAL_TERRITORIAL_CODE;

		protected UrpDialog() : base()
		{
			ApplyButtonVisible = false;

			InitializeComponent();

			FormBorderStyle = FormBorderStyle.Sizable;

			OKTMO_LOC_ID_ComboBox.InitializeSource(Services.FileSystem.Repository.MainDataSet.okato);
			AGENCY_TYPE_ComboBox.InitializeSource(Services.FileSystem.Repository.MainDataSet.EXP_LAW_AGENCY_TYPES);
			SPECIAL_TERRITORIAL_CODE_ComboBox.InitializeSource(Services.FileSystem.Repository.MainDataSet.SPECIAL_TERRITORIAL_CODE);

			Text = "Новая запись о подразделении в УРП ГАС ПС";
			DialogCaption = "Создание записи о подразделении в УРП ГАС ПС";

			OkButtonEnabled = false;
		}

		protected TextBox SHORT_NAME_TextBox;
		protected CheckBox DOESNT_CREATE_CARD_CheckBox;
		protected CheckBox DOESNT_SIGN_REPORT_CheckBox;

		public UrpDialog(Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow row, bool createNew) : this()
		{
			this.createNew = createNew;

			DataRow = row;

			oldAGENCY_RECEIVING_REPORT = DataRow.AGENCY_RECEIVING_REPORT;
			oldDOESNT_CONSOLIDATE_CHILD = DataRow.DOESNT_CONSOLIDATE_CHILD;
			oldDOESNT_CREATE_CARD = DataRow.DOESNT_CREATE_CARD;
			oldDOESNT_SIGN_REPORT = DataRow.DOESNT_SIGN_REPORT;
			oldLAW_AGENCY_TYPE = DataRow.IsLAW_AGENCY_TYPENull() ? 0 : DataRow.LAW_AGENCY_TYPE;
			oldOKTMO_LOC_ID = DataRow.OKTMO_LOC_ID;
			oldSHORT_NAME = DataRow.SHORT_NAME;
			oldVED_CODE = DataRow.IsVED_CODENull() ? string.Empty : DataRow.VED_CODE;
			oldSPECIAL_TERRITORIAL_CODE = DataRow.IsSPECIAL_TERRITORIAL_CODENull() || DataRow.SPECIAL_TERRITORIAL_CODE == 0 ? -1 : DataRow.SPECIAL_TERRITORIAL_CODE;
			oldIS_GS = DataRow.IS_GS;

			DOESNT_CONSOLIDATE_CHILD_CheckBox.Checked = DataRow.DOESNT_CONSOLIDATE_CHILD;
			DOESNT_CREATE_CARD_CheckBox.Checked = DataRow.DOESNT_CREATE_CARD;
			DOESNT_SIGN_REPORT_CheckBox.Checked = DataRow.DOESNT_SIGN_REPORT;
			AgencyReceivingReport = DataRow.AGENCY_RECEIVING_REPORT;
			AGENCY_RECEIVING_REPORT_TextBox.Text = FileSystem.Repository.MainDataSet.gasps.ExistsKey(AgencyReceivingReport) ?
				FileSystem.Repository.MainDataSet.gasps.GetLastVersionOrganizationFromKey(AgencyReceivingReport).name + " (код: " + FileSystem.Repository.MainDataSet.gasps.GetLastVersionOrganizationFromKey(AgencyReceivingReport).code + ")" :
				string.Empty;

			AGENCY_TYPE_ComboBox.Id = DataRow.IsLAW_AGENCY_TYPENull() ? -1 : DataRow.LAW_AGENCY_TYPE;
			OKTMO_LOC_ID_ComboBox.Id = DataRow.OKTMO_LOC_ID;
			SHORT_NAME_TextBox.Text = DataRow.SHORT_NAME;
			VED_CODE_TextBox.Text = DataRow.IsVED_CODENull() ? string.Empty : DataRow.VED_CODE;
			SPECIAL_TERRITORIAL_CODE_ComboBox.Id = DataRow.IsSPECIAL_TERRITORIAL_CODENull() ? -1 : DataRow.SPECIAL_TERRITORIAL_CODE;
			IS_GS_CheckBox.Checked = DataRow.IS_GS;

			if (createNew) OkButtonEnabled = true;
		}

		public Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow DataRow { get; private set; }

		public bool DoesntConsolidateChild => DOESNT_CONSOLIDATE_CHILD_CheckBox.Checked;

		public bool DoesntCreateCard => DOESNT_CREATE_CARD_CheckBox.Checked;

		public bool DoesntSingReport => DOESNT_SIGN_REPORT_CheckBox.Checked;

		public long AgencyReceivingReport { get; private set; }

		public long LawAgencyType => AGENCY_TYPE_ComboBox.Value ?? 0;

		public long OktmoLocId => OKTMO_LOC_ID_ComboBox.Id;

		public string ShortName => SHORT_NAME_TextBox.Text;

		public string VedCode => VED_CODE_TextBox.Text;

		public bool IsGS => IS_GS_CheckBox.Checked;

		public long SpecialTerritorialCode => SPECIAL_TERRITORIAL_CODE_ComboBox.Id;


		private Label AGENCY_RECEIVING_REPORT_Label;
		protected TextBox AGENCY_RECEIVING_REPORT_TextBox;
		private Button AGENCY_RECEIVING_REPORT_Button;
		private Label AGENCY_TYPE_Label;
		protected LawAgencyTypesComboBox AGENCY_TYPE_ComboBox;
		protected TextBox VED_CODE_TextBox;
		private Label VED_CODE_Label;
		private Label OKTMO_LOC_ID_Label;
		protected OkatoComboBox OKTMO_LOC_ID_ComboBox;
		protected CheckBox DOESNT_CONSOLIDATE_CHILD_CheckBox;
		private Label SHORT_NAME_Label;
		protected SpecialTerritorialComboBox SPECIAL_TERRITORIAL_CODE_ComboBox;
		private Label SPECIAL_TERRITORIAL_CODE_Label;
		private Button AGENCY_RECEIVING_REPORT_Clean_button;
		protected CheckBox IS_GS_CheckBox;

		private void InitializeComponent()
		{
			this.SHORT_NAME_Label = new System.Windows.Forms.Label();
			this.SHORT_NAME_TextBox = new System.Windows.Forms.TextBox();
			this.DOESNT_CREATE_CARD_CheckBox = new System.Windows.Forms.CheckBox();
			this.DOESNT_SIGN_REPORT_CheckBox = new System.Windows.Forms.CheckBox();
			this.AGENCY_RECEIVING_REPORT_Label = new System.Windows.Forms.Label();
			this.AGENCY_RECEIVING_REPORT_TextBox = new System.Windows.Forms.TextBox();
			this.AGENCY_RECEIVING_REPORT_Button = new System.Windows.Forms.Button();
			this.AGENCY_TYPE_Label = new System.Windows.Forms.Label();
			this.AGENCY_TYPE_ComboBox = new DatabaseToolSuite.Controls.LawAgencyTypesComboBox();
			this.VED_CODE_TextBox = new System.Windows.Forms.TextBox();
			this.VED_CODE_Label = new System.Windows.Forms.Label();
			this.OKTMO_LOC_ID_Label = new System.Windows.Forms.Label();
			this.OKTMO_LOC_ID_ComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox = new System.Windows.Forms.CheckBox();
			this.SPECIAL_TERRITORIAL_CODE_ComboBox = new DatabaseToolSuite.Controls.SpecialTerritorialComboBox();
			this.SPECIAL_TERRITORIAL_CODE_Label = new System.Windows.Forms.Label();
			this.AGENCY_RECEIVING_REPORT_Clean_button = new System.Windows.Forms.Button();
			this.IS_GS_CheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// SHORT_NAME_Label
			// 
			this.SHORT_NAME_Label.AutoSize = true;
			this.SHORT_NAME_Label.Location = new System.Drawing.Point(12, 72);
			this.SHORT_NAME_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.SHORT_NAME_Label.Name = "SHORT_NAME_Label";
			this.SHORT_NAME_Label.Size = new System.Drawing.Size(216, 20);
			this.SHORT_NAME_Label.TabIndex = 3;
			this.SHORT_NAME_Label.Text = "Краткое наименование :";
			// 
			// SHORT_NAME_TextBox
			// 
			this.SHORT_NAME_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SHORT_NAME_TextBox.Location = new System.Drawing.Point(240, 72);
			this.SHORT_NAME_TextBox.Margin = new System.Windows.Forms.Padding(2);
			this.SHORT_NAME_TextBox.Name = "SHORT_NAME_TextBox";
			this.SHORT_NAME_TextBox.Size = new System.Drawing.Size(489, 27);
			this.SHORT_NAME_TextBox.TabIndex = 4;
			this.SHORT_NAME_TextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// DOESNT_CREATE_CARD_CheckBox
			// 
			this.DOESNT_CREATE_CARD_CheckBox.AutoSize = true;
			this.DOESNT_CREATE_CARD_CheckBox.Location = new System.Drawing.Point(12, 192);
			this.DOESNT_CREATE_CARD_CheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.DOESNT_CREATE_CARD_CheckBox.Name = "DOESNT_CREATE_CARD_CheckBox";
			this.DOESNT_CREATE_CARD_CheckBox.Size = new System.Drawing.Size(217, 24);
			this.DOESNT_CREATE_CARD_CheckBox.TabIndex = 5;
			this.DOESNT_CREATE_CARD_CheckBox.Text = "Не создаёт карточки ";
			this.DOESNT_CREATE_CARD_CheckBox.UseVisualStyleBackColor = true;
			this.DOESNT_CREATE_CARD_CheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// DOESNT_SIGN_REPORT_CheckBox
			// 
			this.DOESNT_SIGN_REPORT_CheckBox.AutoSize = true;
			this.DOESNT_SIGN_REPORT_CheckBox.Location = new System.Drawing.Point(12, 228);
			this.DOESNT_SIGN_REPORT_CheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.DOESNT_SIGN_REPORT_CheckBox.Name = "DOESNT_SIGN_REPORT_CheckBox";
			this.DOESNT_SIGN_REPORT_CheckBox.Size = new System.Drawing.Size(227, 24);
			this.DOESNT_SIGN_REPORT_CheckBox.TabIndex = 6;
			this.DOESNT_SIGN_REPORT_CheckBox.Text = "Не подписывает отчёт";
			this.DOESNT_SIGN_REPORT_CheckBox.UseVisualStyleBackColor = true;
			this.DOESNT_SIGN_REPORT_CheckBox.CheckStateChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// AGENCY_RECEIVING_REPORT_Label
			// 
			this.AGENCY_RECEIVING_REPORT_Label.AutoSize = true;
			this.AGENCY_RECEIVING_REPORT_Label.Location = new System.Drawing.Point(12, 300);
			this.AGENCY_RECEIVING_REPORT_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.AGENCY_RECEIVING_REPORT_Label.Name = "AGENCY_RECEIVING_REPORT_Label";
			this.AGENCY_RECEIVING_REPORT_Label.Size = new System.Drawing.Size(169, 20);
			this.AGENCY_RECEIVING_REPORT_Label.TabIndex = 7;
			this.AGENCY_RECEIVING_REPORT_Label.Text = "Передаёт отчёт в:";
			// 
			// AGENCY_RECEIVING_REPORT_TextBox
			// 
			this.AGENCY_RECEIVING_REPORT_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_RECEIVING_REPORT_TextBox.Location = new System.Drawing.Point(201, 300);
			this.AGENCY_RECEIVING_REPORT_TextBox.Margin = new System.Windows.Forms.Padding(2);
			this.AGENCY_RECEIVING_REPORT_TextBox.Multiline = true;
			this.AGENCY_RECEIVING_REPORT_TextBox.Name = "AGENCY_RECEIVING_REPORT_TextBox";
			this.AGENCY_RECEIVING_REPORT_TextBox.ReadOnly = true;
			this.AGENCY_RECEIVING_REPORT_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.AGENCY_RECEIVING_REPORT_TextBox.Size = new System.Drawing.Size(292, 57);
			this.AGENCY_RECEIVING_REPORT_TextBox.TabIndex = 8;
			this.AGENCY_RECEIVING_REPORT_TextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// AGENCY_RECEIVING_REPORT_Button
			// 
			this.AGENCY_RECEIVING_REPORT_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_RECEIVING_REPORT_Button.Location = new System.Drawing.Point(502, 300);
			this.AGENCY_RECEIVING_REPORT_Button.Margin = new System.Windows.Forms.Padding(2);
			this.AGENCY_RECEIVING_REPORT_Button.Name = "AGENCY_RECEIVING_REPORT_Button";
			this.AGENCY_RECEIVING_REPORT_Button.Size = new System.Drawing.Size(108, 27);
			this.AGENCY_RECEIVING_REPORT_Button.TabIndex = 9;
			this.AGENCY_RECEIVING_REPORT_Button.Text = "Обзор...";
			this.AGENCY_RECEIVING_REPORT_Button.UseVisualStyleBackColor = true;
			this.AGENCY_RECEIVING_REPORT_Button.Click += new System.EventHandler(this.AGENCY_RECEIVING_REPORT_button_Click);
			// 
			// AGENCY_TYPE_Label
			// 
			this.AGENCY_TYPE_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AGENCY_TYPE_Label.AutoSize = true;
			this.AGENCY_TYPE_Label.Location = new System.Drawing.Point(12, 374);
			this.AGENCY_TYPE_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.AGENCY_TYPE_Label.Name = "AGENCY_TYPE_Label";
			this.AGENCY_TYPE_Label.Size = new System.Drawing.Size(182, 20);
			this.AGENCY_TYPE_Label.TabIndex = 10;
			this.AGENCY_TYPE_Label.Text = "Тип подразделений:";
			// 
			// AGENCY_TYPE_ComboBox
			// 
			this.AGENCY_TYPE_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_TYPE_ComboBox.Code = "";
			this.AGENCY_TYPE_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.AGENCY_TYPE_ComboBox.DropDownHeight = 504;
			this.AGENCY_TYPE_ComboBox.DropDownWidth = 80;
			this.AGENCY_TYPE_ComboBox.FormattingEnabled = true;
			this.AGENCY_TYPE_ComboBox.Id = ((long)(-1));
			this.AGENCY_TYPE_ComboBox.IntegralHeight = false;
			this.AGENCY_TYPE_ComboBox.ItemHeight = 25;
			this.AGENCY_TYPE_ComboBox.Location = new System.Drawing.Point(204, 369);
			this.AGENCY_TYPE_ComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.AGENCY_TYPE_ComboBox.MaxDropDownItems = 20;
			this.AGENCY_TYPE_ComboBox.Name = "AGENCY_TYPE_ComboBox";
			this.AGENCY_TYPE_ComboBox.SelectedItem = null;
			this.AGENCY_TYPE_ComboBox.Size = new System.Drawing.Size(530, 31);
			this.AGENCY_TYPE_ComboBox.TabIndex = 11;
			this.AGENCY_TYPE_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// VED_CODE_TextBox
			// 
			this.VED_CODE_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.VED_CODE_TextBox.Location = new System.Drawing.Point(201, 411);
			this.VED_CODE_TextBox.Margin = new System.Windows.Forms.Padding(2);
			this.VED_CODE_TextBox.Name = "VED_CODE_TextBox";
			this.VED_CODE_TextBox.Size = new System.Drawing.Size(530, 27);
			this.VED_CODE_TextBox.TabIndex = 12;
			this.VED_CODE_TextBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// VED_CODE_Label
			// 
			this.VED_CODE_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.VED_CODE_Label.AutoSize = true;
			this.VED_CODE_Label.Location = new System.Drawing.Point(10, 414);
			this.VED_CODE_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.VED_CODE_Label.Name = "VED_CODE_Label";
			this.VED_CODE_Label.Size = new System.Drawing.Size(187, 20);
			this.VED_CODE_Label.TabIndex = 13;
			this.VED_CODE_Label.Text = "Ведомственный код:";
			// 
			// OKTMO_LOC_ID_Label
			// 
			this.OKTMO_LOC_ID_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OKTMO_LOC_ID_Label.AutoSize = true;
			this.OKTMO_LOC_ID_Label.Location = new System.Drawing.Point(12, 453);
			this.OKTMO_LOC_ID_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.OKTMO_LOC_ID_Label.Name = "OKTMO_LOC_ID_Label";
			this.OKTMO_LOC_ID_Label.Size = new System.Drawing.Size(309, 20);
			this.OKTMO_LOC_ID_Label.TabIndex = 14;
			this.OKTMO_LOC_ID_Label.Text = "ОКТМО территории обслуживания :";
			// 
			// OKTMO_LOC_ID_ComboBox
			// 
			this.OKTMO_LOC_ID_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OKTMO_LOC_ID_ComboBox.Code = "";
			this.OKTMO_LOC_ID_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.OKTMO_LOC_ID_ComboBox.DropDownHeight = 504;
			this.OKTMO_LOC_ID_ComboBox.DropDownWidth = 80;
			this.OKTMO_LOC_ID_ComboBox.FormattingEnabled = true;
			this.OKTMO_LOC_ID_ComboBox.Id = ((long)(-1));
			this.OKTMO_LOC_ID_ComboBox.IntegralHeight = false;
			this.OKTMO_LOC_ID_ComboBox.ItemHeight = 25;
			this.OKTMO_LOC_ID_ComboBox.Location = new System.Drawing.Point(324, 453);
			this.OKTMO_LOC_ID_ComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.OKTMO_LOC_ID_ComboBox.MaxDropDownItems = 20;
			this.OKTMO_LOC_ID_ComboBox.Name = "OKTMO_LOC_ID_ComboBox";
			this.OKTMO_LOC_ID_ComboBox.SelectedItem = null;
			this.OKTMO_LOC_ID_ComboBox.Size = new System.Drawing.Size(408, 31);
			this.OKTMO_LOC_ID_ComboBox.TabIndex = 15;
			this.OKTMO_LOC_ID_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// DOESNT_CONSOLIDATE_CHILD_CheckBox
			// 
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.AutoSize = true;
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.Location = new System.Drawing.Point(12, 264);
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.Name = "DOESNT_CONSOLIDATE_CHILD_CheckBox";
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.Size = new System.Drawing.Size(274, 24);
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.TabIndex = 16;
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.Text = "Не консолидирует дочерние";
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.UseVisualStyleBackColor = true;
			this.DOESNT_CONSOLIDATE_CHILD_CheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// SPECIAL_TERRITORIAL_CODE_ComboBox
			// 
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Code = "";
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.DropDownHeight = 504;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.DropDownWidth = 80;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.FormattingEnabled = true;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Id = ((long)(-1));
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.IntegralHeight = false;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.ItemHeight = 25;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Location = new System.Drawing.Point(240, 144);
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.MaxDropDownItems = 20;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Name = "SPECIAL_TERRITORIAL_CODE_ComboBox";
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.SelectedItem = null;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Size = new System.Drawing.Size(489, 31);
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.TabIndex = 17;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// SPECIAL_TERRITORIAL_CODE_Label
			// 
			this.SPECIAL_TERRITORIAL_CODE_Label.AutoSize = true;
			this.SPECIAL_TERRITORIAL_CODE_Label.Location = new System.Drawing.Point(12, 108);
			this.SPECIAL_TERRITORIAL_CODE_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.SPECIAL_TERRITORIAL_CODE_Label.Name = "SPECIAL_TERRITORIAL_CODE_Label";
			this.SPECIAL_TERRITORIAL_CODE_Label.Size = new System.Drawing.Size(390, 20);
			this.SPECIAL_TERRITORIAL_CODE_Label.TabIndex = 18;
			this.SPECIAL_TERRITORIAL_CODE_Label.Text = "Специализированный территориальный код:";
			// 
			// AGENCY_RECEIVING_REPORT_Clean_button
			// 
			this.AGENCY_RECEIVING_REPORT_Clean_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_RECEIVING_REPORT_Clean_button.Location = new System.Drawing.Point(622, 300);
			this.AGENCY_RECEIVING_REPORT_Clean_button.Margin = new System.Windows.Forms.Padding(2);
			this.AGENCY_RECEIVING_REPORT_Clean_button.Name = "AGENCY_RECEIVING_REPORT_Clean_button";
			this.AGENCY_RECEIVING_REPORT_Clean_button.Size = new System.Drawing.Size(108, 27);
			this.AGENCY_RECEIVING_REPORT_Clean_button.TabIndex = 19;
			this.AGENCY_RECEIVING_REPORT_Clean_button.Text = "Очистить";
			this.AGENCY_RECEIVING_REPORT_Clean_button.UseVisualStyleBackColor = true;
			this.AGENCY_RECEIVING_REPORT_Clean_button.Click += new System.EventHandler(this.AGENCY_RECEIVING_REPORT_Clean_button_Click);
			// 
			// IS_GS_CheckBox
			// 
			this.IS_GS_CheckBox.AutoSize = true;
			this.IS_GS_CheckBox.Location = new System.Drawing.Point(336, 192);
			this.IS_GS_CheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.IS_GS_CheckBox.Name = "IS_GS_CheckBox";
			this.IS_GS_CheckBox.Size = new System.Drawing.Size(402, 24);
			this.IS_GS_CheckBox.TabIndex = 20;
			this.IS_GS_CheckBox.Text = "Участвует в формировании гос.отчетности";
			this.IS_GS_CheckBox.UseVisualStyleBackColor = true;
			this.IS_GS_CheckBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// UrpDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.ClientSize = new System.Drawing.Size(742, 553);
			this.Controls.Add(this.IS_GS_CheckBox);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_Clean_button);
			this.Controls.Add(this.SPECIAL_TERRITORIAL_CODE_Label);
			this.Controls.Add(this.SPECIAL_TERRITORIAL_CODE_ComboBox);
			this.Controls.Add(this.DOESNT_CONSOLIDATE_CHILD_CheckBox);
			this.Controls.Add(this.OKTMO_LOC_ID_ComboBox);
			this.Controls.Add(this.OKTMO_LOC_ID_Label);
			this.Controls.Add(this.VED_CODE_Label);
			this.Controls.Add(this.VED_CODE_TextBox);
			this.Controls.Add(this.AGENCY_TYPE_ComboBox);
			this.Controls.Add(this.AGENCY_TYPE_Label);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_Button);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_TextBox);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_Label);
			this.Controls.Add(this.DOESNT_SIGN_REPORT_CheckBox);
			this.Controls.Add(this.DOESNT_CREATE_CARD_CheckBox);
			this.Controls.Add(this.SHORT_NAME_TextBox);
			this.Controls.Add(this.SHORT_NAME_Label);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.emblem32;
			this.Margin = new System.Windows.Forms.Padding(3);
			this.MinimumSize = new System.Drawing.Size(760, 600);
			this.Name = "UrpDialog";
			this.Controls.SetChildIndex(this.SHORT_NAME_Label, 0);
			this.Controls.SetChildIndex(this.SHORT_NAME_TextBox, 0);
			this.Controls.SetChildIndex(this.DOESNT_CREATE_CARD_CheckBox, 0);
			this.Controls.SetChildIndex(this.DOESNT_SIGN_REPORT_CheckBox, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_Label, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_TextBox, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_Button, 0);
			this.Controls.SetChildIndex(this.AGENCY_TYPE_Label, 0);
			this.Controls.SetChildIndex(this.AGENCY_TYPE_ComboBox, 0);
			this.Controls.SetChildIndex(this.VED_CODE_TextBox, 0);
			this.Controls.SetChildIndex(this.VED_CODE_Label, 0);
			this.Controls.SetChildIndex(this.OKTMO_LOC_ID_Label, 0);
			this.Controls.SetChildIndex(this.OKTMO_LOC_ID_ComboBox, 0);
			this.Controls.SetChildIndex(this.DOESNT_CONSOLIDATE_CHILD_CheckBox, 0);
			this.Controls.SetChildIndex(this.SPECIAL_TERRITORIAL_CODE_ComboBox, 0);
			this.Controls.SetChildIndex(this.SPECIAL_TERRITORIAL_CODE_Label, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_Clean_button, 0);
			this.Controls.SetChildIndex(this.IS_GS_CheckBox, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void AGENCY_RECEIVING_REPORT_button_Click(object sender, EventArgs e)
		{
			SelectOrganizationDialog dialog = new SelectOrganizationDialog(MasterDataSystem.PROSECUTOR_CODE)
			{
				LastLockOnlyShow = false,
				LockShow = false,
				ReserveShow = false,
				UnlockShow = true
			};

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				AgencyReceivingReport = dialog.DataRow.key;
				AGENCY_RECEIVING_REPORT_TextBox.Text = dialog.DataRow.name + " (код: " + dialog.DataRow.code + ")";
			}
		}

		private void Controls_ValueChanged(object sender, EventArgs e)
		{
			if (
				oldDOESNT_CONSOLIDATE_CHILD != DoesntConsolidateChild ||
				oldDOESNT_CREATE_CARD != DoesntCreateCard ||
				oldDOESNT_SIGN_REPORT != DoesntSingReport ||
				oldAGENCY_RECEIVING_REPORT != AgencyReceivingReport ||
				oldLAW_AGENCY_TYPE != LawAgencyType ||
				oldOKTMO_LOC_ID != OktmoLocId ||
				oldSHORT_NAME != ShortName ||
				oldVED_CODE != VedCode ||
				oldSPECIAL_TERRITORIAL_CODE != SpecialTerritorialCode ||
				oldIS_GS != IsGS
				)
			{
				OkButtonEnabled = true;
			}
			else
			{
				OkButtonEnabled = createNew;
			}
		}

		private void AGENCY_RECEIVING_REPORT_Clean_button_Click(object sender, EventArgs e)
		{
			AgencyReceivingReport = 0;
			AGENCY_RECEIVING_REPORT_TextBox.Text = string.Empty;
		}		
	}
}