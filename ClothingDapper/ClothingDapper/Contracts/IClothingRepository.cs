using ClothingDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothingDapper.Contracts
{
    public interface IClothingRepository
    {
        public Task<IEnumerable<Clothing>> GetClothing();
        public Task<IEnumerable<Customer>> GetCustomer();
        public Task<Clothing> GetClothingById(int id);

        public Task<Clothing> GetClothingAndCustomer(int id);

        public Task UpdateClothing(int id, Clothing clothing);
        public Task DeleteClothing(int id);

        public Task<Clothing> AddClothing(Clothing clothing);

        public Task<Customer> AddCustomer(Customer customer);
        public Task<Cart> AddCart( Cart cart);
        Task UpdateClothingCount(int id);
    }
}
