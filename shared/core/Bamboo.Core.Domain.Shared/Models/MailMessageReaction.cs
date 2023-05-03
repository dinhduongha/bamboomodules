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

[Table("mail_message_reaction")]
public partial class MailMessageReaction: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("guest_id")]
    public Guid? GuestId { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    [ForeignKey("GuestId")]
    //[InverseProperty("MailMessageReactions")]
    [NotMapped]
    public virtual MailGuest? Guest { get; set; }

    [ForeignKey("MessageId")]
    //[InverseProperty("MailMessageReactions")]
    [NotMapped]
    public virtual MailMessage? Message { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("MailMessageReactions")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }
}
