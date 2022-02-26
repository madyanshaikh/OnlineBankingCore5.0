using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBankingCore5._0.Models
{
    public partial class Qualification
    {
        public Qualification()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

       
    }
}
