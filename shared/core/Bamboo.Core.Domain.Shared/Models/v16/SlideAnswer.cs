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

[Table("slide_answer")]
public partial class SlideAnswer: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("question_id")]
    public Guid? QuestionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("text_value", TypeName = "jsonb")]
    public string? TextValue { get; set; }

    [JsonField]
    [Column("comment", TypeName = "jsonb")]
    public string? Comment { get; set; }

    [Column("is_correct")]
    public bool? IsCorrect { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideAnswerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("QuestionId")]
    //[InverseProperty("SlideAnswers")]
    [NotMapped]
    public virtual SlideQuestion? Question { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideAnswerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
