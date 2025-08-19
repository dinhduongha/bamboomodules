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
        public static void ConfigureAccountReconcileModelPartnerMapping(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountReconcileModelPartnerMapping>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_reconcile_model_partner_mapping_pkey");

            entity.ToTable("account_reconcile_model_partner_mapping");

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
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.NarrationRegex).HasColumnName("narration_regex");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PaymentRefRegex).HasColumnName("payment_ref_regex");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountReconcileModelPartnerMappingCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_reconcile_model_partner_mapping_create_uid_fkey");

            entity.HasOne(d => d.Model).WithMany(p => p.AccountReconcileModelPartnerMapping)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("account_reconcile_model_partner_mapping_model_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.AccountReconcileModelPartnerMapping)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("account_reconcile_model_partner_mapping_partner_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountReconcileModelPartnerMappingWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_reconcile_model_partner_mapping_write_uid_fkey");
            });
        }
    }
}