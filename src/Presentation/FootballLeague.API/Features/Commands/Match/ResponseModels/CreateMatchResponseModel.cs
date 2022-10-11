namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class CreateMatchResponseModel : BaseResponse<CreateMatchCommandResponseModel>
    {
        public CreateMatchResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public CreateMatchResponseModel(bool isSuccess, string message, CreateMatchCommandResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
