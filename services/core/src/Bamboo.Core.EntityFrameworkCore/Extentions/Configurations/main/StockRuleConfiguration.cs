using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_rule_pkey");

                        entity.ToTable("stock_rule");

                        entity.HasIndex(e => e.Action, "stock_rule__action_index");

                        entity.HasIndex(e => e.TenantId, "stock_rule__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationDestId, "stock_rule__location_dest_id_index");

                        entity.HasIndex(e => e.LocationSrcId, "stock_rule__location_src_id_index");

                        entity.HasIndex(e => e.RouteId, "stock_rule__route_id_index");

                        entity.HasIndex(e => e.WarehouseId, "stock_rule__warehouse_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Action).HasColumnName("action");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Auto).HasColumnName("auto");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Delay).HasColumnName("delay");
                        entity.Property(e => e.LocationDestFromRule).HasColumnName("location_dest_from_rule");
                        entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                        entity.Property(e => e.LocationSrcId).HasColumnName("location_src_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PartnerAddressId).HasColumnName("partner_address_id");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.ProcureMethod).HasColumnName("procure_method");
                        entity.Property(e => e.PropagateCancel).HasColumnName("propagate_cancel");
                        entity.Property(e => e.PropagateCarrier).HasColumnName("propagate_carrier");
                        entity.Property(e => e.PushDomain).HasColumnName("push_domain");
                        entity.Property(e => e.RouteId).HasColumnName("route_id");
                        entity.Property(e => e.RouteSequence).HasColumnName("route_sequence");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockRule) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_rule_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rule_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rule_create_uid_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.StockRuleLocationDest)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_rule_location_dest_id_fkey");

                        entity.HasOne(d => d.LocationSrc).WithMany(p => p.StockRuleLocationSrc)
                            .HasForeignKey(d => d.LocationSrcId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rule_location_src_id_fkey");

                        // entity.HasOne(d => d.PartnerAddress).WithMany(p => p.StockRule) .HasForeignKey(d => d.PartnerAddressId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_rule_partner_address_id_fkey");
                        entity.HasOne(d => d.PartnerAddress).WithMany()
                            .HasForeignKey(d => d.PartnerAddressId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rule_partner_address_id_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.StockRule)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_rule_picking_type_id_fkey");

                        entity.HasOne(d => d.Route).WithMany(p => p.StockRule)
                            .HasForeignKey(d => d.RouteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_rule_route_id_fkey");

                        entity.HasOne(d => d.Warehouse).WithMany(p => p.StockRule)
                            .HasForeignKey(d => d.WarehouseId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rule_warehouse_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rule_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}