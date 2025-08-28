using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsiteControllerPage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsiteControllerPage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_controller_page_pkey");

                        entity.ToTable("website_controller_page");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "website_controller_page__is_published_index");

                        entity.HasIndex(e => e.WebsiteId, "website_controller_page__website_id_index");

                        entity.HasIndex(e => e.NameSlugified, "website_controller_page_unique_name_slugified").IsUnique();

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
                        entity.Property(e => e.DefaultLayout).HasColumnName("default_layout");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.NameSlugified).HasColumnName("name_slugified");
                        entity.Property(e => e.RecordDomain).HasColumnName("record_domain");
                        entity.Property(e => e.RecordViewId).HasColumnName("record_view_id");
                        entity.Property(e => e.ViewId).HasColumnName("view_id");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteControllerPageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_controller_page_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_controller_page_create_uid_fkey");

                        entity.HasOne(d => d.RecordView).WithMany(p => p.WebsiteControllerPageRecordView)
                            .HasForeignKey(d => d.RecordViewId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_controller_page_record_view_id_fkey");

                        entity.HasOne(d => d.View).WithMany(p => p.WebsiteControllerPageView)
                            .HasForeignKey(d => d.ViewId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_controller_page_view_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.WebsiteControllerPage) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("website_controller_page_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_controller_page_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteControllerPageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_controller_page_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_controller_page_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}