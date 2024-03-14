using TaskEquipment.Models;
namespace TaskEquipment.Contracts
{
    public interface IEquipmentRepository
    {
          public Task<IEnumerable<Equipment>> GetEquipment();
          public Task<Equipment> GetEquipmentByNo(string eqpmtno);
          public Task<Equipment> AddEquipment(Equipment eqpmt);
         public Task UpdateEquipment(string eqpmtno , Equipment eqpmt);
         public Task  DeleteEquipment(string eqpmtno);
    }
}
