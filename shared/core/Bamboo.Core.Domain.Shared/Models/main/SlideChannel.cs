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

[Table("slide_channel")]
//[Index("IsPublished", Name = "slide_channel__is_published_index")]
//[Index("WebsiteId", Name = "slide_channel__website_id_index")]
//[Index("ForumId", Name = "slide_channel_forum_uniq", IsUnique = true)]
public partial class SlideChannel : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("promoted_slide_id")]
    public Guid? PromotedSlideId { get; set; }

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

    [Column("total_views")]
    public long? TotalViews { get; set; }

    [Column("total_votes")]
    public long? TotalVotes { get; set; }

    [Column("publish_template_id")]
    public Guid? PublishTemplateId { get; set; }

    [Column("share_channel_template_id")]
    public Guid? ShareChannelTemplateId { get; set; }

    [Column("share_slide_template_id")]
    public Guid? ShareSlideTemplateId { get; set; }

    [Column("completed_template_id")]
    public Guid? CompletedTemplateId { get; set; }

    [Column("karma_gen_channel_rank")]
    public long? KarmaGenChannelRank { get; set; }

    [Column("karma_gen_channel_finish")]
    public long? KarmaGenChannelFinish { get; set; }

    [Column("karma_review")]
    public long? KarmaReview { get; set; }

    [Column("karma_slide_comment")]
    public long? KarmaSlideComment { get; set; }

    [Column("karma_slide_vote")]
    public long? KarmaSlideVote { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("channel_type")]
    public string? ChannelType { get; set; }

    [Column("promote_strategy")]
    public string? PromoteStrategy { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("enroll")]
    public string? Enroll { get; set; }

    [Column("visibility")]
    public string? Visibility { get; set; }

    [Column("slide_last_update")]
    public DateTime? SlideLastUpdate { get; set; }

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

    [JsonField(IsSparse = false)] // DescriptionShort
    [Column("description_short", TypeName = "jsonb")]
    public StringDictionary? DescriptionShort { get; set; }

    [JsonField(IsSparse = false)] // DescriptionHtml
    [Column("description_html", TypeName = "jsonb")]
    public StringDictionary? DescriptionHtml { get; set; }

    [JsonField] // EnrollMsg
    [Column("enroll_msg", TypeName = "jsonb")]
    public JsonElement? EnrollMsg { get; set; }

    [Column("cover_properties")]
    public string? CoverProperties { get; set; }

    [Column("total_time")]
    public decimal? TotalTime { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("allow_comment")]
    public bool? AllowComment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("nbr_certification")]
    public long? NbrCertification { get; set; }

    [Column("forum_id")]
    public Guid? ForumId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CompletedTemplateId")]
    public virtual MailTemplate? CompletedTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ForumId")]
    public virtual ForumForum? Forum { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SlideChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SlideChannel")] // One2many
    public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PromotedSlideId")]
    public virtual SlideSlide? PromotedSlide { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PublishTemplateId")]
    public virtual MailTemplate? PublishTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ShareChannelTemplateId")]
    public virtual MailTemplate? ShareChannelTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ShareSlideTemplateId")]
    public virtual MailTemplate? ShareSlideTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<SlideChannelPartner> SlideChannelPartner { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<SlideSlide> SlideSlide { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<SlideSlidePartner> SlideSlidePartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PrerequisiteChannelId")] // Many2many // Normal
    // [InverseProperty("PrerequisiteChannel")] // Many2many // Normal
    public virtual ICollection<SlideChannel> Channel { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ChannelId")] // Many2many // Normal
    // [InverseProperty("Channel")] // Many2many // Normal
    public virtual ICollection<ResGroups> Group { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ChannelId")] // Many2many // Normal
    // [InverseProperty("Channel")] // Many2many // Normal
    public virtual ICollection<SlideChannel> PrerequisiteChannel { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SlideChannelId")] // Many2many // Normal
    // [InverseProperty("SlideChannel")] // Many2many // Normal
    public virtual ICollection<ResGroups> ResGroups { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ChannelId")] // Many2many // Normal
    // [InverseProperty("Channel")] // Many2many // Normal
    public virtual ICollection<SlideChannelTag> Tag { get; set; }
}
