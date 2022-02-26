using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBankingCore5._0.Models
{
    public class ApplicationUser:IdentityUser
    {
        
      

            [NotMapped]
            public string Password { get; set; }
        public ApplicationUser()
        {

            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }




        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
