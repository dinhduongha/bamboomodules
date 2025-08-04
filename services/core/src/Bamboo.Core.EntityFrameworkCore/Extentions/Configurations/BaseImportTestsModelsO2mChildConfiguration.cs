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
        public static void ConfigureBaseImportTestsModelsO2mChild(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseImportTestsModelsO2mChild>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("base_import_tests_models_o2m_child_pkey");

                entity.ToTable("base_import_tests_models_o2m_child");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_import_tests_models_o2m_child_create_uid_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.BaseImportTestsModelsO2mChildren)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_import_tests_models_o2m_child_parent_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_import_tests_models_o2m_child_write_uid_fkey");
            });
        }
    }
}