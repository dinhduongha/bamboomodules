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
        public static void ConfigureIrServerObjectLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrServerObjectLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_server_object_lines_pkey");

                entity.ToTable("ir_server_object_lines");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Col1).HasColumnName("col1");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EvaluationType).HasColumnName("evaluation_type");
                entity.Property(e => e.ServerId).HasColumnName("server_id");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Col1Navigation).WithMany(p => p.IrServerObjectLines)
                    .HasForeignKey(d => d.Col1)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_server_object_lines_col1_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_server_object_lines_create_uid_fkey");

                entity.HasOne(d => d.Server).WithMany(p => p.IrServerObjectLines)
                    .HasForeignKey(d => d.ServerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_server_object_lines_server_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_server_object_lines_write_uid_fkey");
            });
        }
    }
}