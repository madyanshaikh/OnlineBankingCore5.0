using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBankingCore5._0.Models
{
    public partial class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int? CityId { get; set; }
    }
}
