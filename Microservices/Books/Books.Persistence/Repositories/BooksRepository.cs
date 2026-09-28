using Books.Application.Contracts.Repositories;
using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Books;
using Books.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence.Repositories
{
    public class BooksRepository : Repository<book>, IBooksRepository
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<book>> GetPagedListAsync(
            PaginationRequest request,
            Guid? CategoryId,
            Guid? AutorId,
            CancellationToken cancellationToken = default)
        {
            IQueryable<book> query = _context.Set<book>()
                                             .Include(b => b.Autor)
                                             .Include(b => b.Category)
                                             .AsNoTracking()
                                             .AsQueryable();

            if (CategoryId.HasValue)
            {
                query = query.Where(b => b.CategoryId == CategoryId.Value);
            }

            if (AutorId.HasValue)
            {
                query = query.Where(b => b.AutorId == AutorId.Value);
            }

            query = query.OrderBy(b => b.Title);

            return await query.ToPagedListAsync(
                request,
                cancellationToken);
        }
    }
}