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
        public static void ConfigureMailingList(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingList>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_list_pkey");

                entity.ToTable("mailing_list", tb => tb.HasComment("Mailing List"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.IsPublic)
                    .HasComment("Show In Preferences")
                    .HasColumnName("is_public");
                entity.Property(e => e.Name)
                    .HasComment("Mailing List")
                    .HasColumnType("character varying")
                    .HasColumnName("name");
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
                    .HasConstraintName("mailing_list_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_list_write_uid_fkey");

                entity.HasMany(d => d.MailingMailings).WithMany(p => p.MailingLists)
                    .UsingEntity<Dictionary<string, object>>(
                        "MailMassMailingListRel",
                        r => r.HasOne<MailingMailing>().WithMany()
                            .HasForeignKey("MailingMailingId")
                            .HasConstraintName("mail_mass_mailing_list_rel_mailing_mailing_id_fkey"),
                        l => l.HasOne<MailingList>().WithMany()
                            .HasForeignKey("MailingListId")
                            .HasConstraintName("mail_mass_mailing_list_rel_mailing_list_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailingListId", "MailingMailingId").HasName("mail_mass_mailing_list_rel_pkey");
                            j.ToTable("mail_mass_mailing_list_rel", tb => tb.HasComment("RELATION BETWEEN mailing_list AND mailing_mailing"));
                            j.HasIndex(new[] { "MailingMailingId", "MailingListId" }, "mail_mass_mailing_list_rel_mailing_mailing_id_mailing_list__idx");
                            j.IndexerProperty<Guid>("MailingListId").HasColumnName("mailing_list_id");
                            j.IndexerProperty<Guid>("MailingMailingId").HasColumnName("mailing_mailing_id");
                        });
            });
        }
    }
}