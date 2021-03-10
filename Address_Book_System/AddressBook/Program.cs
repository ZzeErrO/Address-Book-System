using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" WELCOME TO ADDRESS BOOK SYSTEM PROGRAM \n");

            Console.WriteLine("Write First Name of the person: ");
            string first_Name = Console.ReadLine();
            Console.WriteLine(" \n Write Last Name of the person: ");
            string last_Name = Console.ReadLine();
            Console.WriteLine("\n Write Address of the person: ");
            string address = Console.ReadLine();
            Console.WriteLine("\n Write City of the person: ");
            string city = Console.ReadLine();
            Console.WriteLine("\n Write State of the person: ");
            string state = Console.ReadLine();
            Console.WriteLine("\n Write Zip of the person: ");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Write Phone_number of the person: ");
            int phone_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Write Email of the person: ");
            string email = Console.ReadLine();

            AddContacts obj = new AddContacts();
            obj.Assign(first_Name, last_Name, address, city, state, zip, phone_number, email);
            obj.Show();

            Console.ReadKey();
        }
    }
}
