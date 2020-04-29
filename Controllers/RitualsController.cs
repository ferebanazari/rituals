using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RitualsAPI.Models;
using Microsoft.AspNetCore.Hosting;

namespace RitualsAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RitualsController : ControllerBase
    {

        private readonly RitualsContext _context;
        private readonly IWebHostEnvironment _hosting;

        public RitualsController(RitualsContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        [HttpGet]
        public async Task<IEnumerable<Matrett>> Get()
        {
            List<Matrett> MatrettList = await _context.Matrett.ToListAsync();
            return MatrettList;
        }

        [HttpGet("{id}")]
        public async Task<Matrett> Get(int id)
        {
            Matrett chosenMatrett = await _context.Matrett.FirstOrDefaultAsync(matrett => matrett.Id == id);
            return chosenMatrett;
        }

        [HttpPost]
        public async Task<Matrett> Post(Matrett newMatrett)
        {
            _context.Matrett.Add(newMatrett);
            await _context.SaveChangesAsync();
            return newMatrett;
        }

        [HttpPut]
        public async Task<Matrett> Put(Matrett changeMatrett)
        {
            _context.Update(changeMatrett);
            await _context.SaveChangesAsync();
            return changeMatrett;
        }

        [HttpDelete("{id}")]
        public async Task<Matrett> Delete(int id)
        {
            Matrett deleteMatrett = await _context.Matrett.FirstOrDefaultAsync(matrett => matrett.Id == id);
            _context.Matrett.Remove(deleteMatrett);
            return deleteMatrett;
        }

    }

}