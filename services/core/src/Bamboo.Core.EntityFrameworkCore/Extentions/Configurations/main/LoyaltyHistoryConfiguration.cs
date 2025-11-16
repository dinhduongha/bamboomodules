using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLoyaltyHistory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LoyaltyHistory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("loyalty_history_pkey");

                        entity.ToTable("loyalty_history");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CardId, "loyalty_history__card_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CardId).HasColumnName("card_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Issued).HasColumnName("issued");
                        entity.Property(e => e.OrderId).HasColumnName("order_id");
                        entity.Property(e => e.OrderModel).HasColumnName("order_model");
                        entity.Property(e => e.Used).HasColumnName("used");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Card).WithMany(p => p.LoyaltyHistory)
                            .HasForeignKey(d => d.CardId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("loyalty_history_card_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LoyaltyHistoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_history_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_history_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LoyaltyHistoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_history_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_history_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}