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
    }
}
