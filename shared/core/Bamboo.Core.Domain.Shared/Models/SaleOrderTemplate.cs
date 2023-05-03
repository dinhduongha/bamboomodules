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

[Table("sale_order_template")]
public partial class SaleOrderTemplate: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("number_of_days")]
    public long? NumberOfDays { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("require_signature")]
    public bool? RequireSignature { get; set; }

    [Column("require_payment")]
    public bool? RequirePayment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SaleOrderTemplates")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailTemplateId")]
    //[InverseProperty("SaleOrderTemplates")]
    [NotMapped]
    public virtual MailTemplate? MailTemplate { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("SaleOrderTemplate")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //[InverseProperty("SaleOrderTemplate")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("SaleOrderTemplate")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("SaleOrderTemplate")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

}
