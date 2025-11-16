using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResRole(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResRole>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_role_pkey");

                        entity.ToTable("res_role");

                        entity.HasIndex(e => e.Name, "res_role_unique_name").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResRoleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_role_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_role_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResRoleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_role_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_role_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.ResRole)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ResRoleResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("res_role_res_users_rel_res_users_id_fkey"),
                                l => l.HasOne<ResRole>().WithMany()
                                    .HasForeignKey("ResRoleId")
                                    .HasConstraintName("res_role_res_users_rel_res_role_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ResRoleId", "ResUsersId").HasName("res_role_res_users_rel_pkey");
                                    j.ToTable("res_role_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "ResRoleId" }, "res_role_res_users_rel_res_users_id_res_role_id_idx");
                                    j.IndexerProperty<Guid>("ResRoleId").HasColumnName("res_role_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}