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
        public static void ConfigureChooseDeliveryPackage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ChooseDeliveryPackage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("choose_delivery_package_pkey");

            entity.ToTable("choose_delivery_package");

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
            entity.Property(e => e.DeliveryPackageTypeId).HasColumnName("delivery_package_type_id");
            entity.Property(e => e.PickingId).HasColumnName("picking_id");
            entity.Property(e => e.ShippingWeight).HasColumnName("shipping_weight");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ChooseDeliveryPackageCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("choose_delivery_package_create_uid_fkey");

            entity.HasOne(d => d.DeliveryPackageType).WithMany(p => p.ChooseDeliveryPackage)
                .HasForeignKey(d => d.DeliveryPackageTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("choose_delivery_package_delivery_package_type_id_fkey");

            entity.HasOne(d => d.Picking).WithMany(p => p.ChooseDeliveryPackage)
                .HasForeignKey(d => d.PickingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("choose_delivery_package_picking_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ChooseDeliveryPackageWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("choose_delivery_package_write_uid_fkey");
            });
        }
    }
}