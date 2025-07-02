using Microsoft.AspNetCore.Identity;
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
                UserName = "perokos@mail.com",
                NormalizedUserName = "PEROKOS@MAIL.COM",
                Email = "perokos@mail.com",
                NormalizedEmail = "PEROKOS@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGVVQO9tT545J7972g/FIeaXBP9CYEGcgw22zhPHiFTU43AyVKDN2XgmECS9o+8B1g==",
                SecurityStamp = "LBVGORWNUZWDU6HUMNJRAFNJJNHOIRNS",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Pero",
                Surname = "Kos"
            };

            var user2 = new Entities.ApplicationUser
            {
                UserName = "matomedved@mail.com",
                NormalizedUserName = "MATOMEDVED@MAIL.COM",
                Email = "matomedved@mail.com",
                NormalizedEmail = "MATOMEDVED@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMO9IIBvBfdesDidx0YGJTdZupQpkolKZ1MDVhm6bXxUsJ0ELBcZMjU8DDq1y6Qo+Q==",
                SecurityStamp = "LBVGORWNUZWDU6HUMNJRAFNJJNHOIRNS",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Mato",
                Surname = "Medved"
            };

            var user3 = new Entities.ApplicationUser
            {
                UserName = "dunjalasta@mail.com",
                NormalizedUserName = "DUNJALASTA@MAIL.COM",
                Email = "dunjalasta@mail.com",
                NormalizedEmail = "DUNJALASTA@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = "533QXQEQQBACFFQVTAEMH3QUJWKPYKGZ",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Dunja",
                Surname = "Lasta"
            };

            var user4 = new Entities.ApplicationUser
            {
                UserName = "anarakun@mail.com",
                NormalizedUserName = "ANARAKUN@MAIL.COM",
                Email = "anarakun@mail.com",
                NormalizedEmail = "ANARAKUN@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Ana",
                Surname = "Rakun"
            };

            var user5 = new Entities.ApplicationUser
            {
                UserName = "petarkonj@mail.com",
                NormalizedUserName = "PETARKONJ@MAIL.COM",
                Email = "petarkonj@mail.com",
                NormalizedEmail = "PETARKONJ@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Petar",
                Surname = "Konj"
            };

            var user6 = new Entities.ApplicationUser
            {
                UserName = "ivanvuk@mail.com",
                NormalizedUserName = "IVANVUK@MAIL.COM",
                Email = "ivanvuk@mail.com",
                NormalizedEmail = "IVANVUK@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Ivan",
                Surname = "Vuk"
            };

            var user7 = new Entities.ApplicationUser
            {
                UserName = "katjapuz@mail.com",
                NormalizedUserName = "KATJAPUZ@MAIL.COM",
                Email = "katjapuz@mail.com",
                NormalizedEmail = "KATJAPUZ@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Katja",
                Surname = "Puz"
            };

            var user8 = new Entities.ApplicationUser
            {
                UserName = "ivansisak@mail.com",
                NormalizedUserName = "IVANSISAK@MAIL.COM",
                Email = "ivansisak@mail.com",
                NormalizedEmail = "IVANSISAK@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Ivan",
                Surname = "Sisak"
            };

            var user9 = new Entities.ApplicationUser
            {
                UserName = "marinasova@mail.com",
                NormalizedUserName = "MARINASOVA@MAIL.COM",
                Email = "marinasova@mail.com",
                NormalizedEmail = "MARINASOVA@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Marina",
                Surname = "Sova"
            };

            var user10 = new Entities.ApplicationUser
            {
                UserName = "domagojzec@mail.com",
                NormalizedUserName = "DOMAGOJZEC@MAIL.COM",
                Email = "domagojzec@mail.com",
                NormalizedEmail = "DOMAGOJZEC@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Domagoj",
                Surname = "Zec"
            };

            var user11 = new Entities.ApplicationUser
            {
                UserName = "ivanaorao@mail.com",
                NormalizedUserName = "IVANAORAO@MAIL.COM",
                Email = "ivanaorao@mail.com",
                NormalizedEmail = "IVANAORAO@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Ivana",
                Surname = "Orao"
            };

            var user12 = new Entities.ApplicationUser
            {
                UserName = "darkoriba@mail.com",
                NormalizedUserName = "DARKORIBA@MAIL.COM",
                Email = "darkoriba@mail.com",
                NormalizedEmail = "DARKORIBA@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Darko",
                Surname = "Riba"
            };

            var user13 = new Entities.ApplicationUser
            {
                UserName = "anaorao@mail.com",
                NormalizedUserName = "ANAORAO@MAIL.COM",
                Email = "anaorao@mail.com",
                NormalizedEmail = "ANAORAO@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Ana",
                Surname = "Orao"
            };

            var user14 = new Entities.ApplicationUser
            {
                UserName = "petarmedvjed@mail.com",
                NormalizedUserName = "PETARMEDVJED@MAIL.COM",
                Email = "petarmedvjed@mail.com",
                NormalizedEmail = "PETARMEDVJED@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Petar",
                Surname = "Medvjed"
            };

            var user15 = new Entities.ApplicationUser
            {
                UserName = "saralisica@mail.com",
                NormalizedUserName = "SARALISICA@MAIL.COM",
                Email = "saralisica@mail.com",
                NormalizedEmail = "SARALISICA@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGhU4Y7mJFg2TDwEQNCztHfRXHrn0mp8smqxchx2JXDr57GATBcvy0p5SBZ9YW4trw==",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Sara",
                Surname = "Lisica"
            };

            _context.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12, user13, user14, user15);

            var typeBreak = new Entities.WorkSessionType { Name = "Pauza", Description = "Pauza" };

            var typeWork = new Entities.WorkSessionType { Name = "Radno vrijeme", Description = "Radno vrijeme" };

            _context.WorkSessionTypes.AddRange(typeBreak, typeWork);

            var project1 = new Entities.Project
            {
                Name = "Aplikacija za upravljanje zadacima",
                Description = "Web aplikacija za praćenje i upravljanje dnevnim zadacima i projektima.",
                IsActive = true,
                IsBillable = true
            };

            var project2 = new Entities.Project
            {
                Name = "Mobilna aplikacija za fitness",
                Description = "Aplikacija koja prati vježbe, kalorije i napredak korisnika.",
                IsActive = true,
                IsBillable = true
            };

            var project3 = new Entities.Project
            {
                Name = "Sustav za rezervaciju termina",
                Description = "Online sustav koji omogućava korisnicima rezervaciju termina za razne usluge.",
                IsActive = true,
                IsBillable = true
            };

            var project4 = new Entities.Project
            {
                Name = "Platforma za e-učenje",
                Description = "Web platforma za objavljivanje i praćenje edukativnih sadržaja i tečajeva.",
                IsActive = true,
                IsBillable = true
            };

            var project5 = new Entities.Project
            {
                Name = "Aplikacija za upravljanje financijama",
                Description = "Alat za praćenje prihoda, rashoda i planiranje budžeta.",
                IsActive = true,
                IsBillable = true
            };

            var project6 = new Entities.Project
            {
                Name = "Chat aplikacija za timsku komunikaciju",
                Description = "Real-time chat aplikacija za bolju suradnju unutar timova.",
                IsActive = true,
                IsBillable = true
            };

            _context.Projects.AddRange(project1, project2, project3, project4, project5, project6);
            _context.SaveChanges();

            var dates = new List<DateOnly>
            {
                new DateOnly(2025, 6, 16),
                new DateOnly(2025, 6, 17),
                new DateOnly(2025, 6, 18),
                new DateOnly(2025, 6, 19),
                new DateOnly(2025, 6, 20),
                new DateOnly(2025, 6, 23),
                new DateOnly(2025, 6, 24),
                new DateOnly(2025, 6, 25),
                new DateOnly(2025, 6, 26),
                new DateOnly(2025, 6, 27)
            };

            var workDay1 = new Entities.WorkDay
            {
                WorkDate = dates[0],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay2 = new Entities.WorkDay
            {
                WorkDate = dates[1],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay3 = new Entities.WorkDay
            {
                WorkDate = dates[2],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay4 = new Entities.WorkDay
            {
                WorkDate = dates[3],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay5 = new Entities.WorkDay
            {
                WorkDate = dates[4],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay6 = new Entities.WorkDay
            {
                WorkDate = dates[5],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay7 = new Entities.WorkDay
            {
                WorkDate = dates[6],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay8 = new Entities.WorkDay
            {
                WorkDate = dates[7],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay9 = new Entities.WorkDay
            {
                WorkDate = dates[8],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay10 = new Entities.WorkDay
            {
                WorkDate = dates[9],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user1.Id
            };

            var workDay11 = new Entities.WorkDay
            {
                WorkDate = dates[0],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay12 = new Entities.WorkDay
            {
                WorkDate = dates[1],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay13 = new Entities.WorkDay
            {
                WorkDate = dates[2],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay14 = new Entities.WorkDay
            {
                WorkDate = dates[3],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay15 = new Entities.WorkDay
            {
                WorkDate = dates[4],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay16 = new Entities.WorkDay
            {
                WorkDate = dates[5],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay17 = new Entities.WorkDay
            {
                WorkDate = dates[6],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay18 = new Entities.WorkDay
            {
                WorkDate = dates[7],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay19 = new Entities.WorkDay
            {
                WorkDate = dates[8],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay20 = new Entities.WorkDay
            {
                WorkDate = dates[9],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user2.Id
            };

            var workDay21 = new Entities.WorkDay
            {
                WorkDate = dates[0],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay22 = new Entities.WorkDay
            {
                WorkDate = dates[1],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay23 = new Entities.WorkDay
            {
                WorkDate = dates[2],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay24 = new Entities.WorkDay
            {
                WorkDate = dates[3],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay25 = new Entities.WorkDay
            {
                WorkDate = dates[4],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay26 = new Entities.WorkDay
            {
                WorkDate = dates[5],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay27 = new Entities.WorkDay
            {
                WorkDate = dates[6],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay28 = new Entities.WorkDay
            {
                WorkDate = dates[7],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay29 = new Entities.WorkDay
            {
                WorkDate = dates[8],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay30 = new Entities.WorkDay
            {
                WorkDate = dates[9],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user3.Id
            };

            var workDay31 = new Entities.WorkDay
            {
                WorkDate = dates[0],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay32 = new Entities.WorkDay
            {
                WorkDate = dates[1],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay33 = new Entities.WorkDay
            {
                WorkDate = dates[2],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay34 = new Entities.WorkDay
            {
                WorkDate = dates[3],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay35 = new Entities.WorkDay
            {
                WorkDate = dates[4],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay36 = new Entities.WorkDay
            {
                WorkDate = dates[5],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay37 = new Entities.WorkDay
            {
                WorkDate = dates[6],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay38 = new Entities.WorkDay
            {
                WorkDate = dates[7],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay39 = new Entities.WorkDay
            {
                WorkDate = dates[8],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay40 = new Entities.WorkDay
            {
                WorkDate = dates[9],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user4.Id
            };

            var workDay41 = new Entities.WorkDay
            {
                WorkDate = dates[0],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay42 = new Entities.WorkDay
            {
                WorkDate = dates[1],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay43 = new Entities.WorkDay
            {
                WorkDate = dates[2],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay44 = new Entities.WorkDay
            {
                WorkDate = dates[3],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay45 = new Entities.WorkDay
            {
                WorkDate = dates[4],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay46 = new Entities.WorkDay
            {
                WorkDate = dates[5],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay47 = new Entities.WorkDay
            {
                WorkDate = dates[6],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay48 = new Entities.WorkDay
            {
                WorkDate = dates[7],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay49 = new Entities.WorkDay
            {
                WorkDate = dates[8],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            var workDay50 = new Entities.WorkDay
            {
                WorkDate = dates[9],
                WorkDayStart = new TimeOnly(8, 0),
                UserId = user5.Id
            };

            _context.WorkDays.AddRange(workDay1, workDay2, workDay3, workDay4, workDay5, workDay6, workDay7, workDay8, workDay9, workDay10,
                workDay11, workDay12, workDay13, workDay14, workDay15, workDay16, workDay17, workDay18, workDay19, workDay20,
                workDay21, workDay22, workDay23, workDay24, workDay25, workDay26, workDay27, workDay28, workDay29, workDay30,
                workDay31, workDay32, workDay33, workDay34, workDay35, workDay36, workDay37, workDay38, workDay39, workDay40,
                workDay41, workDay42, workDay43, workDay44, workDay45, workDay46, workDay47, workDay48, workDay49, workDay50);
            _context.SaveChanges(); 

            var session1 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(10, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay1.Id
            };

            var session2 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(10, 31),
                EndTime = new TimeOnly(11, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay1.Id
            };

            var session3 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay1.Id
            };

            var session4 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(12, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay2.Id
            };

            var session5 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(12, 31),
                EndTime = new TimeOnly(13, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay2.Id
            };

            var session6 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(13, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project2.Id,
                WorkDayId = workDay2.Id
            };

            var session7 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(10, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay3.Id
            };

            var session8 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(10, 31),
                EndTime = new TimeOnly(11, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay3.Id
            };

            var session9 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project2.Id,
                WorkDayId = workDay3.Id
            };

            var session10 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(10, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay4.Id
            };

            var session11 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(10, 31),
                EndTime = new TimeOnly(11, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay4.Id
            };

            var session12 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay4.Id
            };

            var session13 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(11, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay5.Id
            };

            var session14 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 31),
                EndTime = new TimeOnly(12, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay5.Id
            };

            var session15 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(12, 01),
                EndTime = new TimeOnly(17, 0),
                IsOvertime = true,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay5.Id
            };

            var session16 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(11, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay11.Id
            };

            var session17 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 31),
                EndTime = new TimeOnly(12, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay11.Id
            };

            var session18 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(12, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay11.Id
            };

            var session19 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(11, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay12.Id
            };

            var session20 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 01),
                EndTime = new TimeOnly(14, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay12.Id
            };

            var session21 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(14, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project2.Id,
                WorkDayId = workDay12.Id
            };

            var session22 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(10, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay13.Id
            };

            var session23 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(10, 31),
                EndTime = new TimeOnly(11, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay13.Id
            };

            var session24 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project2.Id,
                WorkDayId = workDay13.Id
            };

            var session25 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(10, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay14.Id
            };

            var session26 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(10, 31),
                EndTime = new TimeOnly(11, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay14.Id
            };

            var session27 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(15, 01),
                EndTime = new TimeOnly(16, 0),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay14.Id
            };

            var session28 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(11, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay15.Id
            };

            var session29 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 31),
                EndTime = new TimeOnly(12, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay15.Id
            };

            var session30 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(12, 01),
                EndTime = new TimeOnly(17, 0),
                IsOvertime = true,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay15.Id
            };

            var session31 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(11, 30),
                IsOvertime = false,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay6.Id
            };

            var session32 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(11, 31),
                EndTime = new TimeOnly(12, 0),
                IsOvertime = false,
                TypeId = typeBreak.Id,
                WorkDayId = workDay6.Id
            };

            var session33 = new Entities.WorkSession
            {
                StartTime = new TimeOnly(12, 01),
                EndTime = new TimeOnly(17, 0),
                IsOvertime = true,
                TypeId = typeWork.Id,
                ProjectId = project1.Id,
                WorkDayId = workDay6.Id
            };

            _context.WorkSessions.AddRange(session1, session2, session3, session4, session5, session6, session7, session8, session9, session10, session11, session12, session13, session14, session15,
                session16, session17, session18, session19, session20, session21, session22, session23, session24, session25, session26, session27, session28, session29, session30,
                session31, session32, session33);

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
                new Entities.UserProject { UserId = user1.Id, ProjectId = project1.Id, Position = "Developer"},
                new Entities.UserProject { UserId = user1.Id, ProjectId = project2.Id, Position = "QA tester"},
                new Entities.UserProject { UserId = user2.Id, ProjectId = project1.Id, Position = "Business analyst"},
                new Entities.UserProject { UserId = user2.Id, ProjectId = project2.Id, Position = "QA tester"}
            });

            var role1 = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() };
            var role2 = new IdentityRole { Name = "Superuser", NormalizedName = "SUPERUSER", ConcurrencyStamp = Guid.NewGuid().ToString() };

            _context.Roles.AddRange(role1, role2);

            _context.SaveChanges();

            _context.UserRoles.AddRange(new[]
            {
                new IdentityUserRole<string> { RoleId = role1.Id, UserId = user1.Id },
                new IdentityUserRole<string> { RoleId = role2.Id, UserId = user1.Id },
                new IdentityUserRole<string> { RoleId = role2.Id, UserId = user2.Id },
                new IdentityUserRole<string> { RoleId = role1.Id, UserId = user3.Id },
                new IdentityUserRole<string> { RoleId = role2.Id, UserId = user3.Id }
            });

            _context.SaveChanges();

            _context.Dispose();
        }
    }
}
