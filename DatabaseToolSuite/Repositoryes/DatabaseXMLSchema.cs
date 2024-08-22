using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;


namespace DatabaseToolSuite.Repositoryes
{

    partial class RepositoryDataSet
    {
        public bool ExistsCourtTypeId(Int64 id)
        {
            court_typeDataTable okato = (court_typeDataTable)this.Tables["court_type"];
            return court_type.ExistsId(id);
        }

        public bool ExistsCourtTypeName(string name)
        {
            court_typeDataTable okato = (court_typeDataTable)this.Tables["court_type"];
            return court_type.ExistsName(name);
        }

        public string GetCourtTypeName(Int64 id)
        {
            court_typeDataTable okato = (court_typeDataTable)this.Tables["court_type"];
            return court_type.GetName(id);
        }

        public bool ExistsOkatoCode(string code)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.ExistsCode(code);
        }

        public bool ExistsOkatoName(string name)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.ExistsName(name);
        }

        public bool ExistsOkatoName2(string name2)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.ExistsName2(name2);
        }

        public bool ExistsOkatoCentrum(string centrum)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.ExistsCentrum(centrum);
        }

        public bool ExistsOkatoGenitive(string genitive)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.ExistsGenitive(genitive);
        }

        public string GetOkatoName(string code)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.GetName(code);
        }

        public string GetOkatoName2(string code)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.GetName2(code);
        }

        public string GetOkatoGenitive(string code)
        {
            okatoDataTable okato = (okatoDataTable)this.Tables["okato"];
            return okato.GetGenitive(code);
        }


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

        partial class court_typeDataTable
        {
            public bool ExistsId(Int64 id)
            {
                return (from item in this.AsEnumerable()
                        where item.id == id
                        select item).Count() == 1;
            }

            public bool ExistsName(string name)
            {
                return (from item in this.AsEnumerable()
                        where item.name == name
                        select item).Count() == 1;
            }

            public string GetName(Int64 id)
            {
                return (from item in this.AsEnumerable()
                        where item.id == id
                        select item).First().name;
            }
        }

        partial class gaspsDataTable
        {
            public bool ExistsCode(string code)
            {
                return (from item in this.AsEnumerable()
                        where item.code.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                        select item).Count() > 0;
            }

            public bool ExistsName(string name, string okato)
            {
                return (from item in this.AsEnumerable()
                        where item.name.Equals(name, StringComparison.CurrentCultureIgnoreCase) &&
                        item.okato_code.Equals(okato, StringComparison.CurrentCultureIgnoreCase)
                        select item).Count() > 0;
            }

            public IEnumerable<long> GetVersionFromNameOkato(string name1, string name2, string name3, string okato)
            {
                return from item in this.AsEnumerable()
                       where (
                       item.name.Equals(name1, StringComparison.CurrentCultureIgnoreCase) ||
                       item.name.Equals(name2, StringComparison.CurrentCultureIgnoreCase) ||
                       item.name.Equals(name3, StringComparison.CurrentCultureIgnoreCase)
                       ) &&
                       item.okato_code.Equals(okato, StringComparison.CurrentCultureIgnoreCase)
                       select item.version;
            }

            public IList<gaspsRow> GetGaspsOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
            {
                return _GetGaspsOrganizationFilter(authority: authority,
                    okato: okato,
                    code: code,
                    name: name,
                    unlockShow: unlockShow,
                    reserveShow: reserveShow,
                    lockShow: lockShow).ToList();
            }

            private IEnumerable<gaspsRow> _GetGaspsOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
            {
                IEnumerable<gaspsRow> result = this.AsEnumerable()
                    .OrderBy(x => x.version).OrderBy(x => x.code);

                if (!unlockShow)
                {
                    result = result
                        .Where(x => (
                    (x.date_end < DateTime.Now || x.date_beg >= DateTime.Today))
                    );
                }

                if (!reserveShow)
                {
                    result = result
                    .Where(x => x.date_beg < DateTime.Today);
                }

                if (!lockShow)
                {
                    result = result
                    .Where(x => x.date_end > DateTime.Today);
                }

                if (authority.HasValue)
                {
                    result = result.Where(x => x.authority_id == authority.Value);
                }

                if (!string.IsNullOrWhiteSpace(okato))
                {
                    result = result.Where(x => x.okato_code.Equals(okato, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(code))
                {
                    result = result.Where(x => x.code.Contains(code));
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    result = result.Where(x => x.name.ToLower().Contains(name.ToLower()));
                }

                return result;
            }

            public IList<ViewFgisEsnsiOrganization> GetFgisEsnsiOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
            {
                return _GetFgisEsnsiOrganizationFilter(authority: authority,
                    okato: okato,
                    code: code,
                    name: name,
                    unlockShow: unlockShow,
                    reserveShow: reserveShow,
                    lockShow: lockShow).ToList();
            }

            private IEnumerable<ViewFgisEsnsiOrganization> _GetFgisEsnsiOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
            {
                IEnumerable<ViewFgisEsnsiOrganization> result = GetFgisEsnsiOrganizations()
                    .OrderBy(x => x.Version).OrderBy(x => x.Code);

                if (!unlockShow)
                {
                    result = result
                        .Where(x => (
                    (x.End < DateTime.Now || x.Begin >= DateTime.Today))
                    );
                }

                if (!reserveShow)
                {
                    result = result
                    .Where(x => x.Begin < DateTime.Today);
                }

                if (!lockShow)
                {
                    result = result
                    .Where(x => x.End > DateTime.Today);
                }

                if (authority.HasValue)
                {
                    result = result.Where(x => x.AuthorityId == authority.Value);
                }

                if (!string.IsNullOrWhiteSpace(okato))
                {
                    result = result.Where(x => x.OkatoCode.Equals(okato, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(code))
                {
                    result = result.Where(x => x.Code.Contains(code));
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }

                return result;
            }




            public IList<ViewErvkOrganization> GetErvkOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool ervkOnlyShow)
            {
                return _GetErvkOrganizationFilter(authority: authority,
                    okato: okato,
                    code: code,
                    name: name,
                    unlockShow: unlockShow,
                    reserveShow: reserveShow,
                    lockShow: lockShow,
                    ervkOnlyShow: ervkOnlyShow).ToList();
            }

            private IEnumerable<ViewErvkOrganization> _GetErvkOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool ervkOnlyShow)
            {
                IEnumerable<ViewErvkOrganization> result = GetErvkOrganizations()
                    .OrderBy(x => x.Version).OrderBy(x => x.Code);

                if (!unlockShow)
                {
                    result = result
                        .Where(x => (
                    (x.End < DateTime.Now || x.Begin >= DateTime.Today))
                    );
                }

                if (!reserveShow)
                {
                    result = result
                    .Where(x => x.Begin < DateTime.Today);
                }

                if (!lockShow)
                {
                    result = result
                    .Where(x => x.End > DateTime.Today);
                }

                if (authority.HasValue)
                {
                    result = result.Where(x => x.AuthorityId == authority.Value);
                }

                if (!string.IsNullOrWhiteSpace(okato))
                {
                    result = result.Where(x => x.OkatoCode.Equals(okato, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(code))
                {
                    result = result.Where(x => x.Code.Contains(code));
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }

                return result;
            }






            public IEnumerable<gaspsRow> GetOwnerOrganization()
            {
                return this.AsEnumerable().Where(x => x.owner_id == 0);
            }

            public DataView GetUnlockOrganization()
            {
                DataViewManager vm = new DataViewManager(this.DataSet);

                DataView dv = vm.CreateDataView(this);

                dv.RowFilter = string.Format("(date_beg <= {0} and date_end > {0}) or date_beg >= {0}", DateTime.Today.ToString("#MM-dd-yyyy#"));

                return dv;
            }

            public IList<gaspsRow> GetLockLastCodes(long? authority, string okato)
            {
                IEnumerable<gaspsRow> result = this.AsEnumerable()
                    .GroupBy(x => x.code, (key, g) => g.OrderByDescending(y => y.version).First())
                    .Where(x => x.date_end < DateTime.Today);

                if (authority.HasValue)
                {
                    result = result.Where(x => x.authority_id == authority.Value);
                }

                if (!string.IsNullOrWhiteSpace(okato))
                {
                    result = result.Where(x => x.okato_code.Equals(okato, StringComparison.OrdinalIgnoreCase));
                }

                return result.ToList();
            }

            public gaspsRow GetOrganizationFromVersion(long version)
            {
                return this.AsEnumerable()
                    .Last(x => x.version == version);
            }

            public gaspsRow GetLastVersionOrganizationFromKey(long key)
            {
                long version = this.AsEnumerable()
                    .Where(x => x.key.Equals(key)).Max(r => r.version);
                return GetOrganizationFromVersion(version);
            }

            public gaspsRow GetLastVersionOrganizationFromCode(string code)
            {
                long version = this.AsEnumerable()
                    .Where(x => x.code.Equals(code, StringComparison.CurrentCultureIgnoreCase)).Max(r => r.version);
                return GetOrganizationFromVersion(version);
            }

            public int GetEditedRowCount()
            {
                DateTime beginDate = new DateTime(2023, 01, 01);
                DateTime endDate = new DateTime(2023, 12, 31);
                return this.AsEnumerable()
                    .Where(x => (x.date_beg >= beginDate && x.date_beg <= endDate) || (x.date_end >= beginDate && x.date_end <= endDate))
                    .Count();
            }

            public string GetOrganizationName(long key, string defaultName)
            {
                try
                {
                    return GetLastVersionOrganizationFromKey(key).name;
                }
                catch (Exception)
                {
                    return defaultName;
                }
            }

            public bool IsLastVersion(long version)
            {
                gaspsRow current = GetOrganizationFromVersion(version);
                gaspsRow last = GetLastVersionOrganizationFromCode(current.code);
                return version == last.version;
            }

            public long GetNextKey()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable().Max(r => r.key);
                else
                    return 1;
            }

            public long GetNextVersion()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable().Max(r => r.version);
                else
                    return 1;
            }

            public long GetNextIndex()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable().Max(r => r.index);
                else
                    return 1;
            }

            public string GetNextCode(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);

                if (this.AsEnumerable()
                    .Where(r => r.authority_id == authority && r.okato_code == okato).Count() > 0)
                {
                    long code = 1 + this.AsEnumerable()
                    .Where(r => r.authority_id == authority && r.okato_code == okato).Max(r => long.Parse(r.code.Substring(leftCode.Length)));

                    if (code.ToString().Length > rightCodeFormat.Length)
                    {
                        throw new ArgumentOutOfRangeException(
                            string.Format("Диапазон кодов исчерпан. Присваемое значение {0} выходит за границы заданного диапазона (1-{1}).",
                            code, new string('9', rightCodeFormat.Length))
                            );
                    }
                    else
                    {
                        return leftCode + code.ToString(rightCodeFormat);
                    }
                }
                else
                {
                    return leftCode + (1).ToString(rightCodeFormat);
                }
            }

            public IEnumerable<long> GetSkippedCodes(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);
                List<long> codes = new List<long>(this.AsEnumerable()
                    .Where(r => r.authority_id == authority && r.okato_code == okato)
                    .Select(r => long.Parse(r.code.Substring(leftCode.Length)))
                    .Distinct());
                long length = rightCodeFormat.Length == 2 ? 99 : 9999;
                List<long> result = new List<long>();
                for (long i = 1; i < length; i++)
                {
                    if (!codes.Contains(i))
                    {
                        result.Add(i);
                    }
                }
                return result;
            }

            public string GetNextSkippedCode(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);
                long code = GetSkippedCodes(authority, okato).Min();
                return leftCode + code.ToString(rightCodeFormat);
            }

            public IEnumerable<long> GetUsedCodes(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);
                List<long> codes = new List<long>(this.AsEnumerable()
                    .Where(r => r.authority_id == authority && r.okato_code == okato)
                    .Select(r => long.Parse(r.code.Substring(leftCode.Length)))
                    .Distinct());
                codes.Sort();
                return codes;
            }

            public BindingList<gaspsRow> GetLockCodes(long authority, string okato, DateTime today)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);

                EnumerableRowCollection<gaspsRow> unlickCodes = from item in this.AsEnumerable()
                                                                where item.authority_id == authority &&
                                                                item.okato_code == okato &&
                                                                ((item.date_beg <= today &&
                                                                item.date_end > today) ||
                                                                item.date_beg > today)
                                                                orderby item.date_beg descending
                                                                select item;

                IEnumerable<gaspsRow> lockCodes = (from item in this.AsEnumerable()
                                                   where item.authority_id == authority &&
                                                   item.okato_code == okato &&
                                                   item.date_end <= today
                                                   orderby item.date_beg descending
                                                   select item).GroupBy(x => x.code).Select(y => y.FirstOrDefault());

                return new BindingList<gaspsRow>(lockCodes.Where(p => unlickCodes.All(p2 => p2.code != p.code)).OrderBy(x => x.code).ToArray());
            }

            public IEnumerable<ViewGaspsOrganization> ExportData()
            {
                return from item in this.AsEnumerable()
                       where (item.date_beg <= DateTime.Today &&
                       item.date_end > DateTime.Today)
                       join authority in authorityTable on item.authority_id equals authority.id
                       join okato in okatoTable on item.okato_code equals okato.code
                       join owner in this.AsEnumerable() on item.id equals owner.owner_id
                       select new ViewGaspsOrganization(
                           name: item.name,
                           authority: authority.name,
                           okato: okato.code + " - " + (okato.Isname2Null() ? okato.name : okato.name2),
                           code: item.code,
                           begin: item.date_beg,
                           end: item.date_end,
                           version: item.version,
                           authorityId: item.authority_id,
                           okatoCode: item.okato_code,
                           key: item.key,
                           ownerId: item.owner_id,
                           ownerName: owner.name);
            }

            public class ViewGaspsOrganization
            {
                [Description("Наименование подразделения (SV-0001)")]
                [Category("ГАС ПС")]
                [DisplayName("Наименование")]
                public string Name { get; }

                [Description("Ведомство")]
                [Category("ГАС ПС")]
                [DisplayName("Ведомство")]
                public string Authority { get; }

                [Description("Код ОКАТО")]
                [Category("ГАС ПС")]
                [DisplayName("ОКАТО")]
                public string Okato { get; }

                [Description("Код подразделения")]
                [Category("ГАС ПС")]
                [DisplayName("Код подразделения")]
                public string Code { get; }

                [Description("Дата начала действия подразделения")]
                [Category("ГАС ПС")]
                [DisplayName("Дата начала")]
                public DateTime Begin { get; }

                [Description("Дата окончания действия подразделения")]
                [Category("ГАС ПС")]
                [DisplayName("Дата окончания")]
                public DateTime End { get; }

                [Description("Уникальное значение версии записи")]
                [DisplayName("Версия записи")]
                public long Version { get; }

                [Description("Наименование вышестоящей организации (владельца)")]
                [Category("ГАС ПС")]
                [DisplayName("Владелец")]
                public string OwnerName { get; }

                [Browsable(false)]
                public long AuthorityId { get; }

                [Browsable(false)]
                public string OkatoCode { get; }

                public long Key { get; }

                public long OwnerId { get; }

                public ViewGaspsOrganization(string name, string authority, string okato, string code, DateTime begin, DateTime end, long version, long authorityId, string okatoCode, long key, long ownerId, string ownerName)
                {
                    Name = name;
                    Authority = authority;
                    Okato = okato;
                    Code = code;
                    Begin = begin;
                    End = end;
                    Version = version;
                    AuthorityId = authorityId;
                    OkatoCode = okatoCode;
                    Key = key;
                    OwnerId = ownerId;
                    OwnerName = ownerName;
                }
            }

            public class ViewFgisEsnsiOrganization : ViewGaspsOrganization
            {
                [Description("Телефон канцелярии (SV-0004)")]
                [Category("ФГИС ЕСНСИ")]
                [DisplayName("Телефон")]
                public string Phone { get; }

                [Description("Электронный адрес канцелярии (SV-0005)")]
                [Category("ФГИС ЕСНСИ")]
                [DisplayName("Электронный адрес")]
                public string Email { get; }

                [Description("Почтовый адрес где ведется прием граждан (SV-0006)")]
                [Category("ФГИС ЕСНСИ")]
                [DisplayName("Почтовый адрес")]
                public string Address { get; }

                public ViewFgisEsnsiOrganization(
                    string name,
                    string authority,
                    string okato,
                    string code,
                    DateTime begin,
                    DateTime end,
                    string phone,
                    string email,
                    string address,
                    long version,
                    long authorityId,
                    string okatoCode,
                    long key,
                    long ownerId,
                    string ownerName) : base(name, authority, okato, code, begin, end, version, authorityId, okatoCode, key, ownerId, ownerName)
                {
                    Phone = phone;
                    Email = email;
                    Address = address;
                }
            }

            public ViewFgisEsnsiOrganization GetFgisEsnsiOrganization(long version)
            {
                gaspsRow gasps = this.GetOrganizationFromVersion(version);
                string authority_name = authorityTable.GetName(gasps.authority_id);
                string okato_name = okatoTable.GetName2(gasps.okato_code);
                string ownerName = "TODO";
                fgis_esnsiRow esnsi = fgisesnsiTable.ExistsRow(version) ? fgisesnsiTable.Get(version) : null;

                return new ViewFgisEsnsiOrganization(
                           name: gasps.name,
                           authority: authority_name,
                           okato: gasps.okato_code + " - " + okato_name,
                           code: gasps.code,
                           begin: gasps.date_beg,
                           end: gasps.date_end,
                           phone: esnsi == null ? string.Empty : (esnsi.Issv_0004Null() ? string.Empty : esnsi.sv_0004),
                           email: esnsi == null ? string.Empty : (esnsi.Issv_0005Null() ? string.Empty : esnsi.sv_0005),
                           address: esnsi == null ? string.Empty : (esnsi.Issv_0006Null() ? string.Empty : esnsi.sv_0006),
                           version: gasps.version,
                           authorityId: gasps.authority_id,
                           okatoCode: gasps.okato_code,
                           key: gasps.key,
                           ownerId: gasps.owner_id,
                           ownerName: ownerName);
            }

            public IEnumerable<ViewFgisEsnsiOrganization> GetFgisEsnsiOrganizations()
            {
                EnumerableRowCollection<gaspsRow> gasps = this.Where(e => e.RowState != DataRowState.Deleted);
                EnumerableRowCollection<gaspsRow> active = gasps.Where(e => e.date_end > DateTime.Today && e.date_beg <= DateTime.Today);
                EnumerableRowCollection<fgis_esnsiRow> fgisEsnsi = fgisesnsiTable.Where(e => e.RowState != DataRowState.Deleted);

                return from row in gasps
                       join authority in authorityTable on row.authority_id equals authority.id
                       join okato in okatoTable on row.okato_code equals okato.code
                       join esnsi in fgisEsnsi on row.version equals esnsi.version into ps_jointable
                       join owner in active on row.owner_id equals owner.key
                       from p in ps_jointable.DefaultIfEmpty()

                       select new ViewFgisEsnsiOrganization(
                           name: row.name,
                           authority: authority.name,
                           okato: okato.code + " - " + (okato.Isname2Null() ? okato.name : okato.name2),
                           code: row.code,
                           begin: row.date_beg,
                           end: row.date_end,
                           phone: p == null ? string.Empty : (p.Issv_0004Null() ? string.Empty : p.sv_0004),
                           email: p == null ? string.Empty : (p.Issv_0005Null() ? string.Empty : p.sv_0005),
                           address: p == null ? string.Empty : (p.Issv_0006Null() ? string.Empty : p.sv_0006),
                           version: row.version,
                           authorityId: row.authority_id,
                           okatoCode: row.okato_code,
                           key: row.key,
                           ownerId: row.owner_id,
                           ownerName: owner.name);
            }
        


            public class ViewErvkOrganization : ViewFgisEsnsiOrganization
            {
                [Description("ИД ЕСНСИ")]
                [Category("ЕРВК")]
                [DisplayName("ИД ЕСНСИ")]
                public long EsnsiCode { get; }

                [Description("Признак, определяющий, что орган прокуратуры является головным")]
                [Category("ЕРВК")]
                [DisplayName("Головная прокуратура")]
                public bool IsHead { get; }

                [Description("Признак, определяющий, что орган прокуратуры является специализированным")]
                [Category("ЕРВК")]
                [DisplayName("Спец.прокуратура")]
                public bool Special { get; }

                [Description("Признак, определяющий, что орган прокуратуры является военным")]
                [Category("ЕРВК")]
                [DisplayName("Военная прокуратура")]
                public bool Military { get; }

                [Description("Признак, определяющий, что запись является активной")]
                [Category("ЕРВК")]
                [DisplayName("Признак активности")]
                public bool IsActive { get; }

                [Description("ИД версии органа прокуратуры в ЕСНСИ")]
                [Category("ЕРВК")]
                [DisplayName("ИД версии органа прокуратуры в ЕСНСИ")]
                public string IdVersionProc { get; }

                [Description("ИД ЕСНСИ вышестоящего органа прокуратуры (ссылка на esnsiCode)")]
                [Category("ЕРВК")]
                [DisplayName("ИД ЕСНСИ вышестоящего органа прокуратуры")]
                public long IdVersionHead { get; }

                [Description("Дата создания версии органа прокуратуры в ЕСНСИ")]
                [Category("ЕРВК")]
                [DisplayName("Дата создания версии органа прокуратуры в ЕСНСИ")]
                public DateTime DateStartVersion { get; }

                [Description("Дата прекращения действия органа прокуратуры в ЕСНСИ")]
                [Category("ЕРВК")]
                [DisplayName("Дата прекращения действия")]
                public DateTime DateCloseProc { get; }

                [Description("ОГРН")]
                [Category("ЕРВК")]
                [DisplayName("ОГРН")]
                public string Ogrn { get; }

                [Description("ИНН")]
                [Category("ЕРВК")]
                [DisplayName("ИНН")]
                public string Inn { get; }

              
                public ViewErvkOrganization(
                    string name,
                    string authority,
                    string okato,
                    string code,
                    DateTime begin,
                    DateTime end,
                    string phone,
                    string email,
                    string address,
                    long version,
                    long authorityId,
                    string okatoCode,
                    long key,
                    long ownerId,
                    string ownerName,
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
                    string inn                    
                    ) : base(name, authority, okato, code, begin, end, phone, email, address, version, authorityId, okatoCode, key, ownerId, ownerName)
                {
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
                }
            }

            public ViewErvkOrganization GetErvkOrganization(long version)
            {
                gaspsRow gasps = this.GetOrganizationFromVersion(version);
                string authority_name = authorityTable.GetName(gasps.authority_id);
                string okato_name = okatoTable.GetName2(gasps.okato_code);
                string ownerName = "TODO";
                fgis_esnsiRow esnsi = fgisesnsiTable.ExistsRow(version) ? fgisesnsiTable.Get(version) : null;
                ervkRow ervk = ervkTable.ExistsRow(version) ? ervkTable.Get(version) : null;

                return new ViewErvkOrganization(
                           name: gasps.name,
                           authority: authority_name,
                           okato: gasps.okato_code + " - " + okato_name,
                           code: gasps.code,
                           begin: gasps.date_beg,
                           end: gasps.date_end,
                           phone: esnsi == null ? string.Empty : (esnsi.Issv_0004Null() ? string.Empty : esnsi.sv_0004),
                           email: esnsi == null ? string.Empty : (esnsi.Issv_0005Null() ? string.Empty : esnsi.sv_0005),
                           address: esnsi == null ? string.Empty : (esnsi.Issv_0006Null() ? string.Empty : esnsi.sv_0006),
                           version: gasps.version,
                           authorityId: gasps.authority_id,
                           okatoCode: gasps.okato_code,
                           key: gasps.key,
                           ownerId: gasps.owner_id,
                           ownerName: ownerName,
                           esnsiCode: ervk.esnsiCode,
                           isHead: ervk.isHead,
                           special: ervk.special,
                           military: ervk.military,
                           isActive: ervk.isActive,
                           idVersionProc: ervk.IsidVersionProcNull() ? string.Empty : ervk.idVersionProc,
                           idVersionHead: ervk.IsidVersionHeadNull() ? 0 : ervk.idVersionHead,
                           dateStartVersion: ervk.dateStartVersion,
                           dateCloseProc: ervk.IsdateCloseProcNull() ?  DateTime.MaxValue : ervk.dateCloseProc,
                           ogrn: ervk.IsogrnNull() ? string.Empty : ervk.ogrn,
                           inn: ervk.IsinnNull() ? string.Empty : ervk.inn);
            }

            public IEnumerable<ViewErvkOrganization> GetErvkOrganizations()
            {
                EnumerableRowCollection<gaspsRow> rows = this.Where(e => e.RowState != DataRowState.Deleted);

                return from gasps in rows
                       join owner in rows on gasps.owner_id equals owner.id into owner_jointable
                       from o in owner_jointable.DefaultIfEmpty()
                       join authority in authorityTable on gasps.authority_id equals authority.id
                       join okato in okatoTable on gasps.okato_code equals okato.code
                       join esnsi in fgisesnsiTable.Where(e => e.RowState != DataRowState.Deleted) on gasps.version equals esnsi.version into ps_jointable
                       from p in ps_jointable.DefaultIfEmpty()
                       join ervk in ervkTable.Where(e => e.RowState != DataRowState.Deleted) on gasps.version equals ervk.version into es_jointable
                       from e in es_jointable.DefaultIfEmpty()

                       select new ViewErvkOrganization(
                           name: gasps.name,
                           authority: authority.name,
                           okato: okato.code + " - " + (okato.Isname2Null() ? okato.name : okato.name2),
                           code: gasps.code,
                           begin: gasps.date_beg,
                           end: gasps.date_end,
                           phone: p == null ? string.Empty : (p.Issv_0004Null() ? string.Empty : p.sv_0004),
                           email: p == null ? string.Empty : (p.Issv_0005Null() ? string.Empty : p.sv_0005),
                           address: p == null ? string.Empty : (p.Issv_0006Null() ? string.Empty : p.sv_0006),
                           version: gasps.version,
                           authorityId: gasps.authority_id,
                           okatoCode: gasps.okato_code,
                           key: gasps.key,
                           ownerId: gasps.owner_id,
                           ownerName: o.name,
                           esnsiCode: e == null ? 0 :  e.esnsiCode,
                           isHead: e == null ? false : e.isHead,
                           special: e == null ? false : e.special,
                           military: e == null ? false : e.military,
                           isActive: e == null ? false : e.isActive,
                           idVersionProc: e.idVersionProc,
                           idVersionHead: e.idVersionHead,
                           dateStartVersion: e.dateStartVersion,
                           dateCloseProc: e.dateCloseProc,
                           ogrn: e.ogrn,
                           inn: e.inn);
            }

            private authorityDataTable authorityTable
            {
                get { return Services.MasterDataSystem.DataSet.authority; }
            }

            private okatoDataTable okatoTable
            {
                get { return Services.MasterDataSystem.DataSet.okato; }
            }

            private fgis_esnsiDataTable fgisesnsiTable
            {
                get { return Services.MasterDataSystem.DataSet.fgis_esnsi; }
            }

            private ervkDataTable ervkTable
            {
                get { return Services.MasterDataSystem.DataSet.ervk; }
            }
        }

        partial class authorityDataTable
        {
            public bool ExistsId(Int64 id)
            {
                return (from item in this.AsEnumerable()
                        where item.id == id
                        select item).Count() == 1;
            }

            public bool ExistsName(string name)
            {
                return (from item in this.AsEnumerable()
                        where item.name == name
                        select item).Count() == 1;
            }

            public string GetName(Int64 id)
            {
                return (from item in this.AsEnumerable()
                        where item.id == id
                        select item).First().name;
            }
        }

        partial class okatoDataTable
        {

            public bool ExistsCode(string code)
            {
                return (from item in this.AsEnumerable()
                        where item.code == code
                        select item).Count() == 1;
            }

            public bool ExistsName(string name)
            {
                return (from item in this.AsEnumerable()
                        where item.name == name
                        select item).Count() == 1;
            }

            public bool ExistsName2(string name2)
            {
                return (from item in this.AsEnumerable()
                        where item.name2 == name2
                        select item).Count() == 1;
            }

            public bool ExistsCentrum(string centrum)
            {
                return (from item in this.AsEnumerable()
                        where item.centrum == centrum
                        select item).Count() == 1;
            }

            public bool ExistsGenitive(string genitive)
            {
                return (from item in this.AsEnumerable()
                        where item.genitive == genitive
                        select item).Count() == 1;
            }

            public string GetName(string code)
            {
                return (from item in this.AsEnumerable()
                        where item.code == code
                        select item).First().name;
            }

            public string GetName2(string code)
            {
                return (from item in this.AsEnumerable()
                        where item.code == code
                        select item).First().name2;
            }

            public string GetGenitive(string code)
            {
                return (from item in this.AsEnumerable()
                        where item.code == code
                        select item).First().genitive;
            }
        }

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

namespace DatabaseToolSuite.Repositoryes.RepositoryDataSetTableAdapters
{

    [DesignerCategoryAttribute("code")]
    [ToolboxItem(true)]
    [DataObject(true)]
    [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" +
        ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [HelpKeyword("vs.data.TableAdapter")]
    public partial class QueriesTableAdapter : Component
    {

        private IDbCommand[] _commandCollection;

        protected IDbCommand[] CommandCollection
        {
            get
            {
                if ((this._commandCollection == null))
                {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }

        private void InitCommandCollection()
        {
            this._commandCollection = new IDbCommand[1];
            this._commandCollection[0] = new System.Data.OleDb.OleDbCommand();
            ((System.Data.OleDb.OleDbCommand)(this._commandCollection[0])).CommandType = CommandType.Text;
        }

        [HelpKeyword("vs.data.TableAdapter")]
        public virtual object ScalarQuery()
        {
            System.Data.OleDb.OleDbCommand command = ((global::System.Data.OleDb.OleDbCommand)(this.CommandCollection[0]));
            ConnectionState previousConnectionState = command.Connection.State;
            if (((command.Connection.State & ConnectionState.Open)
                        != ConnectionState.Open))
            {
                command.Connection.Open();
            }
            object returnValue;
            try
            {
                returnValue = command.ExecuteScalar();
            }
            finally
            {
                if ((previousConnectionState == ConnectionState.Closed))
                {
                    command.Connection.Close();
                }
            }
            if (((returnValue == null)
                        || (returnValue.GetType() == typeof(DBNull))))
            {
                return null;
            }
            else
            {
                return ((object)(returnValue));
            }
        }
    }
}