using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;

namespace AddressBook
{
    class AddressBookWriteJSON
    {
        public static void ImplementJSON(List<TakeContacts> list)
        {
            //string importFilePath = "C:\\Users\\Prashik Jaware\\source\\repos\\Address_Book\\Address_Book_System\\AddressBook\\Utility\\AddressBook.csv";
            string exportFilePath = "C:\\Users\\Prashik Jaware\\source\\repos\\Address_Book\\Address_Book_System\\AddressBook\\Utility\\AddressBookJSON.json";

            string jsonData = JsonConvert.SerializeObject(list);

            File.WriteAllText(exportFilePath, JsonConvert.SerializeObject(list));

        }

        public static void ImplementJSONAndRead()
        {
            string FilePath = "C:\\Users\\Prashik Jaware\\source\\repos\\Address_Book\\Address_Book_System\\AddressBook\\Utility\\AddressBookJSON.json";

            using (StreamReader sr = File.OpenText(FilePath))
            {
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                sr.Close();
            }
            
        }
    }
}
