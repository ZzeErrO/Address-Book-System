using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class ADO_NET
    {
        AddContacts totalinfo;
        public ADO_NET()
        {
            totalinfo = new AddContacts();
        }
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public static void getAllData()
        {
            SqlConnection Connection = ConnectionSetup();
            try
            {
                using (Connection)
                {
                    string query = @"select * from employee_names";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    TakeContacts take = new TakeContacts();
                    Console.WriteLine("----------TABLE FOR EMPLOYEE----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //model.EmployeeId = dr.GetInt32(0);
                            take.FirstName = dr.GetString(1);
                            take.LastName = dr.GetString(2);
                            take.Address = dr.GetString(3);
                            take.City = dr.GetString(4);
                            take.State = dr.GetString(5);
                            take.Zip = dr.GetInt32(6);
                            take.Phone_number = dr.GetInt64(7);
                            take.Email = dr.GetString(8);
                            Console.WriteLine(" " +
                                take.FirstName + " "
                                + take.LastName + " "
                                + take.Address + " "
                                + take.City + " "
                                + take.State + " "
                                + take.Zip + " "
                                + take.Phone_number + " "
                                + take.Email);

                        }
                    }

                    Connection.Close();
                    string query1 = @"select * from addressBooks";
                    SqlCommand command1 = new SqlCommand(query1, Connection);
                    Connection.Open();
                    SqlDataReader dr1 = command1.ExecuteReader();
                    AddressBookName name = new AddressBookName();
                    Console.WriteLine("----------TABLE FOR ADDRESS_BOOK----------");
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            name.Addid = dr1.GetInt32(0);
                            name.Address_Book_Name = dr1.GetString(1);
                            name.Empid = dr1.GetInt32(2);
                            //display.EmployeeId = dr1.GetInt32(3);

                            Console.WriteLine(" " +
                                name.Addid + " "
                                + name.Address_Book_Name + " "
                                + name.Empid);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public static bool UpdateContactInformation(TakeContacts contact, AddressBookName book)
        {
            SqlConnection Connection = ConnectionSetup();
            try
            {
                using (Connection)
                {
                    TakeContacts take = new TakeContacts();
                    AddressBookName name = new AddressBookName();
                    SqlCommand command = new SqlCommand("UpdateContactInformation", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", contact.Empid);
                    command.Parameters.AddWithValue("@firstname", contact.FirstName);
                    command.Parameters.AddWithValue("@lastname", contact.LastName);
                    command.Parameters.AddWithValue("@address", contact.Address);
                    command.Parameters.AddWithValue("@city", contact.City);
                    command.Parameters.AddWithValue("@state", contact.State);
                    command.Parameters.AddWithValue("@zip", contact.Zip);
                    command.Parameters.AddWithValue("@phonenumber", contact.Phone_number);
                    command.Parameters.AddWithValue("@email", contact.Email);
                    command.Parameters.AddWithValue("@addressbookname", book.Address_Book_Name);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            take.Empid = Convert.ToInt32(dr["Empid"]);
                            take.FirstName = dr["firstname"].ToString();
                            take.LastName = dr["lastname"].ToString();
                            take.Address = dr["address"].ToString();
                            take.City = dr["city"].ToString();
                            take.State = dr["state"].ToString();
                            take.Zip = Convert.ToInt32(dr["zip"]);
                            take.Phone_number = Convert.ToInt32(dr["phone_number"]);
                            take.Email = dr["email"].ToString();
                            name.Address_Book_Name = dr["addressBookName"].ToString();

                            if 
                            (
                            take.FirstName == contact.FirstName &&
                            take.LastName == contact.LastName &&
                            take.Address == contact.Address &&
                            take.City == contact.City &&
                            take.State == contact.State &&
                            take.Zip == contact.Zip &&
                            take.Phone_number == contact.Phone_number &&
                            take.Email == contact.Email &&
                            name.Address_Book_Name == book.Address_Book_Name
                            )
                            {
                                return true;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }

        public static void dataInAParticularPeriod()
        {
            SqlConnection Connection = ConnectionSetup();
            try
            {
                using (Connection)
                {
                    string query = @"select * from employee_names where joinDate between '2020-01-01' and '2021-05-01'";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    TakeContacts take = new TakeContacts();
                    Console.WriteLine("----------TABLE FOR QUERY----------");
                    Console.WriteLine("select * from employee_names where joinDate between '2020-01-01' and '2021-05-01'");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //model.EmployeeId = dr.GetInt32(0);
                            take.FirstName = dr.GetString(1);
                            take.LastName = dr.GetString(2);
                            take.Address = dr.GetString(3);
                            take.City = dr.GetString(4);
                            take.State = dr.GetString(5);
                            take.Zip = dr.GetInt32(6);
                            take.Phone_number = dr.GetInt64(7);
                            take.Email = dr.GetString(8);
                            Console.WriteLine(" " +
                                take.FirstName + " "
                                + take.LastName + " "
                                + take.Address + " "
                                + take.City + " "
                                + take.State + " "
                                + take.Zip + " "
                                + take.Phone_number + " "
                                + take.Email);

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public static void contactInDatabaseByCityOrState()
        {
            SqlConnection Connection = ConnectionSetup();
            try
            {
                using (Connection)
                {
                    string query = @"select * from employee_names where city = 'Earth'";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    TakeContacts take = new TakeContacts();
                    Console.WriteLine("----------INFORMATION FOR BELOW QUERY----------");
                    Console.WriteLine("select * from employee_names where city = 'Earth'");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //model.EmployeeId = dr.GetInt32(0);
                            take.FirstName = dr.GetString(1);
                            take.LastName = dr.GetString(2);
                            take.Address = dr.GetString(3);
                            take.City = dr.GetString(4);
                            take.State = dr.GetString(5);
                            take.Zip = dr.GetInt32(6);
                            take.Phone_number = dr.GetInt64(7);
                            take.Email = dr.GetString(8);
                            Console.WriteLine(" " +
                                take.FirstName + " "
                                + take.LastName + " "
                                + take.Address + " "
                                + take.City + " "
                                + take.State + " "
                                + take.Zip + " "
                                + take.Phone_number + " "
                                + take.Email);

                        }
                    }

                    Connection.Close();

                    string query1 = @"select * from employee_names where state = 'Maharashtra'";
                    SqlCommand command1 = new SqlCommand(query1, Connection);
                    Connection.Open();
                    SqlDataReader dr1 = command1.ExecuteReader();

                    Console.WriteLine("----------INFORMATION FOR BELOW QUERY----------");
                    Console.WriteLine("select * from employee_names where state = 'Maharashtra'");
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            //model.EmployeeId = dr.GetInt32(0);
                            take.FirstName = dr1.GetString(1);
                            take.LastName = dr1.GetString(2);
                            take.Address = dr1.GetString(3);
                            take.City = dr1.GetString(4);
                            take.State = dr1.GetString(5);
                            take.Zip = dr1.GetInt32(6);
                            take.Phone_number = dr1.GetInt64(7);
                            take.Email = dr1.GetString(8);
                            Console.WriteLine(" " +
                                take.FirstName + " "
                                + take.LastName + " "
                                + take.Address + " "
                                + take.City + " "
                                + take.State + " "
                                + take.Zip + " "
                                + take.Phone_number + " "
                                + take.Email);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}