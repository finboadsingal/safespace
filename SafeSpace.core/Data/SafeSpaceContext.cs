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

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
