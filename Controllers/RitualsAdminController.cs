using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RitualsAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RitualsAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RitualsAdminController : ControllerBase
    {

        private readonly RitualsContext _context;
        private readonly IWebHostEnvironment _hosting;

        public RitualsAdminController(RitualsContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        [HttpGet]
        public async Task<IEnumerable<Matrett>> Get()
        {
            List<Matrett> matrettList = await _context.Matrett.ToListAsync();
            return matrettList;
        }

        [HttpPost]
        [Route("[action]")]
        public void UploadImage(IFormFile file)
        {
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");
            using (var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }

    }

}