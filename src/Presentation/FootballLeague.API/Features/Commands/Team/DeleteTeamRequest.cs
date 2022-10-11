using FootballLeague.API.Features.Commands.Team.ResponseModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.API.Features.Commands.Team
{
    public class DeleteTeamRequest : IRequest<DeleteTeamResponseModel>
    {
        [Required]
        public int TeamId { get; set; }
    }
}
