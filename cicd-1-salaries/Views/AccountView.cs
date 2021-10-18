namespace cicd_1_salaries.Views
{
    using cicd_1_salaries.Controllers;
    using cicd_1_salaries.Models;
    using System;

    internal class AccountView
    {
        public AccountView(AccountController accountController)
        {
            AccountController = accountController;

            Console.WriteLine($"Signed in as account {AccountController.Account.Name}\n");
            Console.WriteLine($"{AccountController.Account}\n");

            NavMenu();
        }

        private AccountController AccountController { get; }

        private enum Nav
        {
            RequestNewRole,
            RequestNewSalary,
            RemoveAccount,
            Exit,
        }

        private void NavMenu()
        {
            var exit = false;

            while (exit is false)
            {
                var nav = PromptNavigation();

                switch (nav)
                {
                    case Nav.RequestNewRole:
                        RequestNewRole();
                        break;
                    case Nav.RequestNewSalary:
                        RequestNewSalary();
                        break;
                    case Nav.RemoveAccount:
                        RemoveAccount();
                        exit = true;
                        break;
                    case Nav.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private void RemoveAccount()
        {
            AccountController.RemoveAccount();
        }

        private void RequestNewRole()
        {
            var role = PromptAccountRole();

            var request = new RoleRequest(AccountController.Account, role);

            AccountController.CreateRequest(request);
        }

        private void RequestNewSalary()
        {
            var salary = PromptNewSalary();

            var request = new SalaryRequest(AccountController.Account, salary);

            AccountController.CreateRequest(request);
        }

        private int PromptNewSalary()
        {
            try
            {
                Console.Write("New salary: ");
                var input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                return input;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return PromptNewSalary();
            }
        }

        private Role PromptAccountRole()
        {
            Console.WriteLine("Select role");
            foreach (var roleName in Enum.GetNames(typeof(Role)))
            {
                Console.WriteLine($" [{roleName}]");
            }
            Console.Write("> ");
            var input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                var role = Enum.Parse(typeof(Role), input, true);
                return (Role) role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
                return PromptAccountRole();
            }
        }

        private Nav PromptNavigation()
        {
            Console.WriteLine("Select");
            Console.WriteLine(" [1] Request new role");
            Console.WriteLine(" [2] Request new salary");
            Console.WriteLine(" [3] Remove account");
            Console.WriteLine(" [E] Exit");
            Console.Write("> ");
            var input = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return input switch
            {
                "1" => Nav.RequestNewRole,
                "2" => Nav.RequestNewSalary,
                "3" => Nav.RemoveAccount,
                "E" => Nav.Exit,
                _ => PromptNavigation(),
            };
        }
    }
}