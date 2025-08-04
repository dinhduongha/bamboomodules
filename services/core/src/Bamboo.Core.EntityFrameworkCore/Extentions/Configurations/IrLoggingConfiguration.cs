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
        public static void ConfigureIrLogging(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrLogging>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_logging_pkey");

                entity.ToTable("ir_logging");

                entity.HasIndex(e => e.Dbname, "ir_logging_dbname_index");

                entity.HasIndex(e => e.Level, "ir_logging_level_index");

                entity.HasIndex(e => e.Type, "ir_logging_type_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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