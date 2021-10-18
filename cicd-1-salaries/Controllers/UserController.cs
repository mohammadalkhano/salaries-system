namespace cicd_1_salaries.Controllers
{
    using cicd_1_salaries.Models;
    using cicd_1_salaries.Models.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserController
    {
        public User Login(string name, string password)
        {
            return Database.Users.FirstOrDefault((u) => u.Name == name && u.Password == password);
        }
    }
}
