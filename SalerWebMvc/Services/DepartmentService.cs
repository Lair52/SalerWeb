using SalerWebMvc.Data;
using SalerWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalerWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalerWebMvcContext _context;
        public DepartmentService(SalerWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
