using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseToolSuite.Services.Courts
{
	internal class CourtsCollection: Dictionary<string, CourtEntity>
	{
		public bool IsFullCourtsCollection()
		{
			return Values.Any(x => x.IsMs) && Values.Any(x => x.IsNotMs);
		}

		/// <summary>
		/// Коллекция ключей, которые имеются только базе данных ГАС ПС (соответственно, подлежат блокировке).
		/// </summary>
		/// <returns></returns>
		public IEnumerable<long> GetGaspsOnlyRowVersion()
		{
			return Values
				.Where(x => x.IsGaspsOnly)
				.SelectMany(x => x.Versions());
		}

		/// <summary>
		/// Коллекция ключей, которые имеются только базе данных судов.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> GetCourstOnlyVrn()
		{
			return Values
				.Where(x => x.IsCourtsOnly)
				.SelectMany(x => x.Vrns());
		}

		/// <summary>
		/// Коллекция кодов, которые имеются только базе данных судов.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> GetCourstOnlyCode()
		{
			return Values
				.Where(x => x.IsCourtsOnly)
				.Select(x => x.Code);
		}

		/// <summary>
		/// Коллекция корректных связок кодов, которые можно сразу вносить в ВД (DIC_RECORD.Version).
		/// </summary>
		/// <returns></returns>
		public IEnumerable<(string, long)> GetCorrectCodeDictionary()
		{
			return Values
				.Where(x => x.IsNotNeedToEdit)
				.SelectMany(x => x.GetCorrectCodeDictionary());
		}


		public IEnumerable<CourtEntity> GetNeedToEditCourtEntity()
		{
			return Values
				.Where(x => x.IsNeedToEdit);
		}

		/// <summary>
		/// Коллекция записей, максимальные даты которых больше текущей или меньше текущей даты.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<CourtEntity> GetSkipCourtEntity(DateTime editedDate)
		{
			return Values
				.Where(x => x.IsMix && 
				((x.GaspsMaxDateEnd > editedDate && x.CourtMaxDateEnd > editedDate) ||
				(x.GaspsMaxDateEnd < editedDate && x.CourtMaxDateEnd < editedDate)));
		}

		/// <summary>
		/// Коллекция записей, в которых только одна максимальная дата больше текущей или меньше текущей даты.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<CourtEntity> GetNotSkipCourtEntity(DateTime editedDate)
		{
			return Values
				.Where(x => x.IsMix &&
				((x.GaspsMaxDateEnd > editedDate && x.CourtMaxDateEnd < editedDate) ||
				(x.GaspsMaxDateEnd < editedDate && x.CourtMaxDateEnd > editedDate)));
		}

		public new CourtEntity this[string code] => base[key: code];

		private new void Add(string code, CourtEntity court)
		{
			base.Add(key: code, value: court);
		}

		public void Add(CourtEntity court)
		{
			Add(code: court.Code, court: court);
		}

		public void Add(string code, DateTime dateBegin, DateTime dateEnd, long version)
		{
			if (this.ContainsKey(code)) 
			{
				CourtEntity court = this[code];
				court.Add(dateBegin: dateBegin, dateEnd: dateEnd, version: version);
			}
			else
			{
				CourtEntity court = new CourtEntity(code);
				court.Add(dateBegin:  dateBegin, dateEnd: dateEnd, version: version);
				Add(court: court);
			}
		}

		public void Add(string code, DateTime dateBegin, DateTime dateEnd, string vrn, bool isMs)
		{
			if (this.ContainsKey(code))
			{
				CourtEntity court = this[code];
				court.Add(dateBegin: dateBegin, dateEnd: dateEnd, vrn: vrn, isMs: isMs);
			}
			else
			{
				CourtEntity court = new CourtEntity(code);
				court.Add(dateBegin: dateBegin, dateEnd: dateEnd, vrn: vrn, isMs: isMs);
				Add(court: court);
			}
		}
	}
}
