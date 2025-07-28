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

[Table("product_document")]
public partial class ProductDocument: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("attached_on_sale")]
    public string? AttachedOnSale { get; set; }

    [Column("attached_on_mrp")]
    public string? AttachedOnMrp { get; set; }

    [Column("shown_on_product_page")]
    public bool? ShownOnProductPage { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductDocumentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("ProductDocuments")]
    [NotMapped]
    public virtual IrAttachment? IrAttachment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductDocumentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ProductDocumentId")]
    //[InverseProperty("ProductDocuments")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } 

    [ForeignKey("ProductDocumentId")]
    //[InverseProperty("ProductDocuments")]
    [NotMapped]
    public virtual ICollection<SalePdfFormField> SalePdfFormFields { get; set; } 
}
