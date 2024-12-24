using Microsoft.EntityFrameworkCore;

namespace Booking_Webiste.Models
{
    public class PatientDBContext : DbContext
    {
        public PatientDBContext(DbContextOptions options) : base(options)
        {
            

        }
        public DbSet<Patient> Patients { get; set; }
    }
}
