namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class UpdateMatchResponseModel : BaseResponse<MatchCommandResponseModel>
    {
        public UpdateMatchResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateMatchResponseModel(bool isSuccess, string message, MatchCommandResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
