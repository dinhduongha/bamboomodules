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
        public static void ConfigureIrSequenceDateRange(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrSequenceDateRange>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_sequence_date_range_pkey");

            entity.ToTable("ir_sequence_date_range");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.NumberNext).HasColumnName("number_next");
            entity.Property(e => e.SequenceId).HasColumnName("sequence_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrSequenceDateRangeCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_sequence_date_range_create_uid_fkey");

            entity.HasOne(d => d.Sequence).WithMany(p => p.IrSequenceDateRange)
                .HasForeignKey(d => d.SequenceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_sequence_date_range_sequence_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrSequenceDateRangeWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_sequence_date_range_write_uid_fkey");
            });
        }
    }
}