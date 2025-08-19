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
        public static void ConfigureIrCronTrigger(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrCronTrigger>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_cron_trigger_pkey");

            entity.ToTable("ir_cron_trigger");

            entity.HasIndex(e => e.CallAt, "ir_cron_trigger__call_at_index");

            entity.HasIndex(e => e.CronId, "ir_cron_trigger__cron_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CallAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("call_at");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CronId).HasColumnName("cron_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrCronTriggerCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_cron_trigger_create_uid_fkey");

            entity.HasOne(d => d.Cron).WithMany(p => p.IrCronTrigger)
                .HasForeignKey(d => d.CronId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_cron_trigger_cron_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrCronTriggerWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_cron_trigger_write_uid_fkey");
            });
        }
    }
}
