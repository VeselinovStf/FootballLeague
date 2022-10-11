namespace FootballLeague.API.Features.Queries.Team.ResponseModels
{
    public class GetTeamQueryResponseModel : BaseResponse<TeamModel>
    {
        public GetTeamQueryResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetTeamQueryResponseModel(bool isSuccess, string message, TeamModel data) : base(isSuccess, message, data)
        {
        }
    }
}
