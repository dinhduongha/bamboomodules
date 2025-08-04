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
        public static void ConfigureAccountAnalyticLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAnalyticLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_analytic_line_pkey");

                entity.ToTable("account_analytic_line");

                entity.HasIndex(e => e.AccountId, "account_analytic_line_account_id_index");

                entity.HasIndex(e => e.Date, "account_analytic_line_date_index");

                entity.HasIndex(e => e.MoveLineId, "account_analytic_line_move_line_id_index");

                entity.HasIndex(e => e.SoLine, "account_analytic_line__so_line_index").HasFilter("(so_line IS NOT NULL)");

                entity.HasIndex(e => e.UserId, "account_analytic_line_user_id_index");

                entity.HasIndex(e => e.XPlan2Id, "account_analytic_line__x_plan2_id_index").HasFilter("(x_plan2_id IS NOT NULL)");

                entity.HasIndex(e => e.XPlan3Id, "account_analytic_line__x_plan3_id_index").HasFilter("(x_plan3_id IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.Category).HasColumnName("category");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.GeneralAccountId).HasColumnName("general_account_id");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.MoveLineId).HasColumnName("move_line_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PlanId).HasColumnName("plan_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.Ref).HasColumnName("ref");
                entity.Property(e => e.SoLine).HasColumnName("so_line");
                entity.Property(e => e.UnitAmount).HasColumnName("unit_amount");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                entity.Property(e => e.XPlan2Id).HasColumnName("x_plan2_id");
                entity.Property(e => e.XPlan3Id).HasColumnName("x_plan3_id");

                // v16-Compat
                // TODO: CHECK RELATION
                //entity.HasOne(d => d.Account).WithMany(p => p.AccountAnalyticLines)
                entity.HasOne(d => d.Account).WithMany(p => p.AccountAnalyticLineAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_analytic_line_account_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_analytic_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_currency_id_fkey");

                entity.HasOne(d => d.GeneralAccount).WithMany(p => p.AccountAnalyticLines)
                    .HasForeignKey(d => d.GeneralAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_analytic_line_general_account_id_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.AccountAnalyticLines)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_journal_id_fkey");

                entity.HasOne(d => d.MoveLine).WithMany(p => p.AccountAnalyticLines)
                    .HasForeignKey(d => d.MoveLineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_analytic_line_move_line_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_partner_id_fkey");

                entity.HasOne(d => d.Plan).WithMany(p => p.AccountAnalyticLines)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_plan_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.AccountAnalyticLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.AccountAnalyticLines)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_product_uom_id_fkey");

                entity.HasOne(d => d.SoLineNavigation).WithMany(p => p.AccountAnalyticLines)
                    .HasForeignKey(d => d.SoLine)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_so_line_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_write_uid_fkey");

                entity.HasOne(d => d.XPlan2).WithMany(p => p.AccountAnalyticLineXPlan2s)
                    .HasForeignKey(d => d.XPlan2Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_x_plan2_id_fkey");

                entity.HasOne(d => d.XPlan3).WithMany(p => p.AccountAnalyticLineXPlan3s)
                    .HasForeignKey(d => d.XPlan3Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_line_x_plan3_id_fkey");
            });
        }
    }
}