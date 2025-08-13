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
        public static void ConfigureIrModelFields(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModelFields>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_model_fields_pkey");

                entity.ToTable("ir_model_fields");

                entity.HasIndex(e => e.CompleteName, "ir_model_fields_complete_name_index");

                entity.HasIndex(e => e.ModelId, "ir_model_fields_model_id_index");

                entity.HasIndex(e => e.Model, "ir_model_fields_model_index");

                entity.HasIndex(e => e.Name, "ir_model_fields_name_index");

                entity.HasIndex(e => new { e.Model, e.Name }, "ir_model_fields_name_unique").IsUnique();

                entity.HasIndex(e => e.State, "ir_model_fields_state_index");

                entity.HasIndex(e => e.WebsiteFormBlacklisted, "ir_model_fields_website_form_blacklisted_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Column1).HasColumnName("column1");
                entity.Property(e => e.Column2).HasColumnName("column2");
                entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                entity.Property(e => e.Compute).HasColumnName("compute");
                entity.Property(e => e.Copied).HasColumnName("copied");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
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
                entity.Property(e => e.Selectable).HasColumnName("selectable");
                entity.Property(e => e.Size).HasColumnName("size");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.Store).HasColumnName("store");
                entity.Property(e => e.Tracking).HasColumnName("tracking");
                entity.Property(e => e.Translate).HasColumnName("translate");
                entity.Property(e => e.Ttype).HasColumnName("ttype");
                entity.Property(e => e.WebsiteFormBlacklisted)
                    .HasDefaultValueSql("true")
                    .HasColumnName("website_form_blacklisted");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_model_fields_write_uid_fkey");

                //entity.HasMany(d => d.Groups).WithMany(p => p.Fields)
                entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IrModelFieldsGroupRel",
                        r => r.HasOne<ResGroup>().WithMany()
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
                        });
            });
        }
    }
}