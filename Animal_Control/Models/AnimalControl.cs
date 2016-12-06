namespace Animal_Control.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AnimalControl : DbContext
    {
        public AnimalControl()
            : base("name=AnimalControl")
        {
        }

        public virtual DbSet<AC_Animal> AC_Animal { get; set; }
        public virtual DbSet<AC_Articulo> AC_Articulo { get; set; }
        public virtual DbSet<AC_Articulo_Proveedor> AC_Articulo_Proveedor { get; set; }
        public virtual DbSet<AC_Control_Diario> AC_Control_Diario { get; set; }
        public virtual DbSet<AC_Daño> AC_Daño { get; set; }
        public virtual DbSet<AC_Gastos> AC_Gastos { get; set; }
        public virtual DbSet<AC_Ingresos> AC_Ingresos { get; set; }
        public virtual DbSet<AC_Liberacion> AC_Liberacion { get; set; }
        public virtual DbSet<AC_Medicamento> AC_Medicamento { get; set; }
        public virtual DbSet<AC_Persona_Reporta> AC_Persona_Reporta { get; set; }
        public virtual DbSet<AC_Proveedor> AC_Proveedor { get; set; }
        public virtual DbSet<AC_Stock_Maximo> AC_Stock_Maximo { get; set; }
        public virtual DbSet<AC_Stock_Minimo> AC_Stock_Minimo { get; set; }
        public virtual DbSet<AC_Usuario> AC_Usuario { get; set; }
        public virtual DbSet<AC_Vacuna> AC_Vacuna { get; set; }
        public virtual DbSet<AC_Visita_Veterinaria> AC_Visita_Veterinaria { get; set; }
        public virtual DbSet<AC_Zona> AC_Zona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<AC_Animal>()
                .HasMany(e => e.AC_Control_Diario)
                .WithRequired(e => e.AC_Animal)
                .HasForeignKey(e => e.ID_Animal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Animal>()
                .HasMany(e => e.AC_Visita_Veterinaria)
                .WithRequired(e => e.AC_Animal)
                .HasForeignKey(e => e.ID_Animal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Articulo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<AC_Articulo>()
                .HasMany(e => e.AC_Articulo_Proveedor)
                .WithRequired(e => e.AC_Articulo)
                .HasForeignKey(e => e.ID_Articulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Articulo>()
                .HasMany(e => e.AC_Gastos)
                .WithOptional(e => e.AC_Articulo)
                .HasForeignKey(e => e.ID_Articulo);


            modelBuilder.Entity<AC_Articulo>()
                .HasMany(e => e.AC_Stock_Maximo)
                .WithRequired(e => e.AC_Articulo)
                .HasForeignKey(e => e.ID_Articulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Articulo>()
                .HasMany(e => e.AC_Stock_Minimo)
                .WithRequired(e => e.AC_Articulo)
                .HasForeignKey(e => e.ID_Articulo)
                .WillCascadeOnDelete(false);
       

            modelBuilder.Entity<AC_Daño>()
                .HasMany(e => e.AC_Animal)
                .WithRequired(e => e.AC_Daño)
                .HasForeignKey(e => e.ID_Daño)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Daño>()
                .HasMany(e => e.AC_Liberacion)
                .WithRequired(e => e.AC_Daño)
                .HasForeignKey(e => e.ID_Daño)
                .WillCascadeOnDelete(false);

            

            modelBuilder.Entity<AC_Medicamento>()
                .HasMany(e => e.AC_Control_Diario)
                .WithOptional(e => e.AC_Medicamento)
                .HasForeignKey(e => e.ID_Medicamento);

            modelBuilder.Entity<AC_Persona_Reporta>()
                .HasMany(e => e.AC_Animal)
                .WithRequired(e => e.AC_Persona_Reporta)
                .HasForeignKey(e => e.ID_Persona_Reporta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Proveedor>()
                .HasMany(e => e.AC_Articulo_Proveedor)
                .WithRequired(e => e.AC_Proveedor)
                .HasForeignKey(e => e.ID_Proveedor)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<AC_Usuario>()
                .HasMany(e => e.AC_Animal)
                .WithRequired(e => e.AC_Usuario)
                .HasForeignKey(e => e.ID_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Usuario>()
                .HasMany(e => e.AC_Control_Diario)
                .WithRequired(e => e.AC_Usuario)
                .HasForeignKey(e => e.ID_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Usuario>()
                .HasMany(e => e.AC_Gastos)
                .WithRequired(e => e.AC_Usuario)
                .HasForeignKey(e => e.ID_Usuario)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<AC_Usuario>()
                .HasMany(e => e.AC_Ingresos)
                .WithRequired(e => e.AC_Usuario)
                .HasForeignKey(e => e.ID_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Usuario>()
                .HasMany(e => e.AC_Liberacion)
                .WithRequired(e => e.AC_Usuario)
                .HasForeignKey(e => e.ID_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Usuario>()
                .HasMany(e => e.AC_Visita_Veterinaria)
                .WithRequired(e => e.AC_Usuario)
                .HasForeignKey(e => e.ID_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Vacuna>()
                .HasMany(e => e.AC_Control_Diario)
                .WithOptional(e => e.AC_Vacuna)
                .HasForeignKey(e => e.ID_Vacuna);


            modelBuilder.Entity<AC_Zona>()
                .HasMany(e => e.AC_Animal)
                .WithRequired(e => e.AC_Zona)
                .HasForeignKey(e => e.ID_Zona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AC_Zona>()
                .HasMany(e => e.AC_Liberacion)
                .WithRequired(e => e.AC_Zona)
                .HasForeignKey(e => e.ID_Zona)
                .WillCascadeOnDelete(false);
        }
    }
}
