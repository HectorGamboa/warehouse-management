using System.Text.Json;
using WH.Application.Commons.Bases;
using WH.Application.Commons.Exceptions;

namespace WH.Api.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    IsSuccess=false,
                    Message = "Error de validacion",
                    Errors = ex.Errors,
                }); 
            }
        }
    }
}
