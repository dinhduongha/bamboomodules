using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("mailing_list");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsPublic).HasColumnName("is_public");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingListCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_list_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_list_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingListWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mailing_list_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mailing_list_write_uid_fkey");

                        // entity.HasMany(d => d.MailingMailing).WithMany(p => p.MailingList)
                        entity.HasMany(d => d.MailingMailing).WithMany(p => p.MailingList)
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
                                    j.ToTable("mail_mass_mailing_list_rel");
                                    j.HasIndex(new[] { "MailingMailingId", "MailingListId" }, "mail_mass_mailing_list_rel_mailing_mailing_id_mailing_list__idx");
                                    j.IndexerProperty<Guid>("MailingListId").HasColumnName("mailing_list_id");
                                    j.IndexerProperty<Guid>("MailingMailingId").HasColumnName("mailing_mailing_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}