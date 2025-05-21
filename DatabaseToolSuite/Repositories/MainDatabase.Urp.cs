// Ignore Spelling: oktmo

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using urpRow = DatabaseToolSuite.Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		public partial class EXP_LAW_AGENCY_URPDataTable
		{
			public bool Exists(long gaspsVersion)
			{
				return (from item in this.AsEnumerable()
						.Where(x => x.RowState != DataRowState.Deleted)
						where item.VERSION == gaspsVersion
						select item).Count() > 0;
			}

			public urpRow Get(long version)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted)
					.Last(x => x.VERSION == version);
			}

			public long GetNextId()
			{
				if (this.Rows.Count > 0)
				{
					return 1 + this.AsEnumerable()
							.Where(x => x.RowState != DataRowState.Deleted)
							.Max(x => x.ID);
				}
				else
				{
					return 1;
				}
			}

			public urpRow Create(long gaspsVersion, string shortName, long oktmo)
			{
				long id = GetNextId();
				return (urpRow)this.Rows.Add(new object[] {
					gaspsVersion,
					shortName, // SHORT_NAME
					false, // DOESNT_CREATE_CARD
					false, // DOESNT_SIGN_REPORT
					false, // DOESNT_CONSOLIDATE_CHILD
					0, // AGENCY_RECEIVING_REPORT
					0, // ORD
					0, // VED_CODE
					id, // ID
					oktmo, // OKTMO_LOC_ID
					0, // LAW_AGENCY_TYPE
					null // SPECIAL_TERRITORIAL_CODE
				});
			}

			public void Remove(long gaspsVersion)
			{
				DataRow row = Get(gaspsVersion);
				row.Delete();
			}

			public IEnumerable<ViewUrpOrganization> ExportGaspsFullData()
			{
				EnumerableRowCollection<gaspsRow> gaspsCollection = GaspsTable
					.Where(e => e.RowState != DataRowState.Deleted)
					.OrderBy(e => e, new GaspsRowComparer());
				EnumerableRowCollection<gaspsRow> activeCollection = gaspsCollection.Where(e => e.date_end.Date > DateTime.Today && e.date_beg.Date <= DateTime.Today);
				EnumerableRowCollection<urpRow> urpCollection = this.AsEnumerable()
					.Where(e => e.RowState != DataRowState.Deleted);

				return from gasps in gaspsCollection
					   join owner in activeCollection on gasps.owner_id equals owner.key into ow_jointable
					   from ow in ow_jointable.DefaultIfEmpty()
					   join urp in urpCollection on gasps.version equals urp.VERSION into ur_jointable
					   from ur in ur_jointable.DefaultIfEmpty()
					   select new ViewUrpOrganization(gasps: gasps, owner: ow, urp: ur);
			}

			private gaspsDataTable GaspsTable
			{
				get { return Services.MasterDataSystem.DataSet.gasps; }
			}
		}
	}
}