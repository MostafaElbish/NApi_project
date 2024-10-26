using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Entities;

namespace Talapat.Core.Specifications
{
    public interface ISpecifications<T> where T:BaseEntety
    {

        public Expression<Func<T,bool>> Criteira { get; set; }

        public List<Expression< Func<T,object>>> Include {  get; set; }



    }
}
