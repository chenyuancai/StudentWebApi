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
<<<<<<< HEAD
        public List<Role> GetRole(IConfiguration configuration, int id)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`Roles` from `Role` where `Id` =@Id";
            List<Role> role = (List<Role>)conn.Query<Role>(sql, new { Id = id });
=======
        public Role GetRole(IConfiguration configuration, int id)
        {
            IDbConnection conn = dapper.MySqlConnection(configuration);
            string sql = @"select `Id`,`Roles` from `Role` where `Id` =@Id";
            Role role = (Role)conn.Query<Role>(sql, new { Id = id });
>>>>>>> 7a42374069fa5623529170d705a428704a0f046e
            conn.Close();
            return role;
        }
    }
}
