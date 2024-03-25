using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.Context;
using Logistics.Interface;
using Logistics.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Services
{
    public class LogServices:Ilogistics
    {
        private readonly LogDbContext _logDbContext;

        public LogServices(LogDbContext logDbContext)
    {
        _logDbContext=logDbContext;
    }
      public async Task<IEnumerable<Logi>> GetAll(int skip, int take, string orderByColumn, bool isAscending)
        {
            IQueryable<Logi> query = _logDbContext.logisticsef;

            switch (orderByColumn)
            {
                case "product_Name":
                    query = isAscending ? query.OrderBy(u => u.Product_Name) : query.OrderByDescending(u => u.Product_Name);
                    break;
                case "quantity":
                    query = isAscending ? query.OrderBy(u => u.Quantity) : query.OrderByDescending(u => u.Quantity);
                    break;
                case "ownername":
                    query = isAscending ? query.OrderBy(u => u.Ownername) : query.OrderByDescending(u => u.Ownername);
                    break;
                case "package_Id":
                    query = isAscending ? query.OrderBy(u => u.Package_Id) : query.OrderByDescending(u => u.Package_Id);
                    break;
                case "packed_Date":
                    query = isAscending ? query.OrderBy(u => u.Packed_Date) : query.OrderByDescending(u => u.Packed_Date);
                    break;
                case "expected_Date":
                    query = isAscending ? query.OrderBy(u => u.Expected_Date) : query.OrderByDescending(u => u.Expected_Date);
                    break;
                case "price":
                    query = isAscending ? query.OrderBy(u => u.Price) : query.OrderByDescending(u => u.Price);
                    break;
                case "delivery_Status":
                    query = isAscending ? query.OrderBy(u => u.Delivery_Status) : query.OrderByDescending(u => u.Delivery_Status);
                    break;
                case "from_Location":
                    query = isAscending ? query.OrderBy(u => u.From_Location) : query.OrderByDescending(u => u.From_Location);
                    break;
                case "to_Location":
                    query = isAscending ? query.OrderBy(u => u.To_Location) : query.OrderByDescending(u => u.To_Location);
                    break;
                default:
                    throw new ArgumentException("Invalid orderByColumn");
            }

            return await query.Skip(skip).Take(take).ToListAsync();
        }

         public void Insert(Logi logi)
    {
       using (var transaction = _logDbContext.Database.BeginTransaction() )
        {
            try{
                _logDbContext.Add(logi);
                _logDbContext.SaveChanges();
                transaction.Commit();
               
            }
            catch(System.Exception){
                transaction.Rollback();
                throw;
            }
          
        }
    }

    public void Update (Logi logi)
    {
        using (var transaction = _logDbContext.Database.BeginTransaction() )
        {
            try{
                _logDbContext.Entry(logi).State=EntityState.Modified;
                _logDbContext.SaveChanges();
                transaction.Commit();
               
            }
            catch(System.Exception){
                transaction.Rollback();
                throw;
            }
          
        }
    }

       public void Delete (int Id)
       {
        try
        {
            var logdelete =_logDbContext.logisticsef.Find(Id);
            _logDbContext.logisticsef.Remove(logdelete);
            _logDbContext.SaveChanges();

        }
        catch(System.Exception ex)
        {
            throw ex;
            

        }
       }

       public Logi Getbyid(int Id)
       {
        try{
            return _logDbContext.logisticsef.Find(Id);
        }

        catch(System.Exception ex)
        {
            throw ex;
        }
       }

      
    }
    }
   
