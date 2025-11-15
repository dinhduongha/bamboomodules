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

public partial class EventQuestion
{

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_default")]
    public bool? IsDefault { get; set; }

    [Column("is_reusable")]
    public bool? IsReusable { get; set; }

    // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("EventQuestionId")] //Many2many // Hidden
    // // [InverseProperty("EventQuestion")] //Many2many // Hidden
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("EventQuestionId")] //Many2many // Hidden
    // // [InverseProperty("EventQuestion")] //Many2many // Hidden
    // public virtual ICollection<EventType> EventType { get; set; }

}