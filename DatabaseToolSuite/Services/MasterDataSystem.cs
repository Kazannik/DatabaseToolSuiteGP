// Ignore Spelling: sv okato autokey dest doesnt Ervk Esnsi Fgis Loc ogrn oktmo ord Urp ved

using System;
using System.Collections.Generic;

namespace DatabaseToolSuite.Services
{
	/// <summary>
	/// Управление записями
	/// </summary>
	internal static class MasterDataSystem
	{
		public const long PROSECUTOR_CODE = 20;
		public static readonly DateTime MAX_DATE = new DateTime(2999, 12, 31);
		public static readonly DateTime MIN_DATE = new DateTime(1900, 1, 1);
		public static readonly DateTime ERVK_MIN_DATE = new DateTime(1899, 12, 31);
		public static readonly long[] RESERVE_CODES = new long[] { 3200 };

		public static Repositories.MainDataSet DataSet
		{
			get { return FileSystem.Repository.MainDataSet; }
		}

		/// <summary>
		/// Создание записи о подразделении правоохранительного органа в ГАС ПС
		/// </summary>
		/// <param name="name">Наименование подразделения.</param>
		/// <param name="key">Ключ подразделения. Не изменяется от версии к версии записи.</param>
		/// <param name="okato">Код ОКАТО.</param>
		/// <param name="authorityId">Индекс вида органа.</param>
		/// <param name="code">Код подразделения.</param>
		/// <param name="version">Уникальный "сквозной" код версии записи.</param>
		/// <param name="index">Код для сортировки (?). Не используется.</param>
		/// <param name="ownerKey">Ключ (key) родительского подразделения.</param>
		/// <param name="dateBegin">Дата введения в действие новой записи.</param>
		/// <param name="dateEnd">Дата окончания действия записи.</param>
		/// <param name="courtTypeId">Индекс вида суда.</param>
		/// <param name="import_guid">Индекс органа прокуратуры в формате GUID, полученный из файла 1С.</param>
		/// <param name="export_key">Ключ подразделения, присвоенный при экспортировании в файл ГАС ПС.</param>
		/// <param name="export_version">Код версии, присвоенный при экспортировании в файл ГАС ПС.</param>
		/// <returns></returns>
		private static Repositories.MainDataSet.gaspsRow CreateOrganization(
			string name,
			long key,
			string okato,
			long authorityId,
			string code,
			long? version,
			long index,
			long ownerKey,
			DateTime dateBegin,
			DateTime dateEnd,
			long courtTypeId,
			string import_guid,
			long? export_key,
			long? export_version)
		{
			object[] values = new object[18];
			values[0] = null; // id
			values[1] = name; // name
			values[2] = key; // key
			values[3] = okato; // okato_code
			values[4] = authorityId; // authority_id
			values[5] = code; // code
			values[6] = version; // version
			values[7] = index; // index
			values[8] = ownerKey; // owner_id
			values[9] = dateBegin; // date_beg
			values[10] = dateEnd; // date_end
			values[11] = null; // location_okato_id
			values[12] = null; // another_okato_id
			values[13] = 0; // court_type_id
			values[14] = DateTime.Now; // logEditDate
			values[15] = import_guid; // import_guid
			values[16] = export_key; // export_key
			values[17] = export_version; // export_version

			Repositories.MainDataSet.gaspsRow newRow = (Repositories.MainDataSet.gaspsRow)FileSystem.Repository.MainDataSet.gasps.Rows.Add(values);

			return newRow;
		}

		/// <summary>
		/// Создание записи о подразделении правоохранительного органа в ГАС ПС
		/// </summary>
		/// <param name="name">Наименование подразделения</param>
		/// <param name="okato">Код ОКАТО</param>
		/// <param name="authorityId">Индекс вида органа</param>
		/// <param name="code">Код подразделения</param>
		/// <param name="ownerKey">Ключ (key) родительского подразделения</param>
		/// <param name="dateBegin">Дата введения в действие новой записи</param>
		/// <param name="dateEnd">Дата окончания действия записи</param>
		/// <param name="courtTypeId">Индекс вида суда</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.gaspsRow CreateNewOrganization(
			string name,
			string okato,
			long authorityId,
			string code,
			long ownerKey,
			DateTime dateBegin,
			DateTime dateEnd,
			long courtTypeId)
		{
			long key = DataSet.gasps.GetNextKey();
			long version = DataSet.gasps.GetNextVersion();
			key = key >= version ? key : version;
			version = key;
			long index = DataSet.gasps.GetNextIndex();

			Repositories.MainDataSet.gaspsRow newRow = CreateOrganization(
						   name: name,
						   key: key,
						   okato: okato,
						   authorityId: authorityId,
						   code: code,
						   version: version,
						   index: index,
						   ownerKey: ownerKey,
						   dateBegin: dateBegin,
						   dateEnd: dateEnd,
						   courtTypeId: courtTypeId,
						   import_guid: null,
						   export_key: null,
						   export_version: null
						   );

			long id = DataSet.EXP_LAW_AGENCY_URP.GetNextId();
			long oktmo = 0;
			if (DataSet.okato.ExistsCode(okato))
			{
				oktmo = DataSet.okato.Get(okato).export_id;
			}

			CreateUrpNote(
					version: version,
					shortName: name,
					doesntCreateCard: false,
					doesntSingReport: false,
					doesntConsolidateChild: false,
					agencyReceivingReport: 0,
					ord: 0,
					vedCode: "0",
					id: id,
					oktmoLocId: oktmo,
					lawAgencyType: 0,
					specialTerritorialCode: 0);

			return newRow;
		}

		/// <summary>
		/// Создание записи о подразделении органа прокуратуры в ГАС ПС.
		/// </summary>
		/// <param name="parentVersion">Уникальный "сквозной" код версии записи родительского органа прокуратуры.</param>
		/// <param name="date">Дата введения в действие новой версии</param>
		/// <param name="name">Наименование подразделения органа прокуратуры.</param>
		/// <param name="guid">Индекс органа прокуратуры в формате GUID, полученный из файла 1С.</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.gaspsRow CreateNewOrganization(long parentVersion, DateTime date, string name, string guid)
		{
			Repositories.MainDataSet.gaspsRow parentRow = DataSet.gasps.GetOrganizationFromVersion(version: parentVersion);

			return CreateNewOrganization(parentRow, date, name, guid);
		}

		/// <summary>
		/// Создание записи о подразделении органа прокуратуры в ГАС ПС.
		/// </summary>
		/// <param name="parentRow">Запись родительского органа прокуратуры.</param>
		/// <param name="date">Дата введения в действие новой версии</param>
		/// <param name="name">Наименование подразделения органа прокуратуры.</param>
		/// <param name="guid">Индекс органа прокуратуры в формате GUID, полученный из файла 1С.</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.gaspsRow CreateNewOrganization(Repositories.MainDataSet.gaspsRow parentRow, DateTime date, string name, string guid)
		{
			if (!string.IsNullOrWhiteSpace(guid)
				&& DataSet.gasps.ExistsGuid(guid))
			{
				return DataSet.gasps.GetOrganizationFromGuid(guid);
			}
			else
			{
				long key = DataSet.gasps.GetNextKey();
				long version = DataSet.gasps.GetNextVersion();
				key = key >= version ? key : version;
				version = key;
				long index = DataSet.gasps.GetNextIndex();

				Repositories.MainDataSet.gaspsRow newRow = CreateOrganization(
							   name: name,
							   key: key,
							   okato: parentRow.okato_code,
							   authorityId: PROSECUTOR_CODE,
							   code: null,
							   version: version,
							   index: index,
							   ownerKey: parentRow.key,
							   dateBegin: date,
							   dateEnd: MAX_DATE,
							   courtTypeId: parentRow.court_type_id,
							   import_guid: guid,
							   export_key: null,
							   export_version: null
							   );

				long id = DataSet.EXP_LAW_AGENCY_URP.GetNextId();
				CreateUrpNote(
					version: version,
					shortName: name,
					doesntCreateCard: false,
					doesntSingReport: false,
					doesntConsolidateChild: false,
					agencyReceivingReport: 0,
					ord: 0,
					vedCode: "0",
					id: id,
					oktmoLocId: parentRow.okatoRow.export_id,
					lawAgencyType: 0,
					specialTerritorialCode: 0);

				return newRow;
			}
		}

		/// <summary>
		/// Создание новой версии записи о подразделении правоохранительного органа в ГАС ПС
		/// </summary>
		/// <param name="version">Индекс версии</param>
		/// <param name="date">Дата введения в действие новой версии</param>
		/// <param name="name">Наименование подразделения</param>
		/// <param name="okato">Код ОКАТО</param>
		/// <param name="authorityId">Индекс вида органа</param>
		/// <param name="ownerKey">Ключ (key) родительского подразделения</param>
		/// <param name="courtTypeId">Индекс вида суда</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.gaspsRow CreateNewVersionOrganization(
			long version,
			DateTime date,
			string name,
			string okato,
			long authorityId,
			long ownerKey,
			long courtTypeId)
		{
			Repositories.MainDataSet.gaspsRow modifedRow = DataSet.gasps.GetOrganizationFromVersion(version: version);

			if (!DataSet.gasps.IsLastVersion(version: version))
			{
				throw new ArgumentException(string.Format(
					"Запись версии {0} не является самой последней записью с ключом {1}, поэтому не может быть отредактирована.",
							version, modifedRow.key));
			}

			modifedRow.date_end = date;
			modifedRow.logEditDate = DateTime.Now;

			long newVersion = DataSet.gasps.GetNextVersion();

			Repositories.MainDataSet.gaspsRow newRow = CreateOrganization(
				name: name,
				key: modifedRow.key,
				okato: okato,
				authorityId: authorityId,
				code: modifedRow.IscodeNull() ? null : modifedRow.code,
				version: newVersion,
				index: modifedRow.IsindexNull() ? 0 : modifedRow.index,
				ownerKey: ownerKey,
				dateBegin: date,
				dateEnd: MAX_DATE,
				courtTypeId: courtTypeId,
				import_guid: modifedRow.import_guid,
				export_key: null,
				export_version: null);

			if (modifedRow.authority_id == PROSECUTOR_CODE)
			{
				if (DataSet.fgis_esnsi.Exists(modifedRow.version))
				{
					CloneFgisEsnsiNote(modifedRow.version, newVersion);
				}
				if (DataSet.ervk.Exists(modifedRow.version))
				{
					CloneErvkNote(modifedRow.version, newVersion);
					DataSet.ervk.Get(modifedRow.version).isActive = false;
					DataSet.ervk.Get(modifedRow.version).logEditDate = DateTime.Now;
				}
				if (DataSet.EXP_LAW_AGENCY_URP.Exists(modifedRow.version))
				{
					CloneUrpNote(modifedRow.version, newVersion);
				}
			}

			return newRow;
		}

		/// <summary>
		/// Создание новой версии записи о подразделении правоохранительного органа в ГАС ПС
		/// </summary>
		/// <param name="version">Индекс версии</param>
		/// <param name="date">Дата введения в действие новой версии</param>
		/// <param name="name">Наименование подразделения</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.gaspsRow CreateNewVersionOrganization(
			long version,
			DateTime date,
			string name)
		{
			Repositories.MainDataSet.gaspsRow modifedRow = DataSet.gasps.GetOrganizationFromVersion(version: version);

			if (!DataSet.gasps.IsLastVersion(version: version))
			{
				throw new ArgumentException(string.Format(
					"Запись версии {0} не является самой последней записью с ключем {1}, поэтому не может быть отредактирована.",
							version, modifedRow.key));
			}

			modifedRow.date_end = date;
			modifedRow.logEditDate = DateTime.Now;

			long newVersion = DataSet.gasps.GetNextVersion();

			Repositories.MainDataSet.gaspsRow newRow = CreateOrganization(
				name: name,
				key: modifedRow.key,
				okato: modifedRow.okato_code,
				authorityId: modifedRow.authority_id,
				code: modifedRow.IscodeNull() ? null : modifedRow.code,
				version: newVersion,
				index: modifedRow.IsindexNull() ? 0 : modifedRow.index,
				ownerKey: modifedRow.owner_id,
				dateBegin: date,
				dateEnd: MAX_DATE,
				courtTypeId: modifedRow.court_type_id,
				import_guid: modifedRow.import_guid,
				export_key: null,
				export_version: null);

			if (modifedRow.authority_id == PROSECUTOR_CODE)
			{
				if (DataSet.fgis_esnsi.Exists(modifedRow.version))
				{
					CloneFgisEsnsiNote(modifedRow.version, newVersion);
				}

				if (DataSet.ervk.Exists(modifedRow.version))
				{
					CloneErvkNote(modifedRow.version, newVersion);
					DataSet.ervk.Get(modifedRow.version).isActive = false;
					DataSet.ervk.Get(modifedRow.version).logEditDate = DateTime.Now;
				}

				if (DataSet.EXP_LAW_AGENCY_URP.Exists(modifedRow.version))
				{
					CloneUrpNote(modifedRow.version, newVersion);
				}
			}
			return newRow;
		}

		/// <summary>
		/// Блокировка записи о подразделении правоохранительного органа в ГАС ПС
		/// </summary>
		/// <param name="version">Индекс версии</param>
		/// <param name="date">Дата блокировки</param>
		public static void RemoveOrganization(long version, DateTime date)
		{
			Repositories.MainDataSet.gaspsRow oldRow = DataSet.gasps.GetOrganizationFromVersion(version: version);

			IEnumerable<Repositories.MainDataSet.gaspsRow> childRows = DataSet.gasps.GetGaspsChildOrganization(oldRow.key, date);

			foreach (Repositories.MainDataSet.gaspsRow row in childRows)
			{
				RemoveOrganization(row.version, date);
			}

			oldRow.BeginEdit();
			oldRow.date_end = date;
			oldRow.logEditDate = DateTime.Now;
			oldRow.EndEdit();

			if (DataSet.ervk.Exists(version))
			{
				DataSet.ervk.Get(version).isActive = false;
				DataSet.ervk.Get(version).logEditDate = DateTime.Now;
			}
		}

		/// <summary>
		/// Правка записи о подразделении правоохранительного органа в ГАС ПС
		/// </summary>
		/// <param name="version">Индекс версии</param>
		/// <param name="date">Дата введения в действие новой версии</param>
		/// <param name="name">Наименование подразделения</param>
		/// <param name="okato">Код ОКАТО</param>
		/// <param name="authorityId">Индекс вида органа</param>
		/// <param name="ownerKey">Ключ (key) родительского подразделения</param>
		/// <param name="courtTypeId">Индекс вида суда</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.gaspsRow EditVersionOrganization(
			long version,
			DateTime date,
			string name,
			string okato,
			long authorityId,
			long ownerKey,
			long courtTypeId)
		{
			Repositories.MainDataSet.gaspsRow errorRow = DataSet.gasps.GetOrganizationFromVersion(version: version);

			errorRow.date_beg = date;
			errorRow.name = name;
			errorRow.okato_code = okato;
			errorRow.authority_id = authorityId;
			errorRow.owner_id = ownerKey;
			errorRow.date_end = MAX_DATE;
			errorRow.logEditDate = DateTime.Now;

			return errorRow;
		}

		public static Repositories.MainDataSet.gaspsRow ClearCodeVersionOrganization(
		   long version)
		{
			Repositories.MainDataSet.gaspsRow row = DataSet.gasps.GetOrganizationFromVersion(version: version);
			row.logEditDate = DateTime.Now;
			row.SetcodeNull();
			return row;
		}

		/// <summary>
		/// Создание записи ФГИС ЕСНСИ
		/// </summary>
		/// <param name="version">Версия. Поле для связи gasps и fgis_esnsi</param>
		/// <param name="region_id">Индекс региона</param>
		/// <param name="sv_0004">Телефон</param>
		/// <param name="sv_0005">Электронный адрес</param>
		/// <param name="sv_0006">Почтовый адрес</param>
		/// <param name="okato">ОКАТО</param>
		/// <param name="code">Служебный код</param>
		/// <param name="autokey">Составной ключ</param>
		/// <param name="id">Ключ записи</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.fgis_esnsiRow CreateFgisEsnsiNote(
			long version,
			long region_id,
			string sv_0004,
			string sv_0005,
			string sv_0006,
			short okato,
			long code,
			string autokey,
			long id)
		{
			object[] values = new object[10];
			values[0] = version;
			values[1] = region_id;
			values[2] = sv_0004;
			values[3] = sv_0005;
			values[4] = sv_0006;
			values[5] = okato;
			values[6] = code;
			values[7] = autokey;
			values[8] = id;
			values[9] = DateTime.Now;

			Repositories.MainDataSet.fgis_esnsiRow newRow = (Repositories.MainDataSet.fgis_esnsiRow)FileSystem.Repository.MainDataSet.fgis_esnsi.Rows.Add(values);
			return newRow;
		}

		/// <summary>
		/// Клонирование записи ФГИС ЕСНСИ из заданной записи в последнюю запись.
		/// </summary>
		/// <param name="currentVersion">Выбранная запись.</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.fgis_esnsiRow CloneFgisEsnsiNoteToLastVersion(long currentVersion)
		{
			Repositories.MainDataSet.gaspsRow currentGaspsRow = DataSet.gasps.GetOrganizationFromVersion(version: currentVersion);
			Repositories.MainDataSet.gaspsRow lastGaspsRow = DataSet.gasps.GetLastVersionOrganizationFromKey(currentGaspsRow.key);

			return CloneFgisEsnsiNote(currentGaspsRow.version, lastGaspsRow.version);
		}

		/// <summary>
		/// Клонирование записи ФГИС ЕСНСИ
		/// </summary>
		/// <param name="sourceVersion">Версия записи источника.</param>
		/// <param name="destVersion">Версия записи назначения</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.fgis_esnsiRow CloneFgisEsnsiNote(long sourceVersion, long destVersion)
		{
			if (!DataSet.fgis_esnsi.Exists(destVersion))
			{
				Repositories.MainDataSet.fgis_esnsiRow currentFgisEsnsiRow = DataSet.fgis_esnsi.Get(sourceVersion);
				return CreateFgisEsnsiNote(
				version: destVersion,
				region_id: currentFgisEsnsiRow.Isregion_idNull() ? 0 : currentFgisEsnsiRow.region_id,
				sv_0004: currentFgisEsnsiRow.Issv_0004Null() ? null : currentFgisEsnsiRow.sv_0004,
				sv_0005: currentFgisEsnsiRow.Issv_0005Null() ? null : currentFgisEsnsiRow.sv_0005,
				sv_0006: currentFgisEsnsiRow.Issv_0006Null() ? null : currentFgisEsnsiRow.sv_0006,
				okato: currentFgisEsnsiRow.IsokatoNull() ? (short)0 : currentFgisEsnsiRow.okato,
				code: currentFgisEsnsiRow.IscodeNull() ? 0 : currentFgisEsnsiRow.code,
				autokey: currentFgisEsnsiRow.IsautokeyNull() ? null : currentFgisEsnsiRow.autokey,
				id: currentFgisEsnsiRow.IsidNull() ? 0 : currentFgisEsnsiRow.id);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Редактирование записи ФГИС ЕСНСИ
		/// </summary>
		/// <param name="version">Версия. Поле для связи gasps и fgis_esnsi</param>
		/// <param name="region_id">Индекс региона</param>
		/// <param name="sv_0004">Телефон</param>
		/// <param name="sv_0005">Электронный адрес</param>
		/// <param name="sv_0006">Почтовый адрес</param>
		/// <param name="okato">ОКАТО</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.fgis_esnsiRow EditVersionFgisEsnsiNote(
			long version,
			long region_id,
			string sv_0004,
			string sv_0005,
			string sv_0006,
			short okato)
		{
			Repositories.MainDataSet.fgis_esnsiRow errorRow = DataSet.fgis_esnsi.Get(gaspsVersion: version);

			errorRow.region_id = region_id;
			errorRow.sv_0004 = sv_0004;
			errorRow.sv_0005 = sv_0005;
			errorRow.sv_0006 = sv_0006;
			errorRow.okato = okato;
			errorRow.logEditDate = DateTime.Now;

			return errorRow;
		}

		/// <summary>
		/// Создание записи ЕРВК
		/// </summary>
		/// <param name="version">Версия. Поле для связи gasps и ervk</param>
		/// <param name="esnsiCode">ИД ЕСНСИ</param>
		/// <param name="isHead">isHead</param>
		/// <param name="special">Специальная</param>
		/// <param name="military">Военная</param>
		/// <param name="isActive">Признак активности</param>
		/// <param name="idVersionProc">ИД версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="idVersionHead">ИД ЕСНСИ вышестоящего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="idSuccession">ИД ЕСНСИ бывшего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="dateStartVersion">Дата создания версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="dateCloseProc">Дата прекращения действия органа прокуратуры в ЕСНСИ</param>
		/// <param name="ogrn">ОГРН</param>
		/// <param name="inn">ИНН</param>
		/// <param name="subjectRfList">Субъект множественный</param>
		/// <param name="oktmoList">ОКТМО множественный</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.ervkRow CreateErvkNote(
			long version,
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
			string subjectRfList,
			string oktmoList
			)
		{
			object[] values = new object[16];
			values[0] = version;
			values[1] = esnsiCode;
			values[2] = isHead;
			values[3] = special;
			values[4] = military;
			values[5] = isActive;
			values[6] = idVersionProc;
			values[7] = idVersionHead;
			values[8] = idSuccession;
			values[9] = dateStartVersion;
			values[10] = DateTime.MaxValue.Equals(dateCloseProc) ? null : (object)dateCloseProc;
			values[11] = ogrn;
			values[12] = inn;
			values[13] = subjectRfList;
			values[14] = oktmoList;
			values[15] = DateTime.Now;

			Repositories.MainDataSet.ervkRow newRow = (Repositories.MainDataSet.ervkRow)FileSystem.Repository.MainDataSet.ervk.Rows.Add(values);
			return newRow;
		}

		/// <summary>
		/// Создание записи ЕРВК
		/// </summary>
		/// <param name="version">Версия. Поле для связи gasps и ervk</param>
		/// <param name="esnsiCode">ИД ЕСНСИ</param>
		/// <param name="isHead">isHead</param>
		/// <param name="special">Специальная</param>
		/// <param name="military">Военная</param>
		/// <param name="isActive">Признак активности</param>
		/// <param name="idVersionProc">ИД версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="idVersionHead">ИД ЕСНСИ вышестоящего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="idSuccession">ИД ЕСНСИ бывшего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="dateStartVersion">Дата создания версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="dateCloseProc">Дата прекращения действия органа прокуратуры в ЕСНСИ</param>
		/// <param name="ogrn">ОГРН</param>
		/// <param name="inn">ИНН</param>
		/// <param name="subjectRfList">Субъект множественный</param>
		/// <param name="oktmoList">ОКТМО множественный</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.ervkRow CreateErvkNote(
			long version,
			bool isHead,
			bool special,
			bool military,
			long idVersionHead,
			long idSuccession,
			DateTime dateStartVersion,
			string ogrn,
			string inn,
			string subjectRfList,
			string oktmoList
			)
		{
			long esnsiCode = DataSet.ervk.GetNextEsnsiCode();
			string idVersionProc = DataSet.ervk.GetNextVersionProc();
			if (idVersionHead > 0)
			{
				Repositories.MainDataSet.ervkRow headRow = DataSet.ervk.GetFromEsnsiCode(idVersionHead);
				headRow.isHead = true;
			}

			return CreateErvkNote(
				version: version,
				esnsiCode: esnsiCode,
				isHead: isHead,
				special: special,
				military: military,
				isActive: true,
				idVersionProc: idVersionProc,
				idVersionHead: idVersionHead,
				idSuccession: idSuccession,
				dateStartVersion: dateStartVersion,
				dateCloseProc: MAX_DATE,
				ogrn: ogrn,
				inn: inn,
				subjectRfList: subjectRfList,
				oktmoList: oktmoList);
		}


		/// <summary>
		/// Создание новой версии записи ЕРВК
		/// </summary>
		/// <param name="version">Версия. Поле для связи gasps и ervk</param>
		/// <param name="esnsiCode">ИД ЕСНСИ</param>
		/// <param name="isHead">isHead</param>
		/// <param name="special">Специальная</param>
		/// <param name="military">Военная</param>
		/// <param name="isActive">Признак активности</param>
		/// <param name="idVersionProc">ИД версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="idVersionHead">ИД ЕСНСИ вышестоящего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="idSuccession">ИД ЕСНСИ бывшего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="dateStartVersion">Дата создания версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="dateCloseProc">Дата прекращения действия органа прокуратуры в ЕСНСИ</param>
		/// <param name="ogrn">ОГРН</param>
		/// <param name="inn">ИНН</param>
		/// <param name="subjectRfList">Субъект множественный</param>
		/// <param name="oktmoList">ОКТМО множественный</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.ervkRow CreateErvkVersionNote(
			long version,
			bool isHead,
			bool special,
			bool military,
			long idVersionHead,
			long idSuccession,
			DateTime dateStartVersion,
			string ogrn,
			string inn,
			string subjectRfList,
			string oktmoList
			)
		{
			long esnsiCode = DataSet.ervk.GetNextEsnsiCode();
			string idVersionProc = DataSet.ervk.GetNextVersionProc();
			if (idVersionHead > 0)
			{
				Repositories.MainDataSet.ervkRow headRow = DataSet.ervk.GetFromEsnsiCode(idVersionHead);
				headRow.isHead = true;
			}

			return CreateErvkNote(
				version: version,
				esnsiCode: esnsiCode,
				isHead: isHead,
				special: special,
				military: military,
				isActive: true,
				idVersionProc: idVersionProc,
				idVersionHead: idVersionHead,
				idSuccession: idSuccession,
				dateStartVersion: dateStartVersion,
				dateCloseProc: MAX_DATE,
				ogrn: ogrn,
				inn: inn,
				subjectRfList: subjectRfList,
				oktmoList: oktmoList);
		}


		/// <summary>
		/// Клонирование записи ЕРВК
		/// </summary>
		/// <param name="currentVersion"></param>
		/// <returns></returns>
		public static Repositories.MainDataSet.ervkRow CloneErvkNoteToLastVersion(long currentVersion)
		{
			Repositories.MainDataSet.gaspsRow currentGaspsRow = DataSet.gasps.GetOrganizationFromVersion(version: currentVersion);
			Repositories.MainDataSet.gaspsRow lastGaspsRow = DataSet.gasps.GetLastVersionOrganizationFromKey(currentGaspsRow.key);

			return CloneErvkNote(currentGaspsRow.version, lastGaspsRow.version);
		}

		/// <summary>
		/// Клонирование записи ЕРВК
		/// </summary>
		/// <param name="sourceVersion">Версия записи источника.</param>
		/// <param name="destVersion">Версия записи назначения</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.ervkRow CloneErvkNote(long sourceVersion, long destVersion)
		{
			if (!DataSet.ervk.Exists(destVersion))
			{
				Repositories.MainDataSet.ervkRow currentErvkRow = DataSet.ervk.Get(sourceVersion);
				return CreateErvkNote(
				version: destVersion,
				esnsiCode: currentErvkRow.esnsiCode,
				isHead: currentErvkRow.isHead,
				special: currentErvkRow.special,
				military: currentErvkRow.military,
				isActive: currentErvkRow.isActive,
				idVersionProc: currentErvkRow.idVersionProc,
				idVersionHead: currentErvkRow.IsidVersionHeadNull() ? 0 : currentErvkRow.idVersionHead,
				idSuccession: currentErvkRow.IsidSuccessionNull() ? 0 : currentErvkRow.idSuccession,
				dateStartVersion: currentErvkRow.dateStartVersion,
				dateCloseProc: currentErvkRow.IsdateCloseProcNull() ? DateTime.MaxValue : currentErvkRow.dateCloseProc,
				ogrn: currentErvkRow.IsogrnNull() ? null : currentErvkRow.ogrn,
				inn: currentErvkRow.IsinnNull() ? null : currentErvkRow.inn,
				subjectRfList: currentErvkRow.IssubjectRfListNull() ? null : currentErvkRow.subjectRfList,
				oktmoList: currentErvkRow.IsoktmoListNull() ? null : currentErvkRow.oktmoList);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Редактирование записи ЕРВК
		/// </summary>
		/// <param name="version">Версия. Поле для связи gasps и ervk</param>
		/// <param name="esnsiCode">ИД ЕСНСИ</param>
		/// <param name="isHead">isHead</param>
		/// <param name="special">Специальная</param>
		/// <param name="military">Военная</param>
		/// <param name="isActive">Признак активности</param>
		/// <param name="idVersionProc">ИД версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="idVersionHead">ИД ЕСНСИ вышестоящего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="idSuccession">ИД ЕСНСИ бывшего органа прокуратуры (ссылка на esnsiCode)</param>
		/// <param name="dateStartVersion">Дата создания версии органа прокуратуры в ЕСНСИ</param>
		/// <param name="dateCloseProc">Дата прекращения действия органа прокуратуры в ЕСНСИ</param>
		/// <param name="ogrn">ОГРН</param>
		/// <param name="inn">ИНН</param>
		/// <param name="subjectRfList">Субъект множественный</param>
		/// <param name="oktmoList">ОКТМО множественный</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.ervkRow EditVersionErvkNote(
			long version,
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
			string subjectRfList,
			string oktmoList)
		{
			Repositories.MainDataSet.ervkRow errorRow = DataSet.ervk.Get(gaspsVersion: version);

			errorRow.esnsiCode = esnsiCode;
			errorRow.isHead = isHead;
			errorRow.special = special;
			errorRow.military = military;
			errorRow.isActive = isActive;
			errorRow.idVersionProc = idVersionProc;
			errorRow.idVersionHead = idVersionHead;
			errorRow.idSuccession = idSuccession;
			errorRow.dateStartVersion = dateStartVersion;
			errorRow.dateCloseProc = dateCloseProc;
			errorRow.ogrn = ogrn;
			errorRow.inn = inn;
			errorRow.subjectRfList = subjectRfList;
			errorRow.oktmoList = oktmoList;

			errorRow.logEditDate = DateTime.Now;

			return errorRow;
		}

		/// <summary>
		/// Создание записи УРП ГАС ПС
		/// </summary>
		/// <param name="version">Версия подразделения</param>
		/// <param name="shortName">Краткое наименование </param>
		/// <param name="doesntCreateCard">Не создаёт карточки </param>
		/// <param name="doesntSingReport">Не подписывает отчёт</param>
		/// <param name="doesntConsolidateChild">Не консолидирует дочерние</param>
		/// <param name="agencyReceivingReport">Передаёт отчёт в </param>
		/// <param name="ord">Порядок</param>
		/// <param name="vedCode">Ведомственный код</param>
		/// <param name="id">Ключ</param>
		/// <param name="oktmoLocId">ОКТМО территории обслуживания </param>
		/// <param name="lawAgencyType">Тип подразделений</param>
		/// <param name="specialTerritorialCode">Специализированный территориальный код </param>
		/// <returns></returns>
		public static Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow CreateUrpNote(
			long version,
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
			)
		{
			object[] values = new object[12];
			values[0] = version; // VERSION
			values[1] = shortName; // SHORT_NAME
			values[2] = doesntCreateCard; // DOESNT_CREATE_CARD
			values[3] = doesntSingReport; // DOESNT_SIGN_REPORT
			values[4] = doesntConsolidateChild; // DOESNT_CONSOLIDATE_CHILD
			values[5] = agencyReceivingReport; // AGENCY_RECEIVING_REPORT
			values[6] = ord; // ORD
			values[7] = vedCode; // VED_CODE
			values[8] = id; // ID
			values[9] = oktmoLocId; // OKTMO_LOC_ID
			values[10] = lawAgencyType; // LAW_AGENCY_TYPE
			values[11] = specialTerritorialCode; // SPECIAL_TERRITORIAL_CODE

			Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow newRow = (Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow)FileSystem.Repository.MainDataSet.EXP_LAW_AGENCY_URP
				.Rows.Add(values);
			return newRow;
		}

		/// <summary>
		/// Клонирование записи УРП ГАС ПС
		/// </summary>
		/// <param name="currentVersion"></param>
		/// <returns></returns>
		public static Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow CloneUrpNoteToLastVersion(long currentVersion)
		{
			Repositories.MainDataSet.gaspsRow currentGaspsRow = DataSet.gasps.GetOrganizationFromVersion(version: currentVersion);
			Repositories.MainDataSet.gaspsRow lastGaspsRow = DataSet.gasps.GetLastVersionOrganizationFromKey(currentGaspsRow.key);

			return CloneUrpNote(currentGaspsRow.version, lastGaspsRow.version);
		}

		/// <summary>
		/// Клонирование записи УРП ГАС ПС
		/// </summary>
		/// <param name="sourceVersion">Версия записи источника.</param>
		/// <param name="destVersion">Версия записи назначения</param>
		/// <returns></returns>
		public static Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow CloneUrpNote(long sourceVersion, long destVersion)
		{
			if (!DataSet.EXP_LAW_AGENCY_URP.Exists(destVersion))
			{
				Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow currentUrpRow = DataSet.EXP_LAW_AGENCY_URP.Get(sourceVersion);
				return CreateUrpNote(
					version: destVersion,
					shortName: currentUrpRow.SHORT_NAME,
					doesntCreateCard: currentUrpRow.DOESNT_CREATE_CARD,
					doesntSingReport: currentUrpRow.DOESNT_SIGN_REPORT,
					doesntConsolidateChild: currentUrpRow.DOESNT_CONSOLIDATE_CHILD,
					agencyReceivingReport: currentUrpRow.AGENCY_RECEIVING_REPORT,
					ord: currentUrpRow.ORD,
					vedCode: currentUrpRow.VED_CODE,
					id: DataSet.EXP_LAW_AGENCY_URP.GetNextId(),
					oktmoLocId: currentUrpRow.OKTMO_LOC_ID,
					lawAgencyType: currentUrpRow.LAW_AGENCY_TYPE,
					specialTerritorialCode: currentUrpRow.SPECIAL_TERRITORIAL_CODE
				);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Редактирование записи ЕРВК
		/// </summary>
		/// <param name="version">Версия подразделения</param>
		/// <param name="shortName">Краткое наименование </param>
		/// <param name="doesntCreateCard">Не создаёт карточки </param>
		/// <param name="doesntSingReport">Не подписывает отчёт</param>
		/// <param name="doesntConsolidateChild">Не консолидирует дочерние</param>
		/// <param name="agencyReceivingReport">Передаёт отчёт в </param>
		/// <param name="ord">Порядок</param>
		/// <param name="vedCode">Ведомственный код</param>
		/// <param name="id">Ключ</param>
		/// <param name="oktmoLocId">ОКТМО территории обслуживания </param>
		/// <param name="lawAgencyType">Тип подразделений</param>
		/// <param name="specialTerritorialCode">Специализированный территориальный код </param>
		/// <returns></returns>
		public static Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow EditVersionUrpNote(
			long version,
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
			)
		{
			Repositories.MainDataSet.EXP_LAW_AGENCY_URPRow errorRow = DataSet.EXP_LAW_AGENCY_URP.Get(version: version);

			errorRow.SHORT_NAME = shortName;
			errorRow.DOESNT_CREATE_CARD = doesntCreateCard;
			errorRow.DOESNT_SIGN_REPORT = doesntSingReport;
			errorRow.DOESNT_CONSOLIDATE_CHILD = doesntConsolidateChild;
			errorRow.AGENCY_RECEIVING_REPORT = agencyReceivingReport;
			errorRow.ORD = ord;
			errorRow.VED_CODE = vedCode;
			errorRow.ID = id;
			errorRow.OKTMO_LOC_ID = oktmoLocId;
			errorRow.LAW_AGENCY_TYPE = lawAgencyType;
			errorRow.SPECIAL_TERRITORIAL_CODE = specialTerritorialCode;
			return errorRow;
		}
	}
}