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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var project = builder.Entity<Project>();
            project.HasIndex(p => p.Name);
            project.HasIndex(p => p.IsActive);
            project.HasIndex(p => p.IsBillable);

            var sickLeave = builder.Entity<SickLeave>();
            sickLeave.HasIndex(s => s.StartDate);
            sickLeave.HasIndex(s => s.EndDate);

            var user = builder.Entity<ApplicationUser>();
            user.HasIndex(u => u.Email);
            user.HasIndex(u => u.Name);
            user.HasIndex(u => u.Surname);

            var vacation = builder.Entity<Vacation>();
            vacation.HasIndex(v => v.StartDate);
            vacation.HasIndex(v => v.EndDate);
            vacation.HasIndex(v => v.IsTeamBuilding);

            var workDay = builder.Entity<WorkDay>();
            workDay.HasIndex(w => w.WorkDate);
            workDay.HasIndex(w => w.WorkDayStart);

            var workSession = builder.Entity<WorkSession>();
            workSession.HasIndex(w => w.IsOvertime);
            workSession.HasIndex(w => w.ProjectId);
            workSession.HasIndex(w => w.TypeId);
        }
    }
}
