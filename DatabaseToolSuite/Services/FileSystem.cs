using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DatabaseToolSuite.Services
{
	/// <summary>
	/// Класс для работы с файлами базы данных
	/// </summary>
	static class FileSystem
	{
		public static Repositories.DatabasesRepository Repository { get; } = new Repositories.DatabasesRepository();

		public static string DatabaseFileName { get; private set; }

		public static bool DefaultDatabaseFileExists()
		{
			string fileName = Properties.Settings.Default.DatabaseFileName;
			return File.Exists(fileName);
		}

		public static void ReadDatabase()
		{
			ReadDatabase(Properties.Settings.Default.DatabaseFileName);
		}

		public static void ReadDatabase(string xmlFileName)
		{
			DatabaseFileName = xmlFileName;
			Repository.ReadXml(xmlFileName);
			Repository.MainDataSet.AcceptChanges();
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
			Cursor.Current = Cursors.WaitCursor;

			DatabaseFileName = xmlFileName;
			Repository.WriteXml(xmlFileName);
			Repository.MainDataSet.AcceptChanges();

			Cursor.Current = Cursors.Default;
		}

		public static void WriteSchema(string xsdFileName)
		{
			Repository.WriteSchema(xsdFileName);
		}

		public static void RescueDatabase()
		{
			Cursor.Current = Cursors.WaitCursor;
			
			Repository.WriteXml(DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_") + Properties.Settings.Default.RescueDatabaseFileName);
				
			Cursor.Current = Cursors.Default;
		}


		private static string GetBackupFolderPath()
		{
			string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			DirectoryInfo backubDirectory = new DirectoryInfo(Path.Combine(applicationDataPath, "GASPS"));
			if (!backubDirectory.Exists) backubDirectory.Create();
			return backubDirectory.FullName;
		}

		public static void BackupDatabase()
		{
			if (Repository.MainDataSet.HasChanges())
			{
				Cursor.Current = Cursors.WaitCursor;

				Repository.WriteXml(Path.Combine(GetBackupFolderPath(), DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_") + Properties.Settings.Default.RescueDatabaseFileName));

				Cursor.Current = Cursors.Default;
			}
		}

		public static void OpenBackupFilder()
		{
			Process.Start("explorer.exe", GetBackupFolderPath());
		}
	}
}
