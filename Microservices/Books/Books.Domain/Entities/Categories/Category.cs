using Books.Domain.Common.ValueObjects;

namespace Books.Domain.Entities.Categories
{
    public sealed class Category
    {
        public Guid Id { get; private set; }

        public Nombre Nombre { get; private set; } = null!;

        // Constructor privado para Entity Framework
        private Category()
        {
        }

        // Constructor que usarás desde la aplicación
        public Category(Guid id, string nombre)
        {
            Id = id;
            Nombre = new Nombre(nombre);
        }
    }
}