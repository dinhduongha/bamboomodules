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

[Table("mail_guest")]
public partial class MailGuest: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("timezone")]
    public string? Timezone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    public virtual BusPresence? BusPresence { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("GuestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Guest")] // One2many
    public virtual ICollection<DiscussChannelMember> DiscussChannelMember { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AuthorGuestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AuthorGuest")] // One2many
    public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("GuestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Guest")] // One2many
    public virtual ICollection<MailMessageReaction> MailMessageReaction { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
