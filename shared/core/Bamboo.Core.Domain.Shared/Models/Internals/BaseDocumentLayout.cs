using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
[Table("base_document_layout")]
public partial class BaseDocumentLayout: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("report_layout_id")]
    public Guid? ReportLayoutId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("from_invoice")]
    public bool? FromInvoice { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("BaseDocumentLayouts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BaseDocumentLayoutCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ReportLayoutId")]
    //[InverseProperty("BaseDocumentLayouts")]
    [NotMapped]
    public virtual ReportLayout? ReportLayout { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BaseDocumentLayoutWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
