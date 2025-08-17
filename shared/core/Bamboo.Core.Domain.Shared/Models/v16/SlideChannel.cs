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

[Table("slide_channel")]
//[Index("ForumId", Name = "slide_channel_forum_uniq", IsUnique = true)]
//[Index("IsPublished", Name = "slide_channel_is_published_index")]
//[Index("WebsiteId", Name = "slide_channel_website_id_index")]
public partial class SlideChannel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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

    [Column("karma_gen_slide_vote")]
    public long? KarmaGenSlideVote { get; set; }

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
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("description_short", TypeName = "jsonb")]
    public string? DescriptionShort { get; set; }

    [JsonField]
    [Column("description_html", TypeName = "jsonb")]
    public string? DescriptionHtml { get; set; }

    [JsonField]
    [Column("enroll_msg", TypeName = "jsonb")]
    public string? EnrollMsg { get; set; }

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
    [ForeignKey("CompletedTemplateId")]
    // [InverseProperty("SlideChannelCompletedTemplate")] //Many2one
    public virtual MailTemplate? CompletedTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SlideChannelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ForumId")]
    // [InverseProperty("SlideChannelNavigation")] //Many2one
    public virtual ForumForum? Forum { get; set; }

    // [One2many]
    [ForeignKey("SlideChannelId")]
    [InverseProperty("SlideChannel")]
    public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("SlideChannel")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("SlideChannel")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("PromotedSlideId")]
    // [InverseProperty("SlideChannel")] //Many2one
    public virtual SlideSlide? PromotedSlide { get; set; }

    // [Many2one]
    [ForeignKey("PublishTemplateId")]
    // [InverseProperty("SlideChannelPublishTemplate")] //Many2one
    public virtual MailTemplate? PublishTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ShareChannelTemplateId")]
    // [InverseProperty("SlideChannelShareChannelTemplate")] //Many2one
    public virtual MailTemplate? ShareChannelTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ShareSlideTemplateId")]
    // [InverseProperty("SlideChannelShareSlideTemplate")] //Many2one
    public virtual MailTemplate? ShareSlideTemplate { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<SlideChannelPartner> SlideChannelPartner { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<SlideSlide> SlideSlide { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<SlideSlidePartner> SlideSlidePartner { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("SlideChannelUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("SlideChannel")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SlideChannelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ChannelId")] //Many2many
    // [InverseProperty("Channel")] //Many2many
    public virtual ICollection<ResGroups> Group { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SlideChannelId")] //Many2many
    // [InverseProperty("SlideChannel")] //Many2many
    public virtual ICollection<ResGroups> ResGroups { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ChannelId")] //Many2many
    // [InverseProperty("Channel")] //Many2many
    public virtual ICollection<SlideChannelTag> Tag { get; set; }
}
