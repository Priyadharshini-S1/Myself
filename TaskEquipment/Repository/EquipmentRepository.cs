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
        //    var procedureName = "Equipment_Package.Get_All_Equipment";
           var procedureName = "SELECT * FROM EQUIPMENT_DETAILS";
           using (var connection = _dapperContext.CreateConnection())
              {
               var equipment = await connection.QueryAsync<Equipment>(procedureName);
               return equipment.ToList();
              }
        }
 //GET BY EQMT NUMBER
     public async Task<Equipment> GetEquipmentByNo(string eqpmtno)
       {
           var procedureName = "SELECT * FROM EQUIPMENT_DETAILS WHERE Eqpmt_No= :eqpmtno";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("p_Eqpmt_No", eqpmtno, DbType.String,ParameterDirection.Input);

         using (var connection = _dapperContext.CreateConnection())
        {
        //    var equipment = await connection.QueryFirstOrDefaultAsync<Equipment>(procedureName, parameters, commandType: CommandType.StoredProcedure);
           var equipment = await connection.QueryFirstOrDefaultAsync<Equipment>(procedureName,new { eqpmtno });
           return equipment;
        }
        }
//ADD
       public async Task<Equipment> AddEquipment(Equipment eqpmt)
   {
        var procedureName = "Equipment_Package.Insert_Equipment";
        var parameters = new DynamicParameters();
        parameters.Add("p_Eqpmt_No", eqpmt.Eqpmt_No, DbType.String);
        parameters.Add("p_Eqpmt_size", eqpmt.Eqpmt_size, DbType.String);
        parameters.Add("p_Eqpmt_type", eqpmt.Eqpmt_type, DbType.String);
        parameters.Add("p_Manuf_date", eqpmt.Manuf_date, DbType.Date);
        parameters.Add("p_Equipment_owner", eqpmt.Equipment_owner, DbType.String);
        parameters.Add("p_Equipment_photo", eqpmt.Equipment_photo, DbType.String);
        parameters.Add("p_Isp_doc", eqpmt.Isp_doc, DbType.String);

      using (var connection = _dapperContext.CreateConnection())
      {
          await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
          return eqpmt;
     }
   }
//EDIT
       public async Task UpdateEquipment(string eqpmtno, Equipment eqpmt)
   {
        var procedureName = "Equipment_Package.Update_Equipment";
        var parameters = new DynamicParameters();
        parameters.Add("p_Eqpmt_No", eqpmt.Eqpmt_No, DbType.String);
        parameters.Add("p_Eqpmt_size", eqpmt.Eqpmt_size, DbType.String);
        parameters.Add("p_Eqpmt_type", eqpmt.Eqpmt_type, DbType.String);
        parameters.Add("p_Manuf_date", eqpmt.Manuf_date, DbType.Date);
        parameters.Add("p_Equipment_owner", eqpmt.Equipment_owner, DbType.String);
        parameters.Add("p_Equipment_photo", eqpmt.Equipment_photo, DbType.String);
        parameters.Add("p_Isp_doc", eqpmt.Isp_doc, DbType.String);

        using (var connection = _dapperContext.CreateConnection())
        {
           await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }

//DELETE
      public async Task DeleteEquipment(string eqpmtno)
    {
        var procedureName = "Equipment_Package.Delete_Equipment";
        var parameters = new DynamicParameters();
        parameters.Add("p_Eqpmt_No", eqpmtno, DbType.String);
        using (var connection = _dapperContext.CreateConnection())
       {
           await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
       }
    }
    
}
}
