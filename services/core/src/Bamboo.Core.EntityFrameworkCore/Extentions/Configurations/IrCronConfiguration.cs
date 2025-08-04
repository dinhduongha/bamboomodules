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
        public static void ConfigureIrCron(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrCron>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_cron_pkey");

                entity.ToTable("ir_cron");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CronName)
                    .HasColumnName("cron_name");
                entity.Property(e => e.Doall).HasColumnName("doall");
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_cron_create_uid_fkey");

                entity.HasOne(d => d.IrActionsServer).WithMany(p => p.IrCrons)
                    .HasForeignKey(d => d.IrActionsServerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ir_cron_ir_actions_server_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ir_cron_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_cron_write_uid_fkey");
            });
        }
    }
}