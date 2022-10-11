using FootballLeague.API.Features.Commands.Match.ResponseModels;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.API.Features.Commands.Match
{
    public class CreateMatchRequest : IRequest<CreateMatchResponseModel>
    {
        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public int HomeTeamScore { get; set; }

        [Required]
        public int AwayTeamScore { get; set; }
    }
}
