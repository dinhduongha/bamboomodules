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
        public static void ConfigurePrivacyLookupWizardLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivacyLookupWizardLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("privacy_lookup_wizard_line_pkey");

                entity.ToTable("privacy_lookup_wizard_line");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ExecutionDetails).HasColumnName("execution_details");
                entity.Property(e => e.HasActive).HasColumnName("has_active");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.IsUnlinked).HasColumnName("is_unlinked");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
                entity.Property(e => e.ResName).HasColumnName("res_name");
                entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("privacy_lookup_wizard_line_create_uid_fkey");

                entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.PrivacyLookupWizardLines)
                    .HasForeignKey(d => d.ResModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("privacy_lookup_wizard_line_res_model_id_fkey");

                entity.HasOne(d => d.Wizard).WithMany(p => p.PrivacyLookupWizardLines)
                    .HasForeignKey(d => d.WizardId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("privacy_lookup_wizard_line_wizard_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("privacy_lookup_wizard_line_write_uid_fkey");
            });
        }
    }
}