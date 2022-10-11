using FootballLeague.Core.Entities;
using System.Collections.Generic;

namespace FootballLeague.CoreTests.Builders
{
    public static class TeamBuilder
    {
        public static Team GetTeam(int id)
        {
            return new Team($"Team {id}", new Statistic()) { Id = id };
        }

        public static List<Team> GetTeamsStub()
        {
            var teams = new List<Team>();
            for (int i = 1; i < 5; i++)
            {
                teams.Add(GetTeam(i));
            }

            return teams;
        }

        public static List<Team> GetTeamsWithStatistics()
        {
            return new List<Team>()
            {
                new Team("Team 1", new Statistic()
                    {
                        Id = 1,
                        TotalScore = 5
                    } ){Id = 1},

                new Team("Team 2",  new Statistic()
                    {
                        Id = 2,
                        TotalScore = 78
                    }){Id = 2}
            };
        }

        public static List<Team> GetTeamsWithMatches()
        {
            var team1 = new Team("Team 1", new Statistic()) { Id = 1 };
            var team2 = new Team("Team 1", new Statistic()) { Id = 2 };

            var match1 = new Match()
            {
                Id = 1,
                HomeTeam = team1,
                HomeTeamId = team1.Id,
                AwayTeam = team2,
                AwayTeamId = team2.Id
            };

            var match2 = new Match()
            {
                Id = 2,
                HomeTeam = team2,
                HomeTeamId = team2.Id,
                AwayTeam = team1,
                AwayTeamId = team1.Id
            };

            team1.AddNewMatch(match1, match2);

            return new List<Team> { team1, team2 };
        }
    }
}
