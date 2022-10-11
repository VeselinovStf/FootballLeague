namespace FootballLeague.API.Features.Queries.Match.ResponseModels
{
    public class GetMatchQueryResponseModel : BaseResponse<MathQueryResponseModel>
    {
        public GetMatchQueryResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetMatchQueryResponseModel(bool isSuccess, string message, MathQueryResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
