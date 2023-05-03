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

[Table("ir_model_constraint")]
//[Index("Model", Name = "ir_model_constraint_model_index")]
//[Index("Module", Name = "ir_model_constraint_module_index")]
//[Index("Name", "Module", Name = "ir_model_constraint_module_name_uniq", IsUnique = true)]
//[Index("Name", Name = "ir_model_constraint_name_index")]
//[Index("Type", Name = "ir_model_constraint_type_index")]
public partial class IrModelConstraint: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("model")]
    public Guid? Model { get; set; }

    [Column("module")]
    public Guid? Module { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("definition")]
    public string? Definition { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("message", TypeName = "jsonb")]
    public string? Message { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModelConstraintCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("Model")]
    //[InverseProperty("IrModelConstraints")]
    [NotMapped]
    public virtual IrModel? ModelNavigation { get; set; }

    [ForeignKey("Module")]
    //[InverseProperty("IrModelConstraints")]
    [NotMapped]
    public virtual IrModuleModule? ModuleNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModelConstraintWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
