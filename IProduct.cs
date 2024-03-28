using MyWebApiProject.Data;
using product.Models;

namespace product.Interface
{
    public interface IProduct
   {
        IEnumerable<Product> GetProduct ();

        public void deleteproduct(int Id);

        public Task<Product> getUserById(int id);  

          public void InsertProduct(Product newProduct);

            public Task<Product> UpdateProduct(Product product);

               public IEnumerable<Product> GetProducts(int skip, int take, string orderByColumn, bool isAscending, string idFilter, string titleFilter, string priceFilter, string authorFilter, string editionFilter, string filterTerm);

               public int GetCount();
   }
           
}