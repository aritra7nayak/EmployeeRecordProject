using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace EmployeeRecordProject.Models
{
    public class EmployeeEducation
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public int PassingYear { get; set; }

        [Required]
        public decimal DegreePercentage { get; set; }

        public virtual Employee Employee { get; set; }
    }
}