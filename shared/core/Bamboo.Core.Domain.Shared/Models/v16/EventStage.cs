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

[Table("event_stage")]
public partial class EventStage: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("legend_blocked", TypeName = "jsonb")]
    public string? LegendBlocked { get; set; }

    [JsonField]
    [Column("legend_done", TypeName = "jsonb")]
    public string? LegendDone { get; set; }

    [JsonField]
    [Column("legend_normal", TypeName = "jsonb")]
    public string? LegendNormal { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("pipe_end")]
    public bool? PipeEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventStageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Stage")]
    [NotMapped]
    public virtual ICollection<EventEvent> EventEvents { get; set; } = new List<EventEvent>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventStageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
