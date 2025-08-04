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
        public static void ConfigureIrModelConstraint(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModelConstraint>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_model_constraint_pkey");

                entity.ToTable("ir_model_constraint");

                entity.HasIndex(e => e.Model, "ir_model_constraint_model_index");

                entity.HasIndex(e => e.Module, "ir_model_constraint_module_index");

                entity.HasIndex(e => new { e.Name, e.Module }, "ir_model_constraint_module_name_uniq").IsUnique();

                entity.HasIndex(e => e.Name, "ir_model_constraint_name_index");

                entity.HasIndex(e => e.Type, "ir_model_constraint_type_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Definition).HasColumnName("definition");
                entity.Property(e => e.Message)
                    .HasColumnType("jsonb")
                    .HasColumnName("message");
                entity.Property(e => e.Model).HasColumnName("model");
                entity.Property(e => e.Module).HasColumnName("module");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_model_constraint_create_uid_fkey");

                entity.HasOne(d => d.ModelNavigation).WithMany(p => p.IrModelConstraints)
                    .HasForeignKey(d => d.Model)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_constraint_model_fkey");

                entity.HasOne(d => d.ModuleNavigation).WithMany(p => p.IrModelConstraints)
                    .HasForeignKey(d => d.Module)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_constraint_module_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_model_constraint_write_uid_fkey");
            });
        }
    }
}