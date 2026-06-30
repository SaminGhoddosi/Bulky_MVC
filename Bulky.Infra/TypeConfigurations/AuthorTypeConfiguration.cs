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
    public class AuthorTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BirthDate).HasColumnType("datetime");
            builder.Property(x => x.Name).HasColumnType("nvarchar(255)");
            builder.Property(x => x.PublishHouseId).HasColumnType("int");
        }
    }
}
