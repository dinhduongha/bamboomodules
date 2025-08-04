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
        public static void ConfigureIrModelInherit(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModelInherit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_model_inherit_pkey");

                entity.ToTable("ir_model_inherit");

                entity.HasIndex(e => new { e.ModelId, e.ParentId }, "ir_model_inherit_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.ParentFieldId).HasColumnName("parent_field_id");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");

                entity.HasOne(d => d.Model).WithMany(p => p.IrModelInheritModels)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_inherit_model_id_fkey");

                entity.HasOne(d => d.ParentField).WithMany(p => p.IrModelInherits)
                    .HasForeignKey(d => d.ParentFieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_inherit_parent_field_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.IrModelInheritParents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_model_inherit_parent_id_fkey");
            });
        }
    }
}