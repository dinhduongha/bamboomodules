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

[Table("stock_lot")]
//[Index("CompanyId", Name = "stock_lot__company_id_index")]
//[Index("ProductId", Name = "stock_lot__product_id_index")]
public partial class StockLot : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [JsonField] // LotProperties
    [Column("lot_properties", TypeName = "jsonb")]
    public JsonElement? LotProperties { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField] // StandardPrice
    [Column("standard_price", TypeName = "jsonb")]
    public JsonElement? StandardPrice { get; set; }

    [Column("product_expiry_reminded")]
    public bool? ProductExpiryReminded { get; set; }

    [Column("expiration_date", TypeName = "timestamp without time zone")]
    public DateTime? ExpirationDate { get; set; }

    [Column("use_date", TypeName = "timestamp without time zone")]
    public DateTime? UseDate { get; set; }

    [Column("removal_date", TypeName = "timestamp without time zone")]
    public DateTime? RemovalDate { get; set; }

    [Column("alert_date", TypeName = "timestamp without time zone")]
    public DateTime? AlertDate { get; set; }

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
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotProducingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LotProducing")] // One2many
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderFinishedLotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OrderFinishedLot")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LotId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockLotId")] //Many2many // Hidden
    // [InverseProperty("StockLot")] //Many2many // Hidden
    public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmation { get; set; }
}
