using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebApi.Util.Mysql.Dapper
{
    public class DapperHelper
    {
        private IConfiguration _configuration;
        public DapperHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public MySqlConnection MySqlConnection()
        {
            string mysqlConnectionStr = this._configuration["Mysql:MySqlConn"].ToString();
            var connection = new MySqlConnection(mysqlConnectionStr);
            connection.Open();
            return connection;
        }
    }
}
