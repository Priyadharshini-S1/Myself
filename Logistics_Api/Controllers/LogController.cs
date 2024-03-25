using Logistics_Api.Contract;
using Logistics_Api.Models;
using Logistics_Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistics_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly ILog _log;
        public LogController(ILog log)
        {
          _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            try
            {
                var companies = await _log.GetDetails();
                return Ok(companies);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var companies = await _log.GetById(id);
                return Ok(companies);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertLogistics")]
        public async Task<IActionResult> Insert(Logistics logistics)
        {
            try
            {
                var res = await _log.Insert(logistics);
                return Ok(res);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut]
        [Route("UpdateLogistics")]
        public async Task<IActionResult> Update(Logistics logistics , int id)
        {
            try
            {
                var res = await _log.Update(logistics,id);
                return Ok(res);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete]
        [Route("DeleteLogistics")]
        public async Task<IActionResult> Delete( int id)
        {
            try
            {
                var res = await _log.Delete(id);
                return Ok(res);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Track")]
        public async Task<IActionResult> Tracking(int id)
        {
            try
            {
                var companies = await _log.Tracking(id);
                return Ok(companies);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("Pack")]
        public async Task<IActionResult> Package(int id)
        {
            try
            {
                var companies = await _log.Package(id);
                return Ok(companies);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
