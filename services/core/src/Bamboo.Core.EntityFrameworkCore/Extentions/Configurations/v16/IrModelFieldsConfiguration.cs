using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrModelFields(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrModelFields>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_model_fields_pkey");

                        entity.ToTable("ir_model_fields");

                        entity.HasIndex(e => e.CompleteName, "ir_model_fields__complete_name_index");

                        entity.HasIndex(e => e.ModelId, "ir_model_fields__model_id_index");

                        entity.HasIndex(e => e.Model, "ir_model_fields__model_index");

                        entity.HasIndex(e => e.Name, "ir_model_fields__name_index");

                        entity.HasIndex(e => e.State, "ir_model_fields__state_index");

                        entity.HasIndex(e => e.WebsiteFormBlacklisted, "ir_model_fields__website_form_blacklisted_index");

                        entity.HasIndex(e => new { e.Model, e.Name }, "ir_model_fields_name_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.Column1).HasColumnName("column1");
                        entity.Property(e => e.Column2).HasColumnName("column2");
                        entity.Property(e => e.CompanyDependent).HasColumnName("company_dependent");
                        entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                        entity.Property(e => e.Compute).HasColumnName("compute");
                        entity.Property(e => e.Copied).HasColumnName("copied");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyField).HasColumnName("currency_field");
                        entity.Property(e => e.Depends).HasColumnName("depends");
                        entity.Property(e => e.Domain).HasColumnName("domain");
                        entity.Property(e => e.FieldDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("field_description");
                        entity.Property(e => e.GroupExpand).HasColumnName("group_expand");
                        entity.Property(e => e.Help)
                            .HasColumnType("jsonb")
                            .HasColumnName("help");
                        entity.Property(e => e.Index).HasColumnName("index");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.ModelId).HasColumnName("model_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OnDelete).HasColumnName("on_delete");
                        entity.Property(e => e.Readonly).HasColumnName("readonly");
                        entity.Property(e => e.Related).HasColumnName("related");
                        entity.Property(e => e.RelatedFieldId).HasColumnName("related_field_id");
                        entity.Property(e => e.Relation).HasColumnName("relation");
                        entity.Property(e => e.RelationField).HasColumnName("relation_field");
                        entity.Property(e => e.RelationFieldId).HasColumnName("relation_field_id");
                        entity.Property(e => e.RelationTable).HasColumnName("relation_table");
                        entity.Property(e => e.Required).HasColumnName("required");
                        entity.Property(e => e.Sanitize).HasColumnName("sanitize");
                        entity.Property(e => e.SanitizeAttributes).HasColumnName("sanitize_attributes");
                        entity.Property(e => e.SanitizeForm).HasColumnName("sanitize_form");
                        entity.Property(e => e.SanitizeOverridable).HasColumnName("sanitize_overridable");
                        entity.Property(e => e.SanitizeStyle).HasColumnName("sanitize_style");
                        entity.Property(e => e.SanitizeTags).HasColumnName("sanitize_tags");
                        entity.Property(e => e.Selectable).HasColumnName("selectable");
                        entity.Property(e => e.SerializationFieldId).HasColumnName("serialization_field_id");
                        entity.Property(e => e.Size).HasColumnName("size");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.Store).HasColumnName("store");
                        entity.Property(e => e.StripClasses).HasColumnName("strip_classes");
                        entity.Property(e => e.StripStyle).HasColumnName("strip_style");
                        entity.Property(e => e.Tracking).HasColumnName("tracking");
                        entity.Property(e => e.Translate).HasColumnName("translate");
                        entity.Property(e => e.Ttype).HasColumnName("ttype");
                        entity.Property(e => e.WebsiteFormBlacklisted)
                            .HasDefaultValue(true)
                            .HasColumnName("website_form_blacklisted");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrModelFieldsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_fields_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_fields_create_uid_fkey");

                        entity.HasOne(d => d.ModelNavigation).WithMany(p => p.IrModelFields)
                            .HasForeignKey(d => d.ModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_fields_model_id_fkey");

                        entity.HasOne(d => d.RelatedField).WithMany(p => p.InverseRelatedField)
                            .HasForeignKey(d => d.RelatedFieldId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_fields_related_field_id_fkey");

                        entity.HasOne(d => d.RelationFieldNavigation).WithMany(p => p.InverseRelationFieldNavigation)
                            .HasForeignKey(d => d.RelationFieldId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_fields_relation_field_id_fkey");

                        entity.HasOne(d => d.SerializationField).WithMany(p => p.InverseSerializationField)
                            .HasForeignKey(d => d.SerializationFieldId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_model_fields_serialization_field_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrModelFieldsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_model_fields_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_model_fields_write_uid_fkey");

                        // entity.HasMany(d => d.Group).WithMany(p => p.Field)
                        entity.HasMany(d => d.Group).WithMany(p => p.Field)
                            .UsingEntity<Dictionary<string, object>>(
                                "IrModelFieldsGroupRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("GroupId")
                                    .HasConstraintName("ir_model_fields_group_rel_group_id_fkey"),
                                l => l.HasOne<IrModelFields>().WithMany()
                                    .HasForeignKey("FieldId")
                                    .HasConstraintName("ir_model_fields_group_rel_field_id_fkey"),
                                j =>
                                {
                                    j.HasKey("FieldId", "GroupId").HasName("ir_model_fields_group_rel_pkey");
                                    j.ToTable("ir_model_fields_group_rel");
                                    j.HasIndex(new[] { "GroupId", "FieldId" }, "ir_model_fields_group_rel_group_id_field_id_idx");
                                    j.IndexerProperty<Guid>("FieldId").HasColumnName("field_id");
                                    j.IndexerProperty<Guid>("GroupId").HasColumnName("group_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}