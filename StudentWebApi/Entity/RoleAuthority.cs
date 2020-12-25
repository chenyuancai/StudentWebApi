using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Entity
{
    /// <summary>
    /// 权限点实体类
    /// </summary>
    public class RoleAuthority
    {
        /// <summary>
        /// 权限点id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 权限id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 权限id所拥有的权限点
        /// </summary>
        public int RoleLevel { get; set; }
    }
}
