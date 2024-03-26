using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskEquipment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ValuesController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class Fileupload
        {
            public IFormFile files
            {
                get;
                set;
            }
        }
     
        [HttpPost]
        public async Task<string> Post([FromForm] Fileupload objfile)
        {
            if (objfile.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");


                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + objfile.files.FileName))
                    {
                        objfile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\uploads\\" + objfile.files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }

                        
                }
            }
        }
    