using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureDigestTip(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<DigestTip>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("digest_tip_pkey");

                        entity.ToTable("digest_tip");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.GroupId).HasColumnName("group_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TipDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("tip_description");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.DigestTipCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("digest_tip_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("digest_tip_create_uid_fkey");

                        entity.HasOne(d => d.Group).WithMany(p => p.DigestTip)
                            .HasForeignKey(d => d.GroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("digest_tip_group_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.DigestTipWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("digest_tip_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("digest_tip_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.DigestTip)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "DigestTipResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("digest_tip_res_users_rel_res_users_id_fkey"),
                                l => l.HasOne<DigestTip>().WithMany()
                                    .HasForeignKey("DigestTipId")
                                    .HasConstraintName("digest_tip_res_users_rel_digest_tip_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DigestTipId", "ResUsersId").HasName("digest_tip_res_users_rel_pkey");
                                    j.ToTable("digest_tip_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "DigestTipId" }, "digest_tip_res_users_rel_res_users_id_digest_tip_id_idx");
                                    j.IndexerProperty<Guid>("DigestTipId").HasColumnName("digest_tip_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}