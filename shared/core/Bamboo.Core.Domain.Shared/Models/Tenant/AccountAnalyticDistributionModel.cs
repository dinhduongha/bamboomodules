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
public partial class AccountAnalyticDistributionModel: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("partner_category_id")]
    public long? PartnerCategoryId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_categ_id")]
    public long? ProductCategId { get; set; }

    [Column("account_prefix")]
    public string? AccountPrefix { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAnalyticDistributionModels")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAnalyticDistributionModelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("AccountAnalyticDistributionModels")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PartnerCategoryId")]
    //[InverseProperty("AccountAnalyticDistributionModels")]
    [NotMapped]
    public virtual ResPartnerCategory? PartnerCategory { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("AccountAnalyticDistributionModels")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductCategId")]
    //[InverseProperty("AccountAnalyticDistributionModels")]
    [NotMapped]
    public virtual ProductCategory? ProductCateg { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAnalyticDistributionModelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
