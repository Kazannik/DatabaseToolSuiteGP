using System;

namespace DatabaseToolSuite.Services
{
    static class FileSystem
    {
        private static readonly Repositoryes.DatabaseRepository repository = new Repositoryes.DatabaseRepository();
        
        public static Repositoryes.DatabaseRepository Repository
        {
            get { return repository; }
        }
        
        public static string DatabaseFileName { get; private set; }

        public static bool DefaultDatabaseFileExists()
        {
            string fileName = Properties.Settings.Default.DatabaseFileName;
            return System.IO.File.Exists(fileName);
        }

        public static void ReadDatabase()
        {
            ReadDatabase(Properties.Settings.Default.DatabaseFileName);
        }

        public static void ReadDatabase(string xmlFileName)
        {
            DatabaseFileName = xmlFileName;
            Repository.ReadXml(xmlFileName);
            Repository.DataSet.AcceptChanges();
        }

        public static void ReadSchema(string xsdFileName)
        {
            Repository.ReadSchema(xsdFileName);           
        }

        public static void WriteDatabase()
        {
            WriteDatabase(DatabaseFileName);
        }

        public static void WriteDatabase(string xmlFileName)
        {
            DatabaseFileName = xmlFileName;
            Repository.WriteXml(xmlFileName);
            Repository.DataSet.AcceptChanges();
        }
        
        public static void WriteSchema(string xsdFileName)
        {
            Repository.WriteSchema(xsdFileName);
        }
        
        public static void RescueDatabase()
        {            
            Repository.WriteXml(DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_") + Properties.Settings.Default.RescueDatabaseFileName);
        }
    }
}
