using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
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

                entity.HasIndex(e => e.TenantId, "procurement_group_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("procurement_group_create_uid_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("procurement_group_partner_id_fkey");

                entity.HasOne(d => d.PosOrder).WithMany(p => p.ProcurementGroups)
                    .HasForeignKey(d => d.PosOrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("procurement_group_pos_order_id_fkey");

                entity.HasOne(d => d.Sale).WithMany(p => p.ProcurementGroups)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("procurement_group_sale_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("procurement_group_write_uid_fkey");
            });
        }
    }
}