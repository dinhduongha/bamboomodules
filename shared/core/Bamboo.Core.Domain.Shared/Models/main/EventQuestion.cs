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

[Table("event_question")]
public partial class EventQuestion : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("question_type")]
    public string? QuestionType { get; set; }

    [JsonField(IsSparse = false)] // Title
    [Column("title", TypeName = "jsonb")]
    public StringDictionary? Title { get; set; }

    [Column("once_per_order")]
    public bool? OncePerOrder { get; set; }

    [Column("is_mandatory_answer")]
    public bool? IsMandatoryAnswer { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventId")]
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("QuestionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Question")] // One2many
    public virtual ICollection<EventQuestionAnswer> EventQuestionAnswer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("QuestionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Question")] // One2many
    public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswer { get; set; }

    // CONFLICK-V19
    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("EventTypeId")]
    // public virtual EventType? EventType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
