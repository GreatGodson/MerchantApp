using MerchantApp.Application.Common;
using Microsoft.AspNetCore.Mvc;


namespace MerchantApp.API.Controller;

[ApiController]
public abstract class BaseControllerV1 : ControllerBase
{
    // protected string LoggedInUserEmail => User.FindFirstValue(ClaimTypes.Email) ?? throw new FormatException("Active user email not encrypted in token");
    // protected string LoggedInUserId => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new FormatException("Active user id not encrypted in token");

    protected IActionResult HandleResponse<T>(ApiResponse<T> response)
    {
        if (response == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Response is null." });
        }

        return response.StatusCode switch
        {
            ResponseCodes.Ok => Ok(response),
            ResponseCodes.NotFound => NotFound(response),
            ResponseCodes.BadRequest => BadRequest(response),
            ResponseCodes.Unauthorized => Unauthorized(response),
            ResponseCodes.InternalServer => StatusCode(StatusCodes.Status500InternalServerError, response),
            _ => StatusCode(StatusCodes.Status500InternalServerError, response)
        };
    }
}

