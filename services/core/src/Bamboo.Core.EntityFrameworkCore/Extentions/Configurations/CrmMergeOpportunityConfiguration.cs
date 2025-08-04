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
        public static void ConfigureCrmMergeOpportunity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmMergeOpportunity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crm_merge_opportunity_pkey");

                entity.ToTable("crm_merge_opportunity");

                entity.HasIndex(e => e.TenantId, "crm_merge_opportunity_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.TeamId).HasColumnName("team_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_merge_opportunity_create_uid_fkey");

                entity.HasOne(d => d.Team).WithMany(p => p.CrmMergeOpportunities)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_merge_opportunity_team_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_merge_opportunity_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_merge_opportunity_write_uid_fkey");

                //entity.HasMany(d => d.Opportunities).WithMany(p => p.Merges)
                entity.HasMany<CrmLead>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MergeOpportunityRel",
                        r => r.HasOne<CrmLead>().WithMany()
                            .HasForeignKey("OpportunityId")
                            .HasConstraintName("merge_opportunity_rel_opportunity_id_fkey"),
                        l => l.HasOne<CrmMergeOpportunity>().WithMany()
                            .HasForeignKey("MergeId")
                            .HasConstraintName("merge_opportunity_rel_merge_id_fkey"),
                        j =>
                        {
                            j.HasKey("MergeId", "OpportunityId").HasName("merge_opportunity_rel_pkey");
                            j.ToTable("merge_opportunity_rel");
                            j.HasIndex(new[] { "OpportunityId", "MergeId" }, "merge_opportunity_rel_opportunity_id_merge_id_idx");
                        });
            });
        }
    }
}