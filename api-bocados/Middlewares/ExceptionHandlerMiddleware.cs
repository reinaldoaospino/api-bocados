using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using api_bocados.Models;
using Domain.Exceptions;

namespace api_bocados.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ExistingCategoryException ex)
            {
                await HandleException(context.Response, ex, HttpStatusCode.BadRequest, 2);
            }
            catch (ApplicationException ex)
            {

                await HandleException(context.Response, ex, HttpStatusCode.BadRequest, 1);
            }

            catch (Exception ex)
            {
                await HandleException(context.Response, ex, HttpStatusCode.InternalServerError, 1);
            }
        }

        private async Task HandleException(HttpResponse response, Exception ex, HttpStatusCode statusCode, int errorCode)
        {
            var error = JsonConvert.SerializeObject(new ErrorModel(ex.Message, errorCode));

            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            await response.WriteAsync(error);
        }
    }
}
