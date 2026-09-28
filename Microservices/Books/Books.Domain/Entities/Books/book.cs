using AuthorEntity = Books.Domain.Entities.Author.Author;
using Books.Domain.Entities.Books.ValueObjects;
using Books.Domain.Entities.Categories;
using Books.Domain.Exceptions;

namespace Books.Domain.Entities.Books
{
    public sealed class book
    {
        public Guid Id { get; private set; }

        public Guid AutorId { get; private set; }

        public AuthorEntity Autor { get; private set; } = null!;

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; } = null!;

        public string Title { get; private set; } = null!;

        public string ISBN { get; private set; } = null!;

        public AnioPublicacion AnioPublicacion { get; private set; } = null!;


        // Constructor privado requerido por Entity Framework
        private book()
        {
        }


        public book(
            Guid autorId,
            Guid categoryId,
            string title,
            string isbn,
            int anioPublicacion)
        {
            ApplyAutorRules(autorId);
            ApplyCategoryRules(categoryId);
            ApplyTitleRules(title);
            ApplyISBNRules(isbn);
            ApplyAnioPublicacionRules(anioPublicacion);

            Id = Guid.CreateVersion7();
            AutorId = autorId;
            CategoryId = categoryId;
            Title = title;
            ISBN = isbn;
            AnioPublicacion = new AnioPublicacion(anioPublicacion);
        }


        private void ApplyAutorRules(Guid autorId)
        {
            if (autorId == Guid.Empty)
            {
                throw new BussinesRuleException(
                    "El autor es requerido.");
            }
        }


        private void ApplyCategoryRules(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new BussinesRuleException(
                    "La categoría es requerida.");
            }
        }


        private void ApplyTitleRules(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new BussinesRuleException(
                    "El título es requerido.");
            }

            if (title.Length < 2 || title.Length > 256)
            {
                throw new BussinesRuleException(
                    "El título debe tener entre 2 y 256 caracteres.");
            }
        }


        private void ApplyISBNRules(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new BussinesRuleException(
                    "El ISBN es requerido.");
            }

            if (isbn.Length > 20)
            {
                throw new BussinesRuleException(
                    "El ISBN no puede superar los 20 caracteres.");
            }
        }


        private void ApplyAnioPublicacionRules(int anioPublicacion)
        {
            if (anioPublicacion <= 0)
            {
                throw new BussinesRuleException(
                    "El año de publicación debe ser válido.");
            }

            if (anioPublicacion > DateTime.UtcNow.Year)
            {
                throw new BussinesRuleException(
                    "El año de publicación no puede ser mayor al año actual.");
            }
        }
    }
}