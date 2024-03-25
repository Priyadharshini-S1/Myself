using Dapper;
using Logistics_Api.Context;
using Logistics_Api.Contract;
using Logistics_Api.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;

namespace Logistics_Api.Repository
{
    public class LogRepo : ILog
    {
        private readonly LogContext _context;
        public LogRepo(LogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Logistics>> GetDetails()
        {
            var query = "select * from Logistics";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Logistics>(query);
                return companies.ToList();
            }
        }

        public async Task<Logistics> GetById(int id)
        {
            var query = "select * from Logistics where Id=@id";
            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QueryFirstOrDefaultAsync<Logistics>(query, new { id });
                return company;
            }
        }



        public async Task<int> Insert(Logistics logistics)
        {
            var procedureName = "insert_data";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Product_name", logistics.Product_Name, DbType.String, ParameterDirection.Input);
                parameters.Add("@Quantity", logistics.Quantity, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Owner_name", logistics.Ownername, DbType.String, ParameterDirection.Input);
                parameters.Add("@Package_id", logistics.Package_Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Packed_date", logistics.Packed_Date, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@Expected_date", logistics.Expected_Date, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@Price", logistics.Price, DbType.Currency, ParameterDirection.Input);
                parameters.Add("@Delivery_status", logistics.Delivery_Status, DbType.String, ParameterDirection.Input);
                parameters.Add("@From_location", logistics.From_Location, DbType.String, ParameterDirection.Input);
                parameters.Add("@To_location", logistics.To_Location, DbType.String, ParameterDirection.Input);

                var affectedRows = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return affectedRows;
            }
        }




        public async Task<int> Update(Logistics logistics, int id)
        {
            var procedureName = "update_data";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Product_name", logistics.Product_Name, DbType.String, ParameterDirection.Input);
                parameters.Add("@Quantity", logistics.Quantity, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Owner_name", logistics.Ownername, DbType.String, ParameterDirection.Input);
                parameters.Add("@Package_id", logistics.Package_Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Packed_Date", logistics.Packed_Date, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@Expected_Date", logistics.Expected_Date, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@Price", logistics.Price, DbType.Currency, ParameterDirection.Input);
                parameters.Add("@Delivery_status", logistics.Delivery_Status, DbType.String, ParameterDirection.Input);
                parameters.Add("@From_location", logistics.From_Location, DbType.String, ParameterDirection.Input);
                parameters.Add("@To_location", logistics.To_Location, DbType.String, ParameterDirection.Input);

                var affectedRows = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var procedureName = "delete_sp";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);


                var affectedRows = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return affectedRows;
            }
        }

        public async Task<Track> Tracking(int id)
        {
            var procedureName = "tracking";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);

                var logistics = await connection.QueryFirstOrDefaultAsync<Track>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return logistics;
            }
        }

        public async Task<Package> Package(int id)
        {
            var procedureName = "getbypaack";

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);

                var logistics = await connection.QueryFirstOrDefaultAsync<Package>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return logistics;
            }
        }




    }
    }








