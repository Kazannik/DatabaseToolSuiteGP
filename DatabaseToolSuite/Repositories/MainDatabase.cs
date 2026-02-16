// Ignore Spelling: okato ord centrum ssrf fgis esnsi sv autokey ervk ogrn oktmo VED

using System.Collections.Generic;
using System.Data;
using System.Linq;
using courtsDataTable = DatabaseToolSuite.Repositories.MainDataSet.DIC_RECORDDataTable;
using dicCourtsDataTable = DatabaseToolSuite.Repositories.MainDataSet.DICDataTable;
using urpDataTable = DatabaseToolSuite.Repositories.MainDataSet.EXP_LAW_AGENCY_URPDataTable;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		partial class EXP_LAW_AGENCY_URPDataTable
		{
		}

		public bool ExistsCourtTypeId(long id) => CourtTypeTable.ExistsId(id);

		public bool ExistsCourtTypeName(string name) => CourtTypeTable.ExistsName(name);

		public string GetCourtTypeName(long id) => CourtTypeTable.GetName(id);

		public bool ExistsOkatoCode(string code) => OkatoTable.ExistsCode(code);

		public bool ExistsOkatoName(string name) => OkatoTable.ExistsName(name);

		public bool ExistsOkatoName2(string name2) => OkatoTable.ExistsName2(name2);

		public bool ExistsOkatoCentrum(string centrum) => OkatoTable.ExistsCentrum(centrum);

		public bool ExistsOkatoGenitive(string genitive) => OkatoTable.ExistsGenitive(genitive);

		public bool ExistsCourts(string vrn) => CourtsTable.Exists(vrn: vrn);

		public bool ExistsDicCourts(int dicId) => DicCourtsTable.Exists(dicId: dicId);


		public string GetOkatoName(string code) => OkatoTable.GetName(code);

		public string GetOkatoName2(string code) => OkatoTable.GetName2(code);

		public string GetOkatoGenitive(string code) => OkatoTable.GetGenitive(code);

		public string GetOkatoSSRF(string code) => OkatoTable.GetSSRF(code);


		private gaspsDataTable GaspsTable => Services.MasterDataSystem.DataSet.gasps;

		private authorityDataTable AuthorityTable => Services.MasterDataSystem.DataSet.authority;

		private okatoDataTable OkatoTable => Services.MasterDataSystem.DataSet.okato;

		private court_typeDataTable CourtTypeTable => Services.MasterDataSystem.DataSet.court_type;

		private fgis_esnsiDataTable FgisesnsiTable => Services.MasterDataSystem.DataSet.fgis_esnsi;

		private ervkDataTable ErvkTable => Services.MasterDataSystem.DataSet.ervk;

		private urpDataTable UrpTable => Services.MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP;

		private courtsDataTable CourtsTable => Services.MasterDataSystem.DataSet.DIC_RECORD;

		private dicCourtsDataTable DicCourtsTable => Services.MasterDataSystem.DataSet.DIC;

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

			public string GetSSRF(string code)
			{
				if ((from item in this.AsEnumerable()
					 where code.Equals(item.code)
					 select item).Any())
				{
					return (from item in this.AsEnumerable()
							where code.Equals(item.code)
							select item).First().ssrf;
				}
				else
					return default;
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