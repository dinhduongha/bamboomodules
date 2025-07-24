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

[Table("slide_question")]
public partial class SlideQuestion: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("slide_id")]
    public Guid? SlideId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("question", TypeName = "jsonb")]
    public string? Question { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideQuestionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SlideId")]
    //[InverseProperty("SlideQuestions")]
    [NotMapped]
    public virtual SlideSlide? Slide { get; set; }

    //[InverseProperty("Question")]
    [NotMapped]
    public virtual ICollection<SlideAnswer> SlideAnswers { get; set; } = new List<SlideAnswer>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideQuestionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
