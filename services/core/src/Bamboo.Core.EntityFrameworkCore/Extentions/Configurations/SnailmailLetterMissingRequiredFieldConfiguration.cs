using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSnailmailLetterMissingRequiredField(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SnailmailLetterMissingRequiredField>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("snailmail_letter_missing_required_fields_pkey");

                entity.ToTable("snailmail_letter_missing_required_fields");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_missing_required_fields_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_missing_required_fields_create_uid_fkey");

                entity.HasOne(d => d.Letter).WithMany(p => p.SnailmailLetterMissingRequiredFields)
                    .HasForeignKey(d => d.LetterId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_missing_required_fields_letter_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_missing_required_fields_partner_id_fkey");

                entity.HasOne(d => d.State).WithMany(p => p.SnailmailLetterMissingRequiredFields)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_missing_required_fields_state_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_missing_required_fields_write_uid_fkey");
            });
        }
    }
}