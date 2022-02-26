using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OnlineBankingCore5._0.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Salary { get; set; }
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public int QualificationId { get; set; }
        public int CityId { get; set; }
        public int DepartmentId { get; set; }
        public string AspNetUserId { get; set; }
        [NotMapped]
        public string Email { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public virtual ApplicationUser AspNetUser { get; set; }
        public virtual City City { get; set; }
        public virtual Department Department { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}
