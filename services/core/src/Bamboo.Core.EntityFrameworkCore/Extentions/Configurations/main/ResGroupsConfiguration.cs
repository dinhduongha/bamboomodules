using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResGroups(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResGroups>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_groups_pkey");

                        entity.ToTable("res_groups");

                        entity.HasIndex(e => e.PrivilegeId, "res_groups__privilege_id_index");

                        entity.HasIndex(e => new { e.PrivilegeId, e.Name }, "res_groups_name_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.ApiKeyDuration).HasColumnName("api_key_duration");
                        entity.Property(e => e.Comment)
                            .HasColumnType("jsonb")
                            .HasColumnName("comment");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LockTimeout).HasColumnName("lock_timeout");
                        entity.Property(e => e.LockTimeoutInactivity).HasColumnName("lock_timeout_inactivity");
                        entity.Property(e => e.LockTimeoutInactivityMfa).HasColumnName("lock_timeout_inactivity_mfa");
                        entity.Property(e => e.LockTimeoutMfa).HasColumnName("lock_timeout_mfa");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PrivilegeId).HasColumnName("privilege_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Share).HasColumnName("share");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResGroupsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_groups_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_groups_create_uid_fkey");

                        entity.HasOne(d => d.Privilege).WithMany(p => p.ResGroups)
                            .HasForeignKey(d => d.PrivilegeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_groups_privilege_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResGroupsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_groups_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_groups_write_uid_fkey");

                        // entity.HasMany(d => d.Gid).WithMany(p => p.Hid)
                        entity.HasMany(d => d.Gid).WithMany(p => p.Hid)
                            .UsingEntity<Dictionary<string, object>>(
                                "ResGroupsImpliedRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("Gid")
                                    .HasConstraintName("res_groups_implied_rel_gid_fkey"),
                                l => l.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("Hid")
                                    .HasConstraintName("res_groups_implied_rel_hid_fkey"),
                                j =>
                                {
                                    j.HasKey("Gid", "Hid").HasName("res_groups_implied_rel_pkey");
                                    j.ToTable("res_groups_implied_rel");
                                    j.HasIndex(new[] { "Hid", "Gid" }, "res_groups_implied_rel_hid_gid_idx");
                                    j.IndexerProperty<Guid>("Gid").HasColumnName("gid");
                                    j.IndexerProperty<Guid>("Hid").HasColumnName("hid");
                                });

                        // entity.HasMany(d => d.Hid).WithMany(p => p.Gid)
                        entity.HasMany(d => d.Hid).WithMany(p => p.Gid)
                            .UsingEntity<Dictionary<string, object>>(
                                "ResGroupsImpliedRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("Hid")
                                    .HasConstraintName("res_groups_implied_rel_hid_fkey"),
                                l => l.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("Gid")
                                    .HasConstraintName("res_groups_implied_rel_gid_fkey"),
                                j =>
                                {
                                    j.HasKey("Gid", "Hid").HasName("res_groups_implied_rel_pkey");
                                    j.ToTable("res_groups_implied_rel");
                                    j.HasIndex(new[] { "Hid", "Gid" }, "res_groups_implied_rel_hid_gid_idx");
                                    j.IndexerProperty<Guid>("Gid").HasColumnName("gid");
                                    j.IndexerProperty<Guid>("Hid").HasColumnName("hid");
                                });

                        // entity.HasMany(d => d.UidNavigation).WithMany(p => p.Gid)
                        entity.HasMany(d => d.UidNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ResGroupsUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("Uid")
                                    .HasConstraintName("res_groups_users_rel_uid_fkey"),
                                l => l.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("Gid")
                                    .HasConstraintName("res_groups_users_rel_gid_fkey"),
                                j =>
                                {
                                    j.HasKey("Gid", "Uid").HasName("res_groups_users_rel_pkey");
                                    j.ToTable("res_groups_users_rel");
                                    j.HasIndex(new[] { "Uid", "Gid" }, "res_groups_users_rel_uid_gid_idx");
                                    j.IndexerProperty<Guid>("Gid").HasColumnName("gid");
                                    j.IndexerProperty<Guid>("Uid").HasColumnName("uid");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}