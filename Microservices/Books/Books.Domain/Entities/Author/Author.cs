using Books.Domain.Common.ValueObjects;

namespace Books.Domain.Entities.Author
{
    public sealed class Author
    {
        public Guid Id { get; private set; }

        public Nombre Nombre { get; private set; } = null!;

        // Constructor privado para Entity Framework
        private Author()
        {
        }

        // Constructor que usarás desde tu aplicación
        public Author(Guid id, string nombre)
        {
            Id = id;
            Nombre = new Nombre(nombre);
        }
    }
}