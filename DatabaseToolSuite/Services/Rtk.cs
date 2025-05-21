// Ignore Spelling: Oktmo Allowble

using DatabaseToolSuite.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls.Expressions;
using ExportDataSet = DatabaseToolSuite.Repositories.EXP_LAW_AGENCY;

namespace DatabaseToolSuite.Services
{
	/// <summary>
	/// Сервис для подготовки базы к передаче в РТК
	/// </summary>
	internal static class Rtk
	{
		public static ExportDataSet DataSet
		{
			get { return FileSystem.Repository.GaspsDataSet; }
		}

		public static void ExportToXml(string xmlFileName)
		{
			DataSet.WriteXml(xmlFileName, XmlWriteMode.WriteSchema);
		}

		public static void ConvertDataBase()
		{
			DataSet.Clear();

			EntityCollection oktmo = ConvertOktmo();
			_ = ConvertAuthority();
			_ = ConvertLawAgencyTypeAllowbleHierarchy();
			_ = ConvertLawAgencyTypes();
			_ = ConvertSpecialTerritorialCode();

			IEnumerable<MainDataSet.ViewUrpOrganization> gasps = MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP.ExportGaspsFullData();

			long ord = 1;
			foreach (MainDataSet.ViewUrpOrganization item in gasps)
			{
				long oktmoId = oktmo[item.OkatoCode].Id;
				CreateLawAgency(name: item.Name, uniq: item.Code, oktmo: oktmoId, ved_id: item.AuthorityId, version: item.Version,
					ord: ord, id: item.Key, parent_id: item.OwnerId, indate: item.Begin, outdate: item.End,
					oktmo_loc_id: item.OktmoLocId, law_agency_type: item.LawAgencyType,
					special_territorial_code: item.SpecialTerritorialCode);

				if (item.IsUrp)
				{
					CreateLawAgencyUrp(version: item.Version, shortName: item.ShortName, doesntCreateCard: item.DoesntCreateCard,
						doesntSingReport: item.DoesntSingReport, doesntConsolidateChild: item.DoesntConsolidateChild,
						agencyReceivingReport: item.AgencyReceivingReport, ord: item.Ord, vedCode: item.VedCode, id: item.Id,
						oktmoLocId: item.OktmoLocId);
				}
			}
		}

		public static EntityCollection ConvertOktmo()
		{
			EntityCollection result = new EntityCollection();
			foreach (MainDataSet.okatoRow row in MasterDataSystem.DataSet.okato.Rows)
			{
				if (!row.Isexport_idNull() && !result.Contains(row.export_id))
					result.Add(row.export_id, row.code, row.name);
			}

			foreach (MainDataSet.okatoRow row in
				(from MainDataSet.okatoRow row in MasterDataSystem.DataSet.okato.Rows
				 where row.Isexport_idNull()
				 orderby row.code
				 select row)
				 .ToArray())
			{
				if (!result.Contains(row.export_id))
				{
					long exportId = result.Add(row.code, row.name);
					row.export_id = exportId;
				}
			}

			foreach (EntityCollection.IEntity entity in result)
			{
				CreateOktmo(entity);
			}
			return result;
		}

		public static EntityCollection ConvertAuthority()
		{
			EntityCollection result = new EntityCollection();

			foreach (MainDataSet.authorityRow row in
				(from MainDataSet.authorityRow row in MasterDataSystem.DataSet.authority.Rows
				 orderby row.id
				 select row)
				 .ToArray())
			{
				if (!result.Contains(row.id))
				{
					result.Add(row.id, row.code, row.name);
				}
			}

			foreach (EntityCollection.IEntity entity in result)
			{
				CreateVed(entity);
			}
			return result;
		}

		public static EntityCollection ConvertLawAgencyTypes()
		{
			EntityCollection result = new EntityCollection();

			foreach (MainDataSet.EXP_LAW_AGENCY_TYPESRow row in
				(from MainDataSet.EXP_LAW_AGENCY_TYPESRow row in MasterDataSystem.DataSet.EXP_LAW_AGENCY_TYPES.Rows
				 orderby row.ID
				 select row)
				 .ToArray())
			{
				if (!result.Contains(row.ID))
				{
					result.Add(row.ID, row.MANDATORY_CODE, row.NAME);
				}
			}

			foreach (EntityCollection.IEntity entity in result)
			{
				CreateLawAgencyTypes(entity);
			}
			return result;
		}

		public static EntityCollection ConvertSpecialTerritorialCode()
		{
			EntityCollection result = new EntityCollection();

			foreach (MainDataSet.SPECIAL_TERRITORIAL_CODERow row in
				(from MainDataSet.SPECIAL_TERRITORIAL_CODERow row in MasterDataSystem.DataSet.SPECIAL_TERRITORIAL_CODE.Rows
				 orderby row.ID
				 select row)
				 .ToArray())
			{
				if (!result.Contains(row.ID))
				{
					result.Add(row.ID, row.ID.ToString(), row.NAME);
				}
			}

			foreach (EntityCollection.IEntity entity in result)
			{
				CreateSpecialTerritorialCode(entity);
			}
			return result;
		}

		public static EntityCollection ConvertLawAgencyTypeAllowbleHierarchy()
		{
			EntityCollection result = new EntityCollection();

			foreach (MainDataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHYRow row in
				(from MainDataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHYRow row in MasterDataSystem.DataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHY.Rows
				 orderby row.ALLOWBLE_HIERARCHY
				 orderby row.LAW_AGENCY_TYPE
				 select row)
				 .ToArray())
			{
				result.Add(row.LAW_AGENCY_TYPE, row.ALLOWBLE_HIERARCHY);
			}

			foreach (EntityCollection.IEntity entity in result)
			{
				CreateLawAgencyTypeAllowbleHierarchy(entity);
			}
			return result;
		}

		public class EntityCollection : CollectionBase, IEnumerable<EntityCollection.IEntity>
		{
			public void Add(IEntity item)
			{
				InnerList.Add(item);
			}

			public long Add(string code, string name)
			{
				long id = GetNextId();
				Add(id, code, name);
				return id;
			}

			public void Add(long id, string code, string name)
			{
				InnerList.Add(Entity.Create(id, code, name));
			}

			public void Add(long id, bool booleanArg, string name)
			{
				InnerList.Add(Entity.Create(id, id.ToString(), name, booleanArg));
			}

			public void Add(long arg1, long arg2)
			{
				InnerList.Add(Entity.Create(arg1, arg2));
			}

			public void Remove(IEntity item)
			{
				InnerList.Remove(item);
			}

			public bool Contains(long id)
			{
				return this.AsEnumerable()
						.Where(x => x.Id.Equals(id))
						.Any();
			}

			public bool Contains(string code)
			{
				return this.AsEnumerable()
						.Where(x => x.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase))
						.Any();
			}

			public IEntity this[long id]
			{
				get
				{
					IEnumerable<IEntity> array = this.AsEnumerable()
						.Where(x => x.Id.Equals(id));
					if (array.Any())
					{
						return array.First();
					}
					else
					{
						throw new ArgumentOutOfRangeException();
					}
				}
			}

			public IEntity this[string code]
			{
				get
				{
					IEnumerable<IEntity> array = this.AsEnumerable()
						.Where(x => x.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
					if (array.Any())
					{
						return array.First();
					}
					else
					{
						throw new ArgumentOutOfRangeException();
					}
				}
			}

			IEnumerator<IEntity> IEnumerable<IEntity>.GetEnumerator()
			{
				return new EntityEnumerator(InnerList);
			}

			private IEnumerator PrGetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return PrGetEnumerator();
			}

			private long GetNextId()
			{
				if (Count > 0)
					return 1 + this.AsEnumerable()
						.Max(e => e.Id);
				else
					return 1;
			}

			public interface IEntity
			{
				long Id { get; }
				string Name { get; }
				string Code { get; }
				bool BooleanArg { get; }
				long LongArg { get; }
			}

			private class Entity : IEntity
			{
				public static IEntity Create(long id, string code, string name)
				{
					return new Entity(id, code, name, false, -1);
				}

				public static IEntity Create(long id, string code, string name, bool booleanArg)
				{
					return new Entity(id, code, name, booleanArg, -1);
				}

				public static IEntity Create(long id, long longArg)
				{
					return new Entity(id, string.Empty, string.Empty, false, longArg);
				}

				private Entity(long id, string code, string name, bool booleanArg, long longArg)
				{
					Id = id;
					Name = name;
					Code = code;
					BooleanArg = booleanArg;
					LongArg = longArg;
				}

				public long Id { get; }
				public string Name { get; }
				public string Code { get; }

				public bool BooleanArg { get; }
				public long LongArg { get; }
			}

			public class EntityEnumerator : IEnumerator<IEntity>
			{
				private readonly ArrayList array;
				private int position;

				public EntityEnumerator(ArrayList array)
				{
					this.array = array;
					this.array.Sort(new EntityComparer());
					position = -1;
				}

				private IEntity current;

				public IEntity Current
				{
					get
					{
						if (array == null || current == null)
						{
							throw new InvalidOperationException();
						}
						return current;
					}
				}

				private object _Current => Current;

				object IEnumerator.Current
				{
					get { return _Current; }
				}

				public bool MoveNext()
				{
					position++;
					if (position >= array.Count)
					{
						return false;
					}
					current = (IEntity)array[position];
					return true;
				}

				public void Reset()
				{
					position = -1;
					current = null;
				}

				private bool disposedValue = false;

				public void Dispose()
				{
					Dispose(disposing: true);
					GC.SuppressFinalize(this);
				}

				protected virtual void Dispose(bool disposing)
				{
					if (!this.disposedValue)
					{
						if (disposing)
						{
							// Dispose of managed resources.
						}
						current = null;
					}
					this.disposedValue = true;
				}

				~EntityEnumerator()
				{
					Dispose(disposing: false);
				}
			}

			public class EntityComparer : IComparer, IComparer<IEntity>
			{
				public int Compare(object x, object y)
				{
					return ((IEntity)x).Id.CompareTo(((IEntity)y).Id);
				}

				int IComparer<IEntity>.Compare(IEntity x, IEntity y)
				{
					return x.Id.CompareTo(y.Id);
				}
			}
		}

		/// <summary>
		/// Создание записи о подразделении правоохранительного органа.
		/// </summary>
		/// <param name="name">Наименование (name)</param>
		/// <param name="uniq">Код (code)</param>
		/// <param name="oktmo">ОКТМО (okato_code)</param>
		/// <param name="ved_id">Ведомство (authority_id)</param>
		/// <param name="version">Версия (version)</param>
		/// <param name="ord">Порядок (нет сопоставимых данных)</param>
		/// <param name="id">Ключ (key)</param>
		/// <param name="parent_id">Родитель (owner_id)</param>
		/// <param name="indate">Дата начала (date_beg)</param>
		/// <param name="outdate">Дата окончания (date_end)</param>
		/// <param name="oktmo_loc_id">Место дислокации (ОКТМО) (location_okato_id)</param>
		/// <param name="law_agency_type">Тип подразделений (таблица: exp_law_agency_types)</param>
		/// <param name="special_territorial_code">Специализированный территориальный код (таблица: special_territorial_code)</param>
		/// <returns></returns>
		private static ExportDataSet.exp_law_agency_okatoidRow CreateLawAgency(
			string name,
			string uniq,
			long oktmo,
			long ved_id,
			long version,
			long ord,
			long id,
			long parent_id,
			DateTime indate,
			DateTime outdate,
			long oktmo_loc_id,
			long law_agency_type,
			long special_territorial_code)
		{
			object[] values = new object[13];
			values[0] = name;
			values[1] = uniq;
			values[2] = oktmo;
			values[3] = ved_id;
			values[4] = version;
			values[5] = ord;
			values[6] = id;
			values[7] = parent_id;
			values[8] = indate;
			values[9] = outdate;
			values[10] = oktmo_loc_id;
			values[11] = law_agency_type;
			values[12] = special_territorial_code;

			ExportDataSet.exp_law_agency_okatoidRow newRow =
				(ExportDataSet.exp_law_agency_okatoidRow)DataSet.exp_law_agency_okatoid.Rows.Add(values);

			return newRow;
		}

		/// <summary>
		/// Создание записи УРП ГАС ПС
		/// </summary>
		/// <param name="version">Версия подразделения</param>
		/// <param name="shortName">Краткое наименование </param>
		/// <param name="doesntCreateCard">Не создаёт карточки </param>
		/// <param name="doesntSingReport">Не подписывает отчёт</param>
		/// <param name="doesntConsolidateChild">Не консолидирует дочерние</param>
		/// <param name="agencyReceivingReport">Передаёт отчёт в (см. exp_law_agency_okatoid.id)</param>
		/// <param name="ord">Порядок</param>
		/// <param name="vedCode">Ведомственный код</param>
		/// <param name="id">Ключ</param>
		/// <param name="oktmoLocId">ОКТМО территории обслуживания (см. t6292734.id) </param>
		/// <returns></returns>
		private static ExportDataSet.EXP_LAW_AGENCY_URPRow CreateLawAgencyUrp(
			long version,
			string shortName,
			bool doesntCreateCard,
			bool doesntSingReport,
			bool doesntConsolidateChild,
			long agencyReceivingReport,
			long ord,
			string vedCode,
			long id,
			long oktmoLocId
			)
		{
			object[] values = new object[10];
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

			ExportDataSet.EXP_LAW_AGENCY_URPRow newRow =
				(ExportDataSet.EXP_LAW_AGENCY_URPRow)DataSet.EXP_LAW_AGENCY_URP.Rows.Add(values);

			return newRow;
		}

		private static ExportDataSet.t6292734Row CreateOktmo(EntityCollection.IEntity entity)
		{
			return CreateOktmo(id: entity.Id, code: entity.Code, name: entity.Name);
		}

		private static ExportDataSet.t6292734Row CreateOktmo(long id, string code, string name)
		{
			object[] values = new object[3];
			values[0] = id; // ID
			values[1] = code; // CODE
			values[2] = name; // NAME

			ExportDataSet.t6292734Row newRow =
				(ExportDataSet.t6292734Row)DataSet.t6292734.Rows.Add(values);
			return newRow;
		}

		private static ExportDataSet.t6301724Row CreateVed(EntityCollection.IEntity entity)
		{
			return CreateVed(id: entity.Id, code: entity.Code, name: entity.Name);
		}

		private static ExportDataSet.t6301724Row CreateVed(long id, string code, string name)
		{
			object[] values = new object[3];
			values[0] = id; // ID
			values[1] = code; // CODE
			values[2] = name; // NAME

			ExportDataSet.t6301724Row newRow =
				(ExportDataSet.t6301724Row)DataSet.t6301724.Rows.Add(values);
			return newRow;
		}

		private static ExportDataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHYRow CreateLawAgencyTypeAllowbleHierarchy(EntityCollection.IEntity entity)
		{
			return CreateLawAgencyTypeAllowbleHierarchy(agencyType: entity.Id, allowbleHierarchy: entity.LongArg);
		}

		private static ExportDataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHYRow CreateLawAgencyTypeAllowbleHierarchy(long agencyType, long allowbleHierarchy)
		{
			object[] values = new object[2];
			values[0] = agencyType; // AGENCY_TYPE
			values[1] = allowbleHierarchy; // ALLOWBLE_HIERARCHY

			ExportDataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHYRow newRow =
				(ExportDataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHYRow)DataSet.EXP_LAW_AGENCY_ALLOWBLE_HIERARCHY.Rows.Add(values);
			return newRow;
		}

		private static ExportDataSet.EXP_LAW_AGENCY_TYPESRow CreateLawAgencyTypes(EntityCollection.IEntity entity)
		{
			return CreateLawAgencyTypes(id: entity.Id, mandatoryCode: entity.BooleanArg, name: entity.Name);
		}

		private static ExportDataSet.EXP_LAW_AGENCY_TYPESRow CreateLawAgencyTypes(long id, bool mandatoryCode, string name)
		{
			object[] values = new object[3];
			values[0] = id; // ID
			values[1] = mandatoryCode; // MANDATORY_CODE
			values[2] = name; // NAME

			ExportDataSet.EXP_LAW_AGENCY_TYPESRow newRow =
				(ExportDataSet.EXP_LAW_AGENCY_TYPESRow)DataSet.EXP_LAW_AGENCY_TYPES.Rows.Add(values);
			return newRow;
		}

		private static ExportDataSet.SPECIAL_TERRITORIAL_CODERow CreateSpecialTerritorialCode(EntityCollection.IEntity entity)
		{
			return CreateSpecialTerritorialCode(id: entity.Id, code: entity.Code, name: entity.Name);
		}

		private static ExportDataSet.SPECIAL_TERRITORIAL_CODERow CreateSpecialTerritorialCode(long id, string code, string name)
		{
			object[] values = new object[3];
			values[0] = id; // ID
			values[1] = code; // CODE
			values[2] = name; // NAME

			ExportDataSet.SPECIAL_TERRITORIAL_CODERow newRow =
				(ExportDataSet.SPECIAL_TERRITORIAL_CODERow)DataSet.SPECIAL_TERRITORIAL_CODE.Rows.Add(values);
			return newRow;
		}
	}
}