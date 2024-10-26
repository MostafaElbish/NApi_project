using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Entities;

namespace Talapat.Core.Specifications
{
    public class BaseSpecfication<T> : ISpecifications<T> where T : BaseEntety
    {
        public Expression<Func<T, bool>> Criteira { get; set; } = null;
        public List<Expression<Func<T, object>>> Include { get; set; } = new List<Expression<Func<T, object>>>();
        public BaseSpecfication()
        {
            //Include = new List<Func<T, object>>();
            //Criteira = null;
        }

        public BaseSpecfication(Expression<Func<T, bool>> criteiras)
        {
            Criteira = criteiras;

        }
    }
}

