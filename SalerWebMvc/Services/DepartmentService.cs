using SalerWebMvc.Data;
using SalerWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalerWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalerWebMvcContext _context;
        public DepartmentService(SalerWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
