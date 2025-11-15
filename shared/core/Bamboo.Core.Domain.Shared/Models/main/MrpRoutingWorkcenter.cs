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

[Table("mrp_routing_workcenter")]
//[Index("BomId", Name = "mrp_routing_workcenter__bom_id_index")]
public partial class MrpRoutingWorkcenter : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("workcenter_id")]
    public Guid? WorkcenterId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("time_mode_batch")]
    public long? TimeModeBatch { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("worksheet_type")]
    public string? WorksheetType { get; set; }

    [Column("worksheet_google_slide")]
    public string? WorksheetGoogleSlide { get; set; }

    [Column("time_mode")]
    public string? TimeMode { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("time_cycle_manual")]
    public double? TimeCycleManual { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BomId")]
    public virtual MrpBom? Bom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OperationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Operation")] // One2many
    public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OperationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Operation")] // One2many
    public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OperationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Operation")] // One2many
    public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OperationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Operation")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WorkcenterId")]
    public virtual MrpWorkcenter? Workcenter { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("OperationId")] // Many2many // Normal
    // [InverseProperty("Operation")] // Many2many // Normal
    public virtual ICollection<MrpRoutingWorkcenter> BlockedBy { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("BlockedById")] // Many2many // Normal
    // [InverseProperty("BlockedBy")] // Many2many // Normal
    public virtual ICollection<MrpRoutingWorkcenter> Operation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MrpRoutingWorkcenterId")] // Many2many // Normal
    // [InverseProperty("MrpRoutingWorkcenter")] // Many2many // Normal
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValue { get; set; }
}
