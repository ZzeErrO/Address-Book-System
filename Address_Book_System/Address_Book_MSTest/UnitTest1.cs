using System;
using Address_Book;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Address_Book_MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
            //UC17
        public void GivenInformation_UpdateDatabaseInformation_ReturnSuccess()
        {
            TakeContacts data = new TakeContacts()
            {
                Empid = 2,
                FirstName = "Prashik",
                LastName = "Jaware",
                Address = "Prashik Niwas",
                City = "Nandura",
                State = "Maharashtra",
                Zip = 443434,
                Phone_number = 9876543210,
                Email = "prashikjaware@gmail.com"
            };
            AddressBookName data1 = new AddressBookName() 
            {
                Addid = 2,
                Address_Book_Name = "address",
                Empid = 2
            };

            bool result = ADO_NET.UpdateContactInformation(data, data1);
            Assert.AreEqual(true, result);
        }
    }
}
