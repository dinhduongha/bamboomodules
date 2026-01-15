using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrModelFieldAccess(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModelFieldAccess>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_model_field_access_pkey");

                entity.ToTable("ir_model_field_access");

                entity.HasIndex(e => e.TenantId, "ir_model_field_access_company_id_index");

                entity.HasIndex(e => e.GroupId, "ir_model_field_access_group_id_index");

                entity.HasIndex(e => e.ModelId, "ir_model_field_access_model_id_index");

                entity.HasIndex(e => e.FieldId, "ir_model_field_access_model_field_id_index");

                entity.HasIndex(e => new { e.ModelId, e.FieldId, e.GroupId }, "ir_model_field_access_model_field_group_id_index").IsUnique();

                entity.HasIndex(e => e.Name, "ir_model_field_access_name_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("uuidv7()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.FieldId).HasColumnName("field_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PermRead).HasColumnName("perm_read");
                entity.Property(e => e.PermWrite).HasColumnName("perm_write");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUsers>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_model_field_access_create_uid_fkey");

                entity.HasOne(d => d.Group).WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ir_model_field_access_field_group_id_fkey");

                entity.HasOne(d => d.Model).WithMany()
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_field_access_field_model_id_fkey");

                entity.HasOne(d => d.Field).WithMany()
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_field_access_field_model_field_id_fkey");

                entity.HasOne<ResUsers>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_model_field_access_write_uid_fkey");
            });
        }

    }

}
