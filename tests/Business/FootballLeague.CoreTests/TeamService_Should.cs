using FootballLeague.Core.Entities;
using FootballLeague.Core.Exceptions;
using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Services;
using FootballLeague.Core.Specifications;
using FootballLeague.CoreTests.Stubs;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.CoreTests
{
    public class TeamService_Should
    {     
        [Test]
        public async Task GetAllTeamsRankingAsync()
        {
            var expectedTeamsWithRanking = TeamStub.GetTeamsWithStatisticsStub();

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.ListAsyncBySpec(It.IsAny<TeamsWithStatiscticsSpecification>()))
                .ReturnsAsync(expectedTeamsWithRanking);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeamsWithRanking = await teamService.GetAllTeamsWithStatisticsAsync();

            Assert.NotNull(actualTeamsWithRanking);
            CollectionAssert.AreEqual(expectedTeamsWithRanking, actualTeamsWithRanking);
        }

        [Test]
        public async Task GetAllTeamsPlayedMatchesAsync()
        {
            var expectedTeamsWithMatches = TeamStub.GetTeamsWithMatchesStub();

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.ListAsyncBySpec(It.IsAny<TeamsWithPlayedMatchesSpecification>()))
                .ReturnsAsync(expectedTeamsWithMatches);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeamsWithMatches = await teamService
                .GetTeamsWithMatches();

            Assert.NotNull(actualTeamsWithMatches);
            CollectionAssert.AreEqual(expectedTeamsWithMatches, actualTeamsWithMatches);

            var actualTeamsWithMatchesList = actualTeamsWithMatches.ToList();
            for (int i = 0; i < expectedTeamsWithMatches.Count; i++)
            {
                var expectedTeam = expectedTeamsWithMatches[i];
                var actualTeam = actualTeamsWithMatchesList[i];

                CollectionAssert.AreEqual(expectedTeam.HomeMatches, actualTeam.HomeMatches);
                CollectionAssert.AreEqual(expectedTeam.AwayMatches, actualTeam.AwayMatches);
            }
        }

        [Test]
        public async Task GetAllTeamsAsync()
        {
            var expectedTeams = TeamStub.GetTeamsStub();

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.ListAllAsync())
                .ReturnsAsync(expectedTeams);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeams = await teamService.GetAllTeamsAsync();

            Assert.NotNull(actualTeams);
            CollectionAssert.AreEqual(expectedTeams, actualTeams);
        }


        [Test]
        public async Task GetTeamByIdAsync()
        {
            var expectedId = 1;
            var expectedTeam = TeamStub.GetTeamStub(expectedId);

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedTeam);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeam = await teamService.GetTeamByIdAsync(expectedId);

            Assert.NotNull(actualTeam);
            Assert.That(actualTeam.Id, Is.EqualTo(expectedId));
            Assert.That(actualTeam.Name, Is.EqualTo(expectedTeam.Name));
        }

        [Test]
        public void Throws_ArgumentException_When_GetTeamByIdAsync_Team_Id_Is_Zero()
        {
            var expectedId = 0;
            var expectedTeam = TeamStub.GetTeamStub(expectedId);

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedTeam);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await teamService.GetTeamByIdAsync(expectedId));
        }

        [Test]
        public async Task CreateTeamAsync_When_Valid_ParamersAre_Passed()
        {
            var expectedTeam = new Team()
            {
                Id = 1,
                Name = "Team 1"
            };

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.AddAsync(It.IsAny<Team>()))
                .ReturnsAsync(expectedTeam);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeam = await teamService.CreateTeamAsync(expectedTeam.Name);

            Assert.NotNull(actualTeam);
            Assert.That(actualTeam.Id, Is.EqualTo(expectedTeam.Id));
            Assert.That(actualTeam.Name, Is.EqualTo(expectedTeam.Name));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Throws_ValidationException_When_CreateTeamAsync_Is_Called_With_Invalid_Parameter(string name)
        {
            var expectedTeam = new Team()
            {
                Id = 1,
                Name = "Team 1"
            };

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.AddAsync(It.IsAny<Team>()))
                .ReturnsAsync(expectedTeam);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await teamService.CreateTeamAsync(name));
        }

        [Test]
        public void Throws_ValidationException_When_UpdateTeamAsync_TeamId_Is_Invalid()
        {
            var expectedTeam = new Team()
            {
                Id = 1,
                Name = "Team 1"
            };

            var newName = "Team XXX";

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedTeam);

            teamServiceAsyncRepositoryMock
                .Setup(m => m.UpdateAsync(It.IsAny<Team>()));

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await teamService.UpdateTeamAsync(0, newName));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Throws_ValidationException_When_UpdateTeamAsync_Name_Is_Invalid(string newName)
        {
            var expectedTeam = new Team()
            {
                Id = 1,
                Name = "Team 1"
            };

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedTeam);

            teamServiceAsyncRepositoryMock
                .Setup(m => m.UpdateAsync(It.IsAny<Team>()));

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await teamService.UpdateTeamAsync(expectedTeam.Id,newName));
        }

        [Test]     
        public void Throws_ValidationException_When_UpdateTeamAsync_Team_To_Update_Is_Not_Found()
        {
            var expectedTeam = new Team()
            {
                Id = 1,
                Name = "Team 1"
            };

            var newName = "Team XXX";

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<Team>(null));

            teamServiceAsyncRepositoryMock
                .Setup(m => m.UpdateAsync(It.IsAny<Team>()));

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await teamService.UpdateTeamAsync(expectedTeam.Id, newName));
        }

        [Test]
        public void Throws_ValidationException_When_DeleteTeamAsync_TeamId_Is_Invalid()
        {
            var expectedTeam = new Team()
            {
                Id = 1,
                Name = "Team 1"
            };

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedTeam);

            teamServiceAsyncRepositoryMock
                .Setup(m => m.DeleteAsync(It.IsAny<Team>()));

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await teamService.DeleteTeamAsync(0));
        }

        [Test]
        public void Throws_ValidationException_When_DeleteTeamAsync_Team_To_Update_Is_Not_Found()
        {
            var expectedTeam = new Team()
            {
                Id = 1,
                Name = "Team 1"
            };

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<Team>(null));

            teamServiceAsyncRepositoryMock
                .Setup(m => m.DeleteAsync(It.IsAny<Team>()));

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await teamService.DeleteTeamAsync(expectedTeam.Id));
        }
    }
}
