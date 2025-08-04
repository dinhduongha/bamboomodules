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
        public static void ConfigureMailingListMerge(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingListMerge>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_list_merge_pkey");

                entity.ToTable("mailing_list_merge", tb => tb.HasComment("Merge Mass Mailing List"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ArchiveSrcLists)
                    .HasComment("Archive source mailing lists")
                    .HasColumnName("archive_src_lists");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.DestListId)
                    .HasComment("Destination Mailing List")
                    .HasColumnName("dest_list_id");
                entity.Property(e => e.MergeOptions)
                    .HasComment("Merge Option")
                    .HasColumnType("character varying")
                    .HasColumnName("merge_options");
                entity.Property(e => e.NewListName)
                    .HasComment("New Mailing List Name")
                    .HasColumnType("character varying")
                    .HasColumnName("new_list_name");
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
                    .HasConstraintName("mailing_list_merge_create_uid_fkey");

                entity.HasOne(d => d.DestList).WithMany(p => p.MailingListMergesNavigation)
                    .HasForeignKey(d => d.DestListId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_list_merge_dest_list_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_list_merge_write_uid_fkey");

                entity.HasMany(d => d.MailingLists).WithMany(p => p.MailingListMerges)
                    .UsingEntity<Dictionary<string, object>>(
                        "MailingListMailingListMergeRel",
                        r => r.HasOne<MailingList>().WithMany()
                            .HasForeignKey("MailingListId")
                            .HasConstraintName("mailing_list_mailing_list_merge_rel_mailing_list_id_fkey"),
                        l => l.HasOne<MailingListMerge>().WithMany()
                            .HasForeignKey("MailingListMergeId")
                            .HasConstraintName("mailing_list_mailing_list_merge_rel_mailing_list_merge_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailingListMergeId", "MailingListId").HasName("mailing_list_mailing_list_merge_rel_pkey");
                            j.ToTable("mailing_list_mailing_list_merge_rel", tb => tb.HasComment("RELATION BETWEEN mailing_list_merge AND mailing_list"));
                            j.HasIndex(new[] { "MailingListId", "MailingListMergeId" }, "mailing_list_mailing_list_mer_mailing_list_id_mailing_list__idx");
                            j.IndexerProperty<Guid>("MailingListMergeId").HasColumnName("mailing_list_merge_id");
                            j.IndexerProperty<Guid>("MailingListId").HasColumnName("mailing_list_id");
                        });
            });
        }
    }
}