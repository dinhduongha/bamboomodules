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

[Table("account_analytic_distribution_model")]
public partial class AccountAnalyticDistributionModel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("partner_category_id")]
    public Guid? PartnerCategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_categ_id")]
    public Guid? ProductCategId { get; set; }

    [Column("account_prefix")]
    public string? AccountPrefix { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountAnalyticDistributionModel")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountAnalyticDistributionModelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("AccountAnalyticDistributionModel")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PartnerCategoryId")]
    // [InverseProperty("AccountAnalyticDistributionModel")] //Many2one
    public virtual ResPartnerCategory? PartnerCategory { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("AccountAnalyticDistributionModel")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductCategId")]
    // [InverseProperty("AccountAnalyticDistributionModel")] //Many2one
    public virtual ProductCategory? ProductCateg { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountAnalyticDistributionModelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
