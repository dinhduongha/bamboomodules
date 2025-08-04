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
        public static void ConfigureIrModuleModuleExclusion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModuleModuleExclusion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_module_module_exclusion_pkey");

                entity.ToTable("ir_module_module_exclusion");

                entity.HasIndex(e => e.Name, "ir_module_module_exclusion_name_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ModuleId).HasColumnName("module_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_module_module_exclusion_create_uid_fkey");

                entity.HasOne(d => d.Module).WithMany(p => p.IrModuleModuleExclusions)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_module_module_exclusion_module_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_module_module_exclusion_write_uid_fkey");
            });
        }
    }
}