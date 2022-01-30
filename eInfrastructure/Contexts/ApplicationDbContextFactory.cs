using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInfrastructure.Contexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseMySql("server=localhost;uid=vicram10;pwd=@@.Vm2530723.--;database=bd_eRestaurant");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
