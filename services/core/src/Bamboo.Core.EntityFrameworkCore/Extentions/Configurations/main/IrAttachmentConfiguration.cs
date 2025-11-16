using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrAttachment(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrAttachment>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_attachment_pkey");

                        entity.ToTable("ir_attachment");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.OriginalId, "ir_attachment__original_id_index").HasFilter("(original_id IS NOT NULL)");

                        entity.HasIndex(e => e.StoreFname, "ir_attachment__store_fname_index");

                        entity.HasIndex(e => e.ThemeTemplateId, "ir_attachment__theme_template_id_index").HasFilter("(theme_template_id IS NOT NULL)");

                        entity.HasIndex(e => e.Url, "ir_attachment__url_index").HasFilter("(url IS NOT NULL)");

                        entity.HasIndex(e => e.IndexContent, "ir_attachment_index_content_applicant_trgm_idx")
                            .HasFilter("(res_model = 'hr.applicant'::text)")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => new { e.ResModel, e.ResId }, "ir_attachment_res_idx");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.Checksum).HasColumnName("checksum");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DbDatas).HasColumnName("db_datas");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.FileSize).HasColumnName("file_size");
                        entity.Property(e => e.IndexContent).HasColumnName("index_content");
                        entity.Property(e => e.Key).HasColumnName("key");
                        entity.Property(e => e.Mimetype).HasColumnName("mimetype");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OriginalId).HasColumnName("original_id");
                        entity.Property(e => e.Public).HasColumnName("public");
                        entity.Property(e => e.ResField).HasColumnName("res_field");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.StoreFname).HasColumnName("store_fname");
                        entity.Property(e => e.ThemeTemplateId).HasColumnName("theme_template_id");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.Url).HasColumnName("url");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.IrAttachment) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_attachment_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_attachment_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrAttachmentCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_attachment_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_attachment_create_uid_fkey");

                        // entity.HasOne(d => d.Original).WithMany(p => p.InverseOriginal) .HasForeignKey(d => d.OriginalId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_attachment_original_id_fkey");
                        entity.HasOne(d => d.Original).WithMany()
                            .HasForeignKey(d => d.OriginalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_attachment_original_id_fkey");

                        entity.HasOne(d => d.ThemeTemplate).WithMany(p => p.IrAttachment)
                            .HasForeignKey(d => d.ThemeTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_attachment_theme_template_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.IrAttachment) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_attachment_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_attachment_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrAttachmentWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_attachment_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_attachment_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}