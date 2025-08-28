using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpProduction(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpProduction>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_production_pkey");

                        entity.ToTable("mrp_production");

                        entity.HasIndex(e => e.TenantId, "mrp_production__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.DateStart, "mrp_production__date_start_index");

                        entity.HasIndex(e => e.OrderpointId, "mrp_production__orderpoint_id_index").HasFilter("(orderpoint_id IS NOT NULL)");

                        entity.HasIndex(e => e.PickingTypeId, "mrp_production__picking_type_id_index");

                        entity.HasIndex(e => e.ReservationState, "mrp_production__reservation_state_index");

                        entity.HasIndex(e => e.State, "mrp_production__state_index");

                        entity.HasIndex(e => new { e.Name, e.TenantId }, "mrp_production_name_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AllowWorkorderDependencies).HasColumnName("allow_workorder_dependencies");
                        entity.Property(e => e.BackorderSequence).HasColumnName("backorder_sequence");
                        entity.Property(e => e.BomId).HasColumnName("bom_id");

                        entity.Property(e => e.Consumption).HasColumnName("consumption");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateDeadline)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_deadline");
                        entity.Property(e => e.DateFinished)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_finished");
                        entity.Property(e => e.DateStart)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_start");
                        entity.Property(e => e.ExtraCost).HasColumnName("extra_cost");
                        entity.Property(e => e.IsLocked).HasColumnName("is_locked");
                        entity.Property(e => e.IsOutdatedBom).HasColumnName("is_outdated_bom");
                        entity.Property(e => e.IsPlanned).HasColumnName("is_planned");
                        entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                        entity.Property(e => e.LocationFinalId).HasColumnName("location_final_id");
                        entity.Property(e => e.LocationSrcId).HasColumnName("location_src_id");
                        entity.Property(e => e.LotProducingId).HasColumnName("lot_producing_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OrderpointId).HasColumnName("orderpoint_id");
                        entity.Property(e => e.Origin).HasColumnName("origin");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
                        entity.Property(e => e.ProductDescriptionVariants).HasColumnName("product_description_variants");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
                        entity.Property(e => e.ProductionLocationId).HasColumnName("production_location_id");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.PropagateCancel).HasColumnName("propagate_cancel");
                        entity.Property(e => e.QtyProducing).HasColumnName("qty_producing");
                        entity.Property(e => e.ReservationState).HasColumnName("reservation_state");
                        entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.SubcontractingHasBeenRecorded).HasColumnName("subcontracting_has_been_recorded");
                        entity.Property(e => e.SubcontractorId).HasColumnName("subcontractor_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Bom).WithMany(p => p.MrpProduction)
                            .HasForeignKey(d => d.BomId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_bom_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.MrpProduction) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_production_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_production_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpProductionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_create_uid_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.MrpProductionLocationDest)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_production_location_dest_id_fkey");

                        entity.HasOne(d => d.LocationFinal).WithMany(p => p.MrpProductionLocationFinal)
                            .HasForeignKey(d => d.LocationFinalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_location_final_id_fkey");

                        entity.HasOne(d => d.LocationSrc).WithMany(p => p.MrpProductionLocationSrc)
                            .HasForeignKey(d => d.LocationSrcId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_production_location_src_id_fkey");

                        entity.HasOne(d => d.LotProducing).WithMany(p => p.MrpProduction)
                            .HasForeignKey(d => d.LotProducingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_lot_producing_id_fkey");

                        entity.HasOne(d => d.Orderpoint).WithMany(p => p.MrpProduction)
                            .HasForeignKey(d => d.OrderpointId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_orderpoint_id_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.MrpProduction)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_production_picking_type_id_fkey");

                        entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.MrpProduction)
                            .HasForeignKey(d => d.ProcurementGroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_procurement_group_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.MrpProduction) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_production_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_production_product_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpProduction) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_production_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_production_product_uom_id_fkey");

                        entity.HasOne(d => d.ProductionLocation).WithMany(p => p.MrpProductionProductionLocation)
                            .HasForeignKey(d => d.ProductionLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_production_location_id_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.MrpProduction)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_project_id_fkey");

                        entity.HasOne(d => d.SaleLine).WithMany(p => p.MrpProduction)
                            .HasForeignKey(d => d.SaleLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_sale_line_id_fkey");

                        // entity.HasOne(d => d.Subcontractor).WithMany(p => p.MrpProduction) .HasForeignKey(d => d.SubcontractorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_subcontractor_id_fkey");
                        entity.HasOne(d => d.Subcontractor).WithMany()
                            .HasForeignKey(d => d.SubcontractorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_subcontractor_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.MrpProductionUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpProductionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_production_write_uid_fkey");

                        // entity.HasMany(d => d.TemplateAttributeValue).WithMany(p => p.Production)
                        entity.HasMany(d => d.TemplateAttributeValue).WithMany(p => p.Production)
                            .UsingEntity<Dictionary<string, object>>(
                                "TemplateAttributeValueMrpProductionRel",
                                r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                                    .HasForeignKey("TemplateAttributeValueId")
                                    .HasConstraintName("template_attribute_value_mrp_p_template_attribute_value_id_fkey"),
                                l => l.HasOne<MrpProduction>().WithMany()
                                    .HasForeignKey("ProductionId")
                                    .HasConstraintName("template_attribute_value_mrp_production_rel_production_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductionId", "TemplateAttributeValueId").HasName("template_attribute_value_mrp_production_rel_pkey");
                                    j.ToTable("template_attribute_value_mrp_production_rel");
                                    j.HasIndex(new[] { "TemplateAttributeValueId", "ProductionId" }, "template_attribute_value_mrp__template_attribute_value_id_p_idx");
                                    j.IndexerProperty<Guid>("ProductionId").HasColumnName("production_id");
                                    j.IndexerProperty<Guid>("TemplateAttributeValueId").HasColumnName("template_attribute_value_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}