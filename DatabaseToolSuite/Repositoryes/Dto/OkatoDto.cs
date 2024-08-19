using DatabaseToolSuite.Controls;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Repositoryes.Dto
{
    public class OkatoDto : ComboControl<OkatoDto>.IComboBoxItem
    {
        public string Code { get; }

        public string Okato { get; }

        public int Ter { get; }

        public int Kod1 { get;}

        public string Lab { get; }

        public string Name { get; }

        public string Name2 { get; }

        public string Centrum { get; }

        public string Genitive { get; }

        public string Text { get { return Name; } }

        public OkatoDto (int ter, int kod1, string lab, string name, string name2, string centrum, string genitive)
        {
            Ter = ter;
            Kod1 = kod1;
            Lab = lab;
            Name = name;
            Name2 = name2;
            Centrum = centrum;
            Genitive = genitive;
            Okato = ter.ToString("00") + (kod1 > 0 ? kod1.ToString("00") : string.Empty);
            Code = Okato + (lab.Length > 0 ? lab.ToUpper() : string.Empty);
        }

        public OkatoDto(okatoRow row) : this(int.Parse(row.ter), row.kod1, 
            (row.IslabNull() ? string.Empty: row.lab), 
            row.name, 
            (row.Isname2Null() ? string.Empty:  row.name2), 
            (row.IscentrumNull() ? string.Empty: row.centrum), 
            (row.IsgenitiveNull() ? string.Empty: row.genitive)
            ) { }       
    }
}
