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
        public static void ConfigureMailingContactListRel(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailingContactListRel>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mailing_contact_list_rel_pkey");

            entity.ToTable("mailing_contact_list_rel");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.ContactId, e.ListId }, "mailing_contact_list_rel_unique_contact_list").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.ListId).HasColumnName("list_id");
            entity.Property(e => e.OptOut).HasColumnName("opt_out");
            entity.Property(e => e.UnsubscriptionDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("unsubscription_date");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Contact).WithMany(p => p.MailingContactListRel)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mailing_contact_list_rel_contact_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingContactListRelCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_contact_list_rel_create_uid_fkey");

            entity.HasOne(d => d.List).WithMany(p => p.MailingContactListRel)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mailing_contact_list_rel_list_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingContactListRelWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_contact_list_rel_write_uid_fkey");
            });
        }
    }
}