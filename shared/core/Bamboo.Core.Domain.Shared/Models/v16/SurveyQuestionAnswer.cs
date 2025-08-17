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

[Table("survey_question_answer")]
public partial class SurveyQuestionAnswer: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("question_id")]
    public Guid? QuestionId { get; set; }

    [Column("matrix_question_id")]
    public Guid? MatrixQuestionId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("value_image_filename")]
    public string? ValueImageFilename { get; set; }

    [JsonField]
    [Column("value", TypeName = "jsonb")]
    public string? Value { get; set; }

    [Column("is_correct")]
    public bool? IsCorrect { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("answer_score")]
    public double? AnswerScore { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SurveyQuestionAnswerCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MatrixQuestionId")]
    // [InverseProperty("SurveyQuestionAnswerMatrixQuestion")] //Many2one
    public virtual SurveyQuestion? MatrixQuestion { get; set; }

    // [Many2one]
    [ForeignKey("QuestionId")]
    // [InverseProperty("SurveyQuestionAnswerQuestion")] //Many2one
    public virtual SurveyQuestion? Question { get; set; }

    // [One2many]
    [ForeignKey("TriggeringAnswerId")]
    [InverseProperty("TriggeringAnswer")]
    public virtual ICollection<SurveyQuestion> SurveyQuestion { get; set; }

    // [One2many]
    [ForeignKey("MatrixRowId")]
    [InverseProperty("MatrixRow")]
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLineMatrixRow { get; set; }

    // [One2many]
    [ForeignKey("SuggestedAnswerId")]
    [InverseProperty("SuggestedAnswer")]
    public virtual ICollection<SurveyUserInputLine> SurveyUserInputLineSuggestedAnswer { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SurveyQuestionAnswerWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
