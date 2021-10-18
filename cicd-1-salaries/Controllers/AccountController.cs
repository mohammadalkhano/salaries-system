using System;
using System.Collections.Generic;
using System.Linq;
using cicd_1_salaries.Models;
using cicd_1_salaries.Models.Data;

namespace cicd_1_salaries.Controllers
{
    public class AccountController
    {
        public AccountController(Account account)
        {
            Account = account;
        }

        public Account Account { get; private set; }

        /// <summary>
        /// Checks if the User exist
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsValidLogin(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                Account = Database.Users.FirstOrDefault(user => user.Name == userName && user.Password == password) as Account;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logs in.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>In logged user</returns>
        public User Login(string userName, string password)
        {
            if (!IsValidLogin(userName, password)) return null;

            return Account;
        }

        public void CreateRequest(Request request)
        {
            Database.Requests.Add(request);
        }

        /// <summary>
        /// Remove logged in account from the database.
        /// </summary>
        /// <returns>true if account is removed, otherwise false</returns>
        public bool RemoveAccount()
        {
            return Database.Users.Remove(Account);
        }

    }
}

