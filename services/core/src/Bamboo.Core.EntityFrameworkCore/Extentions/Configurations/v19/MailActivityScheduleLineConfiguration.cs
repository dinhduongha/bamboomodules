using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailActivityScheduleLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailActivityScheduleLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_activity_schedule_line_pkey");

                        entity.ToTable("mail_activity_schedule_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ActivityScheduleId).HasColumnName("activity_schedule_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LineDateDeadline).HasColumnName("line_date_deadline");
                        entity.Property(e => e.LineDescription).HasColumnName("line_description");
                        entity.Property(e => e.ResponsibleUserId).HasColumnName("responsible_user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ActivitySchedule).WithMany(p => p.MailActivityScheduleLine)
                            .HasForeignKey(d => d.ActivityScheduleId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_activity_schedule_line_activity_schedule_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailActivityScheduleLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_activity_schedule_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_activity_schedule_line_create_uid_fkey");

                        // entity.HasOne(d => d.ResponsibleUser).WithMany(p => p.MailActivityScheduleLineResponsibleUser) .HasForeignKey(d => d.ResponsibleUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_activity_schedule_line_responsible_user_id_fkey");
                        entity.HasOne(d => d.ResponsibleUser).WithMany()
                            .HasForeignKey(d => d.ResponsibleUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_activity_schedule_line_responsible_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailActivityScheduleLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_activity_schedule_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_activity_schedule_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}