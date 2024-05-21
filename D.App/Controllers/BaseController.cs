using D.App.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace D.App.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IActionResult GenericClientError(string message)
        {
            var errors = new List<string>() { message };

            var error = new HttpErrorResponse(errors);

            return BadRequest(error);
        }
    }
}
