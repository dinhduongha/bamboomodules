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

[Table("account_edi_document")]
//[Index("MoveId", Name = "account_edi_document__move_id_index")]
//[Index("EdiFormatId", "MoveId", Name = "account_edi_document_unique_edi_document_by_move_by_format", IsUnique = true)]
public partial class AccountEdiDocument: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("edi_format_id")]
    public Guid? EdiFormatId { get; set; }

    [Column("attachment_id")]
    public Guid? AttachmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("blocking_level")]
    public string? BlockingLevel { get; set; }

    [Column("error")]
    public string? Error { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AttachmentId")]
    // [InverseProperty("AccountEdiDocument")] //Many2one
    public virtual IrAttachment? Attachment { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountEdiDocumentCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EdiFormatId")]
    // [InverseProperty("AccountEdiDocument")] //Many2one
    public virtual AccountEdiFormat? EdiFormat { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("AccountEdiDocument")] //Many2one
    public virtual AccountMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountEdiDocumentWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
