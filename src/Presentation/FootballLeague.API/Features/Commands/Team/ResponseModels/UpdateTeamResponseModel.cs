namespace FootballLeague.API.Features.Commands.Team.ResponseModels
{
    public class UpdateTeamResponseModel : BaseResponse<TeamResponseModel>
    {
        public UpdateTeamResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public UpdateTeamResponseModel(bool isSuccess, string message, TeamResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
