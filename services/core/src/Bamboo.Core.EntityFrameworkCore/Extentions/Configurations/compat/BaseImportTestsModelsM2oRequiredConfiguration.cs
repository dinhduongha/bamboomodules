using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureBaseImportTestsModelsM2oRequired(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseImportTestsModelsM2oRequired>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_import_tests_models_m2o_required_pkey");

                        entity.ToTable("base_import_tests_models_m2o_required");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Value).HasColumnName("value");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseImportTestsModelsM2oRequiredCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_import_tests_models_m2o_required_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_import_tests_models_m2o_required_create_uid_fkey");

                        entity.HasOne(d => d.ValueNavigation).WithMany(p => p.BaseImportTestsModelsM2oRequired)
                            .HasForeignKey(d => d.Value)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("base_import_tests_models_m2o_required_value_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseImportTestsModelsM2oRequiredWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_import_tests_models_m2o_required_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_import_tests_models_m2o_required_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}