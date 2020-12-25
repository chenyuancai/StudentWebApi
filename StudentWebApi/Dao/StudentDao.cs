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
<<<<<<< HEAD
            string sql = @"select `Id`,`Name`,`Birthday` from Student where `UserName` = @UserName";
=======
            string sql = @"select `Id`,`Name`,`Birthday` from Student where `UserName` =@UserName";
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
            Student student = (Student)conn.Query<Student>(sql, new { UserName = name });
            conn.Close();
            return student;
        }
<<<<<<< HEAD
        /// <summary>
        /// 插入学生信息
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <param name="student">传入学生对象</param>
        /// <returns>返回是否成功</returns>
        public bool InsertStudent(IConfiguration configuration, Student student)
        {
            bool flag = false;
            int con = 0;
            DynamicParameters Parameters = new DynamicParameters();
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"insert into `Student` (`Name`,`Birthday`) values (@Name,@Birthday)";
            Parameters.Add("Name",student.Name);
            Parameters.Add("Birthday", student.Birthday);
            con = conn.Execute(sql, Parameters);
            conn.Close();
            if(con == 1)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 根据id删除相应学生信息
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <param name="id">学生id</param>
        /// <returns>返回是否成功</returns>
        public bool DeleteStudentById(IConfiguration configuration, int id)
        {
            bool flag = false;
            int con = 0;
            DynamicParameters Parameters = new DynamicParameters();
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"delete from `Student` where `ID` = @Id";
            Parameters.Add("Id",id);
            con = conn.Execute(sql,Parameters);
            conn.Close();
            if (con == 1)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 根据id查询学生信息
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <param name="id">学生id</param>
        /// <returns>返回相关信息</returns>
        public List<Student> SelectStudentById(IConfiguration configuration, int id)
        {
            DynamicParameters Parameters = new DynamicParameters();
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`Name`,`Birthday` from `Student` where `ID` = @Id";
            Parameters.Add("Id", id);
            List<Student> student = (List<Student>)conn.Query<Student>(sql, Parameters);
            conn.Close();
            return student;
        }
        /// <summary>
        /// 更新学生
        /// </summary>
        /// <param name="configuration">传入配置</param>
        /// <param name="student">传入学生对象</param>
        /// <returns>返回是否更新成功</returns>
        public bool UpdateStudent(IConfiguration configuration, Student student)
        {
            bool flag = false;
            int con = 0;
            DynamicParameters Parameters = new DynamicParameters();
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"update `Student` set `Name` = @Name,`Birthday` = @Birthday where `Id` = @ID";
            Parameters.Add("Name",student.Name);
            Parameters.Add("Birthday", student.Birthday);
            Parameters.Add("Id", student.Id);
            con = conn.Execute(sql,Parameters);
            if (con == 1)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
=======
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
    }
}
