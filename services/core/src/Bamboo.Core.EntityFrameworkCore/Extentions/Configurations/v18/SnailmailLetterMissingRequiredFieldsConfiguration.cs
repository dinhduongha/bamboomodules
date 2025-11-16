using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSnailmailLetterMissingRequiredFields(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SnailmailLetterMissingRequiredFields>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("snailmail_letter_missing_required_fields_pkey");

                        entity.ToTable("snailmail_letter_missing_required_fields");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.City).HasColumnName("city");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LetterId).HasColumnName("letter_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.StateId).HasColumnName("state_id");
                        entity.Property(e => e.Street).HasColumnName("street");
                        entity.Property(e => e.Street2).HasColumnName("street2");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.Zip).HasColumnName("zip");

                        // entity.HasOne(d => d.Country).WithMany(p => p.SnailmailLetterMissingRequiredFields) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_missing_required_fields_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_missing_required_fields_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SnailmailLetterMissingRequiredFieldsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_missing_required_fields_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_missing_required_fields_create_uid_fkey");

                        entity.HasOne(d => d.Letter).WithMany(p => p.SnailmailLetterMissingRequiredFields)
                            .HasForeignKey(d => d.LetterId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_missing_required_fields_letter_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.SnailmailLetterMissingRequiredFields) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_missing_required_fields_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_missing_required_fields_partner_id_fkey");

                        // entity.HasOne(d => d.State).WithMany(p => p.SnailmailLetterMissingRequiredFields) .HasForeignKey(d => d.StateId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_missing_required_fields_state_id_fkey");
                        entity.HasOne(d => d.State).WithMany()
                            .HasForeignKey(d => d.StateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_missing_required_fields_state_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SnailmailLetterMissingRequiredFieldsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_missing_required_fields_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_missing_required_fields_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}