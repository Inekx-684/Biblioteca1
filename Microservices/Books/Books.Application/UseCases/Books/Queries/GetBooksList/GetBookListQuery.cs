using Books.Application.Utilities.Mediator;
using Books.Application.Utilities.Mediator.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.UseCases.Books.Queries.GetBooksList
{
    public class GetBookListQuery : IRequest<PaginationResponse<BookListItemDTO>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();

        public Guid? CategoryId { get; set; }

        public Guid? AutorId { get; set; }

    }
}
