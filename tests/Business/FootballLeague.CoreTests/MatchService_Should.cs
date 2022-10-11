using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Services;
using FootballLeague.CoreTests.Builders;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FootballLeague.CoreTests
{
    public class MatchService_Should
    {
        [Test]
        public async Task CreateMatchAsync_When_Valid_ParamersAre_Passed()
        {
            var homeTeam = TeamBuilder.GetTeam(1);

            var awayTeam = TeamBuilder.GetTeam(2);

            var matchDate = DateTime.Now;
            var expectedMatch = new Core.Entities.Match(homeTeam.Id, awayTeam.Id, matchDate, 2, 1)
            { Id = 1 };

            var matchServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Core.Entities.Match>>();
            var teamServiceAsyncRepositoryMock = new Mock<IAsyncRepository<Core.Entities.Team>>();

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(homeTeam.Id))
                .ReturnsAsync(homeTeam);

            teamServiceAsyncRepositoryMock
                .Setup(m => m.GetByIdAsync(awayTeam.Id))
                .ReturnsAsync(awayTeam);

            matchServiceAsyncRepositoryMock
                .Setup(m => m.AddAsync(It.IsAny<Core.Entities.Match>()))
                .ReturnsAsync(expectedMatch);

            var matchService = new MatchService(matchServiceAsyncRepositoryMock.Object, teamServiceAsyncRepositoryMock.Object);

            var actialMatch = await matchService.CreateMatchAsync(
                homeTeam.Id,
                awayTeam.Id,
                matchDate,
                expectedMatch.HomeTeamScore,
                expectedMatch.AwayTeamScore);

            Assert.NotNull(actialMatch);
            Assert.That(actialMatch.HomeTeamId, Is.EqualTo(expectedMatch.HomeTeamId));
            Assert.That(actialMatch.AwayTeamId, Is.EqualTo(expectedMatch.AwayTeamId));
            Assert.That(actialMatch.Date, Is.EqualTo(matchDate));
            Assert.That(actialMatch.HomeTeamScore, Is.EqualTo(expectedMatch.HomeTeamScore));
            Assert.That(actialMatch.AwayTeamScore, Is.EqualTo(expectedMatch.AwayTeamScore));
        }

        // TODO: Update Match test
        // TODO: Delete Match test
        // TODO: Get All Match test
        // TODO: Get by id Match test
    }
}
