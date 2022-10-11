namespace FootballLeague.API.Features.Commands.Team.ResponseModels
{
    public class CreateTeamResponseModel : BaseResponse<TeamResponseModel>
    {
        public CreateTeamResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public CreateTeamResponseModel(bool isSuccess, string message, TeamResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
