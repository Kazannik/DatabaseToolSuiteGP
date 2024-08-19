using DatabaseToolSuite.Repositoryes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DatabaseToolSuite.Dialogs
{
    public partial class ImportProcessDialog : Form
    {
        DataTable _dataTable;
        string _filename;
        DataTable[] _linkDataTables;
        IDictionary<string, string> _linkColumnIndexes;

        public ImportProcessDialog(DataTable dataTable, string filename, IDictionary<string, string> linkColumnIndexes) : this(dataTable: dataTable, filename: filename, linkColumnIndexes:linkColumnIndexes, linkDataTables: null) { }

        public ImportProcessDialog(DataTable dataTable, string filename, IDictionary<string, string> linkColumnIndexes,  DataTable[] linkDataTables)
        {
            _dataTable = dataTable;
            _filename = filename;
            _linkDataTables = linkDataTables;
            _linkColumnIndexes = linkColumnIndexes;

            InitializeComponent();

            progressLabel.Text = String.Empty;
            cancelButton.Enabled = true;            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            importBackgroundWorker.CancelAsync();
            cancelButton.Enabled = false;
        }

        private void importBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            DataTable dataTable =(DataTable) ((Object[])e.Argument)[0];
            string filename = (string)((Object[])e.Argument)[1];
            DataTable[] linkDataTables = (DataTable[])((Object[])e.Argument)[2];
            IDictionary<string, string> linkColumnIndexes = (IDictionary<string, string>)((Object[])e.Argument)[3];

            //LinkDataSet linkDataSet = new LinkDataSet();
            //if (linkfile !=string.Empty)
            //{
            //    linkDataSet.ReadXml(linkfile, XmlReadMode.IgnoreSchema);
            //}

            StreamReader reader = new StreamReader(filename, Encoding.GetEncoding(1251));
            long length = reader.BaseStream.Length;
            string headers = reader.ReadLine();

            int index = -1;
            while (!reader.EndOfStream)
            {
                long percent = reader.BaseStream.Position * 100 / length;
                worker.ReportProgress((int)percent);
                string line = reader.ReadLine();
                string[] split = line.Split(';');
                
                object[] cells = new object[dataTable.Columns.Count];

                
                index+=1;
                cells[0] = index;

                for (int i = 1; i < split.Length; i++)
                {                   
                        try
                        {
                            cells[i] = Convert.ChangeType(split[i], dataTable.Columns[i].DataType);
                        }
                        catch (Exception)
                        {
                            cells[i] = 0;
                        }
                    
                }

                if (linkColumnIndexes.ContainsKey(split[3]))
                {
                    cells[3] = linkColumnIndexes[split[3]];
                    if (cells[3].ToString() == "00")
                    {
                        string code = cells[5].ToString();
                        string okato = code.Substring(2, 4);
                        cells[3] = okato;
                    }
                }
                else
                {
                    throw new Exception(split[3]);
                }

                if (linkColumnIndexes.ContainsKey(split[4]))
                {
                    cells[4] = linkColumnIndexes[split[4]];
                }
                else
                {
                    throw new Exception(split[4]);
                }

                if (linkColumnIndexes.ContainsKey(split[13]))
                {
                    cells[13] = linkColumnIndexes[split[13]];
                }
                else
                {
                    cells[13] = 0;
                }
                
                DataRow row = dataTable.Rows.Add(cells);
            }

            reader.Close();

            e.Result = "100%";
        }

        private void importBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.importProgressBar.Value = e.ProgressPercentage;
        }

        private void importBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {                
                progressLabel.Text = "Canceled";
                Close();
            }
            else
            {
                progressLabel.Text = e.Result.ToString();
                Close();
            }
            cancelButton.Enabled = false;
        }

        private void ImportProcessDialog_Shown(object sender, EventArgs e)
        {
            if (_linkDataTables == null)
            {
                _linkDataTables = new DataTable[_dataTable.Columns.Count];
            }

            importBackgroundWorker.RunWorkerAsync(new object[] { _dataTable, _filename, _linkDataTables, _linkColumnIndexes });
        }
    }
}
