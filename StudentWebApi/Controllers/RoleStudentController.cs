using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentWebApi.Entity;
using StudentWebApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("api/v3")]
    [Authorize]
    public class RoleHandleStudentController : ControllerBase
    {
<<<<<<< HEAD
        
=======
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
        private IConfiguration _configuration;
        private IStudentService _studentService;
        public RoleHandleStudentController(IConfiguration configuration, IStudentService studentService)
        {
            this._configuration = configuration;
            this._studentService = studentService;
        }
        /// <summary>
        /// 教师获取所有学生的信息
        /// 需要老师或教导主任的权限
        /// </summary>
        /// <returns>返回一个学生集合</returns>
        [HttpGet]
        [Route("GetAll")]
<<<<<<< HEAD
        [Authorize(Roles = "Teacher")]
        public List<Student> GetAll()
        {
            List <Student>  studentList = this._studentService.GetAll();
            return studentList;
        }
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student">传入学生信息</param>
        /// <returns>返回相关信息</returns>
        [HttpPost]
        [Route("InsertStudent")]
        [Authorize(Roles = "Director")]
        public Dictionary<string,Object> InsertStudent(Student student)
        {
            Dictionary<string, Object> dic = new Dictionary<string, object>();
            Dictionary<string, Object> dic1 = new Dictionary<string, object>();
            string msg = "";
            bool flag = false;
            if (!"".Equals(student.Name))
            {
                dic = this._studentService.InsertStudent(student);
                
            }
            else
            {
                flag = false;
                msg = "请输入学生信息";
                dic1.Add("msg", msg);
                dic1.Add("flag", flag);
                return dic1;
            }

            return dic;
        } 

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id">学生id</param>
        /// <returns>返回相关信息</returns>
        [HttpGet]
        [Route("DeleteById")]
        [Authorize(Roles = "Director")]
        public Dictionary<string, Object> DeleteById(int id)
        {
            Dictionary<string, Object> dic = new Dictionary<string, object>();
            Dictionary<string, Object> dic1 = new Dictionary<string, object>();
            bool flag = false;
            string msg = "";
            if (id != 0)
            {
                dic = this._studentService.DeleteStudentById(id);
            }
            else
            {
                flag = false;
                msg = "请输入id";
                dic1.Add("msg", msg);
                dic1.Add("flag", flag);
                return dic1;
            }

            return dic;
        }
        
        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="student">传入学生对象</param>
        /// <returns>返回先关信息</returns>
        [HttpPost]
        [Route("UpdateStudent")]
        [Authorize(Roles = "Director")]
        public Dictionary<string, Object> UpdateStudent(Student student)
        {
            Dictionary<string, Object> dic = new Dictionary<string, object>();
            Dictionary<string, Object> dic1 = new Dictionary<string, object>();
            bool flag = false;
            string msg = "";
            if(student.Id != 0 && !"".Equals(student.Name))
            {
                dic = this._studentService.UpdateStudent(student);
            }
            else
            {
                flag = false;
                msg = "请输入学生相关信息";
                dic1.Add("msg", msg);
                dic1.Add("flag", flag);
                return dic1;
            }

            return dic;
=======
        [Authorize(Roles = "admin")]
        public List<Student> GetAll()
        {
            List <Student>  studentList = this._studentService.GetAll();
            return studentList;
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
        }
    }
}
