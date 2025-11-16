using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrModelRelation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrModelRelation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_model_relation_pkey");

                        entity.ToTable("ir_model_relation");

                        entity.HasIndex(e => e.Model, "ir_model_relation__model_index");

                        entity.HasIndex(e => e.Module, "ir_model_relation__module_index");

                        entity.HasIndex(e => e.Name, "ir_model_relation__name_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.Module).HasColumnName("module");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrModelRelationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_relation_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_relation_create_uid_fkey");

                        entity.HasOne(d => d.ModelNavigation).WithMany(p => p.IrModelRelation)
                            .HasForeignKey(d => d.Model)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_relation_model_fkey");

                        entity.HasOne(d => d.ModuleNavigation).WithMany(p => p.IrModelRelation)
                            .HasForeignKey(d => d.Module)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_relation_module_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrModelRelationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_relation_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_relation_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}