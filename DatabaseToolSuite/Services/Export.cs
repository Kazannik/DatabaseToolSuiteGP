using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet.gaspsDataTable;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet.fgis_esnsiDataTable;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DatabaseToolSuite.Services
{
    static class Export
    {

        public static void ExportToXml(string xmlFileName)
        {
            MasterDataSystem.DataSet.WriteXml(xmlFileName, System.Data.XmlWriteMode.WriteSchema);
        }


        public static void ExportGaspsToExcel()
        {
            IEnumerable<GaspsOrganization> data = MasterDataSystem.DataSet.gasps.ExportData();
            int rowCount = data.Count();

            Excel.Application m_objExcel = null;
            Excel.Workbooks m_objBooks = null;
            Excel._Workbook m_objBook = null;
            Excel.Sheets m_objSheets = null;
            Excel._Worksheet m_objSheet = null;
            Excel.Range m_objRange = null;
            Excel.Font m_objFont = null;

            object m_objOpt = Missing.Value;

            // Start a new workbook in Excel.
            m_objExcel = new Excel.Application();

            m_objExcel.Visible = true;

            m_objBooks = m_objExcel.Workbooks;
            m_objBook = m_objBooks.Add(m_objOpt);
            m_objSheets = m_objBook.Worksheets;
            m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
            

            object[] objHeaders = {"Номер", "Наименование", "Ведомство", "ОКАТО", "Код", "Дата начала действия"};
            m_objRange = m_objSheet.get_Range("A1", "F1");
            m_objRange.Value = objHeaders;
            m_objFont = m_objRange.Font;
            m_objFont.Bold = true;

            m_objRange = m_objSheet.get_Range("B1", "E" + (rowCount + 1));
            m_objRange.NumberFormat = "@";
            
            m_objRange = m_objSheet.get_Range("B1", "B1");
            m_objRange.ColumnWidth = 70;

            m_objRange = m_objSheet.get_Range("B2", "B2");
            m_objRange.Select();
            m_objExcel.ActiveWindow.FreezePanes = true;

            m_objRange = m_objSheet.get_Range("C1", "C1");
            m_objRange.ColumnWidth = 20;

            m_objRange = m_objSheet.get_Range("D1", "D1");
            m_objRange.ColumnWidth = 60;

            m_objRange = m_objSheet.get_Range("E1", "E1");
            m_objRange.ColumnWidth = 10;

            m_objRange = m_objSheet.get_Range("F1", "F1");
            m_objRange.ColumnWidth = 10;

            object[,] objData = new object[rowCount, 6];
            int r = 0;
            foreach (GaspsOrganization item in data)
            {
                objData[r, 0] = r + 1;
                objData[r, 1] = item.Name;
                objData[r, 2] = item.Authority;
                objData[r, 3] = item.Okato;
                objData[r, 4] = item.Code;
                objData[r, 5] = item.Begin;
                r += 1;
            }
            
            m_objRange = m_objSheet.get_Range("A2", m_objOpt);
            m_objRange = m_objRange.get_Resize(rowCount, 6);
            m_objRange.Value = objData;

            // Save the Workbook and quit Excel.
            //m_objBook.SaveAs(m_strSampleFolder + "Book2.xls", m_objOpt, m_objOpt,
            //m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
            //m_objOpt, m_objOpt, m_objOpt, m_objOpt);
           // m_objBook.Close(false, m_objOpt, m_objOpt);
          //  m_objExcel.Quit();
        }


        public static void ExportGaspsToExcel2()
        {
            IEnumerable<GaspsOrganization> data = MasterDataSystem.DataSet.gasps.ExportData()
                .Where(x=> x.AuthorityId == 20)
                .Where(x=> x.Name.ToLower().IndexOf("прокуратура")>=0);
            int rowCount = data.Count();

            Excel.Application m_objExcel = null;
            Excel.Workbooks m_objBooks = null;
            Excel._Workbook m_objBook = null;
            Excel.Sheets m_objSheets = null;
            Excel._Worksheet m_objSheet = null;
            Excel.Range m_objRange = null;
            Excel.Font m_objFont = null;

            object m_objOpt = Missing.Value;

            // Start a new workbook in Excel.
            m_objExcel = new Excel.Application();

            m_objExcel.Visible = true;

            m_objBooks = m_objExcel.Workbooks;
            m_objBook = m_objBooks.Add(m_objOpt);
            m_objSheets = m_objBook.Worksheets;
            m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));


            object[] objHeaders = { "Номер", "Наименование", "Ведомство", "ОКАТО", "Код", "Дата начала действия", "ключ", "ключ родителя"};
            m_objRange = m_objSheet.get_Range("A1", "H1");
            m_objRange.Value = objHeaders;
            m_objFont = m_objRange.Font;
            m_objFont.Bold = true;

            m_objRange = m_objSheet.get_Range("B1", "E" + (rowCount + 1));
            m_objRange.NumberFormat = "@";

            m_objRange = m_objSheet.get_Range("B1", "B1");
            m_objRange.ColumnWidth = 70;

            m_objRange = m_objSheet.get_Range("B2", "B2");
            m_objRange.Select();
            m_objExcel.ActiveWindow.FreezePanes = true;

            m_objRange = m_objSheet.get_Range("C1", "C1");
            m_objRange.ColumnWidth = 20;

            m_objRange = m_objSheet.get_Range("D1", "D1");
            m_objRange.ColumnWidth = 60;

            m_objRange = m_objSheet.get_Range("E1", "E1");
            m_objRange.ColumnWidth = 10;

            m_objRange = m_objSheet.get_Range("F1", "F1");
            m_objRange.ColumnWidth = 10;

            object[,] objData = new object[rowCount, 8];
            int r = 0;
            foreach (GaspsOrganization item in data)
            {
                objData[r, 0] = r + 1;
                objData[r, 1] = item.Name;
                objData[r, 2] = item.Authority;
                objData[r, 3] = item.Okato;
                objData[r, 4] = item.Code;
                objData[r, 5] = item.Begin;
                objData[r, 6] = item.Key;
                objData[r, 7] = item.OwnerId;
                r += 1;
            }

            m_objRange = m_objSheet.get_Range("A2", m_objOpt);
            m_objRange = m_objRange.get_Resize(rowCount, 8);
            m_objRange.Value = objData;

            // Save the Workbook and quit Excel.
            //m_objBook.SaveAs(m_strSampleFolder + "Book2.xls", m_objOpt, m_objOpt,
            //m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
            //m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            // m_objBook.Close(false, m_objOpt, m_objOpt);
            //  m_objExcel.Quit();
        }

        public static void ExportFgisEsnsiToExcel()
        {
            IEnumerable<FgisEsnsiOrganization> data = MasterDataSystem.DataSet.fgis_esnsi.ExportData();
            int rowCount = data.Count();

            Excel.Application m_objExcel = null;
            Excel.Workbooks m_objBooks = null;
            Excel._Workbook m_objBook = null;
            Excel.Sheets m_objSheets = null;
            Excel._Worksheet m_objSheet = null;
            Excel.Range m_objRange = null;
            Excel.Font m_objFont = null;

            object m_objOpt = Missing.Value;

            // Start a new workbook in Excel.
            m_objExcel = new Excel.Application();

            m_objExcel.Visible = true;

            m_objBooks = m_objExcel.Workbooks;

            m_objBook = m_objBooks.Add(m_objOpt);
            m_objSheets = m_objBook.Worksheets;
            m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
            m_objSheet.Name = "FED_GENPROK_ORGANIZATION_Cp1251";

            object[] objHeaders = { "id", "NAME", "REGION", "PHONE", "EMAIL", "ADDRESS", "OKATO", "CODE", "autokey"};
            m_objRange = m_objSheet.get_Range("A1", "I1");
            m_objRange.Value = objHeaders;
           
            object[,] objData = new object[rowCount, objHeaders.Count()];
            int r = 0;
            foreach (FgisEsnsiOrganization item in data)
            {
                objData[r, 0] = item.Id;
                objData[r, 1] = item.Name;
                objData[r, 2] = item.Region;
                objData[r, 3] = item.Phone;
                objData[r, 4] = item.Email;
                objData[r, 5] = item.Address;
                objData[r, 6] = item.Okato;
                objData[r, 7] = item.Code;
                objData[r, 8] = item.Autokey;
                r += 1;
            }

            m_objRange = m_objSheet.get_Range("A2", m_objOpt);
            m_objRange = m_objRange.get_Resize(rowCount, objHeaders.Count());
            m_objRange.Value = objData;            
        }

        public static void ExportFgisEsnsiToCsv(string path)
        {
            IEnumerable<FgisEsnsiOrganization> data = MasterDataSystem.DataSet.fgis_esnsi.ExportData();
            StreamWriter writer = new StreamWriter(path: path, append: false, encoding: Encoding.GetEncoding(1251));
            writer.WriteLine("id;NAME;REGION;PHONE;EMAIL;ADDRESS;OKATO;CODE;autokey");
            
            foreach (FgisEsnsiOrganization item in data)
            {
                string line = item.Id + ";" + 
                    item.Name.Trim() + ";" + 
                    item.Region.Trim() + ";" + 
                    item.Phone.Trim() + ";" + 
                    item.Email.Trim() + ";" + 
                    item.Address.Trim() + ";" + 
                    item.Okato.ToString("00") + ";" + 
                    item.Code + ";" + 
                    item.Autokey.Trim();
                writer.WriteLine(line);
             }
            writer.Close();
            MessageBox.Show("Экспорт в формате CSV выполнен!");
        }
    }
}
