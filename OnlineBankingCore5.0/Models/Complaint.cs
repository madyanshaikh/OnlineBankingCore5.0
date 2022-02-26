using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBankingCore5._0.Models
{
    public partial class Complaint
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
