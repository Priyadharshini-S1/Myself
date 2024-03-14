using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;
namespace TaskEquipment.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public IDbConnection CreateConnection() => new OracleConnection(_connectionString);
    }
}
