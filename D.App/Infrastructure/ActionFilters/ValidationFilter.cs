using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace D.App.Infrastructure.ActionFilters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                        .SelectMany(m => m.Value!.Errors.Select(x => x.ErrorMessage))
                        .ToList();

                var response = new HttpErrorResponse(errors);
                response.Succeeded = false;

                context.Result = new BadRequestObjectResult(response);
                return;
            }

            await next();
        }
    }
}
