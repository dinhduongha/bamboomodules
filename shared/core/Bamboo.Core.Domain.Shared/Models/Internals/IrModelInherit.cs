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

[Table("ir_model_inherit")]
//[Index("ModelId", "ParentId", Name = "ir_model_inherit_uniq", IsUnique = true)]
public partial class IrModelInherit: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("parent_field_id")]
    public Guid? ParentFieldId { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("IrModelInheritModel")] //Many2one
    public virtual IrModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("IrModelInheritParent")] //Many2one
    public virtual IrModel? Parent { get; set; }

    // [Many2one]
    [ForeignKey("ParentFieldId")]
    // [InverseProperty("IrModelInherit")] //Many2one
    public virtual IrModelFields? ParentField { get; set; }
}
