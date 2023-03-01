using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Doctorappointment.Models
{
    public class Doctors
    {
        [Key]
        [Required]
        public int doctor_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public string emailid { get; set; }
        [Required]
        public string Phonenumber { get; set; }


    }
}