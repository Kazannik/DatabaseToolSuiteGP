using DatabaseToolSuite.Repositories;
using DatabaseToolSuite.Repositories.Dto;
using DatabaseToolSuite.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.Design;

namespace DatabaseToolSuite.Controls
{
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
	internal class AuthorityComboBox : ComboControl<AuthorityDto>
	{
		#region Initialize

		public AuthorityComboBox() : base()
		{
		}

		public void InitializeSource(MainDataSet.authorityDataTable table)
		{
			BeginUpdate();
			Items.Clear();
			foreach (MainDataSet.authorityRow row in table.Rows)
			{
				Add(new AuthorityDto(row));
			}
			EndUpdate();
		}

		public void InitializeSource(MainDataSet.authorityDataTable table, bool isProsecutor)
		{
			BeginUpdate();
			Items.Clear();
			IEnumerable<MainDataSet.authorityRow> rowCollection;
			if (isProsecutor)
			{
				rowCollection = from MainDataSet.authorityRow row
								in table.Rows
								where row.id == MasterDataSystem.PROSECUTOR_CODE
								select row;
			}
			else
			{
				rowCollection = from MainDataSet.authorityRow row
								in table.Rows
								where row.id != MasterDataSystem.PROSECUTOR_CODE &&
								row.id != MasterDataSystem.COURT_CODE
								select row;
			}

			foreach (MainDataSet.authorityRow row in rowCollection)
			{
				Add(new AuthorityDto(row));
			}
			EndUpdate();
		}

		#endregion Initialize
	}
}