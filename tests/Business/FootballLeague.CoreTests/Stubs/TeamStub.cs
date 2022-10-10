using FootballLeague.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.CoreTests.Stubs
{
    public static class TeamStub
    {
        public static Team GetTeamStub(int id)
        {
            return new Team()
            {
                Id = id,
                Name = $"Team {id}",

            };
        }

        public static List<Team> GetTeamsStub()
        {
            var teams = new List<Team>();
            for (int i = 1; i < 5; i++)
            {
                teams.Add(GetTeamStub(i));
            }
            
            return teams;
        }

        public static List<Team> GetTeamsWithStatisticsStub()
        {
            return new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "Team 1",
                    Statistic = new Statistic()
                    {
                        Id = 1,
                        TotalScore = 5
                    }
                },
                new Team()
                {
                    Id = 2,
                    Name = "Team 2",
                    Statistic = new Statistic()
                    {
                        Id = 2,
                        TotalScore = 78
                    }
                }
            };
        }

        public static List<Team> GetTeamsWithMatchesStub()
        {
            var team1 = new Team()
            {
                Id = 1,
                Name = "Team 1",           
            };

            var team2 = new Team()
            {
                Id = 2,
                Name = "Team 2",
            };

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

            team1.HomeMatches.Add(match1);
            team2.AwayMatches.Add(match2);
            team2.HomeMatches.Add(match2);
            team1.AwayMatches.Add(match2);

            return new List<Team> { team1, team2 };
        }
    }
}
