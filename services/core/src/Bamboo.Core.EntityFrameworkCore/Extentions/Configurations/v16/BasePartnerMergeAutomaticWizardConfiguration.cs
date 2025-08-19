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
        public static void ConfigureBasePartnerMergeAutomaticWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BasePartnerMergeAutomaticWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_partner_merge_automatic_wizard_pkey");

            entity.ToTable("base_partner_merge_automatic_wizard");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrentLineId).HasColumnName("current_line_id");
            entity.Property(e => e.DstPartnerId).HasColumnName("dst_partner_id");
            entity.Property(e => e.ExcludeContact).HasColumnName("exclude_contact");
            entity.Property(e => e.ExcludeJournalItem).HasColumnName("exclude_journal_item");
            entity.Property(e => e.GroupByEmail).HasColumnName("group_by_email");
            entity.Property(e => e.GroupByIsCompany).HasColumnName("group_by_is_company");
            entity.Property(e => e.GroupByName).HasColumnName("group_by_name");
            entity.Property(e => e.GroupByParentId).HasColumnName("group_by_parent_id");
            entity.Property(e => e.GroupByVat).HasColumnName("group_by_vat");
            entity.Property(e => e.MaximumGroup).HasColumnName("maximum_group");
            entity.Property(e => e.NumberGroup).HasColumnName("number_group");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BasePartnerMergeAutomaticWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_partner_merge_automatic_wizard_create_uid_fkey");

            entity.HasOne(d => d.CurrentLine).WithMany(p => p.BasePartnerMergeAutomaticWizard)
                .HasForeignKey(d => d.CurrentLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_partner_merge_automatic_wizard_current_line_id_fkey");

            entity.HasOne(d => d.DstPartner).WithMany()
                .HasForeignKey(d => d.DstPartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_partner_merge_automatic_wizard_dst_partner_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BasePartnerMergeAutomaticWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_partner_merge_automatic_wizard_write_uid_fkey");

            // entity.HasMany(d => d.ResPartner).WithMany(p => p.BasePartnerMergeAutomaticWizardNavigation)
            entity.HasMany(d => d.ResPartner).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "BasePartnerMergeAutomaticWizardResPartnerRel",
                    r => r.HasOne<ResPartner>().WithMany()
                        .HasForeignKey("ResPartnerId")
                        .HasConstraintName("base_partner_merge_automatic_wizard_res_par_res_partner_id_fkey"),
                    l => l.HasOne<BasePartnerMergeAutomaticWizard>().WithMany()
                        .HasForeignKey("BasePartnerMergeAutomaticWizardId")
                        .HasConstraintName("base_partner_merge_automatic__base_partner_merge_automatic_fkey"),
                    j =>
                    {
                        j.HasKey("BasePartnerMergeAutomaticWizardId", "ResPartnerId").HasName("base_partner_merge_automatic_wizard_res_partner_rel_pkey");
                        j.ToTable("base_partner_merge_automatic_wizard_res_partner_rel");
                        j.HasIndex(new[] { "ResPartnerId", "BasePartnerMergeAutomaticWizardId" }, "base_partner_merge_automatic__res_partner_id_base_partner_m_idx");
                        j.IndexerProperty<Guid>("BasePartnerMergeAutomaticWizardId").HasColumnName("base_partner_merge_automatic_wizard_id");
                        j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                    });
            });
        }
    }
}