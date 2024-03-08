using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.Test.Application.Queries
{
    public class GetAllSkillsQueryHandlerTest
    {
        [Fact]
        public async void ThreeSkillsExist_Executes_ReturnThreeSkillViewModels()
        {
            var skills = new List<Skill>
            {
                new Skill("descrição 1"),
                new Skill("descrição 2"),
                new Skill("descrição 3")
            };

            var skillRepository = new Mock<ISkillRepository>();
            skillRepository
                .Setup(sr => sr.GetAllAsync())
                .ReturnsAsync(skills);

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var sut = new GetAllSkillsQueryHandler(skillRepository.Object);
            var result = await sut.Handle(getAllSkillsQuery, new CancellationToken());

            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.Equal(skills.Count, result.Count);
            skillRepository.Verify(sr => sr.GetAllAsync(), Times.Once);
        }
    }
}