using CustomSolutionsTemplate.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSolutionsTemplate.DataAccess
{
    public class CustomSolutionsTemplateDbContext : DbContext
    {
        public CustomSolutionsTemplateDbContext(DbContextOptions<CustomSolutionsTemplateDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}