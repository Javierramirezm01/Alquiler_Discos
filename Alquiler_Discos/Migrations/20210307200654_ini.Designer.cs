// <auto-generated />
using System;
using Alquiler_Discos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alquiler_Discos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210307200654_ini")]
    partial class ini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alquiler_Discos.Models.Alquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("fechaAlquiler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nroAlquiler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("valorAlquiler")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("alquilers");
                });

            modelBuilder.Entity("Alquiler_Discos.Models.Cd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("codigoTitulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("condicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cds");
                });

            modelBuilder.Entity("Alquiler_Discos.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimineto")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NroDNI")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.Property<string>("TemaInteres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Alquiler_Discos.Models.DetalleAlquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlquilerId")
                        .HasColumnType("int");

                    b.Property<int>("CdId")
                        .HasColumnType("int");

                    b.Property<string>("diasPrestamo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fechaDevolucion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("item")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlquilerId");

                    b.HasIndex("CdId");

                    b.ToTable("detalleAlquilers");
                });

            modelBuilder.Entity("Alquiler_Discos.Models.Sancion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlquilerId")
                        .HasColumnType("int");

                    b.Property<int>("NroDiasSancion")
                        .HasColumnType("int");

                    b.Property<string>("TipoSancion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlquilerId");

                    b.ToTable("sancions");
                });

            modelBuilder.Entity("Alquiler_Discos.Models.Alquiler", b =>
                {
                    b.HasOne("Alquiler_Discos.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Alquiler_Discos.Models.DetalleAlquiler", b =>
                {
                    b.HasOne("Alquiler_Discos.Models.Alquiler", "Alquiler")
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alquiler_Discos.Models.Cd", "Cd")
                        .WithMany()
                        .HasForeignKey("CdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alquiler");

                    b.Navigation("Cd");
                });

            modelBuilder.Entity("Alquiler_Discos.Models.Sancion", b =>
                {
                    b.HasOne("Alquiler_Discos.Models.Alquiler", "Alquiler")
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alquiler");
                });
#pragma warning restore 612, 618
        }
    }
}
