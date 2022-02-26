using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OnlineBankingCore5._0.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Complaints = new HashSet<Complaint>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }
        public string Nic { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public string AlternateAddress { get; set; }
        public string AspNetUserId { get; set; }
        public int AccountId { get; set; }
        public int CityId { get; set; }
        [NotMapped]
        public string Emails { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public virtual Account Account { get; set; }
        public virtual ApplicationUser AspNetUser { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
