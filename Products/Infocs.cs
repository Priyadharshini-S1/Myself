using System;
using Microsoft.EntityFrameworkCore;
using MyWebApiProject.Data;
using product.Interface;
using product.Models;

namespace product.Products
{
    public class Infocs : IProduct
    {
          private readonly AppDbContext appsContext;
        public Infocs(AppDbContext _context)
        {
            appsContext=_context;
        }

        public IEnumerable<Product> GetProduct()
        {
           
           return appsContext.Products.ToList();
        }

          public void deleteproduct(int Id)
        {
            try{
                    var product=appsContext.Products.Find(Id);
                    appsContext.Products.Remove(product);
                    appsContext.SaveChanges();
            }
            catch(System.Exception ex){
                throw ex;
            }
        }
          public async Task<Product> getUserById(int id)
        {
        try
        {
            var Product = await appsContext.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (Product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            return Product;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        }
 
   public void InsertProduct(Product newProduct)
       {
           appsContext.Products.Add(newProduct);
           appsContext.SaveChanges();
        }
public async Task<Product> UpdateProduct(Product product)
    {
 
    using (var transaction = appsContext.Database.BeginTransaction())
    {
        try
        {
           
            appsContext.Entry(product).State = EntityState.Modified;
            await appsContext.SaveChangesAsync();
            transaction.Commit();
            return product;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
     }

        public IEnumerable<Product> GetProducts(int skip, int take, string? orderByColumn, bool isAscending, string? idFilter, string? titleFilter, string? priceFilter, string? authorFilter, string? editionFilter, string? filterTerm)
        {
             IQueryable<Product> query = appsContext.Products;

             if (!string.IsNullOrEmpty(filterTerm))
    {
        query = query.Where(u =>
            u.Id.ToString().Contains(filterTerm) ||
            u.Title.Contains(filterTerm) ||
            u.Price.ToString().Contains(filterTerm) ||
            u.Author.Contains(filterTerm)||
            u.Edition.ToString().Contains(filterTerm)
        );
    }

  if (!string.IsNullOrEmpty(idFilter))
    {
        query = query.Where(u => u.Id.ToString().Contains(idFilter));
    }
 
    if (!string.IsNullOrEmpty(titleFilter))
    {
        query = query.Where(u => u.Title.Contains(titleFilter));
    }
 
    if (!string.IsNullOrEmpty(priceFilter))
    {
        query = query.Where(u => u.Price.ToString().Contains(priceFilter));
    }
 
    if (!string.IsNullOrEmpty(authorFilter))
    {
        query = query.Where(u => u.Author.Contains(authorFilter));
    }
     if (!string.IsNullOrEmpty(editionFilter))
    {
        query = query.Where(u => u.Edition.ToString().Contains(editionFilter));
    }


    switch (orderByColumn)
    {
      case "id":
            query = isAscending ? query.OrderBy(u => u.Id) : query.OrderByDescending(u => u.Id);
            break;
        case "title":
            query = isAscending ? query.OrderBy(u => u.Title) : query.OrderByDescending(u => u.Title);
            break;
        case "price":
            query = isAscending ? query.OrderBy(u => u.Price) : query.OrderByDescending(u => u.Price);
            break;
        case "author":
            query = isAscending ? query.OrderBy(u => u.Author) : query.OrderByDescending(u => u.Author);
            break;
        case "edition":
            query = isAscending ? query.OrderBy(u => u.Edition) : query.OrderByDescending(u => u.Edition);
            break;
        default:
            break;
    }
 
    return query.Skip(skip).Take(take).ToList();
}
public int GetCount()
{
    return appsContext.Products.Count();
}
        }

    }