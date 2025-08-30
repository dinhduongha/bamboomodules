using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("event_registration")]
//[Index("UtmCampaignId", Name = "event_registration__utm_campaign_id_index")]
//[Index("UtmMediumId", Name = "event_registration__utm_medium_id_index")]
//[Index("UtmSourceId", Name = "event_registration__utm_source_id_index")]
public partial class EventRegistration
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [Column("is_paid")]
    public bool? IsPaid { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventRegistrationId")] // Many2many // Normal
    // [InverseProperty("EventRegistration")] // Many2many // Normal
    // public virtual ICollection<CrmLead> CrmLead { get; set; }
}
