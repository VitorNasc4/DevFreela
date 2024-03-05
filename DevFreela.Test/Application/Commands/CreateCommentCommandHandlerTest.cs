using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.Test.Application.Commands
{
    public class CreateCommentCommandHandlerTest
    {
        [Fact]
        public async void InputDataIsOk_Executed_CallsAddCommentAsync()
        {
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createCommentCommand = new CreateCommentCommand
            {
                Content = "comentário",
                IdProject = 1,
                IdUser = 2
            };
            var sut = new CreateCommentCommandHandler(projectRepositoryMock.Object);
            await sut.Handle(createCommentCommand, new CancellationToken());

            projectRepositoryMock.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}