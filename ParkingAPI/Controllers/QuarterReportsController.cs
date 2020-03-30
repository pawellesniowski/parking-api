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
    [Route("api/QuarterReports")]
    [ApiController]
    public class QuarterReportsController : ControllerBase
    {
        private readonly ReportContext _context;

        public QuarterReportsController(ReportContext context)
        {
            _context = context;
        }

        // GET: api/QuarterReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuarterReport>>> GetQuarterReports()
        {
            return await _context.QuarterReports.ToListAsync();
        }

        // GET: api/QuarterReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuarterReport>> GetQuarterReport(long id)
        {
            var quarterReport = await _context.QuarterReports.FindAsync(id);

            if (quarterReport == null)
            {
                return NotFound();
            }

            return quarterReport;
        }

        // PUT: api/QuarterReports/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuarterReport(long id, QuarterReport quarterReport)
        {
            if (id != quarterReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(quarterReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuarterReportExists(id))
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

        // POST: api/QuarterReports
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<QuarterReport>> PostQuarterReport(QuarterReport quarterReport)
        {
            _context.QuarterReports.Add(quarterReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuarterReport", new { id = quarterReport.Id }, quarterReport);
        }

        // DELETE: api/QuarterReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuarterReport>> DeleteQuarterReport(long id)
        {
            var quarterReport = await _context.QuarterReports.FindAsync(id);
            if (quarterReport == null)
            {
                return NotFound();
            }

            _context.QuarterReports.Remove(quarterReport);
            await _context.SaveChangesAsync();

            return quarterReport;
        }

        private bool QuarterReportExists(long id)
        {
            return _context.QuarterReports.Any(e => e.Id == id);
        }
    }
}
