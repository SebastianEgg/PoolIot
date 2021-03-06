using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQPoolIot.Logic.DataContext
{
    class BloggingContextFactory : IDesignTimeDbContextFactory<SnQPoolIotDbContext>
    {
        public SnQPoolIotDbContext CreateDbContext(string[] args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<SnQPoolIotDbContext>();
            optionsBuilder
                .UseSqlite(configuration["ConnectionStrings:DefaultConnection"]);

            return new SnQPoolIotDbContext();
        }
    }
}
