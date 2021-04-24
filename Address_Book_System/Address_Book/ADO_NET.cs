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
            SqlConnection SalaryConnection = ConnectionSetup();
            try
            {
                using (SalaryConnection)
                {
                    string query = @"select * from employee_names";
                    SqlCommand command = new SqlCommand(query, SalaryConnection);
                    SalaryConnection.Open();
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

                    SalaryConnection.Close();
                    string query1 = @"select * from addressBooks";
                    SqlCommand command1 = new SqlCommand(query1, SalaryConnection);
                    SalaryConnection.Open();
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
                SalaryConnection.Close();
            }
        }

    }
}