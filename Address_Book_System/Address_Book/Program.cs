using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class Program
    {
        public static string first_Name;
        public static string last_Name;
        public static string address;
        public static string city;
        public static string state;
        public static int zip;
        public static int phone_number;
        public static string email;
        public static string edit_First_Name;
        public static string edit_Last_Name;
        public static string delete_First_Name;
        public static string delete_Last_Name;
        //public static string city_Check;
        //public static string state_Check;

        static void Main(string[] args)
        {
            //UC1 To UC15
            //AddValuesInConsoleOrPlayWithFiles();

            //UC16 To UC20
            ADONET();

            Console.ReadKey();
        }

        public static void ADONET()
        {
            //  UC16
            ADO_NET.getAllData();
            // UC17
            ADO_NET.dataInAParticularPeriod();
        }

        public static void AddValuesInConsoleOrPlayWithFiles()
        {
            AddContacts obj = new AddContacts();
            Console.WriteLine(" WELCOME TO ADDRESS BOOK SYSTEM PROGRAM \n");

            Console.WriteLine("How many Address Book do you want(Expected Integer): ");
            int NUM_OF_ADDRESS_BOOK = Convert.ToInt32(Console.ReadLine());

            for (int j = 1; j <= NUM_OF_ADDRESS_BOOK; j++)
            {
                Console.WriteLine("Type the name of the Address Book: ");
                string address_Book = Console.ReadLine();

                Console.WriteLine(" How many people's Information is needed to be Added(Expected Integer): ");
                int NUM_OF_PEOPLE = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= NUM_OF_PEOPLE; i++)
                {
                    Console.WriteLine("\n Write First Name of the person: ");
                    first_Name = Console.ReadLine();
                    Console.WriteLine("\n Write Last Name of the person: ");
                    last_Name = Console.ReadLine();
                    Console.WriteLine("\n Write Address of the person: ");
                    address = Console.ReadLine();
                    Console.WriteLine("\n Write City of the person: ");
                    city = Console.ReadLine();
                    Console.WriteLine("\n Write State of the person: ");
                    state = Console.ReadLine();
                    Console.WriteLine("\n Write Zip of the person: ");
                    zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n Write Phone_number of the person: ");
                    phone_number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n Write Email of the person: ");
                    email = Console.ReadLine();

                    obj.Assign(address_Book, first_Name, last_Name, address, city, state, zip, phone_number, email);
                }
                obj.Check_Duplicate(address_Book);

                string Name = first_Name + " " + last_Name;
                obj.Sort_By_Name(Name);

                obj.Show(address_Book);

                Console.WriteLine("\n Do you want to edit any person Information then reply with 'y' or 'n': ");
                string y_n = Console.ReadLine();
                if (y_n == "y")
                {
                    Console.WriteLine("Enter the first name of the person you want to edit information: ");
                    edit_First_Name = Console.ReadLine();
                    Console.WriteLine("Enter the first name of the person you want to edit information: ");
                    edit_Last_Name = Console.ReadLine();
                    obj.Edit(edit_First_Name, edit_Last_Name);
                    obj.Show(address_Book);
                }

                Console.WriteLine("\n Do you want to delete any person Information then reply with 'y' or 'n': ");
                string y_n_1 = Console.ReadLine();
                if (y_n_1 == "y")
                {
                    Console.WriteLine("Enter the first name of the person you want to delete information: ");
                    delete_First_Name = Console.ReadLine();
                    Console.WriteLine("Enter the first name of the person you want to delete information: ");
                    delete_Last_Name = Console.ReadLine();
                    obj.delete(delete_First_Name, delete_Last_Name);
                    obj.Show(address_Book);
                }

            }

            Console.WriteLine("\n Do you want to Sort by City(press c), State(press s) or Zip(press z), if not then press any other button: ");
            string c_s_z = Console.ReadLine();
            obj.Sort(c_s_z);

            Console.WriteLine("\n------PRINT THE NUMBER OF PERSONS BY CITY OR STATE------\n");

            obj.count_By_City_Or_State();

            Console.WriteLine("\n\n ADDRESS BOOKS INFORMATION \n\n");

            //AddContacts.printAll_WriteText_InFile();
            ReadText();

            obj.CSV();
            Console.WriteLine("Do you want to read the CSV File to display on Console (Type 'y' or 'n' for yes or no respectively): ");
            string y_n_csv = Console.ReadLine();

            if (y_n_csv == "y")
            {
                obj.CSVRead();
            }

            obj.JSON();
            Console.WriteLine("Do you want to read the JSON Content of CSV File to display on Console (Type 'y' or 'n' for yes or no respectively): ");
            string y_n_json = Console.ReadLine();

            if (y_n_csv == "y")
            {
                obj.CSVReadJSON();
            }
        }

        public static void ReadText()
        {
            String path = @"C:\Users\Prashik Jaware\source\repos\Address_Book\Address-Book-System\Address_Book_System\Address_Book\AddressBook.txt";

            using (StreamReader sr = File.OpenText(path))
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