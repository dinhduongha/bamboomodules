using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockImmediateTransferLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockImmediateTransferLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_immediate_transfer_line_pkey");

                        entity.ToTable("stock_immediate_transfer_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ImmediateTransferId).HasColumnName("immediate_transfer_id");
                        entity.Property(e => e.PickingId).HasColumnName("picking_id");
                        entity.Property(e => e.ToImmediate).HasColumnName("to_immediate");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockImmediateTransferLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_immediate_transfer_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_immediate_transfer_line_create_uid_fkey");

                        entity.HasOne(d => d.ImmediateTransfer).WithMany(p => p.StockImmediateTransferLine)
                            .HasForeignKey(d => d.ImmediateTransferId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_immediate_transfer_line_immediate_transfer_id_fkey");

                        entity.HasOne(d => d.Picking).WithMany(p => p.StockImmediateTransferLine)
                            .HasForeignKey(d => d.PickingId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_immediate_transfer_line_picking_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockImmediateTransferLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_immediate_transfer_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_immediate_transfer_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}