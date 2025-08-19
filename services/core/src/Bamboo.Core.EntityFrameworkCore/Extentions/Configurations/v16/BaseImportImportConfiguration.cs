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
        public static void ConfigureBaseImportImport(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseImportImport>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_import_import_pkey");

            entity.ToTable("base_import_import");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.File).HasColumnName("file");
            entity.Property(e => e.FileName).HasColumnName("file_name");
            entity.Property(e => e.FileType).HasColumnName("file_type");
            entity.Property(e => e.ResModel).HasColumnName("res_model");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseImportImportCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_import_import_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseImportImportWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_import_import_write_uid_fkey");
            });
        }
    }
}