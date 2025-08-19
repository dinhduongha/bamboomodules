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
        public static void ConfigureMailingMailingScheduleDate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailingMailingScheduleDate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mailing_mailing_schedule_date_pkey");

            entity.ToTable("mailing_mailing_schedule_date");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MassMailingId).HasColumnName("mass_mailing_id");
            entity.Property(e => e.ScheduleDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("schedule_date");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailingMailingScheduleDateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_mailing_schedule_date_create_uid_fkey");

            entity.HasOne(d => d.MassMailing).WithMany(p => p.MailingMailingScheduleDate)
                .HasForeignKey(d => d.MassMailingId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mailing_mailing_schedule_date_mass_mailing_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailingMailingScheduleDateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mailing_mailing_schedule_date_write_uid_fkey");
            });
        }
    }
}