using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class EventEvent
{
    [Column("event_url")]
    public string? EventUrl { get; set; }

    [Column("is_multi_slots")]
    public bool? IsMultiSlots { get; set; }

    [Column("header_visible")]
    public bool? HeaderVisible { get; set; }

    [Column("footer_visible")]
    public bool? FooterVisible { get; set; }

    [Column("is_seo_optimized")]
    public bool? IsSeoOptimized { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("EventId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Event")] // One2many
    // public virtual ICollection<EventQuiz> EventQuiz { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("EventId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Event")] // One2many
    // public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventSlot> EventSlot { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventEventId")] // Many2many // Normal
    // [InverseProperty("EventEvent")] // Many2many // Normal
    public virtual ICollection<EventQuestion> EventQuestion { get; set; }


}