namespace SalariesTests
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    class AccountControllerTests
    {
        private List<User> users;
        private Admin admin;
        private Account account;
        private AccountController accountController;

        [SetUp]
        public void SetUp()
        {
            admin = new Admin("admin1", "Admin@123", Role.Developer, 1);
            account = new Account("Mohammad", "Passw0rd@123", Role.Developer, 1);

            accountController = new AccountController(account);

            users = new List<User>()
            {
                admin,
                account,
            };

            Database.Users.AddRange(users);
        }

        [Test]
        public void LoginAsAdmin_Test()
        {
            var name = "admin1";
            var password = "Admin@123";

            var actual = accountController.Login(name, password);

            Assert.AreEqual(actual.Name, name);
            Assert.AreEqual(actual.Password, password);
        }

        [Test]
        public void LoginAsNotExistUser_Test()
        {
            var name = "NotExist";
            var password = "123123";

            var actual = accountController.Login(name, password);
            Assert.IsNull(actual);
        }

        [Test]
        public void RemoveAccount_Test()
        {
            //accountController.Login("Mohammad", "Passw0rd@123");
            accountController.Login("admin1", "Admin@123");
            var actual = accountController.RemoveAccount();
            Assert.IsTrue(actual);
        }
    }
}
