using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalerWebMvc.Models;

namespace SalerWebMvc.Data
{
    public class SalerWebMvcContext : DbContext
    {
        public SalerWebMvcContext (DbContextOptions<SalerWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<SalerWebMvc.Models.Department> Department { get; set; }
    }
}
