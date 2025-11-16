using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResGroupsPrivilege(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResGroupsPrivilege>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_groups_privilege_pkey");

                        entity.ToTable("res_groups_privilege");

                        entity.HasIndex(e => e.CategoryId, "res_groups_privilege__category_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Placeholder).HasColumnName("placeholder");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Category).WithMany(p => p.ResGroupsPrivilege)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_groups_privilege_category_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResGroupsPrivilegeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_groups_privilege_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_groups_privilege_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResGroupsPrivilegeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_groups_privilege_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_groups_privilege_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}