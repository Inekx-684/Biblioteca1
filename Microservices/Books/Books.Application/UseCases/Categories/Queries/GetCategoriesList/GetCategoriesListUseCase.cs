using Books.Application.Contracts.Repositories;
using Books.Application.Utilities.Mediator;
using Books.Application.Utilities.Mediator.Pagination;
using Books.Domain.Entities.Categories;

namespace Books.Application.UseCases.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListUseCase
        : IRequestHandler<GetCategoriesListQuery, PaginationResponse<GetCategoriesListDTO>>
    {
        private readonly ICategoriesRepository _repository;

        public GetCategoriesListUseCase(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<GetCategoriesListDTO>> Handle(
            GetCategoriesListQuery query)
        {
            PaginationRequest pagination = query.Pagination;

            PaginationResponse<Category> response =
                await _repository.GetPagedListAsync(pagination);

            List<GetCategoriesListDTO> items =
                response.Items
                        .Select(c => c.ToListItemDTO())
                        .ToList();

            return PaginationResponse<GetCategoriesListDTO>.Create(
                items,
                response.TotalCount,
                pagination);
        }
    }
}