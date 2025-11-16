using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventBooth(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventBooth>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_booth_pkey");

                        entity.ToTable("event_booth");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BoothCategoryId).HasColumnName("booth_category_id");
                        entity.Property(e => e.ContactEmail).HasColumnName("contact_email");
                        entity.Property(e => e.ContactName).HasColumnName("contact_name");
                        entity.Property(e => e.ContactPhone).HasColumnName("contact_phone");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
                        entity.Property(e => e.IsPaid).HasColumnName("is_paid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Price).HasColumnName("price");
                        entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                        entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
                        entity.Property(e => e.SponsorId).HasColumnName("sponsor_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.BoothCategory).WithMany(p => p.EventBooth)
                            .HasForeignKey(d => d.BoothCategoryId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("event_booth_booth_category_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventBoothCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_booth_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventBooth)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_booth_event_id_fkey");

                        entity.HasOne(d => d.EventType).WithMany(p => p.EventBooth)
                            .HasForeignKey(d => d.EventTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_event_type_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.EventBooth) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_booth_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_partner_id_fkey");

                        entity.HasOne(d => d.SaleOrder).WithMany(p => p.EventBooth)
                            .HasForeignKey(d => d.SaleOrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_sale_order_id_fkey");

                        entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.EventBooth)
                            .HasForeignKey(d => d.SaleOrderLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_sale_order_line_id_fkey");

                        entity.HasOne(d => d.Sponsor).WithMany(p => p.EventBooth)
                            .HasForeignKey(d => d.SponsorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_sponsor_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventBoothWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_booth_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}