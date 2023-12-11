

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
        {
            public void Configure(EntityTypeBuilder<Instructor> builder)
            {
                builder.ToTable("Instructor");

                 builder.HasKey(p => p.Id); 

                builder.Property(p => p.Nombre)
                .HasColumnType("varchar")
                .HasMaxLength(50);

                builder.Property(p => p.Correo)
                .HasColumnType("varchar")
                .HasMaxLength(150);

                builder.Property(p => p.Telefono)
                .HasColumnType("int")
                .HasMaxLength(10);

                 builder
               .HasMany(p => p.Asignaturas) 
               .WithMany(r => r.Instructores)
               .UsingEntity<InstrucAsignatura>(

                   j => j
                   .HasOne(pt => pt.Asignatura)
                   .WithMany(t => t.InstrucAsignaturas)
                   .HasForeignKey(ut => ut.IdAsignaturaFK),


                   j => j
                   .HasOne(et => et.Instructor)
                   .WithMany(et => et.InstrucAsignaturas)
                   .HasForeignKey(el => el.IdInstructorFk),

                   j =>
                   {
                       j.ToTable("InstrucAsignatura");
                       j.HasKey(t => new { t.IdAsignaturaFK, t.IdInstructorFk });

                   });

            }
        }