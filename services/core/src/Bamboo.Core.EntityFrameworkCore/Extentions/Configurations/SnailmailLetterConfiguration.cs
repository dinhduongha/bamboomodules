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
        public static void ConfigureSnailmailLetter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SnailmailLetter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("snailmail_letter_pkey");

                entity.ToTable("snailmail_letter");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.Cover).HasColumnName("cover");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne(d => d.Attachment).WithMany(p => p.SnailmailLetters)
                    .HasForeignKey(d => d.AttachmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("snailmail_letter_attachment_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("snailmail_letter_company_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_create_uid_fkey");

                entity.HasOne(d => d.Message).WithMany(p => p.SnailmailLetters)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_message_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("snailmail_letter_partner_id_fkey");

                entity.HasOne(d => d.ReportTemplateNavigation).WithMany(p => p.SnailmailLetters)
                    .HasForeignKey(d => d.ReportTemplate)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_report_template_fkey");

                entity.HasOne(d => d.StateNavigation).WithMany(p => p.SnailmailLetters)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_state_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("snailmail_letter_write_uid_fkey");
            });
        }
    }
}