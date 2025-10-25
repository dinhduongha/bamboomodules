using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrUiView(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrUiView>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_ui_view_pkey");

                        entity.ToTable("ir_ui_view");

                        entity.HasIndex(e => e.InheritId, "ir_ui_view__inherit_id_index");

                        entity.HasIndex(e => e.Key, "ir_ui_view__key_index").HasFilter("(key IS NOT NULL)");

                        entity.HasIndex(e => e.Model, "ir_ui_view__model_index");

                        entity.HasIndex(e => new { e.Model, e.InheritId }, "ir_ui_view_model_type_inherit_id");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.ArchDb)
                            .HasColumnType("jsonb")
                            .HasColumnName("arch_db");
                        entity.Property(e => e.ArchFs).HasColumnName("arch_fs");
                        entity.Property(e => e.ArchPrev).HasColumnName("arch_prev");
                        entity.Property(e => e.ArchUpdated).HasColumnName("arch_updated");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CustomizeShow).HasColumnName("customize_show");
                        entity.Property(e => e.InheritId).HasColumnName("inherit_id");
                        entity.Property(e => e.Key).HasColumnName("key");
                        entity.Property(e => e.Mode).HasColumnName("mode");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.ThemeTemplateId).HasColumnName("theme_template_id");
                        entity.Property(e => e.Track).HasColumnName("track");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.Visibility).HasColumnName("visibility");
                        entity.Property(e => e.VisibilityPassword).HasColumnName("visibility_password");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.WebsiteMetaDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_description");
                        entity.Property(e => e.WebsiteMetaKeywords)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_keywords");
                        entity.Property(e => e.WebsiteMetaOgImg).HasColumnName("website_meta_og_img");
                        entity.Property(e => e.WebsiteMetaTitle)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_title");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrUiViewCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_ui_view_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_ui_view_create_uid_fkey");

                        entity.HasOne(d => d.Inherit).WithMany(p => p.InverseInherit)
                            .HasForeignKey(d => d.InheritId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("ir_ui_view_inherit_id_fkey");

                        entity.HasOne(d => d.ThemeTemplate).WithMany(p => p.IrUiView)
                            .HasForeignKey(d => d.ThemeTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_ui_view_theme_template_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.IrUiView) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("ir_ui_view_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_ui_view_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrUiViewWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_ui_view_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_ui_view_write_uid_fkey");

                        // entity.HasMany(d => d.Group).WithMany(p => p.View)
                        entity.HasMany(d => d.Group).WithMany(p => p.View)
                            .UsingEntity<Dictionary<string, object>>(
                                "IrUiViewGroupRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("GroupId")
                                    .HasConstraintName("ir_ui_view_group_rel_group_id_fkey"),
                                l => l.HasOne<IrUiView>().WithMany()
                                    .HasForeignKey("ViewId")
                                    .HasConstraintName("ir_ui_view_group_rel_view_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ViewId", "GroupId").HasName("ir_ui_view_group_rel_pkey");
                                    j.ToTable("ir_ui_view_group_rel");
                                    j.HasIndex(new[] { "GroupId", "ViewId" }, "ir_ui_view_group_rel_group_id_view_id_idx");
                                    j.IndexerProperty<Guid>("ViewId").HasColumnName("view_id");
                                    j.IndexerProperty<Guid>("GroupId").HasColumnName("group_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}