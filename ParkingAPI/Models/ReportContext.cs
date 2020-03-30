using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ParkingAPI.Models
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options)
        {
        }

        public DbSet<MonthlyReport> MonthlyReports { get; set; }
        public DbSet<QuarterReport> QuarterReports { get; set; }
        public DbSet<YearlyReport> YearlyReports { get; set; }
    }
}
