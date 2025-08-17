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

[Table("account_fiscal_position_template")]
public partial class AccountFiscalPositionTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("country_group_id")]
    public Guid? CountryGroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("zip_from")]
    public string? ZipFrom { get; set; }

    [Column("zip_to")]
    public string? ZipTo { get; set; }

    [JsonField]
    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

    [Column("auto_apply")]
    public bool? AutoApply { get; set; }

    [Column("vat_required")]
    public bool? VatRequired { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("PositionId")]
    [InverseProperty("Position")]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplate { get; set; }

    // [One2many]
    [ForeignKey("PositionId")]
    [InverseProperty("Position")]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    // [InverseProperty("AccountFiscalPositionTemplate")] //Many2one
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("AccountFiscalPositionTemplate")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CountryGroupId")]
    // [InverseProperty("AccountFiscalPositionTemplate")] //Many2one
    public virtual ResCountryGroup? CountryGroup { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountFiscalPositionTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountFiscalPositionTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountFiscalPositionTemplateId")] //Many2many
    // [InverseProperty("AccountFiscalPositionTemplate")] //Many2many
    public virtual ICollection<ResCountryState> ResCountryState { get; set; }
}
