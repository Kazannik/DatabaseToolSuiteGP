using System;
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
            return courtTypeTable.ExistsId(id);
        }

        public bool ExistsCourtTypeName(string name)
        {
            return courtTypeTable.ExistsName(name);
        }

        public string GetCourtTypeName(long id)
        {
            return courtTypeTable.GetName(id);
        }

        public bool ExistsOkatoCode(string code)
        {
            return okatoTable.ExistsCode(code);
        }

        public bool ExistsOkatoName(string name)
        {
            return okatoTable.ExistsName(name);
        }

        public bool ExistsOkatoName2(string name2)
        {
            return okatoTable.ExistsName2(name2);
        }

        public bool ExistsOkatoCentrum(string centrum)
        {
            return okatoTable.ExistsCentrum(centrum);
        }

        public bool ExistsOkatoGenitive(string genitive)
        {
            return okatoTable.ExistsGenitive(genitive);
        }

        public string GetOkatoName(string code)
        {
            return okatoTable.GetName(code);
        }

        public string GetOkatoName2(string code)
        {
            return okatoTable.GetName2(code);
        }

        public string GetOkatoGenitive(string code)
        {
            return okatoTable.GetGenitive(code);
        }

        private gaspsDataTable gaspsTable
        {
            get { return Services.MasterDataSystem.DataSet.gasps; }
        }

        private authorityDataTable authorityTable
        {
            get { return Services.MasterDataSystem.DataSet.authority; }
        }

        private okatoDataTable okatoTable
        {
            get { return Services.MasterDataSystem.DataSet.okato; }
        }

        private court_typeDataTable courtTypeTable
        {
            get { return Services.MasterDataSystem.DataSet.court_type; }
        }

        private fgis_esnsiDataTable fgisesnsiTable
        {
            get { return Services.MasterDataSystem.DataSet.fgis_esnsi; }
        }

        private ervkDataTable ervkTable
        {
            get { return Services.MasterDataSystem.DataSet.ervk; }
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