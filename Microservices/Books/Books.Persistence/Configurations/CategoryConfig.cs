using Books.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Books.Domain.Common.ValueObjects;

using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Persistence.Configurations
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                   .HasConversion(
                       nombre => nombre.Valor,
                       valor => new Nombre(valor))
                   .HasMaxLength(90)
                   .IsRequired();
        }
    }
}
