using System.Linq;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data
{
    public class SpecificationEvaluator<TEntiy> where TEntiy : BaseEntity
    {
        public static IQueryable<TEntiy> GetQuery(IQueryable<TEntiy> inputQuery, ISpecification<TEntiy> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) =>
                current.Include(include));

            return query;
        }
    }
}