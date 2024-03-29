﻿using SportPourTous.Infrastructure.Exceptions;
using System.Net;

namespace SportPourTous.Web.Middleware
{
    public class GlobalErrorHandlerMiddleware(RequestDelegate next)
    {

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; 

            if (exception is ReservationNotFoundException) code = HttpStatusCode.NotFound;

            var result = new { error = exception.Message, code = code.ToString() };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result.ToString());
        }
    }
}
