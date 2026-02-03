using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsMessagingChannelConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsMessagingChannelConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_messaging_channel_config_pkey");

            entity.ToTable("dms_messaging_channel_config");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.Channel).HasColumnName("channel");
            entity.Property(e => e.ApiKey).HasColumnName("api_key");
            entity.Property(e => e.BotToken).HasColumnName("bot_token");
            entity.Property(e => e.WebhookUrl).HasColumnName("webhook_url");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MessageTemplate);

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}