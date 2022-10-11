namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class DeleteMatchResponseModel : BaseResponse<int>
    {
        public DeleteMatchResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteMatchResponseModel(bool isSuccess, string message, int data) : base(isSuccess, message, data)
        {
        }
    }
}
