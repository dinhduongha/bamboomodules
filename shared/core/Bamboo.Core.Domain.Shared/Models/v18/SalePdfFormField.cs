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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("document_type")]
    public string? DocumentType { get; set; }

    [Column("path")]
    public string? Path { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SalePdfFormFieldCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SalePdfFormFieldWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [ForeignKey("SalePdfFormFieldId")] //Many2many
    // [InverseProperty("SalePdfFormField")] //Many2many
    [NotMapped] //Many2many // Hidden
    public virtual ICollection<ProductDocument> ProductDocument { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [ForeignKey("SalePdfFormFieldId")] //Many2many
    // [InverseProperty("SalePdfFormField")] //Many2many
    [NotMapped] //Many2many // Hidden
    public virtual ICollection<QuotationDocument> QuotationDocument { get; set; }
}
