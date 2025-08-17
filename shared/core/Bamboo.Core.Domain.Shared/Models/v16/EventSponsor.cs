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

[Table("event_sponsor")]
//[Index("IsPublished", Name = "event_sponsor_is_published_index")]
public partial class EventSponsor: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("chat_room_id")]
    public Guid? ChatRoomId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("sponsor_type_id")]
    public Guid? SponsorTypeId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("subtitle")]
    public string? Subtitle { get; set; }

    [Column("exhibitor_type")]
    public string? ExhibitorType { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [JsonField]
    [Column("website_description", TypeName = "jsonb")]
    public string? WebsiteDescription { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("hour_from")]
    public double? HourFrom { get; set; }

    [Column("hour_to")]
    public double? HourTo { get; set; }

    // [Many2one]
    [ForeignKey("ChatRoomId")]
    // [InverseProperty("EventSponsor")] //Many2one
    public virtual ChatRoom? ChatRoom { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventSponsorCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("EventSponsor")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    [ForeignKey("SponsorId")]
    [InverseProperty("Sponsor")]
    public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("EventSponsor")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("EventSponsor")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("SponsorTypeId")]
    // [InverseProperty("EventSponsor")] //Many2one
    public virtual EventSponsorType? SponsorType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventSponsorWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
