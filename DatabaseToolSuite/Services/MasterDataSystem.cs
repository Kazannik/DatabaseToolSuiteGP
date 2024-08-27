using System;
using static DatabaseToolSuite.Repositoryes.RepositoryDataSet;

namespace DatabaseToolSuite.Services
{
    // Создание новой записи:
    // key++
    // version = key
    // index++

    // Создание версии записи:
    // key
    // version++
    // index
    static class MasterDataSystem
    {
        public static readonly long PROSECUTOR_CODE = 20;
        public static readonly DateTime MAX_DATE = new DateTime(2999, 12, 31);
        public static readonly DateTime MIN_DATE = new DateTime(1900, 1, 1);
        
        public static Repositoryes.RepositoryDataSet DataSet
        {
            get { return FileSystem.Repository.DataSet; }
        }

        /// <summary>
        /// Создание записи о подразделении правоохранительного органа в ГАС ПС
        /// </summary>
        /// <param name="name">Наименование подразделения.</param>
        /// <param name="key">Ключ подразделения. Не изменяется от версии к версии записи.</param>
        /// <param name="okato">Код ОКАТО.</param>
        /// <param name="authorityId">Индекс вида органа.</param>
        /// <param name="code">Код подразделения.</param>
        /// <param name="version">Уникальный "сквозной" код версии записи. </param>
        /// <param name="index">Код для сортировки (?). Не используется.</param>
        /// <param name="ownerKey">Ключ (key) родительского подразделения.</param>
        /// <param name="dateBegin">Дата введения в действие новой записи.</param>
        /// <param name="dateEnd">Дата окончания действия записи.</param>
        /// <param name="courtTypeId">Индекс вида суда.</param>
        /// <returns></returns>
        private static gaspsRow CreateOrganization(
            string name,
            long key,
            string okato,
            long authorityId,
            string code,
            long version,
            long index,
            long ownerKey,
            DateTime dateBegin,
            DateTime dateEnd,
            long courtTypeId)
        {
            object[] values = new object[15];
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

            gaspsRow newRow = (gaspsRow) FileSystem.Repository.DataSet.gasps.Rows.Add(values);

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
        public static long CreateNewOrganization(
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

            gaspsRow newRow = CreateOrganization(
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
                           courtTypeId: courtTypeId);

            return newRow.version;
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
        public static long CreateNewVersionOrganization(
            long version, 
            DateTime date,
            string name,
            string okato,
            long authorityId,
            long ownerKey,            
            long courtTypeId)
        {
            gaspsRow modifedRow = DataSet.gasps.GetOrganizationFromVersion(version: version);

            if (!DataSet.gasps.IsLastVersion(version: version))
            {
                throw new ArgumentException(string.Format(
                    "Запись версии {0} не является самой последней записью с ключем {1}, поэтому не может быть отредактирована.",
                            version, modifedRow.key));
            }
            
            modifedRow.date_end = date;

            long newVersion = DataSet.gasps.GetNextVersion();

            gaspsRow newRow = CreateOrganization(
                name: name,
                key: modifedRow.key,
                okato: okato,
                authorityId: authorityId,
                code: modifedRow.code,
                version: newVersion,
                index: modifedRow.IsindexNull() ? 0: modifedRow.index,
                ownerKey: ownerKey,
                dateBegin: date,
                dateEnd: MAX_DATE,
                courtTypeId: courtTypeId);

            if (modifedRow.authority_id == PROSECUTOR_CODE)
            {
                if (DataSet.fgis_esnsi.ExistsRow(modifedRow.version))
                {
                    CloneFgisEsnsiNote(modifedRow.version, newVersion);
                }
                if (DataSet.ervk.ExistsRow(modifedRow.version))
                {
                    CloneErvkNote(modifedRow.version, newVersion);
                }
            }

            return newRow.version;
        }


        /// <summary>
        /// Создание новой версии записи о подразделении правоохранительного органа в ГАС ПС
        /// </summary>
        /// <param name="version">Индекс версии</param>
        /// <param name="date">Дата введения в действие новой версии</param>
        /// <param name="name">Наименование подразделения</param>
        /// <returns></returns>
        public static long CreateNewVersionOrganization(
            long version,
            DateTime date,
            string name)
        {
            gaspsRow modifedRow = DataSet.gasps.GetOrganizationFromVersion(version: version);

            if (!DataSet.gasps.IsLastVersion(version: version))
            {
                throw new ArgumentException(string.Format(
                    "Запись версии {0} не является самой последней записью с ключем {1}, поэтому не может быть отредактирована.",
                            version, modifedRow.key));
            }

            modifedRow.date_end = date;

            long newVersion = DataSet.gasps.GetNextVersion();

            gaspsRow newRow = CreateOrganization(
                name: name,
                key: modifedRow.key,
                okato: modifedRow.okato_code,
                authorityId: modifedRow.authority_id,
                code: modifedRow.code,
                version: newVersion,
                index: modifedRow.index,
                ownerKey: modifedRow.owner_id,
                dateBegin: date,
                dateEnd: MAX_DATE,
                courtTypeId: modifedRow.court_type_id);

            if (modifedRow.authority_id == PROSECUTOR_CODE)
            {
                if (DataSet.fgis_esnsi.ExistsRow(modifedRow.version))
                {
                    CloneFgisEsnsiNote(modifedRow.version, newVersion);
                }

                if (DataSet.ervk.ExistsRow(modifedRow.version))
                {
                    CloneErvkNote(modifedRow.version, newVersion);
                }
            }
            return newRow.version;
        }

        /// <summary>
        /// Блокировка записи о подразделении правоохранительного органа в ГАС ПС
        /// </summary>
        /// <param name="version">Индекс версии</param>
        /// <param name="date">Дата блокировки</param>
        public static void RemoveOrganization(long version, DateTime date)
        {
            gaspsRow oldRow = DataSet.gasps.GetOrganizationFromVersion(version: version);
            oldRow.BeginEdit();
            oldRow.date_end = date;
            oldRow.EndEdit();
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
        public static long EditVersionOrganization(
            long version,
            DateTime date,
            string name,
            string okato,
            long authorityId,
            long ownerKey,
            long courtTypeId)
        {
            gaspsRow errorRow = DataSet.gasps.GetOrganizationFromVersion(version: version);

            errorRow.date_beg = date;
            errorRow.name = name;
            errorRow.okato_code = okato;
            errorRow.authority_id = authorityId;
            errorRow.owner_id = ownerKey;
            errorRow.date_end = MAX_DATE;
            errorRow.logEditDate = DateTime.Now;

            return errorRow.version;
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
        public static fgis_esnsiRow CreateFgisEsnsiNote(
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

            fgis_esnsiRow newRow = (fgis_esnsiRow)FileSystem.Repository.DataSet.fgis_esnsi.Rows.Add(values);
                return newRow;
                         
        }

        /// <summary>
        /// Клонирование записи ФГИС ЕСНСИ из заданой записи в последнюю запись.
        /// </summary>
        /// <param name="currentVersion">Выбранная запись.</param>
        /// <returns></returns>
        public static fgis_esnsiRow CloneFgisEsnsiNoteToLastVersion(long currentVersion)
        {
            gaspsRow currentGaspsRow = DataSet.gasps.GetOrganizationFromVersion(version: currentVersion);
            gaspsRow lastGaspsRow = DataSet.gasps.GetLastVersionOrganizationFromCode(currentGaspsRow.code);

            return CloneFgisEsnsiNote(currentGaspsRow.version, lastGaspsRow.version);           
        }

        /// <summary>
        /// Клонирование записи ФГИС ЕСНСИ
        /// </summary>
        /// <param name="sourceVersion">Версия записи источника.</param>
        /// <param name="destVersion">Версия записи назначения</param>
        /// <returns></returns>
        public static fgis_esnsiRow CloneFgisEsnsiNote(long sourceVersion, long destVersion)
        {
            if (!DataSet.fgis_esnsi.ExistsRow(destVersion))
            {
                fgis_esnsiRow currentFgisEsnsiRow = DataSet.fgis_esnsi.Get(sourceVersion);
                return CreateFgisEsnsiNote(
                version: destVersion,
                region_id: currentFgisEsnsiRow.Isregion_idNull() ? 0 : currentFgisEsnsiRow.region_id,
                sv_0004: currentFgisEsnsiRow.Issv_0004Null() ? string.Empty : currentFgisEsnsiRow.sv_0004,
                sv_0005: currentFgisEsnsiRow.Issv_0005Null() ? string.Empty : currentFgisEsnsiRow.sv_0005,
                sv_0006: currentFgisEsnsiRow.Issv_0006Null() ? string.Empty : currentFgisEsnsiRow.sv_0006,
                okato: currentFgisEsnsiRow.IsokatoNull() ? (short)0 : currentFgisEsnsiRow.okato,
                code: currentFgisEsnsiRow.IscodeNull() ? 0 : currentFgisEsnsiRow.code,
                autokey: currentFgisEsnsiRow.IsautokeyNull() ? string.Empty : currentFgisEsnsiRow.autokey,
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
        public static long EditVersionFgisEsnsiNote(
            long version,
            long region_id,
            string sv_0004,
            string sv_0005,
            string sv_0006,
            short okato)
        {
            fgis_esnsiRow errorRow = DataSet.fgis_esnsi.Get(gaspsVersion: version);

            errorRow.region_id = region_id;
            errorRow.sv_0004 = sv_0004;
            errorRow.sv_0005 = sv_0005;
            errorRow.sv_0006 = sv_0006;
            errorRow.okato = okato;
            errorRow.logEditDate = DateTime.Now;

            return errorRow.version;
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
        public static ervkRow CreateErvkNote(
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
            values[10] =  DateTime.MaxValue.Equals(dateCloseProc) ? null : (object)dateCloseProc;
            values[11] = ogrn;
            values[12] = inn;
            values[13] = subjectRfList;
            values[14] = oktmoList;
            values[15] = DateTime.Now;

            ervkRow newRow = (ervkRow)FileSystem.Repository.DataSet.ervk.Rows.Add(values);
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
        public static ervkRow CreateErvkNote(
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
                ervkRow headRow = DataSet.ervk.GetFromEsnsiCode(idVersionHead);
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
        public static ervkRow CloneErvkNoteToLastVersion(long currentVersion)
        {
            gaspsRow currentGaspsRow = DataSet.gasps.GetOrganizationFromVersion(version: currentVersion);
            gaspsRow lastGaspsRow = DataSet.gasps.GetLastVersionOrganizationFromCode(currentGaspsRow.code);

            return CloneErvkNote(currentGaspsRow.version, lastGaspsRow.version);
        }


        /// <summary>
        /// Клонирование записи ЕРВК
        /// </summary>
        /// <param name="sourceVersion">Версия записи источника.</param>
        /// <param name="destVersion">Версия записи назначения</param>
        /// <returns></returns>
        public static ervkRow CloneErvkNote(long sourceVersion, long destVersion)
        {
            if (!DataSet.ervk.ExistsRow(destVersion))
            {
                ervkRow currentErvkRow = DataSet.ervk.Get(sourceVersion);
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
                ogrn: currentErvkRow.IsogrnNull() ? string.Empty : currentErvkRow.ogrn,
                inn: currentErvkRow.IsinnNull() ? string.Empty : currentErvkRow.inn,
                subjectRfList: currentErvkRow.IssubjectRfListNull() ? string.Empty : currentErvkRow.subjectRfList,
                oktmoList: currentErvkRow.IsoktmoListNull() ? string.Empty : currentErvkRow.oktmoList);
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
        public static long EditVersionErvkNote(
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
            ervkRow errorRow = DataSet.ervk.Get(gaspsVersion: version);

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

            return errorRow.version;
        }
    }
}
