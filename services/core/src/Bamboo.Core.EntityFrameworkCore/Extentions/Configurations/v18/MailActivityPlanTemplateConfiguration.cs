using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailActivityPlanTemplate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailActivityPlanTemplate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_activity_plan_template_pkey");

                        entity.ToTable("mail_activity_plan_template");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DelayCount).HasColumnName("delay_count");
                        entity.Property(e => e.DelayFrom).HasColumnName("delay_from");
                        entity.Property(e => e.DelayUnit).HasColumnName("delay_unit");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.PlanId).HasColumnName("plan_id");
                        entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");
                        entity.Property(e => e.ResponsibleType).HasColumnName("responsible_type");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Summary).HasColumnName("summary");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ActivityType).WithMany(p => p.MailActivityPlanTemplate)
                            .HasForeignKey(d => d.ActivityTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mail_activity_plan_template_activity_type_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailActivityPlanTemplateCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_activity_plan_template_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_activity_plan_template_create_uid_fkey");

                        entity.HasOne(d => d.Plan).WithMany(p => p.MailActivityPlanTemplate)
                            .HasForeignKey(d => d.PlanId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_activity_plan_template_plan_id_fkey");

                        // entity.HasOne(d => d.Responsible).WithMany(p => p.MailActivityPlanTemplateResponsible) .HasForeignKey(d => d.ResponsibleId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_activity_plan_template_responsible_id_fkey");
                        entity.HasOne(d => d.Responsible).WithMany()
                            .HasForeignKey(d => d.ResponsibleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_activity_plan_template_responsible_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailActivityPlanTemplateWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_activity_plan_template_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_activity_plan_template_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}