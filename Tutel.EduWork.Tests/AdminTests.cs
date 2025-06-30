using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.Client.Components.Admin;
using Tutel.EduWork.Client.Pages;

namespace Tutel.EduWork.Tests
{
    public class AdminTests : TestContext
    {
        /// <summary>
        /// Check if components AdminDashboard and AdminManageUsers are rendered.
        /// </summary>
        [Fact]
        public void Admin_RenderAdminDasboardAndManageUsers()
        {
            var mockUserService = new Mock<IUserService>();
            var mockProjectService = new Mock<IProjectService>();
            var mockWorkDayService = new Mock<IWorkDayService>();

            var mockUsers = new List<UserDTO> {
                new UserDTO { Id = "abc-123", Name = "Pero", Surname = "Kos", Email = "nijeperokos@mail.com" },
                new UserDTO { Id = "def-456", Name = "Mato", Surname = "Medved", Email = "nijematomedved@mail.com" }
            };

            var mockProjects = new List<ProjectDTO> { 
                new ProjectDTO { Id = 1, Name = "Projekt A", Description = "Nije projekt A", IsActive = true, IsBillable = true},
                new ProjectDTO { Id = 2, Name = "Projekt B", Description = "Nije projekt B", IsActive = true, IsBillable = false}
            };

            var mockLateLogIns = new List<string> { "abc-123" };

            mockUserService.Setup(s => s.GetAllAsync()).ReturnsAsync(mockUsers);
            mockProjectService.Setup(s => s.GetAllActive(true)).ReturnsAsync(mockProjects);
            mockWorkDayService.Setup(s => s.GetUsersWithLateLogsIn()).ReturnsAsync(mockLateLogIns);

            Services.AddSingleton(mockUserService.Object);
            Services.AddSingleton(mockProjectService.Object);
            Services.AddSingleton(mockWorkDayService.Object);

            var component = RenderComponent<Admin>();

            var dashboard = component.FindComponent<AdminDashboard>();
            var manageUsers = component.FindComponent<AdminManageUsers>();

            Assert.Equal(2, dashboard.Instance.NumberOfUsers);
            Assert.Equal(1, dashboard.Instance.LateLogIns.Count);
            Assert.Equal(2, manageUsers.Instance.Users.Count);
        }

        /// <summary>
        /// Check if passed parameters NumberOfUsers, NumberOfActiveProjects and LateLogIns are displayed.
        /// </summary>
        [Fact]
        public void AdminDashboard_DisplayUserAndProjectCounts()
        {
            var mockUserService = new Mock<IUserService>();
            var mockProjectService = new Mock<IProjectService>();
            Services.AddSingleton(mockUserService.Object);
            Services.AddSingleton(mockProjectService.Object);

            var users = 5;
            var projects = 3;
            var lateLogins = new List<string> { "abc-123", "def-456" };

            var cut = RenderComponent<AdminDashboard>(parameters => parameters
                .Add(p => p.NumberOfUsers, users)
                .Add(p => p.NumberOfActiveProjects, projects)
                .Add(p => p.LateLogIns, lateLogins)
            );

            Assert.Contains("5", cut.Markup);
            Assert.Contains("3", cut.Markup);
            Assert.Contains("2", cut.Markup);

            Assert.Contains("Ukupan broj zaposlenika", cut.Markup);
            Assert.Contains("Broj aktivnih projekata", cut.Markup);
            Assert.Contains("Kašnjenja u unosu radnih dana", cut.Markup);
        }

        /// <summary>
        /// Check if click on project card redirects to page /timeonprojects.
        /// </summary>
        [Fact]
        public void AdminDashboard_OnProjectCardClickNavigateToTimeOnProjects()
        {
            var mockUserService = new Mock<IUserService>();
            var mockProjectService = new Mock<IProjectService>();
            Services.AddSingleton(mockUserService.Object);
            Services.AddSingleton(mockProjectService.Object);

            var navMan = Services.GetRequiredService<FakeNavigationManager>();

            var cut = RenderComponent<AdminDashboard>(parameters => parameters
                .Add(p => p.NumberOfUsers, 2)
                .Add(p => p.NumberOfActiveProjects, 2)
                .Add(p => p.LateLogIns, new List<string>())
            );

            cut.FindAll(".card")[2].Click();

            Assert.Equal("timeonprojects", navMan?.Uri.Replace(navMan.BaseUri, ""));
        }

        /// <summary>
        /// Check if users are displayed in table.
        /// </summary>
        [Fact]
        public void AdminManageUsers_ShowUsersInTable()
        {
            var cut = RenderComponent<AdminManageUsers>(parameters => parameters
                .Add(p => p.Users, new List<UserDTO> {
                    new UserDTO { Id = "abc-123", Name = "Pero", Surname = "Kos", Email = "nijeperokos@mail.com" },
                    new UserDTO { Id = "def-456", Name = "Mato", Surname = "Medved", Email = "nijematomedved@mail.com" }
                })
                .Add(p => p.HighlightedUsers, new List<string> { "def-456" }));

            var markup = cut.Markup;

            Assert.Contains("nijeperokos@mail.com", markup);
            Assert.Contains("nijematomedved@mail.com", markup);
        }

        /// <summary>
        /// Check if users with late log ins are higlighted in table with the table-danger class.
        /// </summary>
        [Fact]
        public void AdminManageUsers_HiglihtTableContentForLateUsers()
        {
            var cut = RenderComponent<AdminManageUsers>(parameters => parameters
                .Add(p => p.Users, new List<UserDTO> {
                    new UserDTO { Id = "abc-123", Name = "Pero", Surname = "Kos", Email = "nijeperokos@mail.com" },
                    new UserDTO { Id = "def-456", Name = "Mato", Surname = "Medved", Email = "nijematomedved@mail.com" }
                })
                .Add(p => p.HighlightedUsers, new List<string> { "def-456" }));

            var rows = cut.FindAll("tbody tr");

            var lateUserRow = rows.FirstOrDefault(row => row.TextContent.Contains("nijematomedved@mail.com"));

            Assert.Contains("table-danger", lateUserRow.ClassList);
        }

        /// <summary>
        /// Check if "Dodaj novog zaposlenika" button redirects to /adduser page.
        /// </summary>
        [Fact]
        public void AdminManageUsers_OnAddUserCLickNavigateToAddUserPage()
        {
            var navMan = Services.GetRequiredService<FakeNavigationManager>();

            var cut = RenderComponent<AdminManageUsers>(parameters => parameters
                .Add(p => p.Users, new List<UserDTO> {
                    new UserDTO { Id = "abc-123", Name = "Pero", Surname = "Kos", Email = "nijeperokos@mail.com" },
                    new UserDTO { Id = "def-456", Name = "Mato", Surname = "Medved", Email = "nijematomedved@mail.com" }
                })
                .Add(p => p.HighlightedUsers, new List<string> { "def-456" }));

            var addButton = cut.FindAll("button")
                .FirstOrDefault(b => b.TextContent.Contains("Dodaj novog zaposlenika"));
            
            addButton?.Click();

            Assert.Equal("adduser", navMan?.Uri.Replace(navMan.BaseUri, ""));
        }
    }
}
