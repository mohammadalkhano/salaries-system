namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class LoginView
    {
        private UserController userController;

        private enum Navigation
        {
            Login,
            Exit,
        }

        public LoginView()
        {
            userController = new();

            NavMenu();
        }

        private void NavMenu()
        {
            var exit = false;

            while (exit is false)
            {
                var nav = PromptNavigation();

                switch (nav)
                {
                    case Navigation.Login:
                        Login();
                        break;
                    case Navigation.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private void Login()
        {
            var (name, password) = PromptLoginDetails();
            var user = userController.Login(name, password);

            // Create new view based on user type.
            if (user is Admin)
            {
                var adminController = new AdminController(user as Admin);
                new AdminView(adminController);
            }
            else if (user is Account)
            {
                var accountController = new AccountController(user as Account);
                new AccountView(accountController);
            }
            else
            {
                Console.WriteLine("Invalid user details.\n");
            }
        }

        private Navigation PromptNavigation()
        {
            Console.WriteLine("Select");
            Console.WriteLine(" [1] Login");
            Console.WriteLine(" [E] Exit");
            Console.Write("> ");
            var input = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return input switch
            {
                "1" => Navigation.Login,
                "E" => Navigation.Exit,
                _ => PromptNavigation(),
            };
        }

        private (string name, string password) PromptLoginDetails()
        {
            Console.WriteLine("Sign in\n");
            Console.Write("User: ");
            var name = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            return (name, password);
        }
    }
}
