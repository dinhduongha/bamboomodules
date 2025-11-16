using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLunchTopping(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LunchTopping>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("lunch_topping_pkey");

                        entity.ToTable("lunch_topping");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.SupplierId, "lunch_topping__supplier_id_index").HasFilter("(supplier_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Price).HasColumnName("price");
                        entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
                        entity.Property(e => e.ToppingCategory).HasColumnName("topping_category");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.LunchTopping) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_topping_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_topping_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LunchToppingCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_topping_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_topping_create_uid_fkey");

                        entity.HasOne(d => d.Supplier).WithMany(p => p.LunchTopping)
                            .HasForeignKey(d => d.SupplierId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("lunch_topping_supplier_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LunchToppingWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lunch_topping_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lunch_topping_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}