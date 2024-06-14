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

[Table("ir_server_object_lines")]
public partial class IrServerObjectLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("server_id")]
    public Guid? ServerId { get; set; }

    [Column("col1")]
    public Guid? Col1 { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("evaluation_type")]
    public string? EvaluationType { get; set; }

    [Column("value")]
    public string? Value { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("Col1")]
    //[InverseProperty("IrServerObjectLines")]
    [NotMapped]
    public virtual IrModelField? Col1Navigation { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrServerObjectLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ServerId")]
    //[InverseProperty("IrServerObjectLines")]
    [NotMapped]
    public virtual IrActServer? Server { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrServerObjectLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
