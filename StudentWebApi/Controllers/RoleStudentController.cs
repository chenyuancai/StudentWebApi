using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public RoleHandleStudentController()
        {

        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "admin")]
        public string GetAll()
        {
            string roles = "";
            foreach (var aa in HttpContext.User.Claims)
            {
                Console.WriteLine(aa);
                if (aa.Type.Contains("role"))
                {
                    roles = aa.Value;
                }
            }
            return "hello";
        }
    }
}
