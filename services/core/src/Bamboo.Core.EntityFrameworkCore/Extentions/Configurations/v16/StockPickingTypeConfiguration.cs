using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockPickingType(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPickingType>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_picking_type_pkey");

                        entity.ToTable("stock_picking_type");

                        entity.HasIndex(e => e.TenantId, "stock_picking_type__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AnalyticCosts).HasColumnName("analytic_costs");
                        entity.Property(e => e.AutoBatch).HasColumnName("auto_batch");
                        entity.Property(e => e.AutoPrintDeliverySlip).HasColumnName("auto_print_delivery_slip");
                        entity.Property(e => e.AutoPrintDoneMrpLot).HasColumnName("auto_print_done_mrp_lot");
                        entity.Property(e => e.AutoPrintDoneMrpProductLabels).HasColumnName("auto_print_done_mrp_product_labels");
                        entity.Property(e => e.AutoPrintDoneProductionOrder).HasColumnName("auto_print_done_production_order");
                        entity.Property(e => e.AutoPrintGeneratedMrpLot).HasColumnName("auto_print_generated_mrp_lot");
                        entity.Property(e => e.AutoPrintLotLabels).HasColumnName("auto_print_lot_labels");
                        entity.Property(e => e.AutoPrintMrpReceptionReport).HasColumnName("auto_print_mrp_reception_report");
                        entity.Property(e => e.AutoPrintMrpReceptionReportLabels).HasColumnName("auto_print_mrp_reception_report_labels");
                        entity.Property(e => e.AutoPrintPackageLabel).HasColumnName("auto_print_package_label");
                        entity.Property(e => e.AutoPrintPackages).HasColumnName("auto_print_packages");
                        entity.Property(e => e.AutoPrintProductLabels).HasColumnName("auto_print_product_labels");
                        entity.Property(e => e.AutoPrintReceptionReport).HasColumnName("auto_print_reception_report");
                        entity.Property(e => e.AutoPrintReceptionReportLabels).HasColumnName("auto_print_reception_report_labels");
                        entity.Property(e => e.AutoPrintReturnSlip).HasColumnName("auto_print_return_slip");
                        entity.Property(e => e.AutoShowReceptionReport).HasColumnName("auto_show_reception_report");
                        entity.Property(e => e.Barcode).HasColumnName("barcode");
                        entity.Property(e => e.BatchAutoConfirm).HasColumnName("batch_auto_confirm");
                        entity.Property(e => e.BatchGroupByCarrier).HasColumnName("batch_group_by_carrier");
                        entity.Property(e => e.BatchGroupByDestLoc).HasColumnName("batch_group_by_dest_loc");
                        entity.Property(e => e.BatchGroupByDestination).HasColumnName("batch_group_by_destination");
                        entity.Property(e => e.BatchGroupByPartner).HasColumnName("batch_group_by_partner");
                        entity.Property(e => e.BatchGroupBySrcLoc).HasColumnName("batch_group_by_src_loc");
                        entity.Property(e => e.BatchMaxLines).HasColumnName("batch_max_lines");
                        entity.Property(e => e.BatchMaxPickings).HasColumnName("batch_max_pickings");
                        entity.Property(e => e.BatchMaxWeight).HasColumnName("batch_max_weight");
                        entity.Property(e => e.BatchPropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("batch_properties_definition");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreateBackorder).HasColumnName("create_backorder");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultLocationDestId).HasColumnName("default_location_dest_id");
                        entity.Property(e => e.DefaultLocationSrcId).HasColumnName("default_location_src_id");
                        entity.Property(e => e.DefaultProductLocationDestId).HasColumnName("default_product_location_dest_id");
                        entity.Property(e => e.DefaultProductLocationSrcId).HasColumnName("default_product_location_src_id");
                        entity.Property(e => e.DefaultRecycleLocationDestId).HasColumnName("default_recycle_location_dest_id");
                        entity.Property(e => e.DefaultRemoveLocationDestId).HasColumnName("default_remove_location_dest_id");
                        entity.Property(e => e.DoneMrpLotLabelToPrint).HasColumnName("done_mrp_lot_label_to_print");
                        entity.Property(e => e.GeneratedMrpLotLabelToPrint).HasColumnName("generated_mrp_lot_label_to_print");
                        entity.Property(e => e.IsRepairable).HasColumnName("is_repairable");
                        entity.Property(e => e.LotLabelFormat).HasColumnName("lot_label_format");
                        entity.Property(e => e.MoveType).HasColumnName("move_type");
                        entity.Property(e => e.MrpProductLabelToPrint).HasColumnName("mrp_product_label_to_print");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PackageLabelToPrint).HasColumnName("package_label_to_print");
                        entity.Property(e => e.PickingPropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("picking_properties_definition");
                        entity.Property(e => e.PrintLabel).HasColumnName("print_label");
                        entity.Property(e => e.ProductLabelFormat).HasColumnName("product_label_format");
                        entity.Property(e => e.RepairPropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("repair_properties_definition");
                        entity.Property(e => e.ReservationDaysBefore).HasColumnName("reservation_days_before");
                        entity.Property(e => e.ReservationDaysBeforePriority).HasColumnName("reservation_days_before_priority");
                        entity.Property(e => e.ReservationMethod).HasColumnName("reservation_method");
                        entity.Property(e => e.ReturnPickingTypeId).HasColumnName("return_picking_type_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SequenceCode).HasColumnName("sequence_code");
                        entity.Property(e => e.SequenceId).HasColumnName("sequence_id");
                        entity.Property(e => e.ShowEntirePacks).HasColumnName("show_entire_packs");
                        entity.Property(e => e.ShowOperations).HasColumnName("show_operations");
                        entity.Property(e => e.UseCreateComponentsLots).HasColumnName("use_create_components_lots");
                        entity.Property(e => e.UseCreateLots).HasColumnName("use_create_lots");
                        entity.Property(e => e.UseExistingLots).HasColumnName("use_existing_lots");
                        entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                        entity.Property(e => e.WaveGroupByCategory).HasColumnName("wave_group_by_category");
                        entity.Property(e => e.WaveGroupByLocation).HasColumnName("wave_group_by_location");
                        entity.Property(e => e.WaveGroupByProduct).HasColumnName("wave_group_by_product");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockPickingType) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_picking_type_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_picking_type_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPickingTypeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_type_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_create_uid_fkey");

                        entity.HasOne(d => d.DefaultLocationDest).WithMany(p => p.StockPickingTypeDefaultLocationDest)
                            .HasForeignKey(d => d.DefaultLocationDestId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_picking_type_default_location_dest_id_fkey");

                        entity.HasOne(d => d.DefaultLocationSrc).WithMany(p => p.StockPickingTypeDefaultLocationSrc)
                            .HasForeignKey(d => d.DefaultLocationSrcId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_picking_type_default_location_src_id_fkey");

                        entity.HasOne(d => d.DefaultProductLocationDest).WithMany(p => p.StockPickingTypeDefaultProductLocationDest)
                            .HasForeignKey(d => d.DefaultProductLocationDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_default_product_location_dest_id_fkey");

                        entity.HasOne(d => d.DefaultProductLocationSrc).WithMany(p => p.StockPickingTypeDefaultProductLocationSrc)
                            .HasForeignKey(d => d.DefaultProductLocationSrcId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_default_product_location_src_id_fkey");

                        entity.HasOne(d => d.DefaultRecycleLocationDest).WithMany(p => p.StockPickingTypeDefaultRecycleLocationDest)
                            .HasForeignKey(d => d.DefaultRecycleLocationDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_default_recycle_location_dest_id_fkey");

                        entity.HasOne(d => d.DefaultRemoveLocationDest).WithMany(p => p.StockPickingTypeDefaultRemoveLocationDest)
                            .HasForeignKey(d => d.DefaultRemoveLocationDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_default_remove_location_dest_id_fkey");

                        entity.HasOne(d => d.ReturnPickingType).WithMany(p => p.InverseReturnPickingType)
                            .HasForeignKey(d => d.ReturnPickingTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_return_picking_type_id_fkey");

                        entity.HasOne(d => d.SequenceNavigation).WithMany(p => p.StockPickingType)
                            .HasForeignKey(d => d.SequenceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_sequence_id_fkey");

                        entity.HasOne(d => d.Warehouse).WithMany(p => p.StockPickingType)
                            .HasForeignKey(d => d.WarehouseId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_picking_type_warehouse_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPickingTypeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_type_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_type_write_uid_fkey");

                        // entity.HasMany(d => d.ProductCategory).WithMany(p => p.StockPickingType)
                        entity.HasMany(d => d.ProductCategory).WithMany(p => p.StockPickingType)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductCategoryStockPickingTypeRel",
                                r => r.HasOne<ProductCategory>().WithMany()
                                    .HasForeignKey("ProductCategoryId")
                                    .HasConstraintName("product_category_stock_picking_type_re_product_category_id_fkey"),
                                l => l.HasOne<StockPickingType>().WithMany()
                                    .HasForeignKey("StockPickingTypeId")
                                    .HasConstraintName("product_category_stock_picking_type__stock_picking_type_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockPickingTypeId", "ProductCategoryId").HasName("product_category_stock_picking_type_rel_pkey");
                                    j.ToTable("product_category_stock_picking_type_rel");
                                    j.HasIndex(new[] { "ProductCategoryId", "StockPickingTypeId" }, "product_category_stock_pickin_product_category_id_stock_pic_idx");
                                    j.IndexerProperty<Guid>("StockPickingTypeId").HasColumnName("stock_picking_type_id");
                                    j.IndexerProperty<Guid>("ProductCategoryId").HasColumnName("product_category_id");
                                });

                        // entity.HasMany(d => d.StockLocation).WithMany(p => p.StockPickingType)
                        entity.HasMany(d => d.StockLocation).WithMany(p => p.StockPickingType)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockLocationStockPickingTypeRel",
                                r => r.HasOne<StockLocation>().WithMany()
                                    .HasForeignKey("StockLocationId")
                                    .HasConstraintName("stock_location_stock_picking_type_rel_stock_location_id_fkey"),
                                l => l.HasOne<StockPickingType>().WithMany()
                                    .HasForeignKey("StockPickingTypeId")
                                    .HasConstraintName("stock_location_stock_picking_type_re_stock_picking_type_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockPickingTypeId", "StockLocationId").HasName("stock_location_stock_picking_type_rel_pkey");
                                    j.ToTable("stock_location_stock_picking_type_rel");
                                    j.HasIndex(new[] { "StockLocationId", "StockPickingTypeId" }, "stock_location_stock_picking__stock_location_id_stock_picki_idx");
                                    j.IndexerProperty<Guid>("StockPickingTypeId").HasColumnName("stock_picking_type_id");
                                    j.IndexerProperty<Guid>("StockLocationId").HasColumnName("stock_location_id");
                                });

                        // entity.HasMany(d => d.User).WithMany(p => p.PickingType)
                        entity.HasMany(d => d.User).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "PickingTypeFavoriteUserRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("UserId")
                                    .HasConstraintName("picking_type_favorite_user_rel_user_id_fkey"),
                                l => l.HasOne<StockPickingType>().WithMany()
                                    .HasForeignKey("PickingTypeId")
                                    .HasConstraintName("picking_type_favorite_user_rel_picking_type_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PickingTypeId", "UserId").HasName("picking_type_favorite_user_rel_pkey");
                                    j.ToTable("picking_type_favorite_user_rel");
                                    j.HasIndex(new[] { "UserId", "PickingTypeId" }, "picking_type_favorite_user_rel_user_id_picking_type_id_idx");
                                    j.IndexerProperty<Guid>("PickingTypeId").HasColumnName("picking_type_id");
                                    j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}