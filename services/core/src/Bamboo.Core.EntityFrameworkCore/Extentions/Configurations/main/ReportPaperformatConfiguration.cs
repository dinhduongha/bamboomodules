using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureReportPaperformat(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ReportPaperformat>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("report_paperformat_pkey");

                        entity.ToTable("report_paperformat");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CssMargins).HasColumnName("css_margins");
                        entity.Property(e => e.Default).HasColumnName("default");
                        entity.Property(e => e.DisableShrinking).HasColumnName("disable_shrinking");
                        entity.Property(e => e.Dpi).HasColumnName("dpi");
                        entity.Property(e => e.Format).HasColumnName("format");
                        entity.Property(e => e.HeaderLine).HasColumnName("header_line");
                        entity.Property(e => e.HeaderSpacing).HasColumnName("header_spacing");
                        entity.Property(e => e.MarginBottom).HasColumnName("margin_bottom");
                        entity.Property(e => e.MarginLeft).HasColumnName("margin_left");
                        entity.Property(e => e.MarginRight).HasColumnName("margin_right");
                        entity.Property(e => e.MarginTop).HasColumnName("margin_top");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Orientation).HasColumnName("orientation");
                        entity.Property(e => e.PageHeight).HasColumnName("page_height");
                        entity.Property(e => e.PageWidth).HasColumnName("page_width");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ReportPaperformatCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("report_paperformat_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("report_paperformat_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ReportPaperformatWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("report_paperformat_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("report_paperformat_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}