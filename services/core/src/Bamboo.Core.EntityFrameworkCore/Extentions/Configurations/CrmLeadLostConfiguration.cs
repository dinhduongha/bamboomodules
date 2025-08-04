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
        public static void ConfigureCrmLeadLost(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmLeadLost>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crm_lead_lost_pkey");

                entity.ToTable("crm_lead_lost");

                entity.HasIndex(e => e.TenantId, "crm_lead_lost_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LostFeedback).HasColumnName("lost_feedback");
                entity.Property(e => e.LostReasonId).HasColumnName("lost_reason_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_lost_create_uid_fkey");

                entity.HasOne(d => d.LostReason).WithMany(p => p.CrmLeadLosts)
                    .HasForeignKey(d => d.LostReasonId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_lost_lost_reason_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_lost_write_uid_fkey");

                entity.HasMany(d => d.CrmLeads).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "CrmLeadCrmLeadLostRel",
                        r => r.HasOne<CrmLead>().WithMany()
                            .HasForeignKey("CrmLeadId")
                            .HasConstraintName("crm_lead_crm_lead_lost_rel_crm_lead_id_fkey"),
                        l => l.HasOne<CrmLeadLost>().WithMany()
                            .HasForeignKey("CrmLeadLostId")
                            .HasConstraintName("crm_lead_crm_lead_lost_rel_crm_lead_lost_id_fkey"),
                        j =>
                        {
                            j.HasKey("CrmLeadLostId", "CrmLeadId").HasName("crm_lead_crm_lead_lost_rel_pkey");
                            j.ToTable("crm_lead_crm_lead_lost_rel");
                            j.HasIndex(new[] { "CrmLeadId", "CrmLeadLostId" }, "crm_lead_crm_lead_lost_rel_crm_lead_id_crm_lead_lost_id_idx");
                            j.IndexerProperty<Guid>("CrmLeadLostId").HasColumnName("crm_lead_lost_id");
                            j.IndexerProperty<Guid>("CrmLeadId").HasColumnName("crm_lead_id");
                        });
            });
        }
    }
}