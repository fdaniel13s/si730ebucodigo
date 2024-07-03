using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.ValueObjects;
using si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Configure relationships and entitys
        builder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            entity.Property(p => p.Brand).IsRequired().HasMaxLength(120);
            entity.Property(p => p.Model).IsRequired().HasMaxLength(120);
            entity.Property(p => p.SerialNumber).IsRequired().HasMaxLength(120);
            entity.HasIndex(p => p.SerialNumber).IsUnique();
            entity.Property(p => p.Status).IsRequired();
            entity.Ignore(p => p.StatusDescription);
        });
        
        //MaintenanceActivity
        builder.Entity<MaintenanceActivity>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Summary).IsRequired().HasMaxLength(120);
            entity.Property(m => m.Description).IsRequired().HasMaxLength(500);
            // Asumiendo que ActivityResult es un enumerado, convertirlo a string para la base de datos
            entity.Property(m => m.ActivityResult)
                .HasConversion(
                    v => v.ToString(),
                    v => (EActivityResult)Enum.Parse(typeof(EActivityResult), v))
                .IsRequired();
        });
        
        //Relation one to one with foreign key ProductSerialNumber
        builder.Entity<MaintenanceActivity>(entity =>
        {
            entity.HasKey(m => m.Id); // Asegura que MaintenanceActivity tenga una clave primaria.

            entity.HasOne(m => m.Product) // Indica la relación uno a uno con Product.
                .WithOne(p => p.MaintenanceActivity) // Indica la navegación inversa.
                .HasForeignKey<MaintenanceActivity>(m => m.ProductSerialNumber) // Usa ProductSerialNumber como FK.
                .HasPrincipalKey<Product>(p => p.SerialNumber); // Indica que SerialNumber es la clave principal en Product para esta relación.
        });
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}