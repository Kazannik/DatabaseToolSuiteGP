using DatabaseToolSuite.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet.fgis_esnsiDataTable;

namespace DatabaseToolSuite.Utils.Dialogs
{
    public partial class ImportDialog : Form
    {
        const string HEADER = "id;Наименование прокуратуры (SV-0001);REGION;Телефон канцелярии (SV-0004);Электронный адрес канцелярии(SV-0005);Адрес приемной(SV-0006);OKATO;CODE;autokey;version";

        List<NoteFgisEsnsi> existsNotes;

        public ImportDialog()
        {
            existsNotes = new List<NoteFgisEsnsi>();

            InitializeComponent();
        }

        private void openFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;

            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            existsNotes.Clear();

            System.IO.StreamReader reader = new System.IO.StreamReader(dialog.FileName, Encoding.Default);
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] split = line.Split(new string[] { ";" }, StringSplitOptions.None);

                NoteFgisEsnsi note = new NoteFgisEsnsi(
                    id: long.Parse(split[0]),
                    name: split[1],
                    region: split[2],
                    phone: split[3],
                    email: split[4],
                    address: split[5],
                    okato: short.Parse(split[6]),
                    code: long.Parse(split[7]),
                    autokey: split[8]);

                if (split.Length == 10)
                    note.Version = long.Parse(split[9]);
                
                    existsNotes.Add(note);
            }
            reader.Close();
            MessageBox.Show("Загружено " + existsNotes.Count + " записей");

            foreach (NoteFgisEsnsi note in existsNotes)
            {
                ListViewItem item = listView1.Items.Add(note.Name);
                item.Tag = note;
                item.SubItems.Add(note.Region);
                item.SubItems.Add(note.Address);
            }
        }

        private void selectOrganizationButton_Click(object sender, EventArgs e)
        {
            SelectOrganizationDialog dialog = new SelectOrganizationDialog(Services.MasterDataSystem.DataSet);
            if (listView1.SelectedItems.Count > 0)
            {
                NoteFgisEsnsi note = (NoteFgisEsnsi)listView1.SelectedItems[0].Tag;
                dialog.FilterAuthority = 20;
                dialog.FilterName = note.Name;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        note.Version = dialog.DataRow.version;
                        Services.MasterDataSystem.CreateFgisEsnsiNote(dialog.DataRow.version, note.Okato, note.Phone, note.Email, note.Address, note.Okato, note.Code, note.Autokey, note.Id);
                        listView1.SelectedItems[0].Remove();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }            
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;

            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            existsNotes.Clear();
            int adding = 0;

            System.IO.StreamReader reader = new System.IO.StreamReader(dialog.FileName, Encoding.Default);
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] split = line.Split(new string[] { ";" }, StringSplitOptions.None);

                NoteFgisEsnsi note = new NoteFgisEsnsi(
                    id: long.Parse(split[0]), 
                    name: split[1], 
                    region: split[2], 
                    phone: split[3], 
                    email: split[4], 
                    address: split[5], 
                    okato: short.Parse(split[6]), 
                    code: long.Parse( split[7]), 
                    autokey: split[8]);

                IEnumerable<long> versions = Services.MasterDataSystem.DataSet.gasps.GetVersionFromNameOkato(note.Name1, note.Name2, note.Name3, note.Okato.ToString("00"));
                foreach (long v in versions)
                {
                    if (!Services.MasterDataSystem.DataSet.fgis_esnsi.ExistsRow(v))
                    {
                        Services.MasterDataSystem.CreateFgisEsnsiNote(v, note.Okato, note.Phone, note.Email, note.Address, note.Okato, note.Code, note.Autokey, note.Id);
                        adding += 1;
                    }
                }

                if (versions.Count() == 0)
                {
                   existsNotes.Add(note);
                }
            }
            reader.Close();
            MessageBox.Show("Добавлено " + adding + " записей");

            foreach (NoteFgisEsnsi note in existsNotes)
            {
                ListViewItem item = listView1.Items.Add(note.Name);
                item.Tag = note;
                item.SubItems.Add(note.Region);
                item.SubItems.Add(note.Address);
            }
        }


        public class NoteFgisEsnsi: FgisEsnsiOrganization
        {
            public new long Version
            {
                get { return base.Version; }
                set { base.Version = value; }
            }

            public string Name1 { get; }
            public string Name2 { get; }
            public string Name3 { get; }

            public NoteFgisEsnsi(
                   long id,
                   string name,
                   string region,
                   string phone,
                   string email,
                   string address,
                   short okato,
                   long code,
                   string autokey): 
                base(
                    version: -1, 
                    id: id, 
                    name: name, 
                    region: region, 
                    phone: phone, 
                    email: email, 
                    address: address, 
                    okato: okato, 
                    code: code, 
                    autokey: autokey)
            {
                Name1 = name;
                Name2 = name.Replace(" г. ", " города ");
                Name3 = name.Replace(" города ", " г. ");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(dialog.FileName, false, Encoding.Default);

                writer.WriteLine(HEADER);

                foreach (NoteFgisEsnsi note in existsNotes)
                {
                    writer.WriteLine(
                        note.Id + ";" +
                        note.Name + ";" +
                        note.Region + ";" +
                        note.Phone + ";" +
                        note.Email + ";" +
                        note.Address + ";" +
                        note.Okato + ";" +
                        note.Code + ";" +
                        note.Autokey + ";" + 
                        note.Version);
                }
                writer.Close();
            }
        }
    }
}
