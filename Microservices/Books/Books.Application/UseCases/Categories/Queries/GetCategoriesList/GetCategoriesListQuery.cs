using System;
using System.Collections.Generic;
using System.Text;
using Books.Application.Utilities.Mediator;
using Books.Application.Utilities.Mediator.Pagination;

namespace Books.Application.UseCases.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<PaginationResponse<GetCategoriesListDTO>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();
    }
}
