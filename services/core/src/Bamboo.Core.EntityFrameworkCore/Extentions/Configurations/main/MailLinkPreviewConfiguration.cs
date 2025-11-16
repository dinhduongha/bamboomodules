using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailLinkPreview(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailLinkPreview>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_link_preview_pkey");

                        entity.ToTable("mail_link_preview");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CreationTime, "mail_link_preview__create_date_index");

                        entity.HasIndex(e => e.SourceUrl, "mail_link_preview_unique_source_url").IsUnique();

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
                        entity.Property(e => e.ImageMimetype).HasColumnName("image_mimetype");
                        entity.Property(e => e.OgDescription).HasColumnName("og_description");
                        entity.Property(e => e.OgImage).HasColumnName("og_image");
                        entity.Property(e => e.OgMimetype).HasColumnName("og_mimetype");
                        entity.Property(e => e.OgSiteName).HasColumnName("og_site_name");
                        entity.Property(e => e.OgTitle).HasColumnName("og_title");
                        entity.Property(e => e.OgType).HasColumnName("og_type");
                        entity.Property(e => e.SourceUrl).HasColumnName("source_url");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailLinkPreviewCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_link_preview_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_link_preview_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailLinkPreviewWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_link_preview_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_link_preview_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}