using System.Collections.Generic;

namespace FootballLeague.API.Features.Queries.Team.ResponseModels
{
    public class GetTeamsQueryResponseModel : BaseResponse<IEnumerable<TeamModel>>
    {
        public GetTeamsQueryResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetTeamsQueryResponseModel(bool isSuccess, string message, IEnumerable<TeamModel> data) : base(isSuccess, message, data)
        {
        }
    }
}
