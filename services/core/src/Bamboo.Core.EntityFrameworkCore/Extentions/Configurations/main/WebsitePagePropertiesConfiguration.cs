using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsitePageProperties(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsitePageProperties>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_page_properties_pkey");

                        entity.ToTable("website_page_properties");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.OldUrl).HasColumnName("old_url");
                        entity.Property(e => e.TargetModelId).HasColumnName("target_model_id");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsitePagePropertiesCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_page_properties_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_page_properties_create_uid_fkey");

                        entity.HasOne(d => d.TargetModel).WithMany(p => p.WebsitePageProperties)
                            .HasForeignKey(d => d.TargetModelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_page_properties_target_model_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.WebsitePageProperties) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("website_page_properties_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_page_properties_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsitePagePropertiesWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_page_properties_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_page_properties_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}