using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsiteMenu(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsiteMenu>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_menu_pkey");

                        entity.ToTable("website_menu");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ControllerPageId, "website_menu__controller_page_id_index").HasFilter("(controller_page_id IS NOT NULL)");

                        entity.HasIndex(e => e.PageId, "website_menu__page_id_index").HasFilter("(page_id IS NOT NULL)");

                        entity.HasIndex(e => e.ParentId, "website_menu__parent_id_index");

                        entity.HasIndex(e => e.ParentPath, "website_menu__parent_path_index");

                        entity.HasIndex(e => e.ThemeTemplateId, "website_menu__theme_template_id_index").HasFilter("(theme_template_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ControllerPageId).HasColumnName("controller_page_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.MegaMenuClasses).HasColumnName("mega_menu_classes");
                        entity.Property(e => e.MegaMenuContent)
                            .HasColumnType("jsonb")
                            .HasColumnName("mega_menu_content");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NewWindow).HasColumnName("new_window");
                        entity.Property(e => e.PageId).HasColumnName("page_id");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.ThemeTemplateId).HasColumnName("theme_template_id");
                        entity.Property(e => e.Url).HasColumnName("url");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ControllerPage).WithMany(p => p.WebsiteMenu)
                            .HasForeignKey(d => d.ControllerPageId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_menu_controller_page_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteMenuCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_menu_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_menu_create_uid_fkey");

                        entity.HasOne(d => d.Page).WithMany(p => p.WebsiteMenu)
                            .HasForeignKey(d => d.PageId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_menu_page_id_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_menu_parent_id_fkey");

                        entity.HasOne(d => d.ThemeTemplate).WithMany(p => p.WebsiteMenu)
                            .HasForeignKey(d => d.ThemeTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_menu_theme_template_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.WebsiteMenu) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("website_menu_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_menu_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteMenuWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_menu_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_menu_write_uid_fkey");

                        // entity.HasMany(d => d.ResGroups).WithMany(p => p.WebsiteMenu)
                        entity.HasMany(d => d.ResGroups).WithMany(p => p.WebsiteMenu)
                            .UsingEntity<Dictionary<string, object>>(
                                "ResGroupsWebsiteMenuRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("ResGroupsId")
                                    .HasConstraintName("res_groups_website_menu_rel_res_groups_id_fkey"),
                                l => l.HasOne<WebsiteMenu>().WithMany()
                                    .HasForeignKey("WebsiteMenuId")
                                    .HasConstraintName("res_groups_website_menu_rel_website_menu_id_fkey"),
                                j =>
                                {
                                    j.HasKey("WebsiteMenuId", "ResGroupsId").HasName("res_groups_website_menu_rel_pkey");
                                    j.ToTable("res_groups_website_menu_rel");
                                    j.HasIndex(new[] { "ResGroupsId", "WebsiteMenuId" }, "res_groups_website_menu_rel_res_groups_id_website_menu_id_idx");
                                    j.IndexerProperty<Guid>("WebsiteMenuId").HasColumnName("website_menu_id");
                                    j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}