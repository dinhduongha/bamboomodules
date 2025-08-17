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
//[Index("CompanyId", Name = "stock_picking_type_company_id_index")]
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

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("create_backorder")]
    public string? CreateBackorder { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

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

    [Column("show_reserved")]
    public bool? ShowReserved { get; set; }

    [Column("auto_show_reception_report")]
    public bool? AutoShowReceptionReport { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("is_repairable")]
    public bool? IsRepairable { get; set; }

    [Column("use_create_components_lots")]
    public bool? UseCreateComponentsLots { get; set; }

    [Column("use_auto_consume_components_lots")]
    public bool? UseAutoConsumeComponentsLots { get; set; }

    [Column("batch_max_lines")]
    public long? BatchMaxLines { get; set; }

    [Column("batch_max_pickings")]
    public long? BatchMaxPickings { get; set; }

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

    [Column("batch_auto_confirm")]
    public bool? BatchAutoConfirm { get; set; }

    [Column("batch_max_weight")]
    public long? BatchMaxWeight { get; set; }

    [Column("batch_group_by_carrier")]
    public bool? BatchGroupByCarrier { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockPickingType")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockPickingTypeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DefaultLocationDestId")]
    // [InverseProperty("StockPickingTypeDefaultLocationDest")] //Many2one
    public virtual StockLocation? DefaultLocationDest { get; set; }

    // [Many2one]
    [ForeignKey("DefaultLocationSrcId")]
    // [InverseProperty("StockPickingTypeDefaultLocationSrc")] //Many2one
    public virtual StockLocation? DefaultLocationSrc { get; set; }

    // [One2many]
    [ForeignKey("ReturnPickingTypeId")]
    [InverseProperty("ReturnPickingType")]
    public virtual ICollection<StockPickingType> InverseReturnPickingType { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many]
    [ForeignKey("DropshipSubcontractorPickTypeId")]
    [InverseProperty("DropshipSubcontractorPickType")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("ReturnPickingTypeId")]
    // [InverseProperty("InverseReturnPickingType")] //Many2one
    public virtual StockPickingType? ReturnPickingType { get; set; }

    // [Many2one]
    [ForeignKey("SequenceId")]
    // [InverseProperty("StockPickingType")] //Many2one
    public virtual IrSequence? SequenceNavigation { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many]
    [ForeignKey("PickingTypeId")]
    [InverseProperty("PickingType")]
    public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many]
    [ForeignKey("InTypeId")]
    [InverseProperty("InType")]
    public virtual ICollection<StockWarehouse> StockWarehouseInType { get; set; }

    // [One2many]
    [ForeignKey("IntTypeId")]
    [InverseProperty("IntType")]
    public virtual ICollection<StockWarehouse> StockWarehouseIntType { get; set; }

    // [One2many]
    [ForeignKey("ManuTypeId")]
    [InverseProperty("ManuType")]
    public virtual ICollection<StockWarehouse> StockWarehouseManuType { get; set; }

    // [One2many]
    [ForeignKey("OutTypeId")]
    [InverseProperty("OutType")]
    public virtual ICollection<StockWarehouse> StockWarehouseOutType { get; set; }

    // [One2many]
    [ForeignKey("PackTypeId")]
    [InverseProperty("PackType")]
    public virtual ICollection<StockWarehouse> StockWarehousePackType { get; set; }

    // [One2many]
    [ForeignKey("PbmTypeId")]
    [InverseProperty("PbmType")]
    public virtual ICollection<StockWarehouse> StockWarehousePbmType { get; set; }

    // [One2many]
    [ForeignKey("PickTypeId")]
    [InverseProperty("PickType")]
    public virtual ICollection<StockWarehouse> StockWarehousePickType { get; set; }

    // [One2many]
    [ForeignKey("PosTypeId")]
    [InverseProperty("PosType")]
    public virtual ICollection<StockWarehouse> StockWarehousePosType { get; set; }

    // [One2many]
    [ForeignKey("ReturnTypeId")]
    [InverseProperty("ReturnType")]
    public virtual ICollection<StockWarehouse> StockWarehouseReturnType { get; set; }

    // [One2many]
    [ForeignKey("SamTypeId")]
    [InverseProperty("SamType")]
    public virtual ICollection<StockWarehouse> StockWarehouseSamType { get; set; }

    // [One2many]
    [ForeignKey("SubcontractingResupplyTypeId")]
    [InverseProperty("SubcontractingResupplyType")]
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingResupplyType { get; set; }

    // [One2many]
    [ForeignKey("SubcontractingTypeId")]
    [InverseProperty("SubcontractingType")]
    public virtual ICollection<StockWarehouse> StockWarehouseSubcontractingType { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("StockPickingType")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockPickingTypeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
