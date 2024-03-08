using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Test.Mocks
{
    public class ProjectMocks
    {
        public static Project GetValidProject()
        {
            var faker = new Faker<Project>("pt_BR")
            .CustomInstantiator(f =>
                new Project(
                    f.Company.CompanyName(),
                    f.Lorem.Paragraph(),
                    f.Random.Int(1, 100),
                    f.Random.Int(1, 100),
                    f.Finance.Amount(1000, 5000)
                ))
            .RuleFor(p => p.Status, f => f.PickRandom<ProjectStatusEnum>())
            .RuleFor(p => p.StartedAt, f => f.Date.Past(2))
            .RuleFor(p => p.FinishedAt, f => f.Date.Past(1))
            .RuleFor(p => p.Client, UserMocks.GetValidClientUser())
            .RuleFor(p => p.Freelancer, UserMocks.GetValidFreelancerUser());

            var fakeProject = faker.Generate();

            return fakeProject;
        }
    }
}