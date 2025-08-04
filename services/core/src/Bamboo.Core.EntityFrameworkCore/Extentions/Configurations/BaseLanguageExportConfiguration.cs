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
        public static void ConfigureBaseLanguageExport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseLanguageExport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("base_language_export_pkey");

                entity.ToTable("base_language_export");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Data).HasColumnName("data");
                entity.Property(e => e.Domain).HasColumnName("domain");
                entity.Property(e => e.ExportType).HasColumnName("export_type");
                entity.Property(e => e.Format).HasColumnName("format");
                entity.Property(e => e.Lang).HasColumnName("lang");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_language_export_create_uid_fkey");

                //entity.HasOne(d => d.Model).WithMany(p => p.BaseLanguageExports)
                entity.HasOne(d => d.Model).WithMany()
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_language_export_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("base_language_export_write_uid_fkey");

                //entity.HasMany(d => d.Modules).WithMany(p => p.Wizs)
                entity.HasMany<IrModuleModule>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "RelModulesLangexport",
                        r => r.HasOne<IrModuleModule>().WithMany()
                            .HasForeignKey("ModuleId")
                            .HasConstraintName("rel_modules_langexport_module_id_fkey"),
                        l => l.HasOne<BaseLanguageExport>().WithMany()
                            .HasForeignKey("WizId")
                            .HasConstraintName("rel_modules_langexport_wiz_id_fkey"),
                        j =>
                        {
                            j.HasKey("WizId", "ModuleId").HasName("rel_modules_langexport_pkey");
                            j.ToTable("rel_modules_langexport");
                            j.HasIndex(new[] { "ModuleId", "WizId" }, "rel_modules_langexport_module_id_wiz_id_idx");
                            j.IndexerProperty<Guid>("WizId").HasColumnName("wiz_id");
                            j.IndexerProperty<Guid>("ModuleId").HasColumnName("module_id");
                        });
            });
        }
    }
}