// Ignore Spelling: Utils

namespace DatabaseToolSuite.Utils
{
	internal static class NameWizard
	{

		public static string GetName(Repositories.MainDataSet.gaspsRow row)
		{
			if (row == null) return string.Empty;
			string name = row.name;
			return name + ClearText(GetOwnerName(row)).TrimEnd();
		}

		private static string GetOwnerName(Repositories.MainDataSet.gaspsRow row)
		{
			string result = string.Empty;
			if (row.owner_id > 0)
			{
				Repositories.MainDataSet.gaspsRow owner = Services.FileSystem.Repository.MainDataSet.gasps.GetLastVersionOrganizationFromKey(row.owner_id);
				result = " " + owner.name + GetOwnerName(owner);
			}
			return result;
		}

		private static string ClearText(string text)
		{
			return text
				.Replace("Центральный аппарат ", string.Empty)
				.Replace("Аппарат ", string.Empty)
				.Replace("Главное ", "Главного ")
				.Replace("Управление ", "управления ")
				.Replace("управление ", "управления ")
				.Replace("Генеральной прокуратуры Российской Федерации Генеральная прокуратура Российской Федерации", "Генеральной прокуратуры Российской Федерации");
		}

	}
}
