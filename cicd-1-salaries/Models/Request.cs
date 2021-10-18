namespace cicd_1_salaries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Request
    {
        public Request(Account account, Object value)
        {
            Account = account;
            Value = value;
        }

        /// <summary>
        /// Requestee.
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Desired value in regard to what is requested.
        /// </summary>
        public Object Value { get; set; }
    }
}
