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
        public static void ConfigureMailingMailingScheduleDate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailingMailingScheduleDate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mailing_mailing_schedule_date_pkey");

                entity.ToTable("mailing_mailing_schedule_date", tb => tb.HasComment("schedule a mailing"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.MassMailingId)
                    .HasComment("Mass Mailing")
                    .HasColumnName("mass_mailing_id");
                entity.Property(e => e.ScheduleDate)
                    .HasComment("Scheduled for")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("schedule_date");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_schedule_date_create_uid_fkey");

                entity.HasOne(d => d.MassMailing).WithMany(p => p.MailingMailingScheduleDates)
                    .HasForeignKey(d => d.MassMailingId)
                    .HasConstraintName("mailing_mailing_schedule_date_mass_mailing_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_schedule_date_write_uid_fkey");
            });
        }
    }
}