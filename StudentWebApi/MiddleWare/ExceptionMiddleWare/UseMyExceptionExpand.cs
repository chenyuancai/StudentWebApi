using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.MiddleWare.ExceptionMiddleware
{
    public static class UseMyExceptionExpand
    {
        /// <summary>
        /// 捕获异常
        /// </summary>
        /// <returns>将捕获异常中间件暴露出来</returns>
        public static IApplicationBuilder UseMyException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyExceptionMiddleware>();
        }
    }
}
