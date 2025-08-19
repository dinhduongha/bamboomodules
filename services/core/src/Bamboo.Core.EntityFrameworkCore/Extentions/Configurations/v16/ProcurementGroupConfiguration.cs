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
        public static void ConfigureProcurementGroup(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProcurementGroup>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("procurement_group_pkey");

            entity.ToTable("procurement_group");

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
            entity.Property(e => e.MoveType).HasColumnName("move_type");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PosOrderId).HasColumnName("pos_order_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProcurementGroupCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("procurement_group_create_uid_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.ProcurementGroup)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("procurement_group_partner_id_fkey");

            entity.HasOne(d => d.PosOrderNavigation).WithMany(p => p.ProcurementGroupNavigation)
                .HasForeignKey(d => d.PosOrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("procurement_group_pos_order_id_fkey");

            entity.HasOne(d => d.Sale).WithMany(p => p.ProcurementGroup)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("procurement_group_sale_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProcurementGroupWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("procurement_group_write_uid_fkey");
            });
        }
    }
}