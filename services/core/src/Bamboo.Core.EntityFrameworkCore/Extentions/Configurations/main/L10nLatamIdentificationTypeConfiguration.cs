using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureL10nLatamIdentificationType(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<L10nLatamIdentificationType>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("l10n_latam_identification_type_pkey");

                        entity.ToTable("l10n_latam_identification_type");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.IsVat).HasColumnName("is_vat");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Country).WithMany(p => p.L10nLatamIdentificationType) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_identification_type_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_identification_type_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.L10nLatamIdentificationTypeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_identification_type_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_identification_type_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.L10nLatamIdentificationTypeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_identification_type_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_identification_type_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}