using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockBackorderConfirmationLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockBackorderConfirmationLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_backorder_confirmation_line_pkey");

                        entity.ToTable("stock_backorder_confirmation_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BackorderConfirmationId).HasColumnName("backorder_confirmation_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.PickingId).HasColumnName("picking_id");
                        entity.Property(e => e.ToBackorder).HasColumnName("to_backorder");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.BackorderConfirmation).WithMany(p => p.StockBackorderConfirmationLine)
                            .HasForeignKey(d => d.BackorderConfirmationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_backorder_confirmation_lin_backorder_confirmation_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockBackorderConfirmationLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_backorder_confirmation_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_backorder_confirmation_line_create_uid_fkey");

                        entity.HasOne(d => d.Picking).WithMany(p => p.StockBackorderConfirmationLine)
                            .HasForeignKey(d => d.PickingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_backorder_confirmation_line_picking_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockBackorderConfirmationLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_backorder_confirmation_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_backorder_confirmation_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}