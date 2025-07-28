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

[Table("slide_slide_partner")]
//[Index("ChannelId", Name = "slide_slide_partner__channel_id_index")]
//[Index("PartnerId", Name = "slide_slide_partner__partner_id_index")]
//[Index("SlideId", Name = "slide_slide_partner__slide_id_index")]
//[Index("SlideId", "PartnerId", Name = "slide_slide_partner_slide_partner_uniq", IsUnique = true)]
public partial class SlideSlidePartner: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("slide_id")]
    public Guid? SlideId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("vote")]
    public long? Vote { get; set; }

    [Column("quiz_attempts_count")]
    public long? QuizAttemptsCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("completed")]
    public bool? Completed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("survey_scoring_success")]
    public bool? SurveyScoringSuccess { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("SlideSlidePartners")]
    [NotMapped]
    public virtual SlideChannel? Channel { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideSlidePartnerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("SlideSlidePartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("SlideId")]
    //[InverseProperty("SlideSlidePartners")]
    [NotMapped]
    public virtual SlideSlide? Slide { get; set; }

    //[InverseProperty("SlidePartner")]
    [NotMapped]
    public virtual ICollection<SurveyUserInput> SurveyUserInputs { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideSlidePartnerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
