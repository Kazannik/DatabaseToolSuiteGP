// Ignore Spelling: Urp Ervk Fgis Esnsi ALLOWBLE Utils

namespace DatabaseToolSuite.Utils
{
	using DatabaseToolSuite.Controls;
	using DatabaseToolSuite.Services;
	using Microsoft.Office.Interop.Excel;
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	/// <summary>
	/// Класс для реализации временных функций
	/// </summary>
	internal static class Database
	{
		/// <summary>
		/// Вызов: return ConvertFromDBVal<string>(this[this.tablegasps.codeColumn]);
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		/// <code>return ConvertFromDBVal<string>(this[this.tablegasps.codeColumn]);</code>
		public static T ConvertFromDBVal<T>(object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return default;
			}
			else
			{
				return (T)obj;
			}
		}



		/// <summary>
		/// Defines the allowbleHierarchyArray
		/// </summary>
		private static readonly LAW_AGENCY_ALLOWBLE_HIERARCHY[] allowbleHierarchyArray = new LAW_AGENCY_ALLOWBLE_HIERARCHY[]
		{
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(2, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(3, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(4, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(5, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(6, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(7, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(8, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(9, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(10, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(11, 10),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(12, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(13, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(14, 12),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(14, 13),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(15, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 3),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 4),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 5),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 6),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 7),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 8),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 9),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 10),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 11),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 12),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 13),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 14),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 15),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 17),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 18),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 19),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 20),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 21),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(16, 22),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(17, 15),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 3),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 4),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 5),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 6),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 7),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 8),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 9),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 10),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 11),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 12),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 13),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 14),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 15),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 16),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 17),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 19),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 20),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 21),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(18, 22),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 3),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 4),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 5),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 6),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 7),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 8),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 9),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 10),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 11),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 12),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 13),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 14),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 15),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 16),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 17),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 18),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 20),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 21),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(19, 22),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 3),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 4),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 5),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 6),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 7),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 8),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 9),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 10),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 11),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 12),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 13),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 14),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 15),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 16),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 17),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 18),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 19),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 21),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(20, 22),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 3),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 4),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 5),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 6),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 7),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 8),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 9),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 10),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 11),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 12),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 13),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 14),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 15),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 16),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 17),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 18),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 19),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 20),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(21, 22),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 1),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 2),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 3),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 4),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 5),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 6),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 7),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 8),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 9),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 10),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 11),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 12),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 13),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 14),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 15),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 16),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 17),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 18),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 19),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 20),
			new LAW_AGENCY_ALLOWBLE_HIERARCHY(22, 21)
		};

		/// <summary>
		/// Defines the territorialArray
		/// </summary>
		private static readonly SPECIAL_TERRITORIAL_CODE[] territorialArray = new SPECIAL_TERRITORIAL_CODE[]
				{
			new SPECIAL_TERRITORIAL_CODE(1, "Приволжская транспортная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(2, "Волжская межрегиональная природоохранная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(5, "Военная прокуратура Восточного военного округа"),
			new SPECIAL_TERRITORIAL_CODE(7, "Военная прокуратура Ленинградского военного округа"),
			new SPECIAL_TERRITORIAL_CODE(8, "Амурская бассейновая природоохранная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(9, "Байкальская межрегиональная природоохранная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(10, "Военная прокуратура Центрального военного округа"),
			new SPECIAL_TERRITORIAL_CODE(12, "Военная прокуратура Объединенных группировок войск (сил)"),
			new SPECIAL_TERRITORIAL_CODE(14, "Военная прокуратура Южного военного округа"),
			new SPECIAL_TERRITORIAL_CODE(19, "Военная прокуратура Московского военного округа"),
			new SPECIAL_TERRITORIAL_CODE(20, "Военная прокуратура Балтийского флота"),
			new SPECIAL_TERRITORIAL_CODE(21, "Военная прокуратура Тихоокеанского флота"),
			new SPECIAL_TERRITORIAL_CODE(22, "Военная прокуратура Черноморского флота"),
			new SPECIAL_TERRITORIAL_CODE(23, "Военная прокуратура Северного флота"),
			new SPECIAL_TERRITORIAL_CODE(24, "Военная прокуратура Ракетных войск стратегического назначения"),
			new SPECIAL_TERRITORIAL_CODE(29, "Главная военная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(33, "Московская городская военная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(77, "Правоохранительные органы федерального уровня"),
			new SPECIAL_TERRITORIAL_CODE(81, "Южная транспортная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(93, "Восточно - Сибирская транспортная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(94, "Дальневосточная транспортная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(95, "Западно - Сибирская транспортная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(96, "Московская межрегиональная транспортная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(97, "Северо - Западная транспортная прокуратура"),
			new SPECIAL_TERRITORIAL_CODE(98, "Уральская транспортная прокуратура")
		};

		/// <summary>
		/// Defines the typesArray
		/// </summary>
		private static readonly LAW_AGENCY_TYPE[] typesArray = new LAW_AGENCY_TYPE[] {
			new LAW_AGENCY_TYPE(1, "Генеральная прокуратура", true),
			new LAW_AGENCY_TYPE(2, "Прокуратура субъекта", true),
			new LAW_AGENCY_TYPE(3, "Районная прокуратура", true),
			new LAW_AGENCY_TYPE(4, "Межрайонная прокуратура", true),
			new LAW_AGENCY_TYPE(5, "Специализированная прокуратура субъекта", true),
			new LAW_AGENCY_TYPE(6, "Межрайонная специализированная прокуратура", true),
			new LAW_AGENCY_TYPE(7, "Городская прокуратура", true),
			new LAW_AGENCY_TYPE(8, "Окружная прокуратура", true),
			new LAW_AGENCY_TYPE(9, "Городская районная прокуратура", true),
			new LAW_AGENCY_TYPE(10, "Специализированная прокуратура", true),
			new LAW_AGENCY_TYPE(11, "Специализированная прокуратура на правах районной", true),
			new LAW_AGENCY_TYPE(12, "Главная военная прокуратура", true),
			new LAW_AGENCY_TYPE(13, "Военная прокуратура окружного звена", true),
			new LAW_AGENCY_TYPE(14, "Военная прокуратура", true),
			new LAW_AGENCY_TYPE(15, "Центральный аппарат", false),
			new LAW_AGENCY_TYPE(16, "Аппарат", false),
			new LAW_AGENCY_TYPE(17, "Главное управление", false),
			new LAW_AGENCY_TYPE(18, "Управление", false),
			new LAW_AGENCY_TYPE(19, "Отдел", false),
			new LAW_AGENCY_TYPE(20, "Руководитель", false),
			new LAW_AGENCY_TYPE(21, "Старший помощник", false),
			new LAW_AGENCY_TYPE(22, "Помощник", false)};

		/// <summary>
		/// Автозаполнение сведений журнала редактирования базы ЕРВК
		/// </summary>
		public static void FillLogEditDateInErvk()
		{
			foreach (Repositories.MainDataSet.ervkRow row in MasterDataSystem.DataSet.ervk.Rows)
			{
				if (row.IslogEditDateNull())
				{
					Repositories.MainDataSet.gaspsRow gaspsRow = MasterDataSystem.DataSet.gasps.GetOrganizationFromVersion(row.version);
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
		/// Автозаполнение сведений журнала редактирования базы ФГИС ЕСНСИ
		/// </summary>
		public static void FillLogEditDateInFgisEsnsi()
		{
			foreach (Repositories.MainDataSet.fgis_esnsiRow row in MasterDataSystem.DataSet.fgis_esnsi.Rows)
			{
				if (row.IslogEditDateNull())
				{
					Repositories.MainDataSet.gaspsRow gaspsRow = MasterDataSystem.DataSet.gasps.GetOrganizationFromVersion(row.version);
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
		/// Автозаполнение сведений журнала редактирования базы ГАС ПС
		/// </summary>
		public static void FillLogEditDateInGasps()
		{
			foreach (Repositories.MainDataSet.gaspsRow row in MasterDataSystem.DataSet.gasps.Rows)
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
		/// Автодополнение основной базы сведениями УРП ГАС ПС
		/// </summary>
		public static void FillUrpInGasps()
		{
			_ = Rtk.ConvertOktmo();
			_ = Rtk.ConvertAuthority();
			_ = Rtk.ConvertLawAgencyTypeAllowbleHierarchy();
			_ = Rtk.ConvertLawAgencyTypes();
			_ = Rtk.ConvertSpecialTerritorialCode();

			foreach (Repositories.MainDataSet.gaspsRow row in MasterDataSystem.DataSet.gasps.Rows)
			{
				if (row.authority_id == MasterDataSystem.PROSECUTOR_CODE
					&& row.date_end.Date > DateTime.Today && row.date_beg.Date <= DateTime.Today)
				{
					if (!MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Exists(gaspsVersion: row.version))
						MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.Create(gaspsVersion: row.version, shortName: row.name, oktmo: row.okatoRow.export_id);
				}
			}
		}

		/// <summary>
		/// Инициализация таблиц для РТК в основной базе данных
		/// </summary>
		public static void InitializeTables()
		{
			foreach (LAW_AGENCY_TYPE item in typesArray)
			{
				MasterDataSystem.DataSet.EXP_LAW_AGENCY_TYPES.Rows.Add(
					new object[] { item.ID, item.MANDATORY_CODE, item.NAME });
			}

			foreach (SPECIAL_TERRITORIAL_CODE item in territorialArray)
			{
				MasterDataSystem.DataSet.SPECIAL_TERRITORIAL_CODE.Rows.Add(
					new object[] { item.ID, item.ID.ToString(), item.NAME });
			}

			foreach (LAW_AGENCY_ALLOWBLE_HIERARCHY item in allowbleHierarchyArray)
			{
				MasterDataSystem.DataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHY.Rows.Add(
				new object[] { item.LAW_AGENCY_TYPE, item.ALLOWBLE_HIERARCHY });
			}
		}

		/// <summary>
		/// Автоматическая расстановка атрибута IsHead о наличии подчиненных прокуратур в таблице ЕРВК
		/// </summary>
		public static void SetIsHeadAttribute()
		{
			foreach (Repositories.MainDataSet.ervkRow row in MasterDataSystem.DataSet.ervk.Rows)
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

		/// <summary>
		/// Автоматическое дополнение атрибута Id для ЕСНСИ
		/// </summary>
		public static void SetIdFgisEsnsiAttribute()
		{
			int res = 0;
			foreach (Repositories.MainDataSet.fgis_esnsiRow row in MasterDataSystem.DataSet.fgis_esnsi.Rows)
			{
				if (row.id == 0)
				{
					long id = MasterDataSystem.DataSet.fgis_esnsi.GetNextId();
					row.id = id;
					res++;
				}
				if (row.code == 0)
				{
					long code = MasterDataSystem.DataSet.fgis_esnsi.GetNextCode();
					row.code = code;
					res++;
				}	
				if (row.autokey != "FED_GENPROK_ORGANIZATION_" + row.id)
				{
					row.autokey = "FED_GENPROK_ORGANIZATION_" + row.id;
					res++;
				}
			}
			MessageBox.Show(string.Format("Внесены сведения в {0} записей.", res));
		}

		/// <summary>
		/// Внесение сведений о владельце
		/// </summary>
		/// <param name="date">Дата введения новой версии записи</param>
		/// <param name="array">Массив строк для внесения сведений</param>
		/// <param name="ownerKey">Ключ родительского подразделения</param>
		public static void SetOwnerOrganization(DateTime date, Repositories.MainDataSet.gaspsRow[] array,  long ownerKey)
		{
			foreach (Repositories.MainDataSet.gaspsRow row in array)
			{
				MasterDataSystem.CreateNewVersionOrganization(
					version: row.version,
					date: date,
					name: row.name,
					okato: row.okato_code,
					authorityId: row.authority_id,
					ownerKey: ownerKey,
					courtTypeId: row.court_type_id);
			}			
			MessageBox.Show(string.Format("Внесены сведения в {0} записей.", array.Length));
		}

		/// <summary>
		/// Ремонт данных.
		/// </summary>
		public static void FixDataVersion01()
		{
			int n = 0;
			
			foreach (Repositories.MainDataSet.gaspsRow row in MasterDataSystem.DataSet.gasps.Rows)
			{
				if (row.authority_id != 5 &&
					row.date_beg == row.date_end)
				{
					Repositories.MainDataSet.gaspsRow[] rowsFromKey = MasterDataSystem.DataSet.gasps.GetOrganizationsFromKey(row.key);

					for (int i = 0; i < rowsFromKey.Length - 1; i++)
					{
						Repositories.MainDataSet.gaspsRow oldRow = rowsFromKey[i];
						if (oldRow.date_beg == oldRow.date_end)
						{
							Repositories.MainDataSet.gaspsRow nextRow = rowsFromKey[i + 1];
							if (oldRow.date_beg == nextRow.date_beg)
							{
								DateTime editDate = new DateTime(nextRow.logEditDate.Year, nextRow.logEditDate.Month, nextRow.logEditDate.Day);
								oldRow.date_end = editDate;
								nextRow.date_beg = editDate;
								n++;
							}
						}
					}
				}				
			}
			MessageBox.Show(string.Format("Внесены сведения в {0} записей.", n));
		}

		/// <summary>
		/// Defines the <see cref="LAW_AGENCY_ALLOWBLE_HIERARCHY" />
		/// </summary>
		private class LAW_AGENCY_ALLOWBLE_HIERARCHY
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="LAW_AGENCY_ALLOWBLE_HIERARCHY"/> class.
			/// </summary>
			/// <param name="LAW_AGENCY_TYPE">The LAW_AGENCY_TYPE<see cref="long"/></param>
			/// <param name="ALLOWBLE_HIERARCHY">The ALLOWBLE_HIERARCHY<see cref="long"/></param>
			public LAW_AGENCY_ALLOWBLE_HIERARCHY(long LAW_AGENCY_TYPE, long ALLOWBLE_HIERARCHY)
			{
				this.LAW_AGENCY_TYPE = LAW_AGENCY_TYPE;
				this.ALLOWBLE_HIERARCHY = ALLOWBLE_HIERARCHY;
			}

			/// <summary>
			/// Gets the ALLOWBLE_HIERARCHY
			/// </summary>
			public long ALLOWBLE_HIERARCHY { get; }

			/// <summary>
			/// Gets the LAW_AGENCY_TYPE
			/// </summary>
			public long LAW_AGENCY_TYPE { get; }
		}

		/// <summary>
		/// Defines the <see cref="LAW_AGENCY_TYPE" />
		/// </summary>
		private class LAW_AGENCY_TYPE
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="LAW_AGENCY_TYPE"/> class.
			/// </summary>
			/// <param name="ID">The ID<see cref="long"/></param>
			/// <param name="NAME">The NAME<see cref="string"/></param>
			/// <param name="MANDATORY_CODE">The MANDATORY_CODE<see cref="bool"/></param>
			public LAW_AGENCY_TYPE(long ID, string NAME, bool MANDATORY_CODE)
			{
				this.ID = ID;
				this.MANDATORY_CODE = MANDATORY_CODE;
				this.NAME = NAME;
			}

			/// <summary>
			/// Gets the ID
			/// </summary>
			public long ID { get; }

			/// <summary>
			/// Gets a value indicating whether MANDATORY_CODE
			/// </summary>
			public bool MANDATORY_CODE { get; }

			/// <summary>
			/// Gets the NAME
			/// </summary>
			public string NAME { get; }
		}

		/// <summary>
		/// Defines the <see cref="SPECIAL_TERRITORIAL_CODE" />
		/// </summary>
		private class SPECIAL_TERRITORIAL_CODE
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="SPECIAL_TERRITORIAL_CODE"/> class.
			/// </summary>
			/// <param name="ID">The ID<see cref="long"/></param>
			/// <param name="NAME">The NAME<see cref="string"/></param>
			public SPECIAL_TERRITORIAL_CODE(long ID, string NAME)
			{
				this.ID = ID;
				this.NAME = NAME;
			}

			/// <summary>
			/// Gets the ID
			/// </summary>
			public long ID { get; }

			/// <summary>
			/// Gets the NAME
			/// </summary>
			public string NAME { get; }
		}
	}
}
