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
                        where item.RowState != DataRowState.Deleted &&
                        item.version == gaspsVersion
                        select item).Count() > 0;
            }

            public ervkRow Get(long gaspsVersion)
            {
                return this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Last(x => x.version == gaspsVersion);
            }

            public void Romove(long gaspsVersion)
            {
                DataRow row = Get(gaspsVersion);
                row.Delete();
            }


            public bool IsLastVersion(long version)
            {
                ervkRow current = GetOrganizationFromVersion(version);
                ervkRow last = GetLastVersionOrganizationFromCode(current.code);
                return version == last.version;
            }

            public long GetNextEsnsiCode()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable().Max(r => r.esnsiCode);
                else
                    return 1;
            }

            public long GetNextVersionProc()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable().Max(r =>long.Parse(r.idVersionProc));
                else
                    return 1;
            }
                       
                    
            public ervkRow Create(long gaspsVersion, long esnsiCode)
            {
                DateTime dateStartVersion = DateTime.Now;
                return (ervkRow)this.Rows.Add(new object[] { gaspsVersion, esnsiCode, null, null, null, null, null, null, dateStartVersion, null, null, null, null, null, null }); ;
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
                    bool isHead,
                    bool special,
                    bool military,
                    bool isActive,
                    string idVersionProc,
                    long idVersionHead,
                    DateTime dateStartVersion,
                    DateTime dateCloseProc,
                    string ogrn,
                    string inn,
                    string subjectRfList,
                    string oktmoList)
                {
                    Version = version;
                    EsnsiCode = esnsiCode;
                    IsHead = isHead;
                    Special = special;
                    Military = military;
                    IsActive = isActive;
                    IdVersionProc = idVersionProc;
                    IdVersionHead = idVersionHead;
                    DateStartVersion = dateStartVersion;
                    DateCloseProc = dateCloseProc;
                    Ogrn = ogrn;
                    Inn = inn;
                    SubjectRfList = subjectRfList;
                    OktmoList = oktmoList;
                }
            }

            //public IEnumerable<ErvkOrganization> ExportData()
            //{
            //    return from gasps in gaspsTable
            //           where (gasps.authority_id == 20 && gasps.date_beg <= DateTime.Today &&
            //           gasps.date_end > DateTime.Today)
            //           join ervk in this on gasps.version equals ervk.version
            //           join okato in okatoTable on gasps.okato_code equals okato.code
            //           select new ErvkOrganization(
            //               version: ervk.version,
            //               id: esnsi.IsidNull() ? 0 : esnsi.id,
            //               name: gasps.name,
            //               region: okato.Isname2Null() ? okato.name : okato.name2,
            //               phone: esnsi.Issv_0004Null() ? string.Empty : esnsi.sv_0004,
            //               email: esnsi.Issv_0005Null() ? string.Empty : esnsi.sv_0005,
            //               address: esnsi.Issv_0006Null() ? string.Empty : esnsi.sv_0006,
            //               okato: esnsi.IsokatoNull() ? (short)0 : esnsi.okato,
            //               code: esnsi.IscodeNull() ? 0 : esnsi.code,
            //               autokey: esnsi.IsautokeyNull() ? string.Empty : esnsi.autokey);
            //}

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