using DatabaseToolSuite.Repositories._1C;
using System;
using System.Data;
using System.Threading.Tasks;
using GaspsDataSet = DatabaseToolSuite.Repositories.EXP_LAW_AGENCY;

namespace DatabaseToolSuite.Repositories
{
	class DatabasesRepository
	{
		public MainDataSet MainDataSet { get; }

		public GaspsDataSet GaspsDataSet { get; }

		public SubdivisionCollection Subdivisions { get; }

		public bool IsInitialize { get; private set; }

		private void Initialize(string schema)
		{
			try
			{
				MainDataSet.Reset();
				MainDataSet.ReadXmlSchema(schema);
				IsInitialize = true;
			}
			catch (Exception)
			{
				IsInitialize = false;
			}
		}


		public DatabasesRepository()
		{
			MainDataSet = new MainDataSet();
			GaspsDataSet = new GaspsDataSet();
			Subdivisions = new SubdivisionCollection();

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
			MainDataSet.Clear();
			MainDataSet.ReadXml(filename, XmlReadMode.IgnoreSchema);
		}

		public void WriteSchema(string fileName)
		{
			MainDataSet.WriteXmlSchema(fileName);
		}

		public void WriteXml(string filename)
		{
			MainDataSet.WriteXml(filename, XmlWriteMode.IgnoreSchema);
		}

		public void GaspsWriteSchema(string fileName)
		{
			GaspsDataSet.WriteXmlSchema(fileName);
		}

		public void GaspsWriteXml(string filename)
		{
			GaspsDataSet.WriteXml(filename, XmlWriteMode.IgnoreSchema);
		}

		public void SubdivisionsReadXml(string filename)
		{
			Subdivisions.Clear();
			Subdivisions.ReadXml(filename);
		}

		public async Task SubdivisionsReadXmlAsync(string filename)
		{
			Subdivisions.Clear();
			await Subdivisions.ReadXmlAsync(filename);
		}
	}
}
