using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.Context;
using Logistics.Interface;
using Logistics.Models;
using Logistics.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewApiController : ControllerBase
    {
         private readonly Ilogistics _Ilog;
 
        public NewApiController(Ilogistics ilog)
        {
            _Ilog = ilog;
        }

      
       
         [HttpGet]
        public async Task<ActionResult<IEnumerable<Logi>>> GetLogis(int skip, int take, string orderByColumn, bool isAscending)
        {
            try
            {
                var logis = await _Ilog.GetAll(skip, take, orderByColumn, isAscending);
                return Ok(logis);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    
        // public ActionResult<IEnumerable<Logi>>GetDetails()
        // {
        //     var users=_Ilog.GetAll();
        //     return Ok(users);
        // }

        [HttpPost]
        [Route("insert")]
        public IActionResult InsertLogi( Logi logi)
        {
            try
            {
                 _Ilog.Insert(logi);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

          [HttpPut]
          [Route("update")]
        public IActionResult UpdateLogi(Logi logi)
        {
            try
            {
                _Ilog.Update(logi); 
            
                return Ok(); 
            }
            catch (Exception)
            {
                
            
                throw;
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteLogi(int id)
        {
        try
        {
            _Ilog.Delete(id); 
            
            return NoContent(); 
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error"); 
        }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetLogiById(int id)
        {
            try
            {
                var logi = _Ilog.Getbyid(id);
                if (logi == null)
                {
                    return NotFound();
                }

                return Ok(logi); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error"); 
            }
        }
}
}
