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
        public static void ConfigureDeliveryPriceRule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryPriceRule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("delivery_price_rule_pkey");

                entity.ToTable("delivery_price_rule");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CarrierId).HasColumnName("carrier_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ListBasePrice).HasColumnName("list_base_price");
                entity.Property(e => e.ListPrice).HasColumnName("list_price");
                entity.Property(e => e.MaxValue).HasColumnName("max_value");
                entity.Property(e => e.Operator).HasColumnName("operator");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.Variable).HasColumnName("variable");
                entity.Property(e => e.VariableFactor).HasColumnName("variable_factor");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Carrier).WithMany(p => p.DeliveryPriceRules)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("delivery_price_rule_carrier_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("delivery_price_rule_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("delivery_price_rule_write_uid_fkey");
            });
        }
    }
}