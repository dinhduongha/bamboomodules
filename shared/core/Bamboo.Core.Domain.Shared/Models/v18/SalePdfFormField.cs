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

[Table("sale_pdf_form_field")]
//[Index("Name", "DocumentType", Name = "sale_pdf_form_field_unique_name_per_doc_type", IsUnique = true)]
public partial class SalePdfFormField: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("document_type")]
    public string? DocumentType { get; set; }

    [Column("path")]
    public string? Path { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SalePdfFormFieldCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SalePdfFormFieldWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SalePdfFormFieldId")]
    //[InverseProperty("SalePdfFormFields")]
    [NotMapped]
    public virtual ICollection<ProductDocument> ProductDocuments { get; set; } = new List<ProductDocument>();

    [ForeignKey("SalePdfFormFieldId")]
    //[InverseProperty("SalePdfFormFields")]
    [NotMapped]
    public virtual ICollection<QuotationDocument> QuotationDocuments { get; set; } = new List<QuotationDocument>();
}
