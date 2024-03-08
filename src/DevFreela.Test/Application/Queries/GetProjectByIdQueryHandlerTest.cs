using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Test.Mocks;
using Moq;
using Xunit;

namespace DevFreela.Test.Application.Queries
{
    public class GetProjectByIdQueryHandlerTest
    {
        [Fact]
        public async void ProjectsExist_Executes_ReturnProjectViewModels()
        {
            var project = ProjectMocks.GetValidProject();
            var id = 1;

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr => pr.GetDetailsByIdAsync(id))
                .ReturnsAsync(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(id);
            var sut = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);
            var result = await sut.Handle(getProjectByIdQuery, new CancellationToken());

            Assert.NotNull(result);
            Assert.Equal(project.Title, result.Title);
            projectRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(id), Times.Once);
        }
    }
}