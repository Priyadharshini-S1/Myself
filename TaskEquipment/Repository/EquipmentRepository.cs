using System.Data;
using TaskEquipment.Context;
using TaskEquipment.Contracts;
using TaskEquipment.Models;
using Dapper;
using Oracle.ManagedDataAccess.Client;
namespace TaskEquipment.Repository
{
    public class EquipmentRepository:IEquipmentRepository
    {
        private readonly DapperContext _dapperContext;
        public EquipmentRepository(DapperContext context)
        {
            _dapperContext = context;
        }
        //create
        public async Task<IEnumerable<Equipment>> GetEquipment()
        {
            var query = "select * from Equipment_Details";
            using (var connection = _dapperContext.CreateConnection())
            {
                var equipment = await connection.QueryAsync<Equipment>(query);
                return equipment.ToList();
            }
        }

        //by eqpmt number
        public async Task<Equipment> GetEquipmentByNo(string eqpmtno)
        {
            var query = "select * from Equipment_Details where Eqpmt_No=@Eqpmt_No";
            using (var connection = _dapperContext.CreateConnection())
            {
                var equipment = await connection.QueryFirstOrDefaultAsync<Equipment>(query, new { eqpmtno });
                return equipment;
            }
        }
        //add
        public async Task<Equipment> AddEquipment(Equipment eqpmt)
        {
            var procedureName = "usp_insert";
            var parameters = new DynamicParameters();
            parameters.Add("Eqpmt_No", eqpmt.Eqpmt_No, DbType.String);
            parameters.Add("Eqpmt_size", eqpmt.Eqpmt_size, DbType.String);
            parameters.Add("Eqpmt_type", eqpmt.Eqpmt_type, DbType.Int32);
            parameters.Add("Manuf_date", eqpmt.Manuf_date, DbType.String);
            parameters.Add("Equipment_owner", eqpmt.Equipment_owner, DbType.String);
            parameters.Add("Equipment_photo", eqpmt.Equipment_photo, DbType.String);
            parameters.Add("Isp_doc", eqpmt.Isp_doc, DbType.String);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return eqpmt;
            }
        }
        //edit
        public async Task UpdateEquipment(string eqpmtno, Equipment eqpmt)
        {
            var procedureName = "usp_update";
            var parameters = new DynamicParameters();
            parameters.Add("Eqpmt_No", eqpmtno, DbType.String);
            parameters.Add("Eqpmt_size", eqpmt.Eqpmt_size, DbType.String);
            parameters.Add("Eqpmt_type", eqpmt.Eqpmt_type, DbType.Int32);
            parameters.Add("Manuf_date", eqpmt.Manuf_date, DbType.String);
            parameters.Add("Equipment_owner", eqpmt.Equipment_owner, DbType.String);
            parameters.Add("Equipment_photo", eqpmt.Equipment_photo, DbType.String);
            parameters.Add("Isp_doc", eqpmt.Isp_doc, DbType.String);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        //delete
        public async Task DeleteEquipment(string eqpmtno)
        {
            var query = "delete from Equipment_Details where Eqpmt_No=@Eqpmt_No";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { eqpmtno });
            }
        }
    }
}
