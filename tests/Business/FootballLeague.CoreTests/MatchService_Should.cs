using FootballLeague.Core.Entities;
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
            var expectedMatch = new Core.Entities.Match()
            {
                Id = 1,
                HomeTeamId = homeTeam.Id,
                AwayTeamId = awayTeam.Id,
                Date = matchDate,
                Result = new MatchResult()
                {
                    Id = 1,
                    HomeTeamScore = 2,
                    AwayTeamScore = 1,
                    MatchId = 1
                }
            };

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
                expectedMatch.Result.HomeTeamScore, 
                expectedMatch.Result.AwayTeamScore);

            Assert.NotNull(actialMatch);
            Assert.That(actialMatch.HomeTeamId, Is.EqualTo(expectedMatch.HomeTeamId));
            Assert.That(actialMatch.AwayTeamId, Is.EqualTo(expectedMatch.AwayTeamId));
            Assert.That(actialMatch.Date, Is.EqualTo(matchDate));
            Assert.NotNull(actialMatch.Result);
            Assert.That(actialMatch.Result.HomeTeamScore, Is.EqualTo(expectedMatch.Result.HomeTeamScore));
            Assert.That(actialMatch.Result.AwayTeamScore, Is.EqualTo(expectedMatch.Result.AwayTeamScore));
        }

        // TODO: Update Match test
        // TODO: Delete Match test
        // TODO: Get All Match test
        // TODO: Get by id Match test
    }
}
