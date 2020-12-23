using Dapper;
using Microsoft.Extensions.Configuration;
using StudentWebApi.Entity;
using StudentWebApi.Util.Mysql.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Dao
{
    /// <summary>
    /// 权限操作
    /// </summary>
    public class RoleDao
    {
        /// <summary>
        /// 链接mysql数据库
        /// </summary>
        private DapperHelper dapper = new DapperHelper();
        public Role GetRole(IConfiguration configuration, int id)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`Roles` from `Role` where `Id` =@Id";
            Role role = (Role)conn.Query<Role>(sql, new { Id = id });
            conn.Close();
            return role;
        }
    }
}
