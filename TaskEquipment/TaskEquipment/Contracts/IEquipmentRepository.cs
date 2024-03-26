using Microsoft.AspNetCore.Mvc;
using TaskEquipment.Models;
namespace TaskEquipment.Contracts
{
    public interface IEquipmentRepository
    {
          public Task<IEnumerable<Eq>> GetEquipment();
          public Task<IEnumerable<Types>> GetType();
        
          public Task<Eq> GetEquipmentByNo(string eqpmtno);
        //   public Task<Equipment> AddEquipment(Equipment eqpmt);
         public Task UpdateEquipment(string eqpmtno , Equipment eqpmt);
         public Task  DeleteEquipment(string eqpmtno);
         public  Task<Equipment> AddEquipment(Equipment equipment);
        // public Task<IEnumerable<Eq>> GetEquipmentl(int start, int rows);
        public Task<IEnumerable<Eq>> GetEquipmentSearch(int start, int rows,string searchKey);
        Task<IEnumerable<Eq>> GetEquipment(int pageNumber, int pageSize, string sortBy, string filterBy);
        Task<int> GetTotalCount(string filterBy);
        Task<IEnumerable<Eq>> GetFirstPageOfEquipment(int pageSize, string sortBy, string filterBy);
   
        Task<byte[]> GetEquipmentPhoto(int equipmentId);
    Task<byte[]> GetInspectionDocument(int equipmentId);
    }
}
