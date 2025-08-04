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
        public static void ConfigureMailingTraceReport(this ModelBuilder modelBuilder)
        {
            // TODO HasNoKey
            /*
            modelBuilder.Entity<MailingTraceReport>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("mailing_trace_report");

                entity.Property(e => e.Bounced).HasColumnName("bounced");
                entity.Property(e => e.Campaign)
                    .HasColumnType("character varying")
                    .HasColumnName("campaign");
                entity.Property(e => e.Canceled).HasColumnName("canceled");
                entity.Property(e => e.Clicked).HasColumnName("clicked");
                entity.Property(e => e.Delivered).HasColumnName("delivered");
                entity.Property(e => e.EmailFrom)
                    .HasColumnType("character varying")
                    .HasColumnName("email_from");
                entity.Property(e => e.Error).HasColumnName("error");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.MailingType)
                    .HasColumnType("character varying")
                    .HasColumnName("mailing_type");
                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
                entity.Property(e => e.Opened).HasColumnName("opened");
                entity.Property(e => e.Replied).HasColumnName("replied");
                entity.Property(e => e.Scheduled).HasColumnName("scheduled");
                entity.Property(e => e.ScheduledDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("scheduled_date");
                entity.Property(e => e.Sent).HasColumnName("sent");
                entity.Property(e => e.State)
                    .HasColumnType("character varying")
                    .HasColumnName("state");
            });
            */
        }
    }
}