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
        public static void ConfigureBaseLanguageInstall(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseLanguageInstall>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_language_install_pkey");

            entity.ToTable("base_language_install");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Overwrite).HasColumnName("overwrite");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseLanguageInstallCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_language_install_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseLanguageInstallWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_language_install_write_uid_fkey");

            // entity.HasMany(d => d.Lang).WithMany(p => p.LanguageWizard)
            entity.HasMany(d => d.Lang).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ResLangInstallRel",
                    r => r.HasOne<ResLang>().WithMany()
                        .HasForeignKey("LangId")
                        .HasConstraintName("res_lang_install_rel_lang_id_fkey"),
                    l => l.HasOne<BaseLanguageInstall>().WithMany()
                        .HasForeignKey("LanguageWizardId")
                        .HasConstraintName("res_lang_install_rel_language_wizard_id_fkey"),
                    j =>
                    {
                        j.HasKey("LanguageWizardId", "LangId").HasName("res_lang_install_rel_pkey");
                        j.ToTable("res_lang_install_rel");
                        j.HasIndex(new[] { "LangId", "LanguageWizardId" }, "res_lang_install_rel_lang_id_language_wizard_id_idx");
                        j.IndexerProperty<Guid>("LanguageWizardId").HasColumnName("language_wizard_id");
                        j.IndexerProperty<Guid>("LangId").HasColumnName("lang_id");
                    });

            // entity.HasMany(d => d.Website).WithMany(p => p.BaseLanguageInstall)
            entity.HasMany(d => d.Website).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "BaseLanguageInstallWebsiteRel",
                    r => r.HasOne<Website>().WithMany()
                        .HasForeignKey("WebsiteId")
                        .HasConstraintName("base_language_install_website_rel_website_id_fkey"),
                    l => l.HasOne<BaseLanguageInstall>().WithMany()
                        .HasForeignKey("BaseLanguageInstallId")
                        .HasConstraintName("base_language_install_website_rel_base_language_install_id_fkey"),
                    j =>
                    {
                        j.HasKey("BaseLanguageInstallId", "WebsiteId").HasName("base_language_install_website_rel_pkey");
                        j.ToTable("base_language_install_website_rel");
                        j.HasIndex(new[] { "WebsiteId", "BaseLanguageInstallId" }, "base_language_install_website_website_id_base_language_inst_idx");
                        j.IndexerProperty<Guid>("BaseLanguageInstallId").HasColumnName("base_language_install_id");
                        j.IndexerProperty<Guid>("WebsiteId").HasColumnName("website_id");
                    });
            });
        }
    }
}