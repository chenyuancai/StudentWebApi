using Microsoft.Extensions.Configuration;
using StudentWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Service
{
    public interface ILoginService
    {
        /// <summary>
        /// 判断是否登录成功
        /// </summary>
        /// <param name="login">传入登录对象</param>
        /// <returns>登录成功返回true，登陆失败返回false</returns>
        bool Login(Login login);

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="login">传入登录对象</param>
        /// <returns>传回token</returns>
        string GetToken(Login login);
    }
}
