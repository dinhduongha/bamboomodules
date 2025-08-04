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
        public static void ConfigureMailingContactListRel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingContactListRel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_contact_list_rel_pkey");

                entity.ToTable("mailing_contact_list_rel", tb => tb.HasComment("Mass Mailing Subscription Information"));

                entity.HasIndex(e => new { e.ContactId, e.ListId }, "mailing_contact_list_rel_unique_contact_list").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ContactId)
                    .HasComment("Contact")
                    .HasColumnName("contact_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.ListId)
                    .HasComment("Mailing List")
                    .HasColumnName("list_id");
                entity.Property(e => e.OptOut)
                    .HasComment("Opt Out")
                    .HasColumnName("opt_out");
                entity.Property(e => e.UnsubscriptionDate)
                    .HasComment("Unsubscription Date")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("unsubscription_date");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Contact).WithMany()
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("mailing_contact_list_rel_contact_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_list_rel_create_uid_fkey");

                entity.HasOne(d => d.List).WithMany()
                    .HasForeignKey(d => d.ListId)
                    .HasConstraintName("mailing_contact_list_rel_list_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_list_rel_write_uid_fkey");
            });
        }
    }
}