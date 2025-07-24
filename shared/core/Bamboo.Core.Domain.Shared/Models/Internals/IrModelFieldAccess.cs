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

[Table("ir_model_field_access")]
//[Index("GroupId", Name = "ir_model_access_group_id_index")]
//[Index("ModelId", Name = "ir_model_access_model_id_index")]
//[Index("Name", Name = "ir_model_access_name_index")]
public partial class IrModelFieldAccess: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("field_id")]
    public Guid? FieldId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("model_name")]
    public string? ModelName { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("perm_read")]
    public bool? PermRead { get; set; }

    [Column("perm_write")]
    public bool? PermWrite { get; set; }

    [Column("global")]
    public bool? Global { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModelAccessCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("IrModelAccesses")]
    [NotMapped]
    public virtual ResGroup? Group { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("IrModelAccesses")]
    [NotMapped]
    public virtual IrModel? Model { get; set; }

    [ForeignKey("FieldId")]
    //[InverseProperty("IrModelAccesses")]
    [NotMapped]
    public virtual IrModelField? Field { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModelAccessWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
