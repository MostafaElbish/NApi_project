using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Entities;
using Talapat.Core.Specifications;

namespace Talapat.Core.Reposters.Interfaces
{
    public interface IGenaricReopistres< T> where T : BaseEntety
    {



        Task<T?> GetAsync( int id );
      Task<IEnumerable<T>>  GetAllAdync();
      Task<T?> GetWithSpecAsync(ISpecifications<T> spec);


       Task<IEnumerable<T>> GetAllWithSpecAdync(ISpecifications<T> spec);



    }
}
