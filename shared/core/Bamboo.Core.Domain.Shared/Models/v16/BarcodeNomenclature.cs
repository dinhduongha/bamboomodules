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

[Table("barcode_nomenclature")]
public partial class BarcodeNomenclature: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("upc_ean_conv")]
    public string? UpcEanConv { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("gs1_separator_fnc1")]
    public string? Gs1SeparatorFnc1 { get; set; }

    [Column("is_gs1_nomenclature")]
    public bool? IsGs1Nomenclature { get; set; }

    // [One2many]
    [ForeignKey("BarcodeNomenclatureId")]
    [InverseProperty("BarcodeNomenclature")]
    public virtual ICollection<BarcodeRule> BarcodeRule { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("BarcodeNomenclatureCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("NomenclatureId")]
    [InverseProperty("Nomenclature")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("BarcodeNomenclatureWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
