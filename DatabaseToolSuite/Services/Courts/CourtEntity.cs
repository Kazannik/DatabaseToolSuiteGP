using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DatabaseToolSuite.Services.Courts
{
	internal class CourtEntity
	{
		private readonly List<DateEntity> entities;

		/// <summary>
		/// Мировой суд.
		/// </summary>
		public bool IsMs => entities.Any(e => e.IsMS.HasValue && e.IsMS.Value == true);
		/// <summary>
		/// Федеральный суд.
		/// </summary>
		public bool IsNotMs => entities.Any(e => e.IsMS.HasValue && e.IsMS.Value == false);
		/// <summary>
		/// Имеются записи о судах.
		/// </summary>
		public bool IsCourts => !entities.Any(e => !e.IsGasps);
		public bool IsGaspsOnly => !entities.Any(e => e.IsMS.HasValue) && entities.Any(e => e.IsGasps);
		public bool IsCourtsOnly => !entities.Any(e => e.IsGasps);
		public bool IsMix => entities.Any(e => e.IsGasps) && entities.Any(e => !e.IsGasps);
		public DateTime GaspsMaxDateEnd =>  entities.Where(e => e.IsGasps).Max(e => e.DateEnd);
		public DateTime CourtMaxDateEnd => entities.Where(e => !e.IsGasps).Max(e => e.DateEnd);

		public CourtEntity(string code)
		{
			entities = new List<DateEntity>();
			Code = code;
		}

		public string Code { get; }

		public void Add(DateTime dateBegin, DateTime dateEnd, long version)
		{
			entities.Add(new DateEntity(dateBegin: dateBegin, dateEnd: dateEnd, version: version));
		}

		public void Add(DateTime dateBegin, DateTime dateEnd, string vrn, bool isMs)
		{
			entities.Add(new DateEntity(dateBegin: dateBegin, dateEnd: dateEnd, vrn: vrn, isMs: isMs));
		}


		public long GetLastVersion()
		{
			return (long)entities.Where(x => x.IsGasps)
				.OrderBy(x=> x, new DateEntityComparer())
				.LastOrDefault()?.Version;
		}

		public IEnumerable<long> Versions()
		{
			return entities.Where(x => x.IsGasps).Select(x => (long)x.Version);
		}

		public IEnumerable<string> Vrns()
		{
			return entities.Where(x => !x.IsGasps).Select(x => (string)x.Version);
		}

		/// <summary>
		/// Коды не требуют корректировки.
		/// </summary>
		public bool IsNotNeedToEdit
		{
			get
			{
				if ((entities.Count % 2) == 0)
				{
					entities.Sort(new DateEntityComparer());
					for (int i = 0; i < entities.Count; i = i + 2)
					{
						if (entities[i].IsGasps == entities[i + 1].IsGasps ||
							entities[i] != entities[i + 1])
						{
							return false;
						}
					}
					return true;
				}
				return false;
			}
		}

		public bool IsNeedToEdit => !IsGaspsOnly && !IsCourtsOnly && !IsNotNeedToEdit;

		/// <summary>
		/// Коллекция корректных кодов, которые необходимо сразу включить в базу.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<(string, long)> GetCorrectCodeDictionary()
		{
			List<(string, long)> result = new List<(string, long)>();
			if (IsNotNeedToEdit)
			{
				entities.Sort(new DateEntityComparer());
				for (int i = 0; i < entities.Count; i = i + 2)
				{
					result.Add((entities[i + 1].Version as string, (long)entities[i].Version));					
				}
			}
			return result;
		}

		public void FixData()
		{
			if (IsNeedToEdit)
			{
				Debug.WriteLine(string.Format("Code: {0}", Code));
				entities.Sort(new DateEntityComparer());

				foreach (var entity in entities)
				{
					Debug.WriteLine(string.Format("{0}:{1} - {2}", entity.IsGasps ? "GASPS" : "COURT", entity.DateBegin.ToShortDateString(), entity.DateEnd.ToShortDateString()));
				}

				//for (int i = entities.Count - 1; i >= 0; i--)
				//{
				//	Debug.WriteLine(string.Format("{0}:{1} - {2}", entities[i].IsGasps ? "GASPS": "COURT", entities[i].DateBegin.ToShortDateString(), entities[i].DateEnd.ToShortDateString()));
				//}
			}
		}

		public class DateEntity : IDatesEntity
		{
			public DateEntity(DateTime dateBegin, DateTime dateEnd, long version)
			{
				DateBegin = dateBegin;
				DateEnd = dateEnd;
				IsGasps = true;
				Version = version;
				IsMS = null;
			}

			public DateEntity(DateTime dateBegin, DateTime dateEnd, string vrn, bool isMs)
			{
				DateBegin = dateBegin;
				DateEnd = dateEnd;
				IsGasps = false;
				Version = vrn;
				IsMS = isMs;
			}

			public DateTime DateBegin { get; set; }
			public DateTime DateEnd { get; set; }
			public bool IsGasps { get; }
			public object Version { get; }
			/// <summary>
			/// Признак мирового суда. Для ГАС ПС равен null.
			/// </summary>
			public bool? IsMS { get; }

			public int CompareTo(object obj)
			{
				IDatesEntity objEntity = (IDatesEntity)obj;
				int compare = IsGasps ? 1 : 0;
				if (compare == 0) compare = DateTime.Compare(DateBegin, objEntity.DateBegin);
				if (compare == 0) compare = DateTime.Compare(DateEnd, objEntity.DateEnd);
				return compare;
			}

			int IComparable<IDatesEntity>.CompareTo(IDatesEntity other)
			{
				return CompareTo(obj: other);
			}

			public static bool operator ==(DateEntity x, DateEntity y)
			{
				return x.DateBegin.Date == y.DateBegin.Date &&
					x.DateEnd.Date == y.DateEnd.Date;
			}

			public static bool operator !=(DateEntity x, DateEntity y)
			{
				return x.DateBegin.Date != y.DateBegin.Date ||
					x.DateEnd.Date != y.DateEnd.Date;
			}			
		}

		public class DateEntityComparer : IComparer, IComparer<IDatesEntity>
		{
			public int Compare(object x, object y)
			{
				IDatesEntity xEntity = (IDatesEntity)x;
				IDatesEntity yEntity = (IDatesEntity)y;

				int compare = DateTime.Compare(xEntity.DateBegin, yEntity.DateBegin);
				if (compare == 0) compare = DateTime.Compare(xEntity.DateEnd, yEntity.DateEnd);
				if (compare == 0)
				{
					if (xEntity.IsGasps == yEntity.IsGasps)
					{
						return 0;
					}
					else if (xEntity.IsGasps  && !yEntity.IsGasps)
					{
						return -1;
					}
					else return 1;
				}
				return compare;
			}

			int IComparer<IDatesEntity>.Compare(IDatesEntity x, IDatesEntity y)
			{
				return Compare(x, y);
			}
		}

		public interface IDatesEntity : IComparable, IComparable<IDatesEntity>
		{
			DateTime DateBegin { get; set; }
			DateTime DateEnd { get; set; }
			bool IsGasps { get; }
			object Version { get; }
			/// <summary>
			/// Мировой суд.
			/// </summary>
			bool? IsMS { get; }
		}
	}
}
