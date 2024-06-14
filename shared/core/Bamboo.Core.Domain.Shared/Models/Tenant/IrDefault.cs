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

[Table("ir_default")]
//[Index("TenantId", Name = "ir_default_company_id_index")]
//[Index("FieldId", Name = "ir_default_field_id_index")]
//[Index("UserId", Name = "ir_default_user_id_index")]
public partial class IrDefault: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("field_id")]
    public Guid? FieldId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("condition")]
    public string? Condition { get; set; }

    [Column("json_value")]
    public string? JsonValue { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("IrDefaults")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrDefaultCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("FieldId")]
    //[InverseProperty("IrDefaults")]
    [NotMapped]
    public virtual IrModelField? Field { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("IrDefaultUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrDefaultWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
