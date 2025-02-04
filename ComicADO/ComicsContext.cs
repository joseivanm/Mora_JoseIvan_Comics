using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO;

public partial class ComicsContext : DbContext
{
    //<author>Jose Ivan Mora Gonzaga</author>
    public ComicsContext()
    {
    }

    public ComicsContext(DbContextOptions<ComicsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Comic> Comics { get; set; }

    public virtual DbSet<DetalleOperacion> DetalleOperacions { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Local> Locals { get; set; }

    public virtual DbSet<MedioDePago> MedioDePagos { get; set; }

    public virtual DbSet<Operacion> Operacions { get; set; }

    public virtual DbSet<StockComic> StockComics { get; set; }

    public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }

    public virtual DbSet<LocalEmpleado> LocalEmpleados { get; set; } // Renombrar a Local_Empleados

    public virtual DbSet<ClienteJIM> Clientes { get; set; }

    public virtual DbSet<OperacionClienteJIM> OperacionClientesJIM { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Comics;Integrated Security=True;TrustServerCertificate=True;");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autor__F58AE909187F824A");
        });

        modelBuilder.Entity<Comic>(entity =>
        {
            entity.HasKey(e => e.ComicId).HasName("PK__Comic__B8F0904E450F6C2A");

            entity.HasOne(d => d.Autor).WithMany(p => p.Comics).HasConstraintName("FK__Comic__AutorID__3B75D760");

            entity.HasOne(d => d.Editorial).WithMany(p => p.Comics).HasConstraintName("FK__Comic__Editorial__3C69FB99");
        });

        modelBuilder.Entity<ClienteJIM>(entity =>
        {
            entity.ToTable("Cliente_JIM");
            entity.HasKey(c => c.ClienteID);
            entity.Property(c => c.Nombre).HasMaxLength(100);
            entity.Property(c => c.Email).HasMaxLength(200);
        });

        modelBuilder.Entity<DetalleOperacion>(entity =>
        {
            entity.HasKey(e => e.DetalleOperacionId).HasName("PK__Detalle___DA3A5371A6898FA0");

            entity.HasOne(d => d.Comic).WithMany(p => p.DetalleOperacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_O__Comic__5629CD9C");

            entity.HasOne(d => d.Operacion).WithMany(p => p.DetalleOperacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_O__Opera__5535A963");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.EditorialId).HasName("PK__Editoria__D54C828ED4722916");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F0553D4E9F");

            entity.HasMany(d => d.Locals).WithMany(p => p.Empleados)
                .UsingEntity<Dictionary<string, object>>(
                    "LocalEmpleado",
                    r => r.HasOne<Local>().WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Emp__Local__440B1D61"),
                    l => l.HasOne<Empleado>().WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Emp__Emple__4316F928"),
                    j =>
                    {
                        j.HasKey("EmpleadoId", "LocalId").HasName("PK__Local_Em__3112D36DC2CC4E39");
                        j.ToTable("Local_Empleado");
                        j.IndexerProperty<int>("EmpleadoId").HasColumnName("EmpleadoId"); 
                        j.IndexerProperty<int>("LocalId").HasColumnName("LocalId"); 
                    });

        });

        modelBuilder.Entity<LocalEmpleado>().ToTable("Local_Empleado", "dbo");


        modelBuilder.Entity<LocalEmpleado>()
    .HasKey(le => new { le.EmpleadoId, le.LocalId }); 



        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.LocalId).HasName("PK__Local__499359DBAFEFBEEF");
        });

      

        modelBuilder.Entity<MedioDePago>(entity =>
        {
            entity.HasKey(e => e.MedioDePagoId).HasName("PK__Medio_De__BBFD2763F66049B8");
        });


        modelBuilder.Entity<Operacion>(entity =>
        {
            entity.HasKey(e => e.OperacionId).HasName("PK__Operacio__8A668AF727CE3426");

            entity.HasOne(d => d.Comic).WithMany(p => p.Operacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operacion__Comic__5070F446");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Operacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operacion__Emple__52593CB8");

            entity.HasOne(d => d.Local).WithMany(p => p.Operacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operacion__Local__5165187F");

            entity.HasOne(d => d.MedioDePago).WithMany(p => p.Operacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operacion__Medio__4E88ABD4");

            entity.HasOne(d => d.TipoOperacion).WithMany(p => p.Operacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operacion__Tipo___4F7CD00D");
        });

        modelBuilder.Entity<OperacionClienteJIM>().ToTable("Operacion_ClienteJIM", "dbo");


        modelBuilder.Entity<OperacionClienteJIM>()
    .HasKey(le => new { le.OperacionId, le.ClienteId });

        






        modelBuilder.Entity<StockComic>(entity =>
        {
            entity.HasKey(e => e.StockComicId).HasName("PK__Stock_Co__3A77E093701FB08A");

            entity.HasOne(d => d.Comic).WithMany(p => p.StockComics)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_Com__Comic__47DBAE45");

            entity.HasOne(d => d.Local).WithMany(p => p.StockComics)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_Com__Local__46E78A0C");
        });

        modelBuilder.Entity<TipoOperacion>(entity =>
        {
            entity.HasKey(e => e.TipoOperacionId).HasName("PK__Tipo_Ope__F75BE529816D69A1");
        });

        OnModelCreatingPartial(modelBuilder);
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
