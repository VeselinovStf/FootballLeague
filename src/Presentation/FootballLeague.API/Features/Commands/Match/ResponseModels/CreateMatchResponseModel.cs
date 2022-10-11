namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class CreateMatchResponseModel : BaseResponse<MatchResponseModel>
    {
        public CreateMatchResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public CreateMatchResponseModel(bool isSuccess, string message, MatchResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
