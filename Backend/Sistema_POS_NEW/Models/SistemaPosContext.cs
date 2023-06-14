using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sistema_POS_NEW.Models;

public partial class SistemaPosContext : DbContext
{
    public SistemaPosContext()
    {
    }

    public SistemaPosContext(DbContextOptions<SistemaPosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cajero> Cajeros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<TipoPagoFactura> TipoPagoFacturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UMJDM2Q; Database=Sistema_POS_; Trusted_Connection=True;Encrypt=False;TrustServerCertificate=Yes ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admin__B2C3ADE5F38F5F5C");

            entity.ToTable("Admin");

            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.ApellidoAdmin)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.GeneroAdmin)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.NombreAdmin)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PswdAdmin)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioAdmin)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cajero>(entity =>
        {
            entity.HasKey(e => e.IdCajero).HasName("PK__Cajero__1F02D5982F5F54D3");

            entity.ToTable("Cajero");

            entity.Property(e => e.IdCajero).HasColumnName("idCajero");
            entity.Property(e => e.ApellidoCajero)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.GeneroCajero)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.NombreCajero)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PswdCajero)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCajero)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE25723C00");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Dire)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EstadoCliente)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.GeneroCliente)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PswdCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCliente)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__3CD5687E03D5C35F");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Producto");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Factura");
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TotalPagar)
                .HasMaxLength(40)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
              //  .HasForeignKey(d => d.IdCliente)
                //.HasConstraintName("FK__Factura__IdClien__02084FDA");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__07F4A1328656BA23");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
           // entity.Property(e => e.ImgProducto)
             //   .HasMaxLength(50)
               // .IsUnicode(false);
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorProducto)
                .HasMaxLength(4)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
              //  .HasForeignKey(d => d.IdProveedor)
                //.OnDelete(DeleteBehavior.Cascade)
                //.HasConstraintName("FK__Producto__idProv__02FC7413");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__A3FA8E6B2EDCD933");

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.CelularProveedor)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Celular_Proveedor");
            entity.Property(e => e.EntidadProveedor)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoFijoProveedor).HasColumnName("Telefono_Fijo_Proveedor");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.IdSucursales).HasName("PK__Sucursal__5556C94CAC633240");

            entity.Property(e => e.IdSucursales).HasColumnName("idSucursales");
            entity.Property(e => e.DireccionSucursal)
                .HasMaxLength(30)
                .IsUnicode(false);
            //entity.Property(e => e.EstadoSucursal)
              //  .HasMaxLength(4)
                //.IsUnicode(false);
            entity.Property(e => e.LocalidadSucursal)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPagoFactura>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__TipoPago__BD2295AD5142C71C");

            entity.ToTable("TipoPagoFactura");

            entity.Property(e => e.IdPago).HasColumnName("idPago");
            entity.Property(e => e.ActivoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
