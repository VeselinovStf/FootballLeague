using FootballLeague.Core.Entities;
using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Services;
using FootballLeague.Core.Specifications;
using FootballLeague.CoreTests.Stubs;
using Moq;
using NUnit.Framework;
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
                .Setup(m => m.GetAllBySpec(It.IsAny<TeamsWithStatiscticsSpecification>()))
                .Returns(expectedTeamsWithRanking);

            var teamService = new TeamService(teamServiceAsyncRepositoryMock.Object);

            var actualTeamsWithRanking = await teamService.GetAllTeamsWithStatisticsAsync();

            Assert.NotNull(actualTeamsWithRanking);
            CollectionAssert.AreEqual(expectedTeamsWithRanking, actualTeamsWithRanking);
        }
    }
}
