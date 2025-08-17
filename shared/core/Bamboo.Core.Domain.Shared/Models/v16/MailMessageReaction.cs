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
public partial class MailMessageReaction: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("guest_id")]
    public Guid? GuestId { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    // [Many2one]
    [ForeignKey("GuestId")]
    // [InverseProperty("MailMessageReaction")] //Many2one
    public virtual MailGuest? Guest { get; set; }

    // [Many2one]
    [ForeignKey("MessageId")]
    // [InverseProperty("MailMessageReaction")] //Many2one
    public virtual MailMessage? Message { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("MailMessageReaction")] //Many2one
    public virtual ResPartner? Partner { get; set; }
}
