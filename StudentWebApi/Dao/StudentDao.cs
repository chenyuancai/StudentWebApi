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
    /// 学生操作
    /// </summary>
    public class StudentDao
    {
        /// <summary>
        /// 链接mysql数据库
        /// </summary>
        private DapperHelper dapper = new DapperHelper();
        /// <summary>
        /// 获取所有的学生信息
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <returns>返回一个学生集合</returns>
        public List<Student> GetAll(IConfiguration configuration)
        {

            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`Name`,`Birthday` from Student";
            List<Student> userList = conn.Query<Student>(sql).ToList();
            conn.Close();
            return userList;
        }
        /// <summary>
        /// 根据用户名查找学生信息
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <param name="name">传入姓名</param>
        /// <returns></returns>
        public Student GetStudentbyName(IConfiguration configuration, string name)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`Name`,`Birthday` from Student where `UserName` =@UserName";
            Student student = (Student)conn.Query<Student>(sql, new { UserName = name });
            conn.Close();
            return student;
        }
    }
}
