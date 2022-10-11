
using FootballLeague.API.Features;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Extensions
{
    public static class ApiResponseExtensions
    {
        public static ObjectResult ValidateResponseModel<T>(BaseResponse<T> model)
        {
            if (model.IsSuccess)
            {
                return new OkObjectResult(model);
            }

            return new BadRequestObjectResult(model);
        }
    }
}
