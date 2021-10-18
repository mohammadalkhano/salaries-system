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
    public class UserControllerTests
    {
        [Test]
        public void Login_Test_Account()
        {
            var account111 = new Account("account111", "a111", Role.Developer, 1);
            Database.Users.Add(account111);

            var userController = new UserController();

            var expected = account111;
            var actual = userController.Login(account111.Name, account111.Password);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Login_Test_Admin()
        {
            var admin111 = new Admin("admin111", "a111", Role.Developer, 1);
            Database.Users.Add(admin111);

            var userController = new UserController();

            var expected = admin111;
            var actual = userController.Login(admin111.Name, admin111.Password);

            Assert.AreEqual(expected, actual);
        }
    }
}
