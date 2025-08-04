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
        public static void ConfigureResUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_users_pkey");

                entity.ToTable("res_users");

                entity.HasIndex(e => e.TenantId, "res_users_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.Login, e.WebsiteId }, "res_users_login_key").IsUnique();

                entity.HasIndex(e => e.PartnerId, "res_users_partner_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActionId).HasColumnName("action_id");
                entity.Property(e => e.Active)
                    .HasDefaultValueSql("true")
                    .HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastLunchLocationId).HasColumnName("last_lunch_location_id");
                entity.Property(e => e.Login).HasColumnName("login");
                entity.Property(e => e.NotificationType).HasColumnName("notification_type");
                entity.Property(e => e.OdoobotFailed).HasColumnName("odoobot_failed");
                entity.Property(e => e.OdoobotState).HasColumnName("odoobot_state");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.SaleTeamId).HasColumnName("sale_team_id");
                entity.Property(e => e.Share).HasColumnName("share");
                entity.Property(e => e.Signature).HasColumnName("signature");
                entity.Property(e => e.TargetSalesDone).HasColumnName("target_sales_done");
                entity.Property(e => e.TargetSalesInvoiced).HasColumnName("target_sales_invoiced");
                entity.Property(e => e.TargetSalesWon).HasColumnName("target_sales_won");
                entity.Property(e => e.TotpSecret).HasColumnName("totp_secret");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_users_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_create_uid_fkey");

                entity.HasOne(d => d.LastLunchLocation).WithMany(p => p.ResUsers)
                    .HasForeignKey(d => d.LastLunchLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_last_lunch_location_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_users_partner_id_fkey");

                entity.HasOne(d => d.SaleTeam).WithMany(p => p.ResUsers)
                    .HasForeignKey(d => d.SaleTeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_sale_team_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.ResUsers)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_write_uid_fkey");
            });
        }
    }
}