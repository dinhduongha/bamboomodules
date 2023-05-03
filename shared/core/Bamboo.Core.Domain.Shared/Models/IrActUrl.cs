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

[Table("ir_act_url")]
public partial class IrActUrl: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("binding_model_id")]
    public Guid? BindingModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("binding_type")]
    public string? BindingType { get; set; }

    [Column("binding_view_types")]
    public string? BindingViewTypes { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("help", TypeName = "jsonb")]
    public string? Help { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("target")]
    public string? Target { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [ForeignKey("BindingModelId")]
    //[InverseProperty("IrActUrls")]
    [NotMapped]
    public virtual IrModel? BindingModel { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrActUrlCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrActUrlWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
