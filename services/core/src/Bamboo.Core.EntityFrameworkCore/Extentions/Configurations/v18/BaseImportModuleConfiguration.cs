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
        public static void ConfigureBaseImportModule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseImportModule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_import_module_pkey");

            entity.ToTable("base_import_module");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Force).HasColumnName("force");
            entity.Property(e => e.ImportMessage).HasColumnName("import_message");
            entity.Property(e => e.ModuleFile).HasColumnName("module_file");
            entity.Property(e => e.ModulesDependencies).HasColumnName("modules_dependencies");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.WithDemo).HasColumnName("with_demo");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseImportModuleCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_import_module_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseImportModuleWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_import_module_write_uid_fkey");
            });
        }
    }
}