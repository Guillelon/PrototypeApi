using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypeApi;
using Moq;
using System.Collections.Generic;


namespace PrototypeTest
{
    [TestClass]
    public class TestingTeamRepository
    {
        Mock<ITeamRepository> mockRepository;

        public TestingTeamRepository()
        {
            mockRepository = new Mock<ITeamRepository>();
            var listToTest = new List<Team> 
            {
                new Team { Id = 1, Name = "Dummy F.C", City = "Dummy", Country = "Dummyland" },
                new Team { Id = 2, Name = "Foo F.C", City = "Foo", Country = "Fooland" },
                new Team { Id = 3, Name = "Chavez F.C", City = "Chavez", Country = "Chavezland" },
            };

            mockRepository.Setup(mr => mr.GetAll()).Returns(listToTest);

            // Allows us to test saving a product
            mockRepository.Setup(mr => mr.Add(It.IsAny<Team>())).Returns(
                (Team team) =>
                {                   
                    team.Name = "Maduro F.C";
                    team.City = "Maduro";
                    team.Country = "MaduroLand";
                    listToTest.Add(team);
                    return team;
                });
        }

        [TestMethod]
        public void GetAll()
        {
            var list = mockRepository.Object.GetAll();
            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void Add() 
        {
            var newTeam = new Team { Id = 4, Name = "Arroceros F.C", City = "Coro", Country = "Venezuela"};
            mockRepository.Object.Add(newTeam);

            //Reconteo de votos :)
            var teamCount = mockRepository.Object.GetAll().Count;
            Assert.AreEqual(4, teamCount);
        }
    }
}
