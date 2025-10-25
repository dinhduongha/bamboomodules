using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrModuleModuleExclusion(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrModuleModuleExclusion>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_module_module_exclusion_pkey");

                        entity.ToTable("ir_module_module_exclusion");

                        entity.HasIndex(e => e.Name, "ir_module_module_exclusion__name_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ModuleId).HasColumnName("module_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrModuleModuleExclusionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_module_module_exclusion_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_module_module_exclusion_create_uid_fkey");

                        entity.HasOne(d => d.Module).WithMany(p => p.IrModuleModuleExclusion)
                            .HasForeignKey(d => d.ModuleId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_module_module_exclusion_module_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrModuleModuleExclusionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_module_module_exclusion_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_module_module_exclusion_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}