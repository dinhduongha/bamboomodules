using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("event_registration_answer")]
public partial class EventRegistrationAnswer: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("question_id")]
    public Guid? QuestionId { get; set; }

    [Column("registration_id")]
    public Guid? RegistrationId { get; set; }

    [Column("value_answer_id")]
    public Guid? ValueAnswerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("value_text_box")]
    public string? ValueTextBox { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventRegistrationAnswerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("QuestionId")]
    //[InverseProperty("EventRegistrationAnswers")]
    [NotMapped]
    public virtual EventQuestion? Question { get; set; }

    [ForeignKey("RegistrationId")]
    //[InverseProperty("EventRegistrationAnswers")]
    [NotMapped]
    public virtual EventRegistration? Registration { get; set; }

    [ForeignKey("ValueAnswerId")]
    //[InverseProperty("EventRegistrationAnswers")]
    [NotMapped]
    public virtual EventQuestionAnswer? ValueAnswer { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventRegistrationAnswerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
