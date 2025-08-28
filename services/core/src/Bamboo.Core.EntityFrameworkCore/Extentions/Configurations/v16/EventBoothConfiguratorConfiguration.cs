using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventBoothConfigurator(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventBoothConfigurator>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_booth_configurator_pkey");

                        entity.ToTable("event_booth_configurator");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EventBoothCategoryId).HasColumnName("event_booth_category_id");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventBoothConfiguratorCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_booth_configurator_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_configurator_create_uid_fkey");

                        entity.HasOne(d => d.EventBoothCategory).WithMany(p => p.EventBoothConfigurator)
                            .HasForeignKey(d => d.EventBoothCategoryId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_booth_configurator_event_booth_category_id_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventBoothConfigurator)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_booth_configurator_event_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.EventBoothConfigurator) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_booth_configurator_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_configurator_product_id_fkey");

                        entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.EventBoothConfigurator)
                            .HasForeignKey(d => d.SaleOrderLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_configurator_sale_order_line_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventBoothConfiguratorWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_booth_configurator_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_booth_configurator_write_uid_fkey");

                        // entity.HasMany(d => d.EventBooth).WithMany(p => p.EventBoothConfigurator)
                        entity.HasMany(d => d.EventBooth).WithMany(p => p.EventBoothConfigurator)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventBoothEventBoothConfiguratorRel",
                                r => r.HasOne<EventBooth>().WithMany()
                                    .HasForeignKey("EventBoothId")
                                    .HasConstraintName("event_booth_event_booth_configurator_rel_event_booth_id_fkey"),
                                l => l.HasOne<EventBoothConfigurator>().WithMany()
                                    .HasForeignKey("EventBoothConfiguratorId")
                                    .HasConstraintName("event_booth_event_booth_config_event_booth_configurator_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventBoothConfiguratorId", "EventBoothId").HasName("event_booth_event_booth_configurator_rel_pkey");
                                    j.ToTable("event_booth_event_booth_configurator_rel");
                                    j.HasIndex(new[] { "EventBoothId", "EventBoothConfiguratorId" }, "event_booth_event_booth_confi_event_booth_id_event_booth_co_idx");
                                    j.IndexerProperty<Guid>("EventBoothConfiguratorId").HasColumnName("event_booth_configurator_id");
                                    j.IndexerProperty<Guid>("EventBoothId").HasColumnName("event_booth_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}