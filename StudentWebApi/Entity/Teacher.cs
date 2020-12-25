using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
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
        public string Password { get; set; }
    }
}
