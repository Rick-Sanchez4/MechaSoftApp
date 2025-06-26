using MechaSoft.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechaSoft.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        // Chave primária
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedNever();

        // Configuração do Value Object Name
        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");

            nameBuilder.Property(n => n.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("LastName");

            nameBuilder.Ignore(n => n.FullName);
        });

        // Propriedades básicas
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.CustomerType)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200);

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // Configuração do Value Object Address
        builder.OwnsOne(x => x.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Street)
                .HasMaxLength(200)
                .HasColumnName("Address_Street");

            addressBuilder.Property(a => a.City)
                .HasMaxLength(100)
                .HasColumnName("Address_City");

            addressBuilder.Property(a => a.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("Address_PostalCode");

            addressBuilder.Property(a => a.Country)
                .HasMaxLength(100)
                .HasColumnName("Address_Country");
        });

        // Configuração do Value Object Money (CreditLimit)
        builder.OwnsOne(x => x.CreditLimit, moneyBuilder =>
        {
            moneyBuilder.Property(m => m.Amount)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("CreditLimit_Amount");

            moneyBuilder.Property(m => m.Currency)
                .HasMaxLength(3)
                .HasColumnName("CreditLimit_Currency");
        });

        // Propriedades de auditoria
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasMaxLength(100);

        builder.Property(x => x.UpdatedBy)
            .HasMaxLength(100);

        // Relacionamentos
        builder.HasMany(x => x.Vehicles)
            .WithOne(v => v.Customer)
            .HasForeignKey(v => v.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ServiceOrders)
            .WithOne(so => so.Customer)
            .HasForeignKey(so => so.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índices
        builder.HasIndex(x => x.Email)
            .IsUnique()
            .HasDatabaseName("IX_Customer_Email");

        builder.HasIndex(x => x.CustomerType)
            .HasDatabaseName("IX_Customer_CustomerType");

        builder.HasIndex(x => x.IsActive)
            .HasDatabaseName("IX_Customer_IsActive");
    }
}