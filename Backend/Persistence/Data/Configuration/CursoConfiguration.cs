

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
        {
            public void Configure(EntityTypeBuilder<Curso> builder)
            {
                builder.ToTable("Curso");

                 builder.HasKey(p => p.Id); 

                 builder.Property(p => p.Titulo)
                .HasColumnType("varchar")
                .HasMaxLength(50);

                 builder.Property(p => p.Descripcion)
                .HasColumnType("varchar")
                .HasMaxLength(300);

                builder.Property(p => p.Img)
                .HasColumnType("Varchar")
                .HasMaxLength(256);

                builder.HasOne(p => p.Instructor)
                .WithMany(p => p.Cursos)
                .HasForeignKey(p => p.IdInstructorFk);


            }
        }
