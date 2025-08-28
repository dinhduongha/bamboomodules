using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsiteSaleExtraField(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsiteSaleExtraField>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_sale_extra_field_pkey");

                        entity.ToTable("website_sale_extra_field");

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
                        entity.Property(e => e.FieldId).HasColumnName("field_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteSaleExtraFieldCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_sale_extra_field_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_sale_extra_field_create_uid_fkey");

                        entity.HasOne(d => d.Field).WithMany(p => p.WebsiteSaleExtraField)
                            .HasForeignKey(d => d.FieldId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_sale_extra_field_field_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.WebsiteSaleExtraField) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_sale_extra_field_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_sale_extra_field_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteSaleExtraFieldWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_sale_extra_field_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_sale_extra_field_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}