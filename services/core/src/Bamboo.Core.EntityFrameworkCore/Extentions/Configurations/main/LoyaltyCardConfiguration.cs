using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLoyaltyCard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LoyaltyCard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("loyalty_card_pkey");

                        entity.ToTable("loyalty_card");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.PartnerId, "loyalty_card__partner_id_index");

                        entity.HasIndex(e => e.ProgramId, "loyalty_card__program_id_index").HasFilter("(program_id IS NOT NULL)");

                        entity.HasIndex(e => e.Code, "loyalty_card_card_code_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Code).HasColumnName("code");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
                        entity.Property(e => e.OrderId).HasColumnName("order_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Points).HasColumnName("points");
                        entity.Property(e => e.ProgramId).HasColumnName("program_id");
                        entity.Property(e => e.SourcePosOrderId).HasColumnName("source_pos_order_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.LoyaltyCard) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_card_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_card_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LoyaltyCardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_card_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_card_create_uid_fkey");

                        entity.HasOne(d => d.Order).WithMany(p => p.LoyaltyCard)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_card_order_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.LoyaltyCard) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_card_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_card_partner_id_fkey");

                        entity.HasOne(d => d.Program).WithMany(p => p.LoyaltyCard)
                            .HasForeignKey(d => d.ProgramId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("loyalty_card_program_id_fkey");

                        entity.HasOne(d => d.SourcePosOrder).WithMany(p => p.LoyaltyCard)
                            .HasForeignKey(d => d.SourcePosOrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_card_source_pos_order_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LoyaltyCardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_card_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_card_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}