using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Instructor> Instructores { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UsersRols { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /* dotnet ef migrations add InitialCreate --project .\Persistence\ --startup-project .\API\ --output-dir ./Data/Migrations 
         */
         /* dotnet ef database update --project .\Persistence\ --startup-project .\API\
          */
    }