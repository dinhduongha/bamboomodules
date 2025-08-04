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
        public static void ConfigureCalendarEvent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarEvent>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("calendar_event_pkey");

                entity.ToTable("calendar_event");

                entity.HasIndex(e => e.TenantId, "calendar_event_company_id_index");

                entity.HasIndex(e => e.AccessToken, "calendar_event_access_token_index");

                entity.HasIndex(e => e.ApplicantId, "calendar_event_applicant_id_index").HasFilter("(applicant_id IS NOT NULL)");

                entity.HasIndex(e => e.OpportunityId, "calendar_event_opportunity_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Allday).HasColumnName("allday");
                entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.FollowRecurrence).HasColumnName("follow_recurrence");
                entity.Property(e => e.Location).HasColumnName("location");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OpportunityId).HasColumnName("opportunity_id");
                entity.Property(e => e.Privacy).HasColumnName("privacy");
                entity.Property(e => e.RecurrenceId).HasColumnName("recurrence_id");
                entity.Property(e => e.Recurrency).HasColumnName("recurrency");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.ResModelId).HasColumnName("res_model_id");
                entity.Property(e => e.ShowAs).HasColumnName("show_as");
                entity.Property(e => e.Start)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("start");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
                entity.Property(e => e.Stop)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("stop");
                entity.Property(e => e.StopDate).HasColumnName("stop_date");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.VideocallChannelId).HasColumnName("videocall_channel_id");
                entity.Property(e => e.VideocallLocation).HasColumnName("videocall_location");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Applicant).WithMany(p => p.CalendarEvents)
                    .HasForeignKey(d => d.ApplicantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_applicant_id_fkey");

                entity.HasOne(d => d.Candidate).WithMany(p => p.CalendarEvents)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_candidate_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CalendarEvents)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Opportunity).WithMany(p => p.CalendarEvents)
                    .HasForeignKey(d => d.OpportunityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_opportunity_id_fkey");

                entity.HasOne(d => d.Recurrence).WithMany(p => p.CalendarEvents)
                    .HasForeignKey(d => d.RecurrenceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_recurrence_id_fkey");

                entity.HasOne(d => d.ResModelNavigation).WithMany(p => p.CalendarEvents)
                    .HasForeignKey(d => d.ResModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("calendar_event_res_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_user_id_fkey");

                entity.HasOne(d => d.VideocallChannel).WithMany(p => p.CalendarEvents)
                    .HasForeignKey(d => d.VideocallChannelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_videocall_channel_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_write_uid_fkey");

                //entity.HasMany(d => d.CalendarAlarms).WithMany(p => p.CalendarEvents)
                entity.HasMany<CalendarAlarm>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "CalendarAlarmCalendarEventRel",
                        r => r.HasOne<CalendarAlarm>().WithMany()
                            .HasForeignKey("CalendarAlarmId")
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("calendar_alarm_calendar_event_rel_calendar_alarm_id_fkey"),
                        l => l.HasOne<CalendarEvent>().WithMany()
                            .HasForeignKey("CalendarEventId")
                            .HasConstraintName("calendar_alarm_calendar_event_rel_calendar_event_id_fkey"),
                        j =>
                        {
                            j.HasKey("CalendarEventId", "CalendarAlarmId").HasName("calendar_alarm_calendar_event_rel_pkey");
                            j.ToTable("calendar_alarm_calendar_event_rel");
                            j.HasIndex(new[] { "CalendarAlarmId", "CalendarEventId" }, "calendar_alarm_calendar_event_calendar_alarm_id_calendar_ev_idx");
                            j.IndexerProperty<Guid>("CalendarEventId").HasColumnName("calendar_event_id");
                            j.IndexerProperty<Guid>("CalendarAlarmId").HasColumnName("calendar_alarm_id");
                        });

                //entity.HasMany(d => d.Types).WithMany(p => p.Events)
                entity.HasMany<CalendarEventType>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MeetingCategoryRel",
                        r => r.HasOne<CalendarEventType>().WithMany()
                            .HasForeignKey("TypeId")
                            .HasConstraintName("meeting_category_rel_type_id_fkey"),
                        l => l.HasOne<CalendarEvent>().WithMany()
                            .HasForeignKey("EventId")
                            .HasConstraintName("meeting_category_rel_event_id_fkey"),
                        j =>
                        {
                            j.HasKey("EventId", "TypeId").HasName("meeting_category_rel_pkey");
                            j.ToTable("meeting_category_rel");
                            j.HasIndex(new[] { "TypeId", "EventId" }, "meeting_category_rel_type_id_event_id_idx");
                            j.IndexerProperty<Guid>("EventId").HasColumnName("event_id");
                            j.IndexerProperty<Guid>("TypeId").HasColumnName("type_id");
                        });
            });
        }
    }
}