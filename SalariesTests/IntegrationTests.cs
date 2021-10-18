namespace SalariesTests
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    class IntegrationTests
    {
        /// <summary>
        /// Integration test for AdminController.PayAccounts
        /// Log in as currently stored user admin1, create a new user, pay all
        /// accounts, and assert that the new users balance has been payed.
        /// </summary>
        [Test]
        public void Login_Then_CreateUser_Then_PayAccounts_Test()
        {
            var admin = new Admin("admin", "abc123", Role.Manager, 123);

            Database.Users.Add(admin);
            var userController = new UserController();

            // Log in as admin.
            Assert.AreEqual(admin, userController.Login(admin.Name, admin.Password));

            var adminController = new AdminController(admin);

            // Create a new user.
            var newUserName = "admin2";
            adminController.CreateUser(newUserName, "admin2345", Role.Developer, 2222, true);

            var newAdmin = Database.Users.Find((u) => u.Name == newUserName) as Admin;

            var expectedNewUserBalance = newAdmin.Balance + newAdmin.Salary;

            // Pay all accounts.
            adminController.PayAccounts();

            // Assert that new users balance is increased as expected after accounts payed. 
            var actualNewUserBalance = newAdmin.Balance;

            Assert.AreEqual(expectedNewUserBalance, actualNewUserBalance);
        }
    }
}
