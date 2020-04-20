using Microsoft.EntityFrameworkCore;
using SafeSpace.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeSpace.core.Data
{
    public class SafeSpaceContext : DbContext
    {
        public SafeSpaceContext(DbContextOptions<SafeSpaceContext> options) :base(options)
        {

        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserReport> AppUserReports { get; set; }
        public DbSet<ReportItemDefinition> ReportItemDefinitions { get; set; }
        public DbSet<RiskDefinition> RiskDefinitions { get; set; }
        public DbSet<AppUserContact> AppUserContacts { get; set; }
    }
}
