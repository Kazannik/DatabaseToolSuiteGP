// Ignore Spelling: okato autokey Fgis Esnsi

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		public partial class fgis_esnsiDataTable
		{
			public bool Exists(long gaspsVersion)
			{
				return (from item in this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
						where item.version == gaspsVersion
						select item).Count() > 0;
			}

			public fgis_esnsiRow Get(long gaspsVersion)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted)
					.Last(x => x.version == gaspsVersion);
			}

			public void Remove(long gaspsVersion)
			{
				DataRow row = Get(gaspsVersion);
				row.Delete();
			}

			public long GetNextId()
			{
				if (Count > 0)
					return 1 + this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
						.Max(r => r.id);
				else
					return 1;
			}

			public long GetNextCode()
			{
				if (Count > 0)
					return 1 + this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
						.Max(r => r.code);
				else
					return 1;
			}

			public fgis_esnsiRow Create(long gaspsVersion)
			{
				DateTime dateStartVersion = DateTime.Now;
				long esnsiId = GetNextId();
				long esnsiCode = GetNextCode();
				string autokey = "FED_GENPROK_ORGANIZATION_" + esnsiId;
				return (fgis_esnsiRow)this.Rows.Add(new object[] { gaspsVersion, null, null, null, null, null, esnsiCode, autokey, esnsiId, null, null }); ;
			}

			public class FgisEsnsiOrganization
			{
				private FgisEsnsiOrganization()
				{ }

				public long Version { get; protected set; }
				public long Id { get; private set; }
				public string Name { get; private set; }
				public string Region { get; private set; }
				public string Phone { get; private set; }
				public string Email { get; private set; }
				public string Address { get; private set; }
				public short Okato { get; private set; }
				public long Code { get; private set; }
				public string Autokey { get; private set; }

				public string OkatoList { get; private set; }

				public DateTime EditDate { get; private set; }

				public FgisEsnsiOrganization(
					long version,
					long id,
					string name,
					string region,
					string phone,
					string email,
					string address,
					short okato,
					long code,
					string autokey,
					string okatoList,
					DateTime editDate)
				{
					Version = version;
					Id = id;
					Name = name;
					Region = region;
					Phone = phone;
					Email = email;
					Address = address;
					Okato = okato;
					Code = code;
					Autokey = autokey;
					OkatoList = okatoList;
					EditDate = editDate;
				}
			}

			public IEnumerable<FgisEsnsiOrganization> ExportData()
			{
				return from esnsi in this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
					   join gasps in gaspsTable.ExportActiveData()
					   on esnsi.version equals gasps.version
					   select new FgisEsnsiOrganization(
						   version: esnsi.version,
						   id: esnsi.IsidNull() ? 0 : esnsi.id,
						   name: gasps.name,
						   region: gasps.okatoRow.Isname2Null() ? gasps.okatoRow.name : gasps.okatoRow.name2,
						   phone: esnsi.Issv_0004Null() ? string.Empty : esnsi.sv_0004,
						   email: esnsi.Issv_0005Null() ? string.Empty : esnsi.sv_0005,
						   address: esnsi.Issv_0006Null() ? string.Empty : esnsi.sv_0006,
						   okato: esnsi.IsokatoNull() ? (short)0 : esnsi.okato,
						   code: esnsi.IscodeNull() ? 0 : esnsi.code,
						   autokey: esnsi.IsautokeyNull() ? string.Empty : esnsi.autokey,
						   okatoList: esnsi.IsokatoListNull() ? string.Empty : esnsi.okatoList,
						   editDate: esnsi.IslogEditDateNull() ? Services.MasterDataSystem.MIN_DATE : esnsi.logEditDate);
			}

			private gaspsDataTable gaspsTable
			{
				get { return Services.MasterDataSystem.DataSet.gasps; }
			}

			private okatoDataTable okatoTable
			{
				get { return Services.MasterDataSystem.DataSet.okato; }
			}
		}
	}
}