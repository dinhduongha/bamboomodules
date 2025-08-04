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
        public static void ConfigureIrCronTrigger(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrCronTrigger>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_cron_trigger_pkey");

                entity.ToTable("ir_cron_trigger");

                entity.HasIndex(e => e.CronId, "ir_cron_trigger_cron_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CallAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("call_at");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CronId).HasColumnName("cron_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_cron_trigger_create_uid_fkey");

                entity.HasOne(d => d.Cron).WithMany(p => p.IrCronTriggers)
                    .HasForeignKey(d => d.CronId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_cron_trigger_cron_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_cron_trigger_write_uid_fkey");
            });
        }
    }
}