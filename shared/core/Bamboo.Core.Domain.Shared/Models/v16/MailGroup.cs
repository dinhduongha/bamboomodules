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

[Table("mail_group")]
public partial class MailGroup: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("access_group_id")]
    public Guid? AccessGroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_mode")]
    public string? AccessMode { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("moderation_notify_msg")]
    public string? ModerationNotifyMsg { get; set; }

    [Column("moderation_guidelines_msg")]
    public string? ModerationGuidelinesMsg { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("moderation")]
    public bool? Moderation { get; set; }

    [Column("moderation_notify")]
    public bool? ModerationNotify { get; set; }

    [Column("moderation_guidelines")]
    public bool? ModerationGuidelines { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccessGroupId")]
    public virtual ResGroups? AccessGroup { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    public virtual MailAlias? Alias { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailGroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailGroup")] // One2many
    public virtual ICollection<MailGroupMember> MailGroupMember { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailGroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailGroup")] // One2many
    public virtual ICollection<MailGroupMessage> MailGroupMessage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailGroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailGroup")] // One2many
    public virtual ICollection<MailGroupModeration> MailGroupModeration { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("MailGroupId")] // Many2many // Normal
    // [InverseProperty("MailGroup")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
