using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("event_question")]
public partial class EventQuestion: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("question_type")]
    public string? QuestionType { get; set; }

    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [Column("once_per_order")]
    public bool? OncePerOrder { get; set; }

    [Column("is_mandatory_answer")]
    public bool? IsMandatoryAnswer { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventQuestionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventId")]
    //[InverseProperty("EventQuestions")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    //[InverseProperty("Question")]
    [NotMapped]
    public virtual ICollection<EventQuestionAnswer> EventQuestionAnswers { get; set; } = new List<EventQuestionAnswer>();

    //[InverseProperty("Question")]
    [NotMapped]
    public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswers { get; set; } = new List<EventRegistrationAnswer>();

    [ForeignKey("EventTypeId")]
    //[InverseProperty("EventQuestions")]
    [NotMapped]
    public virtual EventType? EventType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventQuestionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
