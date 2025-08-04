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
        public static void ConfigureMailingContact(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingContact>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_contact_pkey");

                entity.ToTable("mailing_contact", tb => tb.HasComment("Mailing Contact"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CompanyName)
                    .HasComment("Company Name")
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");
                entity.Property(e => e.CountryId)
                    .HasComment("Country")
                    .HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Email)
                    .HasComment("Email")
                    .HasColumnType("character varying")
                    .HasColumnName("email");
                entity.Property(e => e.EmailNormalized)
                    .HasComment("Normalized Email")
                    .HasColumnType("character varying")
                    .HasColumnName("email_normalized");
                entity.Property(e => e.MessageBounce)
                    .HasComment("Bounce")
                    .HasColumnName("message_bounce");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Mobile)
                    .HasComment("Mobile")
                    .HasColumnType("character varying")
                    .HasColumnName("mobile");
                entity.Property(e => e.Name)
                    .HasComment("Name")
                    .HasColumnType("character varying")
                    .HasColumnName("name");
                entity.Property(e => e.PhoneSanitized)
                    .HasComment("Sanitized Number")
                    .HasColumnType("character varying")
                    .HasColumnName("phone_sanitized");
                entity.Property(e => e.TitleId)
                    .HasComment("Title")
                    .HasColumnName("title_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Title).WithMany()
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_title_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_write_uid_fkey");

                entity.HasMany(d => d.ResPartnerCategories).WithMany(p => p.MailingContacts)
                    .UsingEntity<Dictionary<string, object>>(
                        "MailingContactResPartnerCategoryRel",
                        r => r.HasOne<ResPartnerCategory>().WithMany()
                            .HasForeignKey("ResPartnerCategoryId")
                            .HasConstraintName("mailing_contact_res_partner_catego_res_partner_category_id_fkey"),
                        l => l.HasOne<MailingContact>().WithMany()
                            .HasForeignKey("MailingContactId")
                            .HasConstraintName("mailing_contact_res_partner_category_re_mailing_contact_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailingContactId", "ResPartnerCategoryId").HasName("mailing_contact_res_partner_category_rel_pkey");
                            j.ToTable("mailing_contact_res_partner_category_rel", tb => tb.HasComment("RELATION BETWEEN mailing_contact AND res_partner_category"));
                            j.HasIndex(new[] { "ResPartnerCategoryId", "MailingContactId" }, "mailing_contact_res_partner_c_res_partner_category_id_maili_idx");
                            j.IndexerProperty<Guid>("MailingContactId").HasColumnName("mailing_contact_id");
                            j.IndexerProperty<Guid>("ResPartnerCategoryId").HasColumnName("res_partner_category_id");
                        });
            });
        }
    }
}