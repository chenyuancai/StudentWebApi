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
        /// 根据userName获取实体对象
        /// configuration:配置文件类
        /// fileds：列
        /// orderstr：排序
        /// PageSize：当前页显示条数
        /// PageIndex：当前页
        /// strWhere：条件
        /// </summary>
        public List<Student> GetStudentListArray(IConfiguration configuration, string fileds, string orderstr, int PageSize, int PageIndex, string strWhere)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);

            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}", strWhere);

            string sql = string.Format("select {0} from `Student` {1} order by {2} limit {3},{4}", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);

            List<Student> students = conn.Query<Student>(sql).ToList;

        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(IConfiguration configuration, string where)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = "select count(1) from `Student`";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
                int i = conn.QuerySingle<int>(sql);
                return i;

            
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
            string sql = @"select `Id`,`Name`,`Birthday` from Student where `UserName` = @UserName";
            Student student = (Student)conn.Query<Student>(sql, new { UserName = name }).FirstOrDefault();
            conn.Close();
            return student;
        }
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
        /// <returns>返回学生对象</returns>
        public Student SelectStudentById(IConfiguration configuration, int id)
        {
            DynamicParameters Parameters = new DynamicParameters();
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`Name`,`Birthday` from `Student` where `ID` = @Id";
            Parameters.Add("Id", id);
            Student student = (Student)conn.Query<Student>(sql, Parameters).FirstOrDefault();
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
    }
}
