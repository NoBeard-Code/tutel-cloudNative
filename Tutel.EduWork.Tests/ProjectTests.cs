using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.DTOs;
using Tutel.EduWork.Client.Components.Project;

namespace Tutel.EduWork.Tests
{
    public class ProjectTests : TestContext
    {
        /// <summary>
        /// Checks if projects are loaded and displayed in table.
        /// </summary>
        [Fact]
        public void Project_ProjectsLoaded()
        {
            var mockProjectService = new Mock<IProjectService>();

            var mockProjects = new List<ProjectDTO> {
                new ProjectDTO { Id = 1, Name = "Projekt A", Description = "Nije projekt A", IsActive = true, IsBillable = true},
                new ProjectDTO { Id = 2, Name = "Projekt B", Description = "Nije projekt B", IsActive = true, IsBillable = false}
            };

            mockProjectService.Setup(s => s.GetAllAsync()).ReturnsAsync(mockProjects);

            Services.AddSingleton(mockProjectService.Object);

            var cut = RenderComponent<ProjectList>(); 
            cut.WaitForState(() => cut.FindAll("tbody tr").Count == mockProjects.Count);

            var rows = cut.FindAll("tbody tr");
            Assert.Equal(mockProjects.Count, rows.Count);

            Assert.Contains("Projekt A", rows[0].InnerHtml);
            Assert.Contains("Projekt B", rows[1].InnerHtml);
        }

        /// <summary>
        /// Check if on dropdown select displayed projects are changed.
        /// </summary>
        [Fact]
        public void Project_OnSelectChangeProjects()
        {
            var mockProjectService = new Mock<IProjectService>();

            var mockProjects = new List<ProjectDTO> {
                new ProjectDTO { Id = 1, Name = "Projekt A", Description = "Nije projekt A", IsActive = true, IsBillable = true},
                new ProjectDTO { Id = 2, Name = "Projekt B", Description = "Nije projekt B", IsActive = false, IsBillable = false}
            };
            mockProjectService.Setup(s => s.GetAllAsync()).ReturnsAsync(mockProjects);

            Services.AddSingleton(mockProjectService.Object);

            var cut = RenderComponent<ProjectList>(); 
            cut.WaitForState(() => cut.FindAll("tbody tr").Count == 1);

            var rows = cut.FindAll("tbody tr");
            Assert.Single(rows);
            Assert.Contains("Projekt A", rows[0].InnerHtml);

            var select = cut.Find("select");

            select.Change("inactive");
            cut.WaitForState(() => cut.FindAll("tbody tr").Count == 1);
            rows = cut.FindAll("tbody tr");
            Assert.Single(rows);
            Assert.Contains("Projekt B", rows[0].InnerHtml);

            select.Change("all");
            cut.WaitForState(() => cut.FindAll("tbody tr").Count == 2);
            rows = cut.FindAll("tbody tr");
            Assert.Contains("Projekt A", rows[0].InnerHtml);
            Assert.Contains("Projekt B", rows[1].InnerHtml);
        }

        /// <summary>
        /// Checks if "Uredi" button redirects to edit page.
        /// </summary>
        [Fact]
        public void Project_OnEditRedirectToEditPage()
        {
            var mockProjectService = new Mock<IProjectService>();
            var mockProjects = new List<ProjectDTO> {
                new ProjectDTO { Id = 1, Name = "Projekt A", Description = "Nije projekt A", IsActive = true, IsBillable = true},
            };
            mockProjectService.Setup(s => s.GetAllAsync()).ReturnsAsync(mockProjects);

            Services.AddSingleton(mockProjectService.Object);

            var navMan = Services.GetRequiredService<FakeNavigationManager>();

            var cut = RenderComponent<ProjectList>(); 
            cut.WaitForState(() => cut.FindAll("tbody tr").Count == 1);

            var editButton = cut.Find("button.btn-primary");

            editButton.Click();

            Assert.Equal($"editproject/{mockProjects[0].Id}", navMan.Uri.Replace(navMan.BaseUri, ""));
        }

        /// <summary>
        /// Add project and redirect to project page.
        /// </summary>
        [Fact]
        public void AddProject_AddProjectAndRedirectToProject()
        {
            var mockProjectService = new Mock<IProjectService>();
            mockProjectService.Setup(s => s.AddAsync(It.IsAny<ProjectDTO>())).Returns(Task.CompletedTask);

            Services.AddSingleton(mockProjectService.Object);

            var navMan= Services.GetRequiredService<FakeNavigationManager>();

            var cut = RenderComponent<AddProject>();

            cut.Find("#name").Change("Projekt B");
            cut.Find("#description").Change("Opis projekta B");
            cut.Find("#isBillable").Change(true);
            cut.Find("#isActive").Change(true);

            cut.Find("form").Submit();

            mockProjectService.Verify(s => s.AddAsync(It.Is<ProjectDTO>(
                p => p.Name == "Projekt B" &&
                     p.Description == "Opis projekta B" &&
                     p.IsBillable == true &&
                     p.IsActive == true
            )), Times.Once);
                
            Assert.Equal("project", navMan.Uri.Replace(navMan.BaseUri, ""));
        }
    }
}
