using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrActClient(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrActClient>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_act_client_pkey");

                        entity.ToTable("ir_act_client");

                        entity.HasIndex(e => e.Path, "ir_act_client_path_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.BindingModelId).HasColumnName("binding_model_id");
                        entity.Property(e => e.BindingType).HasColumnName("binding_type");
                        entity.Property(e => e.BindingViewTypes).HasColumnName("binding_view_types");
                        entity.Property(e => e.Context).HasColumnName("context");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Help)
                            .HasColumnType("jsonb")
                            .HasColumnName("help");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.ParamsStore).HasColumnName("params_store");
                        entity.Property(e => e.Path).HasColumnName("path");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.Tag).HasColumnName("tag");
                        entity.Property(e => e.Target).HasColumnName("target");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.BindingModel).WithMany(p => p.IrActClient)
                            .HasForeignKey(d => d.BindingModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_act_client_binding_model_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrActClientCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_act_client_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_act_client_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrActClientWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_act_client_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_act_client_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}