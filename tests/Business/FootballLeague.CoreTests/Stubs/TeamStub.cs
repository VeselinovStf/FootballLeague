using FootballLeague.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.CoreTests.Stubs
{
    public static class TeamStub
    {
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
    }
}
