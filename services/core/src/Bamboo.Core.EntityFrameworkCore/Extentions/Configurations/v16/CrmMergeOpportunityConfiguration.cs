using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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
                        entity.Property(e => e.TeamId).HasColumnName("team_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmMergeOpportunityCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_merge_opportunity_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_merge_opportunity_create_uid_fkey");

                        entity.HasOne(d => d.Team).WithMany(p => p.CrmMergeOpportunity)
                            .HasForeignKey(d => d.TeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_merge_opportunity_team_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.CrmMergeOpportunityUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_merge_opportunity_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_merge_opportunity_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmMergeOpportunityWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_merge_opportunity_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_merge_opportunity_write_uid_fkey");

                        // entity.HasMany(d => d.Opportunity).WithMany(p => p.Merge)
                        entity.HasMany(d => d.Opportunity).WithMany(p => p.Merge)
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
                                    j.IndexerProperty<Guid>("MergeId").HasColumnName("merge_id");
                                    j.IndexerProperty<Guid>("OpportunityId").HasColumnName("opportunity_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}