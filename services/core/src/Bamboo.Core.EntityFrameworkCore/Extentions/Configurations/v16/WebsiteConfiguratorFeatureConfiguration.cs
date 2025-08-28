using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsiteConfiguratorFeature(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsiteConfiguratorFeature>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_configurator_feature_pkey");

                        entity.ToTable("website_configurator_feature");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.FeatureUrl).HasColumnName("feature_url");
                        entity.Property(e => e.IapPageCode).HasColumnName("iap_page_code");
                        entity.Property(e => e.Icon).HasColumnName("icon");
                        entity.Property(e => e.MenuCompany).HasColumnName("menu_company");
                        entity.Property(e => e.MenuSequence).HasColumnName("menu_sequence");
                        entity.Property(e => e.ModuleId).HasColumnName("module_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PageViewId).HasColumnName("page_view_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.WebsiteConfigPreselection).HasColumnName("website_config_preselection");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteConfiguratorFeatureCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_configurator_feature_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_configurator_feature_create_uid_fkey");

                        entity.HasOne(d => d.Module).WithMany(p => p.WebsiteConfiguratorFeature)
                            .HasForeignKey(d => d.ModuleId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_configurator_feature_module_id_fkey");

                        entity.HasOne(d => d.PageView).WithMany(p => p.WebsiteConfiguratorFeature)
                            .HasForeignKey(d => d.PageViewId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_configurator_feature_page_view_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteConfiguratorFeatureWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_configurator_feature_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_configurator_feature_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}