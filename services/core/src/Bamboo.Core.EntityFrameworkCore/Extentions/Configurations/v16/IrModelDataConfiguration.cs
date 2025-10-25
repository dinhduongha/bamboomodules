using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrModelData(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrModelData>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_model_data_pkey");

                        entity.ToTable("ir_model_data");

                        entity.HasIndex(e => new { e.Model, e.ResId }, "ir_model_data_model_res_id_index");

                        entity.HasIndex(e => new { e.Module, e.Name }, "ir_model_data_module_name_uniq_index").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("(now() AT TIME ZONE 'UTC'::text)")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.Module).HasColumnName("module");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Noupdate)
                            .HasDefaultValue(false)
                            .HasColumnName("noupdate");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasDefaultValueSql("(now() AT TIME ZONE 'UTC'::text)")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrModelDataCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_data_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_data_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrModelDataWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_data_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_data_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}