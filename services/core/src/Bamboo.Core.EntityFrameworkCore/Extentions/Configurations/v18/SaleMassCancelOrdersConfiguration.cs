using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSaleMassCancelOrders(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SaleMassCancelOrders>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sale_mass_cancel_orders_pkey");

                        entity.ToTable("sale_mass_cancel_orders");

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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SaleMassCancelOrdersCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_mass_cancel_orders_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_mass_cancel_orders_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SaleMassCancelOrdersWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sale_mass_cancel_orders_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sale_mass_cancel_orders_write_uid_fkey");

                        // entity.HasMany(d => d.SaleOrder).WithMany(p => p.SaleMassCancelOrders)
                        entity.HasMany(d => d.SaleOrder).WithMany(p => p.SaleMassCancelOrders)
                            .UsingEntity<Dictionary<string, object>>(
                                "SaleOrderMassCancelWizardRel",
                                r => r.HasOne<SaleOrder>().WithMany()
                                    .HasForeignKey("SaleOrderId")
                                    .HasConstraintName("sale_order_mass_cancel_wizard_rel_sale_order_id_fkey"),
                                l => l.HasOne<SaleMassCancelOrders>().WithMany()
                                    .HasForeignKey("SaleMassCancelOrdersId")
                                    .HasConstraintName("sale_order_mass_cancel_wizard_r_sale_mass_cancel_orders_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SaleMassCancelOrdersId", "SaleOrderId").HasName("sale_order_mass_cancel_wizard_rel_pkey");
                                    j.ToTable("sale_order_mass_cancel_wizard_rel");
                                    j.HasIndex(new[] { "SaleOrderId", "SaleMassCancelOrdersId" }, "sale_order_mass_cancel_wizard_sale_order_id_sale_mass_cance_idx");
                                    j.IndexerProperty<Guid>("SaleMassCancelOrdersId").HasColumnName("sale_mass_cancel_orders_id");
                                    j.IndexerProperty<Guid>("SaleOrderId").HasColumnName("sale_order_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}