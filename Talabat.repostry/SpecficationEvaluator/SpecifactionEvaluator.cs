using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Entities;
using Talapat.Core.Specifications;

namespace Talabat.repostry.SpecficationEvaluator
{
    public class SpecifactionEvaluator<TEntity> where TEntity : BaseEntety
    {

        public static IQueryable<TEntity> GetQuery(IQueryable <TEntity>InputQuery,ISpecifications<TEntity>spec)
        {
            var query = InputQuery;

            if(spec.Criteira is not null)
            {
                query = query.Where(spec.Criteira);
            }

            query = spec.Include.Aggregate(query, (CurrentQuery, includeExpression) => CurrentQuery.Include(includeExpression));

            return query;
        }
    }
}
