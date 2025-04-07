// Ignore Spelling: okato ord centrum ssrf fgis esnsi sv autokey ervk ogrn oktmo VED

using System.Collections.Generic;
using System.Data;
using System.Linq;
using urpDataTable = DatabaseToolSuite.Repositories.MainDataSet.EXP_LAW_AGENCY_URPDataTable;

namespace DatabaseToolSuite.Repositories
{
	internal partial class MainDataSet
	{
		public bool ExistsCourtTypeId(long id)
		{
			return CourtTypeTable.ExistsId(id);
		}

		public bool ExistsCourtTypeName(string name)
		{
			return CourtTypeTable.ExistsName(name);
		}

		public string GetCourtTypeName(long id)
		{
			return CourtTypeTable.GetName(id);
		}

		public bool ExistsOkatoCode(string code)
		{
			return OkatoTable.ExistsCode(code);
		}

		public bool ExistsOkatoName(string name)
		{
			return OkatoTable.ExistsName(name);
		}

		public bool ExistsOkatoName2(string name2)
		{
			return OkatoTable.ExistsName2(name2);
		}

		public bool ExistsOkatoCentrum(string centrum)
		{
			return OkatoTable.ExistsCentrum(centrum);
		}

		public bool ExistsOkatoGenitive(string genitive)
		{
			return OkatoTable.ExistsGenitive(genitive);
		}

		public string GetOkatoName(string code)
		{
			return OkatoTable.GetName(code);
		}

		public string GetOkatoName2(string code)
		{
			return OkatoTable.GetName2(code);
		}

		public string GetOkatoGenitive(string code)
		{
			return OkatoTable.GetGenitive(code);
		}

		private gaspsDataTable GaspsTable
		{
			get { return Services.MasterDataSystem.DataSet.gasps; }
		}

		private authorityDataTable AuthorityTable
		{
			get { return Services.MasterDataSystem.DataSet.authority; }
		}

		private okatoDataTable OkatoTable
		{
			get { return Services.MasterDataSystem.DataSet.okato; }
		}

		private court_typeDataTable CourtTypeTable
		{
			get { return Services.MasterDataSystem.DataSet.court_type; }
		}

		private fgis_esnsiDataTable FgisesnsiTable
		{
			get { return Services.MasterDataSystem.DataSet.fgis_esnsi; }
		}

		private ervkDataTable ErvkTable
		{
			get { return Services.MasterDataSystem.DataSet.ervk; }
		}

		private urpDataTable UrpTable
		{
			get { return Services.MasterDataSystem.DataSet.EXP_LAW_AGENCY_URP; }
		}

		public class GaspsRowComparer : IComparer<gaspsRow>
		{
			public int Compare(gaspsRow x, gaspsRow y)
			{
				int compare = x.authority_id.CompareTo(y.authority_id);
				if (compare != 0) return compare;

				compare = x.okato_code.CompareTo(y.okato_code);
				if (compare != 0) return compare;

				compare = x.name.CompareTo(y.name);
				if (compare != 0) return compare;

				compare = x.date_beg.CompareTo(y.date_beg);
				if (compare != 0) return compare;

				compare = x.date_end.CompareTo(y.date_end) * -1;
				if (compare != 0) return compare;

				return x.version.CompareTo(y.version);
			}
		}

		public partial class court_typeDataTable
		{
			public bool ExistsId(long id)
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

			public string GetName(long id)
			{
				return (from item in this.AsEnumerable()
						where item.id == id
						select item).First().name;
			}
		}

		public partial class authorityDataTable
		{
			public bool ExistsId(long id)
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

			public string GetName(long id)
			{
				return (from item in this.AsEnumerable()
						where item.id == id
						select item).First().name;
			}
		}

		public partial class okatoDataTable
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
						where code.Equals(item.code)
						select item).First().name;
			}

			public string GetName2(string code)
			{
				return (from item in this.AsEnumerable()
						where code.Equals(item.code)
						select item).First().name2;
			}

			public string GetGenitive(string code)
			{
				return (from item in this.AsEnumerable()
						where code.Equals(item.code)
						select item).First().genitive;
			}

			public okatoRow Get(string code)
			{
				return (from item in this.AsEnumerable()
						where code.Equals(item.code)
						select item).First();
			}
		}


		#region NOT EDIT

		public partial class okatoRow : DataRow
		{

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string code
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableokato.codeColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'code\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.codeColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string name2
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableokato.name2Column]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'name2\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.name2Column] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string centrum
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableokato.centrumColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'centrum\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.centrumColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string genitive
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableokato.genitiveColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'genitive\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.genitiveColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string lab
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableokato.labColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'lab\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.labColumn] = value;
				}
			}


			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string okato
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableokato.okatoColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'okato\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.okatoColumn] = value;
				}
			}


			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string ssrf
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableokato.ssrfColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'ssrf\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.ssrfColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long export_id
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableokato.export_idColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'export_id\' в таблице \'okato\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableokato.export_idColumn] = value;
				}
			}
		}

		public partial class gaspsRow : DataRow
		{
			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long index
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.indexColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'index\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.indexColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string code
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tablegasps.codeColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'code\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.codeColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long location_okato_id
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.location_okato_idColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'location_okato_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.location_okato_idColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long another_okato_id
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.another_okato_idColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'another_okato_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.another_okato_idColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long court_type_id
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.court_type_idColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'court_type_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.court_type_idColumn] = value;
				}
			}


			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public System.DateTime logEditDate
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<global::System.DateTime>(this[this.tablegasps.logEditDateColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'logEditDate\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.logEditDateColumn] = value;
				}
			}


			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string import_guid
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tablegasps.import_guidColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'import_guid\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.import_guidColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long export_key
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.export_keyColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'export_key\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.export_keyColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long export_version
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.export_versionColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'export_version\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.export_versionColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long export_id
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.export_idColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'export_id\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.export_idColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long export_ord
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablegasps.export_ordColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'export_ord\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.export_ordColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public System.DateTime export_date_beg
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<global::System.DateTime>(this[this.tablegasps.export_date_begColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'export_date_beg\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.export_date_begColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public System.DateTime export_data_end
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<global::System.DateTime>(this[this.tablegasps.export_data_endColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'export_data_end\' в таблице \'gasps\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablegasps.export_data_endColumn] = value;
				}
			}
		}

		public partial class fgis_esnsiRow : DataRow
		{

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long region_id
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablefgis_esnsi.region_idColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'region_id\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.region_idColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string sv_0004
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tablefgis_esnsi.sv_0004Column]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'sv_0004\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.sv_0004Column] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string sv_0005
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tablefgis_esnsi.sv_0005Column]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'sv_0005\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.sv_0005Column] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string sv_0006
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tablefgis_esnsi.sv_0006Column]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'sv_0006\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.sv_0006Column] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public short okato
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<short>(this[this.tablefgis_esnsi.okatoColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'okato\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.okatoColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long code
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablefgis_esnsi.codeColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'code\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.codeColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string autokey
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tablefgis_esnsi.autokeyColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'autokey\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.autokeyColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long id
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tablefgis_esnsi.idColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'id\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.idColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public System.DateTime logEditDate
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<global::System.DateTime>(this[this.tablefgis_esnsi.logEditDateColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'logEditDate\' в таблице \'fgis_esnsi\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tablefgis_esnsi.logEditDateColumn] = value;
				}
			}
		}

		public partial class ervkRow : DataRow
		{
			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long idVersionHead
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableervk.idVersionHeadColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'idVersionHead\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.idVersionHeadColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long idSuccession
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableervk.idSuccessionColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'idSuccession\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.idSuccessionColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public System.DateTime dateCloseProc
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<global::System.DateTime>(this[this.tableervk.dateCloseProcColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'dateCloseProc\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.dateCloseProcColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string ogrn
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableervk.ogrnColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'ogrn\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.ogrnColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string inn
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableervk.innColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'inn\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.innColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string subjectRfList
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableervk.subjectRfListColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'subjectRfList\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.subjectRfListColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string oktmoList
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableervk.oktmoListColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'oktmoList\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.oktmoListColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public System.DateTime logEditDate
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<global::System.DateTime>(this[this.tableervk.logEditDateColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'logEditDate\' в таблице \'ervk\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableervk.logEditDateColumn] = value;
				}
			}
		}

		public partial class EXP_LAW_AGENCY_URPRow : DataRow
		{

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long AGENCY_RECEIVING_REPORT
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableEXP_LAW_AGENCY_URP.AGENCY_RECEIVING_REPORTColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'AGENCY_RECEIVING_REPORT\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableEXP_LAW_AGENCY_URP.AGENCY_RECEIVING_REPORTColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long ORD
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableEXP_LAW_AGENCY_URP.ORDColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'ORD\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableEXP_LAW_AGENCY_URP.ORDColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string VED_CODE
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableEXP_LAW_AGENCY_URP.VED_CODEColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'VED_CODE\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableEXP_LAW_AGENCY_URP.VED_CODEColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long ID
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableEXP_LAW_AGENCY_URP.IDColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'ID\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableEXP_LAW_AGENCY_URP.IDColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long LAW_AGENCY_TYPE
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableEXP_LAW_AGENCY_URP.LAW_AGENCY_TYPEColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'LAW_AGENCY_TYPE\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableEXP_LAW_AGENCY_URP.LAW_AGENCY_TYPEColumn] = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public long SPECIAL_TERRITORIAL_CODE
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<long>(this[this.tableEXP_LAW_AGENCY_URP.SPECIAL_TERRITORIAL_CODEColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'SPECIAL_TERRITORIAL_CODE\' в таблице \'EXP_LAW_AGENCY_URP\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableEXP_LAW_AGENCY_URP.SPECIAL_TERRITORIAL_CODEColumn] = value;
				}
			}
		}

		public partial class SPECIAL_TERRITORIAL_CODERow : DataRow
		{
			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
			public string NAME
			{
				get
				{
					try
					{
						return (Utils.Database.ConvertFromDBVal<string>(this[this.tableSPECIAL_TERRITORIAL_CODE.NAMEColumn]));
					}
					catch (global::System.InvalidCastException e)
					{
						throw new global::System.Data.StrongTypingException("Значение для столбца \'NAME\' в таблице \'SPECIAL_TERRITORIAL_CODE\' равно DBNull.", e);
					}
				}
				set
				{
					this[this.tableSPECIAL_TERRITORIAL_CODE.NAMEColumn] = value;
				}
			}

		}

		#endregion
	}
}