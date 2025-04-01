using DatabaseToolSuite.Controls;

namespace DatabaseToolSuite.Repositories.Dto
{
	internal class OkatoDto : ComboControl<OkatoDto>.IComboBoxItem
	{
		public long Id { get; private set; }

		public string Code { get; private set; }

		public string Okato { get; private set; }

		public int Ter { get; private set; }

		public int Kod1 { get; private set; }

		public string Lab { get; private set; }

		public string Name { get; private set; }

		public string Name2 { get; private set; }

		public string Centrum { get; private set; }

		public string Genitive { get; private set; }

		public string Text
		{ get { return Name; } }

		public string SSRF { get; private set; }

		public OkatoDto()
		{
			Id = -1;
			Ter = 0;
			Kod1 = 0;
			Lab = string.Empty;
			Name = string.Empty;
			Name2 = string.Empty;
			Centrum = string.Empty;
			Genitive = string.Empty;
			Okato = string.Empty;
			Code = string.Empty;
			SSRF = string.Empty;
		}

		public OkatoDto(int ter, int kod1, string lab, string name, string name2, string centrum, string genitive, string ssrf)
		{
			Id = 0;
			Ter = ter;
			Kod1 = kod1;
			Lab = lab;
			Name = name;
			Name2 = name2;
			Centrum = centrum;
			Genitive = genitive;
			Okato = ter.ToString("00") + (kod1 > 0 ? kod1.ToString("00") : string.Empty);
			Code = Okato + (lab.Length > 0 ? lab.ToUpper() : string.Empty);
			SSRF = ssrf;
		}

		public OkatoDto(MainDataSet.okatoRow row) : this(
			ter: int.Parse(row.ter),
			kod1: row.kod1,
			lab: (row.IslabNull() ? string.Empty : row.lab),
			name: row.name,
			name2: (row.Isname2Null() ? string.Empty : row.name2),
			centrum: (row.IscentrumNull() ? string.Empty : row.centrum),
			genitive: (row.IsgenitiveNull() ? string.Empty : row.genitive),
			ssrf: (row.IsssrfNull() ? string.Empty : row.ssrf)
			)
		{
			Id = row.export_id;
		}
	}
}