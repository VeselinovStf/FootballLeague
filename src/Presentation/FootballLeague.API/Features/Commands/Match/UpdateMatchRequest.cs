using FootballLeague.API.Features.Commands.Match.ResponseModels;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.API.Features.Commands.Match
{
    public class UpdateMatchRequest : IRequest<UpdateMatchResponseModel>
    {
        [Required]
        public int MatchId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int HomeTeamScore { get; set; }

        [Required]
        public int AwayTeamScore { get; set; }
    }
}
