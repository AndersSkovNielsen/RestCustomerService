using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCustomerService.Controllers;
using ModelLibrary;
using ModelLibrary.Model;

namespace RestCustomerServiceTest
{
    [TestClass]
    public class ControllerTest
    {
        private CustomersController controller = new CustomersController();

        [TestMethod]
        public void TestGetAllCount()
        {
            Assert.AreEqual(3, controller.GetAllCustomers().Count);
        }

        [TestMethod]
        public void TestGet()
        {
            Customer c = new Customer(1, "Ace", "Williams", 1991);

            Assert.AreEqual(c, controller.GetCustomer(1));
        }

        [TestMethod]
        public void TestPost()
        {
            Customer c = new Customer(4, "Test", "Tester", 2345);
            controller.InsertCustomer(c);
            
            Assert.AreEqual(c, controller.GetCustomer(4));
        }

        [TestMethod]
        public void TestUpdate()
        {
            Customer c = new Customer(1, "Ace", "Williams", 2018);
            controller.UpdateCustomer(1, c);

            Assert.AreEqual(c.Year, controller.GetCustomer(1).Year);
        }

        [TestMethod]
        public void TestDelete()
        {
            controller.DeleteCustomer(3);

            Assert.AreEqual(3, controller.GetAllCustomers().Count);
        }
    }
}
