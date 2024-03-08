using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.Test.Application.Commands
{
  public class CreateProjectCommandHandlerTest
  {
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnProjectId()
    {
      var projectRepositoryMock = new Mock<IProjectRepository>();
      var createProjectCommand = new CreateProjectCommand
      {
        Title = "Titulo",
        Description = "descrição",
        TotalCost = 100,
        IdClient = 1,
        IdFreelancer = 2
      };

      var sut = new CreateProjectCommandHandler(projectRepositoryMock.Object);
      var id = await sut.Handle(createProjectCommand, new CancellationToken());

      Assert.True(id >= 0);
      projectRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
    }
  }
}