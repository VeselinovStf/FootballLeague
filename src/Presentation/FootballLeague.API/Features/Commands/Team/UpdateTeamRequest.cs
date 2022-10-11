using FootballLeague.API.Features.Commands.Team.ResponseModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.API.Features.Commands.Team
{
    public class UpdateTeamRequest : IRequest<UpdateTeamResponseModel>
    {
        [Required]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
