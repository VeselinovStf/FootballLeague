using System.Collections.Generic;

namespace FootballLeague.API.Features.Team.Queries.ResponseModels
{
    public class GetTeamsRankingQueryResponseModel : BaseResponse<IEnumerable<TeamsRankingResponseModel>>
    {
        public GetTeamsRankingQueryResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetTeamsRankingQueryResponseModel(bool isSuccess, string message, IEnumerable<TeamsRankingResponseModel> data) : base(isSuccess, message, data)
        {
        }
    }
}
