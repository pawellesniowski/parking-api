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
    [Route("api/YearlyReports")]
    [ApiController]
    public class YearlyReportsController : ControllerBase
    {
        private readonly ReportContext _context;

        public YearlyReportsController(ReportContext context)
        {
            _context = context;
        }

        // GET: api/YearlyReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearlyReport>>> GetYearlyReports()
        {
            return await _context.YearlyReports.ToListAsync();
        }

        // GET: api/YearlyReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YearlyReport>> GetYearlyReport(long id)
        {
            var yearlyReport = await _context.YearlyReports.FindAsync(id);

            if (yearlyReport == null)
            {
                return NotFound();
            }

            return yearlyReport;
        }

        // PUT: api/YearlyReports/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearlyReport(long id, YearlyReport yearlyReport)
        {
            if (id != yearlyReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(yearlyReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearlyReportExists(id))
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

        // POST: api/YearlyReports
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<YearlyReport>> PostYearlyReport(YearlyReport yearlyReport)
        {
            _context.YearlyReports.Add(yearlyReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYearlyReport", new { id = yearlyReport.Id }, yearlyReport);
        }

        // DELETE: api/YearlyReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YearlyReport>> DeleteYearlyReport(long id)
        {
            var yearlyReport = await _context.YearlyReports.FindAsync(id);
            if (yearlyReport == null)
            {
                return NotFound();
            }

            _context.YearlyReports.Remove(yearlyReport);
            await _context.SaveChangesAsync();

            return yearlyReport;
        }

        private bool YearlyReportExists(long id)
        {
            return _context.YearlyReports.Any(e => e.Id == id);
        }
    }
}
