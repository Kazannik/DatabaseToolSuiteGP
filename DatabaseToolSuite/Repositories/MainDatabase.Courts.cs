// Ignore Spelling: oktmo vrn DIC

using DatabaseToolSuite.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		public partial class DIC_RECORDDataTable
		{
			public bool Exists(string vrn)
			{
				return (from item in this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
						where item.VRN == vrn
						select item).Any();
			}

			public DIC_RECORDRow Get(string vrn)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted)
					.Last(x => x.VRN == vrn);
			}

			public bool Exists(string vnkod, DateTime dateBeg)
			{
				return (from item in this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
						where item.VNKOD == vnkod && item.DATE_BEG == dateBeg
						select item).Any();
			}

			public DIC_RECORDRow Get(string vnkod, DateTime dateBeg)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted)
					.Last(x => x.VNKOD == vnkod && x.DATE_BEG == dateBeg);
			}

			public DIC_RECORDRow GetOfVnkod(string vnkod)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted && x.ISACTIVE)
					.OrderBy(x => x.DATE_END)
					.Last(x => x.VNKOD == vnkod);
			}

			private IEnumerable<string> GetDuplicatesCode()
			{
				return this.GroupBy(x => x.VNKOD)
					.Where(g => g.Count() > 1)
					.Select(g => g.Key)
					.ToList();
			}

			private EnumerableRowCollection<DIC_RECORDRow> GetDuplicatesRows()
			{
				IEnumerable<string> kods = GetDuplicatesCode();
				return this.AsEnumerable()
					   .Where(r => kods.Contains(r.VNKOD))
					   .OrderBy(e => e, new RowComparer());
			}

			private EnumerableRowCollection<DIC_RECORDRow> GetRows(string vnkod)
			{
				return this.AsEnumerable()
					   .Where(r => r.VNKOD.Equals(vnkod, StringComparison.CurrentCultureIgnoreCase))
					   .OrderBy(e => e, new RowComparer());
			}

			/// <summary>
			/// Создание записи о суде в буферной таблице (DIC_RECORD)
			/// </summary>
			/// <param name="dicId">Индекс записи в  таблице выгрузки (DIC)</param>
			/// <param name="vrnCls">Версия выгрузки</param>
			/// <param name="znachatr">Наименование суда</param>
			/// <param name="vnkod">Код подразделения</param>
			/// <param name="tip">Тип суда</param>
			/// <param name="adress">Адрес расположения суда</param>
			/// <param name="upkod">Индекс справочника SSRF</param>
			/// <param name="dateBeg">Дата введения в действие</param>
			/// <param name="dateEnd">Дата введения в действие</param>
			/// <param name="prim">Ссылка на сайт суда</param>
			/// <param name="vrn">Уникальны код</param>
			/// <param name="faktaddress">Фактический адрес местонахождения</param>
			/// <param name="isActive">Признак активности подразделения</param>
			/// <returns></returns>
			public DIC_RECORDRow Create(
				int dicId,          // Индекс записи в  таблице выгрузки
				int vrnCls,         // Версия выгрузки
				string znachatr,    // Наименование суда
				string vnkod,       // Код подразделения
				long tip,           // Тип суда
				string adress,      // Адрес расположения суда
				string upkod,       // Индекс справочника SSRF
				DateTime dateBeg,   // Дата введения в действие
				DateTime dateEnd,   // Дата прекращения действия
				string prim,        // Ссылка на сайт суда
				string vrn,         // Уникальны код
				string faktaddress, // Фактический адрес местонахождения
				bool isActive       // Признак активности подразделения
				)
			{
				object[] values = new object[13];
				values[0] = dicId;        // Индекс записи в  таблице выгрузки
				values[1] = vrnCls;       // Версия выгрузки
				values[2] = znachatr;     // Наименование суда
				values[3] = vnkod;        // Код подразделения
				values[4] = tip;          // Тип суда
				values[5] = adress;       // Адрес расположения суда
				values[6] = upkod;        // Индекс справочника SSRF
				values[7] = dateBeg;      // Дата введения в действие
				values[8] = dateEnd;      // Дата прекращения действия
				values[9] = prim;         // Ссылка на сайт суда
				values[10] = vrn;         // Уникальны код
				values[11] = faktaddress; // Фактический адрес местонахождения
				values[12] = isActive;    // Признак активности подразделения

				return (DIC_RECORDRow)Rows.Add(values);
			}

			public void Remove(string vrn)
			{
				DataRow row = Get(vrn);
				row.Delete();
			}

			public void CorrectedDates()
			{
				IEnumerable<string> codesCollection = MasterDataSystem.DataSet.DIC_RECORD.GetDuplicatesCode();
				foreach (string vnkod in codesCollection)
				{
					MasterDataSystem.DataSet.DIC_RECORD.CorrectedDates(vnkod);
				}
			}

			public bool SetVersion(string code, DateTime dateBeg, long version)
			{
				if (Exists(vnkod:  code, dateBeg: dateBeg))
				{
					DIC_RECORDRow row = Get(vnkod: code, dateBeg: dateBeg);
					row.gasps_version = version;
					return true;
				}
				else 
					return false;
			}

			private void CorrectedDates(string vnkod)
			{
				List<DIC_RECORDRow> rows = new List<DIC_RECORDRow>(GetRows(vnkod: vnkod));
				for (int i = rows.Count-1 ; i > 0; i--)
				{
					CorrectedDates(rows[i], rows[i - 1]);
				}

				for (int i = rows.Count - 1; i > 0; i--)
				{
					RemoveDuplicates(rows[i], rows[i - 1]);
				}
			}

			private void CorrectedDates(DIC_RECORDRow currentRow, DIC_RECORDRow oldRow)
			{
				if (oldRow.DATE_END.Date.AddDays(1).Date == currentRow.DATE_BEG.Date)
					oldRow.DATE_END = currentRow.DATE_BEG;
				else if (oldRow.DATE_END.Date != MasterDataSystem.MAX_DATE &&
					oldRow.DATE_BEG == currentRow.DATE_BEG &&
					oldRow.DATE_END.Date > currentRow.DATE_BEG.Date)
				{
					currentRow.DATE_BEG = oldRow.DATE_END.Date.AddDays(1);
					oldRow.DATE_END = currentRow.DATE_BEG;
				}
				else if (oldRow.DATE_END.Date == MasterDataSystem.MAX_DATE)
				{
					oldRow.DATE_END = currentRow.DATE_BEG;
				}
				else if (oldRow.DATE_END.Date > currentRow.DATE_BEG.Date)
				{
					currentRow.DATE_BEG = oldRow.DATE_END.Date.AddDays(1);
					oldRow.DATE_END = currentRow.DATE_BEG;
				}
#if DEBUG 
				else
					Debug.WriteLine(string.Format( "beg: {0}, end: {1}/ beg: {2}, end: {2};", oldRow.DATE_BEG, oldRow.DATE_END, currentRow.DATE_BEG, currentRow.DATE_END));
#endif
			}

			private void RemoveDuplicates(DIC_RECORDRow currentRow, DIC_RECORDRow oldRow)
			{
				if (oldRow.DATE_BEG.Date == oldRow.DATE_END.Date &&
					oldRow.DATE_BEG == currentRow.DATE_BEG &&
					!oldRow.ISACTIVE)
					Remove(oldRow.VRN);				
			}

			public class RowComparer : IComparer, IComparer<DIC_RECORDRow>
			{
				public int Compare(object x, object y)
				{
					DIC_RECORDRow xRow = (DIC_RECORDRow)x;
					DIC_RECORDRow yRow = (DIC_RECORDRow)y;

					int compare = string.Compare(xRow.VNKOD, yRow.VNKOD);
					if (compare == 0) compare = DateTime.Compare(xRow.DATE_BEG, yRow.DATE_BEG);
					if (compare == 0) compare = DateTime.Compare(xRow.DATE_END, yRow.DATE_END);
					return compare;
				}

				int IComparer<DIC_RECORDRow>.Compare(DIC_RECORDRow x, DIC_RECORDRow y)
				{
					return Compare(x, y);
				}
			}
		}

		public partial class DICDataTable
		{
			public bool Exists(int dicId)
			{
				return (from item in this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
						where item.DIC_Id == dicId
						select item).Any();
			}

			public DICRow Get(int dicId)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted)
					.Last(x => x.DIC_Id == dicId);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="dicId">Индекс записи</param>
			/// <param name="outputDate">Дата выгрузки</param>
			/// <param name="vrn">Версия выгрузки</param>
			/// <returns></returns>
			public DICRow Create(
				int dicId,           // Индекс записи
				DateTime outputDate, // Дата выгрузки
				int vrn              // Версия выгрузки
				)
			{
				object[] values = new object[3];
				values[0] = dicId;      // Индекс записи
				values[1] = outputDate; // Версия выгрузки
				values[2] = vrn;        // Версия выгрузки

				return (DICRow)Rows.Add(values);
			}

			public void Remove(int dicId)
			{
				DataRow row = Get(dicId);
				row.Delete();
			}
		}		
	}
}

// VRN_CLS			Версия выгрузки						int
// ZNACHATR			Наименование суда					string
// VNKOD			Код подразделения					string
// TIP				Тип суда							long
// ADRESS			Адрес расположения суда				string
// UPKOD			Индекс справочника SSRF				string
// DATE_BEG			Дата введения в действие			dateTime
// DATE_END			Дата прекращения действия			dateTime
// PRIM				Ссылка на сайт суда					string
// VRN				Уникальны код						string
// FAKTADDRESSES	Фактический адрес местонахождения	string
// ISACTIVE			Признак активности подразделения	boolean
