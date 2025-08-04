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
        public static void ConfigureImLivechatReportChannel(this ModelBuilder modelBuilder)
        {
            // TODO HasNoKey
            /*
            modelBuilder.Entity<ImLivechatReportChannel>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("im_livechat_report_channel");

                entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                entity.Property(e => e.ChannelName)
                    .HasColumnType("character varying")
                    .HasColumnName("channel_name");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.DayNumber).HasColumnName("day_number");
                entity.Property(e => e.DaysOfActivity).HasColumnName("days_of_activity");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                //entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.IsAnonymous).HasColumnName("is_anonymous");
                entity.Property(e => e.IsHappy).HasColumnName("is_happy");
                entity.Property(e => e.IsUnrated).HasColumnName("is_unrated");
                entity.Property(e => e.IsWithoutAnswer).HasColumnName("is_without_answer");
                entity.Property(e => e.LivechatChannelId).HasColumnName("livechat_channel_id");
                entity.Property(e => e.NbrMessage).HasColumnName("nbr_message");
                entity.Property(e => e.NbrSpeaker).HasColumnName("nbr_speaker");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.Rating).HasColumnName("rating");
                entity.Property(e => e.RatingText).HasColumnName("rating_text");
                entity.Property(e => e.StartDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("start_date");
                entity.Property(e => e.StartDateHour).HasColumnName("start_date_hour");
                entity.Property(e => e.StartHour).HasColumnName("start_hour");
                entity.Property(e => e.TechnicalName).HasColumnName("technical_name");
                entity.Property(e => e.TimeToAnswer).HasColumnName("time_to_answer");
                entity.Property(e => e.Uuid)
                    .HasMaxLength(50)
                    .HasColumnName("uuid");
            });
            */
        }
    }
}