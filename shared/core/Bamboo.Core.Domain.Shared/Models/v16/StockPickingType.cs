using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("stock_picking_type")]
//[Index("TenantId", Name = "stock_picking_type_company_id_index")]
public partial class StockPickingType : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("sequence_id")]
    public Guid? SequenceId { get; set; }

    [Column("default_location_src_id")]
    public Guid? DefaultLocationSrcId { get; set; }

    [Column("default_location_dest_id")]
    public Guid? DefaultLocationDestId { get; set; }

    [Column("return_picking_type_id")]
    public Guid? ReturnPickingTypeId { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("reservation_days_before")]
    public long? ReservationDaysBefore { get; set; }

    [Column("reservation_days_before_priority")]
    public long? ReservationDaysBeforePriority { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("sequence_code")]
    public string? SequenceCode { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("reservation_method")]
    public string? ReservationMethod { get; set; }

    [Column("product_label_format")]
    public string? ProductLabelFormat { get; set; }

    [Column("lot_label_format")]
    public string? LotLabelFormat { get; set; }

    [Column("package_label_to_print")]
    public string? PackageLabelToPrint { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("create_backorder")]
    public string? CreateBackorder { get; set; }

    [Column("move_type")]
    public string? MoveType { get; set; }

    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("picking_properties_definition", TypeName = "jsonb")]
    public string? PickingPropertiesDefinition { get; set; }

    [Column("show_entire_packs")]
    public bool? ShowEntirePacks { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("use_create_lots")]
    public bool? UseCreateLots { get; set; }

    [Column("use_existing_lots")]
    public bool? UseExistingLots { get; set; }

    [Column("print_label")]
    public bool? PrintLabel { get; set; }

    [Column("show_operations")]
    public bool? ShowOperations { get; set; }

    // v16-Compat
    [Column("show_reserved")]
    public bool? ShowReserved { get; set; }

    [Column("auto_show_reception_report")]
    public bool? AutoShowReceptionReport { get; set; }

    [Column("auto_print_delivery_slip")]
    public bool? AutoPrintDeliverySlip { get; set; }

    [Column("auto_print_return_slip")]
    public bool? AutoPrintReturnSlip { get; set; }

    [Column("auto_print_product_labels")]
    public bool? AutoPrintProductLabels { get; set; }

    [Column("auto_print_lot_labels")]
    public bool? AutoPrintLotLabels { get; set; }

    [Column("auto_print_reception_report")]
    public bool? AutoPrintReceptionReport { get; set; }

    [Column("auto_print_reception_report_labels")]
    public bool? AutoPrintReceptionReportLabels { get; set; }

    [Column("auto_print_packages")]
    public bool? AutoPrintPackages { get; set; }

    [Column("auto_print_package_label")]
    public bool? AutoPrintPackageLabel { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("analytic_costs")]
    public bool? AnalyticCosts { get; set; }

    [Column("default_product_location_src_id")]
    public Guid? DefaultProductLocationSrcId { get; set; }

    [Column("default_product_location_dest_id")]
    public Guid? DefaultProductLocationDestId { get; set; }

    [Column("default_remove_location_dest_id")]
    public Guid? DefaultRemoveLocationDestId { get; set; }

    [Column("default_recycle_location_dest_id")]
    public Guid? DefaultRecycleLocationDestId { get; set; }

    [Column("repair_properties_definition", TypeName = "jsonb")]
    public string? RepairPropertiesDefinition { get; set; }

    [Column("is_repairable")]
    public bool? IsRepairable { get; set; }

    [Column("mrp_product_label_to_print")]
    public string? MrpProductLabelToPrint { get; set; }

    [Column("done_mrp_lot_label_to_print")]
    public string? DoneMrpLotLabelToPrint { get; set; }

    [Column("generated_mrp_lot_label_to_print")]
    public string? GeneratedMrpLotLabelToPrint { get; set; }

    [Column("use_create_components_lots")]
    public bool? UseCreateComponentsLots { get; set; }

    // v16-Compat
    [Column("use_auto_consume_components_lots")]
    public bool? UseAutoConsumeComponentsLots { get; set; }

    [Column("auto_print_done_production_order")]
    public bool? AutoPrintDoneProductionOrder { get; set; }

    [Column("auto_print_done_mrp_product_labels")]
    public bool? AutoPrintDoneMrpProductLabels { get; set; }

    [Column("auto_print_done_mrp_lot")]
    public bool? AutoPrintDoneMrpLot { get; set; }

    [Column("auto_print_mrp_reception_report")]
    public bool? AutoPrintMrpReceptionReport { get; set; }

    [Column("auto_print_mrp_reception_report_labels")]
    public bool? AutoPrintMrpReceptionReportLabels { get; set; }

    [Column("auto_print_generated_mrp_lot")]
    public bool? AutoPrintGeneratedMrpLot { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockPickingTypes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockPickingTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DefaultLocationDestId")]
    //[InverseProperty("StockPickingTypeDefaultLocationDests")]
    [NotMapped]
    public virtual StockLocation? DefaultLocationDest { get; set; }

    [ForeignKey("DefaultLocationSrcId")]
    //[InverseProperty("StockPickingTypeDefaultLocationSrcs")]
    [NotMapped]
    public virtual StockLocation? DefaultLocationSrc { get; set; }

    [ForeignKey("DefaultProductLocationDestId")]
    //[InverseProperty("StockPickingTypeDefaultProductLocationDests")]
    [NotMapped]
    public virtual StockLocation? DefaultProductLocationDest { get; set; }

    [ForeignKey("DefaultProductLocationSrcId")]
    //[InverseProperty("StockPickingTypeDefaultProductLocationSrcs")]
    [NotMapped]
    public virtual StockLocation? DefaultProductLocationSrc { get; set; }

    [ForeignKey("DefaultRecycleLocationDestId")]
    //[InverseProperty("StockPickingTypeDefaultRecycleLocationDests")]
    [NotMapped]
    public virtual StockLocation? DefaultRecycleLocationDest { get; set; }

    [ForeignKey("DefaultRemoveLocationDestId")]
    //[InverseProperty("StockPickingTypeDefaultRemoveLocationDests")]
    [NotMapped]
    public virtual StockLocation? DefaultRemoveLocationDest { get; set; }

    [ForeignKey("ReturnPickingTypeId")]
    //[InverseProperty("InverseReturnPickingType")]
    [NotMapped]
    public virtual StockPickingType? ReturnPickingType { get; set; }

    [ForeignKey("SequenceId")]
    //[InverseProperty("StockPickingTypes")]
    [NotMapped]
    public virtual IrSequence? SequenceNavigation { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("StockPickingTypes")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockPickingTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE
    //[InverseProperty("ReturnPickingType")]
    [NotMapped]
    public virtual ICollection<StockPickingType> InverseReturnPickingType { get; set; } = new List<StockPickingType>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } = new List<MrpBom>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } = new List<MrpProduction>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } = new List<PosConfig>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } = new List<StockMove>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } = new List<StockPicking>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; set; } = new List<StockRule>();

    //[InverseProperty("InType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseInTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("IntType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseIntTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("ManuType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseManuTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("OutType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseOutTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("PackType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePackTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("PbmType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePbmTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("PickType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePickTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("PosType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePosTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("ReturnType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseReturnTypes { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("SamType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseSamTypes { get; set; } = new List<StockWarehouse>();

}
