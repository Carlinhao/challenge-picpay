using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using DesafioPicPay.Core.Interfaces;

namespace DesafioPicPay.Api.Middlewares
{
    [ExcludeFromCodeCoverage]
    public class GlobalErrorHandler(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception error)
            {
                var response = context?.Response;
                response!.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    DomainException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var result = JsonSerializer.Serialize(new { message = error.Message, success = false });
                await response.WriteAsync(result).ConfigureAwait(false);
            }
        }
    }
}
