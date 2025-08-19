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
        public static void ConfigureIrModuleModuleDependency(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrModuleModuleDependency>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_module_module_dependency_pkey");

            entity.ToTable("ir_module_module_dependency");

            entity.HasIndex(e => e.Name, "ir_module_module_dependency__name_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.AutoInstallRequired)
                .HasDefaultValue(true)
                .HasColumnName("auto_install_required");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Module).WithMany(p => p.IrModuleModuleDependency)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_module_module_dependency_module_id_fkey");
            });
        }
    }
}
