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
        public static void ConfigurePosDailySalesReportsWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosDailySalesReportsWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_daily_sales_reports_wizard_pkey");

                entity.ToTable("pos_daily_sales_reports_wizard");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AddReportPerEmployee).HasColumnName("add_report_per_employee");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.PosSessionId).HasColumnName("pos_session_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_daily_sales_reports_wizard_create_uid_fkey");

                entity.HasOne(d => d.PosSession).WithMany()
                    .HasForeignKey(d => d.PosSessionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pos_daily_sales_reports_wizard_pos_session_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_daily_sales_reports_wizard_write_uid_fkey");
            });
        }
    }
}