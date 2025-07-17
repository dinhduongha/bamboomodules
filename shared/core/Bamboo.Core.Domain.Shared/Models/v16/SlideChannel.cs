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
//[Index("IsPublished", Name = "slide_channel__is_published_index")]
//[Index("WebsiteId", Name = "slide_channel__website_id_index")]
public partial class SlideChannel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }


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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("description_short", TypeName = "jsonb")]
    public string? DescriptionShort { get; set; }

    [Column("description_html", TypeName = "jsonb")]
    public string? DescriptionHtml { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("nbr_certification")]
    public long? NbrCertification { get; set; }

    [ForeignKey("CompletedTemplateId")]
    //[InverseProperty("SlideChannelCompletedTemplates")]
    [NotMapped]
    public virtual MailTemplate? CompletedTemplate { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideChannelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("...")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<HrResumeLine> HrResumeLines { get; set; } = new List<HrResumeLine>();

    [ForeignKey("PromotedSlideId")]
    //[InverseProperty("SlideChannels")]
    [NotMapped]
    public virtual SlideSlide? PromotedSlide { get; set; }

    [ForeignKey("PublishTemplateId")]
    //[InverseProperty("SlideChannelPublishTemplates")]
    [NotMapped]
    public virtual MailTemplate? PublishTemplate { get; set; }

    [ForeignKey("ShareChannelTemplateId")]
    //[InverseProperty("SlideChannelShareChannelTemplates")]
    [NotMapped]
    public virtual MailTemplate? ShareChannelTemplate { get; set; }

    [ForeignKey("ShareSlideTemplateId")]
    //[InverseProperty("SlideChannelShareSlideTemplates")]
    [NotMapped]
    public virtual MailTemplate? ShareSlideTemplate { get; set; }

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<SlideChannelInvite> SlideChannelInvites { get; set; } = new List<SlideChannelInvite>();

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<SlideChannelPartner> SlideChannelPartners { get; set; } = new List<SlideChannelPartner>();

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<SlideSlidePartner> SlideSlidePartners { get; set; } = new List<SlideSlidePartner>();

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<SlideSlide> SlideSlides { get; set; } = new List<SlideSlide>();

    [ForeignKey("UserId")]
    //[InverseProperty("SlideChannelUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("SlideChannels")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideChannelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("PrerequisiteChannelId")]
    //[InverseProperty("PrerequisiteChannels")]
    [NotMapped]
    public virtual ICollection<SlideChannel> Channels { get; set; } = new List<SlideChannel>();

    [ForeignKey("ChannelId")]
    //[InverseProperty("Channels")]
    [NotMapped]
    public virtual ICollection<ResGroup> Groups { get; set; } = new List<ResGroup>();

    [ForeignKey("ChannelId")]
    //[InverseProperty("Channels")]
    [NotMapped]
    public virtual ICollection<SlideChannel> PrerequisiteChannels { get; set; } = new List<SlideChannel>();

    [ForeignKey("SlideChannelId")]
    //[InverseProperty("SlideChannels")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroups { get; set; } = new List<ResGroup>();

    [ForeignKey("ChannelId")]
    //[InverseProperty("Channels")]
    [NotMapped]
    public virtual ICollection<SlideChannelTag> Tags { get; set; } = new List<SlideChannelTag>();
}
