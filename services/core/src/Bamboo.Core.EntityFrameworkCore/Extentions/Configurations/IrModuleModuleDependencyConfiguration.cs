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
        public static void ConfigureIrModuleModuleDependency(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModuleModuleDependency>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_module_module_dependency_pkey");

                entity.ToTable("ir_module_module_dependency");

                entity.HasIndex(e => e.Name, "ir_module_module_dependency_name_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");            
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.AutoInstallRequired)
                    .HasDefaultValueSql("true")
                    .HasColumnName("auto_install_required");
                entity.Property(e => e.ModuleId).HasColumnName("module_id");
                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.Module).WithMany(p => p.IrModuleModuleDependencies)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_module_module_dependency_module_id_fkey");
            });
        }
    }
}