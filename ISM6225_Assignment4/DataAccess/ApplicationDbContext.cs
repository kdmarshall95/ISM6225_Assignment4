using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static ISM6225_Assignment4.Models.EF_Models;

namespace ISM6225_Assignment4.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<KeyStats> Stats { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}
