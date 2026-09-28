using Books.Domain.Entities.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Books.Domain.Common.ValueObjects;

namespace Books.Persistence.Configurations
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nombre)
                   .HasConversion(
                       nombre => nombre.Valor,
                       valor => new Nombre(valor))
                   .HasMaxLength(90)
                   .IsRequired();
        }
    }
}
