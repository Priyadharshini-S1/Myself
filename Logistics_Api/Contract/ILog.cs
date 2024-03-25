using Logistics_Api.Models;

namespace Logistics_Api.Contract
{
    public interface ILog
    {

        public Task<IEnumerable<Logistics>> GetDetails();

        public Task<Logistics> GetById(int id);

        Task<int> Insert(Logistics logistics);

        Task<int> Update(Logistics logistics,int id);

        Task<int> Delete(int id);

        Task<Track> Tracking(int id);

        Task<Package> Package(int id);

        

        

        

    }
}
