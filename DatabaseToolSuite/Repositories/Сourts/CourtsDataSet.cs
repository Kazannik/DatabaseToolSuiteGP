// Ignore Spelling: Сourts

using System.Data;
using System.Linq;

namespace DatabaseToolSuite.Repositories.Сourts
{

	partial class СourtsDataSet
	{
		partial class DICDataTable
		{
			public bool Exists(int dicId)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted &&
					x.DIC_Id == dicId)
					.Any();
			}

			public DICRow Get(int dicId)
			{
				return this.AsEnumerable()
					.Where(x => x.RowState != DataRowState.Deleted)
					.Last(x => x.DIC_Id == dicId);
			}
		}
	}
}

