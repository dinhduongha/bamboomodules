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

    [Column("closed_date", TypeName = "timestamp without time zone")]
    public DateTime? ClosedDate { get; set; }

    [Column("relevancy")]
    public double? Relevancy { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ClosedReasonId")]
    public virtual ForumPostReason? ClosedReason { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ClosedUid")]
    public virtual ResUsers? ClosedU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FlagUserId")]
    public virtual ResUsers? FlagUser { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ForumId")]
    public virtual ForumForum? Forum { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PostId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Post")] // One2many
    public virtual ICollection<ForumPostVote> ForumPostVote { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<ForumPost> InverseParent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ModeratorId")]
    public virtual ResUsers? Moderator { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual ForumPost? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ForumPostId")] // Many2many // Normal
    // [InverseProperty("ForumPost")] // Many2many // Normal
    public virtual ICollection<ForumTag> ForumTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("ForumPostId")] // Many2many // Normal
    // [InverseProperty("ForumPost")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
