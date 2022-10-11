using System.Collections.Generic;

namespace FootballLeague.API.Features.Queries.Match.ResponseModels
{
    public class GetMatchesQueryResponseModel : BaseResponse<IEnumerable<MathQueryResponseModel>>
    {
        public GetMatchesQueryResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetMatchesQueryResponseModel(bool isSuccess, string message, IEnumerable<MathQueryResponseModel> data) : base(isSuccess, message, data)
        {
        }
    }
}
