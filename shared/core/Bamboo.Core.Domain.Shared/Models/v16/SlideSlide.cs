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

[Table("slide_slide")]
//[Index("IsPublished", Name = "slide_slide__is_published_index")]
public partial class SlideSlide : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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

    [JsonField(IsSparse = false)] // WebsiteMetaTitle
    [Column("website_meta_title", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaTitle { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaDescription
    [Column("website_meta_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaDescription { get; set; }

    [JsonField] // WebsiteMetaKeywords
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public JsonElement? WebsiteMetaKeywords { get; set; }

    [JsonField(IsSparse = false)] // SeoName
    [Column("seo_name", TypeName = "jsonb")]
    public StringDictionary? SeoName { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [JsonField] // HtmlContent
    [Column("html_content", TypeName = "jsonb")]
    public JsonElement? HtmlContent { get; set; }

    [Column("slug")]
    public string? Slug { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [Column("nbr_certification")]
    public long? NbrCertification { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategoryId")]
    public virtual SlideSlide? Category { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChannelId")]
    public virtual SlideChannel? Channel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CategoryId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Category")] // One2many
    public virtual ICollection<SlideSlide> InverseCategory { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PromotedSlideId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PromotedSlide")] // One2many
    public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SlideId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Slide")] // One2many
    public virtual ICollection<SlideEmbed> SlideEmbed { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SlideId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Slide")] // One2many
    public virtual ICollection<SlideQuestion> SlideQuestion { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SlideId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Slide")] // One2many
    public virtual ICollection<SlideSlidePartner> SlideSlidePartner { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SlideId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Slide")] // One2many
    public virtual ICollection<SlideSlideResource> SlideSlideResource { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SurveyId")]
    public virtual SurveySurvey? Survey { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SlideId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Slide")] // One2many
    public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SlideId")] // Many2many // Normal
    // [InverseProperty("Slide")] // Many2many // Normal
    public virtual ICollection<SlideTag> Tag { get; set; }
}
