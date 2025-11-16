using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureL10nLatamDocumentType(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<L10nLatamDocumentType>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("l10n_latam_document_type_pkey");

                        entity.ToTable("l10n_latam_document_type");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CountryId, "l10n_latam_document_type__country_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DocCodePrefix).HasColumnName("doc_code_prefix");
                        entity.Property(e => e.InternalType).HasColumnName("internal_type");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.ReportName)
                            .HasColumnType("jsonb")
                            .HasColumnName("report_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Country).WithMany(p => p.L10nLatamDocumentType) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("l10n_latam_document_type_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("l10n_latam_document_type_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.L10nLatamDocumentTypeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_document_type_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_document_type_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.L10nLatamDocumentTypeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_document_type_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_document_type_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}