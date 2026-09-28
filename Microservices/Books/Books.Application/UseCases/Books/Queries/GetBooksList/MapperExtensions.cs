using System;
using System.Collections.Generic;
using System.Text;
using Books.Domain.Entities.Books;

namespace Books.Application.UseCases.Books.Queries.GetBooksList
{
    public static class MapperExtensions
    {
        public static BookListItemDTO ToListItemDTO(this book bookEntity)
        {
            return new BookListItemDTO
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                ISBN = bookEntity.ISBN,
                AutorId = bookEntity.AutorId,
                AnioPublicacionName = bookEntity.AnioPublicacion.Valor.ToString(),
                CategoryId = bookEntity.CategoryId
            };
        
        }
    }
}
