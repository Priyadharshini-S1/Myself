using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Interface
{
    public interface Ilogistics
    {
        
         Task<IEnumerable<Logi>> GetAll(int skip, int take, string orderByColumn, bool isAscending);
    
        void Insert(Logi logi);
        void Update(Logi logi);

        void Delete(int Id);

        Logi Getbyid(int Id);



    }
}