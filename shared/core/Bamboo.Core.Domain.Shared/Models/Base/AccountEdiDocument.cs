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
//[Index("EdiFormatId", "MoveId", Name = "account_edi_document_unique_edi_document_by_move_by_format", IsUnique = true)]
public partial class AccountEdiDocument: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("edi_format_id")]
    public long? EdiFormatId { get; set; }

    [Column("attachment_id")]
    public Guid? AttachmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("blocking_level")]
    public string? BlockingLevel { get; set; }

    [Column("error")]
    public string? Error { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AttachmentId")]
    //[InverseProperty("AccountEdiDocuments")]
    [NotMapped]
    public virtual IrAttachment? Attachment { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountEdiDocumentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EdiFormatId")]
    //[InverseProperty("AccountEdiDocuments")]
    [NotMapped]
    public virtual AccountEdiFormat? EdiFormat { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("AccountEdiDocuments")]
    [NotMapped]
    public virtual AccountMove? Move { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountEdiDocumentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
