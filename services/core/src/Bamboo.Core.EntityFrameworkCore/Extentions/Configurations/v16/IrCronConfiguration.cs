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
        public static void ConfigureIrCron(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrCron>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_cron_pkey");

            entity.ToTable("ir_cron");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CronName).HasColumnName("cron_name");
            //entity.Property(e => e.CronName)
            //    .HasColumnType("jsonb")
            //    .HasColumnName("cron_name");
            entity.Property(e => e.Doall).HasColumnName("doall");
            entity.Property(e => e.FailureCount).HasColumnName("failure_count");
            entity.Property(e => e.FirstFailureDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("first_failure_date");
            entity.Property(e => e.IntervalNumber).HasColumnName("interval_number");
            entity.Property(e => e.IntervalType).HasColumnName("interval_type");
            entity.Property(e => e.IrActionsServerId).HasColumnName("ir_actions_server_id");
            entity.Property(e => e.Lastcall)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastcall");
            entity.Property(e => e.Nextcall)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("nextcall");
            entity.Property(e => e.Numbercall).HasColumnName("numbercall");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrCronCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_cron_create_uid_fkey");

            entity.HasOne(d => d.IrActionsServer).WithMany(p => p.IrCron)
                .HasForeignKey(d => d.IrActionsServerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ir_cron_ir_actions_server_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.IrCronUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ir_cron_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrCronWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_cron_write_uid_fkey");
            });
        }
    }
}
