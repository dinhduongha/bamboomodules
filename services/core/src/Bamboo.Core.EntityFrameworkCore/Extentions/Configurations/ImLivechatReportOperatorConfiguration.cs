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
        public static void ConfigureImLivechatReportOperator(this ModelBuilder modelBuilder)
        {
            // TODO HasNoKey
            /*
            modelBuilder.Entity<ImLivechatReportOperator>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("im_livechat_report_operator");

                entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                //entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.LivechatChannelId).HasColumnName("livechat_channel_id");
                entity.Property(e => e.NbrChannel).HasColumnName("nbr_channel");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.StartDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("start_date");
                entity.Property(e => e.TimeToAnswer).HasColumnName("time_to_answer");
            });
            */
        }
    }
}