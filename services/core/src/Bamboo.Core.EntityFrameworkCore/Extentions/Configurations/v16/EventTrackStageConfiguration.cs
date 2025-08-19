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
        public static void ConfigureEventTrackStage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventTrackStage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_track_stage_pkey");

            entity.ToTable("event_track_stage");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasColumnType("jsonb")
                .HasColumnName("description");
            entity.Property(e => e.Fold).HasColumnName("fold");
            entity.Property(e => e.IsCancel).HasColumnName("is_cancel");
            entity.Property(e => e.IsFullyAccessible).HasColumnName("is_fully_accessible");
            entity.Property(e => e.IsVisibleInAgenda).HasColumnName("is_visible_in_agenda");
            entity.Property(e => e.LegendBlocked)
                .HasColumnType("jsonb")
                .HasColumnName("legend_blocked");
            entity.Property(e => e.LegendDone)
                .HasColumnType("jsonb")
                .HasColumnName("legend_done");
            entity.Property(e => e.LegendNormal)
                .HasColumnType("jsonb")
                .HasColumnName("legend_normal");
            entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.EventTrackStageCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_track_stage_create_uid_fkey");

            entity.HasOne(d => d.MailTemplate).WithMany(p => p.EventTrackStage)
                .HasForeignKey(d => d.MailTemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_track_stage_mail_template_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.EventTrackStageWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_track_stage_write_uid_fkey");
            });
        }
    }
}