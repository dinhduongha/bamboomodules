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
        public static void ConfigureMrpWorkcenterCapacity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpWorkcenterCapacity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_workcenter_capacity_pkey");

                entity.ToTable("mrp_workcenter_capacity");

                entity.HasIndex(e => e.TenantId, "mrp_workcenter_capacity_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.WorkcenterId, e.ProductId }, "mrp_workcenter_capacity_unique_product").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Capacity).HasColumnName("capacity");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.TimeStart).HasColumnName("time_start");
                entity.Property(e => e.TimeStop).HasColumnName("time_stop");
                entity.Property(e => e.WorkcenterId).HasColumnName("workcenter_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workcenter_capacity_create_uid_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.MrpWorkcenterCapacities)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_workcenter_capacity_product_id_fkey");

                entity.HasOne(d => d.Workcenter).WithMany(p => p.MrpWorkcenterCapacities)
                    .HasForeignKey(d => d.WorkcenterId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_workcenter_capacity_workcenter_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workcenter_capacity_write_uid_fkey");
            });
        }
    }
}