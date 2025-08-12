// Ignore Spelling: Esnsi Urp Ervk Fgis Oktmo Loc Ord Ved Okato Ogrn Doesnt

using DatabaseToolSuite.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using urpRow = DatabaseToolSuite.Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		public IEnumerable<ViewFgisEsnsiOrganization> GetViewFgisEsnsiOrganizations()
		{
			EnumerableRowCollection<gaspsRow> gaspsCollection = GaspsTable.Where(e => e.RowState != DataRowState.Deleted);
			EnumerableRowCollection<gaspsRow> activeCollection = gaspsCollection.Where(e => e.date_end.Date > DateTime.Today && e.date_beg.Date <= DateTime.Today);
			EnumerableRowCollection<fgis_esnsiRow> fgisEsnsiCollection = FgisesnsiTable.Where(e => e.RowState != DataRowState.Deleted);

			return from gasps in gaspsCollection
				   join owner in activeCollection on gasps.owner_id equals owner.key into ow_jointable
				   from ow in ow_jointable.DefaultIfEmpty()
				   join esnsi in fgisEsnsiCollection on gasps.version equals esnsi.version into es_jointable
				   from es in es_jointable.DefaultIfEmpty()

				   select new ViewFgisEsnsiOrganization(gasps: gasps, owner: ow, esnsi: es);
		}

		public ViewErvkOrganization GetViewErvkOrganization(long version)
		{
			gaspsRow gasps = GaspsTable.GetOrganizationFromVersion(version);

			DateTime date = gasps.date_end.Date > DateTime.Today ? DateTime.Today : gasps.date_end.Date;
			gaspsRow gaspsOwner = gasps.owner_id != 0 ? GaspsTable.GetVersionOrganizationFromKeyDate(gasps.owner_id, date) : null;
			fgis_esnsiRow esnsi = FgisesnsiTable.Exists(version) ? FgisesnsiTable.Get(version) : null;
			ervkRow ervk = ErvkTable.Exists(version) ? ErvkTable.Get(version) : null;

			return new ViewErvkOrganization(gasps: gasps, owner: gaspsOwner, esnsi: esnsi, ervk: ervk);
		}

		public ViewUrpOrganization GetViewUrpOrganization(long version)
		{
			gaspsRow gasps = GaspsTable.GetOrganizationFromVersion(version);

			DateTime date = gasps.date_end.Date > DateTime.Today ? DateTime.Today : gasps.date_end.Date;
			gaspsRow gaspsOwner = gasps.owner_id != 0 ? GaspsTable.GetVersionOrganizationFromKeyDate(gasps.owner_id, date) : null;
			fgis_esnsiRow esnsi = FgisesnsiTable.Exists(version) ? FgisesnsiTable.Get(version) : null;
			ervkRow ervk = ErvkTable.Exists(version) ? ErvkTable.Get(version) : null;
			urpRow urp = UrpTable.Exists(version) ? UrpTable.Get(version) : null;

			return new ViewUrpOrganization(gasps: gasps, owner: gaspsOwner, esnsi: esnsi, ervk: ervk, urp: urp);
		}

		public IEnumerable<ViewErvkOrganization> GetViewErvkOrganizations()
		{
			EnumerableRowCollection<gaspsRow> gaspsCollection = GaspsTable.Where(e => e.RowState != DataRowState.Deleted);
			EnumerableRowCollection<gaspsRow> activeCollection = gaspsCollection.Where(e => e.date_end.Date > DateTime.Today && e.date_beg.Date <= DateTime.Today);
			EnumerableRowCollection<fgis_esnsiRow> fgisEsnsiCollection = FgisesnsiTable.Where(e => e.RowState != DataRowState.Deleted);
			EnumerableRowCollection<ervkRow> ervkCollection = ErvkTable.Where(e => e.RowState != DataRowState.Deleted);

			return from gasps in gaspsCollection
				   join owner in activeCollection on gasps.owner_id equals owner.key into ow_jointable
				   from ow in ow_jointable.DefaultIfEmpty()
				   join esnsi in fgisEsnsiCollection on gasps.version equals esnsi.version into es_jointable
				   from es in es_jointable.DefaultIfEmpty()
				   join ervk in ervkCollection on gasps.version equals ervk.version into er_jointable
				   from er in er_jointable.DefaultIfEmpty()

				   select new ViewErvkOrganization(gasps: gasps, owner: ow, esnsi: es, ervk: er);
		}

		public IEnumerable<ViewUrpOrganization> GetViewUrpOrganizations()
		{
			EnumerableRowCollection<gaspsRow> gaspsCollection = GaspsTable.Where(e => e.RowState != DataRowState.Deleted);
			EnumerableRowCollection<gaspsRow> activeCollection = gaspsCollection.Where(e => e.date_end.Date > DateTime.Today && e.date_beg.Date <= DateTime.Today);
			EnumerableRowCollection<fgis_esnsiRow> fgisEsnsiCollection = FgisesnsiTable.Where(e => e.RowState != DataRowState.Deleted);
			EnumerableRowCollection<ervkRow> ervkCollection = ErvkTable.Where(e => e.RowState != DataRowState.Deleted);
			EnumerableRowCollection<urpRow> urpCollection = UrpTable.Where(e => e.RowState != DataRowState.Deleted);

			return from gasps in gaspsCollection
				   join owner in activeCollection on gasps.owner_id equals owner.key into ow_jointable
				   from ow in ow_jointable.DefaultIfEmpty()
				   join esnsi in fgisEsnsiCollection on gasps.version equals esnsi.version into es_jointable
				   from es in es_jointable.DefaultIfEmpty()
				   join ervk in ervkCollection on gasps.version equals ervk.version into er_jointable
				   from er in er_jointable.DefaultIfEmpty()
				   join urp in urpCollection on gasps.version equals urp.VERSION into ur_jointable
				   from ur in ur_jointable.DefaultIfEmpty()

				   select new ViewUrpOrganization(gasps: gasps, owner: ow, esnsi: es, ervk: er, urp: ur);
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
				(x.End.Date < DateTime.Today
				|| x.Begin.Date >= DateTime.Today))
				);
			}

			if (!reserveShow)
			{
				result = result
				.Where(x => x.Begin.Date < DateTime.Today);
			}

			if (!lockShow)
			{
				result = result
				.Where(x => x.End.Date > DateTime.Today);
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

		public IList<ViewUrpOrganization> GetViewUrpOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
		{
			return _GetViewUrpOrganizationFilter(authority: authority,
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
				(x.End.Date < DateTime.Today
				|| x.Begin.Date >= DateTime.Today))
				);
			}

			if (!reserveShow)
			{
				result = result
				.Where(x => x.Begin.Date < DateTime.Today);
			}

			if (!lockShow)
			{
				result = result
				.Where(x => x.End.Date > DateTime.Today);
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

		private IEnumerable<ViewUrpOrganization> _GetViewUrpOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow, bool fgisEsnsiOnlyShow, bool ervkOnlyShow)
		{
			IEnumerable<ViewUrpOrganization> result = GetViewUrpOrganizations()
				.OrderBy(x => x.Version).OrderBy(x => x.Code);

			if (!unlockShow)
			{
				result = result
					.Where(x => (
				(x.End.Date < DateTime.Today
				|| x.Begin.Date >= DateTime.Today))
				);
			}

			if (!reserveShow)
			{
				result = result
				.Where(x => x.Begin.Date < DateTime.Today);
			}

			if (!lockShow)
			{
				result = result
				.Where(x => x.End.Date > DateTime.Today);
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

			[Description("Идентификатор GUID из АИК `Кадры` 1С")]
			[DisplayName("Идентификатор GUID")]
			public string Guid { get; private set; }

			[Description("Дата и время редактирования записи в базе данных")]
			[DisplayName("Дата и время редактирования")]
			public DateTime LogEditDate { get; private set; }

			private ViewGaspsOrganization(string name, string authority, string okato, string code, DateTime begin, DateTime end, long version, long authorityId, string okatoCode, long key, long ownerId, string ownerName, string guid, DateTime logEditDate)
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
				Guid = guid;
				LogEditDate = logEditDate;
			}

			public ViewGaspsOrganization(gaspsRow gasps, gaspsRow owner) : this(
				name: gasps.name,
				authority: gasps.authorityRow.name,
				okato: gasps.okatoRow.code + " - " + (gasps.okatoRow.Isname2Null() ? gasps.okatoRow.name : gasps.okatoRow.name2),
				code: gasps.IscodeNull() ? string.Empty : gasps.code,
				begin: gasps.date_beg,
				end: gasps.date_end,
				version: gasps.version,
				authorityId: gasps.authority_id,
				okatoCode: gasps.okato_code,
				key: gasps.key,
				ownerId: gasps.owner_id,
				ownerName: owner == null ? string.Empty : owner.name,
				guid: gasps.import_guid,
				logEditDate: gasps.logEditDate)
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

			private ViewFgisEsnsiOrganization(
				gaspsRow gasps,
				gaspsRow owner,
				string phone,
				string email,
				string address,
				bool isFgisEsnsi
				) : base(gasps: gasps, owner: owner)
			{
				Phone = phone;
				Email = email;
				Address = address;
				IsFgisEsnsi = isFgisEsnsi;
			}

			public ViewFgisEsnsiOrganization(
				gaspsRow gasps,
				gaspsRow owner,
				fgis_esnsiRow esnsi) : this(
					gasps: gasps,
					owner: owner,
					phone: esnsi == null || esnsi.Issv_0004Null() ? string.Empty : esnsi.sv_0004,
					email: esnsi == null || esnsi.Issv_0005Null() ? string.Empty : esnsi.sv_0005,
					address: esnsi == null || esnsi.Issv_0006Null() ? string.Empty : esnsi.sv_0006,
					isFgisEsnsi: esnsi != null)
			{ }
		}

		public class ViewErvkOrganization : ViewFgisEsnsiOrganization, IGaspsListViewItem
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

			[Description("ОКТМО")]
			[Category("ЕРВК")]
			[DisplayName("ОКТМО")]
			public string Oktmo { get; private set; }

			[Description("Субъект РФ")]
			[Category("ЕРВК")]
			[DisplayName("Субъект Российской Федерации")]
			public string Subject { get; private set; }

			private ViewErvkOrganization(
				gaspsRow gasps,
				gaspsRow owner,
				fgis_esnsiRow esnsi,
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
				string oktmo,
				string subject,
				bool isErvk
				) : base(gasps: gasps, owner: owner, esnsi: esnsi)
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
				Oktmo = oktmo;
				Subject = subject;
				IsErvk = isErvk;
			}

			public ViewErvkOrganization(
				gaspsRow gasps,
				gaspsRow owner,
				fgis_esnsiRow esnsi,
				ervkRow ervk
				) : this(
					gasps: gasps,
					owner: owner,
					esnsi: esnsi,
					esnsiCode: ervk == null ? 0 : ervk.esnsiCode,
					isHead: ervk != null && ervk.isHead,
					special: ervk != null && ervk.special,
					military: ervk != null && ervk.military,
					isActive: ervk != null && ervk.isActive,
					idVersionProc: ervk != null ? ervk.idVersionProc : string.Empty,
					idVersionHead: ervk == null || ervk.IsidVersionHeadNull() ? 0 : ervk.idVersionHead,
					idSuccession: ervk == null || ervk.IsidSuccessionNull() ? 0 : ervk.idSuccession,
					dateStartVersion: ervk != null ? ervk.dateStartVersion : Services.MasterDataSystem.MIN_DATE,
					dateCloseProc: ervk == null || ervk.IsdateCloseProcNull() ? Services.MasterDataSystem.MAX_DATE : ervk.dateCloseProc,
					ogrn: ervk == null || ervk.IsogrnNull() ? string.Empty : ervk.ogrn,
					inn: ervk == null || ervk.IsinnNull() ? string.Empty : ervk.inn,
					oktmo: ervk == null || ervk.IsoktmoListNull() ? string.Empty : ervk.oktmoList,
					subject: ervk == null || ervk.IssubjectRfListNull() ? string.Empty : ervk.subjectRfList,
					isErvk: ervk != null
					)
			{
			}
		}

		public class ViewUrpOrganization : ViewErvkOrganization
		{
			private const string CATEGORY = "УРП ГАС ПС";

			[Description("Краткое наименование")]
			[Category(CATEGORY)]
			[DisplayName("Краткое наименование")]
			public string ShortName { get; private set; }

			[Description("Не создаёт карточки ")]
			[Category(CATEGORY)]
			[DisplayName("Не создаёт карточки ")]
			public bool DoesntCreateCard { get; private set; }

			[Description("Не подписывает отчёт")]
			[Category(CATEGORY)]
			[DisplayName("Не подписывает отчёт")]
			public bool DoesntSingReport { get; private set; }

			[Description("Не консолидирует дочерние")]
			[Category(CATEGORY)]
			[DisplayName("Не консолидирует дочерние")]
			public bool DoesntConsolidateChild { get; private set; }

			[Description("Передаёт отчёт в")]
			[Category(CATEGORY)]
			[DisplayName("Подразделение, в которое передается отчет")]
			public long AgencyReceivingReport { get; private set; }

			[Description("Порядок")]
			[Category(CATEGORY)]
			[DisplayName("Порядок")]
			public long Ord { get; private set; }

			[Description("Ведомственный код")]
			[Category(CATEGORY)]
			[DisplayName("Ведомственный код")]
			public string VedCode { get; private set; }

			[Description("Ключ")]
			[Category(CATEGORY)]
			[DisplayName("Ключ")]
			public long Id { get; private set; }

			[Description("ОКТМО территории обслуживания")]
			[Category(CATEGORY)]
			[DisplayName("ОКТМО территории обслуживания ")]
			public long OktmoLocId { get; private set; }

			[Description("Тип подразделений")]
			[Category(CATEGORY)]
			[DisplayName("Тип подразделений")]
			public long LawAgencyType { get; private set; }

			[Description("Специализированный территориальный код ")]
			[Category(CATEGORY)]
			[DisplayName("Специализированный территориальный код ")]
			public long SpecialTerritorialCode { get; private set; }

			[Browsable(false)]
			public bool IsUrp { get; private set; }

			private ViewUrpOrganization(
				gaspsRow gasps,
				gaspsRow owner,
				fgis_esnsiRow esnsi,
				ervkRow ervk,
				string shortName,
				bool doesntCreateCard,
				bool doesntSingReport,
				bool doesntConsolidateChild,
				long agencyReceivingReport,
				long ord,
				string vedCode,
				long id,
				long oktmoLocId,
				long lawAgencyType,
				long specialTerritorialCode
				) : base(gasps: gasps, owner: owner, esnsi: esnsi, ervk: ervk)
			{
				ShortName = shortName;
				DoesntCreateCard = doesntCreateCard;
				DoesntSingReport = doesntSingReport;
				DoesntConsolidateChild = doesntConsolidateChild;
				AgencyReceivingReport = agencyReceivingReport;
				Ord = ord;
				VedCode = vedCode;
				Id = id;
				OktmoLocId = oktmoLocId;
				LawAgencyType = lawAgencyType;
				SpecialTerritorialCode = specialTerritorialCode;
			}

			public ViewUrpOrganization(
				gaspsRow gasps,
				gaspsRow owner,
				urpRow urp
				) : this(
					gasps: gasps,
					owner: owner,
					esnsi: null,
					ervk: null,
					urp: urp)
			{ }

			public ViewUrpOrganization(
				gaspsRow gasps,
				gaspsRow owner,
				fgis_esnsiRow esnsi,
				ervkRow ervk,
				urpRow urp
				) : this(
					gasps: gasps,
					owner: owner,
					esnsi: esnsi,
					ervk: ervk,
					shortName: urp != null ? urp.SHORT_NAME : string.Empty,
					doesntCreateCard: urp != null && urp.DOESNT_CREATE_CARD,
					doesntSingReport: urp != null && urp.DOESNT_SIGN_REPORT,
					doesntConsolidateChild: urp != null && urp.DOESNT_CONSOLIDATE_CHILD,
					agencyReceivingReport: urp != null ? urp.AGENCY_RECEIVING_REPORT : 0,
					ord: urp != null ? urp.ORD : 0,
					vedCode: urp != null ? urp.VED_CODE : string.Empty,
					id: urp != null ? urp.ID : 0,
					oktmoLocId: urp != null ? urp.OKTMO_LOC_ID : 0,
					lawAgencyType: urp != null ? urp.LAW_AGENCY_TYPE : 0,
					specialTerritorialCode: urp != null ? urp.SPECIAL_TERRITORIAL_CODE : 0)
			{
				IsUrp = urp != null;
			}
		}
	}
}