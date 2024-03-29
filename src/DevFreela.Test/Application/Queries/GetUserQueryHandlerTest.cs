using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Core.Repositories;
using DevFreela.Test.Mocks;
using Moq;
using Xunit;

namespace DevFreela.Test.Application.Queries
{
    public class GetUserQueryHandlerTest
    {
        [Fact]
        public async void UsersExist_Executes_ReturnUserViewModels()
        {
            var user = UserMocks.GetValidClientUser();
            var id = 1;

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock
                .Setup(ur => ur.GetUserByIdAsync(id))
                .ReturnsAsync(user);

            var getUserQuery = new GetUserQuery(id);
            var sut = new GetUserQueryHandler(userRepositoryMock.Object);
            var result = await sut.Handle(getUserQuery, new CancellationToken());

            Assert.NotNull(result);
            Assert.Equal(user.FullName, result.FullName);
            userRepositoryMock.Verify(ur => ur.GetUserByIdAsync(id), Times.Once);
        }
    }
}