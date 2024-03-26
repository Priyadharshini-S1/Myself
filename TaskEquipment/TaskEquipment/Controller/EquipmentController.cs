using Microsoft.AspNetCore.Mvc;
using TaskEquipment.Contracts;
using TaskEquipment.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static TaskEquipment.Controller.ValuesController;
using TaskEquipment.Repository;

namespace TaskEquipment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public static IWebHostEnvironment _environment;
        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetEquipment()
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
    //     [HttpGet("g")]
    //    public async Task<IActionResult> GetEquipment(int start, int rows)
    //  {
    //       try
    //        {
    //           var eqpmt = await _equipmentRepository.GetEquipmentl(start, rows);
    //           return Ok(eqpmt);
    //        }
    //       catch (Exception ex)
    //        {
    //          return StatusCode(500, ex.Message);
    //        }
    //  }

      [HttpGet("f")]
     public async Task<IActionResult> GetEquipmentSearch(int start, int rows, string searchKey = "")
   {
        try
       {
          var eqpmt = await _equipmentRepository.GetEquipmentSearch(start, rows, searchKey);
          return Ok(eqpmt);
       }
       catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
   } 

        [HttpGet("get")]
        public async Task<IActionResult> GetType()
        {
            try
            {
                var eqpmt = await _equipmentRepository.GetType();
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
        public async Task<IActionResult> UpdateEquipment(string eqpmtno, [FromForm]Equipment eqpmt)
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

        [HttpPost]
        public async Task<IActionResult> AddEquipmen([FromForm]Equipment eqpmt)
        {
           try
           {
               var eqpmts = await _equipmentRepository.AddEquipment(eqpmt);
               return Ok(eqpmts);
           }
           catch (Exception ex)
           {
               return StatusCode(500, ex.Message);
           }
        }
        [HttpGet("i")]
        public async Task<ActionResult<IEnumerable<Eq>>> GetEquipment(
            [FromQuery] int pageNumber = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Eqpmt_No",
            [FromQuery] string filterBy = "")
        {
            try
            {
                var equipment = await _equipmentRepository.GetEquipment(pageNumber, pageSize, sortBy, filterBy);
                return Ok(equipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("total-count")]
        public async Task<ActionResult<int>> GetTotalCount([FromQuery] string filterBy = "")
        {
            try
            {
                var totalCount = await _equipmentRepository.GetTotalCount(filterBy);
                return Ok(totalCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
         [HttpGet("first-page")]
        public async Task<ActionResult<IEnumerable<Eq>>> GetFirstPageOfEquipment(
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Eqpmt_No",
            [FromQuery] string filterBy = "")
        {
            try
            {
                var firstPageEquipment = await _equipmentRepository.GetFirstPageOfEquipment(pageSize, sortBy, filterBy);
                return Ok(firstPageEquipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
          [HttpGet("photo/{equipmentId}")]
        public async Task<ActionResult<byte[]>> GetEquipmentPhoto(int equipmentId)
        {
            var photo = await _equipmentRepository.GetEquipmentPhoto(equipmentId);
            if (photo == null)
            {
                return NotFound();
            }
            return photo;
        }

        [HttpGet("inspection-document/{equipmentId}")]
        public async Task<ActionResult<byte[]>> GetInspectionDocument(int equipmentId)
        {
            var document = await _equipmentRepository.GetInspectionDocument(equipmentId);
            if (document == null)
            {
                return NotFound();
            }
            return document;
        }
      
// public string UploadFile([FromForm] Equipment equipmentPhoto)
// {
//     if (equipmentPhoto.Equipment_photo.Length > 0)
//     {
//         try
//         {
//             if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
//             {
//                 Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
//             }

//             string fileName = Guid.NewGuid().ToString() + Path.GetExtension(equipmentPhoto.Equipment_photo.FileName);
//             string filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

//             using (FileStream fileStream = System.IO.File.Create(filePath))
//             {
//                 equipmentPhoto.Equipment_photo.CopyTo(fileStream);
//                 fileStream.Flush();
//                 return "/uploads/" + fileName;
//             }
//         }
//         catch (Exception ex)
//         {
//             return ex.ToString();
//         }
//     }
//     else
//     {
//         return "No file uploaded.";
//     }
// }

            // [HttpPost]
            // public async Task<IActionResult> AddEquipment(Equipment eqpmt, [FromForm] Equipment equipmentPhoto, [FromForm] Equipment ispDoc)
            // {
            //     try
            //     {
            //         if (equipmentPhoto != null)
            //         {
            //             string filePath = UploadFile(equipmentPhoto);
            //             eqpmt.Equipment_photo = filePath;
            //         }
            //         if (ispDoc != null)
            //         {
            //             string filePath = UploadFile(equipmentPhoto);
            //             eqpmt.Isp_doc = filePath;
            //         }


            //         var eqpmts = await _equipmentRepository.AddEquipment(eqpmt);
            //         return Ok(eqpmts);
            //     }
            //     catch (Exception ex)
            //     {
            //         return StatusCode(500, ex.Message);
            //     }
            // }
        //      [HttpPost("i")]
        // public async Task<string> Post([FromForm] Equipment objfile1)
        // {
        //     if (objfile1.Equipment_photo.Length > 0)
        //     {
        //         try
        //         {
        //             if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
        //             {
        //                 Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");

        //             }
        //             using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + objfile1.Equipment_photo.FileName))
        //             {
        //                 objfile1.Equipment_photo.CopyTo(fileStream);
        //                 fileStream.Flush();
        //                 return "\\uploads\\" + objfile1.Equipment_photo.FileName;
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             return ex.ToString();
        //         }
        //     }
        //     else
        //     {
        //         return "Unsuccessful";
        //     }

                        
        //         }
//     [HttpPost]
// public async Task<IActionResult> AddEquipment(Equipment equipment, [FromForm] Equipment objfile1, [FromForm] Equipment objfile2)
// {
//     try
//     {
//         // First, handle file upload
//         string filePath = await Post(objfile1);
//         string filePath1 = await Post(objfile2);
//         // Check if file upload was successful
//         if (!string.IsNullOrEmpty(filePath))
//         {
//             // Set the equipment photo path
//            equipment.Equipment_photo = objfile1.Equipment_photo;

//             // Add equipment
//             var addedEquipment = await _equipmentRepository.AddEquipment(equipment,objfile1,objfile2);
            
//             // Return the added equipment
//             return Ok(addedEquipment);
//         }
//         else
//         {
//             // If file upload was unsuccessful
//             return BadRequest("File upload unsuccessful");
//         }
//     }
//     catch (Exception ex)
//     {
//         return StatusCode(500, ex.Message);
//     }
// }


        }
    }
