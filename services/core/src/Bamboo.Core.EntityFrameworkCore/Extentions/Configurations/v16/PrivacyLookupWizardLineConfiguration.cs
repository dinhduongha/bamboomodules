using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PrivacyLookupWizardLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("privacy_lookup_wizard_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("privacy_lookup_wizard_line_create_uid_fkey");

                        entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.PrivacyLookupWizardLine)
                            .HasForeignKey(d => d.ResModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("privacy_lookup_wizard_line_res_model_id_fkey");

                        entity.HasOne(d => d.Wizard).WithMany(p => p.PrivacyLookupWizardLine)
                            .HasForeignKey(d => d.WizardId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("privacy_lookup_wizard_line_wizard_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PrivacyLookupWizardLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("privacy_lookup_wizard_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("privacy_lookup_wizard_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}