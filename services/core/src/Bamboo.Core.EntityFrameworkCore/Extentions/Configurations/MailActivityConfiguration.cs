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
        public static void ConfigureMailActivity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailActivity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_activity_pkey");

                entity.ToTable("mail_activity");

                entity.HasIndex(e => e.DateDeadline, "mail_activity_date_deadline_index");

                entity.HasIndex(e => e.ResId, "mail_activity_res_id_index");

                entity.HasIndex(e => e.ResModelId, "mail_activity_res_model_id_index");

                entity.HasIndex(e => e.ResModel, "mail_activity_res_model_index");

                entity.HasIndex(e => e.UserId, "mail_activity_user_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");
                entity.Property(e => e.Automated).HasColumnName("automated");
                entity.Property(e => e.CalendarEventId).HasColumnName("calendar_event_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateDeadline).HasColumnName("date_deadline");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.NoteId).HasColumnName("note_id");
                entity.Property(e => e.PreviousActivityTypeId).HasColumnName("previous_activity_type_id");
                entity.Property(e => e.RecommendedActivityTypeId).HasColumnName("recommended_activity_type_id");
                entity.Property(e => e.RequestPartnerId).HasColumnName("request_partner_id");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
                entity.Property(e => e.ResName).HasColumnName("res_name");
                entity.Property(e => e.Summary).HasColumnName("summary");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.ActivityType).WithMany(p => p.MailActivityActivityTypes)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mail_activity_activity_type_id_fkey");

                entity.HasOne(d => d.CalendarEvent).WithMany(p => p.MailActivities)
                    .HasForeignKey(d => d.CalendarEventId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_activity_calendar_event_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_create_uid_fkey");

                entity.HasOne(d => d.NoteNavigation).WithMany(p => p.MailActivities)
                    .HasForeignKey(d => d.NoteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_activity_note_id_fkey");

                entity.HasOne(d => d.PreviousActivityType).WithMany(p => p.MailActivityPreviousActivityTypes)
                    .HasForeignKey(d => d.PreviousActivityTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_previous_activity_type_id_fkey");

                entity.HasOne(d => d.RecommendedActivityType).WithMany(p => p.MailActivityRecommendedActivityTypes)
                    .HasForeignKey(d => d.RecommendedActivityTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_recommended_activity_type_id_fkey");

                entity.HasOne(d => d.RequestPartner).WithMany(p => p.MailActivities)
                    .HasForeignKey(d => d.RequestPartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_request_partner_id_fkey");

                entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.MailActivities)
                    .HasForeignKey(d => d.ResModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_activity_res_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mail_activity_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_activity_write_uid_fkey");

                entity.HasMany(d => d.Attachments).WithMany(p => p.Activities)
                    .UsingEntity<Dictionary<string, object>>(
                        "ActivityAttachmentRel",
                        r => r.HasOne<IrAttachment>().WithMany()
                            .HasForeignKey("AttachmentId")
                            .HasConstraintName("activity_attachment_rel_attachment_id_fkey"),
                        l => l.HasOne<MailActivity>().WithMany()
                            .HasForeignKey("ActivityId")
                            .HasConstraintName("activity_attachment_rel_activity_id_fkey"),
                        j =>
                        {
                            j.HasKey("ActivityId", "AttachmentId").HasName("activity_attachment_rel_pkey");
                            j.ToTable("activity_attachment_rel");
                            j.HasIndex(new[] { "AttachmentId", "ActivityId" }, "activity_attachment_rel_attachment_id_activity_id_idx");
                            j.IndexerProperty<Guid>("ActivityId").HasColumnName("activity_id");
                            j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                        });
            });
        }
    }
}