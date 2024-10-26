using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Entities;
using Talabat.repostry.Data.Configration;
using Talabat.repostry.SpecficationEvaluator;
using Talapat.Core.Reposters.Interfaces;
using Talapat.Core.Specifications;

namespace Talabat.repostry.Repostries
{
    public class GenaricReopistry<T> : IGenaricReopistres<T> where T : BaseEntety
    {
        private readonly StoreDbcontext _context;
        public GenaricReopistry(StoreDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAdync()
        {
            if(typeof(T)==typeof(Product))
            {
                return ( IEnumerable < T >)await _context.Product.Include(p=>p.Brand).Include(p=>p.Category).ToListAsync();
            }
         return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAdync(ISpecifications<T>spec)
        {
          return await SpecifactionEvaluator<T>.GetQuery(_context.Set<T>(),spec).ToListAsync();


        }

        public async Task<T?> GetAsync(int id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await _context.Product.Where(p=>p.Id==id).Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync() as T;
            }
            return await _context.Set<T>().FindAsync();
        }

        public Task<T?> GetWithSpecAsync(ISpecifications<T>spec)
        {
            return  SpecifactionEvaluator<T>.GetQuery(_context.Set<T>(), spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecifactionEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }

    }
}
