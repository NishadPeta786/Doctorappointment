using Microsoft.EntityFrameworkCore;
using Doctorappointment.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doctorappointment.Models
{
    public class NishadoctorDbContext : DbContext
    {
        public NishadoctorDbContext(DbContextOptions<NishadoctorDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<PatientRegistration> PatientRegistrations { get; set; }
        public virtual DbSet<Appointments> Appointments { get; set; }
    }
}