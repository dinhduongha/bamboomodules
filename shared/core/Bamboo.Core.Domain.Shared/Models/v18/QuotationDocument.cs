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

[Table("quotation_document")]
public partial class QuotationDocument: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("ir_attachment_id")]
    public Guid? IrAttachmentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("document_type")]
    public string? DocumentType { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("QuotationDocumentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("QuotationDocuments")]
    [NotMapped]
    public virtual IrAttachment? IrAttachment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("QuotationDocumentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("QuotationDocumentId")]
    //[InverseProperty("QuotationDocuments")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplates { get; set; } = new List<SaleOrderTemplate>();

    [ForeignKey("QuotationDocumentId")]
    //[InverseProperty("QuotationDocuments")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    [ForeignKey("QuotationDocumentId")]
    //[InverseProperty("QuotationDocuments")]
    [NotMapped]
    public virtual ICollection<SalePdfFormField> SalePdfFormFields { get; set; } = new List<SalePdfFormField>();
}
