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
        public static void ConfigureWebsiteVisitor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsiteVisitor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("website_visitor_pkey");

                entity.ToTable("website_visitor");

                entity.HasIndex(e => e.AccessToken, "website_visitor_access_token_unique").IsUnique();

                entity.HasIndex(e => e.PartnerId, "website_visitor_partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LangId).HasColumnName("lang_id");
                entity.Property(e => e.LastConnectionDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_connection_datetime");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.Timezone).HasColumnName("timezone");
                entity.Property(e => e.VisitCount).HasColumnName("visit_count");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_visitor_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_visitor_create_uid_fkey");

                entity.HasOne(d => d.Lang).WithMany(p => p.WebsiteVisitors)
                    .HasForeignKey(d => d.LangId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_visitor_lang_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_visitor_partner_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.WebsiteVisitors)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_visitor_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_visitor_write_uid_fkey");
            });
        }
    }
}