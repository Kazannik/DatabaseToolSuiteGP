using System;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Dialogs
{
    public partial class OkatoEditDialog : DatabaseToolSuite.Dialogs.DictionaryEditDialog
    {
        public string Code { get; private set; }

        public string Okato { get; private set; }

        public int Ter { get; private set; }

        public int Kod1 { get; private set; }

        public string Lab { get; private set; }

        public string OkatoName { get; private set; }

        public string OkatoName2 { get; private set; }

        public string OkatoCentrum { get; private set; }

        public string OkatoGenitive { get; private set; }


        okatoDataTable okatoTable;

        private string oldCode = string.Empty;

        public OkatoEditDialog(okatoDataTable table)
        {
            okatoTable = table;

            InitializeComponent();

            terNumericTextBox.Text = string.Empty;
            kod1NumericTextBox.Text = string.Empty;
            labTextBox.Text  = string.Empty;
            nameTextBox.Text =  string.Empty;
            name2TextBox.Text = string.Empty;
            centrumTextBox.Text = string.Empty;
            genitiveTextBox.Text = string.Empty;
        }

        public OkatoEditDialog(int ter, int kod1, string lab, string name, string name2, string centrum, string genitive, okatoDataTable table)
        {
            okatoTable = table;

            InitializeComponent();

            terNumericTextBox.Text = ter.ToString("0");
            kod1NumericTextBox.Text = kod1.ToString("0");
            labTextBox.Text = lab;
            nameTextBox.Text = name;
            name2TextBox.Text = name2;
            centrumTextBox.Text = centrum;
            genitiveTextBox.Text = genitive;
            oldCode = SetCode();
            ValidateCode(codeTextBox);
        }


        private void terNumericTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            int ter = 0;
            int.TryParse(control.Text, out ter);
            Ter = ter;
            SetCode();
        }

        private void kod1NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            int kod1 = 0;
            int.TryParse(control.Text, out kod1);
            Kod1 = kod1;
            SetCode();
        }

        private void labTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            Lab = control.Text;
            SetCode();
        }

        private string SetCode()
        {
            Okato = terNumericTextBox.Value.ToString("00") + (kod1NumericTextBox.Value > 0 ? kod1NumericTextBox.Value.ToString("00"):string.Empty);
            Code = Okato + (labTextBox.Text.Length > 0 ? labTextBox.Text.ToUpper() : string.Empty);
            okatoTextBox.Text = Okato;
            codeTextBox.Text = Code;
            return Code;
        }

        private void ValidateCode(Control control)
        {
            if ((oldCode == string.Empty || oldCode != Code) && okatoTable.ExistsCode(Code))
            {
                okatoErrorProvider.SetError(control, "Указанный код не является уникальным!");
                okButton.Enabled = false;
                errorLabel.Text = okatoTable.GetName(Code);
            }
            else
            {
                okatoErrorProvider.SetError(control, String.Empty);
                okButton.Enabled = true;
                errorLabel.Text = String.Empty;
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            OkatoName = control.Text;
        }

        private void name2TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            OkatoName2 = control.Text;
        }

        private void centrumTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            OkatoCentrum = control.Text;
        }

        private void genitiveTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            OkatoGenitive = control.Text;
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateCode((Control) sender);
        }
    }
}
