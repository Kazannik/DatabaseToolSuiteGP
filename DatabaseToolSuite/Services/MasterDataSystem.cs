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
        public static readonly DateTime MAX_DATE = new DateTime(2999, 12, 31);
        public static readonly DateTime MIN_DATE = new DateTime(1900, 1, 1);
        
        public static Repositoryes.RepositoryDataSet DataSet
        {
            get { return FileSystem.Repository.DataSet; }
        }
                
        /// <summary>
        /// Создание записи о подразделении правоохранительного органа
        /// </summary>
        /// <param name="name">Наименование подразделения</param>
        /// <param name="key"></param>
        /// <param name="okato"></param>
        /// <param name="authorityId"></param>
        /// <param name="code"></param>
        /// <param name="version"></param>
        /// <param name="index"></param>
        /// <param name="ownerKey"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <param name="courtTypeId"></param>
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
            object[] values = new object[14];
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

            gaspsRow newRow = (gaspsRow) FileSystem.Repository.DataSet.gasps.Rows.Add(values);

            return newRow;
        }
       
        /// <summary>
        /// Создание новой записи.
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
        /// Создание новой версии записи
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

            if (modifedRow.authority_id == 20 &&
               DataSet.fgis_esnsi.ExistsRow(modifedRow.version))
            {
                fgis_esnsiRow clonedRow = DataSet.fgis_esnsi.Get(modifedRow.version);
                CreateFgisEsnsiNote(
                    version: newVersion,
                    region_id: clonedRow.Isregion_idNull() ? 0: clonedRow.region_id,
                    sv_0004: clonedRow.Issv_0004Null() ? string.Empty: clonedRow.sv_0004,
                    sv_0005: clonedRow.Issv_0005Null() ? string.Empty: clonedRow.sv_0005,
                    sv_0006: clonedRow.Issv_0006Null() ? string.Empty: clonedRow.sv_0006,
                    okato: clonedRow.IsokatoNull() ? (short) 0: clonedRow.okato,
                    code: clonedRow.IscodeNull()? 0: clonedRow.code,
                    autokey: clonedRow.IsautokeyNull() ? string.Empty: clonedRow.autokey,
                    id: clonedRow.IsidNull()? 0: clonedRow.id);
            }

            return newRow.version;
        }


        /// <summary>
        /// Создание новой версии записи
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

            if (modifedRow.authority_id == 20 &&
                DataSet.fgis_esnsi.ExistsRow(modifedRow.version))
            {
                fgis_esnsiRow clonedRow = DataSet.fgis_esnsi.Get(modifedRow.version);
                CreateFgisEsnsiNote(
                    version: newVersion,
                    region_id: clonedRow.Isregion_idNull() ? 0 : clonedRow.region_id,
                    sv_0004: clonedRow.Issv_0004Null() ? string.Empty : clonedRow.sv_0004,
                    sv_0005: clonedRow.Issv_0005Null() ? string.Empty : clonedRow.sv_0005,
                    sv_0006: clonedRow.Issv_0006Null() ? string.Empty : clonedRow.sv_0006,
                    okato: clonedRow.IsokatoNull() ? (short)0: clonedRow.okato,
                    code: clonedRow.IscodeNull() ? 0 : clonedRow.code,
                    autokey: clonedRow.IsautokeyNull() ? string.Empty : clonedRow.autokey,
                    id: clonedRow.IsidNull() ? 0 : clonedRow.id);
            }
            return newRow.version;
        }

        /// <summary>
        /// Блокировка записи
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
        /// Создание новой версии записи
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

            return errorRow.version;
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version">Версия. Поле для связи gasps и fgis_esnsi</param>
        /// <param name="region_id">Индекс региона</param>
        /// <param name="sv_0004">Телефон</param>
        /// <param name="sv_0005">Електронный адрес</param>
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
            
                object[] values = new object[9];
                values[0] = version;
                values[1] = region_id;
                values[2] = sv_0004;
                values[3] = sv_0005;
                values[4] = sv_0006;
                values[5] = okato;
                values[6] = code;
                values[7] = autokey;
                values[8] = id;

                fgis_esnsiRow newRow = (fgis_esnsiRow)FileSystem.Repository.DataSet.fgis_esnsi.Rows.Add(values);
                return newRow;
                         
        }


        public static fgis_esnsiRow CloneFgisEsnsiNoteToLastVersion(long currentVersion)
        {
            gaspsRow currentGaspsRow = DataSet.gasps.GetOrganizationFromVersion(version: currentVersion);
            gaspsRow lastGaspsRow = DataSet.gasps.GetLastVersionOrganizationFromCode(currentGaspsRow.code);

           if (!DataSet.fgis_esnsi.ExistsRow(lastGaspsRow.version))
            {
                fgis_esnsiRow currentFgisEsnsiRow = DataSet.fgis_esnsi.Get(currentGaspsRow.version);
                return CreateFgisEsnsiNote(
                version: lastGaspsRow.version,
                region_id: currentFgisEsnsiRow.Isregion_idNull() ? 0 : currentFgisEsnsiRow.region_id,
                sv_0004: currentFgisEsnsiRow.Issv_0004Null() ? string.Empty : currentFgisEsnsiRow.sv_0004,
                sv_0005: currentFgisEsnsiRow.Issv_0005Null() ? string.Empty : currentFgisEsnsiRow.sv_0005,
                sv_0006: currentFgisEsnsiRow.Issv_0006Null() ? string.Empty : currentFgisEsnsiRow.sv_0006,
                okato: currentFgisEsnsiRow.IsokatoNull() ? (short) 0 : currentFgisEsnsiRow.okato,
                code: currentFgisEsnsiRow.IscodeNull() ? 0 : currentFgisEsnsiRow.code,
                autokey: currentFgisEsnsiRow.IsautokeyNull() ? string.Empty : currentFgisEsnsiRow.autokey, 
                id: currentFgisEsnsiRow.IsidNull() ? 0 : currentFgisEsnsiRow.id);
            }
            else
            {
                return null;
            }            
        }
    }
}
