using Moq;
using ProjectManagement.Api.Business;
using ProjectManagement.Api.Models;
using ProjectManagement.Api.Repositories;

namespace ProjectManagement.Api.Tests;

public class ProjectBusiness_UpdateTest
{
    [Fact]
    public async void WhenNotOwnedUser_ThenUnauthorizedValidation()
    {
        var requestContext = new Mock<IRequestContext>();
        requestContext.Setup(x => x.GetUserId()).Returns(2);
        
        var projectRepositoryMock = new Mock<IProjectRepository>();
        projectRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(new Project()
        {
            Id = 1,
            Title = "Project 1",
            Description = "The project 1",
            BeganAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            IsSubproject = false,
            ParentId = null,
            UserId = 1
        });

        var project = new Project() { Id = 1, Title = "Project One", Description = "The project One"};
        var projectBusiness = new ProjectBusiness(requestContext.Object, projectRepositoryMock.Object);

        var result = await projectBusiness.UpdateAsync(1, project);

        Assert.IsType<UnauthorizedValidation>(result);
    }
}