using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Util.Enum
{
    /// <summary>
    /// SelectAll查看全部信息权限
    /// SelectOne查看详细信息权限
    /// Insert插入权限
    /// Delete删除权限
    /// Update更新权限
    /// </summary>
    public enum EnumRoleAuthority
    {
            SelectAll = 1,
            SelectOne = 2,
            Insert = 3,
            Delete = 4,
            Update = 5
        
    }
}
