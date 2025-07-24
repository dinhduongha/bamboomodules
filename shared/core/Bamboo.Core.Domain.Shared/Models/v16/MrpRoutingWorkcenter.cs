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

[Table("mrp_routing_workcenter")]
//[Index("BomId", Name = "mrp_routing_workcenter_bom_id_index")]
public partial class MrpRoutingWorkcenter : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("workcenter_id")]
    public Guid? WorkcenterId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("bom_id")]
    public Guid? BomId { get; set; }

    [Column("time_mode_batch")]
    public long? TimeModeBatch { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("time_cycle_manual")]
    public double? TimeCycleManual { get; set; }

    [ForeignKey("BomId")]
    //[InverseProperty("MrpRoutingWorkcenters")]
    [NotMapped]
    public virtual MrpBom? Bom { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpRoutingWorkcenterCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("WorkcenterId")]
    //[InverseProperty("MrpRoutingWorkcenters")]
    [NotMapped]
    public virtual MrpWorkcenter? Workcenter { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpRoutingWorkcenterWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Operation")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; set; } = new List<MrpBomByproduct>();

    //[InverseProperty("Operation")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; set; } = new List<MrpBomLine>();

    //[InverseProperty("Operation")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } = new List<MrpWorkorder>();

    //[InverseProperty("Operation")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } = new List<StockMove>();

    [ForeignKey("OperationId")]
    //[InverseProperty("Operations")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> BlockedBies { get; set; } = new List<MrpRoutingWorkcenter>();

    [ForeignKey("BlockedById")]
    //[InverseProperty("BlockedBies")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> Operations { get; set; } = new List<MrpRoutingWorkcenter>();

    [ForeignKey("MrpRoutingWorkcenterId")]
    //[InverseProperty("MrpRoutingWorkcenters")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; set; } = new List<ProductTemplateAttributeValue>();
}
