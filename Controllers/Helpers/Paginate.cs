using Microsoft.EntityFrameworkCore;

namespace ApiServico.Controllers.Helpers
{
    public class Paginate<T>
    {
        public async static Task<(IQueryable<T>, PagedResponse<T>)> Set(IQueryable<T> query, IPaginatedFilter paginate)
        {   
            var totalItems = await query.CountAsync();
            var totalPages = (int) Math.Ceiling(totalItems / (double) paginate.Limit);

            var _query = query
                .Skip((paginate.Page - 1) * paginate.Limit)
                .Take(paginate.Limit);

            var response = new PagedResponse<T>() { 
                TotalItems = totalItems, 
                TotalPages = totalPages,
                Limit = paginate.Limit, 
                Page = paginate.Page 
            };

            return (_query, response);
        }
    }
}
