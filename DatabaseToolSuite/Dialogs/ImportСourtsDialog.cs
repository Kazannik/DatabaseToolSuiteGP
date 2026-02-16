using DatabaseToolSuite.Repositories.Сourts;
using DatabaseToolSuite.Services;
using DatabaseToolSuite.Services.Courts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositories.MainDataSet;
using bufferCourtRow = DatabaseToolSuite.Repositories.Сourts.СourtsDataSet.DIC_RECORDRow;
using currentCourtRow = DatabaseToolSuite.Repositories.MainDataSet.DIC_RECORDRow;
using dicRow = DatabaseToolSuite.Repositories.Сourts.СourtsDataSet.DICRow;

namespace DatabaseToolSuite.Dialogs
{
	internal class ImportСourtsDialog : DialogBase
	{
		private readonly CourtsCollection _courtsCollection;
		/// <summary>
		/// Записи для добавления.
		/// </summary>
		private readonly List<string> _addingCourtsCode;
		/// <summary>
		/// Записи для блокировки.
		/// </summary>
		private readonly List<long> _removedCourtsVersion;
		private readonly List<(string vrn, long version)> _notNeedEdit;
		private readonly List<CourtEntity> _skipCourtEntity;
		/// <summary>
		/// Записи для корректировки.
		/// </summary>
		private readonly List<CourtEntity> _notSkipCourtEntity;

		private TextBox consoleTextBox;
		private Button converterButton;
		private Label label1;
		private DateTimePicker editedDateTimePicker;
		private Button openFileButton;

		/// <summary>
		/// Дата внесения автоматизированных 
		/// </summary>
		public DateTime EditedDate => editedDateTimePicker.Value.Date;

		public ImportСourtsDialog() : base()
		{
			this.InitializeComponent();

			this.ApplyButtonEnabled = false;
			this.ApplyButtonVisible = true;

			this.OkButtonEnabled = false;
			this.OkButtonVisible = false;

			_courtsCollection = new CourtsCollection();
			EnumerableRowCollection<gaspsRow> gaspsRows = MasterDataSystem.DataSet.gasps
				.Where(e => e.RowState != DataRowState.Deleted &&
				e.authority_id == MasterDataSystem.COURT_CODE);

			foreach (gaspsRow row in gaspsRows)
			{
				_courtsCollection.Add(row.code, row.date_beg.Date, row.date_end.Date, row.version);
			}

			Console(string.Format("В справочнике ГАС ПС обнаружено {0:#,#} записей о судах и судебных участках.", _courtsCollection.Count));
			_addingCourtsCode = new List<string>();
			_removedCourtsVersion = new List<long>();
			_notNeedEdit = new List<(string vrn, long version)>();
			_skipCourtEntity = new List<CourtEntity>();
			_notSkipCourtEntity = new List<CourtEntity>();
		}

		private void InitializeComponent()
		{
			this.openFileButton = new System.Windows.Forms.Button();
			this.consoleTextBox = new System.Windows.Forms.TextBox();
			this.converterButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.editedDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// openFileButton
			// 
			this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openFileButton.Location = new System.Drawing.Point(518, 64);
			this.openFileButton.Name = "openFileButton";
			this.openFileButton.Size = new System.Drawing.Size(194, 44);
			this.openFileButton.TabIndex = 3;
			this.openFileButton.Text = "Обзор...";
			this.openFileButton.UseVisualStyleBackColor = true;
			this.openFileButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// consoleTextBox
			// 
			this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.consoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.consoleTextBox.Location = new System.Drawing.Point(4, 164);
			this.consoleTextBox.Multiline = true;
			this.consoleTextBox.Name = "consoleTextBox";
			this.consoleTextBox.ReadOnly = true;
			this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.consoleTextBox.Size = new System.Drawing.Size(715, 318);
			this.consoleTextBox.TabIndex = 4;
			this.consoleTextBox.VisibleChanged += new System.EventHandler(this.ConsoleTextBox_VisibleChanged);
			// 
			// converterButton
			// 
			this.converterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.converterButton.Enabled = false;
			this.converterButton.Location = new System.Drawing.Point(518, 114);
			this.converterButton.Name = "converterButton";
			this.converterButton.Size = new System.Drawing.Size(192, 44);
			this.converterButton.TabIndex = 5;
			this.converterButton.Text = "Конвертировать";
			this.converterButton.UseVisualStyleBackColor = true;
			this.converterButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(237, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Дата внесения изменений:";
			// 
			// editedDateTimePicker
			// 
			this.editedDateTimePicker.Location = new System.Drawing.Point(12, 97);
			this.editedDateTimePicker.Name = "editedDateTimePicker";
			this.editedDateTimePicker.Size = new System.Drawing.Size(189, 27);
			this.editedDateTimePicker.TabIndex = 7;
			// 
			// ImportСourtsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.ClientSize = new System.Drawing.Size(722, 533);
			this.Controls.Add(this.editedDateTimePicker);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.converterButton);
			this.Controls.Add(this.consoleTextBox);
			this.Controls.Add(this.openFileButton);
			this.DialogCaption = "Импорт справочников судов и судебных участков";
			this.DialogCaptionImage = global::DatabaseToolSuite.Properties.Resources.vsrf_emblem_32;
			this.Name = "ImportСourtsDialog";
			this.Controls.SetChildIndex(this.openFileButton, 0);
			this.Controls.SetChildIndex(this.consoleTextBox, 0);
			this.Controls.SetChildIndex(this.converterButton, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.editedDateTimePicker, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				ReadXmlFile(openFileDialog.FileName);
			}
		}

		private void ReadXmlFile(string fileName)
		{
			СourtsDataSet bufferDataSet = new СourtsDataSet();			
			bufferDataSet.ReadXml(fileName);
			int count = _courtsCollection.Count;

			if (count <= 0) 
			{
				DateTime outDate = Utils.Database.Parse(bufferDataSet.DIC.Last().OUTPUTDATE, DateTime.Today).Date;
				editedDateTimePicker.Value = outDate;
			}
			foreach (bufferCourtRow bufferRow in bufferDataSet.DIC_RECORD)
			{
				_courtsCollection.Add(bufferRow.VNKOD,
					Utils.Database.Parse(bufferRow.DATE_BEG, MasterDataSystem.MIN_DATE).Date,
					bufferRow.IsDATE_ENDNull() || string.IsNullOrWhiteSpace(bufferRow.DATE_END) ? MasterDataSystem.MAX_DATE : Utils.Database.Parse(bufferRow.DATE_END, MasterDataSystem.MAX_DATE).Date,
					bufferRow.VRN,
					bufferRow.VRN_CLS == 102);

				dicRow dicRow = bufferDataSet.DIC.Get(bufferRow.DIC_Id);

				MasterDataSystem.CreateCourt(
					dicId: dicRow.DIC_Id,
					outputDate: Utils.Database.Parse(dicRow.OUTPUTDATE, DateTime.Today),
					vers: dicRow.VRN,
					dic_id: bufferRow.DIC_Id,
					vrn_cls: bufferRow.VRN_CLS,
					znachatr: bufferRow.ZNACHATR,
					vnkod: bufferRow.VNKOD,
					tip: long.TryParse(bufferRow.TIP, out long tip) ? tip : 0,
					adress: bufferRow.ADRESS,
					upkod: bufferRow.UPKOD,
					dateBeg: Utils.Database.Parse(bufferRow.DATE_BEG, MasterDataSystem.MIN_DATE),
					dateEnd: bufferRow.IsDATE_ENDNull() || string.IsNullOrWhiteSpace(bufferRow.DATE_END) ? MasterDataSystem.MAX_DATE : Utils.Database.Parse(bufferRow.DATE_END, MasterDataSystem.MAX_DATE),
					prim: bufferRow.PRIM,
					vrn: bufferRow.VRN,
					faktaddress: bufferRow.FAKTADDRESSES,
					isActive: !bufferRow.IsISACTIVENull() && bufferRow.ISACTIVE == "1");
			}

			Console(string.Format("В справочник ГАС ПС добавлено {0:#,#} записей о судах и судебных участках.", _courtsCollection.Count - count));
			if (_courtsCollection.IsFullCourtsCollection())
			{
				Console("Справочник готов к конвертированию.");
				converterButton.Enabled = true;
			}
			else
			{
				Console("Справочник не готов к конвертированию. В него необходимо загрузить все типы данных.");
				converterButton.Enabled = false;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			GetAddingData();
			GetRemovedData();
			GetNotNeedToEdit();
			GetSkipCourtEntity();
			GetNotSkipCourtEntity();

			this.ApplyButtonEnabled = true;
		}

		protected override void OnApply(EventArgs e)
		{
			FixData();
			base.OnApply(e);
		}

		private void GetAddingData()
		{
			_addingCourtsCode.Clear();
			IEnumerable<string> codeArray = _courtsCollection.GetCourstOnlyCode();
			_addingCourtsCode.AddRange(codeArray);
			Console(string.Format("В справочнике судов и судебных участков обнаружено {0:#,#} новых записей.", _addingCourtsCode.Count));
		}

		private void GetRemovedData()
		{
			_removedCourtsVersion.Clear();
			IEnumerable<long> versionsArray = _courtsCollection.GetGaspsOnlyRowVersion();

			_removedCourtsVersion.AddRange(
				versionsArray.Join(MasterDataSystem.DataSet.gasps, version => version, row => row.version, (version, gasps) => new { gasps })
				.Where(row => row.gasps.date_end.Date > DateTime.Today)
				.Select(row => row.gasps.version));

			Console(string.Format("В справочнике ГАС ПС обнаружены {0:#,#} записей о судах и судебных участках, подлежащих блокировке.", _removedCourtsVersion.Count));
		}

		private void GetNotNeedToEdit()
		{
			_notNeedEdit.Clear();
			IEnumerable<(string vrn, long version)> correctArray = _courtsCollection.GetCorrectCodeDictionary();

			_notNeedEdit.AddRange(correctArray);
			Console(string.Format("В справочнике судов и судебных участков обнаружено {0:#,#} не требующих корректировки записей, а только проверки связей.", _notNeedEdit.Count()));
		}

		private void GetSkipCourtEntity()
		{
			_skipCourtEntity.Clear();
			IEnumerable<CourtEntity> skipArray = _courtsCollection.GetSkipCourtEntity(EditedDate);

			_skipCourtEntity.AddRange(skipArray);
			Console(string.Format("В справочнике судов и судебных участков обнаружено {0:#,#} не требующих корректировки записей. Проверка связей слишком затратна.", _skipCourtEntity.Count()));
		}

		private void GetNotSkipCourtEntity()
		{
			_notSkipCourtEntity.Clear();
			IEnumerable<CourtEntity> notSkipArray = _courtsCollection.GetNotSkipCourtEntity(EditedDate);

			_notSkipCourtEntity.AddRange(notSkipArray);
			Console(string.Format("В справочнике судов и судебных участков обнаружено {0:#,#} требующих обязательной корректировки записей. Проверка связей слишком затратна.", _notSkipCourtEntity.Count()));
		}

		private void FixData()
		{
			foreach (long version in _removedCourtsVersion)
			{
				MasterDataSystem.RemoveOrganization(version: version, date: EditedDate);
			}

			foreach (CourtEntity court in _notSkipCourtEntity)
			{
				DateTime courtMaxDateEnd = court.CourtMaxDateEnd.Date;
				DateTime gaspsMaxDateEnd = court.GaspsMaxDateEnd.Date;

				if (courtMaxDateEnd < gaspsMaxDateEnd)
				{
					foreach (long version in court.Versions())
					{
						gaspsRow gasps = MasterDataSystem.DataSet.gasps.Get(version);
						if (gasps.date_end > courtMaxDateEnd)
						{
							MasterDataSystem.RemoveOrganization(version: version, date: courtMaxDateEnd);
							Console(string.Format("Запись {0} заблокирована.", version));
						}
					}
				}
				else
				{
					foreach (string vrn in court.Vrns())
					{
						currentCourtRow courtRaw = MasterDataSystem.DataSet.DIC_RECORD.Get(vrn);
						if (courtRaw.ISACTIVE)
						{
							long version = court.GetLastVersion();
							DateTime date = MasterDataSystem.DataSet.gasps.Get(version).date_end;

							if (date < courtRaw.DATE_BEG.Date) date = courtRaw.DATE_BEG.Date;

							MasterDataSystem.CreateNewVersionOrganization(
								version: version,
								date: date,
								name: courtRaw.ZNACHATR,
								okato: courtRaw.okatoRow.code,
								authorityId: MasterDataSystem.COURT_CODE,
								ownerKey: 0,
								courtTypeId: courtRaw.TIP);
							Console(string.Format("Создана новая версия записи {0}.", version));

						}
					}
				}
			}
			
			foreach (string vrn in _addingCourtsCode)
			{
				currentCourtRow courtRaw = MasterDataSystem.DataSet.DIC_RECORD.GetOfVnkod(vrn);
				if (courtRaw.ISACTIVE)
				{
					long version = MasterDataSystem.CreateNewOrganization(
						name: courtRaw.ZNACHATR,
						okato: courtRaw.okatoRow.code,
						authorityId: MasterDataSystem.COURT_CODE,
						code: courtRaw.VNKOD,
						ownerKey: 0,
						dateBegin: courtRaw.DATE_BEG.Date,
						dateEnd: courtRaw.DATE_END.Date,
						courtTypeId: courtRaw.TIP).version;
					Console(string.Format("Создана новая запись {0}.", version));
				}
			}
			Console("Внесение данных завершено!");
			ApplyButtonEnabled = false;
		}


		private void Console(string text) => consoleTextBox.AppendText(text + Environment.NewLine);

		private void ConsoleTextBox_VisibleChanged(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			if (textBox.Visible)
			{
				textBox.SelectionStart = textBox.TextLength;
				textBox.ScrollToCaret();
			}
		}
	}
}
