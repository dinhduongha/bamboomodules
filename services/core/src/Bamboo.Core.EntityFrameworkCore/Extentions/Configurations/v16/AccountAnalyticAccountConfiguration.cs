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
        public static void ConfigureAccountAnalyticAccount(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAnalyticAccount>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_analytic_account_pkey");

            entity.ToTable("account_analytic_account");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Code, "account_analytic_account_code_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Code).HasColumnName("code");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.RootPlanId).HasColumnName("root_plan_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountAnalyticAccount)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_analytic_account_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAnalyticAccountCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_analytic_account_create_uid_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAnalyticAccount)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_analytic_account_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.AccountAnalyticAccount)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_analytic_account_partner_id_fkey");

            entity.HasOne(d => d.Plan).WithMany(p => p.AccountAnalyticAccountPlan)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_analytic_account_plan_id_fkey");

            entity.HasOne(d => d.RootPlan).WithMany(p => p.AccountAnalyticAccountRootPlan)
                .HasForeignKey(d => d.RootPlanId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_analytic_account_root_plan_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAnalyticAccountWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_analytic_account_write_uid_fkey");

            // entity.HasMany(d => d.MrpBom).WithMany(p => p.AccountAnalyticAccount)
            entity.HasMany(d => d.MrpBom).WithMany(p => p.AccountAnalyticAccount)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAnalyticAccountMrpBomRel",
                    r => r.HasOne<MrpBom>().WithMany()
                        .HasForeignKey("MrpBomId")
                        .HasConstraintName("account_analytic_account_mrp_bom_rel_mrp_bom_id_fkey"),
                    l => l.HasOne<AccountAnalyticAccount>().WithMany()
                        .HasForeignKey("AccountAnalyticAccountId")
                        .HasConstraintName("account_analytic_account_mrp_b_account_analytic_account_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountAnalyticAccountId", "MrpBomId").HasName("account_analytic_account_mrp_bom_rel_pkey");
                        j.ToTable("account_analytic_account_mrp_bom_rel");
                        j.HasIndex(new[] { "MrpBomId", "AccountAnalyticAccountId" }, "account_analytic_account_mrp__mrp_bom_id_account_analytic_a_idx");
                        j.IndexerProperty<Guid>("AccountAnalyticAccountId").HasColumnName("account_analytic_account_id");
                        j.IndexerProperty<Guid>("MrpBomId").HasColumnName("mrp_bom_id");
                    });

            // entity.HasMany(d => d.MrpProduction).WithMany(p => p.AccountAnalyticAccount)
            entity.HasMany(d => d.MrpProduction).WithMany(p => p.AccountAnalyticAccount)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAnalyticAccountMrpProductionRel",
                    r => r.HasOne<MrpProduction>().WithMany()
                        .HasForeignKey("MrpProductionId")
                        .HasConstraintName("account_analytic_account_mrp_production__mrp_production_id_fkey"),
                    l => l.HasOne<AccountAnalyticAccount>().WithMany()
                        .HasForeignKey("AccountAnalyticAccountId")
                        .HasConstraintName("account_analytic_account_mrp_p_account_analytic_account_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountAnalyticAccountId", "MrpProductionId").HasName("account_analytic_account_mrp_production_rel_pkey");
                        j.ToTable("account_analytic_account_mrp_production_rel");
                        j.HasIndex(new[] { "MrpProductionId", "AccountAnalyticAccountId" }, "account_analytic_account_mrp__mrp_production_id_account_ana_idx");
                        j.IndexerProperty<Guid>("AccountAnalyticAccountId").HasColumnName("account_analytic_account_id");
                        j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                    });

            // entity.HasMany(d => d.MrpWorkcenter).WithMany(p => p.AccountAnalyticAccount)
            entity.HasMany(d => d.MrpWorkcenter).WithMany(p => p.AccountAnalyticAccount)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAnalyticAccountMrpWorkcenterRel",
                    r => r.HasOne<MrpWorkcenter>().WithMany()
                        .HasForeignKey("MrpWorkcenterId")
                        .HasConstraintName("account_analytic_account_mrp_workcenter__mrp_workcenter_id_fkey"),
                    l => l.HasOne<AccountAnalyticAccount>().WithMany()
                        .HasForeignKey("AccountAnalyticAccountId")
                        .HasConstraintName("account_analytic_account_mrp_w_account_analytic_account_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountAnalyticAccountId", "MrpWorkcenterId").HasName("account_analytic_account_mrp_workcenter_rel_pkey");
                        j.ToTable("account_analytic_account_mrp_workcenter_rel");
                        j.HasIndex(new[] { "MrpWorkcenterId", "AccountAnalyticAccountId" }, "account_analytic_account_mrp__mrp_workcenter_id_account_ana_idx");
                        j.IndexerProperty<Guid>("AccountAnalyticAccountId").HasColumnName("account_analytic_account_id");
                        j.IndexerProperty<Guid>("MrpWorkcenterId").HasColumnName("mrp_workcenter_id");
                    });
            });
        }
    }
}
