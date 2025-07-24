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

[Table("mrp_batch_produce")]
public partial class MrpBatchProduce: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("production_id")]
    public Guid? ProductionId { get; set; }

    [Column("lot_qty")]
    public long? LotQty { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lot_name")]
    public string? LotName { get; set; }

    [Column("component_separator")]
    public string? ComponentSeparator { get; set; }

    [Column("lots_separator")]
    public string? LotsSeparator { get; set; }

    [Column("lots_quantity_separator")]
    public string? LotsQuantitySeparator { get; set; }

    [Column("production_text")]
    public string? ProductionText { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpBatchProduceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductionId")]
    //[InverseProperty("MrpBatchProduces")]
    [NotMapped]
    public virtual MrpProduction? Production { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpBatchProduceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
