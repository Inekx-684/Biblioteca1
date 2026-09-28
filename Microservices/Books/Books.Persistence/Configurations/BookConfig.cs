using Books.Domain.Entities.Books;
using Books.Domain.Entities.Books.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Persistence.Configurations
{
    internal class BookConfig : IEntityTypeConfiguration<book>
    {
        public void Configure(EntityTypeBuilder<book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(b => b.ISBN)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(b => b.AnioPublicacion)
                   .HasConversion(
                       anio => anio.Valor,
                       valor => new AnioPublicacion(valor))
                   .IsRequired();

            builder.HasOne(b => b.Autor)
                   .WithMany()
                   .HasForeignKey(b => b.AutorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Category)
                   .WithMany()
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}