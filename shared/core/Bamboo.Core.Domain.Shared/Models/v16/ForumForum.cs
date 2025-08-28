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

[Table("forum_forum")]
//[Index("WebsiteId", Name = "forum_forum__website_id_index")]
public partial class ForumForum: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("authorized_group_id")]
    public Guid? AuthorizedGroupId { get; set; }

    [Column("karma_gen_question_new")]
    public long? KarmaGenQuestionNew { get; set; }

    [Column("karma_gen_question_upvote")]
    public long? KarmaGenQuestionUpvote { get; set; }

    [Column("karma_gen_question_downvote")]
    public long? KarmaGenQuestionDownvote { get; set; }

    [Column("karma_gen_answer_upvote")]
    public long? KarmaGenAnswerUpvote { get; set; }

    [Column("karma_gen_answer_downvote")]
    public long? KarmaGenAnswerDownvote { get; set; }

    [Column("karma_gen_answer_accept")]
    public long? KarmaGenAnswerAccept { get; set; }

    [Column("karma_gen_answer_accepted")]
    public long? KarmaGenAnswerAccepted { get; set; }

    [Column("karma_gen_answer_flagged")]
    public long? KarmaGenAnswerFlagged { get; set; }

    [Column("karma_ask")]
    public long? KarmaAsk { get; set; }

    [Column("karma_answer")]
    public long? KarmaAnswer { get; set; }

    [Column("karma_edit_own")]
    public long? KarmaEditOwn { get; set; }

    [Column("karma_edit_all")]
    public long? KarmaEditAll { get; set; }

    [Column("karma_edit_retag")]
    public long? KarmaEditRetag { get; set; }

    [Column("karma_close_own")]
    public long? KarmaCloseOwn { get; set; }

    [Column("karma_close_all")]
    public long? KarmaCloseAll { get; set; }

    [Column("karma_unlink_own")]
    public long? KarmaUnlinkOwn { get; set; }

    [Column("karma_unlink_all")]
    public long? KarmaUnlinkAll { get; set; }

    [Column("karma_tag_create")]
    public long? KarmaTagCreate { get; set; }

    [Column("karma_upvote")]
    public long? KarmaUpvote { get; set; }

    [Column("karma_downvote")]
    public long? KarmaDownvote { get; set; }

    [Column("karma_answer_accept_own")]
    public long? KarmaAnswerAcceptOwn { get; set; }

    [Column("karma_answer_accept_all")]
    public long? KarmaAnswerAcceptAll { get; set; }

    [Column("karma_comment_own")]
    public long? KarmaCommentOwn { get; set; }

    [Column("karma_comment_all")]
    public long? KarmaCommentAll { get; set; }

    [Column("karma_comment_convert_own")]
    public long? KarmaCommentConvertOwn { get; set; }

    [Column("karma_comment_convert_all")]
    public long? KarmaCommentConvertAll { get; set; }

    [Column("karma_comment_unlink_own")]
    public long? KarmaCommentUnlinkOwn { get; set; }

    [Column("karma_comment_unlink_all")]
    public long? KarmaCommentUnlinkAll { get; set; }

    [Column("karma_flag")]
    public long? KarmaFlag { get; set; }

    [Column("karma_dofollow")]
    public long? KarmaDofollow { get; set; }

    [Column("karma_editor")]
    public long? KarmaEditor { get; set; }

    [Column("karma_user_bio")]
    public long? KarmaUserBio { get; set; }

    [Column("karma_post")]
    public long? KarmaPost { get; set; }

    [Column("karma_moderate")]
    public long? KarmaModerate { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("mode")]
    public string? Mode { get; set; }

    [Column("privacy")]
    public string? Privacy { get; set; }

    [Column("default_order")]
    public string? DefaultOrder { get; set; }

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
    [Column("faq", TypeName = "jsonb")]
    public string? Faq { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("welcome_message", TypeName = "jsonb")]
    public string? WelcomeMessage { get; set; }

    [Column("teaser")]
    public string? Teaser { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("allow_share")]
    public bool? AllowShare { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("relevancy_post_vote")]
    public double? RelevancyPostVote { get; set; }

    [Column("relevancy_time_decay")]
    public double? RelevancyTimeDecay { get; set; }

    [Column("slide_channel_id")]
    public Guid? SlideChannelId { get; set; }

    // [Many2one]
    [ForeignKey("AuthorizedGroupId")]
    public virtual ResGroups? AuthorizedGroup { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ForumId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Forum")] // One2many
    public virtual ICollection<ForumPost> ForumPost { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ForumId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Forum")] // One2many
    public virtual ICollection<ForumPostVote> ForumPostVote { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ForumId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Forum")] // One2many
    public virtual ICollection<ForumTag> ForumTag { get; set; }

    // [Many2one]
    [ForeignKey("SlideChannelId")]
    public virtual SlideChannel? SlideChannel { get; set; }

    // [Many2one]
    public virtual SlideChannel? SlideChannelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
