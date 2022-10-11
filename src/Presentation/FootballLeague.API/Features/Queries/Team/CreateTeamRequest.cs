using FootballLeague.API.Features.Queries.Team.ResponseModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.API.Features.Queries.Team
{
    public class CreateTeamRequest : IRequest<CreateTeamResponseModel>
    {
        [Required]
        [StringLength(100,MinimumLength = 2)]
        public string Name { get; set; }
    }
}
