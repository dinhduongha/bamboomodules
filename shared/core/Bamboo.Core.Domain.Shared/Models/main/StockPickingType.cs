using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("stock_picking_type")]
//[Index("CompanyId", Name = "stock_picking_type__company_id_index")]
public partial class StockPickingType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField] // PickingPropertiesDefinition
    [Column("picking_properties_definition", TypeName = "jsonb")]
    public JsonElement? PickingPropertiesDefinition { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("default_product_location_src_id")]
    public Guid? DefaultProductLocationSrcId { get; set; }

    [Column("default_product_location_dest_id")]
    public Guid? DefaultProductLocationDestId { get; set; }

    [Column("default_remove_location_dest_id")]
    public Guid? DefaultRemoveLocationDestId { get; set; }

    [Column("default_recycle_location_dest_id")]
    public Guid? DefaultRecycleLocationDestId { get; set; }

    [JsonField] // RepairPropertiesDefinition
    [Column("repair_properties_definition", TypeName = "jsonb")]
    public JsonElement? RepairPropertiesDefinition { get; set; }

    [Column("is_repairable")]
    public bool? IsRepairable { get; set; }

    [Column("analytic_costs")]
    public bool? AnalyticCosts { get; set; }

    [Column("mrp_product_label_to_print")]
    public string? MrpProductLabelToPrint { get; set; }

    [Column("done_mrp_lot_label_to_print")]
    public string? DoneMrpLotLabelToPrint { get; set; }

    [Column("generated_mrp_lot_label_to_print")]
    public string? GeneratedMrpLotLabelToPrint { get; set; }

    [Column("use_create_components_lots")]
    public bool? UseCreateComponentsLots { get; set; }

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

    [Column("batch_max_lines")]
    public long? BatchMaxLines { get; set; }

    [Column("batch_max_pickings")]
    public long? BatchMaxPickings { get; set; }

    [JsonField] // BatchPropertiesDefinition
    [Column("batch_properties_definition", TypeName = "jsonb")]
    public JsonElement? BatchPropertiesDefinition { get; set; }

    [Column("auto_batch")]
    public bool? AutoBatch { get; set; }

    [Column("batch_group_by_partner")]
    public bool? BatchGroupByPartner { get; set; }

    [Column("batch_group_by_destination")]
    public bool? BatchGroupByDestination { get; set; }

    [Column("batch_group_by_src_loc")]
    public bool? BatchGroupBySrcLoc { get; set; }

    [Column("batch_group_by_dest_loc")]
    public bool? BatchGroupByDestLoc { get; set; }

    [Column("wave_group_by_product")]
    public bool? WaveGroupByProduct { get; set; }

    [Column("wave_group_by_category")]
    public bool? WaveGroupByCategory { get; set; }

    [Column("wave_group_by_location")]
    public bool? WaveGroupByLocation { get; set; }

    [Column("batch_auto_confirm")]
    public bool? BatchAutoConfirm { get; set; }

    [Column("batch_max_weight")]
    public long? BatchMaxWeight { get; set; }

    [Column("batch_group_by_carrier")]
    public bool? BatchGroupByCarrier { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultLocationDestId")]
    public virtual StockLocation? DefaultLocationDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultLocationSrcId")]
    public virtual StockLocation? DefaultLocationSrc { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultProductLocationDestId")]
    public virtual StockLocation? DefaultProductLocationDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultProductLocationSrcId")]
    public virtual StockLocation? DefaultProductLocationSrc { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultRecycleLocationDestId")]
    public virtual StockLocation? DefaultRecycleLocationDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultRemoveLocationDestId")]
    public virtual StockLocation? DefaultRemoveLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ReturnPickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ReturnPickingType")] // One2many
    public virtual ICollection<StockPickingType> InverseReturnPickingType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DropshipSubcontractorPickTypeId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("DropshipSubcontractorPickType")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ReturnPickingTypeId")]
    public virtual StockPickingType? ReturnPickingType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SequenceId")]
    public virtual IrSequence? SequenceNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickingType")] // One2many
    public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("InType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseInType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("IntTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("IntType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseIntType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ManuTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ManuType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseManuType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OutTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OutType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseOutType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PackType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehousePackType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PbmTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PbmType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehousePbmType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PickType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehousePickType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PosTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehousePosType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("QcTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("QcType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseQcType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RepairTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RepairType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseRepairType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SamTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SamType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseSamType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("StoreTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("StoreType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseStoreType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SubcontractingResupplyTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SubcontractingResupplyType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingResupplyType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SubcontractingTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SubcontractingType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("XdockTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("XdockType")] // One2many
    public virtual ICollection<StockWarehouse> StockWarehouseXdockType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WarehouseId")]
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("StockPickingTypeId")] // Many2many // Normal
    // [InverseProperty("StockPickingType")] // Many2many // Normal
    public virtual ICollection<ProductCategory> ProductCategory { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("StockPickingTypeId")] // Many2many // Normal
    // [InverseProperty("StockPickingType")] // Many2many // Normal
    public virtual ICollection<StockLocation> StockLocation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("PickingTypeId")] // Many2many // Normal
    // [InverseProperty("PickingType")] // Many2many // Normal
    public virtual ICollection<ResUsers> User { get; set; }
}
