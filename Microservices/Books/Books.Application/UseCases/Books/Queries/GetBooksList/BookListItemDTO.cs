using Books.Domain.Entities.Books.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.UseCases.Books.Queries.GetBooksList
{
    public class BookListItemDTO
    {
        public Guid Id { get; init; }
        public Guid AutorId { get; set; }
        public string AutorName { get;  set; } = null!;
        public Guid CategoryId { get; set; }
        public string CategoryName { get;  set; } = null!;
        public string Title { get; init; } = null!;
        public string ISBN { get;  init; } = null!;
        public string AnioPublicacionName { get; init; } = null!;
    }
}
