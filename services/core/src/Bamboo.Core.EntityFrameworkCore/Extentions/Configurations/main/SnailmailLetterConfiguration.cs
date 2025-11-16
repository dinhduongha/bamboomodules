using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSnailmailLetter(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SnailmailLetter>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("snailmail_letter_pkey");

                        entity.ToTable("snailmail_letter");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AttachmentId, "snailmail_letter__attachment_id_index").HasFilter("(attachment_id IS NOT NULL)");

                        entity.HasIndex(e => e.MessageId, "snailmail_letter__message_id_index").HasFilter("(message_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
                        entity.Property(e => e.City).HasColumnName("city");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.Cover).HasColumnName("cover");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Duplex).HasColumnName("duplex");
                        entity.Property(e => e.ErrorCode).HasColumnName("error_code");
                        entity.Property(e => e.InfoMsg).HasColumnName("info_msg");
                        entity.Property(e => e.MessageId).HasColumnName("message_id");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.ReportTemplate).HasColumnName("report_template");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.StateId).HasColumnName("state_id");
                        entity.Property(e => e.Street).HasColumnName("street");
                        entity.Property(e => e.Street2).HasColumnName("street2");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.Zip).HasColumnName("zip");

                        // entity.HasOne(d => d.Attachment).WithMany(p => p.SnailmailLetter) .HasForeignKey(d => d.AttachmentId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("snailmail_letter_attachment_id_fkey");
                        entity.HasOne(d => d.Attachment).WithMany()
                            .HasForeignKey(d => d.AttachmentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("snailmail_letter_attachment_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.SnailmailLetter) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("snailmail_letter_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("snailmail_letter_company_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.SnailmailLetter) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SnailmailLetterCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_create_uid_fkey");

                        entity.HasOne(d => d.Message).WithMany(p => p.SnailmailLetter)
                            .HasForeignKey(d => d.MessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_message_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.SnailmailLetter) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("snailmail_letter_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("snailmail_letter_partner_id_fkey");

                        entity.HasOne(d => d.ReportTemplateNavigation).WithMany(p => p.SnailmailLetter)
                            .HasForeignKey(d => d.ReportTemplate)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_report_template_fkey");

                        // entity.HasOne(d => d.StateNavigation).WithMany(p => p.SnailmailLetter) .HasForeignKey(d => d.StateId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_state_id_fkey");
                        entity.HasOne(d => d.StateNavigation).WithMany()
                            .HasForeignKey(d => d.StateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_state_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.SnailmailLetterUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SnailmailLetterWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("snailmail_letter_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("snailmail_letter_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}