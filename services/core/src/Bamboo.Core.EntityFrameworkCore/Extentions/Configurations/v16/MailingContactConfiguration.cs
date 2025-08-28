using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("mailing_contact");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CompanyName).HasColumnName("company_name");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Email).HasColumnName("email");
                        entity.Property(e => e.EmailNormalized).HasColumnName("email_normalized");
                        entity.Property(e => e.FirstName).HasColumnName("first_name");
                        entity.Property(e => e.LastName).HasColumnName("last_name");
                        entity.Property(e => e.MessageBounce).HasColumnName("message_bounce");
                        entity.Property(e => e.Mobile).HasColumnName("mobile");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PhoneSanitized).HasColumnName("phone_sanitized");
                        entity.Property(e => e.TitleId).HasColumnName("title_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Country).WithMany(p => p.MailingContact) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_contact_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_contact_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingContactCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_contact_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_contact_create_uid_fkey");

                        entity.HasOne(d => d.Title).WithMany(p => p.MailingContact)
                            .HasForeignKey(d => d.TitleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_contact_title_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingContactWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_contact_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_contact_write_uid_fkey");

                        // entity.HasMany(d => d.ResPartnerCategory).WithMany(p => p.MailingContact)
                        entity.HasMany(d => d.ResPartnerCategory).WithMany(p => p.MailingContact)
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
                                    j.ToTable("mailing_contact_res_partner_category_rel");
                                    j.HasIndex(new[] { "ResPartnerCategoryId", "MailingContactId" }, "mailing_contact_res_partner_c_res_partner_category_id_maili_idx");
                                    j.IndexerProperty<Guid>("MailingContactId").HasColumnName("mailing_contact_id");
                                    j.IndexerProperty<Guid>("ResPartnerCategoryId").HasColumnName("res_partner_category_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}