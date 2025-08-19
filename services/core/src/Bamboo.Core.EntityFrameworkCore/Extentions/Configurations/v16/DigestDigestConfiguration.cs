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
        public static void ConfigureDigestDigest(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<DigestDigest>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("digest_digest_pkey");

            entity.ToTable("digest_digest");

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
            entity.Property(e => e.KpiAccountTotalRevenue).HasColumnName("kpi_account_total_revenue");
            entity.Property(e => e.KpiAllSaleTotal).HasColumnName("kpi_all_sale_total");
            entity.Property(e => e.KpiCrmLeadCreated).HasColumnName("kpi_crm_lead_created");
            entity.Property(e => e.KpiCrmOpportunitiesWon).HasColumnName("kpi_crm_opportunities_won");
            entity.Property(e => e.KpiHrRecruitmentNewColleagues).HasColumnName("kpi_hr_recruitment_new_colleagues");
            entity.Property(e => e.KpiLivechatConversations).HasColumnName("kpi_livechat_conversations");
            entity.Property(e => e.KpiLivechatRating).HasColumnName("kpi_livechat_rating");
            entity.Property(e => e.KpiLivechatResponse).HasColumnName("kpi_livechat_response");
            entity.Property(e => e.KpiMailMessageTotal).HasColumnName("kpi_mail_message_total");
            entity.Property(e => e.KpiPosTotal).HasColumnName("kpi_pos_total");
            entity.Property(e => e.KpiProjectTaskOpened).HasColumnName("kpi_project_task_opened");
            entity.Property(e => e.KpiResUsersConnected).HasColumnName("kpi_res_users_connected");
            entity.Property(e => e.KpiWebsiteSaleTotal).HasColumnName("kpi_website_sale_total");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.NextRunDate).HasColumnName("next_run_date");
            entity.Property(e => e.Periodicity).HasColumnName("periodicity");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.DigestDigest)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("digest_digest_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.DigestDigestCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("digest_digest_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.DigestDigestWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("digest_digest_write_uid_fkey");

            // entity.HasMany(d => d.ResUsers).WithMany(p => p.DigestDigest)
            entity.HasMany(d => d.ResUsers).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "DigestDigestResUsersRel",
                    r => r.HasOne<ResUsers>().WithMany()
                        .HasForeignKey("ResUsersId")
                        .HasConstraintName("digest_digest_res_users_rel_res_users_id_fkey"),
                    l => l.HasOne<DigestDigest>().WithMany()
                        .HasForeignKey("DigestDigestId")
                        .HasConstraintName("digest_digest_res_users_rel_digest_digest_id_fkey"),
                    j =>
                    {
                        j.HasKey("DigestDigestId", "ResUsersId").HasName("digest_digest_res_users_rel_pkey");
                        j.ToTable("digest_digest_res_users_rel");
                        j.HasIndex(new[] { "ResUsersId", "DigestDigestId" }, "digest_digest_res_users_rel_res_users_id_digest_digest_id_idx");
                        j.IndexerProperty<Guid>("DigestDigestId").HasColumnName("digest_digest_id");
                        j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                    });
            });
        }
    }
}