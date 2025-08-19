using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventBoothRegistration(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventBoothRegistration>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_booth_registration_pkey");

            entity.ToTable("event_booth_registration");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.SaleOrderLineId, e.EventBoothId }, "event_booth_registration_unique_registration").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.ContactEmail).HasColumnName("contact_email");
            entity.Property(e => e.ContactMobile).HasColumnName("contact_mobile");
            entity.Property(e => e.ContactName).HasColumnName("contact_name");
            entity.Property(e => e.ContactPhone).HasColumnName("contact_phone");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.EventBoothId).HasColumnName("event_booth_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
            entity.Property(e => e.SponsorEmail).HasColumnName("sponsor_email");
            entity.Property(e => e.SponsorMobile).HasColumnName("sponsor_mobile");
            entity.Property(e => e.SponsorName).HasColumnName("sponsor_name");
            entity.Property(e => e.SponsorPhone).HasColumnName("sponsor_phone");
            entity.Property(e => e.SponsorSubtitle).HasColumnName("sponsor_subtitle");
            entity.Property(e => e.SponsorWebsiteDescription).HasColumnName("sponsor_website_description");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.EventBoothRegistrationCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_booth_registration_create_uid_fkey");

            entity.HasOne(d => d.EventBooth).WithMany(p => p.EventBoothRegistration)
                .HasForeignKey(d => d.EventBoothId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("event_booth_registration_event_booth_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.EventBoothRegistration)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_booth_registration_partner_id_fkey");

            entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.EventBoothRegistration)
                .HasForeignKey(d => d.SaleOrderLineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_booth_registration_sale_order_line_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.EventBoothRegistrationWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_booth_registration_write_uid_fkey");
            });
        }
    }
}