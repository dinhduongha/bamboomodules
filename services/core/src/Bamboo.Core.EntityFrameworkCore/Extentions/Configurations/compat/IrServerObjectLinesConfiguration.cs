using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrServerObjectLines(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrServerObjectLines>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_server_object_lines_pkey");

                        entity.ToTable("ir_server_object_lines");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.Col1).HasColumnName("col1");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrServerObjectLinesCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_server_object_lines_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_server_object_lines_create_uid_fkey");

                        entity.HasOne(d => d.Server).WithMany(p => p.IrServerObjectLines)
                            .HasForeignKey(d => d.ServerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_server_object_lines_server_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrServerObjectLinesWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_server_object_lines_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_server_object_lines_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}