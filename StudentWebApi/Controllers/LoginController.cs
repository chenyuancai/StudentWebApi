using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Entity;
using StudentWebApi.JWT.JwtService;
using StudentWebApi.Models;
using StudentWebApi.Service;
using StudentWebApi.Util.Enum;
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
        private ILoginService _loginService;
        private Dictionary<String, Object> dic = new Dictionary<string, object>();
        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginModel">一个传入登录对象：UserName：登录名，Password：密码</param>
        /// <returns>返回一个状态以及token：msg：登录是否成功，token：token</returns>
        [HttpPost]
        [Route("Login")]
        public Dictionary<string,Object> Login(LoginModel loginModel)
        {
            string msg = "";
            string token = "";
            string username = loginModel.UserName;
            string password = loginModel.Password;
            Login lo = new Login();
            if(!"".Equals(username) && !"".Equals(password))
            {
                lo.UserName = username;
                lo.Password = password;
                bool flag = this._loginService.Login(lo);
                if (flag)
                {
                    token = this._loginService.GetToken(lo);
                    msg = "登录成功";
                }
                else
                {
                    msg = "登录失败";
                }
            }
            string role = Enum.GetName(typeof(EnumRoleAuthority), 2);
            dic.Add("msg", msg);
            dic.Add("token", token);
            return dic;
        }
    }
}
