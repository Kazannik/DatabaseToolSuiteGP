// Ignore Spelling: Oktmo

using System.Text.RegularExpressions;

namespace DatabaseToolSuite.Utils
{
	static class Converters
	{
		private static readonly Regex quotesRegex = new Regex("\\u0022\\w+\\u0022", RegexOptions.IgnoreCase & RegexOptions.Compiled);


		/// <summary>
		/// Добавление к коду ОКТМО нулей в конце строки (до 8 знаков).
		/// </summary>
		/// <param name="oktmo">Код ОКТМО</param>
		/// <returns></returns>
		public static string OktmoToEightSymbols(string oktmo)
		{
			string small = oktmo.Substring(0, 2).Equals("00") ? string.Empty : oktmo;
			if (string.IsNullOrEmpty(small))
			{
				return small;
			}
			else
			{
				return small + new string('0', 8 - small.Length);
			}
		}

		public static string TitleForCsvFormat(string title)
		{
			string result = title.Replace("\r\n", string.Empty).Replace("\r", string.Empty).Trim();
			if (quotesRegex.IsMatch(result))
			{
				result = "\"" + result.Replace("\"", "\"\"") + "\"";
			}
			return result;
		}

	}
}
