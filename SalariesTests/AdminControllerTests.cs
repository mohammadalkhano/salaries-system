namespace SalariesTests
{
    using System;
    using System.Collections.Generic;
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using NUnit.Framework;

    [TestFixture]
    public class AdminControllerTests
    {
        private List<User> users;
        private List<Request> requests;
        private Admin admin;
        private Account account;
        private AdminController adminController;
        private RoleRequest roleRequest;
        private SalaryRequest salaryRequest;

        [SetUp]
        public void SetUp()
        {
            account = new Account("User", "User@123", Role.Developer, 2100);
            admin = new Admin("admin11", "Admin@123", Role.Developer, 1);

            adminController = new AdminController(admin);

            roleRequest = new RoleRequest(account, Role.Developer);
            salaryRequest = new SalaryRequest(account, 222);

            users = new List<User>()
            {
                admin,
                account
            };
            requests = new List<Request>() 
            {
                roleRequest,
                salaryRequest
            };

            Database.Users.AddRange(users);
            Database.Requests.AddRange(requests);
        }

        [Test]
        public void CreateUser_Test()
        {
            var actual = adminController.CreateUser("Bill", "User@123", Role.Developer, 2100, true);
            Assert.IsTrue(actual);
        }

        [Test]
        public void CreateAlreadyExistsUser_Test()
        {
            //User added to Database.Users by SetUp method.
            var actual = adminController.CreateUser("User", "User@123", Role.Developer, 2100, true);
            Assert.IsFalse(actual);
        }

        [Test]
        public void CreateEmptyUser_Test()
        {
            var actual = adminController.CreateUser("", "", Role.Developer, 1, true);
            Assert.IsFalse(actual);
        }

        [Test]
        public void GetAccountRequests_Test()
        {
            var actual = adminController.GetAccountRequests(account.Name);
            Assert.IsTrue(actual.Contains(roleRequest));
            Assert.IsTrue(actual.Contains(salaryRequest));
        }

        [Test]
        public void RemoveUser_Test()
        {
            var name = "Mohammad";
            var password = "Passw0rd@123";
            var actual = adminController.RemoveUser(name, password);
            Assert.IsTrue(actual);

        }

        [Test]
        public void RemoveNotExistUser_Test()
        {
            var name = "Abcdef";
            var password = "Passw0rd@123";
            var actual = adminController.RemoveUser(name, password);
            Assert.IsFalse(actual);
        }
    }
}