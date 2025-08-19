using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosPackOperationLot(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosPackOperationLot>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_pack_operation_lot_pkey");

            entity.ToTable("pos_pack_operation_lot");

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
            entity.Property(e => e.LotName).HasColumnName("lot_name");
            entity.Property(e => e.PosOrderLineId).HasColumnName("pos_order_line_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.PosPackOperationLotCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pos_pack_operation_lot_create_uid_fkey");

            entity.HasOne(d => d.PosOrderLine).WithMany(p => p.PosPackOperationLot)
                .HasForeignKey(d => d.PosOrderLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pos_pack_operation_lot_pos_order_line_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.PosPackOperationLotWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pos_pack_operation_lot_write_uid_fkey");
            });
        }
    }
}