using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFollowupLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<FollowupLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("followup_line_pkey");

                        entity.ToTable("followup_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => new { e.FollowupId, e.Delay }, "followup_line_days_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Delay).HasColumnName("delay");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.EmailTemplateId).HasColumnName("email_template_id");
                        entity.Property(e => e.FollowupId).HasColumnName("followup_id");
                        entity.Property(e => e.ManualAction).HasColumnName("manual_action");
                        entity.Property(e => e.ManualActionNote).HasColumnName("manual_action_note");
                        entity.Property(e => e.ManualActionResponsibleId).HasColumnName("manual_action_responsible_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.SendEmail).HasColumnName("send_email");
                        entity.Property(e => e.SendLetter).HasColumnName("send_letter");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.FollowupLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("followup_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("followup_line_create_uid_fkey");

                        entity.HasOne(d => d.EmailTemplate).WithMany(p => p.FollowupLine)
                            .HasForeignKey(d => d.EmailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("followup_line_email_template_id_fkey");

                        entity.HasOne(d => d.Followup).WithMany(p => p.FollowupLine)
                            .HasForeignKey(d => d.FollowupId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("followup_line_followup_id_fkey");

                        // entity.HasOne(d => d.ManualActionResponsible).WithMany(p => p.FollowupLineManualActionResponsible) .HasForeignKey(d => d.ManualActionResponsibleId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("followup_line_manual_action_responsible_id_fkey");
                        entity.HasOne(d => d.ManualActionResponsible).WithMany()
                            .HasForeignKey(d => d.ManualActionResponsibleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("followup_line_manual_action_responsible_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.FollowupLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("followup_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("followup_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}