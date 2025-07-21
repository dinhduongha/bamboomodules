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

[Table("event_question_answer")]
public partial class EventQuestionAnswer: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("question_id")]
    public Guid? QuestionId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventQuestionAnswerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("ValueAnswer")]
    [NotMapped]
    public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswers { get; set; } = new List<EventRegistrationAnswer>();

    [ForeignKey("QuestionId")]
    //[InverseProperty("EventQuestionAnswers")]
    [NotMapped]
    public virtual EventQuestion? Question { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventQuestionAnswerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
