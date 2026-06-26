using Bulky.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Infra.TypeConfigurations
{
    public class BookTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ISBN).HasColumnType("nvarchar(255)");
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(255)");
            builder.Property(x => x.CategoryId).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar(255)");
            builder.Property(x => x.ImageUrl).HasColumnType("nvarchar(255)");
        }
    }
}
