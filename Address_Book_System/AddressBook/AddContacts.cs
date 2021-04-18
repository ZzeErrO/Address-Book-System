using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

namespace AddressBook
{
    class AddContacts
    {
        int var = 0;
        public List<TakeContacts> list = new List<TakeContacts>();
        public static Dictionary<string, TakeContacts> dictionary = new Dictionary<string, TakeContacts>();
        public static Dictionary<string, List<string>> dict_City = new Dictionary<string, List<string>>();
        public static Dictionary<string, List<string>> dict_State = new Dictionary<string, List<string>>();

        public void Assign(string address_Book, string first_Name, string last_Name, string address, string city, string state, int zip, int phone_number, string email)
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
            dictionary.Add(address_Book + " Person" + var,class_object);
            var++;
        }

        public void Check_Duplicate(string address_Book)
        {
            for (int temp = 0; temp < list.Count; temp++)
            {
                for (int i = temp; i < list.Count-1; i++)
                {
                    int j = i;
                    j++;
                    if (list[temp].FirstName == list[j].FirstName && list[temp].LastName == list[j].LastName)
                    {
                        delete(list[j].FirstName, list[j].LastName);
                        dictionary.Remove(address_Book + " Person" + j);
                    }
                    //Console.WriteLine("hello "+i);
                }
            }
        }

        public void Show(string address_Book)
        {
            int num = 0;
            Console.WriteLine("\n   ADDRESS BOOK NAME " + address_Book);
            foreach (TakeContacts item in list)
            {
                num++;
                Console.WriteLine("\nPerson " + num + " Information");

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

        public void Edit(string edit_First_Name, string edit_Last_Name)
        {
            foreach (TakeContacts item1 in list)
            {
                if (item1.FirstName == edit_First_Name && item1.LastName == edit_Last_Name)
                {
                    Console.WriteLine("\n Write New Address of the person: ");
                    item1.Address = Console.ReadLine();
                    Console.WriteLine("\n Write New City of the person: ");
                    item1.City = Console.ReadLine();
                    Console.WriteLine("\n Write New State of the person: ");
                    item1.State = Console.ReadLine();
                    Console.WriteLine("\n Write New Zip of the person: ");
                    item1.Zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n Write New Phone number of the person: ");
                    item1.Phone_number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n Write New Email of the person: ");
                    item1.Email = Console.ReadLine();
                }
            }
        }

        public void delete(string delete_First_Name, string delete_Last_Name)
        {
            foreach  (TakeContacts item2 in list)
            {
                if (item2.FirstName == delete_First_Name && item2.LastName == delete_Last_Name)
                {
                    list.Remove(item2);
                    Console.WriteLine("Element Removed");
                    break;
                }
            }
        }

        public static void printAll_WriteText_InFile()
        {

            String path = "C:\\Users\\Prashik Jaware\\source\\repos\\Address_Book\\Address_Book_System\\AddressBook.txt";


            foreach (KeyValuePair<string, TakeContacts> item in dictionary)
            {

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Dictionary Name: " + item.Key + "\nInformation: \n");

                    sw.WriteLine("The first Name of person is: " + item.Value.FirstName);
                    sw.WriteLine("The last name of the person is: " + item.Value.LastName);
                    sw.WriteLine("The Address of the person is: " + item.Value.Address);
                    sw.WriteLine("The city of the person is: " + item.Value.City);
                    sw.WriteLine("The State of the person is: " + item.Value.State);
                    sw.WriteLine("The zip od the person is: " + item.Value.Zip);
                    sw.WriteLine("The phone number of the person is: " + item.Value.Phone_number);
                    sw.WriteLine("The email of the person is: " + item.Value.Email + "\n");


                    sw.Close();
                    //Console.WriteLine(File.ReadAllText(path));
                }
            }
        }

        public static void search_Person_In_City(string city_Check)
        {
            List<string> cityPeoples = new List<string>();
            //Console.WriteLine("Person Name Having " + state_Check + " as ther state is: ");
            foreach (KeyValuePair<string, TakeContacts> item in dictionary)
            {
                if (item.Value.City == city_Check)
                {
                    cityPeoples.Add(item.Value.FirstName + " " + item.Value.LastName);
                }
            }

            try
            {
                dict_City.Add(city_Check, cityPeoples);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //dict_State.Remove(state_Check);
            }
        }

        public static void search_Person_In_State(string state_Check)
        {
            List<string> statePeoples = new List<string>();
            //Console.WriteLine("Person Name Having " + state_Check + " as ther state is: ");
            foreach (KeyValuePair<string, TakeContacts> item in dictionary)
            {
                if (item.Value.State == state_Check)
                {
                    statePeoples.Add(item.Value.FirstName + " " + item.Value.LastName);
                }
            }

            try
            {
                dict_State.Add(state_Check, statePeoples);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //dict_State.Remove(state_Check);
            }
        }

        public void count_By_City_Or_State()
        {

            foreach (KeyValuePair<string, TakeContacts> item1 in dictionary)
            {
                search_Person_In_City(item1.Value.City);
            }
            foreach (KeyValuePair<string, List<string>> alpha in dict_City)
            {
                Console.WriteLine("City: " + alpha.Key + "\nPerson Names: ");
                foreach (var item in alpha.Value)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Number of people in city " + alpha.Key + " is:" + alpha.Value.Count);
            }

            foreach (KeyValuePair<string, TakeContacts> item1 in dictionary)
            {
            
                search_Person_In_State(item1.Value.State);

            }
            foreach (KeyValuePair<string, List<string>> beta in dict_State)
            {
                Console.WriteLine("State: " + beta.Key + "\nPerson Names: ");
                foreach (var item in beta.Value)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Number of people in State " + beta.Key + " is:" + beta.Value.Count);
            }
        }

        public void Sort_By_Name(string toSort)
        {
            SortedList<string, TakeContacts> sort = new SortedList<string, TakeContacts>();
            foreach (TakeContacts item in list)
            {
                sort.Add(item.FirstName + " "+ item.LastName, item);
            }
            int incr = 0;
            foreach (var item in sort)
            {
                list[incr] = item.Value ;
                incr++;
            }

        }

        public void Sort(string toSort)
        {
            SortedList<object, TakeContacts> sort = new SortedList<object, TakeContacts>();
            if (toSort == "c")
            {
                foreach (TakeContacts item in list)
                {
                    try 
                    {
                        sort.Add(item.City, item);

                    }
                    catch(Exception ex)
                    { Console.WriteLine(ex.Message); }
                }
                Console.WriteLine("------SORTING BY CITY------");
                foreach (var item in sort)
                {
                    Console.WriteLine("City is: "+item.Key + " ===>>\n");
                    Console.WriteLine("The first Name of person is: " + item.Value.FirstName);
                    Console.WriteLine("The last name of the person is: " + item.Value.LastName);
                    Console.WriteLine("The Address of the person is: " + item.Value.Address);
                    Console.WriteLine("The State of the person is: " + item.Value.State);
                    Console.WriteLine("The zip od the person is: " + item.Value.Zip);
                    Console.WriteLine("The phone number of the person is: " + item.Value.Phone_number);
                    Console.WriteLine("The email of the person is: " + item.Value.Email + "\n");
                }

            }
            else if (toSort == "s")
            {
                foreach (TakeContacts item in list)
                {
                    try
                    {
                        sort.Add(item.State, item);

                    }
                    catch (Exception ex)
                    { Console.WriteLine(ex.Message); }
                }
                Console.WriteLine("------SORTING BY STATE------");
                foreach (var item in sort)
                {
                    Console.WriteLine("State is: "+item.Key + " ===>>\n");
                    Console.WriteLine("The first Name of person is: " + item.Value.FirstName);
                    Console.WriteLine("The last name of the person is: " + item.Value.LastName);
                    Console.WriteLine("The Address of the person is: " + item.Value.Address);
                    Console.WriteLine("The zip od the person is: " + item.Value.Zip);
                    Console.WriteLine("The phone number of the person is: " + item.Value.Phone_number);
                    Console.WriteLine("The email of the person is: " + item.Value.Email + "\n");
                }
            }
            else if (toSort == "z")
            {
                foreach (TakeContacts item in list)
                {
                    try
                    {
                        sort.Add(item.Zip, item);

                    }
                    catch (Exception ex)
                    { Console.WriteLine(ex.Message); }
                }
                Console.WriteLine("------SORTING BY ZIP------");
                foreach (var item in sort)
                {
                    Console.WriteLine("Zip is: " + item.Key + " ===>>\n");
                    Console.WriteLine("The first Name of person is: " + item.Value.FirstName);
                    Console.WriteLine("The last name of the person is: " + item.Value.LastName);
                    Console.WriteLine("The Address of the person is: " + item.Value.Address);
                    Console.WriteLine("The zip od the person is: " + item.Value.Zip);
                    Console.WriteLine("The phone number of the person is: " + item.Value.Phone_number);
                    Console.WriteLine("The email of the person is: " + item.Value.Email + "\n");
                }

            }

        }


        public void CSV()
        {
            AddressBookCsv.Implement_CSV(list);
        }

        public void CSVRead()
        {
            AddressBookCsv.Implement_CSV_Read();
        }

        public void JSON()
        {
            AddressBookWriteJSON.ImplementJSON(list);
        }

        public void CSVReadJSON()
        {
            AddressBookWriteJSON.ImplementJSONAndRead();
        }
    }
}
