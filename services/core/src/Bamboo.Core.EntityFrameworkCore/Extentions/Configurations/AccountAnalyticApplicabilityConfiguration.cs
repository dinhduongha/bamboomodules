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
        public static void ConfigureAccountAnalyticApplicability(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAnalyticApplicability>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_analytic_applicability_pkey");

                entity.ToTable("account_analytic_applicability");
                entity.HasIndex(e => e.TenantId, "account_account_applicability_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountPrefix).HasColumnName("account_prefix");
                entity.Property(e => e.AnalyticPlanId).HasColumnName("analytic_plan_id");
                entity.Property(e => e.Applicability).HasColumnName("applicability");
                entity.Property(e => e.BusinessDomain).HasColumnName("business_domain");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ProductCategId).HasColumnName("product_categ_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AnalyticPlan).WithMany(p => p.AccountAnalyticApplicabilities)
                    .HasForeignKey(d => d.AnalyticPlanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_applicability_analytic_plan_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_account_applicability_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_applicability_create_uid_fkey");

                entity.HasOne(d => d.ProductCateg).WithMany(p => p.AccountAnalyticApplicabilities)
                    .HasForeignKey(d => d.ProductCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_applicability_product_categ_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_applicability_write_uid_fkey");
            });
        }
    }
}