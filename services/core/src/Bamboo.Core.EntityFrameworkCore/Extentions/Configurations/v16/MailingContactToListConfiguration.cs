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
        public static void ConfigureMailingContactToList(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailingContactToList>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mailing_contact_to_list_pkey");

            entity.ToTable("mailing_contact_to_list");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MailingListId).HasColumnName("mailing_list_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingContactToListCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_contact_to_list_create_uid_fkey");

            entity.HasOne(d => d.MailingList).WithMany(p => p.MailingContactToList)
                .HasForeignKey(d => d.MailingListId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mailing_contact_to_list_mailing_list_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingContactToListWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_contact_to_list_write_uid_fkey");

            // entity.HasMany(d => d.MailingContact).WithMany(p => p.MailingContactToList)
            entity.HasMany(d => d.MailingContact).WithMany(p => p.MailingContactToList)
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
                        j.ToTable("mailing_contact_mailing_contact_to_list_rel");
                        j.HasIndex(new[] { "MailingContactId", "MailingContactToListId" }, "mailing_contact_mailing_conta_mailing_contact_id_mailing_co_idx");
                        j.IndexerProperty<Guid>("MailingContactToListId").HasColumnName("mailing_contact_to_list_id");
                        j.IndexerProperty<Guid>("MailingContactId").HasColumnName("mailing_contact_id");
                    });
            });
        }
    }
}