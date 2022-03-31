using SalerWebMvc.Data;
using SalerWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalerWebMvc.Services
{
    public class SellerService
    {
        private readonly SalerWebMvcContext _context;
        public SellerService (SalerWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
