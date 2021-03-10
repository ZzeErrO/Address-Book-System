using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddContacts
    {
        private List<TakeContacts> list = new List<TakeContacts>();
        
        public void Assign(string first_Name, string last_Name, string address, string city, string state, int zip, int phone_number, string email)
        {
            TakeContacts class_object = new TakeContacts();
            class_object.FirstName = first_Name;
            class_object.LastName = last_Name;
            class_object.Address = address;
            class_object.City = city;
            class_object.State = state;
            class_object.Zip = zip;
            class_object.Phone_number = phone_number;
            class_object.Email = email;

            list.Add(class_object);
        }

        public void Show()
        {
            int num = 0;
            foreach (TakeContacts item in list)
            {
                num++;
                Console.WriteLine("\nPERSON " + num + " INFORMATION");

                Console.WriteLine("The first Name of person is: " + item.FirstName);
                Console.WriteLine("The last name of the person is: " + item.LastName);
                Console.WriteLine("The Address of the person is: " + item.Address);
                Console.WriteLine("The city of the person is: " + item.City);
                Console.WriteLine("The State of the person is: " + item.State);
                Console.WriteLine("The zip od the person is: " + item.Zip);
                Console.WriteLine("The phone number of the person is: " + item.Phone_number);
                Console.WriteLine("The email of the person is: " + item.Email + "\n");
            }
        }
    }
}
