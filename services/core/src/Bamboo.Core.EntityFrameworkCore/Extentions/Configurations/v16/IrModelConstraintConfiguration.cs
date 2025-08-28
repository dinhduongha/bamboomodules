using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.Model, "ir_model_constraint__model_index");

                        entity.HasIndex(e => e.Module, "ir_model_constraint__module_index");

                        entity.HasIndex(e => e.Name, "ir_model_constraint__name_index");

                        entity.HasIndex(e => e.Type, "ir_model_constraint__type_index");

                        entity.HasIndex(e => new { e.Name, e.Module }, "ir_model_constraint_module_name_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrModelConstraintCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_constraint_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_constraint_create_uid_fkey");

                        entity.HasOne(d => d.ModelNavigation).WithMany(p => p.IrModelConstraint)
                            .HasForeignKey(d => d.Model)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_constraint_model_fkey");

                        entity.HasOne(d => d.ModuleNavigation).WithMany(p => p.IrModelConstraint)
                            .HasForeignKey(d => d.Module)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_constraint_module_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrModelConstraintWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_constraint_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_constraint_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}