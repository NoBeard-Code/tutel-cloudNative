using System.Net.Http.Headers;
using Tutel.EduWork.Data;

namespace Tutel.EduWork.DataAccessLayer
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Cleanup()
        {
            _context.WorkSessions.RemoveRange(_context.WorkSessions);
            _context.WorkDays.RemoveRange(_context.WorkDays);
            _context.UserProjects.RemoveRange(_context.UserProjects);
            _context.Vacations.RemoveRange(_context.Vacations);
            _context.SickLeaves.RemoveRange(_context.SickLeaves);

            _context.Projects.RemoveRange(_context.Projects);
            _context.WorkSessionTypes.RemoveRange(_context.WorkSessionTypes);
            _context.Users.RemoveRange(_context.Users);

            _context.Roles.RemoveRange(_context.Roles);
            _context.UserRoles.RemoveRange(_context.UserRoles);

            _context.SaveChanges();
        }

        public void Seed()
        {
            
            Cleanup();

            var user1 = new Entities.ApplicationUser
            {
                Id = "b1e207f2-9c36-41fd-b587-df7d4e0b4d2f",
                UserName = "perokos@mail.com",
                NormalizedUserName = "PEROKOS@MAIL.COM",
                Email = "perokos@mail.com",
                NormalizedEmail = "PEROKOS@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGVVQO9tT545J7972g/FIeaXBP9CYEGcgw22zhPHiFTU43AyVKDN2XgmECS9o+8B1g==",
                SecurityStamp = "LBVGORWNUZWDU6HUMNJRAFNJJNHOIRNS",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Pero",
                Surname = "Kos",
                Position = "Developer"
            };

            var user2 = new Entities.ApplicationUser
            {
                Id = "01667bee-0442-488d-9346-be00ccaaad86",
                UserName = "matomedved@mail.com",
                NormalizedUserName = "MATOMEDVED@MAIL.COM",
                Email = "matomedved@mail.com",
                NormalizedEmail = "MATOMEDVED@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMO9IIBvBfdesDidx0YGJTdZupQpkolKZ1MDVhm6bXxUsJ0ELBcZMjU8DDq1y6Qo+Q==",
                SecurityStamp = "LBVGORWNUZWDU6HUMNJRAFNJJNHOIRNS",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Mato",
                Surname = "Medved",
                Position = "Tester"
            };

            _context.Users.AddRange(user1, user2);

            var typeBreak = new Entities.WorkSessionType { Name = "Pauza", Description = "Pauza" };

            var typeWork = new Entities.WorkSessionType { Name = "Radno vrijeme", Description = "Radno vrijeme" };

            _context.WorkSessionTypes.AddRange(typeBreak, typeWork);

            var project = new Entities.Project
            {
                Name = "Projekt A",
                Description = "Projekt A",
                IsActive = true,
                IsBillable = true
            };

            _context.Projects.Add(project);
            _context.SaveChanges(); 

            var workDay = new Entities.WorkDay
            {
                WorkDate = new DateOnly(2025, 6, 17),
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            _context.WorkDays.Add(workDay);
            _context.SaveChanges(); 

            var session = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(10, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project.Id,
                WorkDayId = workDay.Id
            };

            _context.WorkSessions.Add(session);

            _context.Vacations.Add(new Entities.Vacation
            {
                StartDate = new DateOnly(2025, 6, 20),
                EndDate = new DateOnly(2025, 6, 25),
                IsTeamBuilding = false,
                Year = 2025,
                UserId = user1.Id
            });

            _context.SickLeaves.Add(new Entities.SickLeave
            {
                StartDate = new DateOnly(2025, 5, 26),
                EndDate = new DateOnly(2025, 5, 30),
                Reason = "Bolest",
                UserId = user2.Id
            });

            _context.UserProjects.AddRange(new[] {
                new Entities.UserProject { UserId = user1.Id, ProjectId = project.Id },
                new Entities.UserProject { UserId = user2.Id, ProjectId = project.Id }
            });

            _context.SaveChanges();

            _context.Dispose();
        }
    }
}
