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
        public static void ConfigureDigestTip(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DigestTip>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("digest_tip_pkey");

                entity.ToTable("digest_tip");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.TipDescription)
                    .HasColumnType("jsonb")
                    .HasColumnName("tip_description");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("digest_tip_create_uid_fkey");

                entity.HasOne(d => d.Group).WithMany(p => p.DigestTips)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("digest_tip_group_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("digest_tip_write_uid_fkey");

                //entity.HasMany(d => d.ResUsers).WithMany(p => p.DigestTips)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "DigestTipResUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
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
                        });
            });
        }
    }
}