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
        public static void ConfigureIrUiViewCustom(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrUiViewCustom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_ui_view_custom_pkey");

                entity.ToTable("ir_ui_view_custom");

                entity.HasIndex(e => e.RefId, "ir_ui_view_custom_ref_id_index");

                entity.HasIndex(e => e.UserId, "ir_ui_view_custom_user_id_index");

                entity.HasIndex(e => new { e.UserId, e.RefId }, "ir_ui_view_custom_user_id_ref_id");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Arch).HasColumnName("arch");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.RefId).HasColumnName("ref_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_ui_view_custom_create_uid_fkey");

                entity.HasOne(d => d.Ref).WithMany(p => p.IrUiViewCustoms)
                    .HasForeignKey(d => d.RefId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_ui_view_custom_ref_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_ui_view_custom_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_ui_view_custom_write_uid_fkey");
            });
        }
    }
}