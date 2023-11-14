using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Dapper_Web_Api.Models.DapperContext
{
    public class DapperContext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}

