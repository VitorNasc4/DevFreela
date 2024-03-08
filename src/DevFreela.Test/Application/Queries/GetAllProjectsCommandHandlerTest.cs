using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.Test.Application.Queries
{
  public class GetAllProjectsCommandHandlerTest
  {
    [Fact]
    public async void ThreeProjectsExist_Executes_ReturnThreeProjectViewModels()
    {
      var projects = new List<Project>
            {
                new Project("Projeto 1", "descricao 1", 1, 2, 100),
                new Project("Projeto 2", "descricao 2", 1, 2, 100),
                new Project("Projeto 3", "descricao 3", 1, 2, 100)
            };

      var projectRepositoryMock = new Mock<IProjectRepository>();
      projectRepositoryMock
          .Setup(pr => pr.GetAllAsync())
          .ReturnsAsync(projects);

      var getAllProjectsQuery = new GetAllProjectsQuery("");
      var sut = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);
      var result = await sut.Handle(getAllProjectsQuery, new CancellationToken());

      Assert.NotEmpty(result);
      Assert.NotNull(result);
      Assert.Equal(projects.Count, result.Count);
      projectRepositoryMock.Verify(pr => pr.GetAllAsync(), Times.Once);
    }
  }
}