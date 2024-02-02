using ClothingDapper.Contracts;
using ClothingDapper.Models;
using ClothingDapper.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingDapper.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClothingController : ControllerBase
    {
        private readonly IClothingRepository _clothingRepository;

        public ClothingController(IClothingRepository clothingRepository)
        {
            _clothingRepository = clothingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClothing()

        {
            try
            {
                var clothings = await _clothingRepository.GetClothing();
                return Ok(clothings);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClothing(int id)

        {
            try
            {
                var clothings = await _clothingRepository.GetClothingById(id);
                return Ok(clothings);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("Multiresult/{id}")]
        public async Task<IActionResult> GetCustomerByClothing(int id)
        {
            try
            {
                var clothings = await _clothingRepository.GetClothingAndCustomer(id);
                return Ok(clothings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClothing(int id, Clothing clothing)
        {
            try
            {
               var cloth = await _clothingRepository.GetClothingById(id);
                if (cloth == null)
                    return NotFound();

                await _clothingRepository.UpdateClothing(id, clothing);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteClothing(int id)
        {

            try
            {
                var companies = await _clothingRepository.GetClothingById(id);
                if (companies == null)
                    return NotFound();
                await _clothingRepository.DeleteClothing(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetEmployeeByCompanyMapping(Clothing clothing)
        {

            try
            {
                var cloth = await _clothingRepository.AddClothing(clothing);
                return Ok(cloth);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetCustomer()

        {
            try
            {
                var customers = await _clothingRepository.GetCustomer();
                return Ok(customers);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCustomers(Customer customer)
        {
          try
            {
                var cloth = await _clothingRepository.AddCustomer(customer);
                await _clothingRepository.UpdateClothingCount(customer.ProductId);
                return Ok(cloth);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("cart")]
        public async Task<IActionResult> AddCart(Cart cart)
        {
            try
            {
                var cloth = await _clothingRepository.AddCart(cart);
               
                return Ok(cloth);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
