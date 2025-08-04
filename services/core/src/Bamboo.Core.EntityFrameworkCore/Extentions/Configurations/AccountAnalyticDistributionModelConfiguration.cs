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
        public static void ConfigureAccountAnalyticDistributionModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAnalyticDistributionModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_analytic_distribution_model_pkey");

                entity.ToTable("account_analytic_distribution_model");

                entity.HasIndex(e => e.TenantId, "account_analytic_distribution_model_company_id_index");
                entity.HasIndex(e => e.AnalyticDistribution, "account_analytic_distribution_model_analytic_distribution_gin_i").HasMethod("gin");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountPrefix).HasColumnName("account_prefix");
                entity.Property(e => e.AnalyticDistribution)
                    .HasColumnType("jsonb")
                    .HasColumnName("analytic_distribution");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.PartnerCategoryId).HasColumnName("partner_category_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.ProductCategId).HasColumnName("product_categ_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_analytic_distribution_model_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_distribution_model_create_uid_fkey");

                entity.HasOne(d => d.PartnerCategory).WithMany(p => p.AccountAnalyticDistributionModels)
                    .HasForeignKey(d => d.PartnerCategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_analytic_distribution_model_partner_category_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_analytic_distribution_model_partner_id_fkey");

                entity.HasOne(d => d.ProductCateg).WithMany(p => p.AccountAnalyticDistributionModels)
                    .HasForeignKey(d => d.ProductCategId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_analytic_distribution_model_product_categ_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.AccountAnalyticDistributionModels)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_analytic_distribution_model_product_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_distribution_model_write_uid_fkey");
            });
        }
    }
}