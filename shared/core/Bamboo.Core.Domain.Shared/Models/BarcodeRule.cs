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
public partial class BarcodeRule: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("barcode_nomenclature_id")]
    public long? BarcodeNomenclatureId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("associated_uom_id")]
    public Guid? AssociatedUomId { get; set; }

    [Column("gs1_content_type")]
    public string? Gs1ContentType { get; set; }

    [Column("gs1_decimal_usage")]
    public bool? Gs1DecimalUsage { get; set; }

    [ForeignKey("AssociatedUomId")]
    //[InverseProperty("BarcodeRules")]
    [NotMapped]
    public virtual UomUom? AssociatedUom { get; set; }

    [ForeignKey("BarcodeNomenclatureId")]
    //[InverseProperty("BarcodeRules")]
    [NotMapped]
    public virtual BarcodeNomenclature? BarcodeNomenclature { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BarcodeRuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BarcodeRuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
