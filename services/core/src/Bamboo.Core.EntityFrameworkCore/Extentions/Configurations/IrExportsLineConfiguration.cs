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
        public static void ConfigureIrExportsLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrExportsLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_exports_line_pkey");

                entity.ToTable("ir_exports_line");

                entity.HasIndex(e => e.ExportId, "ir_exports_line_export_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ExportId).HasColumnName("export_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_exports_line_create_uid_fkey");

                entity.HasOne(d => d.Export).WithMany(p => p.IrExportsLines)
                    .HasForeignKey(d => d.ExportId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_exports_line_export_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_exports_line_write_uid_fkey");
            });
        }
    }
}