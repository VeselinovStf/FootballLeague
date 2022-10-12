namespace FootballLeague.API.Features.Commands.Auth.ResponseModel
{
    public class AuthenticationResponseModel : BaseResponse<AccessResponseModel>
    {
        public AuthenticationResponseModel(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public AuthenticationResponseModel(bool isSuccess, string message, AccessResponseModel data) : base(isSuccess, message, data)
        {
        }
    }
}
