using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrModelFieldsSelection(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrModelFieldsSelection>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_model_fields_selection_pkey");

                        entity.ToTable("ir_model_fields_selection");

                        entity.HasIndex(e => e.FieldId, "ir_model_fields_selection__field_id_index");

                        entity.HasIndex(e => new { e.FieldId, e.Value }, "ir_model_fields_selection_selection_field_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FieldId).HasColumnName("field_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Value).HasColumnName("value");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrModelFieldsSelectionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_fields_selection_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_fields_selection_create_uid_fkey");

                        entity.HasOne(d => d.Field).WithMany(p => p.IrModelFieldsSelection)
                            .HasForeignKey(d => d.FieldId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_fields_selection_field_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrModelFieldsSelectionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_fields_selection_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_fields_selection_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}