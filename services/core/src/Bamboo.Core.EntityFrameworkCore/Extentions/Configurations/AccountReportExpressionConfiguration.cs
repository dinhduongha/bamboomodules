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
        public static void ConfigureAccountReportExpression(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountReportExpression>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_report_expression_pkey");

                entity.ToTable("account_report_expression");

                entity.HasIndex(e => e.TenantId, "account_report_expression_company_id_index");

                entity.HasIndex(e => new { e.ReportLineId, e.Label }, "account_report_expression_line_label_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Auditable).HasColumnName("auditable");
                entity.Property(e => e.BlankIfZero).HasColumnName("blank_if_zero");
                entity.Property(e => e.CarryoverTarget).HasColumnName("carryover_target");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateScope).HasColumnName("date_scope");
                entity.Property(e => e.Engine).HasColumnName("engine");
                entity.Property(e => e.FigureType).HasColumnName("figure_type");
                entity.Property(e => e.Formula).HasColumnName("formula");
                entity.Property(e => e.GreenOnPositive).HasColumnName("green_on_positive");
                entity.Property(e => e.Label).HasColumnName("label");
                entity.Property(e => e.ReportLineId).HasColumnName("report_line_id");
                entity.Property(e => e.Subformula).HasColumnName("subformula");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_expression_create_uid_fkey");

                entity.HasOne(d => d.ReportLine).WithMany(p => p.AccountReportExpressions)
                    .HasForeignKey(d => d.ReportLineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_report_expression_report_line_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_expression_write_uid_fkey");
            });
        }
    }
}