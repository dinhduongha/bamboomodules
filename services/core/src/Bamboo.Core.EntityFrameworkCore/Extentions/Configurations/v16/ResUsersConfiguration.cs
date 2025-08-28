using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResUsers(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResUsers>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_users_pkey");

                        entity.ToTable("res_users");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CreationTime, "res_users__create_date_index");

                        entity.HasIndex(e => e.PartnerId, "res_users__partner_id_index");

                        entity.HasIndex(e => new { e.Login, e.WebsiteId }, "res_users_login_key").IsUnique();

                        entity.HasIndex(e => new { e.OauthProviderId, e.OauthUid }, "res_users_uniq_users_oauth_provider_oauth_uid").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ActionId).HasColumnName("action_id");
                        entity.Property(e => e.Active)
                            .HasDefaultValue(true)
                            .HasColumnName("active");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Karma).HasColumnName("karma");
                        entity.Property(e => e.LastLunchLocationId).HasColumnName("last_lunch_location_id");
                        entity.Property(e => e.Login).HasColumnName("login");
                        entity.Property(e => e.MicrosoftCalendarRtoken).HasColumnName("microsoft_calendar_rtoken");
                        entity.Property(e => e.MicrosoftCalendarToken).HasColumnName("microsoft_calendar_token");
                        entity.Property(e => e.MicrosoftCalendarTokenValidity)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("microsoft_calendar_token_validity");
                        entity.Property(e => e.NextRankId).HasColumnName("next_rank_id");
                        entity.Property(e => e.NotificationType).HasColumnName("notification_type");
                        entity.Property(e => e.OauthAccessToken).HasColumnName("oauth_access_token");
                        entity.Property(e => e.OauthProviderId).HasColumnName("oauth_provider_id");
                        entity.Property(e => e.OauthUid).HasColumnName("oauth_uid");
                        entity.Property(e => e.OdoobotFailed).HasColumnName("odoobot_failed");
                        entity.Property(e => e.OdoobotState).HasColumnName("odoobot_state");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Password).HasColumnName("password");
                        entity.Property(e => e.PropertyWarehouseId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_warehouse_id");
                        entity.Property(e => e.RankId).HasColumnName("rank_id");
                        entity.Property(e => e.SaleTeamId).HasColumnName("sale_team_id");
                        entity.Property(e => e.Share).HasColumnName("share");
                        entity.Property(e => e.Signature).HasColumnName("signature");
                        entity.Property(e => e.TargetSalesDone).HasColumnName("target_sales_done");
                        entity.Property(e => e.TargetSalesInvoiced).HasColumnName("target_sales_invoiced");
                        entity.Property(e => e.TargetSalesWon).HasColumnName("target_sales_won");
                        entity.Property(e => e.TotpSecret).HasColumnName("totp_secret");
                        entity.Property(e => e.TourEnabled).HasColumnName("tour_enabled");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ResUsers) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("res_users_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("res_users_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.InverseCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_users_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_create_uid_fkey");

                        entity.HasOne(d => d.LastLunchLocation).WithMany(p => p.ResUsers)
                            .HasForeignKey(d => d.LastLunchLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_last_lunch_location_id_fkey");

                        entity.HasOne(d => d.NextRank).WithMany(p => p.ResUsersNextRank)
                            .HasForeignKey(d => d.NextRankId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_next_rank_id_fkey");

                        entity.HasOne(d => d.OauthProvider).WithMany(p => p.ResUsers)
                            .HasForeignKey(d => d.OauthProviderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_oauth_provider_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.ResUsers) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("res_users_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("res_users_partner_id_fkey");

                        entity.HasOne(d => d.Rank).WithMany(p => p.ResUsersRank)
                            .HasForeignKey(d => d.RankId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_rank_id_fkey");

                        entity.HasOne(d => d.SaleTeam).WithMany(p => p.ResUsers)
                            .HasForeignKey(d => d.SaleTeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_sale_team_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.ResUsers) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_users_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.InverseWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_users_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_users_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}