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

//[Table("event_event")]
//[Index("IsPublished", Name = "event_event__is_published_index")]
//[Index("WebsiteId", Name = "event_event__website_id_index")]
public partial class EventEvent
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("auto_confirm")]
    public bool? AutoConfirm { get; set; }

    [Column("menu_register_cta")]
    public bool? MenuRegisterCta { get; set; }

    // [Many2one]
    //[ForeignKey("MenuId")]
    //public virtual WebsiteMenu? Menu { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
