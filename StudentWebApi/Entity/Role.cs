using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
    /// <summary>
    /// 角色实体类
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Roles { get; set; }
    }
}
