using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductValue(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductValue>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_value_pkey");

                        entity.ToTable("product_value");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.Date)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.LotId).HasColumnName("lot_id");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.Value).HasColumnName("value");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProductValue) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_value_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_value_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductValueCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_value_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_value_create_uid_fkey");

                        entity.HasOne(d => d.Lot).WithMany(p => p.ProductValue)
                            .HasForeignKey(d => d.LotId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_value_lot_id_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.ProductValue)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_value_move_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.ProductValue) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_value_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_value_product_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.ProductValueUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_value_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_value_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductValueWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_value_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_value_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}