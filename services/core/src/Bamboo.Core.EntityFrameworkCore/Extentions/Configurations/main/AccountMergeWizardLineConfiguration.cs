using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountMergeWizardLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountMergeWizardLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_merge_wizard_line_pkey");

                        entity.ToTable("account_merge_wizard_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountId).HasColumnName("account_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DisplayType).HasColumnName("display_type");
                        entity.Property(e => e.GroupingKey).HasColumnName("grouping_key");
                        entity.Property(e => e.IsSelected).HasColumnName("is_selected");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Account).WithMany(p => p.AccountMergeWizardLine) .HasForeignKey(d => d.AccountId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("account_merge_wizard_line_account_id_fkey");
                        entity.HasOne(d => d.Account).WithMany()
                            .HasForeignKey(d => d.AccountId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_merge_wizard_line_account_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountMergeWizardLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_merge_wizard_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_merge_wizard_line_create_uid_fkey");

                        entity.HasOne(d => d.Wizard).WithMany(p => p.AccountMergeWizardLine)
                            .HasForeignKey(d => d.WizardId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_merge_wizard_line_wizard_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountMergeWizardLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_merge_wizard_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_merge_wizard_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}