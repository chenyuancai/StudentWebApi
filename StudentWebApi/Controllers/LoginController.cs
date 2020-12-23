using Microsoft.AspNetCore.Mvc;
using StudentWebApi.JWT.JwtService;
using StudentWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class LoginController : ControllerBase
    {
        private IGetTokenService _getTokenService;
        public LoginController(IGetTokenService getTokenService)
        {
            this._getTokenService = getTokenService;
        }

        [HttpPost]
        [Route("Login")]
        public string Login(LoginModel loginModel)
        {
            string msg = "";
            string username = loginModel.UserName;
            string password = loginModel.Password;
            Console.WriteLine($"用户名为：{username}");
            Console.WriteLine($"密码为：{password}");
            string token = this._getTokenService.Token(username,"admin");

            return token;
        }
    }
}
