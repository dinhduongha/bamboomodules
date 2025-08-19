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
        public static void ConfigureIrAsset(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrAsset>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_asset_pkey");

            entity.ToTable("ir_asset");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Bundle).HasColumnName("bundle");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Directive).HasColumnName("directive");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Path).HasColumnName("path");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.Target).HasColumnName("target");
            entity.Property(e => e.ThemeTemplateId).HasColumnName("theme_template_id");
            entity.Property(e => e.WebsiteId).HasColumnName("website_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrAssetCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_asset_create_uid_fkey");

            entity.HasOne(d => d.ThemeTemplate).WithMany(p => p.IrAsset)
                .HasForeignKey(d => d.ThemeTemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_asset_theme_template_id_fkey");

            // entity.HasOne(d => d.Website).WithMany(p => p.IrAsset)
            entity.HasOne(d => d.Website).WithMany()
                .HasForeignKey(d => d.WebsiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_asset_website_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrAssetWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_asset_write_uid_fkey");
            });
        }
    }
}