using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("forum_post")]
//[Index("CreateDate", Name = "forum_post__create_date_index")]
//[Index("CreateUid", Name = "forum_post__create_uid_index")]
//[Index("ParentId", Name = "forum_post__parent_id_index")]
//[Index("WriteDate", Name = "forum_post__write_date_index")]
//[Index("WriteUid", Name = "forum_post__write_uid_index")]
public partial class ForumPost
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("bump_date", TypeName = "timestamp without time zone")]
    public DateTime? BumpDate { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ForumId")] // Many2many // Normal
    // [InverseProperty("ForumNavigation")] // Many2many // Normal
    // public virtual ICollection<ForumTag> ForumTag { get; set; }
}
