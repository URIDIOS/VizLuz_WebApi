﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VizLuz_Api.Context;

#nullable disable

namespace VizLuz_Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241204015855_primera Migracion")]
    partial class primeraMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VizLuz_Api.Models.Controles", b =>
                {
                    b.Property<int>("ID_Controles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Controles"));

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ID_Ubicacion")
                        .HasColumnType("int");

                    b.Property<string>("NombreControl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID_Controles");

                    b.HasIndex("ID_Ubicacion");

                    b.ToTable("Controles", (string)null);
                });

            modelBuilder.Entity("VizLuz_Api.Models.Electrodomesticos", b =>
                {
                    b.Property<int>("ID_Electrodomestico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Electrodomestico"));

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_Usuario")
                        .HasColumnType("int");

                    b.Property<string>("NombreElectrodomestico")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID_Electrodomestico");

                    b.HasIndex("ID_Usuario");

                    b.ToTable("Electrodomesticos", (string)null);
                });

            modelBuilder.Entity("VizLuz_Api.Models.Ubicacion", b =>
                {
                    b.Property<int>("ID_Ubicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Ubicacion"));

                    b.Property<string>("NombreUbicacion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID_Ubicacion");

                    b.ToTable("Ubicaciones", (string)null);

                    b.HasData(
                        new
                        {
                            ID_Ubicacion = 1,
                            NombreUbicacion = "Cosina"
                        },
                        new
                        {
                            ID_Ubicacion = 2,
                            NombreUbicacion = "Sala"
                        },
                        new
                        {
                            ID_Ubicacion = 3,
                            NombreUbicacion = "Recamara 1"
                        },
                        new
                        {
                            ID_Ubicacion = 4,
                            NombreUbicacion = "Recamara 2"
                        },
                        new
                        {
                            ID_Ubicacion = 5,
                            NombreUbicacion = "Recamara 3"
                        },
                        new
                        {
                            ID_Ubicacion = 6,
                            NombreUbicacion = "Patio"
                        });
                });

            modelBuilder.Entity("VizLuz_Api.Models.Usuario", b =>
                {
                    b.Property<int>("ID_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Usuario"));

                    b.Property<string>("Nombres")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID_Usuario");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            ID_Usuario = 1,
                            Nombres = "Uriel Osuna"
                        },
                        new
                        {
                            ID_Usuario = 2,
                            Nombres = "Miguel Octavio"
                        },
                        new
                        {
                            ID_Usuario = 3,
                            Nombres = "Solo Vino"
                        });
                });

            modelBuilder.Entity("VizLuz_Api.Models.Controles", b =>
                {
                    b.HasOne("VizLuz_Api.Models.Ubicacion", "UbicacionReferencia")
                        .WithMany("ControlesReferencia")
                        .HasForeignKey("ID_Ubicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UbicacionReferencia");
                });

            modelBuilder.Entity("VizLuz_Api.Models.Electrodomesticos", b =>
                {
                    b.HasOne("VizLuz_Api.Models.Usuario", "UsuarioReferencia")
                        .WithMany("ElectrodomesticosReferencia")
                        .HasForeignKey("ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioReferencia");
                });

            modelBuilder.Entity("VizLuz_Api.Models.Ubicacion", b =>
                {
                    b.Navigation("ControlesReferencia");
                });

            modelBuilder.Entity("VizLuz_Api.Models.Usuario", b =>
                {
                    b.Navigation("ElectrodomesticosReferencia");
                });
#pragma warning restore 612, 618
        }
    }
}
