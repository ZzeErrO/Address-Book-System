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
        public static void ImplementCSVToJSON()
        {
            string importFilePath = "C:\\Users\\Prashik Jaware\\source\\repos\\Address_Book\\Address_Book_System\\AddressBook\\Utility\\AddressBook.csv";
            string exportFilePath = "C:\\Users\\Prashik Jaware\\source\\repos\\Address_Book\\Address_Book_System\\AddressBook\\Utility\\AddressBookJSON.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<TakeContacts>().ToList();

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }

        }

        public static void ImplementCSVToJSONAndRead()
        {
            string FilePath = "C:\\Users\\Prashik Jaware\\source\\repos\\Address_Book\\Address_Book_System\\AddressBook\\Utility\\AddressBookJSON.csv";

            using (StreamReader sr = File.OpenText(FilePath))
            {
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            
        }
    }
}
