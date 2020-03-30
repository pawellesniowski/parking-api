using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarVisitsController : ControllerBase
    {
        private readonly ReportContext _context;

        public CarVisitsController(ReportContext context)
        {
            _context = context;
        }

        // GET: api/CarVisits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarVisit>>> GetCarVisits()
        {
            return await _context.CarVisits.ToListAsync();
        }

        // GET: api/CarVisits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarVisit>> GetCarVisit(Guid id)
        {
            var carVisit = await _context.CarVisits.FindAsync(id);

            if (carVisit == null)
            {
                return NotFound();
            }

            return carVisit;
        }

        // PUT: api/CarVisits/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarVisit(Guid id, CarVisit carVisit)
        {
            if (id != carVisit.Id)
            {
                return BadRequest();
            }

            _context.Entry(carVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarVisitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarVisits/AddCarVisit
        [HttpPost]
        [Route("AddCarVisit")]

        public async Task<ActionResult<CarVisit>> AddCarVisit([FromBody] string carRegistryNumber)
        {
            CarVisit carVisit = new CarVisit { RegistryNumber = carRegistryNumber };
            _context.CarVisits.Add(carVisit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarVisit", new { id = carVisit.Id }, carVisit);
        }

        // POST: api/CarVisits/LeaveCarVisit
        [HttpPost]
        [Route("LeaveCarVisit")]
        public async Task<ActionResult<CarVisit>> LeaveCarVisit([FromBody] string carRegistryNumber)
        {
            CarVisit currentCar = _context.CarVisits.Where((m) => m.RegistryNumber == carRegistryNumber && m.EndTime == null).FirstOrDefault();

            currentCar.EndTime = DateTime.Now;
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("LeaveCarVisit", new { id = currentCar.Id }, currentCar);
        }





        // DELETE: api/CarVisits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarVisit>> DeleteCarVisit(Guid id)
        {
            var carVisit = await _context.CarVisits.FindAsync(id);
            if (carVisit == null)
            {
                return NotFound();
            }

            _context.CarVisits.Remove(carVisit);
            await _context.SaveChangesAsync();

            return carVisit;
        }

        private bool CarVisitExists(Guid id)
        {
            return _context.CarVisits.Any(e => e.Id == id);
        }
    }
}
