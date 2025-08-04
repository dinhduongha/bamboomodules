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
        public static void ConfigureMailingContactImport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingContactImport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_contact_import_pkey");

                entity.ToTable("mailing_contact_import", tb => tb.HasComment("Mailing Contact Import"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ContactList)
                    .HasComment("Contact List")
                    .HasColumnName("contact_list");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_import_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_import_write_uid_fkey");

                entity.HasMany(d => d.MailingLists).WithMany(p => p.MailingContactImports)
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
                            j.ToTable("mailing_contact_import_mailing_list_rel", tb => tb.HasComment("RELATION BETWEEN mailing_contact_import AND mailing_list"));
                            j.HasIndex(new[] { "MailingListId", "MailingContactImportId" }, "mailing_contact_import_mailin_mailing_list_id_mailing_conta_idx");
                            j.IndexerProperty<Guid>("MailingContactImportId").HasColumnName("mailing_contact_import_id");
                            j.IndexerProperty<Guid>("MailingListId").HasColumnName("mailing_list_id");
                        });
            });
        }
    }
}