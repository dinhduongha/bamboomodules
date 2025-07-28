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
public partial class SaleOrderTemplate: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("number_of_days")]
    public long? NumberOfDays { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [JsonField]
    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

    [JsonField]
    [Column("journal_id", TypeName = "jsonb")]
    public string? JournalId { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("require_signature")]
    public bool? RequireSignature { get; set; }

    [Column("require_payment")]
    public bool? RequirePayment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("prepayment_percent")]
    public double? PrepaymentPercent { get; set; }

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
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    //[InverseProperty("SaleOrderTemplate")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; set; } 

    //[InverseProperty("SaleOrderTemplate")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; } 

    //[InverseProperty("SaleOrderTemplate")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } 

    [ForeignKey("SaleOrderTemplateId")]
    //[InverseProperty("SaleOrderTemplates")]
    [NotMapped]
    public virtual ICollection<QuotationDocument> QuotationDocuments { get; set; } 
}
