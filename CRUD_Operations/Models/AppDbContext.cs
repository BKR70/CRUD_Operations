using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD_Operations.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> ProductStorage { get; set; }
    }
}
