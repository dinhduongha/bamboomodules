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
public partial class SaleOrderTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("number_of_days")]
    public long? NumberOfDays { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("prepayment_percent")]
    public double? PrepaymentPercent { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("SaleOrderTemplateNavigation")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SaleOrderTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailTemplateId")]
    // [InverseProperty("SaleOrderTemplate")] //Many2one
    public virtual MailTemplate? MailTemplate { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderTemplateId")]
    [InverseProperty("SaleOrderTemplate")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderTemplateId")]
    [InverseProperty("SaleOrderTemplate")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderTemplateId")]
    [InverseProperty("SaleOrderTemplate")]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLine { get; set; }

    // [One2many]
    [ForeignKey("SaleOrderTemplateId")]
    [InverseProperty("SaleOrderTemplate")]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOption { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SaleOrderTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("SaleOrderTemplateId")]
    // [InverseProperty("SaleOrderTemplate")]
    public virtual ICollection<QuotationDocument> QuotationDocument { get; set; }
}
