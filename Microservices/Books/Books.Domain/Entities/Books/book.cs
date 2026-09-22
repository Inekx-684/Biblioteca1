using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.Entities.Books
{
    public sealed class book
    {
        public Guid Id { get; private set; }//Cadena de texto larga que sirve como identifivador
        public Guid AutorId { get; private set; }
        public Guid CategoryId { get; private set; }
        public string Title { get; private set; } = null!;
        public string ISBN { get; private set; } = null!;
        public string Autor { get; private set; } = null!;
        public string Categoria { get; private set; } = null!;
        public AnioPublicacion anioPublicacion { get; private set; }
    }
}
