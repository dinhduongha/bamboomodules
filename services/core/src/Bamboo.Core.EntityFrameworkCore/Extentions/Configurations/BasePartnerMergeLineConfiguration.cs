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
        public static void ConfigureBasePartnerMergeLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasePartnerMergeLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("base_partner_merge_line_pkey");

                entity.ToTable("base_partner_merge_line");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AggrIds).HasColumnName("aggr_ids");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MinId).HasColumnName("min_id");
                entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_partner_merge_line_create_uid_fkey");

                entity.HasOne(d => d.Wizard).WithMany(p => p.BasePartnerMergeLines)
                    .HasForeignKey(d => d.WizardId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_partner_merge_line_wizard_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_partner_merge_line_write_uid_fkey");
            });
        }
    }
}