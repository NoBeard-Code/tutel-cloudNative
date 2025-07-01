using System.Security.Claims;
using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.Client.Components.TimeOff;

namespace Tutel.EduWork.Tests
{
    public class TimeOffTests : TestContext
    {
        private readonly string adminUserId = "simple-admin";
        private static readonly string regularUserId = "abc-123";

        private readonly List<VacationDTO> _mockVacations = new()
        {
            new VacationDTO
            {
                Id = 1,
                UserId = regularUserId,
                FullName = "Pero Kos",
                StartDate = new(2025, 6, 1),
                EndDate   = new(2025, 6, 5),
                IsTeamBuilding = false
            },
            new VacationDTO
            {
                Id = 2,
                UserId = "def-456",
                FullName = "Mato Medved",
                StartDate = new(2025, 7, 10),
                EndDate   = new(2025, 7, 14),
                IsTeamBuilding = true
            }
        };

        private readonly List<SickLeaveDTO> _mockSickLeaves = new()
        {
            new SickLeaveDTO
            {
                Id = 3,
                UserId = regularUserId,
                FullName = "Pero Kos",
                StartDate = new(2025, 5, 10),
                EndDate   = new(2025, 5, 12),
                Reason    = "Flu"
            }
        };

        /// <summary>
        /// Registers mocked services for vacation and sick leave.
        /// </summary>
        private void RegisterTimeOffMocks()
        {
            var vacMock = new Mock<IVacationService>();
            var sickMock = new Mock<ISickLeaveService>();

            vacMock.Setup(s => s.GetAllAsync()).ReturnsAsync(_mockVacations);
            sickMock.Setup(s => s.GetAllAsync()).ReturnsAsync(_mockSickLeaves);

            Services.AddSingleton(vacMock.Object);
            Services.AddSingleton(sickMock.Object);
        }

        /// <summary>
        /// Sets the authenticated user with optional admin role.
        /// Using SetRoles is critical for AuthorizeView to work correctly.
        /// </summary>
        private void SetAuthenticatedUser(string userId, bool isAdmin = false)
        {
            var auth = this.AddTestAuthorization();

            var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, userId) };
            if (isAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                claims.Add(new Claim("role", "Admin"));
            }

            auth.SetClaims(claims.ToArray());
            auth.SetAuthorized("authenticated");

            if (isAdmin)
            {
                auth.SetRoles("Admin");
            }
        }

        /// <summary>
        /// Tests that admin sees all absences, the add button, and the filter dropdown.
        /// </summary>
        [Fact]
        public void Admin_SeesAllAbsencesAndAddButton()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(adminUserId, isAdmin: true);

            var component = RenderComponent<TimeOffList>();

            Assert.Equal(3, component.FindAll("tbody tr").Count);

            var addButton = component.Find("button.btn-success");
            Assert.Contains("Dodaj odsutnost", addButton.TextContent);

            Assert.NotNull(component.Find("select"));
        }

        /// <summary>
        /// Tests that a regular user sees only their own absences, different add button text,
        /// and no filter dropdown.
        /// </summary>
        [Fact]
        public void RegularUser_SeesOnlyOwnAbsencesAndAddOwnButton()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(regularUserId, isAdmin: false);

            var component = RenderComponent<TimeOffList>();

            Assert.Equal(2, component.FindAll("tbody tr").Count);

            Assert.DoesNotContain("Mato Medved", component.Markup);

            Assert.Contains("Dodaj svoju odsutnost", component.Markup);

            Assert.Throws<Bunit.ElementNotFoundException>(() => component.Find("select"));
        }

        /// <summary>
        /// Tests that clicking the add button as admin navigates to the add time off page.
        /// </summary>
        [Fact]
        public void Admin_AddButtonNavigatesToAddTimeOffPage()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(adminUserId, isAdmin: true);

            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var component = RenderComponent<TimeOffList>();

            component.Find("button.btn-success").Click();

            Assert.Equal("addtimeoff", navMan.Uri.Replace(navMan.BaseUri, ""));
        }

        /// <summary>
        /// Tests that the filter dropdown filters the rows correctly for admin.
        /// </summary>
        [Fact]
        public void FilterDropdownFiltersRowsForAdmin()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(adminUserId, isAdmin: true);

            var component = RenderComponent<TimeOffList>();

            Assert.Equal(3, component.FindAll("tbody tr").Count);

            component.Find("select").Change("vacation");
            Assert.Equal(2, component.FindAll("tbody tr").Count);

            component.Find("select").Change("sickleave");
            Assert.Single(component.FindAll("tbody tr"));
        }

        /// <summary>
        /// Tests that a regular user cannot see or use the filter dropdown.
        /// </summary>
        [Fact]
        public void RegularUser_CannotFilterBecauseNoSelect()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(regularUserId, isAdmin: false);

            var component = RenderComponent<TimeOffList>();

            Assert.Throws<Bunit.ElementNotFoundException>(() => component.Find("select"));
        }

        /// <summary>
        /// Click on button on page TimeOffList should redirect to page for AddingTimeOff.
        /// </summary>
        [Fact]
        public void ClickingAddButton_NavigatesToAddTimeOff()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(adminUserId, isAdmin: true);

            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var comp = RenderComponent<TimeOffList>();

            comp.Find("button.btn-success").Click();

            Assert.Contains("addtimeoff", navMan.Uri.Replace(navMan.BaseUri, ""));
        }

        /// <summary>
        /// Clicking the Edit button in TimeOffList should navigate to 'editsickleave' or 'editvacation' page.
        /// Assumes there is at least one sick leave and one vacation rendered with Edit buttons.
        /// </summary>
        [Fact]
        public void ClickingEditSickLeaveButton_NavigatesToEditSickLeave()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(adminUserId, isAdmin: true);

            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var comp = RenderComponent<TimeOffList>();

            var editButtons = comp.FindAll("button.btn-primary");

            var sickLeaveEditButton = editButtons.FirstOrDefault(btn =>
                btn.ParentElement.ParentElement.InnerHtml.Contains("Bolovanje"));

            Assert.NotNull(sickLeaveEditButton);

            sickLeaveEditButton!.Click();

            Assert.Contains("editsickleave", navMan.Uri.Replace(navMan.BaseUri, ""));
        }

        /// <summary>
        /// Clicking the Edit button in TimeOffList should navigate to 'editvacation' page.
        /// Assumes there is at least one vacation rendered with Edit button.
        /// </summary>
        [Fact]
        public void ClickingEditVacationButton_NavigatesToEditVacation()
        {
            RegisterTimeOffMocks();
            SetAuthenticatedUser(adminUserId, isAdmin: true);

            var navMan = Services.GetRequiredService<FakeNavigationManager>();
            var comp = RenderComponent<TimeOffList>();

            var editButtons = comp.FindAll("button.btn-primary");

            var vacationEditButton = editButtons.FirstOrDefault(btn =>
                btn.ParentElement.ParentElement.InnerHtml.Contains("Godišnji"));

            Assert.NotNull(vacationEditButton);

            vacationEditButton!.Click();

            Assert.Contains("editvacation", navMan.Uri.Replace(navMan.BaseUri, ""));
        }
    }
}
