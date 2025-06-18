using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tutel.EduWork.DataAccessLayer.Entities;

namespace Tutel.EduWork.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<SickLeave> SickLeaves { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<WorkSession> WorkSessions { get; set; }
        public DbSet<WorkSessionType> WorkSessionTypes { get; set; }
    }
}
