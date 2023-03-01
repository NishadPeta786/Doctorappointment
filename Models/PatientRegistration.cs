using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Doctorappointment.Models
{
    public class PatientRegistration
    {
        [Key]
        [Required]
        public int patient_id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string DOB { get; set; }

        [Required]
        public string Gender { get; set; }


    }
}