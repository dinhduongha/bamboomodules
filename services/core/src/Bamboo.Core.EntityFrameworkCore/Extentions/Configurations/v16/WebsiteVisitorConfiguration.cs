using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LivechatOperatorId, "website_visitor__livechat_operator_id_index").HasFilter("(livechat_operator_id IS NOT NULL)");

                        entity.HasIndex(e => e.PartnerId, "website_visitor__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => e.AccessToken, "website_visitor_access_token_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LangId).HasColumnName("lang_id");
                        entity.Property(e => e.LastConnectionDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_connection_datetime");
                        entity.Property(e => e.LivechatOperatorId).HasColumnName("livechat_operator_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Timezone).HasColumnName("timezone");
                        entity.Property(e => e.VisitCount).HasColumnName("visit_count");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Country).WithMany(p => p.WebsiteVisitor) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_visitor_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_visitor_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteVisitorCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_visitor_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_visitor_create_uid_fkey");

                        entity.HasOne(d => d.Lang).WithMany(p => p.WebsiteVisitor)
                            .HasForeignKey(d => d.LangId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_visitor_lang_id_fkey");

                        // entity.HasOne(d => d.LivechatOperator).WithMany(p => p.WebsiteVisitorLivechatOperator) .HasForeignKey(d => d.LivechatOperatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_visitor_livechat_operator_id_fkey");
                        entity.HasOne(d => d.LivechatOperator).WithMany()
                            .HasForeignKey(d => d.LivechatOperatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_visitor_livechat_operator_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.WebsiteVisitorPartner) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_visitor_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_visitor_partner_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.WebsiteVisitor) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_visitor_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_visitor_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteVisitorWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_visitor_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_visitor_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}