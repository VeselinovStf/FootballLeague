namespace FootballLeague.API.Features.Commands.Team.ResponseModels
{
    public class DeleteTeamResponseModel : BaseResponse<int>
    {
        public DeleteTeamResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public DeleteTeamResponseModel(bool isSuccess, string message, int data) : base(isSuccess, message, data)
        {
        }
    }
}
