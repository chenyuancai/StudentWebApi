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
<<<<<<< HEAD
=======
        /// <param name="configuration">把配置传进去</param>
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
        /// <param name="login">传入登录对象</param>
        /// <returns>登录成功返回true，登陆失败返回false</returns>
        public bool Login(Login login)
        {
            Boolean flag = false;
            if (!"".Equals(login.UserName))
            {
<<<<<<< HEAD
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
=======
                Teacher teacher = loginDao.GetTeacherbyName(this._configuration, login.UserName);
                if (!"".Equals(teacher.Id))
                {
                    if(login.UserName.Equals(teacher.LoginName) && login.Password.Equals(teacher.Password))
                    {
                        flag = true;
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
                    }
                    else
                    {
                        flag = false;
                    }
                }
<<<<<<< HEAD
=======
                else
                {
                    flag = false;
                }
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
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
<<<<<<< HEAD
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
=======
                Teacher teacher = loginDao.GetTeacherbyName(this._configuration, login.UserName);
                if (!"".Equals(teacher.Id))
                {
                    Role ro = roleDao.GetRole(this._configuration,teacher.RoleId);
                    if (!"".Equals(ro.Roles))
                    {
                        role = ro.Roles;
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
                    }
                }
            }
            string token = this._getTokenService.Token(login.UserName, role);
            return token;
        }
    }
}
