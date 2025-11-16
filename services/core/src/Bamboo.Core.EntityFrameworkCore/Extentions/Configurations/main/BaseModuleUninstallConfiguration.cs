using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureBaseModuleUninstall(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseModuleUninstall>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_module_uninstall_pkey");

                        entity.ToTable("base_module_uninstall");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ShowAll).HasColumnName("show_all");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseModuleUninstallCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_module_uninstall_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_module_uninstall_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseModuleUninstallWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_module_uninstall_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_module_uninstall_write_uid_fkey");

                        // entity.HasMany(d => d.IrModuleModule).WithMany(p => p.BaseModuleUninstall)
                        entity.HasMany(d => d.IrModuleModule).WithMany(p => p.BaseModuleUninstall)
                            .UsingEntity<Dictionary<string, object>>(
                                "BaseModuleUninstallIrModuleModuleRel",
                                r => r.HasOne<IrModuleModule>().WithMany()
                                    .HasForeignKey("IrModuleModuleId")
                                    .HasConstraintName("base_module_uninstall_ir_module_module_ir_module_module_id_fkey"),
                                l => l.HasOne<BaseModuleUninstall>().WithMany()
                                    .HasForeignKey("BaseModuleUninstallId")
                                    .HasConstraintName("base_module_uninstall_ir_module_m_base_module_uninstall_id_fkey"),
                                j =>
                                {
                                    j.HasKey("BaseModuleUninstallId", "IrModuleModuleId").HasName("base_module_uninstall_ir_module_module_rel_pkey");
                                    j.ToTable("base_module_uninstall_ir_module_module_rel");
                                    j.HasIndex(new[] { "IrModuleModuleId", "BaseModuleUninstallId" }, "base_module_uninstall_ir_modu_ir_module_module_id_base_modu_idx");
                                    j.IndexerProperty<Guid>("BaseModuleUninstallId").HasColumnName("base_module_uninstall_id");
                                    j.IndexerProperty<Guid>("IrModuleModuleId").HasColumnName("ir_module_module_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}