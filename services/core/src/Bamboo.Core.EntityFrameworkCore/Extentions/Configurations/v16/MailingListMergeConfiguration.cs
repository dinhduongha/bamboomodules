using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("mailing_list_merge");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ArchiveSrcLists).HasColumnName("archive_src_lists");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DestListId).HasColumnName("dest_list_id");
                        entity.Property(e => e.MergeOptions).HasColumnName("merge_options");
                        entity.Property(e => e.NewListName).HasColumnName("new_list_name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingListMergeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_list_merge_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_list_merge_create_uid_fkey");

                        entity.HasOne(d => d.DestList).WithMany(p => p.MailingListMergeNavigation)
                            .HasForeignKey(d => d.DestListId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_list_merge_dest_list_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingListMergeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_list_merge_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_list_merge_write_uid_fkey");

                        // entity.HasMany(d => d.MailingList).WithMany(p => p.MailingListMerge)
                        entity.HasMany(d => d.MailingList).WithMany(p => p.MailingListMerge)
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
                                    j.ToTable("mailing_list_mailing_list_merge_rel");
                                    j.HasIndex(new[] { "MailingListId", "MailingListMergeId" }, "mailing_list_mailing_list_mer_mailing_list_id_mailing_list__idx");
                                    j.IndexerProperty<Guid>("MailingListMergeId").HasColumnName("mailing_list_merge_id");
                                    j.IndexerProperty<Guid>("MailingListId").HasColumnName("mailing_list_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}