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
        public async Task GetAllTeamsRanking()
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
        public async Task GetAllTeamsPlayedMatches()
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
        public async Task GetAllTeams()
        {
            var expectedTeams = TeamStub.GetTeamsStub();

            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.ListAllAsync())
                .ReturnsAsync(expectedTeams);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeamsWithRanking = await teamService.GetAllTeamsAsync();

            Assert.NotNull(actualTeamsWithRanking);
            CollectionAssert.AreEqual(expectedTeams, actualTeamsWithRanking);
        }

    }
}
