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
        public static void ConfigureAccountReportLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountReportLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_report_line_pkey");

                entity.ToTable("account_report_line");

                entity.HasIndex(e => e.TenantId, "account_report_line_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.ReportId, e.Code }, "account_company_report_line_code_uniq").IsUnique();

                entity.HasIndex(e => new { e.ReportId, e.Code }, "account_report_line_code_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActionId).HasColumnName("action_id");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Foldable).HasColumnName("foldable");
                entity.Property(e => e.Groupby).HasColumnName("groupby");
                entity.Property(e => e.HideIfZero).HasColumnName("hide_if_zero");
                entity.Property(e => e.HierarchyLevel).HasColumnName("hierarchy_level");
                entity.Property(e => e.HorizontalSplitSide).HasColumnName("horizontal_split_side");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PrintOnNewPage).HasColumnName("print_on_new_page");
                entity.Property(e => e.ReportId).HasColumnName("report_id");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.UserGroupby).HasColumnName("user_groupby");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_line_create_uid_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_line_parent_id_fkey");

                entity.HasOne(d => d.Report).WithMany(p => p.AccountReportLines)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_report_line_report_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_line_write_uid_fkey");
            });
        }
    }
}