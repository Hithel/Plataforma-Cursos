
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CalificacionConfiguration : IEntityTypeConfiguration<Calificacion>
        {
            public void Configure(EntityTypeBuilder<Calificacion> builder)
            {
                builder.ToTable("Calificacion");

                builder.HasKey(p => new { p.IdUserFk, p.IdCursoFK});

                builder.Property(p => p.IdUserFk)
                .HasColumnType("int");

                builder.Property(p => p.IdCursoFK)
                .HasColumnType("int");
    
                builder.HasOne(p => p.User)
                .WithMany(p => p.Calificaciones)
                .HasForeignKey(p => p.IdUserFk);

                builder.HasOne(p => p.Curso)
                .WithMany(p => p.Calificaciones)
                .HasForeignKey(p => p.IdCursoFK);


                
                
            }
        }