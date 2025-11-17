using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ApplyViewsConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventSaleReport>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("event_sale_report");
            });
            modelBuilder.Entity<ImLivechatReportChannel>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("im_livechat_report_channel");
            });
            modelBuilder.Entity<ImLivechatReportOperator>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("im_livechat_report_operator");
            });
            modelBuilder.Entity<MailingTraceReport>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("mailing_trace_report");
            });
        }
    }
}
