using ClothingDapper.context;
using ClothingDapper.Contracts;
using ClothingDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;
using System.Runtime.InteropServices;

namespace ClothingDapper.Repository
{
    public class ClothingRepository:IClothingRepository
    {
        private readonly DapperContext _dapperContext;
        public ClothingRepository(DapperContext context)
        {
            _dapperContext = context;
        }

        public async Task<IEnumerable<Clothing>> GetClothing()
        {
            var query = "select * from clothings";
            using (var connection = _dapperContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<Clothing>(query);
                return companies.ToList();
            }

        }
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            var query = "select * from customers";
            using (var connection = _dapperContext.CreateConnection())
            {
                var customers = await connection.QueryAsync<Customer>(query);
                return customers.ToList();
            }

        }

        public async Task<Clothing> GetClothingById(int id)
        {
            var query = "select * from clothings where productid=@id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var cloth = await connection.QueryFirstOrDefaultAsync<Clothing>(query, new { id });
                return cloth;
            }
        }
        public async Task<Clothing> GetClothingAndCustomer(int id)
        {
            var query = "select * from clothings where productid=@id;" +
                "select * from customers where productid=@id";
            using (var connection = _dapperContext.CreateConnection())
            using (var multiresult = await connection.QueryMultipleAsync(query, new { id }))
            {
                var clothing = await multiresult.ReadSingleOrDefaultAsync<Clothing>();
                if (clothing != null)
                {
                    clothing.Customers = (await multiresult.ReadAsync<Customer>()).ToList();
                    return clothing;
                }
                else
                {
                    return null;
                }
            }
        }
        //insert
        public async Task<Clothing> AddClothing(Clothing cloth)
        {
            var procedureName = "usp_insert";
            var parameters = new DynamicParameters();
            parameters.Add("name", cloth.Name, DbType.String);
            parameters.Add("description", cloth.Description, DbType.String);
            parameters.Add("price", cloth.price, DbType.Int32);
            parameters.Add("size", cloth.size, DbType.String);
            parameters.Add("color", cloth.color, DbType.String);
            parameters.Add("gender", cloth.gender, DbType.String);
            parameters.Add("instock", cloth.InStock, DbType.Boolean);
            parameters.Add("count", cloth.count, DbType.Int32);
            parameters.Add("addeddate", cloth.AddedDate, DbType.Date);

            //all fields are required
            if (
            string.IsNullOrWhiteSpace(cloth.Name) ||
            string.IsNullOrWhiteSpace(cloth.Description) ||
            string.IsNullOrWhiteSpace(cloth.size) ||
            string.IsNullOrWhiteSpace(cloth.color) ||
            string.IsNullOrWhiteSpace(cloth.gender))
            {
                throw new ArgumentException("All fields are required.");
            }
   
            // Check if count is zero, set instock to false
                if (cloth.count == 0)
            {
                parameters.Add("instock", false, DbType.Boolean);
            }
          
            if(string.IsNullOrEmpty(cloth.gender)||
              !(cloth.gender.ToUpper() == "F" ||
                  cloth.gender.ToUpper() == "M" ||
                  cloth.gender.ToUpper() == "FEMALE" ||
                  cloth.gender.ToUpper() == "MALE"))
            {
                throw new ArgumentException("Gender must be Male or Female");
            }
            //validating size
            if (string.IsNullOrEmpty(cloth.size) ||
                    !(cloth.size.ToUpper() == "S" ||
                      cloth.size.ToUpper() == "M" ||
                      cloth.size.ToUpper() == "L" ||
                      cloth.size.ToUpper() == "XL"))
            {
                throw new ArgumentException("Size must be 'S', 'M', 'L', or 'XL'");
            }
            //year
            int currentYear = DateTime.Now.Year;
            if (cloth.AddedDate.Year < currentYear || cloth.AddedDate.Year > currentYear)
            {
                throw new ArgumentException("Manufacture year must be the current year");
            }
            using (var connection = _dapperContext.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return cloth;
            }
        }
        //add customers
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var procedureName = "usp_insertc";
            var parameters = new DynamicParameters();
           // parameters.Add("customerid", customer.CustomerId, DbType.String);
            parameters.Add("customername",customer.CustomerName, DbType.String);
            parameters.Add("customerage", customer.CustomerAge, DbType.Int32);
            parameters.Add("productid", customer.ProductId, DbType.String);
            parameters.Add("count", customer.count, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return customer;
            }
        }

        //delete 
        public async Task DeleteClothing(int id)
        {
            var query = "delete from clothings where productid=@id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
                
            }
        }

        public async Task UpdateClothing(int id, Clothing clothing)
        {
            var procedureName = "usp_update";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32); 
            parameters.Add("@name", clothing.Name, DbType.String);
            parameters.Add("@description", clothing.Description, DbType.String);
            parameters.Add("@price", clothing.price, DbType.Int32);
            parameters.Add("@size", clothing.size, DbType.String);
            parameters.Add("@color", clothing.color, DbType.String);
            parameters.Add("@gender", clothing.gender, DbType.String);
            parameters.Add("@instock", clothing.InStock, DbType.Boolean);
            parameters.Add("@count", clothing.count, DbType.Int32);
            parameters.Add("@addeddate", clothing.AddedDate, DbType.Date);
            //all fields are required
            if (
            string.IsNullOrWhiteSpace(clothing.Name) ||
            string.IsNullOrWhiteSpace(clothing.Description) ||
            string.IsNullOrWhiteSpace(clothing.size) ||
            string.IsNullOrWhiteSpace(clothing.color) ||
            string.IsNullOrWhiteSpace(clothing.gender))
            {
                throw new ArgumentException("All fields are required.");
            }

            // Check if count is zero, set instock to false
            if (clothing.count == 0)
            {
                parameters.Add("instock", false, DbType.Boolean);
            }

            if (string.IsNullOrEmpty(clothing.gender) ||
              !(clothing.gender.ToUpper() == "F" ||
                  clothing.gender.ToUpper() == "M" ||
                  clothing.gender.ToUpper() == "FEMALE" ||
                  clothing.gender.ToUpper() == "MALE"))
            {
                throw new ArgumentException("Gender must be Male or Female");
            }
            //validating size
            if (string.IsNullOrEmpty(clothing.size) ||
                    !(clothing.size.ToUpper() == "S" ||
                      clothing.size.ToUpper() == "M" ||
                      clothing.size.ToUpper() == "L" ||
                      clothing.size.ToUpper() == "XL"))
            {
                throw new ArgumentException("Size must be 'S', 'M', 'L', or 'XL'");
            }
            //year
            int currentYear = DateTime.Now.Year;
            if (clothing.AddedDate.Year < currentYear || clothing.AddedDate.Year > currentYear)
            {
                throw new ArgumentException("Manufacture year must be the current year");
            }
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task UpdateClothingCount(int id)
        {
            var procedureName = "UpdateClothingCount";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id, DbType.Int32);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        //user add products to cart
        public async Task<Cart> AddCart( Cart cart)
        {
            var procedureName = "usp_insertcart";
            var parameters = new DynamicParameters();
            parameters.Add("@productid", cart.productId, DbType.Int32); 
            parameters.Add("@count", cart.count, DbType.Int32);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var updatedCart = await connection.QueryFirstOrDefaultAsync<Cart>("SELECT * FROM Cart WHERE ProductId = @ProductId", new { cart.productId });
                return updatedCart;
            }
        }
        

    }


    }

