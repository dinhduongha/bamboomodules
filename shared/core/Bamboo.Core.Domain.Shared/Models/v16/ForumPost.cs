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

[Table("forum_post")]
//[Index("CreateDate", Name = "forum_post__create_date_index")]
//[Index("CreateUid", Name = "forum_post__create_uid_index")]
//[Index("ParentId", Name = "forum_post__parent_id_index")]
//[Index("WriteDate", Name = "forum_post__write_date_index")]
//[Index("WriteUid", Name = "forum_post__write_uid_index")]
public partial class ForumPost: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("forum_id")]
    public Guid? ForumId { get; set; }

    [Column("views")]
    public long? Views { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("vote_count")]
    public long? VoteCount { get; set; }

    [Column("favourite_count")]
    public long? FavouriteCount { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("child_count")]
    public long? ChildCount { get; set; }

    [Column("flag_user_id")]
    public Guid? FlagUserId { get; set; }

    [Column("moderator_id")]
    public Guid? ModeratorId { get; set; }

    [Column("closed_reason_id")]
    public Guid? ClosedReasonId { get; set; }

    [Column("closed_uid")]
    public Guid? ClosedUid { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

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

    [Column("content")]
    public string? Content { get; set; }

    [Column("plain_content")]
    public string? PlainContent { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_correct")]
    public bool? IsCorrect { get; set; }

    [Column("self_reply")]
    public bool? SelfReply { get; set; }

    [Column("has_validated_answer")]
    public bool? HasValidatedAnswer { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("last_activity_date", TypeName = "timestamp without time zone")]
    public DateTime? LastActivityDate { get; set; }

    [Column("bump_date", TypeName = "timestamp without time zone")]
    public DateTime? BumpDate { get; set; }

    [Column("closed_date", TypeName = "timestamp without time zone")]
    public DateTime? ClosedDate { get; set; }

    [Column("relevancy")]
    public double? Relevancy { get; set; }

    // [Many2one]
    [ForeignKey("ClosedReasonId")]
    // [InverseProperty("ForumPost")] //Many2one
    public virtual ForumPostReason? ClosedReason { get; set; }

    // [Many2one]
    [ForeignKey("ClosedUid")]
    // [InverseProperty("ForumPostClosedU")] //Many2one
    public virtual ResUsers? ClosedU { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ForumPostCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("FlagUserId")]
    // [InverseProperty("ForumPostFlagUser")] //Many2one
    public virtual ResUsers? FlagUser { get; set; }

    // [Many2one]
    [ForeignKey("ForumId")]
    // [InverseProperty("ForumPost")] //Many2one
    public virtual ForumForum? Forum { get; set; }

    // [One2many]
    [ForeignKey("PostId")]
    [InverseProperty("Post")]
    public virtual ICollection<ForumPostVote> ForumPostVote { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<ForumPost> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("ForumPost")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ModeratorId")]
    // [InverseProperty("ForumPostModerator")] //Many2one
    public virtual ResUsers? Moderator { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual ForumPost? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ForumPostWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ForumPostId")] //Many2many
    // [InverseProperty("ForumPost")] //Many2many
    public virtual ICollection<ForumTag> ForumTag { get; set; }

    // v16-Compat
    // [Many2many] // Normal
    //[NotMapped] //Many2many // Normal
    // [ForeignKey("ForumId")] //Many2many
    // [InverseProperty("ForumNavigation")] //Many2many
    //public virtual ICollection<ForumTag> ForumTag { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ForumPostId")] //Many2many
    // [InverseProperty("ForumPost")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
