using DatabaseToolSuite.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseToolSuite.Services
{
    static class Impors
    {

        public static void ImportTextFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding(1251));
            long length = reader.BaseStream.Length;
            string headers = reader.ReadLine();
            Dictionary<string, CodeGroup> dictionary = new Dictionary<string, CodeGroup>();

            

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] split = line.Split(';');
                
                if (dictionary.ContainsKey(split[1]))
                {
                    dictionary[split[1]].Add(split[0], 
                        string.IsNullOrWhiteSpace(split[2]) ? (DateTime?)null : DateTime.Parse(split[2]), 
                        string.IsNullOrWhiteSpace(split[3]) ? (DateTime?)null : DateTime.Parse(split[3]));
                }
                else
                {
                    CodeGroup group = new CodeGroup(split[1], split[0], string.IsNullOrWhiteSpace(split[2]) ? (DateTime?)null : DateTime.Parse(split[2]),
                        string.IsNullOrWhiteSpace(split[3]) ? (DateTime?)null : DateTime.Parse(split[3]));
                    dictionary.Add(group.Code, group);
                }
            }
            reader.Close();

            int created = 0;
            int edited = 0;
            int removed = 0;

            foreach (CodeGroup group in dictionary.Values)
            {
                bool exists = MasterDataSystem.DataSet.gasps.ExistsCode(group.Code);

                if (exists)
                {
                    long version = MasterDataSystem.DataSet.gasps.GetLastVersionOrganizationFromCode(group.Code).version;
                    if (group.Count == 1)
                    {
                        if (!group.Items[0].DateBegin.HasValue &&
                            group.Items[0].DateEnd.HasValue)
                        {
                            MasterDataSystem.RemoveOrganization(version, group.Items[0].DateEnd.Value);
                            removed += 1;
                        }
                        else
                        {
                            throw new Exception();
                        }                        
                    }
                    if (group.Count == 2)
                    {
                        CodeGroup.CodeGroupItem newItem = group.Items[0].DateBegin.HasValue ? group.Items[0] : group.Items[1];
                        MasterDataSystem.CreateNewVersionOrganization(version: version, date: newItem.DateBegin.Value, name: newItem.Name);
                        edited += 1;
                    }
                }
                else
                {
                    if (group.Count == 1)
                    {
                        CreateNewOrganizationDialog dialog = new CreateNewOrganizationDialog(group.Items[0].Name, group.Code, group.Items[0].DateBegin.Value);

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            MasterDataSystem.CreateNewOrganization(
                                name: dialog.OrganizationName,
                                okato: dialog.OkatoCode,
                                authorityId: dialog.Authority.HasValue ? dialog.Authority.Value : 0,
                                code: dialog.Code,
                                ownerKey: dialog.OrganizationOwner,
                                dateBegin: dialog.BeginDate,
                                dateEnd: Services.MasterDataSystem.MAX_DATE,
                                courtTypeId: dialog.CourtType);

                            created += 1;                            
                        }                       
                    }
                }                
            }

            MessageBox.Show("Импорт данных из текстового файла завершен." + Environment.NewLine +
                string.Format("Создано записей: {0}", created) + Environment.NewLine +
                string.Format("Изменен записей: {0}", edited) + Environment.NewLine +
                string.Format("Удалено записей: {0}", removed), 
                "Импорт данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
               

        private class CodeGroup
        {

            List<CodeGroupItem> items;

            public CodeGroup(string code, string name, DateTime? dateBegin, DateTime? dateEnd)
            {
                items = new List<CodeGroupItem>();
                Code = code;
                CodeGroupItem newItem = new CodeGroupItem(name, dateBegin, dateEnd);
                items.Add(newItem);
            }


            public void Add(string name, DateTime? dateBegin, DateTime? dateEnd)
            {
                CodeGroupItem newItem = new CodeGroupItem(name, dateBegin, dateEnd);
                items.Add(newItem);
            }
            
            public CodeGroupItem[] Items
            {
                get { return items.ToArray(); }
            }

            public int Count { get { return items.Count; } }

            public string Code { get; }
            
            public class CodeGroupItem
            {
                public CodeGroupItem(string name, DateTime? dateBegin, DateTime? dateEnd)
                {
                    Name = name;
                    DateBegin = dateBegin;
                    DateEnd = dateEnd;
                }

                public string Name { get; }
                
                public DateTime? DateBegin { get; }

                public DateTime? DateEnd { get; }
            }
        }
    }
}
