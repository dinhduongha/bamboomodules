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
        public static void ConfigureResGroup(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResGroup>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_groups_pkey");

                entity.ToTable("res_groups");

                entity.HasIndex(e => e.TenantId, "res_groups_company_id_index");

                entity.HasIndex(e => e.CategoryId, "res_groups_category_id_index");

                entity.HasIndex(e => new { e.TenantId, e.CategoryId, e.Name }, "res_groups_name_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.Comment)
                    .HasColumnType("jsonb")
                    .HasColumnName("comment");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Share).HasColumnName("share");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Category).WithMany(p => p.ResGroups)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_groups_category_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_groups_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_groups_write_uid_fkey");

                //entity.HasMany(d => d.Gids).WithMany(p => p.Hids)
                entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ResGroupsImpliedRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("Gid")
                            .HasConstraintName("res_groups_implied_rel_gid_fkey"),
                        l => l.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("Hid")
                            .HasConstraintName("res_groups_implied_rel_hid_fkey"),
                        j =>
                        {
                            j.HasKey("Gid", "Hid").HasName("res_groups_implied_rel_pkey");
                            j.ToTable("res_groups_implied_rel");
                            j.HasIndex(new[] { "Hid", "Gid" }, "res_groups_implied_rel_hid_gid_idx");
                        });

                //entity.HasMany(d => d.Hids).WithMany(p => p.Gids)
                entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ResGroupsImpliedRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("Hid")
                            .HasConstraintName("res_groups_implied_rel_hid_fkey"),
                        l => l.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("Gid")
                            .HasConstraintName("res_groups_implied_rel_gid_fkey"),
                        j =>
                        {
                            j.HasKey("Gid", "Hid").HasName("res_groups_implied_rel_pkey");
                            j.ToTable("res_groups_implied_rel");
                            j.HasIndex(new[] { "Hid", "Gid" }, "res_groups_implied_rel_hid_gid_idx");
                        });

                entity.HasMany(d => d.UidsNavigation).WithMany(p => p.Gids)
                //entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ResGroupsUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("Uid")
                            .HasConstraintName("res_groups_users_rel_uid_fkey"),
                        l => l.HasOne<ResGroup>().WithMany()
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
            });
        }
    }
}