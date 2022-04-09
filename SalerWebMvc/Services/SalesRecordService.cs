using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalerWebMvc.Data;
using SalerWebMvc.Models;

namespace SalerWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalerWebMvcContext _context;

        public SalesRecordService(SalerWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsyn(DateTime? minDate, DateTime? maxdate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxdate.HasValue)
            {
                result = result.Where(x => x.Date <=maxdate.Value);
            }

            return await result
                            .Include(x => x.Seller)
                            .Include(x => x.Seller.Department)
                            .OrderByDescending(x => x.Date)
                            .ToListAsync();
        }

        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupingAsyn(DateTime? minDate, DateTime? maxdate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxdate.HasValue)
            {
                result = result.Where(x => x.Date <= maxdate.Value);
            }

            return await result
                            .Include(x => x.Seller)
                            .Include(x => x.Seller.Department)
                            .OrderByDescending(x => x.Date)
                            .GroupBy(x => x.Seller.Department)
                            .ToListAsync();
        }

    }
}
