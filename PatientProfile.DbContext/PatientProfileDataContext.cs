using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PatientProfile.DbContext.Entity
{
    public class PatientProfileDataContext : IdentityDbContext 
    {
        public PatientProfileDataContext(DbContextOptions<PatientProfileDataContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalCard> MedicalCards { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public static void Main() { }
    }
}
