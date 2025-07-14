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
public partial class IrModelInherit: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("parent_field_id")]
    public Guid? ParentFieldId { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("IrModelInheritModels")]
    [NotMapped]
    public virtual IrModel? Model { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("IrModelInheritParents")]
    [NotMapped]
    public virtual IrModel? Parent { get; set; }

    [ForeignKey("ParentFieldId")]
    //[InverseProperty("IrModelInherits")]
    [NotMapped]
    public virtual IrModelField? ParentField { get; set; }
}
