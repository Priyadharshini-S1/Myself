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
        
    }
}
