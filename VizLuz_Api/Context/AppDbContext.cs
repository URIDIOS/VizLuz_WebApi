using VizLuz_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace VizLuz_Api.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{
			
		}

		public DbSet<Electrodomesticos> Electrodomesticos { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Ubicacion> Ubicaciones { get; set; }
		public DbSet<Controles> Controless { get; set; }




		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Tabla de Usuarios
			modelBuilder.Entity<Usuario>(tb =>
			{
				tb.HasKey(col => col.ID_Usuario);
				tb.Property(col => col.ID_Usuario).UseIdentityColumn().ValueGeneratedOnAdd();
				tb.Property(col => col.Nombres).HasMaxLength(50);
				tb.ToTable("Usuarios");
				tb.HasData(
					new Usuario { ID_Usuario = 1,Nombres = "Uriel Osuna"},
					new Usuario { ID_Usuario = 2,Nombres = "Miguel Octavio" },
					new Usuario { ID_Usuario = 3,Nombres = "Solo Vino" }

					);
			});
			//Tabla de Electrodomesicos
			modelBuilder.Entity<Electrodomesticos>(tb =>
			{
				tb.HasKey(col => col.ID_Electrodomestico);
				tb.Property(col => col.ID_Electrodomestico).UseIdentityColumn().ValueGeneratedOnAdd();
				tb.Property(col => col.NombreElectrodomestico).HasMaxLength(50);
				tb.HasOne(col => col.UsuarioReferencia).WithMany(p => p.ElectrodomesticosReferencia)
				.HasForeignKey(col => col.ID_Usuario);

				tb.ToTable("Electrodomesticos");
			});
			//Tabla de Ubicaciones
			modelBuilder.Entity<Ubicacion>(tb =>
			{
				tb.HasKey(col => col.ID_Ubicacion);
				tb.Property(col => col.ID_Ubicacion).UseIdentityColumn().ValueGeneratedOnAdd();
				tb.Property(col => col.NombreUbicacion).HasMaxLength(50);
				tb.ToTable("Ubicaciones");
				tb.HasData(
					new Ubicacion { ID_Ubicacion = 1, NombreUbicacion = "Cosina" },
					new Ubicacion { ID_Ubicacion = 2, NombreUbicacion = "Sala" },
					new Ubicacion { ID_Ubicacion = 3, NombreUbicacion = "Recamara 1" },
					new Ubicacion { ID_Ubicacion = 4, NombreUbicacion = "Recamara 2" },
					new Ubicacion { ID_Ubicacion = 5, NombreUbicacion = "Recamara 3" },
					new Ubicacion { ID_Ubicacion = 6, NombreUbicacion = "Patio" }
					);
			});
			//Tabla de Controles
			modelBuilder.Entity<Controles>(tb =>
			{
				tb.HasKey(col => col.ID_Controles);
				tb.Property(col => col.ID_Controles).UseIdentityColumn().ValueGeneratedOnAdd();
				tb.Property(col => col.NombreControl).HasMaxLength(50);
				tb.Property(col => col.Estado).HasMaxLength(50);
				tb.HasOne(col => col.UbicacionReferencia).WithMany(p => p.ControlesReferencia)
				.HasForeignKey(col => col.ID_Ubicacion);

				tb.ToTable("Controles");
			});


		}
	}
}
