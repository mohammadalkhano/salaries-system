namespace cicd_1_salaries.Controllers
{
    using System;
    using System.Collections.Generic;
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;

    public class AdminController
    {
        public AdminController(Admin admin)
        {
            Admin = admin;
        }

        public Admin Admin { get; }

        public List<User> GetAllUsers()
        {
            return Database.Users;
        }

        public List<Request> GetAccountRequests(string name)
        {
            List<Request> requests = new();

            foreach (var request in Database.Requests)
            {
                if (request.Account.Name == name) requests.Add(request);
            }

            return requests;
        }

        public void PayAccounts()
        {
            foreach (var user in Database.Users)
            {
                if (user is Account)
                {
                    var account = user as Account;
                    account.Balance += account.Salary;
                }
            }
        }

        public bool CreateUser(string name, string password, Role role, int salary, bool isAdmin)
        {
            // if name and password is not empty.
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(password))
            {
                // Don't create if user already exists.
                if (Database.Users.Find((u) => u.Name == name) is not null) return false;
                                
                if (isAdmin)
                {
                    Database.Users.Add(new Admin(name, password, role, salary));
                }
                else
                {
                    Database.Users.Add(new Account(name, password, role, salary));
                }

                // User was created.
                return true;
            }

            return false;
        }

        public bool RemoveUser(string name, string password)
        {
            var user = Database.Users.Find((u) => u.Name == name && u.Password == password);

            if (user is null) return false;

            Database.Users.Remove(user);

            return true;
        }
    }
}
