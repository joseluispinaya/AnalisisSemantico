using Capa.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Capa.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<ProyectoGrado> ProyectoGrados { get; set; }

        public DbSet<LineaInvestigacion> LineasInvestigacion { get; set; }
        public DbSet<DocenteLineaInvestigacion> DocenteLineasInvestigacion { get; set; }
        public DbSet<HistorialTutoria> HistorialTutorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carrera>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<Docente>().HasIndex(x => x.NroCi).IsUnique();
            modelBuilder.Entity<Estudiante>().HasIndex(x => x.NroCi).IsUnique();
            modelBuilder.Entity<ProyectoGrado>().HasIndex(x => x.EstudianteId).IsUnique();

            // Clave compuesta para tabla intermedia
            modelBuilder.Entity<DocenteLineaInvestigacion>()
                .HasKey(x => new { x.DocenteId, x.LineaInvestigacionId });

            // Relaciones muchos a muchos explícitas
            modelBuilder.Entity<DocenteLineaInvestigacion>()
                .HasOne(x => x.Docente)
                .WithMany(x => x.LineasInvestigacion)
                .HasForeignKey(x => x.DocenteId);

            modelBuilder.Entity<DocenteLineaInvestigacion>()
                .HasOne(x => x.LineaInvestigacion)
                .WithMany(x => x.Docentes)
                .HasForeignKey(x => x.LineaInvestigacionId);

            DisableCascadingDelete(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
