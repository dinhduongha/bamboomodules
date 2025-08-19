using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrDefault(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrDefault>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_default_pkey");

            entity.ToTable("ir_default");

            entity.HasIndex(e => e.TenantId, "ir_default__company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.FieldId, "ir_default__field_id_index");

            entity.HasIndex(e => e.UserId, "ir_default__user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.FieldId).HasColumnName("field_id");
            entity.Property(e => e.JsonValue).HasColumnName("json_value");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.IrDefault)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_default_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrDefaultCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_default_create_uid_fkey");

            entity.HasOne(d => d.Field).WithMany(p => p.IrDefault)
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_default_field_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.IrDefaultUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_default_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrDefaultWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_default_write_uid_fkey");
            });
        }
    }
}
