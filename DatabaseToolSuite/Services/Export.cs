﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DatabaseToolSuite.Repositoryes;

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
            IEnumerable<RepositoryDataSet.ViewGaspsOrganization> data = MasterDataSystem.DataSet.gasps.ExportData();
            int rowCount = data.Count();

            Excel.Application excExcel = null;
            Excel.Workbooks excBooks = null;
            Excel._Workbook excBook = null;
            Excel.Sheets excSheets = null;
            Excel._Worksheet excSheet = null;
            Excel.Range excRange = null;
            Excel.Font excFont = null;

            object objOpt = Missing.Value;

            excExcel = new Excel.Application();

            excExcel.Visible = true;

            excBooks = excExcel.Workbooks;
            excBook = excBooks.Add(objOpt);
            excSheets = excBook.Worksheets;
            excSheet = (Excel._Worksheet)(excSheets.get_Item(1));


            object[] objHeaders = { "Номер", "Наименование", "Ведомство", "ОКАТО", "Код", "Дата начала действия" };
            excRange = excSheet.get_Range("A1", "F1");
            excRange.Value = objHeaders;
            excFont = excRange.Font;
            excFont.Bold = true;

            excRange = excSheet.get_Range("B1", "E" + (rowCount + 1));
            excRange.NumberFormat = "@";

            excRange = excSheet.get_Range("B1", "B1");
            excRange.ColumnWidth = 70;

            excRange = excSheet.get_Range("B2", "B2");
            excRange.Select();
            excExcel.ActiveWindow.FreezePanes = true;

            excRange = excSheet.get_Range("C1", "C1");
            excRange.ColumnWidth = 20;

            excRange = excSheet.get_Range("D1", "D1");
            excRange.ColumnWidth = 60;

            excRange = excSheet.get_Range("E1", "E1");
            excRange.ColumnWidth = 10;

            excRange = excSheet.get_Range("F1", "F1");
            excRange.ColumnWidth = 10;

            object[,] objData = new object[rowCount, 6];
            int r = 0;
            foreach (RepositoryDataSet.ViewGaspsOrganization item in data)
            {
                objData[r, 0] = r + 1;
                objData[r, 1] = item.Name;
                objData[r, 2] = item.AuthorityId.ToString("00 - ") + item.Authority;
                objData[r, 3] = item.Okato;
                objData[r, 4] = item.Code;
                objData[r, 5] = item.Begin;
                r += 1;
            }

            excRange = excSheet.get_Range("A2", objOpt);
            excRange = excRange.get_Resize(rowCount, 6);
            excRange.Value = objData;
        }


        public static void ExportFullDataBaseToExcel()
        {
            IEnumerable<RepositoryDataSet.ViewGaspsOrganization> data = MasterDataSystem.DataSet.gasps.ExportFullData();
            int rowCount = data.Count();

            Excel.Application excExcel = null;
            Excel.Workbooks excBooks = null;
            Excel._Workbook excBook = null;
            Excel.Sheets excSheets = null;
            Excel._Worksheet excSheet = null;
            Excel.Range excRange = null;
            Excel.Font excFont = null;

            object objOpt = Missing.Value;

            excExcel = new Excel.Application();

            excExcel.Visible = true;

            excBooks = excExcel.Workbooks;
            excBook = excBooks.Add(objOpt);
            excSheets = excBook.Worksheets;
            excSheet = (Excel._Worksheet)(excSheets.get_Item(1));


            object[] objHeaders = { "Номер", "Наименование", "Ведомство", "ОКАТО", "Код", "Дата начала действия", "Дата окончания действия" };
            excRange = excSheet.get_Range("A1", "G1");
            excRange.Value = objHeaders;
            excFont = excRange.Font;
            excFont.Bold = true;

            excRange = excSheet.get_Range("B1", "E" + (rowCount + 1));
            excRange.NumberFormat = "@";

            excRange = excSheet.get_Range("B1", "B1");
            excRange.ColumnWidth = 70;

            excRange = excSheet.get_Range("B2", "B2");
            excRange.Select();
            excExcel.ActiveWindow.FreezePanes = true;

            excRange = excSheet.get_Range("C1", "C1");
            excRange.ColumnWidth = 20;

            excRange = excSheet.get_Range("D1", "D1");
            excRange.ColumnWidth = 60;

            excRange = excSheet.get_Range("E1", "E1");
            excRange.ColumnWidth = 10;

            excRange = excSheet.get_Range("F1", "F1");
            excRange.ColumnWidth = 10;

            excRange = excSheet.get_Range("G1", "G1");
            excRange.ColumnWidth = 10;

            object[,] objData = new object[rowCount, 7];
            int r = 0;
            foreach (RepositoryDataSet.ViewGaspsOrganization item in data)
            {
                objData[r, 0] = r + 1;
                objData[r, 1] = item.Name;
                objData[r, 2] = item.AuthorityId.ToString("00 - ") + item.Authority;
                objData[r, 3] = item.Okato;
                objData[r, 4] = item.Code;
                objData[r, 5] = item.Begin;
                objData[r, 6] = item.End;
                r += 1;
            }

            excRange = excSheet.get_Range("A2", objOpt);
            excRange = excRange.get_Resize(rowCount, 7);
            excRange.Value = objData;
        }

        public static void ExportGaspsToExcel2()
        {
            IEnumerable<RepositoryDataSet.ViewGaspsOrganization> data = MasterDataSystem.DataSet.gasps.ExportData()
                .Where(x => x.AuthorityId == 20)
                .Where(x => x.Name.ToLower().IndexOf("прокуратура") >= 0);
            int rowCount = data.Count();

            Excel.Application excExcel = null;
            Excel.Workbooks excBooks = null;
            Excel._Workbook excBook = null;
            Excel.Sheets excSheets = null;
            Excel._Worksheet excSheet = null;
            Excel.Range excRange = null;
            Excel.Font excFont = null;

            object objOpt = Missing.Value;

            excExcel = new Excel.Application();

            excExcel.Visible = true;

            excBooks = excExcel.Workbooks;
            excBook = excBooks.Add(objOpt);
            excSheets = excBook.Worksheets;
            excSheet = (Excel._Worksheet)(excSheets.get_Item(1));


            object[] objHeaders = { "Номер", "Наименование", "Ведомство", "ОКАТО", "Код", "Дата начала действия", "ключ", "ключ родителя" };
            excRange = excSheet.get_Range("A1", "H1");
            excRange.Value = objHeaders;
            excFont = excRange.Font;
            excFont.Bold = true;

            excRange = excSheet.get_Range("B1", "E" + (rowCount + 1));
            excRange.NumberFormat = "@";

            excRange = excSheet.get_Range("B1", "B1");
            excRange.ColumnWidth = 70;

            excRange = excSheet.get_Range("B2", "B2");
            excRange.Select();
            excExcel.ActiveWindow.FreezePanes = true;

            excRange = excSheet.get_Range("C1", "C1");
            excRange.ColumnWidth = 20;

            excRange = excSheet.get_Range("D1", "D1");
            excRange.ColumnWidth = 60;

            excRange = excSheet.get_Range("E1", "E1");
            excRange.ColumnWidth = 10;

            excRange = excSheet.get_Range("F1", "F1");
            excRange.ColumnWidth = 10;

            object[,] objData = new object[rowCount, 8];
            int r = 0;
            foreach (RepositoryDataSet.ViewGaspsOrganization item in data)
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

            excRange = excSheet.get_Range("A2", objOpt);
            excRange = excRange.get_Resize(rowCount, 8);
            excRange.Value = objData;
        }

        public static void ExportFgisEsnsiToExcel()
        {
            IEnumerable<Repositoryes.RepositoryDataSet.fgis_esnsiDataTable.FgisEsnsiOrganization> data = MasterDataSystem.DataSet.fgis_esnsi.ExportData();
            int rowCount = data.Count();

            Excel.Application excExcel = null;
            Excel.Workbooks excBooks = null;
            Excel._Workbook excBook = null;
            Excel.Sheets excSheets = null;
            Excel._Worksheet excSheet = null;
            Excel.Range excRange = null;

            object objOpt = Missing.Value;

            excExcel = new Excel.Application();

            excExcel.Visible = true;

            excBooks = excExcel.Workbooks;

            excBook = excBooks.Add(objOpt);
            excSheets = excBook.Worksheets;
            excSheet = (Excel._Worksheet)(excSheets.get_Item(1));
            excSheet.Name = "FED_GENPROK_ORGANIZATION_Cp1251";

            object[] objHeaders = { "id", "NAME", "REGION", "PHONE", "EMAIL", "ADDRESS", "OKATO", "CODE", "autokey" };
            excRange = excSheet.get_Range("A1", "I1");
            excRange.Value = objHeaders;

            object[,] objData = new object[rowCount, objHeaders.Count()];
            int r = 0;
            foreach (Repositoryes.RepositoryDataSet.fgis_esnsiDataTable.FgisEsnsiOrganization item in data)
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

            excRange = excSheet.get_Range("A2", objOpt);
            excRange = excRange.get_Resize(rowCount, objHeaders.Count());
            excRange.Value = objData;
        }

        public static void ExportFgisEsnsiToCsv(string path)
        {
            IEnumerable<Repositoryes.RepositoryDataSet.fgis_esnsiDataTable.FgisEsnsiOrganization> data = MasterDataSystem.DataSet.fgis_esnsi.ExportData();
            StreamWriter writer = new StreamWriter(path: path, append: false, encoding: Encoding.GetEncoding(1251));
            writer.WriteLine("id;NAME;REGION;PHONE;EMAIL;ADDRESS;OKATO;CODE;autokey");

            foreach (Repositoryes.RepositoryDataSet.fgis_esnsiDataTable.FgisEsnsiOrganization item in data)
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

        public static void ExportErvkToCsv(string path)
        {
            IEnumerable<RepositoryDataSet.ervkDataTable.ErvkOrganization> data = MasterDataSystem.DataSet.ervk.ExportData();
            StreamWriter writer = new StreamWriter(path: path, append: false, encoding: Encoding.GetEncoding(1251));
            writer.WriteLine("esnsiCode;title;isHead;special;military;isActive;idVersionProc;idVersionHead;dateStartVersion;dateCloseProc;ogrn;inn;subjectRfList;oktmoList;idSuccession;Родительский элемент");

            foreach (RepositoryDataSet.ervkDataTable.ErvkOrganization item in data)
            {
                string line = item.EsnsiCode + ";" +
                    item.Title.Replace("\r\n", string.Empty).Replace("\r", string.Empty).Trim() + ";" +
                    item.IsHead.ToString().ToLower() + ";" +
                    item.Special.ToString().ToLower() + ";" +
                    item.Military.ToString().ToLower() + ";" +
                    item.IsActive.ToString().ToLower() + ";" +
                    item.IdVersionProc.ToString() + ";" +
                    (item.IdVersionHead == 0 ? "1" : item.IdVersionHead.ToString()) + ";" +
                    item.DateStartVersion.ToString("dd.MM.yyyy") + ";" +
                    (item.DateCloseProc == MasterDataSystem.MAX_DATE ? string.Empty : item.DateCloseProc.ToString("dd.MM.yyyy")) + ";" +
                    item.Ogrn + ";" +
                    item.Inn + ";" +
                    item.SubjectRfList + ";" +
                    item.OktmoList + ";" +
                    (item.IdSuccession == 0 ? string.Empty : item.IdSuccession.ToString()) + ";" +
                    (item.IdVersionHead == 0 ? string.Empty : item.IdVersionHead.ToString());

                writer.WriteLine(line);
            }
            writer.Close();
            MessageBox.Show("Экспорт в формате CSV выполнен!");
        }


        public static void ExportErvkToExcel()
        {
            IEnumerable<RepositoryDataSet.ervkDataTable.ErvkOrganization> data = MasterDataSystem.DataSet.ervk.ExportData();
            int rowCount = data.Count();

            Excel.Application excExcel = null;
            Excel.Workbooks excBooks = null;
            Excel._Workbook excBook = null;
            Excel.Sheets excSheets = null;
            Excel._Worksheet excSheet = null;
            Excel.Range excRange = null;

            object objOpt = Missing.Value;

            // Start a new workbook in Excel.
            excExcel = new Excel.Application();

            excExcel.Visible = true;

            excBooks = excExcel.Workbooks;

            excBook = excBooks.Add(objOpt);
            excSheets = excBook.Worksheets;
            excSheet = (Excel._Worksheet)(excSheets.get_Item(1));
            excSheet.Name = "FED_GENPROK_ORGANIZATION_ERVK";

            object[] objHeaders = { "esnsiCode","title","isHead", "special", "military", "isActive", "idVersionProc",
                "idVersionHead", "dateStartVersion", "dateCloseProc", "ogrn", "inn", "subjectRfList", "oktmoList",
                "idSuccession", "Родительский элемент" };
            excRange = excSheet.get_Range("A1", "P1");
            excRange.Value = objHeaders;

            object[,] objData = new object[rowCount, objHeaders.Count()];
            int r = 0;
            foreach (RepositoryDataSet.ervkDataTable.ErvkOrganization item in data)
            {
                objData[r, 0] = item.EsnsiCode;
                objData[r, 1] = item.Title;
                objData[r, 2] = item.IsHead;
                objData[r, 3] = item.Special;
                objData[r, 4] = item.Military;
                objData[r, 5] = item.IsActive;
                objData[r, 6] = item.IdVersionProc;
                objData[r, 7] = item.IdVersionHead;
                objData[r, 8] = item.DateStartVersion;
                objData[r, 9] = item.DateCloseProc;
                objData[r, 10] = item.Ogrn;
                objData[r, 11] = item.Inn;
                objData[r, 12] = item.SubjectRfList;
                objData[r, 13] = item.OktmoList;
                objData[r, 14] = item.IdSuccession;
                objData[r, 15] = item.IdVersionHead;
                r += 1;
            }

            excRange = excSheet.get_Range("A2", objOpt);
            excRange = excRange.get_Resize(rowCount, objHeaders.Count());
            excRange.Value = objData;
        }

        public static void ExportStatisticToExcel()
        {
            Excel.Application excExcel = null;
            Excel.Workbooks excBooks = null;
            Excel._Workbook excBook = null;
            Excel.Sheets excSheets = null;
            Excel._Worksheet excSheet = null;
            Excel.Range excRange = null;

            object objOpt = Missing.Value;

            // Start a new workbook in Excel.
            excExcel = new Excel.Application();

            excExcel.Visible = true;

            excBooks = excExcel.Workbooks;

            excBook = excBooks.Add(objOpt);
            excSheets = excBook.Worksheets;
            excSheet = (Excel._Worksheet)(excSheets.get_Item(1));
            excSheet.Name = "Statistics";

            object[] objHeaders = { "Подразделение", "Окато", "Количество задействованных значений", "Количество свободный значений" };

            excRange = excSheet.get_Range("A1", "D1");
            excRange.Value = objHeaders;

            long rowCount = (MasterDataSystem.DataSet.authority.Count - 1) * MasterDataSystem.DataSet.okato.Count;

            object[,] objData = new object[rowCount, objHeaders.Count()];
            int r = 0;
            foreach (RepositoryDataSet.authorityRow authority in MasterDataSystem.DataSet.authority.Where(a => a.id != 5))
            {
                foreach (RepositoryDataSet.okatoRow okato in MasterDataSystem.DataSet.okato)
                {
                    IEnumerable<long> codes = MasterDataSystem.DataSet.gasps.GetUsedCodes(authority.id, okato.okato);
                    if (codes.Count() > 0)
                    {

                        decimal expenses;
                        if (okato.code.Length == 2)
                        {
                            expenses = 9999 - codes.Count();
                        }
                        else
                        {
                            expenses = 99 - codes.Count();
                        }


                        objData[r, 0] = authority.name;
                        objData[r, 1] = okato.name + " (" + okato.code + ")";
                        objData[r, 2] = codes.Count();
                        objData[r, 3] = expenses;

                        r += 1;
                    }
                }
            }

            excRange = excSheet.get_Range("A2", objOpt);
            excRange = excRange.get_Resize(rowCount, objHeaders.Count());
            excRange.Value = objData;
        }
    }
}
