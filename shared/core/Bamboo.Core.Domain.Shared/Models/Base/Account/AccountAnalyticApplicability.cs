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

[Table("account_analytic_applicability")]
public partial class AccountAnalyticApplicability : AuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    //[Column("company_id")]
    //public Guid? TenantId { get; set; }

    [Column("analytic_plan_id")]
    public Guid? AnalyticPlanId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("business_domain")]
    public string? BusinessDomain { get; set; }

    [Column("applicability")]
    public string? Applicability { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("product_categ_id")]
    public Guid? ProductCategId { get; set; }

    [Column("account_prefix")]
    public string? AccountPrefix { get; set; }

    //[ForeignKey("TenantId")]
    //[NotMapped]
    //public virtual ResCompany? Company { get; set; }

    [ForeignKey("AnalyticPlanId")]
    //[InverseProperty("AccountAnalyticApplicabilities")]
    [NotMapped]
    public virtual AccountAnalyticPlan? AnalyticPlan { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAnalyticApplicabilityCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductCategId")]
    //[InverseProperty("AccountAnalyticApplicabilities")]
    [NotMapped]
    public virtual ProductCategory? ProductCateg { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAnalyticApplicabilityWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
