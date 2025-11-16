using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSaleLoyaltyRewardWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SaleLoyaltyRewardWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sale_loyalty_reward_wizard_pkey");

                        entity.ToTable("sale_loyalty_reward_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.OrderId).HasColumnName("order_id");
                        entity.Property(e => e.SelectedProductId).HasColumnName("selected_product_id");
                        entity.Property(e => e.SelectedRewardId).HasColumnName("selected_reward_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SaleLoyaltyRewardWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_loyalty_reward_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_loyalty_reward_wizard_create_uid_fkey");

                        entity.HasOne(d => d.Order).WithMany(p => p.SaleLoyaltyRewardWizard)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("sale_loyalty_reward_wizard_order_id_fkey");

                        // entity.HasOne(d => d.SelectedProduct).WithMany(p => p.SaleLoyaltyRewardWizard) .HasForeignKey(d => d.SelectedProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_loyalty_reward_wizard_selected_product_id_fkey");
                        entity.HasOne(d => d.SelectedProduct).WithMany()
                            .HasForeignKey(d => d.SelectedProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_loyalty_reward_wizard_selected_product_id_fkey");

                        entity.HasOne(d => d.SelectedReward).WithMany(p => p.SaleLoyaltyRewardWizard)
                            .HasForeignKey(d => d.SelectedRewardId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_loyalty_reward_wizard_selected_reward_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SaleLoyaltyRewardWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_loyalty_reward_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_loyalty_reward_wizard_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}