using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailGroup(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailGroup>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_group_pkey");

                        entity.ToTable("mail_group");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessGroupId).HasColumnName("access_group_id");
                        entity.Property(e => e.AccessMode).HasColumnName("access_mode");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AliasId).HasColumnName("alias_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Moderation).HasColumnName("moderation");
                        entity.Property(e => e.ModerationGuidelines).HasColumnName("moderation_guidelines");
                        entity.Property(e => e.ModerationGuidelinesMsg).HasColumnName("moderation_guidelines_msg");
                        entity.Property(e => e.ModerationNotify).HasColumnName("moderation_notify");
                        entity.Property(e => e.ModerationNotifyMsg).HasColumnName("moderation_notify_msg");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AccessGroup).WithMany(p => p.MailGroup)
                            .HasForeignKey(d => d.AccessGroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_group_access_group_id_fkey");

                        entity.HasOne(d => d.Alias).WithMany(p => p.MailGroup)
                            .HasForeignKey(d => d.AliasId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mail_group_alias_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailGroupCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_group_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_group_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailGroupWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_group_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_group_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.MailGroup)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MailGroupModeratorRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("mail_group_moderator_rel_res_users_id_fkey"),
                                l => l.HasOne<MailGroup>().WithMany()
                                    .HasForeignKey("MailGroupId")
                                    .HasConstraintName("mail_group_moderator_rel_mail_group_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailGroupId", "ResUsersId").HasName("mail_group_moderator_rel_pkey");
                                    j.ToTable("mail_group_moderator_rel");
                                    j.HasIndex(new[] { "ResUsersId", "MailGroupId" }, "mail_group_moderator_rel_res_users_id_mail_group_id_idx");
                                    j.IndexerProperty<Guid>("MailGroupId").HasColumnName("mail_group_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}