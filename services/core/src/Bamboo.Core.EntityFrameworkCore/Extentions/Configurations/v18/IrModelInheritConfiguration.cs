using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

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
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.ParentFieldId).HasColumnName("parent_field_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");

            entity.HasOne(d => d.Model).WithMany(p => p.IrModelInheritModel)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_model_inherit_model_id_fkey");

            entity.HasOne(d => d.ParentField).WithMany(p => p.IrModelInherit)
                .HasForeignKey(d => d.ParentFieldId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_model_inherit_parent_field_id_fkey");

            entity.HasOne(d => d.Parent).WithMany(p => p.IrModelInheritParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_model_inherit_parent_id_fkey");
            });
        }
    }
}