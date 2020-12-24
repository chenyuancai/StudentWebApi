using Microsoft.Extensions.Configuration;
using StudentWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Service
{
    public interface IStudentService
    {
        /// <summary>
        /// 获取所有的学生对象
        /// </summary>
        /// <returns>返回所有学生集合</returns>
        List<Student> GetAll();

        /// <summary>
        /// 插入学生
        /// </summary>
        /// <param name="student">传入学生</param>
        /// <returns>返回是否成功</returns>
        Dictionary<string, Object> InsertStudent(Student student);

        /// <summary>
        /// 根据id删除相应学生信息
        /// </summary>
        /// <param name="id">学生id</param>
        /// <returns>返回是否成功</returns>
        Dictionary<string,Object> DeleteStudentById(int id);

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="student">传入学生对象</param>
        /// <returns>返回相关信息</returns>
        Dictionary<string, Object> UpdateStudent(Student student);
    }
}
