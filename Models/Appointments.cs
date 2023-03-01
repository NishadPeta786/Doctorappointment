using Doctorappointment.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctorappointment.Models
{
    public class Appointments
    {
        [Required]
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("PatientRegistartion")]

        public int? PatientId { get; set; }
        [ForeignKey("Doctors")]
        public int? DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string AppointmentType { get; set; }
        public string AppointmentNotes { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual PatientRegistration Patient { get; set; }
    }
}