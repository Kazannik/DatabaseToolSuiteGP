using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace DatabaseToolSuite.Repositoryes
{
    partial class RepositoryDataSet
    {
        public IEnumerable<ViewFgisEsnsiOrganization> GetViewFgisEsnsiOrganizations()
        {
            EnumerableRowCollection<gaspsRow> gaspsCollection = gaspsTable.Where(e => e.RowState != DataRowState.Deleted);
            EnumerableRowCollection<gaspsRow> activeCollection = gaspsCollection.Where(e => e.date_end > DateTime.Today && e.date_beg <= DateTime.Today);
            EnumerableRowCollection<fgis_esnsiRow> fgisEsnsiCollection = fgisesnsiTable.Where(e => e.RowState != DataRowState.Deleted);

            return from gasps in gaspsCollection
                   join owner in activeCollection on gasps.owner_id equals owner.key into ow_jointable
                   from ow in ow_jointable.DefaultIfEmpty()
                   join esnsi in fgisEsnsiCollection on gasps.version equals esnsi.version into es_jointable
                   from es in es_jointable.DefaultIfEmpty()

                   select new ViewFgisEsnsiOrganization(gasps: gasps, owner: ow, esnsi: es);
        }

        public ViewErvkOrganization GetViewErvkOrganization(long version)
        {
            gaspsRow gasps = gaspsTable.GetOrganizationFromVersion(version);

            DateTime date = gasps.date_end > DateTime.Now ? DateTime.Now : gasps.date_end;
            gaspsRow gaspsOwner = gaspsTable.GetVersionOrganizationFromKeyDate(gasps.owner_id, date);
            fgis_esnsiRow esnsi = fgisesnsiTable.ExistsRow(version) ? fgisesnsiTable.Get(version) : null;
            ervkRow ervk = ervkTable.ExistsRow(version) ? ervkTable.Get(version) : null;

            return new ViewErvkOrganization(gasps: gasps, owner: gaspsOwner, esnsi: esnsi, ervk: ervk);
        }

        public IEnumerable<ViewErvkOrganization> GetViewErvkOrganizations()
        {
            EnumerableRowCollection<gaspsRow> gaspsCollection = gaspsTable.Where(e => e.RowState != DataRowState.Deleted);
            EnumerableRowCollection<gaspsRow> activeCollection = gaspsCollection.Where(e => e.date_end > DateTime.Today && e.date_beg <= DateTime.Today);
            EnumerableRowCollection<fgis_esnsiRow> fgisEsnsiCollection = fgisesnsiTable.Where(e => e.RowState != DataRowState.Deleted);
            EnumerableRowCollection<ervkRow> ervkCollection = ervkTable.Where(e => e.RowState != DataRowState.Deleted);

            return from gasps in gaspsCollection
                   join owner in activeCollection on gasps.owner_id equals owner.key into ow_jointable
                   from ow in ow_jointable.DefaultIfEmpty()
                   join esnsi in fgisEsnsiCollection on gasps.version equals esnsi.version into es_jointable
                   from es in es_jointable.DefaultIfEmpty()
                   join ervk in ervkCollection on gasps.version equals ervk.version into er_jointable
                   from er in er_jointable.DefaultIfEmpty()

                   select new ViewErvkOrganization(gasps: gasps, owner: ow, esnsi: es, ervk: er);
        }



        public IList<ViewFgisEsnsiOrganization> GetViewFgisEsnsiOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
        {
            return _GetViewFgisEsnsiOrganizationFilter(authority: authority,
                okato: okato,
                code: code,
                name: name,
                unlockShow: unlockShow,
                reserveShow: reserveShow,
                lockShow: lockShow).ToList();
        }

        private IEnumerable<ViewFgisEsnsiOrganization> _GetViewFgisEsnsiOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
        {
            IEnumerable<ViewFgisEsnsiOrganization> result = GetViewFgisEsnsiOrganizations()
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

        public IList<ViewErvkOrganization> GetViewErvkOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
        {
            return _GetViewErvkOrganizationFilter(authority: authority,
                okato: okato,
                code: code,
                name: name,
                unlockShow: unlockShow,
                reserveShow: reserveShow,
                lockShow: lockShow,
                fgisEsnsiOnlyShow: fgisEsnsiOnlyShow,
                ervkOnlyShow: ervkOnlyShow).ToList();
        }

        private IEnumerable<ViewErvkOrganization> _GetViewErvkOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
        {
            IEnumerable<ViewErvkOrganization> result = GetViewErvkOrganizations()
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

            if (fgisEsnsiOnlyShow)
            {
                result = result
                .Where(x => x.IsFgisEsnsi);
            }
            else if (ervkOnlyShow)
            {
                result = result
                .Where(x => x.IsErvk);
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

        public class ViewGaspsOrganization
        {
            [Description("Наименование подразделения (SV-0001)")]
            [Category("ГАС ПС")]
            [DisplayName("Наименование")]
            public string Name { get; private set; }

            [Description("Ведомство")]
            [Category("ГАС ПС")]
            [DisplayName("Ведомство")]
            public string Authority { get; private set; }

            [Description("Код ОКАТО")]
            [Category("ГАС ПС")]
            [DisplayName("ОКАТО")]
            public string Okato { get; private set; }

            [Description("Код подразделения")]
            [Category("ГАС ПС")]
            [DisplayName("Код подразделения")]
            public string Code { get; private set; }

            [Description("Дата начала действия подразделения")]
            [Category("ГАС ПС")]
            [DisplayName("Дата начала")]
            public DateTime Begin { get; private set; }

            [Description("Дата окончания действия подразделения")]
            [Category("ГАС ПС")]
            [DisplayName("Дата окончания")]
            public DateTime End { get; private set; }

            [Description("Уникальное значение версии записи")]
            [DisplayName("Версия записи")]
            public long Version { get; private set; }

            [Description("Наименование вышестоящей организации (владельца)")]
            [Category("ГАС ПС")]
            [DisplayName("Владелец")]
            public string OwnerName { get; private set; }

            [Browsable(false)]
            public long AuthorityId { get; private set; }

            [Browsable(false)]
            public string OkatoCode { get; private set; }

            [Description("Постоянный ключ записи, который не меняется при изменении версии записи")]
            [DisplayName("Ключ записи")]
            public long Key { get; private set; }

            [Description("Постоянный ключ записи вышестоящей организации, который не меняется при изменении версии записи")]
            [DisplayName("Ключ записи вышестоящей организации")]
            public long OwnerId { get; private set; }

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

            public ViewGaspsOrganization(gaspsRow gasps, gaspsRow owner) : this(
                name: gasps.name,
                authority: gasps.authorityRow.name,
                okato: gasps.okatoRow.code + " - " + (gasps.okatoRow.Isname2Null() ? gasps.okatoRow.name : gasps.okatoRow.name2),
                code: gasps.code,
                begin: gasps.date_beg,
                end: gasps.date_end,
                version: gasps.version,
                authorityId: gasps.authority_id,
                okatoCode: gasps.okato_code,
                key: gasps.key,
                ownerId: gasps.owner_id,
                ownerName: owner == null ? string.Empty : owner.name)
            {
            }
        }

        public class ViewFgisEsnsiOrganization : ViewGaspsOrganization
        {
            [Description("Телефон канцелярии (SV-0004)")]
            [Category("ФГИС ЕСНСИ")]
            [DisplayName("Телефон")]
            public string Phone { get; private set; }

            [Description("Электронный адрес канцелярии (SV-0005)")]
            [Category("ФГИС ЕСНСИ")]
            [DisplayName("Электронный адрес")]
            public string Email { get; private set; }

            [Description("Почтовый адрес где ведется прием граждан (SV-0006)")]
            [Category("ФГИС ЕСНСИ")]
            [DisplayName("Почтовый адрес")]
            public string Address { get; private set; }

            [Browsable(false)]
            public bool IsFgisEsnsi { get; private set; }

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
                string ownerName,
                bool isFgisEsnsi) : base(name, authority, okato, code, begin, end, version, authorityId, okatoCode, key, ownerId, ownerName)
            {
                Phone = phone;
                Email = email;
                Address = address;
                IsFgisEsnsi = isFgisEsnsi;
            }

            public ViewFgisEsnsiOrganization(
                string name,
                string authority,
                string okato,
                string code,
                DateTime begin,
                DateTime end,
                long version,
                long authorityId,
                string okatoCode,
                long key,
                long ownerId,
                string ownerName,
                fgis_esnsiRow esnsi) : base(name, authority, okato, code, begin, end, version, authorityId, okatoCode, key, ownerId, ownerName)
            {
                SetAttr(esnsi);
            }

            public ViewFgisEsnsiOrganization(
                gaspsRow gasps,
                gaspsRow owner,
                fgis_esnsiRow esnsi) : base(gasps: gasps, owner: owner)
            {
                SetAttr(esnsi);
            }


            private void SetAttr(fgis_esnsiRow esnsi)
            {
                if (esnsi != null)
                {
                    Phone = esnsi.Issv_0004Null() ? string.Empty : esnsi.sv_0004;
                    Email = esnsi.Issv_0005Null() ? string.Empty : esnsi.sv_0005;
                    Address = esnsi.Issv_0006Null() ? string.Empty : esnsi.sv_0006;
                    IsFgisEsnsi = true;
                }
            }
        }

        public class ViewErvkOrganization : ViewFgisEsnsiOrganization
        {
            [Description("ИД ЕСНСИ")]
            [Category("ЕРВК")]
            [DisplayName("ИД ЕСНСИ")]
            public long EsnsiCode { get; private set; }

            [Description("Признак, определяющий, что орган прокуратуры является головным")]
            [Category("ЕРВК")]
            [DisplayName("Головная прокуратура")]
            public bool IsHead { get; private set; }

            [Description("Признак, определяющий, что орган прокуратуры является специализированным")]
            [Category("ЕРВК")]
            [DisplayName("Спец.прокуратура")]
            public bool Special { get; private set; }

            [Description("Признак, определяющий, что орган прокуратуры является военным")]
            [Category("ЕРВК")]
            [DisplayName("Военная прокуратура")]
            public bool Military { get; private set; }

            [Description("Признак, определяющий, что запись является активной")]
            [Category("ЕРВК")]
            [DisplayName("Признак активности")]
            public bool IsActive { get; private set; }

            [Description("ИД версии органа прокуратуры в ЕСНСИ")]
            [Category("ЕРВК")]
            [DisplayName("ИД версии органа прокуратуры в ЕСНСИ")]
            public string IdVersionProc { get; private set; }

            [Description("ИД ЕСНСИ вышестоящего органа прокуратуры (ссылка на esnsiCode)")]
            [Category("ЕРВК")]
            [DisplayName("ИД ЕСНСИ вышестоящего органа прокуратуры")]
            public long IdVersionHead { get; private set; }

            [Description("ИД ЕСНСИ бывшего органа прокуратуры (ссылка на esnsiCode)")]
            [Category("ЕРВК")]
            [DisplayName("ИД ЕСНСИ бывшего органа прокуратуры")]
            public long IdSuccession { get; private set; }

            [Description("Дата создания версии органа прокуратуры в ЕСНСИ")]
            [Category("ЕРВК")]
            [DisplayName("Дата создания версии органа прокуратуры в ЕСНСИ")]
            public DateTime DateStartVersion { get; private set; }

            [Description("Дата прекращения действия органа прокуратуры в ЕСНСИ")]
            [Category("ЕРВК")]
            [DisplayName("Дата прекращения действия")]
            public DateTime DateCloseProc { get; private set; }

            [Description("ОГРН")]
            [Category("ЕРВК")]
            [DisplayName("ОГРН")]
            public string Ogrn { get; private set; }

            [Description("ИНН")]
            [Category("ЕРВК")]
            [DisplayName("ИНН")]
            public string Inn { get; private set; }

            [Browsable(false)]
            public bool IsErvk { get; private set; }

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
                long idSuccession,
                DateTime dateStartVersion,
                DateTime dateCloseProc,
                string ogrn,
                string inn,
                bool isFgisEsnsi,
                bool isErvk
                ) : base(name, authority, okato, code, begin, end, phone, email, address, version, authorityId, okatoCode, key, ownerId, ownerName, isFgisEsnsi)
            {
                EsnsiCode = esnsiCode;
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
                IsErvk = isErvk;
            }

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
               bool isFgisEsnsi,
               ervkRow ervk
               ) : base(name, authority, okato, code, begin, end, phone, email, address, version, authorityId, okatoCode, key, ownerId, ownerName, isFgisEsnsi)
            {
                SetAttr(ervk);
            }

            public ViewErvkOrganization(
               string name,
               string authority,
               string okato,
               string code,
               DateTime begin,
               DateTime end,
               long version,
               long authorityId,
               string okatoCode,
               long key,
               long ownerId,
               string ownerName,
               fgis_esnsiRow esnsi,
               ervkRow ervk
               ) : base(name, authority, okato, code, begin, end, version, authorityId, okatoCode, key, ownerId, ownerName, esnsi)
            {
                SetAttr(ervk);
            }

            public ViewErvkOrganization(
                gaspsRow gasps,
                gaspsRow owner,
                fgis_esnsiRow esnsi,
                ervkRow ervk
                ) : base(gasps, owner, esnsi)
            {
                SetAttr(ervk);
            }

            private void SetAttr(ervkRow ervk)
            {
                if (ervk != null)
                {
                    EsnsiCode = ervk.esnsiCode;
                    IsHead = ervk.isHead;
                    Special = ervk.special;
                    Military = ervk.military;
                    IsActive = ervk.isActive;
                    IdVersionProc = ervk.idVersionProc;
                    IdVersionHead = ervk.IsidVersionHeadNull() ? 0 : ervk.idVersionHead;
                    IdSuccession = ervk.IsidSuccessionNull() ? 0 : ervk.idSuccession;
                    DateStartVersion = ervk.dateStartVersion;
                    DateCloseProc = ervk.IsdateCloseProcNull() ? Services.MasterDataSystem.MAX_DATE : ervk.dateCloseProc;
                    Ogrn = ervk.IsogrnNull() ? string.Empty : ervk.ogrn;
                    Inn = ervk.IsinnNull() ? string.Empty : ervk.inn;
                    IsErvk = true;
                }
            }
        }
    }
}