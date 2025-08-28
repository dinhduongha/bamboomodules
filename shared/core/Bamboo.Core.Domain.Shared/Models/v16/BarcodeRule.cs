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

[Table("barcode_rule")]
public partial class BarcodeRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("barcode_nomenclature_id")]
    public Guid? BarcodeNomenclatureId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("encoding")]
    public string? Encoding { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("pattern")]
    public string? Pattern { get; set; }

    [Column("alias")]
    public string? Alias { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("associated_uom_id")]
    public Guid? AssociatedUomId { get; set; }

    [Column("gs1_content_type")]
    public string? Gs1ContentType { get; set; }

    [Column("gs1_decimal_usage")]
    public bool? Gs1DecimalUsage { get; set; }

    // [Many2one]
    [ForeignKey("AssociatedUomId")]
    public virtual UomUom? AssociatedUom { get; set; }

    // [Many2one]
    [ForeignKey("BarcodeNomenclatureId")]
    public virtual BarcodeNomenclature? BarcodeNomenclature { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
