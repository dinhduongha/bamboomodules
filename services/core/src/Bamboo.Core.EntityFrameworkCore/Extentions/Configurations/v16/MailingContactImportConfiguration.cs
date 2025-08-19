using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailingContactImport(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailingContactImport>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mailing_contact_import_pkey");

            entity.ToTable("mailing_contact_import");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.ContactList).HasColumnName("contact_list");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingContactImportCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_contact_import_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingContactImportWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_contact_import_write_uid_fkey");

            // entity.HasMany(d => d.MailingList).WithMany(p => p.MailingContactImport)
            entity.HasMany(d => d.MailingList).WithMany(p => p.MailingContactImport)
                .UsingEntity<Dictionary<string, object>>(
                    "MailingContactImportMailingListRel",
                    r => r.HasOne<MailingList>().WithMany()
                        .HasForeignKey("MailingListId")
                        .HasConstraintName("mailing_contact_import_mailing_list_rel_mailing_list_id_fkey"),
                    l => l.HasOne<MailingContactImport>().WithMany()
                        .HasForeignKey("MailingContactImportId")
                        .HasConstraintName("mailing_contact_import_mailing_l_mailing_contact_import_id_fkey"),
                    j =>
                    {
                        j.HasKey("MailingContactImportId", "MailingListId").HasName("mailing_contact_import_mailing_list_rel_pkey");
                        j.ToTable("mailing_contact_import_mailing_list_rel");
                        j.HasIndex(new[] { "MailingListId", "MailingContactImportId" }, "mailing_contact_import_mailin_mailing_list_id_mailing_conta_idx");
                        j.IndexerProperty<Guid>("MailingContactImportId").HasColumnName("mailing_contact_import_id");
                        j.IndexerProperty<Guid>("MailingListId").HasColumnName("mailing_list_id");
                    });
            });
        }
    }
}