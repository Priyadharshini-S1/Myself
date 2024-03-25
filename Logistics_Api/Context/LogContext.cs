using Microsoft.Data.SqlClient;
using System.Data;

namespace Logistics_Api.Context
{
    public class LogContext
    {
        private readonly IConfiguration _config;
        private readonly string _ConString;


        public LogContext(IConfiguration config)

        {
            _config = config;
            _ConString = _config.GetConnectionString("con");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_ConString);
    }
}
