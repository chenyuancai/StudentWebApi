using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
<<<<<<< HEAD
    /// <summary>
    /// 老师实体类
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// 老师id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 老师角色id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 老师姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 老师登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 老师登录密码
        /// </summary>
=======
    public class Teacher
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
        public string Password { get; set; }
    }
}
