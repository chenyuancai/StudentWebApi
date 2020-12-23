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
    public class RoleHandleStudentController : ControllerBase
    {
        private IConfiguration _configuration;
        private IStudentService _studentService;
        public RoleHandleStudentController(IConfiguration configuration, IStudentService studentService)
        {
            this._configuration = configuration;
            this._studentService = studentService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "admin")]
        public List<Student> GetAll()
        {
            List <Student>  studentList = this._studentService.GetAll();
            return studentList;
        }
    }
}
