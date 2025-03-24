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
            catch (ValidationException ex)  // Manejo de errores de validación (400 Bad Request)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    IsSuccess = false,
                    Message = "Error de validación",
                    Errors = ex.Errors,
                });
            }
            catch (UnauthorizedAccessException ex)  // Manejo de errores de autenticación (401 Unauthorized)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)  // Cualquier otro error (500 Internal Server Error)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    IsSuccess = false,
                    Message = "Internal Server Error",
                    Errors = new List<BaseError> { new BaseError { ErrorMessage = ex.Message } }
                });
            }
        }
    }
}
