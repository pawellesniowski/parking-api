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
    [Route("api/MonthlyReports")]
    [ApiController]
    public class MonthlyReportsController : ControllerBase
    {
        private readonly ReportContext _context;

        public MonthlyReportsController(ReportContext context)
        {
            _context = context;
        }

        // GET: api/MonthlyReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthlyReport>>> GetMonthlyReports()
        {
            return await _context.MonthlyReports.ToListAsync();
        }

        // GET: api/MonthlyReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyReport>> GetMonthlyReport(long id)
        {
            var monthlyReport = await _context.MonthlyReports.FindAsync(id);

            if (monthlyReport == null)
            {
                return NotFound();
            }

            return monthlyReport;
        }

        // PUT: api/MonthlyReports/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlyReport(long id, MonthlyReport monthlyReport)
        {
            if (id != monthlyReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(monthlyReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyReportExists(id))
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

        // POST: api/MonthlyReports
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MonthlyReport>> PostMonthlyReport(MonthlyReport monthlyReport)
        {
            _context.MonthlyReports.Add(monthlyReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthlyReport", new { id = monthlyReport.Id }, monthlyReport);
        }

        // DELETE: api/MonthlyReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MonthlyReport>> DeleteMonthlyReport(long id)
        {
            var monthlyReport = await _context.MonthlyReports.FindAsync(id);
            if (monthlyReport == null)
            {
                return NotFound();
            }

            _context.MonthlyReports.Remove(monthlyReport);
            await _context.SaveChangesAsync();

            return monthlyReport;
        }

        private bool MonthlyReportExists(long id)
        {
            return _context.MonthlyReports.Any(e => e.Id == id);
        }
    }
}
