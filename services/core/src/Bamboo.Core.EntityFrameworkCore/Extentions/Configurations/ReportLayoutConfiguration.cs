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
        public static void ConfigureReportLayout(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportLayout>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("report_layout_pkey");

                entity.ToTable("report_layout");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Image).HasColumnName("image");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Pdf).HasColumnName("pdf");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.ViewId).HasColumnName("view_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("report_layout_create_uid_fkey");

                entity.HasOne(d => d.View).WithMany(p => p.ReportLayouts)
                    .HasForeignKey(d => d.ViewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("report_layout_view_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("report_layout_write_uid_fkey");
            });
        }
    }
}