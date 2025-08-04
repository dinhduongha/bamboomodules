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
        public static void ConfigureIrModuleModule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrModuleModule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_module_module_pkey");

                entity.ToTable("ir_module_module");

                entity.HasIndex(e => e.CategoryId, "ir_module_module_category_id_index");

                entity.HasIndex(e => e.Name, "ir_module_module_name_uniq").IsUnique();

                entity.HasIndex(e => e.State, "ir_module_module_state_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Application)
                    .HasDefaultValueSql("false")
                    .HasColumnName("application");
                entity.Property(e => e.Author).HasColumnName("author");
                entity.Property(e => e.AutoInstall)
                    .HasDefaultValueSql("false")
                    .HasColumnName("auto_install");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Contributors).HasColumnName("contributors");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Demo)
                    .HasDefaultValueSql("false")
                    .HasColumnName("demo");
                entity.Property(e => e.Description)
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.Icon).HasColumnName("icon");
                entity.Property(e => e.LatestVersion).HasColumnName("latest_version");
                entity.Property(e => e.License).HasColumnName("license");
                entity.Property(e => e.Maintainer).HasColumnName("maintainer");
                entity.Property(e => e.MenusByModule).HasColumnName("menus_by_module");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PublishedVersion).HasColumnName("published_version");
                entity.Property(e => e.ReportsByModule).HasColumnName("reports_by_module");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.Shortdesc)
                    .HasColumnType("jsonb")
                    .HasColumnName("shortdesc");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.Summary)
                    .HasColumnType("jsonb")
                    .HasColumnName("summary");
                entity.Property(e => e.ToBuy)
                    .HasDefaultValueSql("false")
                    .HasColumnName("to_buy");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.ViewsByModule).HasColumnName("views_by_module");
                entity.Property(e => e.Web)
                    .HasDefaultValueSql("false")
                    .HasColumnName("web");
                entity.Property(e => e.Website).HasColumnName("website");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Category).WithMany(p => p.IrModuleModules)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_module_module_category_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_module_module_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_module_module_write_uid_fkey");

                //entity.HasMany(d => d.Countries).WithMany(p => p.Modules)
                entity.HasMany<ResCountry>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ModuleCountry",
                        r => r.HasOne<ResCountry>().WithMany()
                            .HasForeignKey("CountryId")
                            .HasConstraintName("module_country_country_id_fkey"),
                        l => l.HasOne<IrModuleModule>().WithMany()
                            .HasForeignKey("ModuleId")
                            .HasConstraintName("module_country_module_id_fkey"),
                        j =>
                        {
                            j.HasKey("ModuleId", "CountryId").HasName("module_country_pkey");
                            j.ToTable("module_country");
                            j.HasIndex(new[] { "CountryId", "ModuleId" }, "module_country_country_id_module_id_idx");
                            j.IndexerProperty<Guid>("ModuleId").HasColumnName("module_id");
                            j.IndexerProperty<Guid>("CountryId").HasColumnName("country_id");
                        });
            });
        }
    }
}