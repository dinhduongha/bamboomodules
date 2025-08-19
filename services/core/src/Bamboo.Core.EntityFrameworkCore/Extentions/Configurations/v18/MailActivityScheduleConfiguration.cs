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
        public static void ConfigureMailActivitySchedule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailActivitySchedule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_activity_schedule_pkey");

            entity.ToTable("mail_activity_schedule");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");
            entity.Property(e => e.ActivityUserId).HasColumnName("activity_user_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DateDeadline).HasColumnName("date_deadline");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PlanDate).HasColumnName("plan_date");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.PlanOnDemandUserId).HasColumnName("plan_on_demand_user_id");
            entity.Property(e => e.ResIds).HasColumnName("res_ids");
            entity.Property(e => e.ResModel).HasColumnName("res_model");
            entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.ActivityType).WithMany(p => p.MailActivitySchedule)
                .HasForeignKey(d => d.ActivityTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_activity_schedule_activity_type_id_fkey");

            entity.HasOne(d => d.ActivityUser).WithMany()
                .HasForeignKey(d => d.ActivityUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_activity_schedule_activity_user_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailActivityScheduleCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_activity_schedule_create_uid_fkey");

            entity.HasOne(d => d.Plan).WithMany(p => p.MailActivityScheduleNavigation)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_activity_schedule_plan_id_fkey");

            entity.HasOne(d => d.PlanOnDemandUser).WithMany()
                .HasForeignKey(d => d.PlanOnDemandUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_activity_schedule_plan_on_demand_user_id_fkey");

            entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.MailActivitySchedule)
                .HasForeignKey(d => d.ResModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_activity_schedule_res_model_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailActivityScheduleWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_activity_schedule_write_uid_fkey");

            // entity.HasMany(d => d.MailActivityPlan).WithMany(p => p.MailActivitySchedule)
            entity.HasMany(d => d.MailActivityPlan).WithMany(p => p.MailActivitySchedule)
                .UsingEntity<Dictionary<string, object>>(
                    "MailActivityPlanMailActivityScheduleRel",
                    r => r.HasOne<MailActivityPlan>().WithMany()
                        .HasForeignKey("MailActivityPlanId")
                        .HasConstraintName("mail_activity_plan_mail_activity_sch_mail_activity_plan_id_fkey"),
                    l => l.HasOne<MailActivitySchedule>().WithMany()
                        .HasForeignKey("MailActivityScheduleId")
                        .HasConstraintName("mail_activity_plan_mail_activity_mail_activity_schedule_id_fkey"),
                    j =>
                    {
                        j.HasKey("MailActivityScheduleId", "MailActivityPlanId").HasName("mail_activity_plan_mail_activity_schedule_rel_pkey");
                        j.ToTable("mail_activity_plan_mail_activity_schedule_rel");
                        j.HasIndex(new[] { "MailActivityPlanId", "MailActivityScheduleId" }, "mail_activity_plan_mail_activ_mail_activity_plan_id_mail_ac_idx");
                        j.IndexerProperty<Guid>("MailActivityScheduleId").HasColumnName("mail_activity_schedule_id");
                        j.IndexerProperty<Guid>("MailActivityPlanId").HasColumnName("mail_activity_plan_id");
                    });
            });
        }
    }
}