using FootballLeague.Core.Entities;
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
                .Setup(m => m.GetByIdAsync(expectedId))
                .ReturnsAsync(expectedTeam);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeam = await teamService.GetTeamByIdAsync(expectedId);

            Assert.NotNull(actualTeam);
            Assert.That(actualTeam.Id, Is.EqualTo(expectedId));
            Assert.That(actualTeam.Name, Is.EqualTo(expectedTeam.Name));
        }
    }
}
