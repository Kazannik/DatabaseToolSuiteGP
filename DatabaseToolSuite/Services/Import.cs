using DatabaseToolSuite.Dialogs;
using DatabaseToolSuite.Repositories._1C;
using DatabaseToolSuite.Repositories.Сourts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositories.MainDataSet;
using static DatabaseToolSuite.Repositories.MainDataSet.gaspsDataTable;
using currentCourtRow = DatabaseToolSuite.Repositories.MainDataSet.DIC_RECORDRow;
using bufferCourtRow = DatabaseToolSuite.Repositories.Сourts.СourtsDataSet.DIC_RECORDRow;
using dicRow = DatabaseToolSuite.Repositories.Сourts.СourtsDataSet.DICRow;

namespace DatabaseToolSuite.Services
{
	static class Import
	{
		/// <summary>
		/// Основное хранилище данных ГАС ПС.
		/// </summary>
		private static readonly EnumerableRowCollection<gaspsRow> GaspsCourtRowCollection = MasterDataSystem.DataSet.gasps
			.Where(e => e.RowState != DataRowState.Deleted &&
			e.authority_id == MasterDataSystem.COURT_CODE)
			.OrderBy(e => e, new GaspsRowComparer());

		/// <summary>
		/// Промежуточное хранилище данных о судах и судебных участках.
		/// </summary>
		private static readonly EnumerableRowCollection<currentCourtRow> CourtRowCollection = MasterDataSystem.DataSet.DIC_RECORD
			.Where(e => e.RowState != DataRowState.Deleted)
			.OrderBy(e => e, new DIC_RECORDDataTable.RowComparer());

		public static void ImportSubdivision(long parentVersion, DateTime beginDate, SubdivisionCollection subdivisions)
		{
			foreach (SubdivisionCollection.Subdivision item in subdivisions.Roots)
			{
				Repositories.MainDataSet.gaspsRow rootRow = MasterDataSystem.CreateNewOrganization(parentVersion, beginDate, item.Name, item.Guid.ToString());
				ImportSubdivision(rootRow, beginDate, item.Child);
			}
		}

		private static void ImportSubdivision(Repositories.MainDataSet.gaspsRow parentRow, DateTime beginDate, IEnumerable<SubdivisionCollection.Subdivision> array)
		{
			foreach (SubdivisionCollection.Subdivision item in array)
			{
				Repositories.MainDataSet.gaspsRow rootRow = MasterDataSystem.CreateNewOrganization(parentRow, beginDate, item.Name, item.Guid.ToString());
				ImportSubdivision(rootRow, beginDate, item.Child);
			}
		}


		public static void ImportTextFile(string fileName)
		{
			StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding(1251));
			Dictionary<string, CodeGroup> dictionary = new Dictionary<string, CodeGroup>();

			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				string[] split = line.Split(';');

				if (dictionary.ContainsKey(split[1]))
				{
					dictionary[split[1]].Add(split[0],
						string.IsNullOrWhiteSpace(split[2]) ? (DateTime?)null : DateTime.Parse(split[2]),
						string.IsNullOrWhiteSpace(split[3]) ? (DateTime?)null : DateTime.Parse(split[3]));
				}
				else
				{
					CodeGroup group = new CodeGroup(split[1], split[0], string.IsNullOrWhiteSpace(split[2]) ? (DateTime?)null : DateTime.Parse(split[2]),
						string.IsNullOrWhiteSpace(split[3]) ? (DateTime?)null : DateTime.Parse(split[3]));
					dictionary.Add(group.Code, group);
				}
			}
			reader.Close();

			int created = 0;
			int edited = 0;
			int removed = 0;

			foreach (CodeGroup group in dictionary.Values)
			{
				bool exists = MasterDataSystem.DataSet.gasps.ExistsCode(group.Code);

				if (exists)
				{
					long version = MasterDataSystem.DataSet.gasps.GetLastVersionOrganizationFromCode(group.Code).version;
					if (group.Count == 1)
					{
						if (!group.Items[0].DateBegin.HasValue &&
							group.Items[0].DateEnd.HasValue)
						{
							MasterDataSystem.RemoveOrganization(version, group.Items[0].DateEnd.Value);
							removed += 1;
						}
						else
						{
							throw new Exception();
						}
					}
					if (group.Count == 2)
					{
						CodeGroup.CodeGroupItem newItem = group.Items[0].DateBegin.HasValue ? group.Items[0] : group.Items[1];
						MasterDataSystem.CreateNewVersionOrganization(version: version, date: newItem.DateBegin.Value, name: newItem.Name);
						edited += 1;
					}
				}
				else
				{
					if (group.Count == 1)
					{
						CreateNewOrganizationDialog dialog = new CreateNewOrganizationDialog(group.Items[0].Name, group.Code, group.Items[0].DateBegin.Value);

						if (dialog.ShowDialog() == DialogResult.OK)
						{
							MasterDataSystem.CreateNewOrganization(
								name: dialog.OrganizationName,
								okato: dialog.OkatoCode,
								authorityId: dialog.Authority ?? 0,
								code: dialog.Code,
								ownerKey: dialog.OrganizationOwner,
								dateBegin: dialog.BeginDate,
								dateEnd: MasterDataSystem.MAX_DATE,
								courtTypeId: dialog.CourtType);

							created += 1;
						}
					}
				}
			}

			MessageBox.Show("Импорт данных из текстового файла завершен." + Environment.NewLine +
				string.Format("Создано записей: {0}", created) + Environment.NewLine +
				string.Format("Изменен записей: {0}", edited) + Environment.NewLine +
				string.Format("Удалено записей: {0}", removed),
				"Импорт данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

		}

		/// <summary>
		/// Импорт справочников судов и судебных участков.
		/// </summary>
		/// <param name="fileName"></param>
		public static void ImportCourtsDataXmlFile(string fileName)
		{
			СourtsDataSet bufferDataSet = new СourtsDataSet();
			bufferDataSet.ReadXml(fileName);			
			
			foreach (bufferCourtRow bufferRow in bufferDataSet.DIC_RECORD)
			{
				if (!MasterDataSystem.DataSet.ExistsCourts(bufferRow.VRN))
				{
					if (!MasterDataSystem.DataSet.ExistsDicCourts(bufferRow.DIC_Id))
					{
						dicRow dicRow = bufferDataSet.DIC.Get(bufferRow.DIC_Id);
						MasterDataSystem.DataSet.DIC.Create(
							dicId: dicRow.DIC_Id,
							outputDate: Utils.Database.Parse(dicRow.OUTPUTDATE, DateTime.Today),
							vrn: dicRow.VRN
							);
					}
					MasterDataSystem.DataSet.DIC_RECORD.Create(
						dicId: bufferRow.DIC_Id,
						vrnCls: bufferRow.VRN_CLS,
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
						isActive: !bufferRow.IsISACTIVENull() && bufferRow.ISACTIVE == "1"
						);
				}
				else
				{
					currentCourtRow currentRow = MasterDataSystem.DataSet.DIC_RECORD.Get(bufferRow.VRN);
					if (currentRow.DATE_END.Date != (bufferRow.IsDATE_ENDNull() || 
						string.IsNullOrWhiteSpace(bufferRow.DATE_END) ? 
						MasterDataSystem.MAX_DATE : 
						Utils.Database.Parse(bufferRow.DATE_END, MasterDataSystem.MAX_DATE).Date))
					{
						Debug.WriteLine(currentRow.gasps_version);
					}

					
				}
			}



			MasterDataSystem.DataSet.DIC_RECORD.CorrectedDates();
			IEnumerable<GaspsEntity> correctedGaspsDates = MasterDataSystem.DataSet.gasps.CorrectedDates();

			foreach (GaspsEntity entity in correctedGaspsDates)
			{
				if (!MasterDataSystem.DataSet.DIC_RECORD
					.SetVersion(entity.Code, entity.DateBeg, entity.Version))
				{
					//if (entity.DateEnd.Date > DateTime.Today.Date)
					//	Debug.WriteLine("Not fount");
				}				
			}

			MessageBox.Show("Импорт данных из текстового файла завершен.");
			//	string.Format("Создано записей: {0}", created) + Environment.NewLine +
			//	string.Format("Изменен записей: {0}", edited) + Environment.NewLine +
			//	string.Format("Удалено записей: {0}", removed),
			//	"Импорт данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}


		




		private class CodeGroup
		{

			private readonly List<CodeGroupItem> items;

			public CodeGroup(string code, string name, DateTime? dateBegin, DateTime? dateEnd)
			{
				items = new List<CodeGroupItem>();
				Code = code;
				CodeGroupItem newItem = new CodeGroupItem(name, dateBegin, dateEnd);
				items.Add(newItem);
			}

			public void Add(string name, DateTime? dateBegin, DateTime? dateEnd)
			{
				CodeGroupItem newItem = new CodeGroupItem(name, dateBegin, dateEnd);
				items.Add(newItem);
			}

			public CodeGroupItem[] Items
			{
				get { return items.ToArray(); }
			}

			public int Count { get { return items.Count; } }

			public string Code { get; private set; }

			public class CodeGroupItem
			{
				public CodeGroupItem(string name, DateTime? dateBegin, DateTime? dateEnd)
				{
					Name = name;
					DateBegin = dateBegin;
					DateEnd = dateEnd;
				}

				public string Name { get; private set; }

				public DateTime? DateBegin { get; private set; }

				public DateTime? DateEnd { get; private set; }
			}
		}
	}
}
