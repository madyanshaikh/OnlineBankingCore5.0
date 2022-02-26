using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBankingCore5._0.Models
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
