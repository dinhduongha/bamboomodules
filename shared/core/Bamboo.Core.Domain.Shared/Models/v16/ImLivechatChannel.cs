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

[Table("im_livechat_channel")]
//[Index("IsPublished", Name = "im_livechat_channel__is_published_index")]
public partial class ImLivechatChannel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("header_background_color")]
    public string? HeaderBackgroundColor { get; set; }

    [Column("title_color")]
    public string? TitleColor { get; set; }

    [Column("button_background_color")]
    public string? ButtonBackgroundColor { get; set; }

    [Column("button_text_color")]
    public string? ButtonTextColor { get; set; }

    // v16-Compat json
    [Column("button_text", TypeName = "jsonb")]
    public string? ButtonText { get; set; }

    // v16-Compat json
    [Column("default_message", TypeName = "jsonb")]
    public string? DefaultMessage { get; set; }

    // v16-Compat json
    [Column("input_placeholder", TypeName = "jsonb")]
    public string? InputPlaceholder { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("website_description", TypeName = "jsonb")]
    public string? WebsiteDescription { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ImLivechatChannelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("LivechatChannel")]
    [NotMapped]
    public virtual ICollection<DiscussChannel> DiscussChannels { get; set; } = new List<DiscussChannel>();

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<ImLivechatChannelRule> ImLivechatChannelRules { get; set; } = new List<ImLivechatChannelRule>();

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<Website> Websites { get; set; } = new List<Website>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ImLivechatChannelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("Channels")]
    [NotMapped]
    public virtual ICollection<ResUser> Users { get; set; } = new List<ResUser>();
}
