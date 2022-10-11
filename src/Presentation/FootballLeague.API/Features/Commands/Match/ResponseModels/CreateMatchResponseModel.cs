namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class CreateMatchResponseModel : BaseResponse<MatchCommandResponseModel>
    {
        public CreateMatchResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public CreateMatchResponseModel(bool isSuccess, string message, MatchCommandResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
