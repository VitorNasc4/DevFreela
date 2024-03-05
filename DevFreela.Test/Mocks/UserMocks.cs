using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using DevFreela.Core.Entities;

namespace DevFreela.Test.Mocks
{
    public class UserMocks
    {
        public static User GetValidClientUser()
        {
            var faker = new Faker<User>("pt_BR")
                .CustomInstantiator(f => new User(
                    f.Person.FullName,
                    f.Internet.Email(),
                    f.Date.Past(30, DateTime.Now.AddYears(-18)),
                    f.Internet.Password(),
                    "client"
                ));

            var fakeUser = faker.Generate();
            return fakeUser;
        }
        public static User GetValidFreelancerUser()
        {
            var faker = new Faker<User>("pt_BR")
                .CustomInstantiator(f => new User(
                    f.Person.FullName,
                    f.Internet.Email(),
                    f.Date.Past(30, DateTime.Now.AddYears(-18)),
                    f.Internet.Password(),
                    "freelancer"
                ));

            var fakeUser = faker.Generate();
            return fakeUser;
        }

    }
}