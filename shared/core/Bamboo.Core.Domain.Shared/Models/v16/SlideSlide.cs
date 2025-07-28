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

[Table("slide_slide")]
//[Index("IsPublished", Name = "slide_slide__is_published_index")]
public partial class SlideSlide: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("quiz_first_attempt_reward")]
    public long? QuizFirstAttemptReward { get; set; }

    [Column("quiz_second_attempt_reward")]
    public long? QuizSecondAttemptReward { get; set; }

    [Column("quiz_third_attempt_reward")]
    public long? QuizThirdAttemptReward { get; set; }

    [Column("quiz_fourth_attempt_reward")]
    public long? QuizFourthAttemptReward { get; set; }

    [Column("likes")]
    public long? Likes { get; set; }

    [Column("dislikes")]
    public long? Dislikes { get; set; }

    [Column("slide_views")]
    public long? SlideViews { get; set; }

    [Column("public_views")]
    public long? PublicViews { get; set; }

    [Column("total_views")]
    public long? TotalViews { get; set; }

    [Column("nbr_document")]
    public long? NbrDocument { get; set; }

    [Column("nbr_video")]
    public long? NbrVideo { get; set; }

    [Column("nbr_infographic")]
    public long? NbrInfographic { get; set; }

    [Column("nbr_article")]
    public long? NbrArticle { get; set; }

    [Column("nbr_quiz")]
    public long? NbrQuiz { get; set; }

    [Column("total_slides")]
    public long? TotalSlides { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("slide_category")]
    public string? SlideCategory { get; set; }

    [Column("source_type")]
    public string? SourceType { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("slide_type")]
    public string? SlideType { get; set; }

    [JsonField]
    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [JsonField]
    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [JsonField]
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [JsonField]
    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("html_content", TypeName = "jsonb")]
    public string? HtmlContent { get; set; }

    [Column("completion_time")]
    public decimal? CompletionTime { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_preview")]
    public bool? IsPreview { get; set; }

    [Column("is_category")]
    public bool? IsCategory { get; set; }

    [Column("slide_resource_downloadable")]
    public bool? SlideResourceDownloadable { get; set; }

    [Column("date_published", TypeName = "timestamp without time zone")]
    public DateTime? DatePublished { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("nbr_certification")]
    public long? NbrCertification { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("InverseCategory")]
    [NotMapped]
    public virtual SlideSlide? Category { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("SlideSlides")]
    [NotMapped]
    public virtual SlideChannel? Channel { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideSlideCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("...")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }


    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<SlideSlide> InverseCategory { get; set; } 

    //[InverseProperty("PromotedSlide")]
    [NotMapped]
    public virtual ICollection<SlideChannel> SlideChannels { get; set; } 

    //[InverseProperty("Slide")]
    [NotMapped]
    public virtual ICollection<SlideEmbed> SlideEmbeds { get; set; } 

    //[InverseProperty("Slide")]
    [NotMapped]
    public virtual ICollection<SlideQuestion> SlideQuestions { get; set; } 

    //[InverseProperty("Slide")]
    [NotMapped]
    public virtual ICollection<SlideSlidePartner> SlideSlidePartners { get; set; } 

    //[InverseProperty("Slide")]
    [NotMapped]
    public virtual ICollection<SlideSlideResource> SlideSlideResources { get; set; } 

    [ForeignKey("SurveyId")]
    //[InverseProperty("SlideSlides")]
    [NotMapped]
    public virtual SurveySurvey? Survey { get; set; }

    //[InverseProperty("Slide")]
    [NotMapped]
    public virtual ICollection<SurveyUserInput> SurveyUserInputs { get; set; } 

    [ForeignKey("UserId")]
    //[InverseProperty("SlideSlideUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideSlideWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SlideId")]
    //[InverseProperty("Slides")]
    [NotMapped]
    public virtual ICollection<SlideTag> Tags { get; set; } 
}
