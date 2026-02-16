// Ignore Spelling: oktmo vrn DIC

using System;
using System.Data;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		#region WARDING! NOT EDIT!

#pragma warning disable IDE1006 // Стили именования
#pragma warning disable VSSpell001 // Spell Check

		// Delete double in MainDatabase.Desinger.cs

		public partial class okatoRow : DataRow
		{
			public string code
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.codeColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'code\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.codeColumn] = value;
				}
			}

			public string name2
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.name2Column]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'name2\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.name2Column] = value;
				}
			}

			public string centrum
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.centrumColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'centrum\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.centrumColumn] = value;
				}
			}

			public string genitive
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.genitiveColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'genitive\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.genitiveColumn] = value;
				}
			}

			public string lab
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.labColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'lab\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.labColumn] = value;
				}
			}


			public string okato
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.okatoColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'okato\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.okatoColumn] = value;
				}
			}

			public string ssrf
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.ssrfColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'ssrf\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.ssrfColumn] = value;
				}
			}

			public long export_id
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableokato.export_idColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'export_id\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.export_idColumn] = value;
				}
			}

			public string courtsrf
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableokato.courtsrfColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'courtsrf\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableokato.courtsrfColumn] = value;
				}
			}
		}

		public partial class gaspsRow : DataRow
		{
			public long index
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.indexColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'index\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.indexColumn] = value;
				}
			}

			public string code
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tablegasps.codeColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'code\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.codeColumn] = value;
				}
			}

			public long location_okato_id
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.location_okato_idColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'location_okato_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.location_okato_idColumn] = value;
				}
			}

			public long another_okato_id
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.another_okato_idColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'another_okato_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.another_okato_idColumn] = value;
				}
			}

			public long court_type_id
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.court_type_idColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'court_type_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.court_type_idColumn] = value;
				}
			}

			public DateTime logEditDate
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<DateTime>(this[tablegasps.logEditDateColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'logEditDate\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.logEditDateColumn] = value;
				}
			}

			public string import_guid
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tablegasps.import_guidColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'import_guid\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.import_guidColumn] = value;
				}
			}

			public long export_key
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.export_keyColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'export_key\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.export_keyColumn] = value;
				}
			}

			public long export_version
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.export_versionColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'export_version\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.export_versionColumn] = value;
				}
			}

			public long export_id
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.export_idColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'export_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.export_idColumn] = value;
				}
			}

			public long export_ord
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablegasps.export_ordColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'export_ord\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.export_ordColumn] = value;
				}
			}

			public DateTime export_date_beg
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<DateTime>(this[tablegasps.export_date_begColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'export_date_beg\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.export_date_begColumn] = value;
				}
			}

			public DateTime export_data_end
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<DateTime>(this[tablegasps.export_data_endColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'export_data_end\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablegasps.export_data_endColumn] = value;
				}
			}
		}

		public partial class fgis_esnsiRow : DataRow
		{

			public long region_id
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablefgis_esnsi.region_idColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'region_id\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.region_idColumn] = value;
				}
			}

			public string sv_0004
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tablefgis_esnsi.sv_0004Column]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'sv_0004\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.sv_0004Column] = value;
				}
			}

			public string sv_0005
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tablefgis_esnsi.sv_0005Column]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'sv_0005\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.sv_0005Column] = value;
				}
			}

			public string sv_0006
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tablefgis_esnsi.sv_0006Column]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'sv_0006\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.sv_0006Column] = value;
				}
			}

			public short okato
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<short>(this[tablefgis_esnsi.okatoColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'okato\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.okatoColumn] = value;
				}
			}

			public long code
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablefgis_esnsi.codeColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'code\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.codeColumn] = value;
				}
			}

			public string autokey
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tablefgis_esnsi.autokeyColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'autokey\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.autokeyColumn] = value;
				}
			}

			public string okatoList
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tablefgis_esnsi.okatoListColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'okatoList\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.okatoListColumn] = value;
				}
			}

			public long id
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tablefgis_esnsi.idColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'id\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.idColumn] = value;
				}
			}

			public DateTime logEditDate
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<DateTime>(this[tablefgis_esnsi.logEditDateColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'logEditDate\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[tablefgis_esnsi.logEditDateColumn] = value;
				}
			}
		}

		public partial class ervkRow : DataRow
		{
			public long idVersionHead
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableervk.idVersionHeadColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'idVersionHead\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.idVersionHeadColumn] = value;
				}
			}

			public long idSuccession
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableervk.idSuccessionColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'idSuccession\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.idSuccessionColumn] = value;
				}
			}

			public DateTime dateCloseProc
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<DateTime>(this[tableervk.dateCloseProcColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'dateCloseProc\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.dateCloseProcColumn] = value;
				}
			}

			public string ogrn
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableervk.ogrnColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'ogrn\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.ogrnColumn] = value;
				}
			}

			public string inn
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableervk.innColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'inn\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.innColumn] = value;
				}
			}

			public string subjectRfList
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableervk.subjectRfListColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'subjectRfList\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.subjectRfListColumn] = value;
				}
			}

			public string oktmoList
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableervk.oktmoListColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'oktmoList\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.oktmoListColumn] = value;
				}
			}

			public DateTime logEditDate
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<DateTime>(this[tableervk.logEditDateColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'logEditDate\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableervk.logEditDateColumn] = value;
				}
			}
		}

		public partial class EXP_LAW_AGENCY_URPRow : DataRow
		{
			public long AGENCY_RECEIVING_REPORT
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableEXP_LAW_AGENCY_URP.AGENCY_RECEIVING_REPORTColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'AGENCY_RECEIVING_REPORT\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableEXP_LAW_AGENCY_URP.AGENCY_RECEIVING_REPORTColumn] = value;
				}
			}

			public long ORD
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableEXP_LAW_AGENCY_URP.ORDColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'ORD\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableEXP_LAW_AGENCY_URP.ORDColumn] = value;
				}
			}

			public string VED_CODE
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableEXP_LAW_AGENCY_URP.VED_CODEColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'VED_CODE\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableEXP_LAW_AGENCY_URP.VED_CODEColumn] = value;
				}
			}

			public long ID
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableEXP_LAW_AGENCY_URP.IDColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'ID\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableEXP_LAW_AGENCY_URP.IDColumn] = value;
				}
			}

			public long LAW_AGENCY_TYPE
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableEXP_LAW_AGENCY_URP.LAW_AGENCY_TYPEColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'LAW_AGENCY_TYPE\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableEXP_LAW_AGENCY_URP.LAW_AGENCY_TYPEColumn] = value;
				}
			}

			public long SPECIAL_TERRITORIAL_CODE
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<long>(this[tableEXP_LAW_AGENCY_URP.SPECIAL_TERRITORIAL_CODEColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'SPECIAL_TERRITORIAL_CODE\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableEXP_LAW_AGENCY_URP.SPECIAL_TERRITORIAL_CODEColumn] = value;
				}
			}
		}

		public partial class SPECIAL_TERRITORIAL_CODERow : DataRow
		{
			public string NAME
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableSPECIAL_TERRITORIAL_CODE.NAMEColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'NAME\' в таблице \'SPECIAL_TERRITORIAL_CODE\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableSPECIAL_TERRITORIAL_CODE.NAMEColumn] = value;
				}
			}

		}

		public partial class DIC_RECORDRow : DataRow
		{
			public string ADRESS
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableDIC_RECORD.ADRESSColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'ADRESS\' в таблице \'DIC_RECORD\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableDIC_RECORD.ADRESSColumn] = value;
				}
			}

			public string PRIM
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableDIC_RECORD.PRIMColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'PRIM\' в таблице \'DIC_RECORD\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableDIC_RECORD.PRIMColumn] = value;
				}
			}

			public string FAKTADDRESSES
			{
				get
				{
					try
					{
						return Utils.Database.ConvertFromDBVal<string>(this[tableDIC_RECORD.FAKTADDRESSESColumn]);
					}
					catch (InvalidCastException e)
					{
						throw new StrongTypingException("Значение для столбца \'FAKTADDRESSES\' в таблице \'DIC_RECORD\' равно DBNull.", e);
					}
				}
				set
				{
					this[tableDIC_RECORD.FAKTADDRESSESColumn] = value;
				}
			}
		}

#pragma warning restore VSSpell001 // Spell Check
#pragma warning restore IDE1006 // Стили именования
		#endregion
	}
}

