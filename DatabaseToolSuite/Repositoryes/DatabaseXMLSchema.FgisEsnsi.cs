﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseToolSuite.Repositoryes
{
    partial class RepositoryDataSet
    {
        partial class fgis_esnsiDataTable
        {
            public bool ExistsRow(long gaspsVersion)
            {
                return (from item in this.AsEnumerable()
                        where item.RowState != DataRowState.Deleted &&
                        item.version == gaspsVersion
                        select item).Count() > 0;
            }

            public fgis_esnsiRow Get(long gaspsVersion)
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

            public fgis_esnsiRow Create(long gaspsVersion)
            {
                return (fgis_esnsiRow)this.Rows.Add(new object[] { gaspsVersion, null, null, null, null, null, null, null, null, null }); ;
            }

            public class FgisEsnsiOrganization
            {
                private FgisEsnsiOrganization() { }
                public long Version { get; protected set; }
                public long Id { get; }
                public string Name { get; }
                public string Region { get; }
                public string Phone { get; }
                public string Email { get; }
                public string Address { get; }
                public short Okato { get; }
                public long Code { get; }
                public string Autokey { get; }

                public DateTime EditDate { get; }

                public FgisEsnsiOrganization(
                    long version,
                    long id,
                    string name,
                    string region,
                    string phone,
                    string email,
                    string address,
                    short okato,
                    long code,
                    string autokey,
                    DateTime editDate)
                {
                    Version = version;
                    Id = id;
                    Name = name;
                    Region = region;
                    Phone = phone;
                    Email = email;
                    Address = address;
                    Okato = okato;
                    Code = code;
                    Autokey = autokey;
                    EditDate = editDate;
                }
            }

            public IEnumerable<FgisEsnsiOrganization> ExportData()
            {
                return from gasps in gaspsTable
                       where (gasps.authority_id == 20 && gasps.date_beg <= DateTime.Today &&
                       gasps.date_end > DateTime.Today)
                       join esnsi in this on gasps.version equals esnsi.version
                       join okato in okatoTable on gasps.okato_code equals okato.code
                       select new FgisEsnsiOrganization(
                           version: esnsi.version,
                           id: esnsi.IsidNull() ? 0 : esnsi.id,
                           name: gasps.name,
                           region: okato.Isname2Null() ? okato.name : okato.name2,
                           phone: esnsi.Issv_0004Null() ? string.Empty : esnsi.sv_0004,
                           email: esnsi.Issv_0005Null() ? string.Empty : esnsi.sv_0005,
                           address: esnsi.Issv_0006Null() ? string.Empty : esnsi.sv_0006,
                           okato: esnsi.IsokatoNull() ? (short)0 : esnsi.okato,
                           code: esnsi.IscodeNull() ? 0 : esnsi.code,
                           autokey: esnsi.IsautokeyNull() ? string.Empty : esnsi.autokey,
                           editDate: esnsi.IslogEditDateNull() ? Services.MasterDataSystem.MIN_DATE : esnsi.logEditDate);
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