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

[Table("ir_model_relation")]
//[Index("Model", Name = "ir_model_relation__model_index")]
//[Index("Module", Name = "ir_model_relation__module_index")]
//[Index("Name", Name = "ir_model_relation__name_index")]
public partial class IrModelRelation: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("model")]
    public Guid? Model { get; set; }

    [Column("module")]
    public Guid? Module { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrModelRelationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("Model")]
    // [InverseProperty("IrModelRelation")] //Many2one
    public virtual IrModel? ModelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("Module")]
    // [InverseProperty("IrModelRelation")] //Many2one
    public virtual IrModuleModule? ModuleNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrModelRelationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
