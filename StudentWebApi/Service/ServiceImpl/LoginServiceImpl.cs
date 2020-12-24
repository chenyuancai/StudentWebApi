using Microsoft.Extensions.Configuration;
using StudentWebApi.Dao;
using StudentWebApi.Entity;
using StudentWebApi.JWT.JwtService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Service.ServiceImpl
{
    public class LoginServiceImpl : ILoginService
    {
        private IConfiguration _configuration;
        private IGetTokenService _getTokenService;
        private LoginDao loginDao = new LoginDao();
        private RoleDao roleDao = new RoleDao();
        public LoginServiceImpl(IGetTokenService getTokenService, IConfiguration configuration)
        {
            this._getTokenService = getTokenService;
            this._configuration = configuration;
        }

        /// <summary>
        /// 判断是否登录成功
        /// </summary>
        /// <param name="login">传入登录对象</param>
        /// <returns>登录成功返回true，登陆失败返回false</returns>
        public bool Login(Login login)
        {
            Boolean flag = false;
            if (!"".Equals(login.UserName))
            {
                List<Teacher> teacher = loginDao.GetTeacherbyName(this._configuration, login.UserName);
                if(teacher.Count == 1)
                {
                    if (!"".Equals(teacher[0].Id))
                    {
                        if (login.UserName.Equals(teacher[0].LoginName) && login.Password.Equals(teacher[0].Password))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="login">传入登录对象</param>
        /// <returns>传回token</returns>
        public string GetToken(Login login)
        {
            string role = "";
            if (!"".Equals(login.UserName))
            {
                List<Teacher> teacher = loginDao.GetTeacherbyName(this._configuration, login.UserName);
                if (teacher.Count == 1)
                {
                    List<Role> ro = roleDao.GetRole(this._configuration,teacher[0].RoleId);
                    if(ro.Count == 1)
                    {
                        if (!"".Equals(ro[0].Roles))
                        {
                            role = ro[0].Roles;
                        }
                    }
                }
            }
            string token = this._getTokenService.Token(login.UserName, role);
            return token;
        }
    }
}
