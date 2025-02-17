﻿// <auto-generated />
using System;
using ComicADO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComicADO.Migrations
{
    [DbContext(typeof(ComicsContext))]
    partial class ComicsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComicADO.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AutorID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutorId"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Pais")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AutorId")
                        .HasName("PK__Autor__F58AE9092334E25C");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("ComicADO.Comic", b =>
                {
                    b.Property<int>("ComicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ComicID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComicId"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int")
                        .HasColumnName("AutorID");

                    b.Property<int?>("EditorialId")
                        .HasColumnType("int")
                        .HasColumnName("EditorialID");

                    b.Property<string>("Nombre")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<decimal?>("PrecioCompra")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Precio_Compra");

                    b.Property<decimal?>("PrecioVenta")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Precio_Venta");

                    b.HasKey("ComicId")
                        .HasName("PK__Comic__B8F0904EADD10E0E");

                    b.HasIndex("AutorId");

                    b.HasIndex("EditorialId");

                    b.ToTable("Comic");
                });

            modelBuilder.Entity("ComicADO.DetalleOperacion", b =>
                {
                    b.Property<int>("DetalleOperacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Detalle_OperacionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleOperacionId"));

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComicId")
                        .HasColumnType("int")
                        .HasColumnName("ComicID");

                    b.Property<decimal?>("Descuento")
                        .HasColumnType("decimal(7, 4)");

                    b.Property<int>("OperacionId")
                        .HasColumnType("int")
                        .HasColumnName("OperacionID");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("DetalleOperacionId")
                        .HasName("PK__Detalle___DA3A53714EA50D72");

                    b.HasIndex("ComicId");

                    b.HasIndex("OperacionId");

                    b.ToTable("Detalle_Operacion");
                });

            modelBuilder.Entity("ComicADO.Editorial", b =>
                {
                    b.Property<int>("EditorialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EditorialID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EditorialId"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.HasKey("EditorialId")
                        .HasName("PK__Editoria__D54C828EBDED7347");

                    b.ToTable("Editorial");
                });

            modelBuilder.Entity("ComicADO.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("NIF");

                    b.Property<string>("Nombre")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Password")
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("EmpleadoId")
                        .HasName("PK__Empleado__958BE6F0A592DBBF");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("ComicADO.Local", b =>
                {
                    b.Property<int>("LocalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LocalID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocalId"));

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Latitud")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<decimal>("Longitud")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.HasKey("LocalId")
                        .HasName("PK__Local__499359DB8AB9ECEE");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("ComicADO.MedioDePago", b =>
                {
                    b.Property<int>("MedioDePagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Medio_De_PagoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedioDePagoId"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreCorto")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Nombre_Corto");

                    b.HasKey("MedioDePagoId")
                        .HasName("PK__Medio_De__BBFD2763DAECE456");

                    b.ToTable("Medio_De_Pago");
                });

            modelBuilder.Entity("ComicADO.Operacion", b =>
                {
                    b.Property<int>("OperacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OperacionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperacionId"));

                    b.Property<int>("ComicId")
                        .HasColumnType("int")
                        .HasColumnName("ComicID");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoID");

                    b.Property<DateTime>("FechaOperacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Operacion");

                    b.Property<int>("LocalId")
                        .HasColumnType("int")
                        .HasColumnName("LocalID");

                    b.Property<int>("MedioDePagoId")
                        .HasColumnType("int")
                        .HasColumnName("Medio_De_PagoID");

                    b.Property<int>("TipoOperacionId")
                        .HasColumnType("int")
                        .HasColumnName("Tipo_OperacionID");

                    b.HasKey("OperacionId")
                        .HasName("PK__Operacio__8A668AF7E68D4AA0");

                    b.HasIndex("ComicId");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("LocalId");

                    b.HasIndex("MedioDePagoId");

                    b.HasIndex("TipoOperacionId");

                    b.ToTable("Operacion");
                });

            modelBuilder.Entity("ComicADO.StockComic", b =>
                {
                    b.Property<int>("StockComicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Stock_ComicID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockComicId"));

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComicId")
                        .HasColumnType("int")
                        .HasColumnName("ComicID");

                    b.Property<int>("LocalId")
                        .HasColumnType("int")
                        .HasColumnName("LocalID");

                    b.HasKey("StockComicId")
                        .HasName("PK__Stock_Co__3A77E093F1F1B3DD");

                    b.HasIndex("ComicId");

                    b.HasIndex("LocalId");

                    b.ToTable("Stock_Comic");
                });

            modelBuilder.Entity("ComicADO.TipoOperacion", b =>
                {
                    b.Property<int>("TipoOperacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Tipo_OperacionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoOperacionId"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("TipoOperacionId")
                        .HasName("PK__Tipo_Ope__F75BE529E376A9FC");

                    b.ToTable("Tipo_Operacion");
                });

            modelBuilder.Entity("EmpleadoLocal", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId", "LocalId");

                    b.ToTable("EmpleadoLocal");
                });

            modelBuilder.Entity("LocalEmpleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoID");

                    b.Property<int>("LocalId")
                        .HasColumnType("int")
                        .HasColumnName("LocalID");

                    b.HasKey("EmpleadoId", "LocalId")
                        .HasName("PK__Local_Em__3112D36D047C811E");

                    b.HasIndex("LocalId");

                    b.ToTable("Local_Empleado", (string)null);
                });

            modelBuilder.Entity("ComicADO.Comic", b =>
                {
                    b.HasOne("ComicADO.Autor", "Autor")
                        .WithMany("Comics")
                        .HasForeignKey("AutorId")
                        .HasConstraintName("FK__Comic__AutorID__286302EC");

                    b.HasOne("ComicADO.Editorial", "Editorial")
                        .WithMany("Comics")
                        .HasForeignKey("EditorialId")
                        .HasConstraintName("FK__Comic__Editorial__29572725");

                    b.Navigation("Autor");

                    b.Navigation("Editorial");
                });

            modelBuilder.Entity("ComicADO.DetalleOperacion", b =>
                {
                    b.HasOne("ComicADO.Comic", "Comic")
                        .WithMany("DetalleOperacions")
                        .HasForeignKey("ComicId")
                        .IsRequired()
                        .HasConstraintName("FK__Detalle_O__Comic__4316F928");

                    b.HasOne("ComicADO.Operacion", "Operacion")
                        .WithMany("DetalleOperacions")
                        .HasForeignKey("OperacionId")
                        .IsRequired()
                        .HasConstraintName("FK__Detalle_O__Opera__4222D4EF");

                    b.Navigation("Comic");

                    b.Navigation("Operacion");
                });

            modelBuilder.Entity("ComicADO.Operacion", b =>
                {
                    b.HasOne("ComicADO.Comic", "Comic")
                        .WithMany("Operacions")
                        .HasForeignKey("ComicId")
                        .IsRequired()
                        .HasConstraintName("FK__Operacion__Comic__3D5E1FD2");

                    b.HasOne("ComicADO.Empleado", "Empleado")
                        .WithMany("Operacions")
                        .HasForeignKey("EmpleadoId")
                        .IsRequired()
                        .HasConstraintName("FK__Operacion__Emple__3F466844");

                    b.HasOne("ComicADO.Local", "Local")
                        .WithMany("Operacions")
                        .HasForeignKey("LocalId")
                        .IsRequired()
                        .HasConstraintName("FK__Operacion__Local__3E52440B");

                    b.HasOne("ComicADO.MedioDePago", "MedioDePago")
                        .WithMany("Operacions")
                        .HasForeignKey("MedioDePagoId")
                        .IsRequired()
                        .HasConstraintName("FK__Operacion__Medio__3B75D760");

                    b.HasOne("ComicADO.TipoOperacion", "TipoOperacion")
                        .WithMany("Operacions")
                        .HasForeignKey("TipoOperacionId")
                        .IsRequired()
                        .HasConstraintName("FK__Operacion__Tipo___3C69FB99");

                    b.Navigation("Comic");

                    b.Navigation("Empleado");

                    b.Navigation("Local");

                    b.Navigation("MedioDePago");

                    b.Navigation("TipoOperacion");
                });

            modelBuilder.Entity("ComicADO.StockComic", b =>
                {
                    b.HasOne("ComicADO.Comic", "Comic")
                        .WithMany("StockComics")
                        .HasForeignKey("ComicId")
                        .IsRequired()
                        .HasConstraintName("FK__Stock_Com__Comic__34C8D9D1");

                    b.HasOne("ComicADO.Local", "Local")
                        .WithMany("StockComics")
                        .HasForeignKey("LocalId")
                        .IsRequired()
                        .HasConstraintName("FK__Stock_Com__Local__33D4B598");

                    b.Navigation("Comic");

                    b.Navigation("Local");
                });

            modelBuilder.Entity("LocalEmpleado", b =>
                {
                    b.HasOne("ComicADO.Empleado", null)
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .IsRequired()
                        .HasConstraintName("FK__Local_Emp__Emple__300424B4");

                    b.HasOne("ComicADO.Local", null)
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .IsRequired()
                        .HasConstraintName("FK__Local_Emp__Local__30F848ED");
                });

            modelBuilder.Entity("ComicADO.Autor", b =>
                {
                    b.Navigation("Comics");
                });

            modelBuilder.Entity("ComicADO.Comic", b =>
                {
                    b.Navigation("DetalleOperacions");

                    b.Navigation("Operacions");

                    b.Navigation("StockComics");
                });

            modelBuilder.Entity("ComicADO.Editorial", b =>
                {
                    b.Navigation("Comics");
                });

            modelBuilder.Entity("ComicADO.Empleado", b =>
                {
                    b.Navigation("Operacions");
                });

            modelBuilder.Entity("ComicADO.Local", b =>
                {
                    b.Navigation("Operacions");

                    b.Navigation("StockComics");
                });

            modelBuilder.Entity("ComicADO.MedioDePago", b =>
                {
                    b.Navigation("Operacions");
                });

            modelBuilder.Entity("ComicADO.Operacion", b =>
                {
                    b.Navigation("DetalleOperacions");
                });

            modelBuilder.Entity("ComicADO.TipoOperacion", b =>
                {
                    b.Navigation("Operacions");
                });
#pragma warning restore 612, 618
        }
    }
}
