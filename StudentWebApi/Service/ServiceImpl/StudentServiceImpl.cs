using Dapper;
using Microsoft.Extensions.Configuration;
using StudentWebApi.Dao;
using StudentWebApi.Entity;
using StudentWebApi.Util.Mysql.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Service.ServiceImpl
{
    public class StudentServiceImpl : IStudentService
    {
        private IConfiguration _configuration;
        public StudentServiceImpl(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        private StudentDao studentDao = new StudentDao();
        /// <summary>
        /// 获取所有的学生对象
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <returns>返回所有学生集合</returns>
        public List<Student> GetAll()
        {
            List<Student> userList = studentDao.GetAll(this._configuration);
            return userList;
        }
    }
}
