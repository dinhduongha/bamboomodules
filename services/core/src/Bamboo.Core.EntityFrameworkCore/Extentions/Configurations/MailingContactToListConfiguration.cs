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
        public static void ConfigureMailingContactToList(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingContactToList>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_contact_to_list_pkey");

                entity.ToTable("mailing_contact_to_list", tb => tb.HasComment("Add Contacts to Mailing List"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.MailingListId)
                    .HasComment("Mailing List")
                    .HasColumnName("mailing_list_id");
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
                    .HasConstraintName("mailing_contact_to_list_create_uid_fkey");

                entity.HasOne(d => d.MailingList).WithMany(p => p.MailingContactToLists)
                    .HasForeignKey(d => d.MailingListId)
                    .HasConstraintName("mailing_contact_to_list_mailing_list_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_to_list_write_uid_fkey");

                entity.HasMany(d => d.MailingContacts).WithMany(p => p.MailingContactToLists)
                    .UsingEntity<Dictionary<string, object>>(
                        "MailingContactMailingContactToListRel",
                        r => r.HasOne<MailingContact>().WithMany()
                            .HasForeignKey("MailingContactId")
                            .HasConstraintName("mailing_contact_mailing_contact_to_list_mailing_contact_id_fkey"),
                        l => l.HasOne<MailingContactToList>().WithMany()
                            .HasForeignKey("MailingContactToListId")
                            .HasConstraintName("mailing_contact_mailing_contact_mailing_contact_to_list_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailingContactToListId", "MailingContactId").HasName("mailing_contact_mailing_contact_to_list_rel_pkey");
                            j.ToTable("mailing_contact_mailing_contact_to_list_rel", tb => tb.HasComment("RELATION BETWEEN mailing_contact_to_list AND mailing_contact"));
                            j.HasIndex(new[] { "MailingContactId", "MailingContactToListId" }, "mailing_contact_mailing_conta_mailing_contact_id_mailing_co_idx");
                            j.IndexerProperty<Guid>("MailingContactToListId").HasColumnName("mailing_contact_to_list_id");
                            j.IndexerProperty<Guid>("MailingContactId").HasColumnName("mailing_contact_id");
                        });
            });
        }
    }
}