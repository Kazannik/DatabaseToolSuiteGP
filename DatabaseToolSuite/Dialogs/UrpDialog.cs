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

		protected TextBox SHORT_NAME_textBox;
		protected CheckBox DOESNT_CREATE_CARD_checkBox;
		protected CheckBox DOESNT_SIGN_REPORT_checkBox;

		public UrpDialog(Repositoryes.MainDataSet.EXP_LAW_AGENCY_URPRow row, bool createNew) : this()
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

			DOESNT_CONSOLIDATE_CHILD_checkBox.Checked = DataRow.DOESNT_CONSOLIDATE_CHILD;
			DOESNT_CREATE_CARD_checkBox.Checked = DataRow.DOESNT_CREATE_CARD;
			DOESNT_SIGN_REPORT_checkBox.Checked = DataRow.DOESNT_SIGN_REPORT;
			AgencyReceivingReport = DataRow.AGENCY_RECEIVING_REPORT;
			AGENCY_RECEIVING_REPORT_textBox.Text = FileSystem.Repository.MainDataSet.gasps.ExistsKey(AgencyReceivingReport) ?
				FileSystem.Repository.MainDataSet.gasps.GetLastVersionOrganizationFromKey(AgencyReceivingReport).name + " (код: " + FileSystem.Repository.MainDataSet.gasps.GetLastVersionOrganizationFromKey(AgencyReceivingReport).code + ")" :
				string.Empty;

			AGENCY_TYPE_ComboBox.Id = DataRow.IsLAW_AGENCY_TYPENull() ? -1 : DataRow.LAW_AGENCY_TYPE;
			OKTMO_LOC_ID_ComboBox.Id = DataRow.OKTMO_LOC_ID;
			SHORT_NAME_textBox.Text = DataRow.SHORT_NAME;
			VED_CODE_textBox.Text = DataRow.IsVED_CODENull() ? string.Empty : DataRow.VED_CODE;
			SPECIAL_TERRITORIAL_CODE_ComboBox.Id = DataRow.IsSPECIAL_TERRITORIAL_CODENull() ? -1 : DataRow.SPECIAL_TERRITORIAL_CODE;
			if (createNew) OkButtonEnabled = true;
		}

		public Repositoryes.MainDataSet.EXP_LAW_AGENCY_URPRow DataRow { get; private set; }

		public bool DoesntConsolidateChild
		{ get { return DOESNT_CONSOLIDATE_CHILD_checkBox.Checked; } }

		public bool DoesntCreateCard
		{ get { return DOESNT_CREATE_CARD_checkBox.Checked; } }

		public bool DoesntSingReport
		{ get { return DOESNT_SIGN_REPORT_checkBox.Checked; } }

		public long AgencyReceivingReport { get; private set; }

		public long LawAgencyType
		{ get { return AGENCY_TYPE_ComboBox.Value ?? 0; } }

		public long OktmoLocId
		{ get { return OKTMO_LOC_ID_ComboBox.Id; } }

		public string ShortName
		{ get { return SHORT_NAME_textBox.Text; } }

		public string VedCode
		{ get { return VED_CODE_textBox.Text; } }

		public long SpecialTerritorialCode
		{ get { return SPECIAL_TERRITORIAL_CODE_ComboBox.Id; } }
		private System.Windows.Forms.Label AGENCY_RECEIVING_REPORT_label;
		protected System.Windows.Forms.TextBox AGENCY_RECEIVING_REPORT_textBox;
		private System.Windows.Forms.Button AGENCY_RECEIVING_REPORT_button;
		private System.Windows.Forms.Label AGENCY_TYPE_label;
		protected Controls.LawAgencyTypesComboBox AGENCY_TYPE_ComboBox;
		protected TextBox VED_CODE_textBox;
		private System.Windows.Forms.Label VED_CODE_label;
		private System.Windows.Forms.Label OKTMO_LOC_ID_label;
		protected Controls.OkatoComboBox OKTMO_LOC_ID_ComboBox;
		protected CheckBox DOESNT_CONSOLIDATE_CHILD_checkBox;
		private System.Windows.Forms.Label SHORT_NAME_label;
		protected SpecialTerritorialComboBox SPECIAL_TERRITORIAL_CODE_ComboBox;
		private Label SPECIAL_TERRITORIAL_CODE_label;
		private Button AGENCY_RECEIVING_REPORT_Clean_button;

		private void InitializeComponent()
		{
			this.SHORT_NAME_label = new System.Windows.Forms.Label();
			this.SHORT_NAME_textBox = new System.Windows.Forms.TextBox();
			this.DOESNT_CREATE_CARD_checkBox = new System.Windows.Forms.CheckBox();
			this.DOESNT_SIGN_REPORT_checkBox = new System.Windows.Forms.CheckBox();
			this.AGENCY_RECEIVING_REPORT_label = new System.Windows.Forms.Label();
			this.AGENCY_RECEIVING_REPORT_textBox = new System.Windows.Forms.TextBox();
			this.AGENCY_RECEIVING_REPORT_button = new System.Windows.Forms.Button();
			this.AGENCY_TYPE_label = new System.Windows.Forms.Label();
			this.AGENCY_TYPE_ComboBox = new DatabaseToolSuite.Controls.LawAgencyTypesComboBox();
			this.VED_CODE_textBox = new System.Windows.Forms.TextBox();
			this.VED_CODE_label = new System.Windows.Forms.Label();
			this.OKTMO_LOC_ID_label = new System.Windows.Forms.Label();
			this.OKTMO_LOC_ID_ComboBox = new DatabaseToolSuite.Controls.OkatoComboBox();
			this.DOESNT_CONSOLIDATE_CHILD_checkBox = new System.Windows.Forms.CheckBox();
			this.SPECIAL_TERRITORIAL_CODE_ComboBox = new DatabaseToolSuite.Controls.SpecialTerritorialComboBox();
			this.SPECIAL_TERRITORIAL_CODE_label = new System.Windows.Forms.Label();
			this.AGENCY_RECEIVING_REPORT_Clean_button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(778, 566);
			// 
			// button_OK
			// 
			this.button_OK.Location = new System.Drawing.Point(578, 566);
			// 
			// SHORT_NAME_label
			// 
			this.SHORT_NAME_label.AutoSize = true;
			this.SHORT_NAME_label.Location = new System.Drawing.Point(12, 88);
			this.SHORT_NAME_label.Name = "SHORT_NAME_label";
			this.SHORT_NAME_label.Size = new System.Drawing.Size(259, 25);
			this.SHORT_NAME_label.TabIndex = 3;
			this.SHORT_NAME_label.Text = "Краткое наименование :";
			// 
			// SHORT_NAME_textBox
			// 
			this.SHORT_NAME_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SHORT_NAME_textBox.Location = new System.Drawing.Point(274, 84);
			this.SHORT_NAME_textBox.Name = "SHORT_NAME_textBox";
			this.SHORT_NAME_textBox.Size = new System.Drawing.Size(594, 31);
			this.SHORT_NAME_textBox.TabIndex = 4;
			this.SHORT_NAME_textBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// DOESNT_CREATE_CARD_checkBox
			// 
			this.DOESNT_CREATE_CARD_checkBox.AutoSize = true;
			this.DOESNT_CREATE_CARD_checkBox.Location = new System.Drawing.Point(17, 200);
			this.DOESNT_CREATE_CARD_checkBox.Name = "DOESNT_CREATE_CARD_checkBox";
			this.DOESNT_CREATE_CARD_checkBox.Size = new System.Drawing.Size(254, 29);
			this.DOESNT_CREATE_CARD_checkBox.TabIndex = 5;
			this.DOESNT_CREATE_CARD_checkBox.Text = "Не создаёт карточки ";
			this.DOESNT_CREATE_CARD_checkBox.UseVisualStyleBackColor = true;
			this.DOESNT_CREATE_CARD_checkBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// DOESNT_SIGN_REPORT_checkBox
			// 
			this.DOESNT_SIGN_REPORT_checkBox.AutoSize = true;
			this.DOESNT_SIGN_REPORT_checkBox.Location = new System.Drawing.Point(17, 235);
			this.DOESNT_SIGN_REPORT_checkBox.Name = "DOESNT_SIGN_REPORT_checkBox";
			this.DOESNT_SIGN_REPORT_checkBox.Size = new System.Drawing.Size(263, 29);
			this.DOESNT_SIGN_REPORT_checkBox.TabIndex = 6;
			this.DOESNT_SIGN_REPORT_checkBox.Text = "Не подписывает отчёт";
			this.DOESNT_SIGN_REPORT_checkBox.UseVisualStyleBackColor = true;
			this.DOESNT_SIGN_REPORT_checkBox.CheckStateChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// AGENCY_RECEIVING_REPORT_label
			// 
			this.AGENCY_RECEIVING_REPORT_label.AutoSize = true;
			this.AGENCY_RECEIVING_REPORT_label.Location = new System.Drawing.Point(12, 314);
			this.AGENCY_RECEIVING_REPORT_label.Name = "AGENCY_RECEIVING_REPORT_label";
			this.AGENCY_RECEIVING_REPORT_label.Size = new System.Drawing.Size(193, 25);
			this.AGENCY_RECEIVING_REPORT_label.TabIndex = 7;
			this.AGENCY_RECEIVING_REPORT_label.Text = "Передаёт отчёт в:";
			// 
			// AGENCY_RECEIVING_REPORT_textBox
			// 
			this.AGENCY_RECEIVING_REPORT_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_RECEIVING_REPORT_textBox.Location = new System.Drawing.Point(234, 314);
			this.AGENCY_RECEIVING_REPORT_textBox.Multiline = true;
			this.AGENCY_RECEIVING_REPORT_textBox.Name = "AGENCY_RECEIVING_REPORT_textBox";
			this.AGENCY_RECEIVING_REPORT_textBox.ReadOnly = true;
			this.AGENCY_RECEIVING_REPORT_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.AGENCY_RECEIVING_REPORT_textBox.Size = new System.Drawing.Size(345, 44);
			this.AGENCY_RECEIVING_REPORT_textBox.TabIndex = 8;
			this.AGENCY_RECEIVING_REPORT_textBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// AGENCY_RECEIVING_REPORT_button
			// 
			this.AGENCY_RECEIVING_REPORT_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_RECEIVING_REPORT_button.Location = new System.Drawing.Point(603, 314);
			this.AGENCY_RECEIVING_REPORT_button.Name = "AGENCY_RECEIVING_REPORT_button";
			this.AGENCY_RECEIVING_REPORT_button.Size = new System.Drawing.Size(130, 34);
			this.AGENCY_RECEIVING_REPORT_button.TabIndex = 9;
			this.AGENCY_RECEIVING_REPORT_button.Text = "Обзор...";
			this.AGENCY_RECEIVING_REPORT_button.UseVisualStyleBackColor = true;
			this.AGENCY_RECEIVING_REPORT_button.Click += new System.EventHandler(this.AGENCY_RECEIVING_REPORT_button_Click);
			// 
			// LAW_AGENCY_TYPE_label
			// 
			this.AGENCY_TYPE_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AGENCY_TYPE_label.AutoSize = true;
			this.AGENCY_TYPE_label.Location = new System.Drawing.Point(12, 374);
			this.AGENCY_TYPE_label.Name = "LAW_AGENCY_TYPE_label";
			this.AGENCY_TYPE_label.Size = new System.Drawing.Size(216, 25);
			this.AGENCY_TYPE_label.TabIndex = 10;
			this.AGENCY_TYPE_label.Text = "Тип подразделений:";
			// 
			// LAW_AGENCY_TYPE_ComboBox
			// 
			this.AGENCY_TYPE_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_TYPE_ComboBox.Code = "";
			this.AGENCY_TYPE_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.AGENCY_TYPE_ComboBox.DropDownHeight = 584;
			this.AGENCY_TYPE_ComboBox.DropDownWidth = 80;
			this.AGENCY_TYPE_ComboBox.FormattingEnabled = true;
			this.AGENCY_TYPE_ComboBox.Id = ((long)(-1));
			this.AGENCY_TYPE_ComboBox.IntegralHeight = false;
			this.AGENCY_TYPE_ComboBox.ItemHeight = 29;
			this.AGENCY_TYPE_ComboBox.Location = new System.Drawing.Point(234, 369);
			this.AGENCY_TYPE_ComboBox.MaxDropDownItems = 20;
			this.AGENCY_TYPE_ComboBox.Name = "LAW_AGENCY_TYPE_ComboBox";
			this.AGENCY_TYPE_ComboBox.SelectedItem = null;
			this.AGENCY_TYPE_ComboBox.Size = new System.Drawing.Size(634, 35);
			this.AGENCY_TYPE_ComboBox.TabIndex = 11;
			this.AGENCY_TYPE_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// VED_CODE_textBox
			// 
			this.VED_CODE_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.VED_CODE_textBox.Location = new System.Drawing.Point(234, 415);
			this.VED_CODE_textBox.Name = "VED_CODE_textBox";
			this.VED_CODE_textBox.Size = new System.Drawing.Size(634, 31);
			this.VED_CODE_textBox.TabIndex = 12;
			this.VED_CODE_textBox.TextChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// VED_CODE_label
			// 
			this.VED_CODE_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.VED_CODE_label.AutoSize = true;
			this.VED_CODE_label.Location = new System.Drawing.Point(12, 419);
			this.VED_CODE_label.Name = "VED_CODE_label";
			this.VED_CODE_label.Size = new System.Drawing.Size(219, 25);
			this.VED_CODE_label.TabIndex = 13;
			this.VED_CODE_label.Text = "Ведомственный код:";
			// 
			// OKTMO_LOC_ID_label
			// 
			this.OKTMO_LOC_ID_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OKTMO_LOC_ID_label.AutoSize = true;
			this.OKTMO_LOC_ID_label.Location = new System.Drawing.Point(12, 459);
			this.OKTMO_LOC_ID_label.Name = "OKTMO_LOC_ID_label";
			this.OKTMO_LOC_ID_label.Size = new System.Drawing.Size(372, 25);
			this.OKTMO_LOC_ID_label.TabIndex = 14;
			this.OKTMO_LOC_ID_label.Text = "ОКТМО территории обслуживания :";
			// 
			// OKTMO_LOC_ID_ComboBox
			// 
			this.OKTMO_LOC_ID_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OKTMO_LOC_ID_ComboBox.Code = "";
			this.OKTMO_LOC_ID_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.OKTMO_LOC_ID_ComboBox.DropDownHeight = 584;
			this.OKTMO_LOC_ID_ComboBox.DropDownWidth = 80;
			this.OKTMO_LOC_ID_ComboBox.FormattingEnabled = true;
			this.OKTMO_LOC_ID_ComboBox.Id = ((long)(-1));
			this.OKTMO_LOC_ID_ComboBox.IntegralHeight = false;
			this.OKTMO_LOC_ID_ComboBox.ItemHeight = 29;
			this.OKTMO_LOC_ID_ComboBox.Location = new System.Drawing.Point(392, 455);
			this.OKTMO_LOC_ID_ComboBox.MaxDropDownItems = 20;
			this.OKTMO_LOC_ID_ComboBox.Name = "OKTMO_LOC_ID_ComboBox";
			this.OKTMO_LOC_ID_ComboBox.SelectedItem = null;
			this.OKTMO_LOC_ID_ComboBox.Size = new System.Drawing.Size(477, 35);
			this.OKTMO_LOC_ID_ComboBox.TabIndex = 15;
			this.OKTMO_LOC_ID_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// DOESNT_CONSOLIDATE_CHILD_checkBox
			// 
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.AutoSize = true;
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.Location = new System.Drawing.Point(17, 270);
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.Name = "DOESNT_CONSOLIDATE_CHILD_checkBox";
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.Size = new System.Drawing.Size(323, 29);
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.TabIndex = 16;
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.Text = "Не консолидирует дочерние";
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.UseVisualStyleBackColor = true;
			this.DOESNT_CONSOLIDATE_CHILD_checkBox.CheckedChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// SPECIAL_TERRITORIAL_CODE_ComboBox
			// 
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Code = "";
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.DropDownHeight = 584;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.DropDownWidth = 80;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.FormattingEnabled = true;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Id = ((long)(-1));
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.IntegralHeight = false;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.ItemHeight = 29;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Location = new System.Drawing.Point(234, 159);
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.MaxDropDownItems = 20;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Name = "SPECIAL_TERRITORIAL_CODE_ComboBox";
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.SelectedItem = null;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.Size = new System.Drawing.Size(632, 35);
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.TabIndex = 17;
			this.SPECIAL_TERRITORIAL_CODE_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Controls_ValueChanged);
			// 
			// SPECIAL_TERRITORIAL_CODE_label
			// 
			this.SPECIAL_TERRITORIAL_CODE_label.AutoSize = true;
			this.SPECIAL_TERRITORIAL_CODE_label.Location = new System.Drawing.Point(12, 124);
			this.SPECIAL_TERRITORIAL_CODE_label.Name = "SPECIAL_TERRITORIAL_CODE_label";
			this.SPECIAL_TERRITORIAL_CODE_label.Size = new System.Drawing.Size(463, 25);
			this.SPECIAL_TERRITORIAL_CODE_label.TabIndex = 18;
			this.SPECIAL_TERRITORIAL_CODE_label.Text = "Специализированный территориальный код:";
			// 
			// AGENCY_RECEIVING_REPORT_Clean_button
			// 
			this.AGENCY_RECEIVING_REPORT_Clean_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AGENCY_RECEIVING_REPORT_Clean_button.Location = new System.Drawing.Point(739, 314);
			this.AGENCY_RECEIVING_REPORT_Clean_button.Name = "AGENCY_RECEIVING_REPORT_Clean_button";
			this.AGENCY_RECEIVING_REPORT_Clean_button.Size = new System.Drawing.Size(130, 34);
			this.AGENCY_RECEIVING_REPORT_Clean_button.TabIndex = 19;
			this.AGENCY_RECEIVING_REPORT_Clean_button.Text = "Очистить";
			this.AGENCY_RECEIVING_REPORT_Clean_button.UseVisualStyleBackColor = true;
			this.AGENCY_RECEIVING_REPORT_Clean_button.Click += new System.EventHandler(this.AGENCY_RECEIVING_REPORT_Clean_button_Click);
			// 
			// UrpDialog
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(878, 584);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_Clean_button);
			this.Controls.Add(this.SPECIAL_TERRITORIAL_CODE_label);
			this.Controls.Add(this.SPECIAL_TERRITORIAL_CODE_ComboBox);
			this.Controls.Add(this.DOESNT_CONSOLIDATE_CHILD_checkBox);
			this.Controls.Add(this.OKTMO_LOC_ID_ComboBox);
			this.Controls.Add(this.OKTMO_LOC_ID_label);
			this.Controls.Add(this.VED_CODE_label);
			this.Controls.Add(this.VED_CODE_textBox);
			this.Controls.Add(this.AGENCY_TYPE_ComboBox);
			this.Controls.Add(this.AGENCY_TYPE_label);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_button);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_textBox);
			this.Controls.Add(this.AGENCY_RECEIVING_REPORT_label);
			this.Controls.Add(this.DOESNT_SIGN_REPORT_checkBox);
			this.Controls.Add(this.DOESNT_CREATE_CARD_checkBox);
			this.Controls.Add(this.SHORT_NAME_textBox);
			this.Controls.Add(this.SHORT_NAME_label);
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.emblem32;
			this.MinimumSize = new System.Drawing.Size(580, 640);
			this.Name = "UrpDialog";
			this.Controls.SetChildIndex(this.button_Cancel, 0);
			this.Controls.SetChildIndex(this.button_OK, 0);
			this.Controls.SetChildIndex(this.SHORT_NAME_label, 0);
			this.Controls.SetChildIndex(this.SHORT_NAME_textBox, 0);
			this.Controls.SetChildIndex(this.DOESNT_CREATE_CARD_checkBox, 0);
			this.Controls.SetChildIndex(this.DOESNT_SIGN_REPORT_checkBox, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_label, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_textBox, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_button, 0);
			this.Controls.SetChildIndex(this.AGENCY_TYPE_label, 0);
			this.Controls.SetChildIndex(this.AGENCY_TYPE_ComboBox, 0);
			this.Controls.SetChildIndex(this.VED_CODE_textBox, 0);
			this.Controls.SetChildIndex(this.VED_CODE_label, 0);
			this.Controls.SetChildIndex(this.OKTMO_LOC_ID_label, 0);
			this.Controls.SetChildIndex(this.OKTMO_LOC_ID_ComboBox, 0);
			this.Controls.SetChildIndex(this.DOESNT_CONSOLIDATE_CHILD_checkBox, 0);
			this.Controls.SetChildIndex(this.SPECIAL_TERRITORIAL_CODE_ComboBox, 0);
			this.Controls.SetChildIndex(this.SPECIAL_TERRITORIAL_CODE_label, 0);
			this.Controls.SetChildIndex(this.AGENCY_RECEIVING_REPORT_Clean_button, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void AGENCY_RECEIVING_REPORT_button_Click(object sender, EventArgs e)
		{
			SelectOrganizationDialog dialog = new SelectOrganizationDialog(MasterDataSystem.PROSECUTOR_CODE);

			dialog.LastLockOnlyShow = false;
			dialog.LockShow = false;
			dialog.ReserveShow = false;
			dialog.UnlockShow = true;

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				AgencyReceivingReport = dialog.DataRow.key;
				AGENCY_RECEIVING_REPORT_textBox.Text = dialog.DataRow.name + " (код: " + dialog.DataRow.code + ")";
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
				oldSPECIAL_TERRITORIAL_CODE != SpecialTerritorialCode
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
			AGENCY_RECEIVING_REPORT_textBox.Text = string.Empty;
		}
	}
}