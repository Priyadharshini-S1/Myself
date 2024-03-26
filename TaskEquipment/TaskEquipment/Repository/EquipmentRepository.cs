﻿using System.Data;
using System.Text;
using TaskEquipment.Context;
using TaskEquipment.Contracts;
using TaskEquipment.Models;
using Dapper;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Mvc;
namespace TaskEquipment.Repository
{
    public class EquipmentRepository:IEquipmentRepository
    {
         public static IWebHostEnvironment _environment;
        private readonly DapperContext _dapperContext;
        public EquipmentRepository(DapperContext context)
        {
            _dapperContext = context;
        }
       //get with lazy
      //  public async Task<IEnumerable<Eq>> GetEquipmentl(int start, int rows)
      //  {
      //     var sqlQuery = "SELECT Eqpmt_No, Eqpmt_size, Eqpmt_type, Manuf_date, Equipment_owner, Equipment_photo, Isp_doc FROM EQUIPMENT_DETAILS";
      //     sqlQuery += $" OFFSET {start} ROWS FETCH NEXT {rows} ROWS ONLY";

      //     using (var connection = _dapperContext.CreateConnection())
      //    {
      //       var equipment = await connection.QueryAsync<Eq>(sqlQuery);
      //       return equipment.ToList();
      //    }
      //  }

      public async Task<IEnumerable<Eq>> GetEquipment(int pageNumber, int pageSize, string sortBy, string filterBy)
        {
            // Construct SQL query with pagination, sorting, and filtering
            var query = new StringBuilder();
            query.Append("SELECT Eqpmt_Id,Eqpmt_No, Eqpmt_size, Eqpmt_type, Manuf_date, Equipment_owner, Equipment_photo, Isp_doc ");
            query.Append("FROM EQUIPMENT_DETAILS ");

            if (!string.IsNullOrEmpty(filterBy))
            {
                query.Append($"WHERE {filterBy} ");
            }

            query.Append($"ORDER BY {sortBy} ");
            query.Append($"OFFSET {pageNumber * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY");

            using (var connection = _dapperContext.CreateConnection())
            {
                var equipment = await connection.QueryAsync<Eq>(query.ToString());
                return equipment.ToList();
            }
        }

        public async Task<int> GetTotalCount(string filterBy)
        {
            // Construct SQL query for counting total records with filtering
            var query = "SELECT COUNT(*) FROM EQUIPMENT_DETAILS ";
            if (!string.IsNullOrEmpty(filterBy))
            {
                query += $"WHERE {filterBy} ";
            }

            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        // Other methods...

        // Example of how to use lazy loading with pagination
        public async Task<IEnumerable<Eq>> GetFirstPageOfEquipment(int pageSize, string sortBy, string filterBy)
        {
            const int pageNumber = 0;
            return await GetEquipment(pageNumber, pageSize, sortBy, filterBy);
        }

        public async Task<byte[]> GetEquipmentPhoto(int equipmentId)
        {
         using (var connection = _dapperContext.CreateConnection())
       {
          var sql = "SELECT Equipment_photo FROM EQUIPMENT_DETAILS WHERE Eqpmt_Id = :EquipmentId";
          var parameters = new { EquipmentId = equipmentId };
          return await connection.QueryFirstOrDefaultAsync<byte[]>(sql, parameters);
       }
       }

      public async Task<byte[]> GetInspectionDocument(int equipmentId)
     {
       using (var connection = _dapperContext.CreateConnection())
       {
        var sql = "SELECT Isp_doc FROM EQUIPMENT_DETAILS WHERE Eqpmt_Id = :Eqpmt_Id";
        var parameters = new { EquipmentId = equipmentId };
        return await connection.QueryFirstOrDefaultAsync<byte[]>(sql, parameters);
       }
     }
       public async Task<IEnumerable<Eq>> GetEquipmentSearch(int start, int rows, string searchKey)
      {
         var sqlQuery = "SELECT Eqpmt_No, Eqpmt_size, Eqpmt_type, Manuf_date, Equipment_owner, Equipment_photo, Isp_doc FROM EQUIPMENT_DETAILS";
        if (!string.IsNullOrEmpty(searchKey))
         {
             sqlQuery += $" WHERE Eqpmt_No LIKE '%{searchKey}%' OR Eqpmt_size LIKE '%{searchKey}%' OR Eqpmt_type LIKE '%{searchKey}%' OR Equipment_owner LIKE '%{searchKey}%'";
         }
         sqlQuery += $" OFFSET {start} ROWS FETCH NEXT {rows} ROWS ONLY";
         using (var connection = _dapperContext.CreateConnection())
         {
            var equipment = await connection.QueryAsync<Eq>(sqlQuery);
           return equipment.ToList();
         }
     }
        //get
      public async Task<IEnumerable<Eq>> GetEquipment()
        {
        //    var procedureName = "Equipment_Package.Get_All_Equipment";
           var procedureName = "SELECT * FROM EQUIPMENT_DETAILS";
           using (var connection = _dapperContext.CreateConnection())
              {
               var equipment = await connection.QueryAsync<Eq>(procedureName);
               return equipment.ToList();
              }
        }
       public async Task<IEnumerable<Types>> GetType()
        {
           var procedureName = "SELECT eqptype FROM typee";
           using (var connection = _dapperContext.CreateConnection())
              {
               var equipment = await connection.QueryAsync<Types>(procedureName);
               return equipment.ToList();
              }
        }
        

   //GET BY EQMT NUMBER
     public async Task<Eq> GetEquipmentByNo(string eqpmtno)
       {
           var procedureName = "SELECT * FROM EQUIPMENT_DETAILS WHERE Eqpmt_No= :eqpmtno";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("p_Eqpmt_No", eqpmtno, DbType.String,ParameterDirection.Input);

         using (var connection = _dapperContext.CreateConnection())
        {
        //    var equipment = await connection.QueryFirstOrDefaultAsync<Equipment>(procedureName, parameters, commandType: CommandType.StoredProcedure);
           var equipment = await connection.QueryFirstOrDefaultAsync<Eq>(procedureName,new { eqpmtno });
           return equipment;
        }
        }

   
//ADD
 
  public async Task<Equipment> AddEquipment( Equipment eqpmt)
   {
    byte[] equipmentPhotoData = ConvertFileToByteArray(eqpmt.Equipment_photo);
    byte[] ispDocData = ConvertFileToByteArray(eqpmt.Isp_doc);
        var procedureName = "Equipment_Package.Insert_Equipment";
        var parameters = new DynamicParameters();
        parameters.Add("p_Eqpmt_No", eqpmt.Eqpmt_No, DbType.String);
        parameters.Add("p_Eqpmt_size", eqpmt.Eqpmt_size, DbType.Int32);
        parameters.Add("p_Eqpmt_type", eqpmt.Eqpmt_type, DbType.String);
        parameters.Add("p_Manuf_date", eqpmt.Manuf_date, DbType.Date);
        parameters.Add("p_Equipment_owner", eqpmt.Equipment_owner, DbType.String);
        parameters.Add("p_Equipment_photo", equipmentPhotoData, DbType.Binary);
        parameters.Add("p_Isp_doc", ispDocData, DbType.Binary);

      using (var connection = _dapperContext.CreateConnection())
      {
          await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
          return eqpmt;
     }
   }
    private byte[] ConvertFileToByteArray(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
          
        }
    }


  //  public async Task<string> Post([FromForm] Equipment objfile1)
  //       {
  //           if (objfile1.Equipment_photo.Length > 0)
  //           {
  //               try
  //               {
  //                   if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
  //                   {
  //                       Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");

  //                   }
  //                   using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + objfile1.Equipment_photo.FileName))
  //                   {
  //                       objfile1.Equipment_photo.CopyTo(fileStream);
  //                       fileStream.Flush();
  //                       return "\\uploads\\" + objfile1.Equipment_photo.FileName;
  //                   }
  //               }
  //               catch (Exception ex)
  //               {
  //                   return ex.ToString();
  //               }
  //           }
  //           else
  //           {
  //               return "Unsuccessful";
  //           }

                        
  //               }
  //  public async Task<Equipment> AddEquipment(Equipment eqpmt, [FromForm]IFormFile equipmentPhoto, [FromForm]IFormFile ispDoc)
  //   {
  //           byte[] equipmentPhotoData;
  //           byte[] ispDocData;

  //           using (var memoryStream1 = new MemoryStream())
  //           {
  //               await equipmentPhoto.CopyToAsync(memoryStream1);
  //               equipmentPhotoData = memoryStream1.ToArray();
  //           }

  //           using (var memoryStream2 = new MemoryStream())
  //           {
  //               await ispDoc.CopyToAsync(memoryStream2);
  //               ispDocData = memoryStream2.ToArray();
  //           }

  //           eqpmt.Equipment_photo = equipmentPhotoData;
  //           eqpmt.Isp_doc = ispDocData;

  //           var procedureName = "Equipment_Package.Insert_Equipment";
  //           var parameters = new DynamicParameters();
  //           parameters.Add("p_Eqpmt_No", eqpmt.Eqpmt_No, DbType.String);
  //           parameters.Add("p_Eqpmt_size", eqpmt.Eqpmt_size, DbType.String);
  //           parameters.Add("p_Eqpmt_type", eqpmt.Eqpmt_type, DbType.String);
  //           parameters.Add("p_Manuf_date", eqpmt.Manuf_date, DbType.Date);
  //           parameters.Add("p_Equipment_owner", eqpmt.Equipment_owner, DbType.String);
  //           parameters.Add("p_Equipment_photo", eqpmt.Equipment_photo, DbType.Binary);
  //           parameters.Add("p_Isp_doc", eqpmt.Isp_doc, DbType.Binary);

  //       return eqpmt;
  //   }

   
//EDIT
       public async Task UpdateEquipment(string eqpmtno, Equipment eqpmt)
   {
         byte[] equipmentPhotoData = ConvertFileToByteArrays(eqpmt.Equipment_photo);
         byte[] ispDocData = ConvertFileToByteArrays(eqpmt.Isp_doc);

        var procedureName = "Equipment_Package.Update_Equipment";
        var parameters = new DynamicParameters();
        parameters.Add("p_Eqpmt_No", eqpmt.Eqpmt_No, DbType.String);
        parameters.Add("p_Eqpmt_size", eqpmt.Eqpmt_size, DbType.String);
        parameters.Add("p_Eqpmt_type", eqpmt.Eqpmt_type, DbType.String);
        parameters.Add("p_Manuf_date", eqpmt.Manuf_date, DbType.Date);
        parameters.Add("p_Equipment_owner", eqpmt.Equipment_owner, DbType.String);
        parameters.Add("p_Equipment_photo", equipmentPhotoData, DbType.Binary);
        parameters.Add("p_Isp_doc", ispDocData, DbType.Binary);

        using (var connection = _dapperContext.CreateConnection())
        {
           await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
    private byte[] ConvertFileToByteArrays(IFormFile file)
{
    using (var memoryStream = new MemoryStream())
    {
        file.CopyTo(memoryStream);
        return memoryStream.ToArray();   
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
    
    // public async Task Upload(Equipment eqpmt, IFormFile equipmentPhoto, IFormFile ispDoc)
    // {
    //    byte[] equipmentPhotoData;
    //     byte[] ispDocData;

    //     using (var memoryStream1 = new MemoryStream())
    //     {
    //         await equipmentPhoto.CopyToAsync(memoryStream1);
    //         equipmentPhotoData = memoryStream1.ToArray();
    //     }

    //     using (var memoryStream2 = new MemoryStream())
    //     {
    //         await ispDoc.CopyToAsync(memoryStream2);
    //         ispDocData = memoryStream2.ToArray();
    //     }
    //     eqpmt.Equipment_photo = equipmentPhotoData;
    //     eqpmt.Isp_doc = ispDocData;
       
    // }
}
}
