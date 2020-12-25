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
<<<<<<< HEAD
=======
        /// <param name="configuration">传入配置</param>
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
        /// <returns>返回所有学生集合</returns>
        public List<Student> GetAll()
        {
            List<Student> userList = studentDao.GetAll(this._configuration);
            return userList;
<<<<<<< HEAD
        }

        /// <summary>
        /// 插入学生
        /// </summary>
        /// <param name="student">传入学生</param>
        /// <returns>返回是否成功</returns>
        public Dictionary<string, Object> InsertStudent(Student student)
        {
            bool flag = false;
            string msg = "";
            Dictionary<string, Object> dic = new Dictionary<string, object>();
            if (!"".Equals(student.Name))
            {
                flag = studentDao.InsertStudent(this._configuration, student);
                if (flag)
                {
                    msg = "添加成功";
                }
                else
                {
                    msg = "添加失败";
                }
            }
            else
            {
                flag = false;
                msg = "请输入学生相关信息";
            }
            dic.Add("flag",flag);
            dic.Add("msg",msg);
            return dic;
        }
        /// <summary>
        /// 根据id删除相应学生信息
        /// </summary>
        /// <param name="id">学生id</param>
        /// <returns>返回相关信息</returns>
        public Dictionary<string, Object> DeleteStudentById(int id)
        {
            Dictionary<string, Object> dic = new Dictionary<string, object>();
            bool flag = false;
            string msg = "";
            if (id != 0)
            {
                List<Student> student = studentDao.SelectStudentById(this._configuration, id);
                if(student.Count != 0)
                {
                    if (!"".Equals(student[0].Name))
                    {
                        flag = studentDao.DeleteStudentById(this._configuration, id);
                        if (flag)
                        {
                            msg = "删除成功";
                        }
                        else
                        {
                            msg = "删除失败";
                        }
                    }
                    else
                    {
                        msg = "查无此人";
                        flag = false;
                    }
                }
                else
                {
                    msg = "查无此人";
                    flag = false;
                }
                
            }
            else
            {
                msg = "请输入id";
                flag = false;
            }
            dic.Add("flag", flag);
            dic.Add("msg", msg);
            return dic;
        }

        public Dictionary<string, Object> UpdateStudent(Student student)
        {
            Dictionary<string, Object> dic = new Dictionary<string, object>();
            bool flag = false;
            string msg = "";
            if (!"".Equals(student.Name))
            {
                List<Student> students = studentDao.SelectStudentById(this._configuration, student.Id);
                if (students.Count != 0)
                {
                    flag = studentDao.UpdateStudent(this._configuration, student);
                    if (flag)
                    {
                        msg = "更新成功";
                    }
                    else
                    {
                        flag = false;
                        msg = "更新失败";
                    }
                }
                else
                {
                    flag = false;
                    msg = "查无此人";
                }
            }
            else
            {
                flag = false;
                msg = "查无此人";
            }
            dic.Add("flag", flag);
            dic.Add("msg", msg);

            return dic;
=======
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
        }
    }
}
