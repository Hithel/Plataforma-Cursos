
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
        {
            public void Configure(EntityTypeBuilder<Asignatura> builder)
            {
                builder.ToTable("Asignatura");

                 builder.HasKey(p => p.Id); 

                builder.Property(p => p.Nombre)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            }
        }
