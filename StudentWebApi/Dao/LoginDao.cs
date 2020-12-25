using Dapper;
using Microsoft.Extensions.Configuration;
using StudentWebApi.Entity;
using StudentWebApi.Util.Mysql.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Dao
{
    /// <summary>
    /// 登录操作
    /// </summary>
    public class LoginDao
    {
        /// <summary>
        /// 链接mysql数据库
        /// </summary>
        private DapperHelper dapper = new DapperHelper();

        /// <summary>
        /// 根据用户名查找学生信息
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <param name="name">传入姓名</param>
        /// <returns></returns>
<<<<<<< HEAD
        public List<Teacher> GetTeacherbyName(IConfiguration configuration, string name)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`RoleId`,`Name`,`LoginName`,`Password` from `Teacher` where `LoginName` =@LoginName";
            List<Teacher> teacher = (List<Teacher>)conn.Query<Teacher>(sql, new { LoginName = name });
=======
        public Teacher GetTeacherbyName(IConfiguration configuration, string name)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`RoleId`,`Name`,`LoginName`,`Password` from `Teacher` where `LoginName` =@LoginName";
            Teacher teacher = (Teacher)conn.Query<Teacher>(sql, new { LoginName = name });
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
            conn.Close();
            return teacher;
        }

    }
}
