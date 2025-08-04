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
        public static void ConfigureChooseDeliveryCarrier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChooseDeliveryCarrier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("choose_delivery_carrier_pkey");

                entity.ToTable("choose_delivery_carrier");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CarrierId).HasColumnName("carrier_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DeliveryMessage).HasColumnName("delivery_message");
                entity.Property(e => e.DeliveryPrice).HasColumnName("delivery_price");
                entity.Property(e => e.DisplayPrice).HasColumnName("display_price");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.WeightUomName).HasColumnName("weight_uom_name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Carrier).WithMany(p => p.ChooseDeliveryCarriers)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("choose_delivery_carrier_carrier_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("choose_delivery_carrier_create_uid_fkey");

                entity.HasOne(d => d.Order).WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("choose_delivery_carrier_order_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("choose_delivery_carrier_write_uid_fkey");
            });
        }
    }
}