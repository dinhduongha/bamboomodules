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
public partial class StockPickingType: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

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

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("create_backorder")]
    public string? CreateBackorder { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("is_repairable")]
    public bool? IsRepairable { get; set; }

    [Column("use_create_components_lots")]
    public bool? UseCreateComponentsLots { get; set; }

    [Column("use_auto_consume_components_lots")]
    public bool? UseAutoConsumeComponentsLots { get; set; }

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
    public virtual ICollection<StockPickingType> InverseReturnPickingType { get; } = new List<StockPickingType>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; } = new List<MrpBom>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; } = new List<StockPicking>();

    //[InverseProperty("PickingType")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; } = new List<StockRule>();

    //[InverseProperty("InType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseInTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("IntType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseIntTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("ManuType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseManuTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("OutType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseOutTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("PackType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePackTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("PbmType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePbmTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("PickType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePickTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("PosType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehousePosTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("ReturnType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseReturnTypes { get; } = new List<StockWarehouse>();

    //[InverseProperty("SamType")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseSamTypes { get; } = new List<StockWarehouse>();

}
