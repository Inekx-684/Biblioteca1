using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Categories;

namespace Books.Application.Contracts.Repositories
{
    public interface ICategoriesRepository : Irepository<Category>
    {
        Task<PaginationResponse<Category>> GetPagedListAsync(
            PaginationRequest request,
            CancellationToken cancellationToken = default);
    }
}