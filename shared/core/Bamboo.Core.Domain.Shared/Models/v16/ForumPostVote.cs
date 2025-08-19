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

[Table("forum_post_vote")]
//[Index("CreateDate", Name = "forum_post_vote__create_date_index")]
//[Index("PostId", "UserId", Name = "forum_post_vote_vote_uniq", IsUnique = true)]
public partial class ForumPostVote: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("post_id")]
    public Guid? PostId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("forum_id")]
    public Guid? ForumId { get; set; }

    [Column("recipient_id")]
    public Guid? RecipientId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("vote")]
    public string? Vote { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ForumPostVoteCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ForumId")]
    // [InverseProperty("ForumPostVote")] //Many2one
    public virtual ForumForum? Forum { get; set; }

    // [Many2one]
    [ForeignKey("PostId")]
    // [InverseProperty("ForumPostVote")] //Many2one
    public virtual ForumPost? Post { get; set; }

    // [Many2one]
    [ForeignKey("RecipientId")]
    // [InverseProperty("ForumPostVoteRecipient")] //Many2one
    public virtual ResUsers? Recipient { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("ForumPostVoteUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ForumPostVoteWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
