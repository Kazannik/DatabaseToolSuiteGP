using System;
using System.Data;

namespace DatabaseToolSuite.Repositoryes
{
    class DatabaseRepository
    {
        RepositoryDataSet _dataSet;

        public RepositoryDataSet DataSet { get { return _dataSet; } }

        public bool IsInitialize { get; private set; }

        private void Initialize(string schema)
        {
            try
            {
                _dataSet.Reset();
                _dataSet.ReadXmlSchema(schema);
                IsInitialize = true;
            }
            catch (Exception)
            {
                IsInitialize = false;
            }            
        }


        public DatabaseRepository()
        {
             _dataSet = new RepositoryDataSet();

            if (System.IO.File.Exists("DatabaseXMLSchema.xsd"))
            {
                Initialize("DatabaseXMLSchema.xsd");
            }
        }

        public void ReadSchema(string schemaFilename)
        {
            Initialize(schemaFilename);
        }

        public void ReadXml(string filename)
        {
            _dataSet.Clear();
            _dataSet.ReadXml(filename, XmlReadMode.IgnoreSchema);
        }

        public void WriteSchema(string fileName)
        {
            _dataSet.WriteXmlSchema(fileName);
        }

        public void WriteXml(string filename)
        {
            _dataSet.WriteXml(filename, XmlWriteMode.IgnoreSchema);
        }
    }
}
