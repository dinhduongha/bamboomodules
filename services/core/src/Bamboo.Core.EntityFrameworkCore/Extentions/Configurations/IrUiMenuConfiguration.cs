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
        public static void ConfigureIrUiMenu(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrUiMenu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_ui_menu_pkey");

                entity.ToTable("ir_ui_menu");

                entity.HasIndex(e => e.ParentId, "ir_ui_menu_parent_id_index");

                entity.HasIndex(e => e.ParentPath, "ir_ui_menu_parent_path_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Action).HasColumnName("action");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.WebIcon).HasColumnName("web_icon");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_ui_menu_create_uid_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ir_ui_menu_parent_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_ui_menu_write_uid_fkey");

                //entity.HasMany(d => d.Gids).WithMany(p => p.Menus)
                entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IrUiMenuGroupRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("Gid")
                            .HasConstraintName("ir_ui_menu_group_rel_gid_fkey"),
                        l => l.HasOne<IrUiMenu>().WithMany()
                            .HasForeignKey("MenuId")
                            .HasConstraintName("ir_ui_menu_group_rel_menu_id_fkey"),
                        j =>
                        {
                            j.HasKey("MenuId", "Gid").HasName("ir_ui_menu_group_rel_pkey");
                            j.ToTable("ir_ui_menu_group_rel");
                            j.HasIndex(new[] { "Gid", "MenuId" }, "ir_ui_menu_group_rel_gid_menu_id_idx");
                        });
            });
        }
    }
}