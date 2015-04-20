using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SystemForOpeningTravelOrdersSpan.Models
{
    public class TravelOrder
    {
        public int id { get; set; }

        [Display(Name = "Subject")]
        public string subject { get; set; }

        [Required(ErrorMessage = "You need to input a valid e-mail address!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "From")]
        public string from { get; set; }

        [Required(ErrorMessage = "You need to input a valid e-mail address!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "To")]
        public string to { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Surname")]
        public string surname { get; set; }

        [Display(Name = "Date of start travel")]
        [Required(ErrorMessage = "You need to input a valid date!")]
        [DataType(DataType.Date)]
        public string dateOfStartTravel { get; set; }
        
        [Display(Name = "Date of end travel")]
        [Required(ErrorMessage = "You need to input a valid date!")]
        [DataType(DataType.Date)]
        public string dateOfEndTravel { get; set; }

        [Display(Name = "Travel vehicle")]
        public string travelVehicle { get; set; }

        [Display(Name = "Reason for travel")]
        public string reasonForTravel { get; set; }

        [Display(Name = "Relation of travel")]
        public string relationOfTravel { get; set; }

        [Display(Name = "Project number")]
        public int projectNumber { get; set; }

        [Display(Name = "Accommodation")]
        public bool accommodation { get; set; }

        [Required(ErrorMessage = "You need to input a valid date!")]
        [Display(Name = "Accomodation date")]
        [DataType(DataType.Date)]
        public string accomodationDate { get; set; }
      
        [Required(ErrorMessage = "You need to input a valid date!")]
        [Display(Name = "Date of arrival")]
        [DataType(DataType.Date)]
        public string accomodationArrivalDate { get; set; }

        [Required(ErrorMessage = "You need to input a valid date!")]
        [Display(Name = "Date of departure")]
        [DataType(DataType.Date)]
        public string accomodationDepartureDate { get; set; }

        [Display(Name = "Comment")]
        public string comment { get; set; }
    }
}