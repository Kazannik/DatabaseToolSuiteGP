using System;
using DatabaseToolSuite.Services;

namespace DatabaseToolSuite.Utils
{
    static class Database
    {

        /// <summary>
        ///  Автозаполнение сведений журнала редактирования базы ГАС ПС
        /// </summary>
        public static void FillLogEditDateInGasps()
        {

            foreach (Repositoryes.RepositoryDataSet.gaspsRow row in MasterDataSystem.DataSet.gasps.Rows)
            {
                if (row.IslogEditDateNull())
                {
                    if (row.date_end < DateTime.Now)
                    {
                        row.logEditDate = row.date_end;
                    }
                    else if (row.date_beg >= DateTime.Now)
                    {
                        row.logEditDate = DateTime.Now;
                    }
                    else
                    {
                        row.logEditDate = row.date_beg;
                    }
                }
            }
        }


        /// <summary>
        /// Автозаполнение сведений журнала редактирования базы ФГИС ЕСНСИ
        /// </summary>
        public static void FillLogEditDateInFgisEsnsi()
        {
            foreach (Repositoryes.RepositoryDataSet.fgis_esnsiRow row in MasterDataSystem.DataSet.fgis_esnsi.Rows)
            {
                if (row.IslogEditDateNull())
                {
                    Repositoryes.RepositoryDataSet.gaspsRow gaspsRow = MasterDataSystem.DataSet.gasps.GetOrganizationFromVersion(row.version);
                    if (gaspsRow.IslogEditDateNull())
                    {
                        if (gaspsRow.date_end < DateTime.Now)
                        {
                            row.logEditDate = gaspsRow.date_end;
                        }
                        else if (gaspsRow.date_beg >= DateTime.Now)
                        {
                            row.logEditDate = DateTime.Now;
                        }
                        else
                        {
                            row.logEditDate = gaspsRow.date_beg;
                        }
                    }
                    else
                    {
                        row.logEditDate = gaspsRow.logEditDate;
                    }                   
                }
            }
        }

        /// <summary>
        /// Автозаполнение сведений журнала редактирования базы ЕРВК
        /// </summary>
        public static void FillLogEditDateInErvk()
        {
            foreach (Repositoryes.RepositoryDataSet.ervkRow row in MasterDataSystem.DataSet.ervk.Rows)
            {
                if (row.IslogEditDateNull())
                {
                    Repositoryes.RepositoryDataSet.gaspsRow gaspsRow = MasterDataSystem.DataSet.gasps.GetOrganizationFromVersion(row.version);
                    if (gaspsRow.IslogEditDateNull())
                    {
                        if (gaspsRow.date_end < DateTime.Now)
                        {
                            row.logEditDate = gaspsRow.date_end;
                        }
                        else if (gaspsRow.date_beg >= DateTime.Now)
                        {
                            row.logEditDate = DateTime.Now;
                        }
                        else
                        {
                            row.logEditDate = gaspsRow.date_beg;
                        }
                    }
                    else
                    {
                        row.logEditDate = gaspsRow.logEditDate;
                    }
                }
            }
        }

        /// <summary>
        /// Автоматическая расстановка атрибута IsHead о наличии подчиненных прокуратур в таблице ЕРВК.
        /// </summary>
        public static void SetIsHeadAttribute()
        {
            foreach (Repositoryes.RepositoryDataSet.ervkRow row in MasterDataSystem.DataSet.ervk.Rows)
            {
                if (MasterDataSystem.DataSet.ervk.ExistsIdVersionHead(row.esnsiCode))
                {
                    row.isHead = true;
                }
                else
                {
                    row.isHead = false;
                }              
            }
        }
    }
}
