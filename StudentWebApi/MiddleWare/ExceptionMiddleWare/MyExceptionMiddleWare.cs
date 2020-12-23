using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.MiddleWare.ExceptionMiddleWare
{
    public class MyExceptionMiddleWare
    {
        public RequestDelegate _next;
        public ILogger<MyExceptionMiddleWare> _logger;

        public MyExceptionMiddleWare(RequestDelegate requestDelegate, ILogger<MyExceptionMiddleWare> logger)
        {
            this._next = requestDelegate;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }catch(Exception e)
            {
                await HandException(httpContext,e);
                this._logger.LogInformation(e.Message);
            }
        }

        public async Task HandException(HttpContext context, Exception e)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/json;charset=utf-8;";
            string error = "";
            error = "抱歉，出错了";
            await context.Response.WriteAsync(error);
        }
    }
}
