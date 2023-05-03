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

[Table("ir_property")]
//[Index("TenantId", Name = "ir_property_company_id_index")]
//[Index("Name", Name = "ir_property_name_index")]
//[Index("ResId", Name = "ir_property_res_id_index")]
//[Index("Type", Name = "ir_property_type_index")]
public partial class IrProperty: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("fields_id")]
    public Guid? FieldsId { get; set; }

    [Column("value_integer")]
    public long? ValueInteger { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("res_id")]
    public string? ResId { get; set; }

    [Column("value_reference")]
    public string? ValueReference { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("value_text")]
    public string? ValueText { get; set; }

    [Column("value_datetime", TypeName = "timestamp without time zone")]
    public DateTime? ValueDatetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("value_float")]
    public double? ValueFloat { get; set; }

    [Column("value_binary")]
    public byte[]? ValueBinary { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("IrProperties")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrPropertyCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("FieldsId")]
    //[InverseProperty("IrProperties")]
    [NotMapped]
    public virtual IrModelField? Fields { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrPropertyWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
