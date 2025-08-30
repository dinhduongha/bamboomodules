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

//[Table("slide_channel")]
//[Index("IsPublished", Name = "slide_channel__is_published_index")]
//[Index("WebsiteId", Name = "slide_channel__website_id_index")]
//[Index("ForumId", Name = "slide_channel_forum_uniq", IsUnique = true)]
public partial class SlideChannel
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("karma_gen_slide_vote")]
    public long? KarmaGenSlideVote { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
