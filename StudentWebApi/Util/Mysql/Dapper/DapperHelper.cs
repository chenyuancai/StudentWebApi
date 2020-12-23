using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Util.Mysql.Dapper
{
    public class DapperHelper
    {
        public MySqlConnection MySqlConnection(IConfiguration configuration)
        {
            string mysqlConnectionStr = configuration["Mysql:MySqlConn"];
            var connection = new MySqlConnection(mysqlConnectionStr);
            connection.Open();
            return connection;
        }

       
    }
}
