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

[Table("snailmail_letter_format_error")]
public partial class SnailmailLetterFormatError: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("snailmail_cover")]
    public bool? SnailmailCover { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SnailmailLetterFormatErrorCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageId")]
    //[InverseProperty("SnailmailLetterFormatErrors")]
    [NotMapped]
    public virtual MailMessage? Message { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SnailmailLetterFormatErrorWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
