using DatabaseToolSuite.Repositoryes;
using DatabaseToolSuite.Repositoryes.Dto;
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

		#endregion Initialize
	}
}