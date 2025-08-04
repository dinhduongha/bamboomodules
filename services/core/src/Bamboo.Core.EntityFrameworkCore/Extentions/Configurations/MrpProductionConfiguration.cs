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
        public static void ConfigureMrpProduction(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpProduction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_production_pkey");

                entity.ToTable("mrp_production");

                entity.HasIndex(e => e.TenantId, "mrp_production_company_id_index");

                entity.HasIndex(e => e.DatePlannedStart, "mrp_production_date_planned_start_index");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "mrp_production_name_uniq").IsUnique();

                entity.HasIndex(e => e.OrderpointId, "mrp_production_orderpoint_id_index").HasFilter("(orderpoint_id IS NOT NULL)");

                entity.HasIndex(e => e.PickingTypeId, "mrp_production_picking_type_id_index");

                entity.HasIndex(e => e.ReservationState, "mrp_production_reservation_state_index");

                entity.HasIndex(e => e.State, "mrp_production_state_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AllowWorkorderDependencies).HasColumnName("allow_workorder_dependencies");
                entity.Property(e => e.AnalyticAccountId).HasColumnName("analytic_account_id");
                entity.Property(e => e.BackorderSequence)
                    .HasColumnName("backorder_sequence");
                entity.Property(e => e.BomId).HasColumnName("bom_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Consumption).HasColumnName("consumption");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateDeadline)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_deadline");
                entity.Property(e => e.DateFinished)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_finished");
                entity.Property(e => e.DatePlannedFinished)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_planned_finished");
                entity.Property(e => e.DatePlannedStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_planned_start");
                entity.Property(e => e.DateStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_start");
                entity.Property(e => e.ExtraCost).HasColumnName("extra_cost");
                entity.Property(e => e.IsLocked).HasColumnName("is_locked");
                entity.Property(e => e.IsPlanned).HasColumnName("is_planned");
                entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                entity.Property(e => e.LocationSrcId).HasColumnName("location_src_id");
                entity.Property(e => e.LotProducingId).HasColumnName("lot_producing_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
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
                entity.Property(e => e.PropagateCancel).HasColumnName("propagate_cancel");
                entity.Property(e => e.QtyProducing).HasColumnName("qty_producing");
                entity.Property(e => e.ReservationState).HasColumnName("reservation_state");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.AnalyticAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_analytic_account_id_fkey");

                entity.HasOne(d => d.Bom).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.BomId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_bom_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_production_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_create_uid_fkey");

                entity.HasOne(d => d.LocationDest).WithMany(p => p.MrpProductionLocationDests)
                    .HasForeignKey(d => d.LocationDestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_production_location_dest_id_fkey");

                entity.HasOne(d => d.LocationSrc).WithMany(p => p.MrpProductionLocationSrcs)
                    .HasForeignKey(d => d.LocationSrcId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_production_location_src_id_fkey");

                entity.HasOne(d => d.LotProducing).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.LotProducingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_lot_producing_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Orderpoint).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.OrderpointId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_orderpoint_id_fkey");

                entity.HasOne(d => d.PickingType).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.PickingTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_production_picking_type_id_fkey");

                entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.ProcurementGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_procurement_group_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_production_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpProductions)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_production_product_uom_id_fkey");

                entity.HasOne(d => d.ProductionLocation).WithMany(p => p.MrpProductionProductionLocations)
                    .HasForeignKey(d => d.ProductionLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_production_location_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_write_uid_fkey");

                //entity.HasMany(d => d.TemplateAttributeValues).WithMany(p => p.Productions)
                entity.HasMany<ProductTemplateAttributeValue>().WithMany()
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
            });
        }
    }
}