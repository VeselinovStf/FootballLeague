using FootballLeague.API.Features.Queries.Match.ResponseModels;

namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class UpdateMatchResponseModel : BaseResponse<MatchCommandResponseModel>
    {
        public UpdateMatchResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateMatchResponseModel(bool isSuccess, string message, MathQueryResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
