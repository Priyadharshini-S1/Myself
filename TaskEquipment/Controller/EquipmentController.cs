using Microsoft.AspNetCore.Mvc;
using TaskEquipment.Contracts;
using TaskEquipment.Models;

namespace TaskEquipment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetClothing()
        {
            try
            {
                var eqpmt = await _equipmentRepository.GetEquipment();
                return Ok(eqpmt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{eqpmtno}")]
        public async Task<IActionResult> GetEquipment(string eqpmtno)
        {
            try
            {
                var eqpmt = await _equipmentRepository.GetEquipmentByNo(eqpmtno);
                return Ok(eqpmt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{eqpmtno}")]
        public async Task<IActionResult> UpdateEquipment(string eqpmtno, Equipment eqpmt)
        {
            try
            {
                var cloth = await _equipmentRepository.GetEquipmentByNo(eqpmtno);
                if (cloth == null)
                    return NotFound();

                await _equipmentRepository.UpdateEquipment(eqpmtno, eqpmt);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{eqpmtno}")]
        public async Task<IActionResult> DeleteEquipment(string eqpmtno)
        {
            try
            {
                var companies = await _equipmentRepository.GetEquipmentByNo(eqpmtno);
                if (companies == null)
                    return NotFound();
                await _equipmentRepository.DeleteEquipment(eqpmtno);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
