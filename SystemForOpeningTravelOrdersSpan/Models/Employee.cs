using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SystemForOpeningTravelOrdersSpan.Models
{
    public class Employee
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Surname")]
        public string surname { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "You need to input a valid e-mail address!")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to input a valid password!")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Student")]
        public bool student { get; set; }

        [Display(Name = "Worker")]
        public bool worker { get; set; }
    }
}