using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace EmployeeRecordProject.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set;}

        public GenderTypeEnum Gender { get; set; }


        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNo { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string EmailId { get; set; }

        [Display(Name ="Photo")]
        [UIHint("FileLink")]
        public string UploadedPhoto { get; set; }

    }

    public enum GenderTypeEnum
    {
        Male= 1,
        Female =2,
        Others = 3
    }
}