using System.Collections.Generic;

namespace FootballLeague.API.Features.Queries.Team.ResponseModels
{
    public class GetTeamsPlayedMatchesQueryResponseModel : BaseResponse<IEnumerable<TeamPlayedMatchesResponseModel>>
    {
        public GetTeamsPlayedMatchesQueryResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetTeamsPlayedMatchesQueryResponseModel(bool isSuccess, string message, IEnumerable<TeamPlayedMatchesResponseModel> data) : base(isSuccess, message, data)
        {
        }

    }
}
