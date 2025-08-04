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
        public static void ConfigureChooseDeliveryPackage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChooseDeliveryPackage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("choose_delivery_package_pkey");

                entity.ToTable("choose_delivery_package");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("choose_delivery_package_create_uid_fkey");

                entity.HasOne(d => d.DeliveryPackageType).WithMany()
                    .HasForeignKey(d => d.DeliveryPackageTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("choose_delivery_package_delivery_package_type_id_fkey");

                entity.HasOne(d => d.Picking).WithMany()
                    .HasForeignKey(d => d.PickingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("choose_delivery_package_picking_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("choose_delivery_package_write_uid_fkey");
            });
        }
    }
}