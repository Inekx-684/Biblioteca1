using Books.Application.Contracts.Repositories;
using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Categories;
using Books.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence.Repositories
{
    public class CategoriesRepository
        : Repository<Category>, ICategoriesRepository
    {
        private readonly DataContext _context;

        public CategoriesRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Category>> GetPagedListAsync(
            PaginationRequest request,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Category> query = _context.Set<Category>()
                                                 .AsNoTracking()
                                                 .OrderBy(c => c.Nombre.Valor);

            return await query.ToPagedListAsync(
                request,
                cancellationToken);
        }
    }
}