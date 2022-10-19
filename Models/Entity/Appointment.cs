using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TECHNICAL_ASSESSMENT.Models.Entity
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }

        [Required(ErrorMessage ="Pic the date and time")]
        public DateTime Date { get; set; }
    }

}