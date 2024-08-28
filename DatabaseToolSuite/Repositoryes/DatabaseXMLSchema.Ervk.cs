using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseToolSuite.Repositoryes
{
    partial class RepositoryDataSet
    {
        partial class ervkDataTable
        {
            public bool ExistsRow(long gaspsVersion)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where item.RowState != DataRowState.Deleted &&
                        item.version == gaspsVersion
                        select item).Count() > 0;
            }

            public bool ExistsEsnsiCode(long esnsiCode)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where item.RowState != DataRowState.Deleted &&
                        item.esnsiCode == esnsiCode
                        select item).Count() > 0;
            }

            public bool ExistsInn(string inn)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where item.inn.Equals(inn, StringComparison.CurrentCultureIgnoreCase)
                        select item).Count() > 0;
            }

            public bool ExistsOgrn(string ogrn)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where item.ogrn.Equals(ogrn, StringComparison.CurrentCultureIgnoreCase)
                        select item).Count() > 0;
            }

            public bool ExistsIdVersionHead(long idVersionHead)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where (!item.IsidVersionHeadNull() && item.idVersionHead == idVersionHead) 
                        select item).Count() > 0;
            }

            public ervkRow Get(long gaspsVersion)
            {
                return this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Last(x => x.version == gaspsVersion);
            }

            public ervkRow GetFromEsnsiCode(long esnsiCode)
            {
                return this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Last(x => x.esnsiCode == esnsiCode);
            }
                       
            public void Romove(long gaspsVersion)
            {
                DataRow row = Get(gaspsVersion);
                row.Delete();
            }

                        
            public long GetNextEsnsiCode()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        .Max(r => r.esnsiCode);
                else
                    return 1;
            }

            public string GetNextVersionProc()
            {
                if (this.Count > 0)
                    return (1 + this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        .Max(r =>long.Parse(r.idVersionProc))).ToString();
                else
                    return (1).ToString();
            }
                       
                    
            public ervkRow Create(long gaspsVersion)
            {
                DateTime dateStartVersion = DateTime.Now;
                long esnsiCode = GetNextEsnsiCode();
                string idVersionProc = GetNextVersionProc();

                return (ervkRow)this.Rows.Add(new object[] { gaspsVersion, esnsiCode, null, null, null, null, idVersionProc, null, null, dateStartVersion, null, null, null, null, null, null }); ;
            }

            /// <summary>
            /// Запись справочника ЕРВК
            /// https://esnsi.gosuslugi.ru/classifiers/14531/hierarchical
            /// </summary>
            public class ErvkOrganization
            {
                private ErvkOrganization() { }

                /// <summary>
                /// Версия ГАС ПС
                /// </summary>
                public long Version { get; protected set; }

                /// <summary>
                /// ИД ЕСНСИ
                /// </summary>
                public long EsnsiCode { get; }

                /// <summary>
                /// Название органа прокуратуры в справочнике ЕРВК
                /// </summary>
                public string Title { get; }

                /// <summary>
                /// Признак, определяющий, что орган прокуратуры является головным
                /// </summary>
                public bool IsHead { get; }

                /// <summary>
                /// Специальная
                /// </summary>
                public bool Special { get; }

                /// <summary>
                /// Военная
                /// </summary>
                public bool Military { get; }

                /// <summary>
                /// Признак активности
                /// </summary>
                public bool IsActive { get; }

                /// <summary>
                /// ИД версии органа прокуратуры в ЕСНСИ
                /// </summary>
                public string IdVersionProc { get; }

                /// <summary>
                /// ИД ЕСНСИ вышестоящего органа прокуратуры (ссылка на esnsiCode)
                /// </summary>
                public long IdVersionHead { get; }

                /// <summary>
                /// ИД ЕСНСИ бывшего органа прокуратуры (ссылка на esnsiCode)
                /// </summary>
                public long IdSuccession { get; }

                /// <summary>
                /// Дата создания версии органа прокуратуры в ЕСНСИ
                /// </summary>
                public DateTime DateStartVersion { get; }

                /// <summary>
                /// Дата прекращения действия органа прокуратуры в ЕСНСИ
                /// </summary>
                public DateTime DateCloseProc { get; }

                /// <summary>
                /// ОГРН
                /// </summary>
                public string Ogrn { get; }

                /// <summary>
                /// ИНН
                /// </summary>
                public string Inn { get; }

                /// <summary>
                /// Субъект множественный
                /// </summary>
                public string SubjectRfList { get; }

                /// <summary>
                /// ОКТМО множественный
                /// </summary>
                public string OktmoList { get; }

                public ErvkOrganization(
                    long version,
                    long esnsiCode,
                    string title,
                    bool isHead,
                    bool special,
                    bool military,
                    bool isActive,
                    string idVersionProc,
                    long idVersionHead,
                    long idSuccession,
                    DateTime dateStartVersion,
                    DateTime dateCloseProc,
                    string ogrn,
                    string inn,
                    string subjectRfList,
                    string oktmoList)
                {
                    Version = version;
                    EsnsiCode = esnsiCode;
                    Title = title;
                    IsHead = isHead;
                    Special = special;
                    Military = military;
                    IsActive = isActive;
                    IdVersionProc = idVersionProc;
                    IdVersionHead = idVersionHead;
                    IdSuccession = idSuccession;
                    DateStartVersion = dateStartVersion;
                    DateCloseProc = dateCloseProc;
                    Ogrn = ogrn;
                    Inn = inn;
                    SubjectRfList = subjectRfList;
                    OktmoList = oktmoList;
                }
            }

            public IEnumerable<ErvkOrganization> ExportData()
            {
                return from ervk in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                       join gasps in gaspsTable on ervk.version equals gasps.version
                       select new ErvkOrganization(
                           version: ervk.version,
                           esnsiCode: ervk.esnsiCode,
                           title: gasps.name,
                           isHead: ervk.isHead,
                           special: ervk.special,
                           military: ervk.military,
                           isActive: ervk.isActive,
                           idVersionProc: ervk.idVersionProc,
                           idVersionHead: ervk.IsidVersionHeadNull() ? 0 :  ervk.idVersionHead,
                           idSuccession: ervk.IsidSuccessionNull() ? 0 : ervk.idSuccession,
                           dateStartVersion: ervk.dateStartVersion,
                           dateCloseProc: ervk.IsdateCloseProcNull() ? Services.MasterDataSystem.MAX_DATE : ervk.dateCloseProc,
                           ogrn: ervk.ogrn,
                           inn: ervk.inn,
                           subjectRfList: gasps.okatoRow.IsssrfNull() ? string.Empty :  gasps.okatoRow.ssrf + "," + gasps.okatoRow.name2,
                           oktmoList: gasps.okato_code.Substring(0,2).Equals("00") ? string.Empty : gasps.okato_code);
            }

            private gaspsDataTable gaspsTable
            {
                get { return Services.MasterDataSystem.DataSet.gasps; }
            }
            private okatoDataTable okatoTable
            {
                get { return Services.MasterDataSystem.DataSet.okato; }
            }
        }
    }
}