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
        public static void ConfigureIrLogging(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrLogging>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_logging_pkey");

            entity.ToTable("ir_logging");

            entity.HasIndex(e => e.Dbname, "ir_logging__dbname_index");

            entity.HasIndex(e => e.Level, "ir_logging__level_index");

            entity.HasIndex(e => e.Type, "ir_logging__type_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Dbname).HasColumnName("dbname");
            entity.Property(e => e.Func).HasColumnName("func");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Line).HasColumnName("line");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Path).HasColumnName("path");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            });
        }
    }
}
