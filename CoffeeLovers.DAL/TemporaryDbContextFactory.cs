using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLovers.DAL
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<CoffeeDbContext>
    {
        public CoffeeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoffeeDbContext>();
            optionsBuilder.UseSqlServer("server=WTIN05201542L\\SQLEXPRESS;database=CoffeeLovers;Integrated Security=SSPI;");

            return new CoffeeDbContext(optionsBuilder.Options);
        }
    }
}
