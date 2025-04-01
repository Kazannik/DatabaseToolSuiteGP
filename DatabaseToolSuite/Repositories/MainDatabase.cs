using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using urpDataTable = DatabaseToolSuite.Repositories.MainDataSet.EXP_LAW_AGENCY_URPDataTable;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		public bool ExistsCourtTypeId(long id)
		{
			return CourtTypeTable.ExistsId(id);
		}

		public bool ExistsCourtTypeName(string name)
		{
			return CourtTypeTable.ExistsName(name);
		}

		public string GetCourtTypeName(long id)
		{
			return CourtTypeTable.GetName(id);
		}

		public bool ExistsOkatoCode(string code)
		{
			return OkatoTable.ExistsCode(code);
		}

		public bool ExistsOkatoName(string name)
		{
			return OkatoTable.ExistsName(name);
		}

		public bool ExistsOkatoName2(string name2)
		{
			return OkatoTable.ExistsName2(name2);
		}

		public bool ExistsOkatoCentrum(string centrum)
		{
			return OkatoTable.ExistsCentrum(centrum);
		}

		public bool ExistsOkatoGenitive(string genitive)
		{
			return OkatoTable.ExistsGenitive(genitive);
		}

		public string GetOkatoName(string code)
		{
			return OkatoTable.GetName(code);
		}

		public string GetOkatoName2(string code)
		{
			return OkatoTable.GetName2(code);
		}

		public string GetOkatoGenitive(string code)
		{
			return OkatoTable.GetGenitive(code);
		}

		private gaspsDataTable GaspsTable
		{
			get { return Services.MasterDataSystem.DataSet.gasps; }
		}

		private authorityDataTable AuthorityTable
		{
			get { return Services.MasterDataSystem.DataSet.authority; }
		}

		private okatoDataTable OkatoTable
		{
			get { return Services.MasterDataSystem.DataSet.okato; }
		}

		private court_typeDataTable CourtTypeTable
		{
			get { return Services.MasterDataSystem.DataSet.court_type; }
		}

		private fgis_esnsiDataTable FgisesnsiTable
		{
			get { return Services.MasterDataSystem.DataSet.fgis_esnsi; }
		}

		private ervkDataTable ErvkTable
		{
			get { return Services.MasterDataSystem.DataSet.ervk; }
		}

		private urpDataTable UrpTable
		{
			get { return Services.MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP; }
		}

		/// <summary>
		/// Вызов: return ConvertFromDBVal<string>(this[this.tablegasps.codeColumn]);
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		/// <code>return ConvertFromDBVal<string>(this[this.tablegasps.codeColumn]);</code>
		public static T ConvertFromDBVal<T>(object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return default;
			}
			else
			{
				return (T)obj;
			}
		}

		public class GaspsRowComparer : IComparer<gaspsRow>
		{
			public int Compare(gaspsRow x, gaspsRow y)
			{
				int compare = x.authority_id.CompareTo(y.authority_id);
				if (compare != 0) return compare;

				compare = x.okato_code.CompareTo(y.okato_code);
				if (compare != 0) return compare;

				compare = x.name.CompareTo(y.name);
				if (compare != 0) return compare;

				compare = x.date_beg.CompareTo(y.date_beg);
				if (compare != 0) return compare;

				compare = x.date_end.CompareTo(y.date_end) * -1;
				if (compare != 0) return compare;

				return x.version.CompareTo(y.version);
			}
		}

		public partial class court_typeDataTable
		{
			public bool ExistsId(long id)
			{
				return (from item in this.AsEnumerable()
						where item.id == id
						select item).Count() == 1;
			}

			public bool ExistsName(string name)
			{
				return (from item in this.AsEnumerable()
						where item.name == name
						select item).Count() == 1;
			}

			public string GetName(long id)
			{
				return (from item in this.AsEnumerable()
						where item.id == id
						select item).First().name;
			}
		}

		public partial class authorityDataTable
		{
			public bool ExistsId(long id)
			{
				return (from item in this.AsEnumerable()
						where item.id == id
						select item).Count() == 1;
			}

			public bool ExistsName(string name)
			{
				return (from item in this.AsEnumerable()
						where item.name == name
						select item).Count() == 1;
			}

			public string GetName(long id)
			{
				return (from item in this.AsEnumerable()
						where item.id == id
						select item).First().name;
			}
		}

		public partial class okatoDataTable
		{
			public bool ExistsCode(string code)
			{
				return (from item in this.AsEnumerable()
						where item.code == code
						select item).Count() == 1;
			}

			public bool ExistsName(string name)
			{
				return (from item in this.AsEnumerable()
						where item.name == name
						select item).Count() == 1;
			}

			public bool ExistsName2(string name2)
			{
				return (from item in this.AsEnumerable()
						where item.name2 == name2
						select item).Count() == 1;
			}

			public bool ExistsCentrum(string centrum)
			{
				return (from item in this.AsEnumerable()
						where item.centrum == centrum
						select item).Count() == 1;
			}

			public bool ExistsGenitive(string genitive)
			{
				return (from item in this.AsEnumerable()
						where item.genitive == genitive
						select item).Count() == 1;
			}

			public string GetName(string code)
			{
				return (from item in this.AsEnumerable()
						where code.Equals(item.code)
						select item).First().name;
			}

			public string GetName2(string code)
			{
				return (from item in this.AsEnumerable()
						where code.Equals(item.code)
						select item).First().name2;
			}

			public string GetGenitive(string code)
			{
				return (from item in this.AsEnumerable()
						where code.Equals(item.code)
						select item).First().genitive;
			}

			public okatoRow Get(string code)
			{
				return (from item in this.AsEnumerable()
						where code.Equals(item.code)
						select item).First();
			}
		}
	}
}