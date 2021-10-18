namespace cicd_1_salaries.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Database
    {
        private static List<User> users;
        private static List<Request> requests;

        public static List<User> Users
        {
            get
            {
                if (users is null) SeedData();
                return users;
            }
        }

        public static List<Request> Requests
        {
            get
            {
                if (requests is null) SeedData();
                return requests;
            }
        }

        private static void SeedData()
        {
            users = new List<User>();
            requests = new List<Request>();

            #region Users
            var admin1 = new Admin("admin1", "admin1234", Role.Manager, 1234);

            users.Add(admin1);

            var account1 = new Account("account1", "account1234", Role.Developer, 1234);

            users.Add(account1);
            #endregion

            #region Requests
            requests.Add(new SalaryRequest(admin1, 2345));

            requests.Add(new SalaryRequest(account1, 3456));
            requests.Add(new RoleRequest(account1, Role.Manager));
            #endregion

        }
    }
}
