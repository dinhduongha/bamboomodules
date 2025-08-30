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

//[Table("forum_forum")]
//[Index("WebsiteId", Name = "forum_forum__website_id_index")]
public partial class ForumForum
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("menu_id")]
    public Guid? MenuId { get; set; }

    [Column("allow_bump")]
    public bool? AllowBump { get; set; }

    // [Many2one]
    [ForeignKey("MenuId")]
    public virtual WebsiteMenu? Menu { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
